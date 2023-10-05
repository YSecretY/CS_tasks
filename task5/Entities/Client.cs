using task5.Repositories;
using task5.Interfaces;

namespace task5.Entities;

public class Client : IClient, IRepositoryEntity<Guid>
{
    private readonly Basket _basket;
    private readonly Wallet _wallet;
    
    //todo: поня нище конструктора тому що це функціональний член
    public Guid Id { get; }

    //TODO: ми ще до цього дойдемо, но тут краще все таки робити через інтерфейс, тому що зразу залежим від реалізації, а не від абстракції / контракту, принцип DIP (SOLID)
    public Client(Basket basket, Wallet wallet)
    {
        //TODO: провірка вхідних параметрів, може поломати клас, порешення інкапсуляції
        Id = Guid.NewGuid();
        _basket = basket;
        _wallet = wallet;
    }

    public void AddToBasket(Product p)
    {
        //TODO: провірка вхідних параметрів, може поломати клас, порешення інкапсуляції воно добавить в _basket null
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
            //TODO: (на майбутнє) в вебі в таких ситуація краще використовувати логер, це клас який ти налаштовуєш в Program.cs і передаєш через конструктор ILogger
            // це би виглядало приблизно так _logger.LogInformation($"{ex.Message}\nClient {Id} removes one element from basket.")
            // цей лог запишеться туда куда ти налаштуєш, не тільки в консоль, можна в файл записати, в телегу відправити, на емайл (якщо це критична помилка) і тд
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