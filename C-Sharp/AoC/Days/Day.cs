namespace AoC
{
    public abstract class Day
    {
        public virtual (string Part1, string Part2) Run()
        {
            return (Part1(), Part2());
        }
        public abstract string Part1();
        public abstract string Part2();
    }
}
