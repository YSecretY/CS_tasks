using System.IO.Compression;
using System.Text;
using patterns.snapshot.interfaces;

namespace patterns.snapshot.classes;

public class Browser
{
    private List<Tab> _tabs = new();
    private int _numberOfTabs = 1;
    private Tab _mainTab;
    private string _mainTabContent;

    public Browser()
    {
        _mainTab = new Tab("main", "/home");
        _mainTabContent = GenerateRandomShortString();
    }

    public Browser(Browser browser)
    {
        _tabs = browser._tabs;
        _numberOfTabs = browser._numberOfTabs;
        _mainTab = browser._mainTab;
        _mainTabContent = browser._mainTabContent;
    }

    public void AddTab(Tab tab)
    {
        _tabs.Add(tab);
        ++_numberOfTabs;
    }

    public void SetNumberOfTabs(int number) => _numberOfTabs = number;

    public void SetMainTab(Tab tab) => _mainTab = tab;

    public string SetMainTabContent(string content) => _mainTabContent = content;

    public void DoSomething()
    {
        Console.WriteLine("Browser: doing something right now...");
        AddTab(new Tab(GenerateRandomShortString(), GenerateRandomShortString()));
    }

    public IMemento<Browser> Save()
    {
        return new BrowserMemento(this);
    }

    public void Restore(IMemento<Browser> memento)
    {
        if (!(memento is BrowserMemento)) throw new Exception("Unknown memento class.");

        Browser restoredBrowser = memento.GetState();
        for (int i = 0; i < restoredBrowser._tabs.Count; ++i)
        {
            _tabs[i] = restoredBrowser._tabs[i];
        }

        _numberOfTabs = restoredBrowser._numberOfTabs;
        _mainTab = restoredBrowser._mainTab;
        _mainTabContent = restoredBrowser._mainTabContent;

        Console.WriteLine($"Browser: My state has changed to: {this}");
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("Tabs: ");
        foreach (Tab tab in _tabs)
        {
            builder.Append(tab.ToString() + " ");
        }

        builder.AppendLine();

        builder.Append($"Number of tabs: {_numberOfTabs}\n");

        builder.Append($"Main tab: {_mainTab.ToString()}\n");

        builder.Append($"Main tab content: {_mainTabContent}");

        return builder.ToString();
    }

    private static string GenerateRandomShortString()
    {
        string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string res = string.Empty;

        for (int i = 0; i < 5; ++i)
            res += symbols[new Random().Next(0, symbols.Length)];

        return res;
    }
}