namespace AoC
{
    public abstract class Day
    {
        /// <summary>
        /// What do you get if you multiply your final horizontal position by your final depth?
        /// </summary>
        /// <returns></returns>
        public virtual (string Part1, string Part2) Run()
        {
            return (Part1(), Part2());
        }
        public abstract string Part1();
        public abstract string Part2();
    }
}
