using patterns.abstractFactory.classes;
using patterns.abstractFactory.interfaces;

namespace patterns;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please choose national dish (Ukraine or Italy): ");
        string? country = Console.ReadLine();

        INationalDishFactory factory = country switch
        {
            "Ukraine" => new UkraineNationalDishFactory(),
            "Italy" => new ItalyNationalDishFactory(),
            _ => throw new ArgumentException("Invalid country input.")
        };

        INationalDish result = factory.CreateNationalDish();

        Console.WriteLine();
        Console.WriteLine(result.Country + " national dish: ");
        Console.WriteLine(result.Name);
        foreach (string ingredient in result.Ingredients)
        {
            Console.Write(ingredient == result.Ingredients.Last() ? $"{ingredient}" : $"{ingredient}, ");
        }

        Console.WriteLine();
    }
}