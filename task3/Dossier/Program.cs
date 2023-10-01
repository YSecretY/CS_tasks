namespace Dossier;

class Program
{
    static void Main()
    {
        Dossier dos = new Dossier();

        bool isRunning = true;
        while (isRunning)
        {
            Console.Write("What would you like to do: ");
            string? response = Console.ReadLine();
            switch (response?.ToLower())
            {
                case "add":
                    Console.Write("Please input full name of the person: ");
                    string? name = Console.ReadLine();
                    Console.Write("Please input their position: ");
                    string? position = Console.ReadLine();
                    dos.AddInfo(name, position);
                    break;

                case "remove":
                    Console.Write("Please input full name of the person: ");
                    name = Console.ReadLine();
                    dos.RemoveInfo(name);
                    break;

                case "get":
                    Console.Write("Please input the surname of the person: ");
                    name = Console.ReadLine();
                    Console.WriteLine(dos.GetInfo(name));
                    break;

                case "print":
                    dos.PrintAll();
                    break;

                case "q":
                    isRunning = false;
                    break;
            }
        }
    }
}