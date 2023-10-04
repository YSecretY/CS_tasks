namespace task5.Interfaces;

public interface IWallet<T>
{
    /// <summary>
    /// Adds money to the wallet.
    /// </summary>
    /// <param name="money"></param>
    public void Add(T money);

    /// <summary>
    /// Takes money from the wallet.
    /// </summary>
    /// <param name="money"></param>
    public void Reduce(T money);
}