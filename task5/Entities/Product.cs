using task5.Interfaces;
using task5.Validators;

namespace task5.Entities;

public class Product : IProduct<decimal>
{
    private string _name;
    private decimal _cost;

    private static ProductNameValidator _validator = new();

    public string Name
    {
        get => _name;

        set
        {
            if (!_validator.IsValid(value)) throw new ArgumentException("Invalid name for the product.", nameof(value));

            _name = value;
        }
    }

    public decimal Cost
    {
        get => _cost;

        set
        {
            CostValidator validator = new CostValidator();

            if (!validator.IsValid(value)) throw new ArgumentException("Invalid cost for the product.", nameof(value));

            _cost = value;
        }
    }

    public Product(string name, decimal cost)
    {
        Name = name;
        _name = name;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"{Name}: {Cost}";
    }
}