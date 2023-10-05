using task5.Interfaces;
using task5.Validators;

namespace task5.Entities;

public class Product : IProduct<decimal>
{
    private string _name;
    private decimal _cost;

    public string Name
    {
        get => _name;

        set
        {
            //TODO: в таких випадка краще всього старатись виносити такі сервіси в конструктор, тому що ми стаємо залежними від реалізації (класу)
            //в реальному проекті з веб апі не прийдеться такого писати, при створенні обєкт клас валідації валідує вхідну команду, при успішній валідації створює обєкт Product
            ProductNameValidator validator = new ProductNameValidator();

            if (!validator.IsValid(value)) throw new ArgumentException("Invalid name for the product.", nameof(value));

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
        //TODO: 
        Name = name;
        _name = name;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"{Name}: {Cost}";
    }
}