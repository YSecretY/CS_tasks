namespace task5.Interfaces;

public interface IProduct<T>
{
    /// <summary>
    /// Name of the product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Product's cost.
    /// </summary>
    public T Cost { get; set; }
}