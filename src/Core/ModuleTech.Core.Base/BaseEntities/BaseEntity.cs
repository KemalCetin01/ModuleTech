namespace ModuleTech.Core.BaseEntities;

public abstract class BaseEntity<TId> : IEntity
{
    public abstract TId Id { get; init; }
}