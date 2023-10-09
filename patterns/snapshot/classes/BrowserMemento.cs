using patterns.snapshot.interfaces;

namespace patterns.snapshot.classes;

public class BrowserMemento : IMemento<Browser>
{
    private readonly Browser _state;

    private readonly DateTime _dateTime;

    public BrowserMemento(Browser state)
    {
        _state = new Browser(state);
        _dateTime = DateTime.Now;
    }

    public string GetName()
    {
        return $"{_dateTime} / {_state}\n";
    }

    public DateTime GetDate()
    {
        return _dateTime;
    }

    public Browser GetState()
    {
        return _state;
    }
}