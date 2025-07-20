using MediatR;
using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Handlers;

public interface ICommand<out TResponse> : IRequest<TResponse> where TResponse : IResponse
{
}

public interface ICommand : IRequest
{
}