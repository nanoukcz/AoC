namespace AoC.Year2024;

public class Day04
{
    private const string Path = "../../../Year2024/inputs/Day04.txt";
    private readonly string[] _lines = File.ReadAllLines(Path);

    public void Runner()
    {
        var solution1 = SolveBothParts(true);
        var solution2 = SolveBothParts(false);
        Console.WriteLine("DAY 4");
        Console.WriteLine($"Part 1: {solution1}");
        Console.WriteLine($"Part 2: {solution2}");
        Console.WriteLine("###################");
    }

    private int SolveBothParts(bool allDirections)
    {
        var result = 0;

        for (var i = 0; i < _lines.Length; i++)
        {
            for (var j = 0; j < _lines[i].Length; j++)
            {
                switch (allDirections)
                {
                    case true when _lines[i][j] == 'X':
                        result += FindXmas(i, j);
                        break;
                    case false when _lines[i][j] == 'A':
                        result += FindX(i, j);
                        break;
                }
            }
        }

        return result;
    }

    private int FindXmas(int i, int j)
    {
        var counter = 0;
        var letters = new List<char> { 'X', 'M', 'A', 'S' };
        (int, int)[] directions = [(-1, -1), (-1, 0), (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1)];

        foreach (var (x, y) in directions)
        {
            var checker = true;

            for (var k = 0; k < letters.Count; k++)
            {
                var row = i + x * k;
                var col = j + y * k;
                
                if (row < 0 || row >= _lines.Length ||
                    col < 0 || col >= _lines[row].Length)
                {
                    checker = false;
                    break;
                }
                
                if (_lines[row][col] != (letters[k]))
                {
                    checker = false;
                    break;
                }
            }
            
            if (checker)
            {
                counter++;
            }
        }

        return counter;
    }

    private int FindX(int i, int j)
    {
        var counter = 0;
        (int, int)[] directions = [(-1, -1), (-1, 1)];

        foreach (var (x, y) in directions)
        {
            var row = i + x;
            var col = j + y;
            var oppositeRow = i - x;
            var oppositeCol = j - y;
            
            if (row < 0 || row >= _lines.Length || 
                col < 0 || col >= _lines[row].Length || 
                oppositeRow < 0 || oppositeRow >= _lines.Length || 
                oppositeCol < 0 || oppositeCol >= _lines[oppositeRow].Length)
            {
                continue;
            }
            
            if ((_lines[row][col] == 'M' && _lines[oppositeRow][oppositeCol] == 'S') ||
                (_lines[row][col] == 'S' && _lines[oppositeRow][oppositeCol] == 'M'))
            {
                counter++;
            }
        }

        return counter == 2 ? 1 : 0;
    }
}