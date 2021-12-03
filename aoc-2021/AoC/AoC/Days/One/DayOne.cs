using System.Reflection;

namespace AoC
{
    public class DayOne : Day
    {
        public override (int Part1, int Part2) Run() => (
            Part1(),
            Part2()
        );

        public int Part1()
        {
            var countsIncremented = 1;
            var rows = Helpers.GetIntInput($@"{this.GetType().Name.Substring(3, this.GetType().Name.Length - 3)}\{MethodBase.GetCurrentMethod().Name}");

            for (var i = 1; i < rows.Length - 1; i++)
            {
                countsIncremented += rows[i - 1] < rows[i] ? 1 : 0;
            }

            return countsIncremented;
        }

        public int Part2()
        {
            int previousSum = 0, countsIncremented = 0;
            var rows = Helpers.GetIntInput($@"{this.GetType().Name.Substring(3, this.GetType().Name.Length - 3)}\{MethodBase.GetCurrentMethod().Name}");

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
