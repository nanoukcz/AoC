namespace AoC.Year2024;

public class Day01 : BaseDay
{
    private readonly List<int> _locations1 = [];
    private readonly List<int> _locations2 = [];
    
    protected override void ParseInput()
    {
        foreach (var line in File.ReadLines(InputFilePath))
        {
            var numbers = line.Split("   ")
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .ToList();

            if (numbers.Count == 2)
            {
                _locations1.Add(numbers[0]);
                _locations2.Add(numbers[1]);
            }
        }
        _locations1.Sort();
        _locations2.Sort();
    }
    
    protected override bool UseSeparatePartSolvers() => true;

    protected override void SolvePartOne() 
    {
        Solution1 = _locations1.Select((t, i) => Math.Abs(t - _locations2[i])).Sum();
    }

    protected override void SolvePartTwo()
    {
        var frequencyMap = _locations2.GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

        Solution2 = _locations1.Sum(number => number * frequencyMap.GetValueOrDefault(number, 0));
    }
}

