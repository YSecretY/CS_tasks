namespace patterns.builder.Classes.gardenParts;

public class Fountain
{
    public Fountain(string name)
    {
        //TODO: check if name is valid
        Name = name;
    }

    public string Name { get; private set; }
}