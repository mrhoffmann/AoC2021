﻿namespace AoC.Days
{
    public class Two : Day
    {
        private int Aim, Horizontal, Depth;

        public override string Part1()
        {
            var rows = Helpers.GetStringInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            for (int i = 0; i < rows.Length; i++)
                Move(rows[i]);
            return Calculate().ToString();
        }

        private int Calculate() => Horizontal * Depth * -1;
        private void MoveDown(int n) => Depth -= n;
        private void MoveUp(int n) => Depth += n;
        private void MoveForward(int n) => Horizontal += n;

        public override string Part2()
        {
            Horizontal = 0; Depth = 0;
            var rows = Helpers.GetStringInput($@"{GetType().Name}\{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            for (int i = 0; i < rows.Length; i++)
                MoveP2(rows[i]);
            return CalculateP2().ToString();
        }

        private int CalculateP2() => Horizontal * Depth;
        private void MoveDownP2(int n) => Aim += n;
        private void MoveUpP2(int n) => Aim -= n;
        private void MoveForwardP2(int n)
        {
            Horizontal += n;
            Depth += Aim * n;
        }

        private void Move(string s)
        {
            var direction = s.Substring(0, s.IndexOf(' '));
            var extractedValue = Helpers.IntegerValueFromDirection(s);

            if (new System.Text.RegularExpressions.Regex($@"{direction} (\d)").IsMatch(s))
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

        private void MoveP2(string s)
        {
            var direction = s.Substring(0, s.IndexOf(' '));
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex($@"{direction} (\d)");
            var extractedValue = Helpers.IntegerValueFromDirection(s);

            if (r.IsMatch(s))
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
