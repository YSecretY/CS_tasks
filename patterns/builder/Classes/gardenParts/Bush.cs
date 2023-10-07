namespace patterns.builder.Classes.gardenParts;

public class Bush
{
    public Bush(string name)
    {
        //TODO: check if name is valid
        Name = name;
    }

    public string Name { get; private set; }

    public bool IsBerry { get; protected set; }
}