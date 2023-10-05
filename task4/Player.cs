namespace task4;

public class Player : IPlayer
{
<<<<<<< HEAD
    //TODO: я би цю конфігурацію виніс би в отдєльний клас UserNameValidator, можна його зробити статичним
    private readonly HashSet<char> _invalidNickNameSymbols = 
        new HashSet<char> { '$', '&', '@', '^', '%', ' ', '\n', '\t' };

=======
>>>>>>> dev
    public Guid Id { get; }
    public Nickname Nick { get; }
    public int Level { get; }
    public bool IsBanned { get; private set; }

    public Player(string nickName)
    {
        Id = Guid.NewGuid();
        Nickname nick = new Nickname(nickName);
        Nick = nick;
        Level = 1;
        IsBanned = false;
    }
    
    //TODO: UserNameValidator
    /// <summary>
    /// Checks if given level is valid.
    /// </summary>
    /// <param name="level">Level to check.</param>
    /// <returns>True if valid otherwise false.</returns>
    public bool IsValid(int level)
    {
        return level is >= 1 and <= 180;
    }

    /// <summary>
    /// Ban this player.
    /// </summary>
    public void Ban() //TODO: ApplyBan() більше характеризує суть
    {
        IsBanned = true;
    }
}