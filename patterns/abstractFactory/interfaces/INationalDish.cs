namespace patterns.abstractFactory.interfaces;

public interface INationalDish
{
    public string Country { get; }
    public string Name { get; }
    public List<string> Ingredients { get; }
}