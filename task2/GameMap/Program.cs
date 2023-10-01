using GameMap;

class Program
{
    static void Main()
    {
        Map map = new Map();
        map.Create();
        map.SetHero(1, 1);

        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            map.Print();
            map.MoveHero();

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Q)
                {
                    isRunning = false;
                }
            }
            
            Thread.Sleep(100);
        }
    }
}