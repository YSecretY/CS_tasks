namespace task4;

public class PlayerValidator : IValidator<Player>
{
    private readonly HashSet<char> _invalidNickNameSymbols =
        new() { '$', '&', '@', '^', '%', ' ', '\n', '\t' };
    
    public bool Validate(Player target)
    {
        return IsValid(target.NickName) && IsValid(target.Level);
    }
    
    private bool IsValid(string nickName)
    {
        return nickName.Length > 2 && !nickName.Any(x => _invalidNickNameSymbols.Contains(x));
    }
    
    private bool IsValid(int level)
    {
        return level is >= 1 and <= 180;
    }
}