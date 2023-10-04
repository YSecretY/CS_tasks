namespace task5.Validators;

public class CostValidator : IValidator<decimal>
{
    public bool IsValid(decimal cost)
    {
        return cost >= 0;
    }
}