using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetMSHTMLVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            var byondProcesses = Process.GetProcessesByName("dreamseeker");
            if (byondProcesses.Length <= 0)
            {
                Console.WriteLine("BYOND must be opened and you must be connected to a server to run this tool.");
                return;
            }

            var byondProcess = byondProcesses[0]; // Use the first process, fuck the others.
            var byondProcessModules = byondProcess.Modules;

            var tridentModule = byondProcess.Modules.OfType<ProcessModule>().First(pm => pm.ModuleName.Contains("mshtml.dll"));
            if (tridentModule == null)
            {
                Console.WriteLine("Unable to find MSHTML in dreamseeker?");
                return;
            }

            var tridentModuleVersion = tridentModule.FileVersionInfo;
            Console.WriteLine(tridentModuleVersion);
        }
    }
}
