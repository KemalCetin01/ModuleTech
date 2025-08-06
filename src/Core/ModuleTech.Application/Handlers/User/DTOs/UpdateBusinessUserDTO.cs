using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Handlers.User.DTOs
{
    public class UpdateBusinessUserDTO
    {
        public Guid Id { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? TownId { get; set; }
        public Guid? RepresentativeId { get; set; }
        public Guid? BusinessId { get; set; }
        public int? SectorId { get; set; } 
        public int? ActivityAreaId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string PhoneCountryCode { get; set; }
        public string Phone { get; set; }
        public SiteStatusEnum? SiteStatus { get; set; }
        public UserStatusEnum? UserStatus { get; set; }
        public string? PanelPrivileges { get; set; }
        public Guid UserGroupRoleId { get; set; }
    }
}
