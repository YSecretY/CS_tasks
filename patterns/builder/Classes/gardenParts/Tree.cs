namespace patterns.builder.Classes.gardenParts;

public class Tree
{
    public Tree(string name)
    {
        //TODO: check if name is valid
        Name = name;
    }

    public string Name { get; private set; }
    public bool IsFruitful { get; protected set; }
}