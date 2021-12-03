using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AoC
{
    internal class Program
    {
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

        static int GetValueFromName(string s)
        {
            int retval = 0;
            foreach(var enumVal in Enum.GetValues(typeof(Names)))
            {
                if(s == enumVal.ToString())
                {
                    retval = (int)enumVal;
                }
            }
            return retval;
        }

        static void Main(string[] args)
        {
            var types = (from a in AppDomain.CurrentDomain.GetAssemblies() from b in a.GetTypes() select b)
                .Where(c => c.FullName.StartsWith("AoC.Days.") && !c.FullName.Contains("+"))
                .ToList();

            Dictionary<Type, int> ClassOrder = new Dictionary<Type, int>();

            foreach (var s in types)
                ClassOrder.Add(s, GetValueFromName(s.Name));
            var obj = ClassOrder.OrderBy(x => x.Value);

            foreach
            (
                var type in obj
            )
            {
                Console.WriteLine($"Day {type.Key.Name}");
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

                for (var i = 0; i < values.Length; i++)
                    Console.WriteLine($"\tPart {i}\t{values[i].Trim()}");
            }
            Console.ReadKey();
        }
    }
}
