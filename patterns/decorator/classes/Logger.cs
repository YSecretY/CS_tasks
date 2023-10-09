using patterns.decorator.interfaces;

namespace patterns.decorator.classes;

public class Logger : ILogger
{
    public void Write(Message message)
    {
        Console.WriteLine(message.Data);
    }
}