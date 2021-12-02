using System;
using System.Text.RegularExpressions;

namespace AoC
{
    public class DayTwo
    {
        private readonly string Day = @"Two\Part";

        public (int Part1, int Part2) Run() =>  (
            new Excersize().Run(Helpers.GetStringInput($@"{Day}1")),
            new ExcersizeTwo().Run(Helpers.GetStringInput($@"{Day}2"))
        );
    }

    public abstract class Orientation
    {
        /// <summary>
        /// What do you get if you multiply your final horizontal position by your final depth?
        /// </summary>
        /// <returns></returns>
        public virtual int Run(string[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                Move(rows[i]);
            }
            return Calculate();
        }

        /// <summary>
        /// Run a calculation
        /// </summary>
        /// <returns></returns>
        protected abstract int Calculate();

        /// <summary>
        /// Forward and backwards axis.
        /// </summary>
        protected int Horizontal { get; set; }

        /// <summary>
        /// Up and down axis.
        /// </summary>
        protected int Depth { get; set; }

        /// <summary>
        /// Move the submarine down
        /// </summary>
        /// <param name="n"></param>
        protected abstract void MoveDown(int n);

        /// <summary>
        /// Move the submarine up
        /// </summary>
        /// <param name="n"></param>
        protected abstract void MoveUp(int n);

        /// <summary>
        /// Move the submarine forward
        /// </summary>
        /// <param name="n"></param>
        protected abstract void MoveForward(int n);

        /// <summary>
        /// Determine what direction is suited
        /// </summary>
        /// <param name="s">up/forward/down direction with the value number</param>
        protected virtual void Move(string s)
        {
            var direction = s.Substring(0, s.IndexOf(' '));
            Regex r = new Regex($@"{direction} (\d)");
            var extractedValue = Helpers.IntegerValueFromDirection(s);

            if (r.IsMatch(s))
            {
                switch (direction)
                {
                    case "forward":
                        MoveForward(extractedValue);
                        break;
                    case "down":
                        MoveDown(extractedValue);
                        break;
                    case "up":
                        MoveUp(extractedValue);
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Part 1
    /// </summary>
    public class Excersize : Orientation
    {
        protected override int Calculate() => Horizontal* Depth * -1;
        protected override void MoveDown(int n) => Depth -= n;
        protected override void MoveUp(int n) => Depth += n;
        protected override void MoveForward(int n) => Horizontal += n;
    }

    /// <summary>
    /// Part 2
    /// </summary>
    public class ExcersizeTwo : Orientation
    {
        protected override int Calculate() => Horizontal * Depth;

        /// <summary>
        /// Positional variable
        /// </summary>
        private int Aim;
        protected override void MoveDown(int n) => Aim += n;
        protected override void MoveUp(int n) => Aim -= n;
        protected override void MoveForward(int n)
        {
            Horizontal += n;
            Depth += Aim * n;
        }
    }
}
