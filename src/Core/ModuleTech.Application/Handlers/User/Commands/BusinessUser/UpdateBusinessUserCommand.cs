
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Core.Base.Handlers;

namespace ModuleTech.Application.Handlers.User.Commands.BusinessUser;

public class UpdateBusinessUserCommand : UpdateBusinessUserCommandDTO, ICommand<BusinessUserGetByIdDTO>
{
  
}

public sealed class BusinessUserCommandHandler : BaseCommandHandler<UpdateBusinessUserCommand, BusinessUserGetByIdDTO>
{
    private readonly IBusinessUserService _userService;
    private readonly IUserEmployeeService _userEmployeeService;
    public BusinessUserCommandHandler(IBusinessUserService userService,
                                 IUserEmployeeService userEmployeeService)
    {
        _userService = userService;
        _userEmployeeService = userEmployeeService;
    }

    public override async Task<BusinessUserGetByIdDTO> Handle(UpdateBusinessUserCommand request, CancellationToken cancellationToken)
    {
        if (request.RepresentativeId.HasValue)
            await _userEmployeeService.GetByIdAsync(request.RepresentativeId.Value, cancellationToken);

        return await _userService.UpdateAsync(request,cancellationToken);
    }
}
