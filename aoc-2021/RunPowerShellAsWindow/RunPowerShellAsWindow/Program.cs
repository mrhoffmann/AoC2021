using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RunPowerShellAsWindow
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine($"Current directory: {AppDomain.CurrentDomain.BaseDirectory}");
            if (args.Count() > 0)
                OpenPowershell(args[args.Count()], args[args.Count() - 1]);
            else
                OpenPowershell($@"{AppDomain.CurrentDomain.BaseDirectory}ps1.ps1", "-NoProfile -ExecutionPolicy bypass");
            Console.ReadKey();
        }

        static void OpenPowershell(string Path, string Flags)
        {
            if (Path.Length > 0)
            {
                if (!File.Exists(Path))
                {
                    Console.WriteLine("File doesn't exist at " + Path);
                }
                else
                {
                    Console.WriteLine($"Request to start {Path}");

                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = @"powershell.exe",
                        Arguments = $@"& Set-ExecutionPolicy bypass; & '{Path}'",
                        RedirectStandardOutput = true,
                        RedirectStandardError = false,
                        UseShellExecute = false,
                        CreateNoWindow = false,
                        RedirectStandardInput = false
                    };
                    new Process
                    {
                        StartInfo = startInfo
                    }.Start();

                    /*
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo($@"{Flags} {Path}")
                        {
                            UseShellExecute = true
                        }
                    };
                    process.Start();*/
                }
            }
            else
            {
                Console.WriteLine("No path specified.");
            }
        }
    }
}
