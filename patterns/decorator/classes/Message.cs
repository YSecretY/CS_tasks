namespace patterns.decorator.classes;

public class Message
{
    public Message(string message)
    {
        Data = message;
    }

    public string Data { get; private set; }
}