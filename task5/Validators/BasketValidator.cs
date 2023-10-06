using task5.Entities;

namespace task5.Validators;

public class BasketValidator : IValidator<Basket>
{
    public bool IsValid(Basket? basket)
    {
        return basket != null; //TODO: nothing to check more.
    }
}