using patterns.abstractFactory.interfaces;

namespace patterns.abstractFactory.classes;

public class UkraineNationalDishFactory : INationalDishFactory
{
    public INationalDish CreateNationalDish()
    {
        return new NationalDish("Ukraine", "Borscht",
            new List<string>()
            {
                "Sausage", "Vegetables", "Canned tomatoes", "Vegetable oil", "Water", "Garlic", "Sugar",
                "Seasonings", "Sour cream", "Fresh herbs"
            });
    }
}