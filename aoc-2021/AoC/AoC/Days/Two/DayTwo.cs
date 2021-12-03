using System.Reflection;

namespace AoC
{
    public class DayTwo : Day
    {
        public override (int Part1, int Part2) Run() => (
            Part1(),
            Part2()
        );

        private int Aim, Horizontal, Depth;

        /// <summary>
        /// What do you get if you multiply your final horizontal position by your final depth?
        /// </summary>
        /// <returns></returns>
        public virtual int Part1()
        {
            var rows = Helpers.GetStringInput($@"{this.GetType().Name.Substring(3, this.GetType().Name.Length - 3)}\{MethodBase.GetCurrentMethod().Name}");
            for (int i = 0; i < rows.Length; i++)
            {
                Move(rows[i]);
            }
            return Calculate();
        }

        private int Calculate() => Horizontal * Depth * -1;
        private void MoveDown(int n) => Depth -= n;
        private void MoveUp(int n) => Depth += n;
        private void MoveForward(int n) => Horizontal += n;

        public virtual int Part2()
        {
            Horizontal = 0; Depth = 0;
            var rows = Helpers.GetStringInput($@"{this.GetType().Name.Substring(3, this.GetType().Name.Length - 3)}\{MethodBase.GetCurrentMethod().Name}");
            for (int i = 0; i < rows.Length; i++)
            {
                MoveP2(rows[i]);
            }
            return CalculateP2();
        }

        private int CalculateP2() => Horizontal * Depth;
        private void MoveDownP2(int n) => Aim += n;
        private void MoveUpP2(int n) => Aim -= n;
        private void MoveForwardP2(int n)
        {
            Horizontal += n;
            Depth += Aim * n;
        }

        /// <summary>
        /// Determine what direction is suited
        /// </summary>
        /// <param name="s">up/forward/down direction with the value number</param>
        private void Move(string s)
        {
            var direction = s.Substring(0, s.IndexOf(' '));
            var extractedValue = Helpers.IntegerValueFromDirection(s);

            if (new System.Text.RegularExpressions.Regex($@"{direction} (\d)").IsMatch(s))
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
        /// <summary>
        /// Determine what direction is suited
        /// </summary>
        /// <param name="s">up/forward/down direction with the value number</param>
        private void MoveP2(string s)
        {
            var direction = s.Substring(0, s.IndexOf(' '));
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex($@"{direction} (\d)");
            var extractedValue = Helpers.IntegerValueFromDirection(s);

            if (r.IsMatch(s))
            {
                switch (direction)
                {
                    case "forward":
                        MoveForwardP2(extractedValue);
                        break;
                    case "down":
                        MoveDownP2(extractedValue);
                        break;
                    case "up":
                        MoveUpP2(extractedValue);
                        break;
                }
            }
        }
    }
}
