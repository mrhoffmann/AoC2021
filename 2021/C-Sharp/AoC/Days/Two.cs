using System.Text.RegularExpressions;

namespace AoC.Days
{
    public class Two : Day
    {
        private int _aim, _horizontal, _depth;

        public override long Part1() => Execute();

        private int Calculate() => _horizontal * _depth * -1;
        private void MoveDown(int n) => _depth -= n;
        private void MoveUp(int n) => _depth += n;
        private void MoveForward(int n) => _horizontal += n;

        public override long Part2() => Execute(true);

        private long Execute(bool part2 = false)
        {
            _horizontal = 0; _depth = 0;
            if(!part2)
                foreach (var t in Part1Input)
                    Move(t);
            else
                foreach (var t in Part2Input)
                    MoveP2(t);

            return !part2 ? CalculateP2() : Calculate();
        }

        private int CalculateP2() => _horizontal * _depth * -1;
        private void MoveDownP2(int n) => _aim += n;
        private void MoveUpP2(int n) => _aim -= n;
        private void MoveForwardP2(int n)
        {
            _horizontal += n;
            _depth += _aim * n;
        }

        private void Move(string s)
        {
            var direction = s.Substring(0, s.IndexOf(' '));
            var extractedValue = Helpers.IntegerValueFromDirection(s);

            if (!new Regex($@"{direction} (\d)").IsMatch(s)) return;
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
            var r = new Regex($@"{direction} (\d)");
            var extractedValue = Helpers.IntegerValueFromDirection(s);

            if (!r.IsMatch(s)) return;
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
