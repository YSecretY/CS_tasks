using System.Data;

namespace Converter;

class Wallet
{
    private double USD, UAH, EUR;

    private static Dictionary<string, double> courseToUSD = new()
    {
        { "UAH", 40.0 },
        { "EUR", 0.94 },
        { "USD", 1.0 }
    };

    public Wallet()
    {
        USD = 0.0;
        UAH = 0.0;
        EUR = 0.0;
    }

    public Wallet(double USD, double UAH, double EUR)
    {
        this.USD = USD;
        this.UAH = UAH;
        this.EUR = EUR;
    }

    public void ConvertMoney(in string? fromCurrency, in string? toCurrency, in double valToConvert)
    {
        EnoughMoney(valToConvert, GetCurrency(fromCurrency));

        double valToConvertInUSD = ConvertToUSD(fromCurrency, valToConvert);
        double convertedValue = ConvertFromUSD(toCurrency, valToConvertInUSD);

        ReduceMoney(fromCurrency, valToConvert);
        AddMoney(toCurrency, convertedValue);
    }

    public double GetCurrency(in string? currency)
    {
        switch (currency?.ToUpper())
        {
            case "USD":
                return USD;
            case "EUR":
                return EUR;
            case "UAH":
                return UAH;
            default:
                throw new ArgumentException("Invalid currency.");
        }
    }

    public void ReadBalance()
    {
        Console.WriteLine("Please input amount of each currency: ");
        Console.Write("USD: ");
        USD = Convert.ToDouble(Console.ReadLine());

        Console.Write("EUR: ");
        EUR = Convert.ToDouble(Console.ReadLine());

        Console.Write("UAH: ");
        UAH = Convert.ToDouble(Console.ReadLine());
    }

    private double ConvertToUSD(in string? from, double valFrom)
    {
        if (from == null)
            throw new ArgumentException("Wrong currency to convert from.");

        string fromUpper = from.ToUpper();

        if (!courseToUSD.ContainsKey(fromUpper))
            throw new ArgumentException("Wrong currency to convert from.");

        return valFrom / courseToUSD[fromUpper];
    }

    private double ConvertFromUSD(in string? to, double valUSD)
    {
        if (to == null)
            throw new ArgumentException("Wrong currency to convert to.");

        string toUpper = to.ToUpper();

        if (!courseToUSD.ContainsKey(toUpper))
            throw new ArgumentException("Wrong currency to convert to.");

        return valUSD * courseToUSD[toUpper];
    }

    private void EnoughMoney(in double wantToConvert, in double haveMoney)
    {
        if (wantToConvert > haveMoney)
            throw new DataException("You don't have enough money.");
    }

    public void PrintBalance()
    {
        Console.WriteLine($"UAH: {UAH}\nUSD: {USD}\nEUR: {EUR}");
    }

    private void ReduceMoney(in string? currency, double value)
    {
        switch (currency?.ToUpper())
        {
            case "USD":
                USD -= value;
                break;
            case "UAH":
                UAH -= value;
                break;
            case "EUR":
                EUR -= value;
                break;
        }
    }

    private void AddMoney(in string? currency, double value)
    {
        switch (currency?.ToUpper())
        {
            case "USD":
                USD += value;
                break;
            case "EUR":
                EUR += value;
                break;
            case "UAH":
                UAH += value;
                break;
        }
    }
}
