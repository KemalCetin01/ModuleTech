using ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;
using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;

namespace ModuleTech.Application.Handlers.Auth.Queries;

public class BusinessUserValidateSignUpInfoQuery : BusinessUserValidateSignUpInfoDTO, IQuery<DataResponse<bool>>
{

}
public sealed class BusinessUserValidateSignUpInfoQueryHandler : BaseQueryHandler<BusinessUserValidateSignUpInfoQuery, DataResponse<bool>>
{

    public BusinessUserValidateSignUpInfoQueryHandler()
    {
    }

    public override async Task<DataResponse<bool>> Handle(BusinessUserValidateSignUpInfoQuery request, CancellationToken cancellationToken)
    {
       
        return new DataResponse<bool>() { Data = true };
    }
}