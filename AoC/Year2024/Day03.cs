using System.Text.RegularExpressions;

namespace AoC.Year2024;

public class Day03
{
    private const string Path = "../../../Year2024/inputs/Day03.txt";
    private readonly Regex _regex = new(@"(do\(\))|(don\'t\(\))|mul\((\d{1,3}),(\d{1,3})\)");
    private readonly MatchCollection _matches;

    public Day03()
    {
        _matches = _regex.Matches(File.ReadAllText(Path));
    }
    public void Runner()
    {
        var solution1 = SolvePartOne();
        var solution2 = SolvePartTwo();
        Console.WriteLine("DAY 3");
        Console.WriteLine($"Part 1: {solution1}");
        Console.WriteLine($"Part 1: {solution2}");
        Console.WriteLine("###################");
    }

    private int SolvePartOne()
    {
        return _matches
            .Where(match => match.Groups[3].Success && match.Groups[4].Success)
            .Select(match => int.Parse(match.Groups[3].Value) * int.Parse(match.Groups[4].Value))
            .Sum();
    }

    private int SolvePartTwo()
    {
        var numbers = new List<int>();
        var checker = true;

        foreach (Match match in _matches)
        {
            switch (match.Value)
            {
                case "do()":
                    checker = true;
                    break;
                case "don't()":
                    checker = false;
                    break;
                default:
                {
                    if (checker)
                    {
                        numbers.Add(int.Parse(match.Groups[3].Value) * int.Parse(match.Groups[4].Value));
                    }
                    break;
                }
            }
        }
        return numbers.Sum();
    }
}