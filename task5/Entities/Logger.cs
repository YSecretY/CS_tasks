using task5.Interfaces;

namespace task5.Entities;

public class Logger : ILogger<IPrintable>
{
    private IPrintable _where;

    public Logger(IPrintable where)
    {
        _where = where;
    }

    public void LogInfo(string text)
    {
        _where.Print(text);
    }
}