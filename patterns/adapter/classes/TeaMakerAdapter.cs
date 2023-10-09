using patterns.adapter.interfaces;

namespace patterns.adapter.classes;

public class TeaMakerAdapter : ITeaMakerAdapter
{
    private readonly CoffeeMachine _coffeeMachine;

    public TeaMakerAdapter(CoffeeMachine coffeeMachine)
    {
        _coffeeMachine = coffeeMachine;
    }

    public void MakeTea()
    {
        Console.WriteLine("Making some tea...");
    }
}