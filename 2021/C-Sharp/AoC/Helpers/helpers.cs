using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC
{
    public static class Helpers
    {
        /// <summary>
        /// Retrieve the rows of a file
        /// </summary>
        /// <param name="file">Path of file</param>
        /// <returns>Return string array</returns>
        public static string[] GetStringInput(string file) =>
            System.IO.File.ReadAllLines(Path.GetFullPath(@"..\..\") + $@"\Inputs\Days\{file}.txt");

        /// <summary>
        /// Convert a string which ends with a number
        /// </summary>
        /// <param name="s">String formatted to end in a number</param>
        /// <returns>The number</returns>
        public static int IntegerValueFromDirection(string s) =>
            int.Parse(System.Text.RegularExpressions.Regex.Match(s, @"\d+").Value);

        /// <summary>
        /// Convert a comma delimited string to an int array.
        /// </summary>
        /// <param name="s">Comma delimited array</param>
        /// <returns>int32 array</returns>
        public static int[] ToIntArr(string s) => Array.ConvertAll(s.Split(','), int.Parse);

        /// <summary>
        /// Convert a string array to an int array.
        /// </summary>
        /// <param name="s">string array</param>
        /// <returns>int32 array</returns>
        public static int[] IntArr(string[] s) => Array.ConvertAll(s, int.Parse);

        public enum Names
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
            Twentyone,
            Twentytwo,
            Twentythree,
            Twentyfour = 24
        }

        public static int GetValueFromName(string s)
        {
            var retval = 0;
            foreach (var enumVal in Enum.GetValues(typeof(Names)))
            {
                if (s == enumVal.ToString())
                {
                    retval = (int)enumVal;
                }
            }
            return retval;
        }

        public static void GenerateDailyFolders(IEnumerable<KeyValuePair<Type, int>> objects)
        {
            var inputsFolder = Path.GetFullPath(@"..\..\Inputs\Days");
            foreach (var type in objects)
            {
                if (!Directory.Exists($@"{inputsFolder}\{type.Key.Name}"))
                {
                    Directory.CreateDirectory($@"{inputsFolder}\{type.Key.Name}");
                    var myFile = File.Create($@"{inputsFolder}\{type.Key.Name}\Part1.txt");
                    myFile.Close();
                    myFile = File.Create($@"{inputsFolder}\{type.Key.Name}\Part2.txt");
                    myFile.Close();
                    Debug.WriteLine(
                        $"ERROR: You have a class {type.Key.Name} which didn't have an input folder. Generated, but not populated.");
                }
            }
        }

        public static IEnumerable<KeyValuePair<Type, int>> GetTypes()
        {
            return (from a in AppDomain.CurrentDomain.GetAssemblies() from b in a.GetTypes() select b)
                .Where(c => c.FullName != null && c.FullName.StartsWith("AoC.Days.") && !c.FullName.Contains("+"))
                .ToList().ToDictionary(s => s, s => Helpers.GetValueFromName(s.Name)).OrderBy(x => x.Value);
        }
    }
}
