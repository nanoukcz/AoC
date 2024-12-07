namespace AoC.Year2024;

public class Day06 : BaseDay
{
    private List<List<char>> _lines = [];
    private (char, (int, int)) _pos;
    protected override void ParseInput()
    {
        _lines = File.ReadAllLines(InputFilePath)
            .Select((line, y) =>
            {
                var charList = line.ToList();
                var x = charList.IndexOf('^');
                if (x >= 0) _pos = ('^', (y, x));
                return charList;
            })
            .ToList();
        
    }
    protected override bool UseSeparatePartSolvers() => false;

    protected override void SolveBothParts()
    {
        var (x, y) = (_pos.Item2.Item2, _pos.Item2.Item1);
        var border = false;
        var direction = 0;
        var directions = new (int dx, int dy, char symbol)[]
        {
            (0, -1, '^'), 
            (1, 0, '>'), 
            (0, 1, 'v'), 
            (-1, 0, '<')
        };

        while (!border)
        {
            _pos.Item1 = directions[direction].symbol;
            _lines[y][x] = 'X';

            var (nextX, nextY) = (x + directions[direction].dx, y + directions[direction].dy);

            if (nextX < 0 || nextY < 0 || nextX >= _lines[0].Count || nextY >= _lines.Count)
            {
                border = true;
                continue;
 
            }
            
            if (_lines[nextY][nextX] == '#')
            {
                direction = (direction + 1) % 4;
                continue;
            }

            (x, y) = (nextX, nextY);
            _lines[y][x] = _pos.Item1;
        }
        CountX();
    }

    private void CountX()
    {
        Solution1 = _lines.Sum(line => line.Count(c => c == 'X'));
    }
}