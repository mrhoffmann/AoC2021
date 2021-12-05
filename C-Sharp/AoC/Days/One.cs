namespace AoC.Days
{
    public class One : Day
    {
        public override string Part1()
        {
            var countsIncremented = 1;
            var rows = Helpers.GetIntInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            for (var i = 1; i < rows.Length - 1; i++)
            {
                countsIncremented += rows[i - 1] < rows[i] ? 1 : 0;
            }

            return countsIncremented.ToString();
        }

        public override string Part2()
        {
            int previousSum = 0, countsIncremented = 0;
            var rows = Helpers.GetIntInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            for (var i = 1; i < rows.Length - 1; i++)
            {
                var A = rows[i - 1];
                var B = rows[i];
                var C = rows[i + 1];
                var sum = A + B + C;

                countsIncremented += previousSum > 0 && sum > previousSum ? 1 : 0;
                previousSum = sum;
            }
            return countsIncremented.ToString();
        }
    }
}
