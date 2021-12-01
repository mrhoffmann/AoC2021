﻿using System;

namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sonar_Sweep_Part1());
            Console.WriteLine(Sonar_Sweep_Part2());
            Console.ReadKey();
        }

        /// <summary>
        /// https://adventofcode.com/2021/day/1
        /// https://adventofcode.com/2021/day/1/input
        /// 
        /// 199 (N/A - no previous measurement)
        /// 200 (increased)
        /// 208 (increased)
        /// 210 (increased)
        /// 200 (decreased)
        /// 207 (increased)
        /// 240 (increased)
        /// 269 (increased)
        /// 260 (decreased)
        /// 263 (increased)
        /// 
        /// How many measurements are larger than the previous measurement?
        /// </summary>
        static int Sonar_Sweep_Part1()
        {
            var countsIncremented = 1;
            var rows = Helpers.GetInput("SonarSweep");

            for(var i = 1; i < rows.Length - 1; i++)
            {
                countsIncremented += rows[i - 1] < rows[i] ? 1 : 0;
            }
            return countsIncremented;
        }

        /// <summary>
        /// https://adventofcode.com/2021/day/1
        /// https://adventofcode.com/2021/day/1/input
        /// 
        /// Part 2
        /// 
        /// A: 607 (N/A - no previous sum)
        /// B: 618 (increased)
        /// C: 618 (no change)
        /// D: 617 (decreased)
        /// E: 647 (increased)
        /// F: 716 (increased)
        /// G: 769 (increased)
        /// H: 792 (increased)
        /// 
        /// How many sums are larger than the previous sum?
        /// </summary>
        static int Sonar_Sweep_Part2()
        {
            int previousSum = 0, countsIncremented = 0;
            var rows = Helpers.GetInput("SonarSweep_Part2");

            for (var i = 1; i < rows.Length - 1; i++)
            {
                var A = rows[i - 1];
                var B = rows[i];
                var C = rows[i + 1];
                var sum = A + B + C;

                countsIncremented += previousSum > 0 && sum > previousSum ? 1 : 0;
                previousSum = sum;
            }
            return countsIncremented;
        }
    }
}
