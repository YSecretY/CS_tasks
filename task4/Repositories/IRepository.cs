namespace task4;

public interface IRepository<TEntity, TKey>
    where TEntity : IRepositoryEntity<TKey>
{
    public void Add(TEntity p);

    public void Remove(TKey p);
    public void Remove(TEntity p);
}