using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;

namespace ModuleTech.Application.Handlers.Auth.Queries;

public class BusinessUserValidateSignUpAddressQuery : BusinessUserValidateSignUpAddressDTO, IQuery<DataResponse<bool>>
{

}
public sealed class BusinessUserValidateSignUpAddressQueryHandler : BaseQueryHandler<BusinessUserValidateSignUpAddressQuery, DataResponse<bool>>
{


    public BusinessUserValidateSignUpAddressQueryHandler()
    {

    }

    public override async Task<DataResponse<bool>> Handle(BusinessUserValidateSignUpAddressQuery request, CancellationToken cancellationToken)
    {


        return new DataResponse<bool>() { Data = true };
    }
}