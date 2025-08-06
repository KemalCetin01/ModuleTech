using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Core.Base.Handlers;

namespace ModuleTech.Application.Handlers.User.Commands.BusinessUser;

public class CreateBusinessUserCommand : CreateBusinessUserCommandDTO, ICommand<BusinessUserGetByIdDTO>
{

}

public sealed class CreateBusinessUserCommandHandler : BaseCommandHandler<CreateBusinessUserCommand, BusinessUserGetByIdDTO>
{
    private readonly IBusinessUserService _businessUserService;
    private readonly IUserEmployeeService _userEmployeeService;
    public CreateBusinessUserCommandHandler(IBusinessUserService businessUserService,
                                       IUserEmployeeService userEmployeeService)
    {
        _businessUserService = businessUserService;
        _userEmployeeService = userEmployeeService;
    }

    public override async Task<BusinessUserGetByIdDTO> Handle(CreateBusinessUserCommand request, CancellationToken cancellationToken)
    {
        return await _businessUserService.CreateAsync(request, cancellationToken);
    }
}