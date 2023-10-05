namespace task4;

public class Nickname : INickname
{
    private string _nickname;

    private static readonly HashSet<char> InvalidNicknameSymbols =
        new HashSet<char> { '$', '&', '@', '^', '%', ' ', '\n', '\t' };

    public Nickname(string nickname)
    {
        if (IsValid(nickname))
            _nickname = nickname;
        else throw new ArgumentException("Invalid nickname symbols.");
    }

    public void Change(string nickname)
    {
        if (IsValid(nickname))
            _nickname = nickname;
        else throw new ArgumentException("Invalid nickname symbols.");
    }

    public override string ToString()
    {
        return _nickname;
    }

    public static bool IsValid(string nickname)
    {
        return !nickname.Any(x => InvalidNicknameSymbols.Contains(x));
    }
}