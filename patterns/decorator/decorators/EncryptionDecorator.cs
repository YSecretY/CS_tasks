using System.Threading.Tasks.Dataflow;
using patterns.decorator.classes;
using patterns.decorator.interfaces;

namespace patterns.decorator.decorators;

public class EncryptionDecorator : LoggerDecorator
{
    public EncryptionDecorator(ILogger logger) : base(logger)
    {
    }

    public void WriteEncrypted(Message message)
    {
        string encryptedMessageData = Encrypt(message.Data);

        Message encryptedMessage = new Message(encryptedMessageData);

        base.Write(encryptedMessage);
    }

    private static string Encrypt(string content)
    {
        return "Encrypted: " + content;
    }
}