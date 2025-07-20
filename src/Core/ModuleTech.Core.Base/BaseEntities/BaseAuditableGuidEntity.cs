namespace ModuleTech.Core.BaseEntities;

public abstract class BaseAuditableGuidEntity : BaseGuidEntity, IAuditableEntity
{
    public DateTime CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }
}