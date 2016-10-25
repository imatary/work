using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var windowHandle = ExternalWriter.FindWindow("TeamViewer", "TeamViewer");
            var textboxHandle = ExternalWriter.FindWindowEx(windowHandle, IntPtr.Zero, null, null);

            string message = "Hello World!";
            //byte[] buffer = ToBytes(message);
            ExternalWriter.SendMessage(textboxHandle, ExternalWriter.WM_SETTEXT, IntPtr.Zero, message);

            Console.WriteLine();

            Console.ReadKey();
        }
    }

   static class ExternalWriter
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string className, string lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, string lParam);

        public const int WM_SETTEXT = 12;

        public static void DoExternalWrite(string text)
        {
            IntPtr parent = FindWindow("&lt;window class name&gt;", "&lt;window title&gt;");
            IntPtr child = GetChildHandle(parent, "&lt;class name&gt;");

            SendMessage(child, WM_SETTEXT, IntPtr.Zero, text);
        }

        private static IntPtr GetChildHandle(IntPtr parent, string className)
        {
            /* Here you need to perform some sort of function to obtain the child window handle, perhaps recursively
             */

            IntPtr child = FindWindowEx(parent, IntPtr.Zero, className, null);
            child = FindWindowEx(parent, child, className, null);

            /* You can use a tool like Spy++ to discover the hierachy on the Remedy 7 form, to find how many levels you need to search
             * to get to the textbox you want */

            return child;
        }
    }
}
