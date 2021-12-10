using System.Collections.Generic;

namespace AoC.Days
{
    internal class Ten : Day
    {
        private readonly Dictionary<char, char> _groups = new() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };

        public override long Part1()
        {
            /*
             ): 3 points.
             ]: 57 points.
             }: 1197 points.
             >: 25137 points.
            */
            Dictionary<char, int> points = new() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
            Stack<char> symbols = new();
            var retval = 0;
            foreach (var row in Part1Input) {
                foreach (var symbol in row) {
                    if (_groups.ContainsKey(symbol)) symbols.Push(symbol);
                    else {
                        var topStack = symbols.Pop();
                        if (symbol == _groups[topStack]) continue;
                        if (points.ContainsKey(symbol)) retval += points[symbol];
                    }
                }
            }
            return retval;
        }

        public override long Part2()
        {
            /*
             ): 1 point.
             ]: 2 points.
             }: 3 points.
             >: 4 points.
            */
            Dictionary<char, int> points = new() { { '(', 1 }, { '[', 2 }, { '{', 3 }, { '<', 4 } };
            List<long> retval = new();
            foreach (var row in Part2Input) {
                Stack<char> symbols = new();
                long score = 0;
                var isCorrupted = false;
                foreach (var symbol in row) {
                    if (_groups.ContainsKey(symbol)) symbols.Push(symbol);
                    else
                    {
                        var topStack = symbols.Pop();
                        isCorrupted = symbol != _groups[topStack];
                        if (isCorrupted) break;
                    }
                }
                while (!isCorrupted && symbols.Count > 0) {
                    var symbol = symbols.Pop();
                    if (points.ContainsKey(symbol)) score = score * 5 + points[symbol];
                }
                if (score > 0) retval.Add(score);
            }
            retval.Sort();
            return retval[retval.Count / 2];
        }
    }
}
