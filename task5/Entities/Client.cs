using task5.Repositories;
using task5.Interfaces;
using task5.Validators;

namespace task5.Entities;

public class Client : IClient, IRepositoryEntity<Guid>
{
    private readonly IBasket<Product> _basket;
    private readonly IWallet<decimal> _wallet;

    private static BasketValidator _basketValidator = new();
    private static WalletValidator _walletValidator = new();
    private static ProductValidator _productValidator = new();

    private static FileWriter _fileWriter = new("./task5/logs.txt");
    private static Logger _logger = new(_fileWriter);

    public Client(IBasket<Product> basket, IWallet<decimal> wallet)
    {
        Id = Guid.NewGuid();

        if (!_basketValidator.IsValid(basket as Basket)) throw new ArgumentException("Invalid basket argument given.");
        if (!_walletValidator.IsValid(wallet as Wallet)) throw new ArgumentException("Invalid wallet argument given.");

        _basket = basket;
        _wallet = wallet;
    }

    public Guid Id { get; }

    public void AddToBasket(Product p)
    {
        if (!_productValidator.IsValid(p)) throw new ArgumentException("Invalid product argument given.");

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
            _logger.LogInfo($"{ex.Message}\nClient {Id} removes one element from basket.");

            _basket.Remove();

            return false;
        }
    }

    public override string ToString()
    {
        return $"{_basket}{_wallet}\nClient id: {Id}\n";
    }
}