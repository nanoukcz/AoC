namespace AoC.Year2024;

public static class Program
{
    private static void Main()
    {
        Console.WriteLine("ADVENT OF CODE 2024");
        Console.WriteLine("###################");

        var days = new List<BaseDay>
        {
            new Day01(), 
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05(),
            new Day06()
        };

        foreach (var day in days)
        {
            day.Run();
        }
    }
    
}