namespace AoC.Year2024;

public class Day01(List<int> locations1, List<int> locations2)
{
    private const string Path = "../../../Year2024/inputs/Day01.txt";

    public Day01() : this(GetLists().Item1, GetLists().Item2)
    {
    }
    
    public void Runner()
    {
        var solution1 = SolvePartOne();
        var solution2 = SolvePartTwo();
        Console.WriteLine("DAY 1");
        Console.WriteLine($"Part 1: {solution1}");
        Console.WriteLine($"Part 2: {solution2}");
        Console.WriteLine("###################");
    }

    private int SolvePartOne() 
    {
        return locations1.Select((t, i) => Math.Abs(t - locations2[i])).Sum();
    }

    private int SolvePartTwo()
    {
        var frequencyMap = locations2.GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

        return locations1.Sum(number => number * frequencyMap.GetValueOrDefault(number, 0));
    }

    private static (List<int>, List<int>) GetLists()
    {
        var (locations1, locations2) = (new List<int>(), new List<int>());
        
        foreach (var line in File.ReadLines(Path))
        {
            var numbers = line.Split("   ")
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .ToList();

            if (numbers.Count == 2)
            {
                locations1.Add(numbers[0]);
                locations2.Add(numbers[1]);
            }
        }

        locations1.Sort();
        locations2.Sort();
        
        return (locations1, locations2);
    }
}

