namespace patterns.builder.Classes.gardenParts;

public class Barn
{
    public Barn(string name, decimal area, decimal perimeter)
    {
        //TODO: check if name is valid
        Name = name;
        if (area < 10 || perimeter < 10) throw new ArgumentException("Barn cannot be so small.");
        Area = area;
        Perimeter = perimeter;
    }

    public string Name { get; private set; }

    public decimal Area { get; private set; }

    public decimal Perimeter { get; private set; }
}