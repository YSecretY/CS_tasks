using System.Collections;

namespace task4;

public interface IPlayersRepository :  IRepository<Player, Guid>, IEnumerable<Player>
{
    /// <summary>
    /// Adds a new player to the database.
    /// </summary>
    /// <param name="p">Instance of the player.</param>
    /// <exception cref="ArgumentException">If given instance is invalid.</exception>
    void Add(Player p);

    /// <summary>
    /// Removes a player from the database by given id.
    /// </summary>
    /// <param name="id">Id of the player.</param>
    void Remove(Guid id);

    /// <summary>
    /// Removes a player from the database by given instance.
    /// </summary>
    /// <param name="p">Instance of the player to remove.</param>
    /// <exception cref="ArgumentException">If given instance is invalid.</exception>
    void Remove(Player p);

    /// <summary>
    /// Bans a player with given id.
    /// </summary>
    /// <param name="id">Id of the player to ban.</param>
    void Ban(Guid id);

    /// <summary>
    /// Bans a player by the given instance.
    /// </summary>
    /// <param name="p">Instance of the player to ban.</param>
    /// <exception cref="ArgumentException">If given instance is invalid.</exception>
    void Ban(Player p);
}