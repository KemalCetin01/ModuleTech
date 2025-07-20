using MediatR;
using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Handlers;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse> where TResponse : IResponse
{
}

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}