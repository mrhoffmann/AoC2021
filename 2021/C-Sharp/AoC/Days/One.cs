namespace AoC.Days
{
    public class One : Day
    {
        public override long Part1()
        {
            var countsIncremented = 1;
            var rows = Helpers.IntArr(Part1Input);

            for (var i = 1; i < rows.Length - 1; i++)
                countsIncremented += rows[i - 1] < rows[i] ? 1 : 0;

            return countsIncremented;
        }

        public override long Part2()
        {
            int previousSum = 0, countsIncremented = 0;
            var rows = Helpers.IntArr(Part2Input);

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
