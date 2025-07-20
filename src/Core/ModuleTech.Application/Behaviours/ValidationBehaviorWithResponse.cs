using System.Collections.Immutable;
using FluentValidation;
using MediatR;
using ModuleTech.Core.Base.Dtos;
using ModuleTech.Core.Base.Extentions;
using ModuleTech.Core.ExceptionHandling.Wrapper;
using ValidationException = ModuleTech.Core.ExceptionHandling.Exceptions.ValidationException;

namespace ModuleTech.Application.Behaviours;


/// <summary>
///     Pipeline behavior that validates requests using a collection of validators
/// </summary>
/// <typeparam name="TRequest">The type of request to validate</typeparam>
/// <typeparam name="TResponse">The type of response to return</typeparam>
public class ValidationBehaviorWithResponse<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResponse
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviorWithResponse(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var errors = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName.ToCamelCase(),
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .SelectMany(errorItem => errorItem.Values.Select(errorMessage => new ExceptionErrorResponse
            {
                Field = errorItem.Key,
                Message = errorMessage
            }))
            .ToImmutableList();

        if (errors.Any())
            throw new ValidationException(errors);

        return await next();
    }
}