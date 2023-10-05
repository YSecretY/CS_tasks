using System.Text;
using task5.Interfaces;

namespace task5.Entities;

public class Basket : IBasket<Product>
{
    private readonly Stack<Product> _products = new();

    public decimal Sum { get; private set; }

    public void Add(Product p) //todo: я би тут добавляв через якийсь абстрактний інтерфейс IItem
                                // тому що якщо нам потрібно буде добавити ще якісь конкретні продукти,
                                // то прийдеться наслідуватись від Product, напряму від нього залежити, а він може бути не ідеальним
                                // хоча з іншої сторони не критична тому що гибкості добавляє  IBasket<Product>
    {
        _products.Push(p);

        Sum += p.Cost;
    }

    public bool Remove()
    {
        if (_products.Count == 0) return false;

        Sum -= _products.Peek().Cost;

        _products.Pop();

        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var p in _products)
            sb.AppendLine(p.ToString());

        sb.AppendLine($"Total sum: {Sum}");

        return sb.ToString();
    }
}