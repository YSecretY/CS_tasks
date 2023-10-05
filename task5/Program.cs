using task5.Repositories;
using task5.Entities;

namespace task5;

class Program
{
    static void Main()
    {
        IClientsRepository clientsRepository = new ClientsRepository();
        
        for (int i = 1; i <= 10; ++i)
        {
            Client c = new Client(new Basket(), new Wallet(i * 10));
            for (int j = 1; j <= 5; ++j)
                c.AddToBasket(new Product($"prod{j}", j * 3));
            clientsRepository.Add(c);
        }

        foreach (Client c in clientsRepository)
        {
            while (!c.Buy())
                c.RemoveFromBasket();
        }

        foreach (Client c in clientsRepository)
            Console.WriteLine(c);

        while (clientsRepository.Size() > 0)
            clientsRepository.Remove();
    }
}