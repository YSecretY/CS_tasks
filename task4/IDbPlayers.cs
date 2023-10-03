namespace task4;

public interface IDbPlayers
{
    public void AddPlayer(Player p);

    public void BanPlayer(Player p);

    public void RemovePlayer(Player p);
    
    public bool IsValid(Player p);

    public void PrintPlayerInfo(Guid id);

    public void PrintPlayerInfo(Player p);
}