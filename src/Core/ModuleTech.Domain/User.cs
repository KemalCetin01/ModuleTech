using ModuleTech.Core.Base.Attributes;
using ModuleTech.Core.BaseEntities;

namespace ModuleTech.Domain;

public class User : BaseSoftDeleteEntity
{
    [QuerySearch]
    public string FirstName { get; set; } = null!;
    [QuerySearch]
    public string LastName { get; set; } = null!;
    [QuerySearch]
    public string Email { get; set; } = null!;
    public string? Suffix { get; set; }
    public Guid IdentityRefId { get; set; }

}