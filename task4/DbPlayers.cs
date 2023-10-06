using System.Collections;

namespace task4;

public class DbPlayers : IDbPlayers, IEnumerable<Player>
{
    private readonly List<Player> _players = new List<Player>();

    /// <summary>
    /// Adds a new player to the database.
    /// </summary>
    /// <param name="p">Instance of the player.</param>
    /// <exception cref="ArgumentException">If given instance is invalid.</exception>
    public void AddPlayer(Player p)
    {
        if (!IsValid(p)) throw new ArgumentException("Invalid player. Cannot add it to db.");
        _players.Add(p);
    }

    /// <summary>
    /// Removes a player from the database by given id.
    /// </summary>
    /// <param name="id">Id of the player.</param>
    public void RemovePlayer(Guid id)
    {
        _players.RemoveAll(p => p.Id == id);
    }

    /// <summary>
    /// Removes a player from the database by given instance.
    /// </summary>
    /// <param name="p">Instance of the player to remove.</param>
    /// <exception cref="ArgumentException">If given instance is invalid.</exception>
    public void RemovePlayer(Player p)
    {
        if (!IsValid(p)) throw new ArgumentException("Invalid player. Cannot remove it.");
        _players.Remove(p);
    }

    /// <summary>
    /// Bans a player with given id.
    /// </summary>
    /// <param name="id">Id of the player to ban.</param>
    public void BanPlayer(Guid id)
    {
        Player? p = _players.FirstOrDefault(p => p.Id == id);
        p?.Ban();
    }

    /// <summary>
    /// Bans a player by the given instance.
    /// </summary>
    /// <param name="p">Instance of the player to ban.</param>
    /// <exception cref="ArgumentException">If given instance is invalid.</exception>
    public void BanPlayer(Player p)
    {
        if (!IsValid(p)) throw new ArgumentException("Invalid player. Cannot ban it.");
        p?.Ban();
    }

    /// <summary>
    /// Checks if given instance of the player is valid.
    /// </summary>
    /// <param name="p">Instance of the player to check.</param>
    /// <returns>True if valid otherwise false.</returns>
    public bool IsValid(Player p)
    {
        return p.Id != Guid.Empty && Nickname.IsValid(p.Nick.ToString()) && p.IsValid(p.Level);
    }

    /// <summary>
    /// Prints info of the player with given id.
    /// </summary>
    /// <param name="id">Id of the player to print.</param>
    public void PrintPlayerInfo(Guid id)
    {
        foreach (var p in _players.Where(p => p.Id == id))
        {
            Console.WriteLine($"Nickname: {p.Nick}\n" +
                              $"Level:    {p.Level}\n" +
                              $"Banned:   {p.IsBanned}\n" +
                              $"Id:       {p.Id}");
        }
    }

    /// <summary>
    /// Prints info of the player by its instance.
    /// </summary>
    /// <param name="p">Instance of the player.</param>
    /// <exception cref="Exception">If given instance is invalid.</exception>
    public void PrintPlayerInfo(Player p)
    {
        if (!IsValid(p)) throw new Exception("Cannot print player info. Invalid player.");
        Console.WriteLine($"Nickname: {p.Nick}\n" +
                          $"Level:    {p.Level}\n" +
                          $"Banned:   {p.IsBanned}\n" +
                          $"Id:       {p.Id}");
    }

    public IEnumerator GetEnumerator()
    {
        return _players.GetEnumerator();
    }

    IEnumerator<Player> IEnumerable<Player>.GetEnumerator()
    {
        return _players.GetEnumerator();
    }
}