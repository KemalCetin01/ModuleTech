using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Handlers;

public abstract class BaseQueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse> where TResponse : IResponse
{
    public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
}