using ModuleTech.Core.Base.Handlers.Search;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Handlers.User.Queries.Filters
{
    public class UserQueryFilter : IFilter
    {
        public Guid Id { get; init; }
        public string? FullName { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? CurrentId { get; init; }
        public string? currentAccountName { get; set; }
        public string? UserType { get; set; }
        public SiteStatusEnum? SiteStatus { get; set; }
        public Guid[]? RepresentativeIds { get; set; }
        public int[]? CountryIds { get; set; }
        public int[]? CityIds { get; set; }
        public int[]? TownIds { get; set; }
        public string? FirstRangeCreatedDate { get; set; }
        public string? LastRangeCreatedDate { get; set; }
    }
}
