using System.Collections;
using task5.Entities;

namespace task5.Repositories;

public class ClientsRepository : IClientsRepository, IEnumerable<Client>
{
    private readonly Queue<Client> _queue = new();

    public void Add(Client c)
    {
        _queue.Enqueue(c);
    }

    public int Size()
    {
        return _queue.Count;
    }

    public void Remove()
    {
        _queue.Dequeue();
    }

    public IEnumerator GetEnumerator()
    {
        return _queue.GetEnumerator();
    }

    IEnumerator<Client> IEnumerable<Client>.GetEnumerator()
    {
        return _queue.GetEnumerator();
    }
}