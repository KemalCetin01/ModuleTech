using ModuleTech.Application.Handlers.Auth.DTOs.B2BUser;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;

namespace ModuleTech.Application.Handlers.Auth.Queries;

public class B2BValidateSignUpInfoQuery : B2BValidateSignUpInfoDTO, IQuery<DataResponse<bool>>
{

}
public sealed class B2BValidateSignUpInfoQueryHandler : BaseQueryHandler<B2BValidateSignUpInfoQuery, DataResponse<bool>>
{

    public B2BValidateSignUpInfoQueryHandler()
    {
    }

    public override async Task<DataResponse<bool>> Handle(B2BValidateSignUpInfoQuery request, CancellationToken cancellationToken)
    {
       
        return new DataResponse<bool>() { Data = true };
    }
}