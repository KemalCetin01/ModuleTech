using ModuleTech.Core.Base.Handlers;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Application.Handlers.Auth.DTOs.B2BUser;

namespace ModuleTech.Application.Handlers.Auth.Queries;

public class B2BValidateSignUpAddressQuery : B2BValidateSignUpAddressDTO, IQuery<DataResponse<bool>>
{

}
public sealed class B2BValidateSignUpAddressQueryHandler : BaseQueryHandler<B2BValidateSignUpAddressQuery, DataResponse<bool>>
{


    public B2BValidateSignUpAddressQueryHandler()
    {

    }

    public override async Task<DataResponse<bool>> Handle(B2BValidateSignUpAddressQuery request, CancellationToken cancellationToken)
    {


        return new DataResponse<bool>() { Data = true };
    }
}