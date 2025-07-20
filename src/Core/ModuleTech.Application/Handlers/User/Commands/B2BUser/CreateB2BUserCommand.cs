using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Core.Base.Handlers;

namespace ModuleTech.Application.Handlers.User.Commands.B2BUser;

public class CreateB2BUserCommand : CreateB2BUserCommandDTO, ICommand<B2BUserGetByIdDTO>
{

}

public sealed class CreateB2BUserCommandHandler : BaseCommandHandler<CreateB2BUserCommand, B2BUserGetByIdDTO>
{
    private readonly IUserB2BService _userB2BService;
    private readonly IUserEmployeeService _userEmployeeService;
    public CreateB2BUserCommandHandler(IUserB2BService userB2BService,
                                       IUserEmployeeService userEmployeeService)
    {
        _userB2BService = userB2BService;
        _userEmployeeService = userEmployeeService;
    }

    public override async Task<B2BUserGetByIdDTO> Handle(CreateB2BUserCommand request, CancellationToken cancellationToken)
    {
        return await _userB2BService.CreateAsync(request, cancellationToken);
    }
}