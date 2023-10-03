namespace task4;

public class Player : IPlayer
{
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
    public void Ban()
    {
        IsBanned = true;
    }
}