using patterns.decorator.classes;
using patterns.decorator.interfaces;

namespace patterns.decorator.decorators;

public class LoggerDecorator : ILogger
{
    private readonly ILogger _logger;

    public LoggerDecorator(ILogger logger)
    {
        _logger = logger;
    }

    public void Write(Message message)
    {
        _logger.Write(message);
    }
}