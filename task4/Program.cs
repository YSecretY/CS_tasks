namespace task4;

internal static class Program
{
    private static void Main()
    {
        DbPlayers db = new DbPlayers();
        Player p1 = new Player("Secret");
        db.AddPlayer(p1);

        for (int i = 0; i < 10; ++i)
        {
            Player p = new Player($"Test{i}");
            db.AddPlayer(p);

            if (i == 4) db.BanPlayer(p);
            if (i == 8) db.RemovePlayer(p);
        }

        Guid toDeleteId = new Guid();
        Guid toBanId = new Guid();
        foreach (Player p in db)
        {
            if (p.Nick.ToString() == "Test6") toDeleteId = p.Id;
            if (p.Nick.ToString() == "Test3") toBanId = p.Id;
        }

        db.RemovePlayer(toDeleteId);
        db.BanPlayer(toBanId);

        foreach (Player p in db)
        {
            db.PrintPlayerInfo(p);
            Console.WriteLine();
        }
    }
}