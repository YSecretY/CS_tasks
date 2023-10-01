using System.ComponentModel;

namespace Converter;

public class HardcodeCourseProvider : ICourseRateProvider
{
    private static Dictionary<Currency, decimal> _courseToUSD = new()
    {
        { Currency.UAH, 40.0M },
        { Currency.EUR, 0.94M },
        { Currency.USD, 1.0M }
    };
    
    public decimal GetUsdCourse(Currency currency)
    {
        if (currency == Currency.None) throw new InvalidEnumArgumentException("currency must be set.");

        return _courseToUSD.GetValueOrDefault(currency);
    }
}