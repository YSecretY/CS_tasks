namespace task4;

public class Player : IPlayer, IRepositoryEntity<Guid>
{
    public Player(string nickName)
    {
        if (nickName == null) throw new ArgumentNullException(nameof(nickName));
        
        Id = Guid.NewGuid();
        NickName = nickName;
        Level = 1;
        IsBanned = false;
    }
    
    public Guid Id { get; }
    public string NickName { get; }
    public int Level { get; }
    public bool IsBanned { get; private set; }

    public void ApplyBan() //TODO: ApplyBan() більше характеризує суть, він приймає бан
    {
        IsBanned = true;
    }

    public override string ToString()
    {
        return $"Nickname: {NickName}\n" +
               $"Level:    {Level}\n" +
               $"Banned:   {IsBanned}\n" +
               $"Id:       {Id}";
    }
}