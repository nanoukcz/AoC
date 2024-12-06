namespace AoC.Year2024;

public class Day02 : BaseDay
{
    private List<List<int>> _levels = [];
    
    protected override void ParseInput()
    {
        _levels =  File.ReadLines(InputFilePath)
            .Select(line => line.Split(" ")
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .ToList())
            .ToList();
    }

    protected override void SolveBothParts()
    {
        Solution1 = _levels.Count(IsSafe);
        Solution2 = _levels.Count(report => 
            report.Select((_, i) => report.Take(i).Concat(report.Skip(i + 1)).ToList()).Any(IsSafe));
    }

    private static bool IsSafe(List<int> level)
    {
        var differences = level.Take(level.Count - 1)
            .Zip(level.Skip(1), (levelOne, levelTwo) => levelOne - levelTwo).ToList();
        
        var safeChecker = differences.All(difference => Math.Abs(difference) is not 0 and <= 3)
            && (differences.All(x => x > 0) || differences.All(x => x < 0));
        
        return safeChecker;
    }
}