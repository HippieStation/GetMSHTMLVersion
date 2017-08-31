using System;
using System.Runtime.InteropServices;

namespace GetMSHTMLVersion
{
    class User32
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);
    }
}
