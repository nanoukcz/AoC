namespace AoC.Year2024;

public class Day02(List<List<int>> reports)
{
    private const string Path = "../../../Year2024/inputs/Day02.txt";

    public Day02() : this(GetLevels())
    {
    }

    public void Runner()
    {
        var solution1 = SolveBothParts(false);
        var solution2 = SolveBothParts(true);
        Console.WriteLine("DAY 2");
        Console.WriteLine($"Part 1: {solution1}");
        Console.WriteLine($"Part 2: {solution2}");
        Console.WriteLine("###################");
    }

    private int SolveBothParts(bool dampener)
    {
        if (!dampener)
        {
            return reports.Count(IsSafe);
        }

        return reports.Count(report => 
            report.Select((_, i) => report.Take(i).Concat(report.Skip(i + 1)).ToList()).Any(IsSafe));
    }

    private bool IsSafe(List<int> level)
    {
        var differences = level.Take(level.Count - 1)
            .Zip(level.Skip(1), (levelOne, levelTwo) => levelOne - levelTwo).ToList();
        
        var safeChecker = differences.All(difference => Math.Abs(difference) is not 0 and <= 3)
            && (differences.All(x => x > 0) || differences.All(x => x < 0));
        
        return safeChecker;
    }
    
    private static List<List<int>> GetLevels()
    {
        return File.ReadLines(Path)
            .Select(line => line.Split(" ")
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .ToList())
            .ToList();
    }
}