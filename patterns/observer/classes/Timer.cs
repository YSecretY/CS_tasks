using patterns.observer.interfaces;

namespace patterns.observer.classes;

public class Timer : ISubject
{
    private readonly List<IObserver> _observers = new();

    private DateTime _alertTime;

    public async Task Set(DateTime alertTime)
    {
        if (alertTime < DateTime.Now) throw new ArgumentException("Wrong alert time given.");

        _alertTime = alertTime;

        await NotifyOnTimeAsync();
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        Console.WriteLine("Timer: Notifying observers...");

        foreach (IObserver observer in _observers)
        {
            observer.Update(this);
        }
    }

    private async Task NotifyOnTimeAsync()
    {
        await Task.Delay(_alertTime - DateTime.Now);

        Notify();
    }
}