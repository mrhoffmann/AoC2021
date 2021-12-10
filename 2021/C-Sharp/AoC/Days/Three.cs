using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Days
{
    public class Three : Day
    {
        private string _gamma, _epsilon;

        public override long Part1()
        {
            for (var i = 0; i < Part1Input[0].Length; i++) {
                var zeroes = Part1Input.Where(x => x[i] == '0').ToArray().Count();
                var ones = Part1Input.Count() - zeroes;

                _gamma += ones > zeroes ? "1" : "0";
                _epsilon += ones < zeroes ? "1" : "0";
            }

            return Convert.ToInt32(_gamma, 2) * Convert.ToInt32(_epsilon, 2);
        }

        public override long Part2()
        {
            var mostCommon = Part2Input;
            var leastCommon = Part2Input;
            for (var i = 0; i < Part2Input[0].Length; i++)
            {
                if (mostCommon.Count() > 1)
                    mostCommon = MostCommon(mostCommon, i);

                if (leastCommon.Count() > 1)
                    leastCommon = LeastCommon(leastCommon, i);
            }

            return Convert.ToInt32(mostCommon[0], 2) * Convert.ToInt32(leastCommon[0], 2);
        }

        private string[] MostCommon(IReadOnlyCollection<string> rows, int pos=0)
        {
            IEnumerable<string> retval;
            int ones = rows.Count(x => x[pos] == '1'), zeroes = rows.Count - ones;

            if (zeroes == ones || ones > zeroes)
                retval = rows.Select(x => x).Where(x => x[pos] == '1');
            else
                retval = rows.Select(x => x).Where(x => x[pos] == '0');

            return retval.ToArray();
        }

        private string[] LeastCommon(IReadOnlyCollection<string> rows, int pos = 0)
        {
            IEnumerable<string> retval;
            int ones = rows.Count(x => x[pos] == '1'), zeroes = rows.Count - ones;

            if (zeroes == ones || ones > zeroes)
                retval = rows.Select(x => x).Where(x => x[pos] == '0');
            else
                retval = rows.Select(x => x).Where(x => x[pos] == '1');

            return retval.ToArray();
        }
    }
}
