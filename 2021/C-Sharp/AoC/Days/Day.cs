using System.Diagnostics;

namespace AoC
{
    public abstract class Day
    {
        /// <summary>
        /// Input from Part1.txt see 
        /// <see cref="GetInput"/>
        /// </summary>
        protected virtual string[] Part1Input { get; set; }

        /// <summary>
        /// Input from Part2.txt see 
        /// <see cref="GetInput"/>
        /// </summary>
        protected virtual string[] Part2Input { get; set; }

        /// <summary>
        /// Runs and returns the output from part 1 and part 2, this function also runs get input to collect data from input files.
        /// <para>You're not really supposed to modify this.</para>
        /// </summary>
        /// <returns>Tuple of the result of <see cref="Part1"/> and <see cref="Part2"/></returns>
        public virtual (long Part1, long Part2) Run()
        {
            GetInput();
            return (Part1(), Part2());
        }

        /// <summary>
        /// Function for any code to run in part 1.
        /// <para>You're expected to override this in each child class.</para>
        /// </summary>
        /// <returns>The result of your functions code</returns>
        public virtual long Part1() => -404;

        /// <summary>
        /// Function for any code to run in part 2
        /// <para>You're expected to override this in each child class.</para>
        /// </summary>
        /// <returns>The result of your functions code</returns>
        public virtual long Part2() => -404;

        /// <summary>
        /// Reserved for any execution of code that may run in bode parts.
        /// </summary>
        /// <returns></returns>
        public virtual void GetInput()
        {
            var className = GetType().UnderlyingSystemType.ToString();
            className = className.Substring(className.LastIndexOf('.') + 1, className.Length - className.LastIndexOf('.') - 1);
            
            Part1Input = Helpers.GetStringInput($@"{className}\Part1");
            Part2Input = Helpers.GetStringInput($@"{className}\Part2");

            if(Part1Input.Length < 1)
                Debug.WriteLine($"FATAL: PART 1 INPUT OF {className} IS 0 - Modify Part1.txt");
            if (Part2Input.Length < 1)
                Debug.WriteLine($"FATAL: PART 2 INPUT OF {className} IS 0 - Modify Part2.txt");
        }
    }
}
