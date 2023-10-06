namespace task5.Interfaces;

public interface IBasket<in TEntity>
{
    /// <summary>
    /// Adds the given entity to the basket.
    /// </summary>
    /// <param name="entity"></param>
    public void Add(TEntity entity);

    /// <summary>
    /// Removes the peek entity in the basket.
    /// </summary>
    /// <returns></returns>
    public bool Remove();

    public decimal Sum { get; }
}