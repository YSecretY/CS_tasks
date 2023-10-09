using patterns.abstractFactory.interfaces;

namespace patterns.abstractFactory.classes;

public class ItalyNationalDishFactory : INationalDishFactory
{
    public INationalDish CreateNationalDish()
    {
        return new NationalDish("Italy", "Ragu alla Bolognese",
            new List<string>()
            {
                "Beef", "Carrots", "Yellow onions ", "Black pepper", "Pancetta bacon", "Extra virgin olive oil",
                "Tomato puree",
                "Celery", "Fine salt", "Red wine", "Vegetable broth"
            });
    }
}