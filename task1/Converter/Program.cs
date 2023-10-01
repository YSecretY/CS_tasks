using System;
using Converter;

class Program
{
    //іменування неймспейсу {Company}.{Product}.{Layer}
    //Microsoft.AspNetCore.Application
    //Microsoft.EntityFrameworkCore.Core
    
    public static void Main(string[] argc)
    {
        Wallet userWallet = new Wallet();
        userWallet.ReadBalance();

        bool keep = true;
        while (keep)
        {
            Console.Write("What currency would you like to convert: ");
            string? fromCurrency = Console.ReadLine();

            //тут тоже потрібно валідувати вхідні значення, щоб зразу сказати користувачеві що він вводить щось не то
            
            Console.Write("How much would you like to convert: ");
            double valToConvert = Convert.ToDouble(Console.ReadLine());

            Console.Write("To what currency would you like to convert: ");
            string? toCurrency = Console.ReadLine();

            userWallet.ConvertMoney(fromCurrency, toCurrency, valToConvert);
            Console.WriteLine("\nYou balance now: ");

            userWallet.PrintBalance();
            Console.WriteLine();

            Console.Write("Would you like to continue? (Input 'y' if yes, otherwise 'n'): ");
            char response = Convert.ToChar(Console.ReadLine() ?? string.Empty);
            keep = response == 'y';
        }
    }
}