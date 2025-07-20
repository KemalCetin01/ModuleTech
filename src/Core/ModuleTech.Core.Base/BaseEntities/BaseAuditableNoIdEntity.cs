namespace ModuleTech.Core.BaseEntities;

public abstract class BaseAuditableNoIdEntity : IAuditableEntity, IEntity
{
    public DateTime CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }
}