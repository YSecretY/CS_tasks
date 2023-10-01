using System.ComponentModel;

namespace Converter;

public class Exchange : IExchange
{
    private readonly ICourseRateProvider _provider;

    public Exchange(ICourseRateProvider provider)
    {
        _provider = provider ?? throw new ArgumentNullException(nameof(provider));
    }

    public void Change(IWallet wallet, Currency from, Currency to, decimal amount)
    {
        if (wallet == null) throw new ArgumentNullException(nameof(wallet));
        if (from == Currency.None) throw new InvalidEnumArgumentException("from value must be set.");
        if (to == Currency.None) throw new InvalidEnumArgumentException("to value must be set.");
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        
        decimal balance = wallet.GetAmount(from);

        if (balance < amount)
            throw new InvalidOperationException("You don't have enough money.");
        
        decimal usdCourseFrom = _provider.GetUsdCourse(from);
        decimal usdCourseTo = _provider.GetUsdCourse(to);
        
        decimal amountToConvertInUsd = ConvertTo(usdCourseFrom, amount);
        decimal convertedValue = ConvertFromUSD(usdCourseTo, amountToConvertInUsd);
        
        wallet.ReduceMoney(amount, from);
        wallet.PutMoney(convertedValue, to);
    }
    
    private decimal ConvertTo(in decimal cource, in decimal amount)
    {
        if (cource == null) throw new ArgumentException("Wrong currency to convert from.");
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));

        return amount / cource;
    }

    private decimal ConvertFromUSD(in decimal toCurrencyCourse, in decimal valUSD)
    {
        if (toCurrencyCourse <= 0) throw new ArgumentOutOfRangeException(nameof(toCurrencyCourse));
        if (valUSD <= 0) throw new ArgumentOutOfRangeException(nameof(valUSD));
        
        return valUSD * toCurrencyCourse;
    }
}