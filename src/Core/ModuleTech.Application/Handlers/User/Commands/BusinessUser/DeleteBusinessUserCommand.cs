using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;

namespace ModuleTech.Application.Handlers.User.Commands.BusinessUser;

public class DeleteBusinessUserCommand : ICommand
{
    public Guid Id { get; set; }
}
public sealed class DeleteBusinessUserCommandHandler : BaseCommandHandler<DeleteBusinessUserCommand>
{
    private readonly IBusinessUserService _userService;
    public DeleteBusinessUserCommandHandler(IBusinessUserService userService)
    {
        _userService = userService;
    }
    public override async Task Handle(DeleteBusinessUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.DeleteAsync(request.Id, cancellationToken);
    }
}
