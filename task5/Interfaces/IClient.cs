using task5.Entities;

namespace task5.Interfaces;

public interface IClient
{
    /// <summary>
    /// Removes peek entity from the basket.
    /// </summary>
    /// <returns></returns>
    public bool RemoveFromBasket();

    /// <summary>
    /// Adds an entity to the basket.
    /// </summary>
    /// <param name="p"></param>
    public void AddToBasket(Product p);

    /// <summary>
    /// Buys all the products in the basket.
    /// </summary>
    /// <returns></returns>
    public bool Buy();
}