namespace ModuleTech.Core.BaseEntities;

public abstract class BaseAuditableIntIdEntity : BaseIntEntity, IAuditableEntity
{
    public DateTime CreatedDate { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public Guid? UpdatedBy { get; set; }
}