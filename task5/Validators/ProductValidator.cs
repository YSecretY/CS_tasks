using task5.Entities;

namespace task5.Validators;

public class ProductValidator : IValidator<Product>
{
    private static ProductNameValidator _productNameValidator = new();
    private static CostValidator _costValidator = new();

    public bool IsValid(Product p)
    {
        return _productNameValidator.IsValid(p.Name) && _costValidator.IsValid(p.Cost);
    }
}