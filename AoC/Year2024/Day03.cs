using System.Text.RegularExpressions;

namespace AoC.Year2024;

public partial class Day03 : BaseDay
{
    private readonly Regex _regex = MyRegex();
    private List<Match> _matches = [];
    
    protected override void ParseInput()
    {
        _matches = _regex.Matches(File.ReadAllText(InputFilePath)).ToList();
    }
    
    protected override bool UseSeparatePartSolvers() => true;

    protected override void SolvePartOne()
    {
        Solution1 = _matches
            .Where(match => match.Groups[3].Success && match.Groups[4].Success)
            .Select(match => int.Parse(match.Groups[3].Value) * int.Parse(match.Groups[4].Value))
            .Sum();
    }

    protected override void SolvePartTwo()
    {
        var numbers = new List<int>();
        var checker = true;

        foreach (var match in _matches)
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
        Solution2 = numbers.Sum();
    }

    [GeneratedRegex(@"(do\(\))|(don\'t\(\))|mul\((\d{1,3}),(\d{1,3})\)")]
    private static partial Regex MyRegex();
}