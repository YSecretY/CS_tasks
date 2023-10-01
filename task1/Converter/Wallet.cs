using System.Data;

namespace Converter;

class Wallet : IWallet
{
    private readonly Dictionary<Currency, decimal> _balance = new();
    
    public Wallet(decimal usd, decimal uah, decimal eur)
    {
        if (usd <= 0) throw new ArgumentOutOfRangeException(nameof(usd));
        if (uah <= 0) throw new ArgumentOutOfRangeException(nameof(uah));
        if (eur <= 0) throw new ArgumentOutOfRangeException(nameof(eur));
        
        _balance.Add(Currency.EUR, eur);
        _balance.Add(Currency.USD, usd);
        _balance.Add(Currency.UAH, uah);
    }

    public decimal USD => _balance.GetValueOrDefault(Currency.USD);
    public decimal UAH => _balance.GetValueOrDefault(Currency.UAH);
    public decimal EUR => _balance.GetValueOrDefault(Currency.EUR);
    
    public void ReduceMoney(decimal amount, Currency currency)
    {
        throw new NotImplementedException();
    }

    public void PutMoney(decimal amount, Currency currency)
    {
        throw new NotImplementedException();
    }

    public decimal GetAmount(Currency currency)
    {
        throw new NotImplementedException();
    }
}
