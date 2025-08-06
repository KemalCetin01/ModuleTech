using ModuleTech.Core.Base.Dtos;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Handlers.User.DTOs;

public class CreateBusinessUserCommandDTO:IResponse
{
    public int? CountryId { get; set; }
    public int? CityId { get; set; }
    public int? TownId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string RePassword { get; set; } = null!;
    public string PhoneCountryCode { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public SiteStatusEnum SiteStatus { get; set; }
    public UserStatusEnum UserStatus { get; set; }
}
