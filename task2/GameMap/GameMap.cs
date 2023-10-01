namespace GameMap;

public class Map
{
    private const int _rows = 10, _cols = 20;
    private readonly char[,] _map = new char[_rows, _cols];
    private int _heroX, _heroY;

    public void Create()
    {
        for (int i = 0; i < _rows; ++i)
        for (int j = 0; j < _cols; ++j)
            if (i == 0 || i == _rows - 1 || j == 0 || j == _cols - 1 || (i == 5 && j > 3 && j < 9) ||
                (j == 15 && i > 2 && i < 7))
                _map[i, j] = '#';
            else _map[i, j] = ' ';
    }

    public void SetHero(int x, int y)
    {
        if (x >= 1 && y >= 1 && x < _rows - 1 && y < _cols - 1)
        {
            _map[x, y] = Hero.GetCharacter();
            _heroX = x;
            _heroY = y;
        }
        else throw new ArgumentException("Wrong coordinates to SetHero.");
    }

    private static ConsoleKey? GetArrowKey()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(intercept: true).Key;
            if (key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow ||
                key == ConsoleKey.RightArrow)
                return key;
        }

        return null;
    }

    public void MoveHero()
    {
        ConsoleKey? key = GetArrowKey();

        if (key.HasValue)
        {
            int newX = _heroX;
            int newY = _heroY;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    newX--;
                    break;
                case ConsoleKey.DownArrow:
                    newX++;
                    break;
                case ConsoleKey.LeftArrow:
                    newY--;
                    break;
                case ConsoleKey.RightArrow:
                    newY++;
                    break;
            }

            if (!IsWall(newX, newY) && newX >= 1 && newY >= 1 && newX <= _rows - 1 && newY <= _cols - 1)
            {
                _map[_heroX, _heroY] = ' ';
                _heroX = newX;
                _heroY = newY;
                _map[_heroX, _heroY] = Hero.GetCharacter();
            }
        }
    }

    private bool IsWall(int x, int y)
    {
        return _map[x, y] == '#';
    }

    public void Print()
    {
        for (int i = 0; i < _rows; ++i)
        {
            for (int j = 0; j < _cols; ++j)
            {
                Console.Write(_map[i, j]);
            }

            Console.WriteLine();
        }
    }
}