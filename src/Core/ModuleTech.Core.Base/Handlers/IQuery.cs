using MediatR;
using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Handlers;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : IResponse
{
}