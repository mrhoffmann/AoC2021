using System;
using System.Diagnostics;
using System.IO;

namespace RunPowerShellWindow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OpenPowershell(args[0]);
        }

        static void OpenPowershell(string path)
        {
            if (path.Length > 0)
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("File doesn't exist at " + path);
                }
                else
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(path)
                    {
                        UseShellExecute = false
                    };
                    startInfo.EnvironmentVariables.Add("RedirectStandardOutput", "true");
                    startInfo.EnvironmentVariables.Add("RedirectStandardError", "true");
                    startInfo.EnvironmentVariables.Add("UseShellExecute", "false");
                    startInfo.EnvironmentVariables.Add("CreateNoWindow", "true");
                    Process.Start(startInfo);
                }
            }
            else
            {
                Console.WriteLine("No path specified.");
            }
        }
    }
}
