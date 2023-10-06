namespace task5.Repositories;

public interface IRepositoryEntity<TKey>
{
    public TKey Id { get; }
}