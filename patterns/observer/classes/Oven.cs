using patterns.observer.interfaces;

namespace patterns.observer.classes;

public class Oven : IObserver
{
    private bool _isMakingFood = false;

    public void MakeFood()
    {
        if (_isMakingFood) throw new ArgumentException("Is already making food.");

        Console.WriteLine("Oven: Starting making the food...");

        _isMakingFood = true;
    }

    public void Update(ISubject subject)
    {
        if (!(subject is Timer)) throw new ArgumentException("Wrong subject given to update.");

        Console.WriteLine("Oven: Finishing making food...");

        _isMakingFood = false;
    }
}