
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Core.Base.Handlers;

namespace ModuleTech.Application.Handlers.User.Commands.B2BUser;

public class UpdateB2BUserCommand : UpdateB2BUserCommandDTO, ICommand<B2BUserGetByIdDTO>
{
  
}

public sealed class B2BUserCommandHandler : BaseCommandHandler<UpdateB2BUserCommand, B2BUserGetByIdDTO>
{
    private readonly IUserB2BService _userService;
    private readonly IUserEmployeeService _userEmployeeService;
    public B2BUserCommandHandler(IUserB2BService userService,
                                 IUserEmployeeService userEmployeeService)
    {
        _userService = userService;
        _userEmployeeService = userEmployeeService;
    }

    public override async Task<B2BUserGetByIdDTO> Handle(UpdateB2BUserCommand request, CancellationToken cancellationToken)
    {
        if (request.RepresentativeId.HasValue)
            await _userEmployeeService.GetByIdAsync(request.RepresentativeId.Value, cancellationToken);

        return await _userService.UpdateAsync(request,cancellationToken);
    }
}
