using MediatR;
using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Handlers;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse> where TResponse : IResponse
{
}