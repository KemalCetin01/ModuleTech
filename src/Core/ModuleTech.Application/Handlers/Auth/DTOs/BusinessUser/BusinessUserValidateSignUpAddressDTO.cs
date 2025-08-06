using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;

public class BusinessUserValidateSignUpAddressDTO : IResponse
{
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public string AddressName { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string Region { get; set; }
    public string ZipCode { get; set; }
}