using task5.Interfaces;

namespace task5.Entities;

public class Wallet : IWallet<decimal>
{
    private decimal _money;

    public Wallet(decimal money)
    {
        if (money <= 0) throw new ArgumentOutOfRangeException(nameof(money), "Money cannot be < 0.");

        _money = money;
    }

    public void Add(decimal money)
    {
        if (money < 0) throw new ArgumentOutOfRangeException(nameof(money), "Cannot add negative number of money.");

        _money += money;
    }

    public void Reduce(decimal money)
    {
        if (money < 0) throw new ArgumentOutOfRangeException(nameof(money), "Cannot reduce negative number of money.");
        if (_money < money) throw new InvalidOperationException("Not enough money.");

        _money -= money;
    }

    public override string ToString()
    {
        return $"Current money: {_money}";
    }
}