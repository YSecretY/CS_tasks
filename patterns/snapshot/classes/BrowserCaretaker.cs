using patterns.snapshot.interfaces;

namespace patterns.snapshot.classes;

public class BrowserCaretaker
{
    private List<IMemento<Browser>> _mementos = new();

    private Browser _browser;

    public BrowserCaretaker(Browser browser)
    {
        _browser = browser;
    }

    public void Backup()
    {
        Console.WriteLine("\nBrowserCaretaker: saving browser state...");
        _mementos.Add(_browser.Save());
    }

    public void Undo()
    {
        if (_mementos.Count == 0) return;

        IMemento<Browser> memento = _mementos.Last();
        _mementos.Remove(memento);

        Console.WriteLine("BrowserCaretaker: Restoring state to: " + memento.GetName() + "\n");

        try
        {
            _browser.Restore(memento);
        }
        catch (Exception)
        {
            Undo();
        }
    }

    public void ShowHistory()
    {
        Console.WriteLine("BrowserCaretaker: Here's the list of mementos: ");

        foreach (IMemento<Browser> memento in _mementos)
        {
            Console.WriteLine(memento.GetName());
        }
    }
}