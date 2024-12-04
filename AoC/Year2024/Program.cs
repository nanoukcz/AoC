namespace AoC.Year2024;

public static class Program
{
    private static void Main()
    {
        Console.WriteLine("ADVENT OF CODE 2024");
        Console.WriteLine("###################");
        var day01 = new Day01();
        day01.Runner();
        var day02 = new Day02();
        day02.Runner();
        var day03 = new Day03();
        day03.Runner();
        var day04 = new Day04();
        day04.Runner();
    }
    
}