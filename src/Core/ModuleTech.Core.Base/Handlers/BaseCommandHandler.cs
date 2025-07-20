using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Handlers;

public abstract class BaseCommandHandler<TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse> where TResponse : IResponse
{
    public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
}

public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
}