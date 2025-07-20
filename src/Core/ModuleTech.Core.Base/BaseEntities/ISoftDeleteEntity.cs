namespace ModuleTech.Core.BaseEntities;

public interface ISoftDeleteEntity
{
    bool IsDeleted { get; set; }

    DateTime? DeletedDate { get; set; }

    Guid? DeletedBy { get; set; }
}