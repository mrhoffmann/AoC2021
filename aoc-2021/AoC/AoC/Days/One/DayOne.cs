namespace AoC
{
    public class DayOne
    {
        public (int Part1, int Part2) Run(string day) => (
            Excersize(day),
            ExcersizeTwo(day)
        );

        public int Excersize(string day)
        {
            var countsIncremented = 1;
            var rows = Helpers.GetIntInput($@"{day}\Part1");

            for (var i = 1; i < rows.Length - 1; i++)
            {
                countsIncremented += rows[i - 1] < rows[i] ? 1 : 0;
            }

            return countsIncremented;
        }

        public int ExcersizeTwo(string day)
        {
            int previousSum = 0, countsIncremented = 0;
            var rows = Helpers.GetIntInput($@"{day}\Part2");

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
