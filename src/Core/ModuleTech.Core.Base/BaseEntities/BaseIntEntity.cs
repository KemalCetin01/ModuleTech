namespace ModuleTech.Core.BaseEntities;
public abstract class BaseIntEntity : BaseEntity<int>
{
    public override int Id { get; init; } 
}