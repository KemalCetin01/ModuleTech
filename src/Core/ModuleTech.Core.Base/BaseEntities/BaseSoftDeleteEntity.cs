namespace ModuleTech.Core.BaseEntities;

public abstract class BaseSoftDeleteEntity : BaseAuditableGuidEntity, ISoftDeleteEntity
{
    public bool IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public Guid? DeletedBy { get; set; }
}