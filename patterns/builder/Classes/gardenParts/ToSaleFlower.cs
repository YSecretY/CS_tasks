using patterns.builder.enums;

namespace patterns.builder.Classes.gardenParts;

public class ToSaleFlower : Flower
{
    public ToSaleFlower(string name) : base(name) => ToSale = true;

    public ToSaleFlower(string name, FlowerTypes flowerType) : this(name) => FlowerType = flowerType;

    public FlowerTypes FlowerType { get; private set; }

    public override string ToString() => $"Name: {Name}, FlowerType: {FlowerType}";
}