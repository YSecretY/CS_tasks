using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace task4;

public class PlayersRepository : IPlayersRepository
{
    private readonly IValidator<Player> _validator;
    private readonly List<Player> _players = new();

    public PlayersRepository(IValidator<Player> validator)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }
    
    public void Add(Player p)
    {
        if (p == null) throw new ArgumentNullException(nameof(p));

        if (_validator.Validate(p) == false) throw new ValidationException("Invalid user.");
        
        _players.Add(p);
    }

    public void Remove(Guid id)
    {
        _players.RemoveAll(p => p.Id == id);
    }

    public void Remove(Player p)
    {
        if (p == null) throw new ArgumentNullException(nameof(p));

        _players.Remove(p);
    }

    public void Ban(Guid id)
    {
        Player p = _players.FirstOrDefault(p => p.Id == id)
                    ?? throw new KeyNotFoundException($"User with id {id} not found.");
        
        p.ApplyBan();
    }

    public void Ban(Player p)
    {
        if (p == null) throw new ArgumentNullException(nameof(p));
        
        p.ApplyBan();
    }

    public IEnumerator GetEnumerator() => _players.GetEnumerator();
    IEnumerator<Player> IEnumerable<Player>.GetEnumerator() => _players.GetEnumerator();
}