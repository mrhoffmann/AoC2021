using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AoC
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var table = new Table
            {
                Rows = new List<TableRow>()
            };

            var obj = Helpers.GetTypes();
            Helpers.GenerateDailyFolders(obj);

            table.Header = new TableRow()
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
                var values =
                    type.Key
                        .GetMethod("Run")
                        ?.Invoke(
                            type.Key
                                .GetConstructor(Type.EmptyTypes)
                                ?.Invoke(
                                    new object[] { }),
                            new object[] { })
                        .ToString()
                        .Replace("(", string.Empty)
                        .Replace(")", string.Empty)
                        .Split(new char[] {','});

                if (values != null)
                    table.Rows.Add(new TableRow()
                    {
                        Day = type.Key.Name,
                        One = values[0],
                        Two = values[1]
                    });
            }

            Debug.WriteLine(table.Output);
        }
    }
}
