using patterns.snapshot.classes;

namespace patterns;

class Program
{
    static void Main()
    {
        Browser browser = new Browser();
        BrowserCaretaker caretaker = new BrowserCaretaker(browser);

        caretaker.Backup();
        browser.DoSomething();
        
        caretaker.Backup();
        browser.DoSomething();
        
        Console.WriteLine();
        caretaker.ShowHistory();

        Console.WriteLine("\nClient: Now, let's rollback!\n");
        caretaker.Undo();

        Console.WriteLine("\n\nClient: Once more!\n");
        caretaker.Undo();

        Console.WriteLine();
    }
}