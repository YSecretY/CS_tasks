namespace Converter;

public interface IExchange
{
    void Change(IWallet wallet, Currency from, Currency to, decimal amount);
}