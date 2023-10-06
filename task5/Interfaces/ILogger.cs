namespace task5.Interfaces;

public interface ILogger<TEntity>
    where TEntity : IPrintable
{
    public void LogInfo(string text);
}