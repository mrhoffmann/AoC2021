namespace AoC.Days
{
    internal class Six : Day
    {
        public override long Part1() => Execute(Part1Input[0], 80);

        public override long Part2() => Execute(Part2Input[0], 256);

        private long Execute(string input, int days)
        {
            var age = new long[days + 1];

            var p = input.Split(',');
            foreach (var s in p)
            {
                var i = int.Parse(s);
                age[i]++;
            }

            for (var i = 0; i < days; i++)
            {
                var a0 = age[0];
                for (var j = 1; j <= days; j++)
                {
                    age[j - 1] = age[j];
                    age[j] = 0;
                }
                age[8] += a0;
                age[6] += a0;
            }

            long e = 0;
            for (var j = 0; j <= days; j++) e += age[j];
            return e;
        }
    }
}
