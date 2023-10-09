using patterns.decorator.classes;
using patterns.decorator.interfaces;

namespace patterns.decorator.decorators;

public class CompressionDecorator : LoggerDecorator
{
    public CompressionDecorator(ILogger logger) : base(logger)
    {
    }

    public void WriteCompressed(Message message)
    {
        string compressedMessageData = Compress(message.Data);

        Message compressedMessage = new Message(compressedMessageData);

        base.Write(compressedMessage);
    }

    private static string Compress(string content)
    {
        return "Compressed: " + content;
    }
}