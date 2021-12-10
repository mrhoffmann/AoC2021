using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Aoc_Helpers
{
    public static class Input
    {
        public static int[] GetIntInput(string file) => System.Array.ConvertAll(GetStringInput(file), s => int.Parse(s));
        public static string[] GetStringInput(string file) => System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(@"..\..\") + @"\Inputs\Days\" + file + ".txt");
        public static int IntegerValueFromDirection(string s) => int.Parse(System.Text.RegularExpressions.Regex.Match(s, @"\d+").Value);
    }

    public static class Runner
    {
        public static void Run(string assembly)
        {
            Table Table = new Table
            {
                Rows = new List<TableRow>()
            };
            var types = (from a in AppDomain.CurrentDomain.GetAssemblies() from b in a.GetTypes() select b)
                .Where(c => c.FullName.StartsWith(assembly) && !c.FullName.Contains("+"))
                .ToList();

            var ClassOrder = new Dictionary<Type, int>();

            foreach (var s in types)
            {
                Debug.WriteLine(s);
                ClassOrder.Add(s, Converting.GetValueFromName(s.Name));
            }
            var obj = ClassOrder.OrderBy(x => x.Value);

            Table.Header = new TableRow()
            {
                Day = "Day",
                One = "Part one",
                Two = "Part two",
                Header = true
            };

            foreach
            (
                var type in obj
            )
            {
                Debug.WriteLine(type.Key.Name);
                string[] values =
                    type.Key
                    .GetMethod("Run")
                    .Invoke(
                        type.Key
                        .GetConstructor(Type.EmptyTypes)
                        .Invoke(
                            new object[] { }),
                            new object[] { })
                                .ToString()
                                .Replace("(", string.Empty)
                                .Replace(")", string.Empty)
                                .Split(new char[] { ',' });

                Table.Rows.Add(new TableRow()
                {
                    Day = type.Key.Name,
                    One = values[0],
                    Two = values[1]
                });
            }
            Debug.WriteLine(Table.Output);
        }
    }

    public static class Parsing
    {

    }

    public static class Converting
    {
        public static int[] ToIntArr(string s) => Array.ConvertAll(s.Split(','), int.Parse);

        public static int GetValueFromName(string s)
        {
            int retval = 0;
            foreach (var enumVal in Enum.GetValues(typeof(Names)))
            {
                if (s == enumVal.ToString())
                {
                    retval = (int)enumVal;
                }
            }
            return retval;
        }
    }

    public abstract class Structure
    {
        public virtual (string Part1, string Part2) Run()
        {
            return (Part1(), Part2());
        }
        public abstract string Part1();
        public abstract string Part2();
    }

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
                string retval = Header.GetHeader(this);
                int lastRow = retval.Length;
                foreach (TableRow row in Rows)
                {
                    if (!row.Header)
                    {
                        retval += row.GetOutput(this);
                    }
                }
                retval += $"\n{Separator}";
                return retval;
            }
        }

        public int GetLongestDay()
        {
            if (LongestDay == 0)
            {
                int retval = 0;
                foreach (TableRow row in Rows)
                {
                    if (row.Day.Length > retval)
                        retval = row.Day.Length + 6;
                }
                LongestDay = retval;
            }
            return LongestDay;
        }

        public int GetLongestPartOne()
        {
            if (LongestPartOne == 0)
            {
                int retval = 0;
                foreach (TableRow row in Rows)
                {
                    if (row.One.Length > retval)
                        retval = row.One.Length + 4;
                }
                LongestPartOne = retval;
            }
            return LongestPartOne;
        }

        public int GetLongestPartTwo()
        {
            if (LongestPartTwo == 0)
            {
                int retval = 0;
                foreach (TableRow row in Rows)
                {
                    if (row.Two.Length > retval)
                        retval = row.Two.Length + 6;
                }
                LongestPartTwo = retval;
            }
            return LongestPartTwo;
        }

    }

    public class TableRow
    {
        public string Day;
        public string One;
        public string Two;
        public bool Header;
        private string Output;

        public string GetOutput(Table current)
        {
            string output = "";
            int length = current.GetLongestDay();

            if (Day.Length < length)
            {
                Day = $"{ Day }{ new string(' ', length - Day.Length)}";
            }

            int partOneLength = current.Header.Day.Length > current.GetLongestPartOne() ? current.Header.Day.Length : current.GetLongestPartOne();

            One = $"{One}{new string(' ', current.Header.One.Length - One.Length)}";

            int sum = current.Header.Two.Length - Two.Length + 1;
            if (sum > 0)
            {
                Two = $"{Two}{new string(' ', sum)}";
            }

            if (!Header)
            {
                output = $"\n| Day {Day.ToLower()} | {One} | {Two.TrimStart()} |";
            }

            Output = output;
            return output;
        }

        public string GetHeader(Table current)
        {
            Day = $"{ Day }{ new string(' ', current.GetLongestDay() - Day.Length + 4)}";
            One = $"{ One }{ new string(' ', current.GetLongestPartOne() - One.Length)}";
            Two = $"{ Two }{ new string(' ', current.GetLongestPartTwo() - Two.Length + 1)}";
            string output = $"| {Day} | {One} | {Two} |";
            current.Separator = $"+{new string('-', output.Length - 2)}+";
            return $"{current.Separator}\n{output}\n+{new string('-', output.Length - 2)}+";
        }

        public string GetSeparator() => Output;
    }

    enum Names
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Eleven,
        Twelve,
        Thirteen,
        Fourteen,
        Fifteen,
        Sixteen,
        Seventeen,
        Eightteen,
        Nineteen,
        Twenty,
        Twentytwo,
        Twentythree,
        Twentyfour
    }
}
