namespace patterns.snapshot.classes;

public class Tab
{
    public Tab(string name, string url)
    {
        //TODO: validate
        Name = name;
        Url = url;
    }

    public string Name { get; private set; }
    public string Url { get; private set; }

    public override string ToString()
    {
        return $"Name: {Name}, Url: {Url}";
    }
}