namespace task4;

public interface IRepositoryEntity<TKey>
{
    public TKey Id { get; }
}