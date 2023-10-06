namespace task5.Validators;

public class ProductNameValidator : IValidator<string>
{
    private readonly HashSet<char> _invalidSymbols = new() { '$', '&', '@', '^', '%', ' ', '\n', '\t' };
    private readonly HashSet<string> _invalidWords = new() { "fuck", "dumb", "bich" };

    public bool IsValid(string name)
    {
        bool invalidSymbols = name.Any(x => _invalidSymbols.Contains(x));
        bool invalidWords = _invalidWords.Any(x => x == name);

        return name.Length > 2 && !invalidSymbols && !invalidWords;
    }
}