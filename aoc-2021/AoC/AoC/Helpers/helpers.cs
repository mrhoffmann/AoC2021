using System;
using System.Text.RegularExpressions;

namespace AoC
{
    /// <summary>
    /// Recurring functions
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Get input from file as integer
        /// </summary>
        /// <param name="file">Target file name without extension or directory</param>
        /// <returns>int[]</returns>
        public static int[] GetIntInput(string file) =>  Array.ConvertAll(GetStringInput(file), s => int.Parse(s));
        public static string[] GetStringInput(string file) => System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(@"..\..\") + @"\Inputs\Days\" + file + ".txt");

        /// <summary>
        /// Always assumes a non-format changing string of <up/down/forward> <num>.
        /// </summary>
        /// <param name="s"><up/down/forward> <num> formatted string</param>
        /// <returns>Integer representation of the <num> value</returns>
        public static int IntegerValueFromDirection(string s) => int.Parse(Regex.Match(s, @"\d+").Value);
    }
}
