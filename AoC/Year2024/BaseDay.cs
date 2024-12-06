namespace AoC.Year2024;

public abstract class BaseDay
{
    protected string InputFilePath => $"../../../Year2024/inputs/Day{GetDayNumber():D2}.txt";
    protected int Solution1;
    protected int Solution2;

    public void Run()
    {
        ParseInput();
        if (UseSeparatePartSolvers())
        {
            SolvePartOne();
            SolvePartTwo();
        }
        else
        {
            SolveBothParts();
        }

        Console.WriteLine($"DAY {GetDayNumber()}");
        Console.WriteLine($"Part 1: {Solution1}");
        Console.WriteLine($"Part 2: {Solution2}");
        Console.WriteLine("###################");
    }

    protected abstract void ParseInput();

    private int GetDayNumber()
    {
        var className = GetType().Name; // Example: "Day03"
        if (className.StartsWith("Day") && int.TryParse(className.AsSpan(3), out var dayNumber))
        {
            return dayNumber;
        }

        throw new InvalidOperationException($"Could not determine day number from class name '{className}'.");
    }

    protected virtual bool UseSeparatePartSolvers() => false;

    protected virtual void SolveBothParts() { }

    protected virtual void SolvePartOne() { }
    protected virtual void SolvePartTwo() { }
    
}