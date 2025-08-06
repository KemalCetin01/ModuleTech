using ModuleTech.Core.Base.Dtos;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Handlers.User.DTOs
{
    public class BusinessUserGetByIdDTO : IResponse
    {
        public Guid Id { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? TownId { get; set; }
        public int? SectorId { get; set; } //sektör
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneCountryCode { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? CreatedDate { get; set; }
        public Guid? UserGroupRoleId { get; set; }
        public SiteStatusEnum? SiteStatus { get; set; }
        public UserStatusEnum? UserStatus { get; set; }
        public Guid IdentityRefId { get; set; }
    }
}
