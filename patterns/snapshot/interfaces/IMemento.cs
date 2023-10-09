namespace patterns.snapshot.interfaces;

public interface IMemento<T>
{
    public string GetName();

    public T GetState();

    DateTime GetDate();
}