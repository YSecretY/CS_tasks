using patterns.abstractFactory.interfaces;

namespace patterns.abstractFactory.classes;

public class NationalDish : INationalDish
{
    public NationalDish(string country, string name, List<string> ingredients)
    {
        //TODO: check if valid
        Country = country;
        Name = name;
        Ingredients = ingredients;
    }

    public string Country { get; }
    public string Name { get; }
    public List<string> Ingredients { get; }
}