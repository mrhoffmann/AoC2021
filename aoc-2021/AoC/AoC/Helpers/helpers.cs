namespace AoC
{
    public static class Helpers
    {
        public static int[] GetIntInput(string file) =>  System.Array.ConvertAll(GetStringInput(file), s => int.Parse(s));
        public static string[] GetStringInput(string file) => System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(@"..\..\") + @"\Inputs\Days\" + file + ".txt");
        public static int IntegerValueFromDirection(string s) => int.Parse(System.Text.RegularExpressions.Regex.Match(s, @"\d+").Value);
    }
}
