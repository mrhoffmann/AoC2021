using System;
using System.Linq;

namespace AoC.Days
{
    internal class Five : Day
    {
        public override string Part1() => Execute(Helpers.GetStringInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}"));
        public override string Part2() => Execute(Helpers.GetStringInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}"), true);
        
        private string Execute(string[] rows, bool part2=false)
        {
            var grid = new int[1000, 1000];
            foreach (string row in rows)
            {
                var (lx, ly, rx, ry) = GetCoords(row);

                var yDiff = ly - ry;
                var xDiff = lx - rx;
                if (ly == ry || lx == rx)
                {
                    for (var i = 0; i < Math.Abs(xDiff) + 1; i++)
                        for (var j = 0; j < Math.Abs(yDiff) + 1; j++)
                            grid[lx + ((xDiff < 0) ? i : i * -1), ly + ((yDiff < 0) ? j : j * -1)]++;
                }
                else if((ly != ry || lx != rx) && part2)
                {
                    for (int xy = 0; xy < Math.Abs(xDiff) + 1; xy++)
                        grid[lx + ((xDiff < 0) ? xy : xy * -1), ly + ((yDiff < 0) ? xy : xy * -1)]++;
                }
            }

            return grid.Cast<int>().Count(c => c >= 2).ToString();
        }

        private (int lx, int ly, int rx, int ry) GetCoords(string formatted)
        {
            int[] left = GetLeft(formatted), right = GetRight(formatted);
            return (left[0], left[1], right[0], right[1]);
        }
        private int[] GetLeft(string formatted) => Array.ConvertAll(formatted.Substring(0, formatted.IndexOf('-') - 1).Split(','), s => int.Parse(s));
        private int[] GetRight(string formatted) => Array.ConvertAll(formatted.Substring(formatted.LastIndexOf('>') + 2, formatted.Length - formatted.LastIndexOf('>') - 2).Split(','), s => int.Parse(s));
    }
}
