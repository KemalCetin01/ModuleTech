using ModuleTech.Core.Base.Handlers.Search;

namespace ModuleTech.Application.Handlers.B2bRoles.Queries;

public class SearchBusinessRolesQueryFilter : IFilter
{
    public Guid BusinessId { get; set; }
    public string name { get; set; }
}
