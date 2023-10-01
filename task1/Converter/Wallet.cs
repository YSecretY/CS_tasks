using System;
using System.Collections.Generic;
using System.Data;

namespace Converter;

//клас посуті поєднує в собі 2 відповідальності, конвертація валюти і її зберігання
//до прикладу в реальному житті кошельок не зможе сам собі конвертувати з однієї валюти в іншу )

//в класа завжди спочатку йдуть публічні методи, а потім вже приватні

//TODO: в c# прийнято (+згідно рекомендацій майкрософт)
//вказувати явно модифікатор доступа private public protected internal...
class Wallet
{
    //TODO: приватні поля повинні завжди починатись з нижньої риски _ щоб легко в середині програми відрізняти поля від перемінних
    //з великої букви - тільки публічні поля, в цьому випадку краще зробити _usd _uah _eur
    //краще розділити на 3 поля в 3 ряди
    private double USD, UAH, EUR;

    private static Dictionary<string, double> courseToUSD = new()
    {
        //TODO: тут краще винести в enum
        { "UAH", 40.0 }, //TODO: антипатерн "магическое число"
                         //незрозуміло що за число і звідки воно, в цьому випадку краще його винести в поле і назвати до прикладу _uahExchangeRate
                         //про антипатерн https://dev.koshovyi.com/2018/04/18/antipattern-1-magicheskoe-chislo-magic-number/
        { "EUR", 0.94 },
        { "USD", 1.0 }
    };

    public Wallet()
    {
        USD = 0.0; // TODO: так як double це структура, дефолтне значення для нього і так 0.0, не потрібно його ініціалізувати
        UAH = 0.0;
        EUR = 0.0;
    }

    public Wallet(double USD, double UAH, double EUR) // параметри повинні завжди бути з маленької букви
    {
        //TODO: хорошою практикою являєтсья провіряти вхідні параменти в конструкторах і публічних методах, суть інкапсуляції,
        //щоб в обєкта не міг бути неправильний стан і щоб ти його не міг зламати ізвнє
        // if (USD <= 0) throw new ArgumentOutOfRangeException(nameof(USD));
        // if (UAH <= 0) throw new ArgumentOutOfRangeException(nameof(UAH));
        // if (EUR <= 0) throw new ArgumentOutOfRangeException(nameof(EUR));
        
        this.USD = USD; //TODO: якраз щоб не потрібно було ключевого слова this. ми використовуємо _ для fields
        this.UAH = UAH;
        this.EUR = EUR;
    }

    //TODO: тут краще замість string зробити перечислення enum, тоді в параметри метода не можна буде передати нічого лишнього,
    //string дуже абстрактне значення, туда може передатись все що завгодно, + з string потрібно буде валідувати значення, коли enum це робить неявно за нас
    //тут не зовсім зрозумів чому string може бути null
    public void ConvertMoney(in string? fromCurrency, in string? toCurrency, in double valToConvert) //тут старай поменше скорочувати, деколи це не дуже легко читається
    {
        //TODO: тут також провірити вхідні параметри

        //ThrowExceptionIfDontHaveEnoughMoney of CheckBalance
        EnoughMoney(valToConvert, GetCurrency(fromCurrency)); //todo: краще не робити таких вложеностей, винести результат метода GetCurrency в отдєльну перемінну

        double valToConvertInUSD = ConvertToUSD(fromCurrency, valToConvert);
        double convertedValue = ConvertFromUSD(toCurrency, valToConvertInUSD);

        ReduceMoney(fromCurrency, valToConvert);
        AddMoney(toCurrency, convertedValue);
    }
    
    public double GetCurrency(in string? currency) //GetCurrencyBalance GetBalanceByCurrency
    {
        switch (currency?.ToUpper())
        {
            case "USD": //тут енам
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

    public void PrintBalance() //вивід інформації про сущність не задача самої сущності
    {
        Console.WriteLine($"UAH: {UAH}\nUSD: {USD}\nEUR: {EUR}");
    }

    private void ReduceMoney(in string? currency, double value)
    {
        switch (currency?.ToUpper())
        {
            case "USD": //тут тоже краще enum
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
