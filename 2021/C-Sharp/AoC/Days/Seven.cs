using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Days
{
    internal class Seven : Day
    {
        public override long Part1()
        {
            var positions = Helpers.ToIntArr(Part1Input[0]);
            var lowestCost = int.MaxValue;
            for (var i = positions.Min(); i <= positions.Max(); i++)
            {
                var tmp = positions.Sum(x => Math.Abs(x - i));
                lowestCost = tmp < lowestCost ? tmp : lowestCost;
            }
            return lowestCost;
        }
        
        public override long Part2()
        {
            var positions = Helpers.ToIntArr(Part2Input[0]);
            var max = positions.Max();
            var lowestCost = long.MaxValue;

            Dictionary<int, long> costs = new()
            {
                [0] = 0,
                [1] = 1
            };
            for (var i = 2; i <= max; i++)
                costs[i] = i + costs[i - 1];

            for (var i = positions.Min(); i <= max; i++)
            {
                var tmp = positions.Sum(x => costs[Math.Abs(x - i)]);
                if (tmp < lowestCost) lowestCost = tmp;
            }
            return lowestCost;
        }
    }
}
