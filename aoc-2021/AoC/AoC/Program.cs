using System;
using System.Linq;

namespace AoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach
            (
                var type in (from a in AppDomain.CurrentDomain.GetAssemblies() from b in a.GetTypes() select b)
                .Where(c => c.Name.StartsWith("Day") &&
                !(
                    new string[] {
                        "Day",
                        "DayOfWeek",
                        "DaylightTime",
                        "DaylightTimeStruct"
                })
                .Contains(c.Name))
                .ToList()
            )
            {
                Console.WriteLine($"Day {type.Name.Substring(3, type.Name.Length - 3).ToLower()}");
                string[] values = 
                    type
                    .GetMethod("Run")
                    .Invoke(
                        type
                        .GetConstructor(Type.EmptyTypes)
                        .Invoke(
                            new object[] { }),
                            new object[] { })
                                .ToString()
                                .Replace("(", string.Empty)
                                .Replace(")", string.Empty)
                                .Split(new char[] { ',' });

                for(var i = 0; i < values.Length; i++)
                    Console.WriteLine($"\tPart {i}\t{values[i].Trim()}");
            }
            Console.ReadKey();
        }
    }
}
