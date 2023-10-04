using task5.Repositories;
using task5.Interfaces;

namespace task5.Entities;

public class Client : IClient, IRepositoryEntity<Guid>
{
    private readonly Basket _basket;
    private readonly Wallet _wallet;

    public Guid Id { get; }

    public Client(Basket basket, Wallet wallet)
    {
        Id = Guid.NewGuid();
        _basket = basket;
        _wallet = wallet;
    }

    public void AddToBasket(Product p)
    {
        _basket.Add(p);
    }

    public bool RemoveFromBasket()
    {
        return _basket.Remove();
    }

    public bool Buy()
    {
        try
        {
            _wallet.Reduce(_basket.Sum);

            return true;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"{ex.Message}\nClient {Id} removes one element from basket.");

            _basket.Remove();

            return false;
        }
    }

    public override string ToString()
    {
        return $"{_basket}{_wallet}\nClient id: {Id}\n";
    }
}