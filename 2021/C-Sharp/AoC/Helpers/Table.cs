using System.Collections.Generic;
using System.Linq;

namespace AoC
{
    public class Table
    {
        public List<TableRow> Rows { get; set; }
        public TableRow Header { get; set; }
        private int LongestDay { get; set; }
        private int LongestPartOne { get; set; }
        private int LongestPartTwo { get; set; }
        public string Separator { get; set; }

        public string Output
        {
            get
            {
                LongestDay = 0; LongestPartOne = 0;
                LongestPartTwo = 0;
                var retval = Header.GetHeader(this);
                retval = Rows.Where(row => !row.Header).Aggregate(retval, (current, row) => current + row.GetOutput(this));
                retval += $"\n{Separator}";
                return retval;
            }
        }

        public int GetLongestDay()
        {
            if (LongestDay != 0) return LongestDay;
            var retval = 0;
            foreach (var row in Rows.Where(row => row.Day.Length > retval))
            {
                retval = row.Day.Length + 6;
            }
            LongestDay = retval;
            return LongestDay;
        }

        public int GetLongestPartOne()
        {
            if (LongestPartOne != 0) return LongestPartOne;
            var retval = 0;
            foreach (var row in Rows.Where(row => row.One.Length > retval))
            {
                retval = row.One.Length + 4;
            }
            LongestPartOne = retval;
            return LongestPartOne;
        }

        public int GetLongestPartTwo()
        {
            if (LongestPartTwo != 0) return LongestPartTwo;
            var retval = 0;
            foreach (var row in Rows.Where(row => row.Two.Length > retval))
            {
                retval = row.Two.Length + 6;
            }
            LongestPartTwo = retval;
            return LongestPartTwo;
        }

    }

    public class TableRow
    {
        public string Day;
        public string One;
        public string Two;
        public bool Header;
        private string _output;

        public string GetOutput(Table current)
        {
            var output = "";
            var length = current.GetLongestDay();

            if (Day.Length < length)
            {
                Day = $"{ Day }{ new string(' ', length - Day.Length)}";
            }

            _ = current.Header.Day.Length > current.GetLongestPartOne() ? current.Header.Day.Length : current.GetLongestPartOne();

            One = $"{One}{new string(' ', current.Header.One.Length - One.Length)}";

            var sum = current.Header.Two.Length - Two.Length + 1;
            if (sum > 0)
            {
                Two = $"{Two}{new string(' ', sum)}";
            }

            if (!Header)
            {
                output = $"\n| Day {Day.ToLower()} | {One} | {Two.TrimStart()} |";
            }

            _output = output;
            return output;
        }

        public string GetHeader(Table current)
        {
            Day = $"{ Day }{ new string(' ', current.GetLongestDay() - Day.Length + 4)}";
            One = $"{ One }{ new string(' ', current.GetLongestPartOne() - One.Length)}";
            Two = $"{ Two }{ new string(' ', current.GetLongestPartTwo() - Two.Length + 1)}";
            var output = $"| {Day} | {One} | {Two} |";
            current.Separator = $"+{new string('-', output.Length - 2)}+";
            return $"{current.Separator}\n{output}\n+{new string('-', output.Length - 2)}+";
        }

        public string GetSeparator() => _output;
    }
}
