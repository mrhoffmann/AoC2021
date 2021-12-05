using System;
using System.Linq;

namespace AoC.Days
{
    internal class Five : Day
    {
        public override string Part1() => execute(Helpers.GetStringInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}"), false);

        public override string Part2() => execute(Helpers.GetStringInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}"), true);

        private string execute(string[] rows, bool part2=false)
        {
            var grid = new int[1000, 1000];
            foreach (string row in rows)
            {
                string coordinatesLeft = GetLeft(row);
                string coordinatesRight = GetRight(row);

                int ly = int.Parse(coordinatesLeft.Split(',')[1]),
                    ry = int.Parse(coordinatesRight.Split(',')[1]),
                    lx = int.Parse(coordinatesLeft.Split(',')[0]),
                    rx = int.Parse(coordinatesRight.Split(',')[0]);

                if (ly == ry || lx == rx)
                {
                    var yDiff = ly - ry;
                    var xDiff = lx - rx;
                    for (var i = 0; i < Math.Abs(xDiff) + 1; i++)
                        for (var j = 0; j < Math.Abs(yDiff) + 1; j++)
                            grid[lx + ((xDiff < 0) ? i : i * -1), ly + ((yDiff < 0) ? j : j * -1)]++;
                }
                else
                {
                    if (part2)
                    {
                        var diff = lx - rx;
                        var xDir = lx - rx;
                        var yDir = ly - ry;
                        for (int xy = 0; xy < Math.Abs(diff) + 1; xy++)
                            grid[lx + ((xDir < 0) ? xy : xy * -1), ly + ((yDir < 0) ? xy : xy * -1)]++;
                    }
                }
            }

            return grid.Cast<int>().Count(c => c >= 2).ToString();
        }

        private string GetLeft(string formatted) => formatted.Substring(0, formatted.IndexOf('-') - 1);
        private string GetRight(string formatted) => formatted.Substring(formatted.LastIndexOf('>') + 2, formatted.Length - formatted.LastIndexOf('>') - 2);
    }
}
