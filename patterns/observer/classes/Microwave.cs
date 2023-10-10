using patterns.observer.interfaces;

namespace patterns.observer.classes;

public class Microwave : IObserver
{
    private bool _isHeatingUpFood = false;

    public void MakeFood()
    {
        if (_isHeatingUpFood) throw new ArgumentException("Is already heating food.");

        Console.WriteLine("Microwave: Starting heating up the food...");

        _isHeatingUpFood = true;
    }

    public void Update(ISubject subject)
    {
        if (!(subject is Timer)) throw new ArgumentException("Wrong subject given to update.");

        Console.WriteLine("Microwave: Finishing heating up the food...");

        _isHeatingUpFood = false;
    }
}