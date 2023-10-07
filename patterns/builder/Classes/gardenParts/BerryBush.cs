using patterns.builder.enums;

namespace patterns.builder.Classes.gardenParts;

public class BerryBush : Bush
{
    public BerryBush(string name) : base(name) => IsBerry = true;

    public BerryBush(string name, BerryTypes berryType) : this(name) => BerryType = berryType;

    public BerryTypes BerryType { get; private set; }

    public override string ToString() => $"Name: {Name}, BerryType: {BerryType}";
}