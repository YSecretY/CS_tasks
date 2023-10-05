namespace task5.Repositories;

public interface IRepository<TEntity, TKey>
    where TEntity : IRepositoryEntity<TKey>
{
    public void Add(TEntity entity);

    public void Remove();
}