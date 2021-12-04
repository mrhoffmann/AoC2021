using System;
using System.Linq;

namespace AoC.Days
{
    public class Three : Day
    {
        private string Gamma, Epsilon;

        public override (int Part1, int Part2) Run()
        {
            return (Part1(), Part2());
        }

        public override int Part1()
        {
            var rows = Helpers.GetStringInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}")

            for (var i = 0; i < rows[0].Length; i++) {
                var zeroes = rows.Where(x => x[i] == '0').ToArray().Count();
                var ones = rows.Count() - zeroes;

                Gamma += ones > zeroes ? "1" : "0";
                Epsilon += ones < zeroes ? "1" : "0";
            }

            return Convert.ToInt32(Gamma, 2) * Convert.ToInt32(Epsilon, 2);
        }

        public override int Part2()
        {
            var rows = Helpers.GetStringInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}")

            string[] mostCommon = rows;
            string[] leastCommon = rows;
            for (var i = 0; i < rows[0].Length; i++)
            {
                if (mostCommon.Count() > 1)
                    mostCommon = MostCommon(mostCommon, i);

                if (leastCommon.Count() > 1)
                    leastCommon = LeastCommon(leastCommon, i);
            }

            return Convert.ToInt32(mostCommon[0].ToString(), 2) * Convert.ToInt32(leastCommon[0].ToString(), 2);
        }

        private string[] MostCommon(string[] rows, int pos=0)
        {
            System.Collections.Generic.IEnumerable<string> retval;
            int ones = rows.Where(x => x[pos] == '1').Count(), zeroes = rows.Length - ones;

            if (zeroes == ones || ones > zeroes)
                retval = rows.Select(x => x).Where(x => x[pos] == '1');
            else
                retval = rows.Select(x => x).Where(x => x[pos] == '0');

            return retval.ToArray();
        }

        private string[] LeastCommon(string[] rows, int pos = 0)
        {
            System.Collections.Generic.IEnumerable<string> retval;
            int ones = rows.Where(x => x[pos] == '1').Count(), zeroes = rows.Length - ones;

            if (zeroes == ones || ones > zeroes)
                retval = rows.Select(x => x).Where(x => x[pos] == '0');
            else
                retval = rows.Select(x => x).Where(x => x[pos] == '1');

            return retval.ToArray();
        }
    }
}
