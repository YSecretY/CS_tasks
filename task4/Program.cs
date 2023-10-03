namespace task4;

internal static class Program
{
    //1. попробуй розділяти всі класи по папкам, як в цьому прикладі
    //2. на практиці в вебі дуже часто використовують репозиторії, нови створені як абстракція над бд, для зберігання сущностей (в нашому випадку користувачів)
    //3. коментарі з описом методів можна просто всунути в інтерфейс, там вони не так мішати будуть, все одно на практиці в більшості випадків всі будуть користуватись інтерфейсом
    //  тут можна глянути по поводу коментарів https://www.youtube.com/watch?v=zPbbdPAg6rg&ab_channel=SergeyNemchinskiy
    
    private static void Main()
    {
        IValidator<Player> playerValidator = new PlayerValidator();
        IPlayersRepository playerRepository = new PlayersRepository(playerValidator);

        Player p1 = new("Secret");
        
        playerRepository.Add(p1);

        for (int i = 0; i < 10; ++i)
        {
            Player p = new($"Test{i}");
            
            playerRepository.Add(p);

            if (i == 4) playerRepository.Ban(p);
            if (i == 8) playerRepository.Remove(p);
        }

        Guid toDeleteId = new();
        Guid toBanId = new();
        
        foreach (Player p in playerRepository)
        {
            if (p.NickName == "Test6") toDeleteId = p.Id;
            if (p.NickName == "Test3") toBanId = p.Id;
        }

        playerRepository.Remove(toDeleteId);
        playerRepository.Ban(toBanId);

        foreach (Player player in playerRepository)
        {
            Console.WriteLine(player);
        }
    }
}