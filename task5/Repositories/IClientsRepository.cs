using System.Collections;
using task5.Entities;

namespace task5.Repositories;

public interface IClientsRepository : IRepository<Client, Guid>, IEnumerable<Client>
{
    /// <summary>
    /// Adds a client to a queue.
    /// </summary>
    /// <param name="c">Client entity.</param>
    public new void Add(Client c);

    /// <summary>
    /// Removes a first client from a queue.
    /// </summary>
    public new void Remove();

    /// <summary>
    /// Returns the size of the clients queue.
    /// </summary>
    /// <returns></returns>
    public int Size();
}