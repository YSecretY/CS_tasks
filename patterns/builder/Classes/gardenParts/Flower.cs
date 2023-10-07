namespace patterns.builder.Classes.gardenParts;

public class Flower
{
    public Flower(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public bool ToSale { get; protected set; }
}