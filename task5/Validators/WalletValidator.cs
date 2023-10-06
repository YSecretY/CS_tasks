using task5.Entities;

namespace task5.Validators;

public class WalletValidator : IValidator<Wallet>
{
    public bool IsValid(Wallet? wallet)
    {
       return wallet != null; //TODO: nothing to check more
    }
}