namespace ModuleTech.Core.BaseEntities;

public interface IAuditableEntity
{
    DateTime CreatedDate { get; set; }

    Guid? CreatedBy { get; set; }

    DateTime? UpdatedDate { get; set; }

    Guid? UpdatedBy { get; set; }
}