using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC.Days
{
    internal class Eight : Day
    {
        public override long Part1()
        {
            List<int> map = new();
            foreach (var t in Part1Input)
            {
                var content = t
                                        .Split('|', (char)StringSplitOptions.RemoveEmptyEntries)[1]
                                        .Split(' ')
                                        .Select(x => x)
                                        .Where(x=>x.Length > 0)
                                        .ToList();

                foreach (var t1 in content)
                {
                    switch (new string(t1.Distinct()
                                         .ToArray())
                                         .Length)
                    {
                        case 2:
                            map.Add(1);
                            break;
                        case 4:
                            map.Add(4);
                            break;
                        case 3:
                            map.Add(7);
                            break;
                        case 7:
                            map.Add(8);
                            break;
                    }
                }
            }
            return map.Count;
        }

        public override long Part2()
        {
            var retval = 0;
            foreach (var line in Part2Input)
            {
                var split       = line.Split('|');
                var unique      = split[0].Trim().Split(' ').OrderBy(x => x.Length).ToList();
                var output      = split[1].Trim().Split(' ').Where(x => x.Length > 0);

                var one         = unique.Single(x => x.Length == 2);
                var seven       = unique.Single(x => x.Length == 3);
                var four        = unique.Single(x => x.Length == 4);
                var eight       = unique.Single(x => x.Length == 7);
                
                var six         = unique.Where(x => x.Length == 6).Single(x => x.Intersect(one).Count() == 1);
                var bottomRight = one.Intersect(six).Single();
                var topRight    = one.Single(x => x != bottomRight);

                var two         = unique.Where(x => x.Length == 5).Single(x => x.Contains(topRight) && !x.Contains(bottomRight));
                var five        = unique.Where(x => x.Length == 5).Single(x => !x.Contains(topRight) && x.Contains(bottomRight));
                var three       = unique.Where(x => x.Length == 5).Single(x => x.Contains(topRight) && x.Contains(bottomRight));

                var bottomLeft  = two.Except(five).Single(x => x != topRight);
                var zero        = unique.Where(x => x.Length == 6 && x != six).Single(x => x.Contains(bottomLeft));
                
                var lineNumber  = 0;
                foreach (var digit in output)
                {
                    int current    = 0, 
                        len     = digit.Length;

                    if (zero.Length         == len && zero  .Intersect(digit).Count() == len)
                        current = 0;
                    else if (one.Length     == len && one   .Intersect(digit).Count() == len)
                        current = 1;
                    else if (two.Length     == len && two   .Intersect(digit).Count() == len)
                        current = 2;
                    else if (three.Length   == len && three .Intersect(digit).Count() == len)
                        current = 3;
                    else if (four.Length    == len && four  .Intersect(digit).Count() == len)
                        current = 4;
                    else if (five.Length    == len && five  .Intersect(digit).Count() == len)
                        current = 5;
                    else if (six.Length     == len && six   .Intersect(digit).Count() == len)
                        current = 6;
                    else if (seven.Length   == len && seven .Intersect(digit).Count() == len)
                        current = 7;
                    else if (eight.Length   == len && eight .Intersect(digit).Count() == len)
                        current = 8;
                    else
                        current = 9;

                    lineNumber = lineNumber * 10 + current;
                }
                retval += lineNumber;
            }
            return retval;
        }
    }
}
