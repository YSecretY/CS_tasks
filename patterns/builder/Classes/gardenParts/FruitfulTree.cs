using patterns.builder.builder.enums;

namespace patterns.builder.Classes.gardenParts;

public class FruitfulTree : Tree
{
    public FruitfulTree(string name) : base(name) => IsFruitful = true;

    public FruitfulTree(string name, FruitTypes fruitType) : this(name) => FruitType = fruitType;

    public FruitTypes FruitType { get; }

    public override string ToString() => $"Name: {Name}, FruitType: {FruitType}";
}