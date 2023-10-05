using System.Collections;

namespace task4;

//TODO: можна було би назвати IPlayerRepository, все що має подібний функціонал в вебі дуже часто називають по такому принципу EntityRepository
public class DbPlayers : IDbPlayers, IEnumerable<Player> 
{
    private readonly List<Player> _players = new List<Player>();

    //TODO: по поводу назви, ісходя з назви класу DbPlayers зразу зрозуміло що це якесь храніліще користувачів,
    //TODO: і в нього будуть методи по типу Add / Remove / Get і тд, так як контекст вже заданий, можна не писати в кінці кожного методу ..Player,
    //TODO: Краще переіменувати на Add, Remove, Ban і тд
    /// <summary>
    /// Adds a new player to the database.
    /// </summary>
    /// <param name="p">Instance of the player.</param>
    /// <exception cref="ArgumentException">If given instance is invalid.</exception>
    public void AddPlayer(Player p)
    {
        if (!IsValid(p)) throw new ArgumentException("Invalid player. Cannot add it to db.");//TODO: між логічно розділеними строками, краще вставляти пусту строку, так читати легче
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
        Player? p = _players.FirstOrDefault(p => p.Id == id); //TODO: тут краще киньту виключення,
                                                              //якщо такого користувача немає, клієнський код очікує бану, а пофакту нічого не відбудеться
                                                              //в c# ми працюємо по принципу мусор на вході - ексепшин на виході
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
<<<<<<< HEAD
        //todo: валідувати нік користувача, гуїд і тд, все що відноситься до користувача, повинен робити конструктор користувача (Player),
        //конструктури для того і створили для того щоб породити обєкт, якщо обєкт з невалідним станом, це його проблема
        //тому що так прийдетсья у всіх класах де на вході приймається користувач писати валідатори, і визивати IsValid()
        return p.Id != Guid.Empty && p.IsValid(p.NickName) && p.IsValid(p.Level);
=======
        return p.Id != Guid.Empty && Nickname.IsValid(p.Nick.ToString()) && p.IsValid(p.Level);
>>>>>>> dev
    }

    /// <summary>
    /// Prints info of the player with given id.
    /// </summary>
    /// <param name="id">Id of the player to print.</param>
    //TODO: в даному випадку цей метод краще винести в інший клас, або в Program
    //TODO: в репозиторія, храніліща єдина відповідальність - зберігати в собі користувачів, і міняти їх стан
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

    public IEnumerator GetEnumerator() //TODO: по поводу IEnumerator непогано придумано)
                                       //я також робив свою оболочку репозиторіїв реалізуя IEnumerable IEnumerator, можу якщо що потім показати
    {
        return _players.GetEnumerator();
    }

    IEnumerator<Player> IEnumerable<Player>.GetEnumerator()
    {
        return _players.GetEnumerator();
    }
}