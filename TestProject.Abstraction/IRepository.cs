namespace TestProject.Abstraction
{
    public interface IRepository<TEntity> : ICrudActions<TEntity> where TEntity: BaseEntity
    {
    }
}