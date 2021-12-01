using System;

namespace AoC
{
    public static class Helpers
    {
        public static int[] GetInput(string file) =>  Array.ConvertAll(System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(@"..\..\") + @"\Inputs\" + file + ".txt"), s => int.Parse(s));
    }
}
