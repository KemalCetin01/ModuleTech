using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.User.DTOs;

namespace ModuleTech.Application.Handlers.User.Commands.BusinessUser;

public class ResetBusinessUserPasswordCommand : ResetPasswordCommandDTO, ICommand<DataResponse<bool>>
{
}
public sealed class ResetBusinessUserPasswordCommandHandler : BaseCommandHandler<ResetBusinessUserPasswordCommand, DataResponse<bool>>
{
    private readonly IBusinessUserService _businessUserService;


    public ResetBusinessUserPasswordCommandHandler(IBusinessUserService businessUserService)
    {
        _businessUserService = businessUserService;
    }


    public override async Task<DataResponse<bool>> Handle(ResetBusinessUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var result= await _businessUserService.ResetPasswordAsync(request, cancellationToken);
        return new DataResponse<bool> {Data= result };
    }
}

