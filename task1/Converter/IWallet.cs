namespace Converter;

public interface IWallet
{
    decimal USD { get; }
    decimal UAH { get; }
    decimal EUR { get; }

    string ToString();
    
    void ReduceMoney(decimal amount, Currency currency);
    void PutMoney(decimal amount, Currency currency);
    decimal GetAmount(Currency currency);
}