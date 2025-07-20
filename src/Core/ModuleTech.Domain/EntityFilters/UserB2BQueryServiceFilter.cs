using ModuleTech.Domain.Enums;
using ModuleTech.Core.Base.Models;

namespace ModuleTech.Domain.EntityFilters;

public class UserB2BQueryServiceFilter : IFilterModel
{
    public Guid Id { get; init; }
    public string? FullName { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string CurrentId { get; init; }
    public string? CurrentAccountName { get; set; }
    public SiteStatusEnum? SiteStatus { get; set; }
    public Guid[]? RepresentativeIds { get; set; }
    public string? FirstRangeCreatedDate { get; set; }
    public string? LastRangeCreatedDate { get; set; }
    public string? BusinessName { get; set; }
    public Guid? BusinessId { get; init; }
    public bool? BusinessStatus { get; set; }
}
