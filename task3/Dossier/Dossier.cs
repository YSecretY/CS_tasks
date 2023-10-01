namespace Dossier;

public class Dossier
{
    private string?[] _names = new string[10];
    private string?[] _positions = new string[10];
    private int _count = 0;

    public void AddInfo(string? name, string? position)
    {
        for (int i = 0; i < _names.Length; ++i)
            if (_names[i] == name)
            {
                _positions[i] = position;
                return;
            }

        if (_count > _names.Length)
        {
            Array.Resize(ref _names, _names.Length * 2);
            Array.Resize(ref _positions, _positions.Length * 2);
        }

        _names[_count] = name;
        _positions[_count] = position;
        _count++;
    }

    public void RemoveInfo(string? name)
    {
        for (int i = 0; i < _count; ++i)
        {
            if (_names[i] == name)
            {
                for (int j = i; j < _count; ++j)
                {
                    _names[j] = _names[j + 1];
                    _positions[j] = _positions[j + 1];
                }

                _names[_count - 1] = "-";
                _names[_count - 1] = "-";
                _count--;
                return;
            }
        }
    }

    public string? GetInfo(string? surname)
    {
        int i = 0;
        while (i < _names.Length && surname != _names[i]?.Split(' ')[0])
            ++i;

        return i < _positions.Length ? _positions[i] : "";
    }

    public void PrintAll()
    {
        for (int i = 0; i < _count; ++i)
        {
            Console.WriteLine($"{_names[i]} - {_positions[i]}");
        }
    }
}