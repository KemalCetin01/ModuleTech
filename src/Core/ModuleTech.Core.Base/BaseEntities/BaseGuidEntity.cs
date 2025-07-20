using MassTransit;

namespace ModuleTech.Core.BaseEntities;

public abstract class BaseGuidEntity : BaseEntity<Guid>
{
    public override Guid Id { get; init; } = NewId.NextGuid();
}