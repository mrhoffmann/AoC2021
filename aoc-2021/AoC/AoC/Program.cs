using System;

namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = new DayTwo().Run();
            Console.WriteLine($"Part 1: {result.Part1}");
            Console.WriteLine($"Part 2: {result.Part2}");
            Console.ReadKey();
        }
    }
}
