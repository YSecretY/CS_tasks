using task5.Interfaces;

namespace task5.Entities;

public class FileWriter : IPrintable
{
    private readonly string _filePath;
    private readonly StreamWriter _writer;

    public FileWriter(string filePath)
    {
        _filePath = filePath;
        _writer = new StreamWriter(filePath);
    }

    public void Print(string text)
    {
        WriteToFile(text);
    }

    private void WriteToFile(string text)
    {
        _writer.WriteLine(text);
        _writer.Flush();
    }
}