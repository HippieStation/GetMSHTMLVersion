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
        [STAThread]
        static void Main(string[] args)
        {
            var byondProcesses = Process.GetProcessesByName("dreamseeker");
            if (byondProcesses.Length <= 0)
            {
                User32.MessageBox((IntPtr)0, "BYOND must be opened and you must be connected to a server to run this tool.", "GetMSHTMLVersion", 0);
                return;
            }

            var byondProcess = byondProcesses[0]; // Use the first process, fuck the others.
            var byondProcessModules = byondProcess.Modules;

            var tridentModule = byondProcess.Modules.OfType<ProcessModule>().First(pm => pm.ModuleName.Contains("mshtml.dll"));
            if (tridentModule == null)
            {
                User32.MessageBox((IntPtr)0, "Unable to find MSHTML in dreamseeker?", "GetMSHTMLVersion", 0);
                return;
            }

            var tridentModuleVersion = tridentModule.FileVersionInfo;
            System.Windows.Forms.Clipboard.SetText(tridentModuleVersion.ToString());
            User32.MessageBox((IntPtr)0, "Version details copied to clipboard\n\n" + tridentModuleVersion.ToString(), "GetMSHTMLVersion", 0);
        }
    }
}
