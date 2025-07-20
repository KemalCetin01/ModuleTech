namespace ModuleTech.Core.BaseEntities;

public abstract class BaseIdSequenceEntity : ISoftDeleteEntity, IEntity
{
    public int Id { get; set; }
    public string Entity { get; set; } = null!;
    public string Prefix { get; set; } = null!;
    public long Counter { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public Guid? DeletedBy { get; set; }
}

