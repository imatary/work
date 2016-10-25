using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Timer t = new Timer(TimerCallback, null, 0, 1000);
            // Wait for the user to hit <Enter>
            Console.ReadLine();
            Console.ReadKey();
        }

        private struct WinText
        {
            public IntPtr hWnd;
            public string Text;
        }

        const int WM_GETTEXT = 0x0D;
        const int WM_GETTEXTLENGTH = 0x0E;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int Param, System.Text.StringBuilder text);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


        private static void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            //Console.WriteLine("In TimerCallback: " + DateTime.Now);
            // Force a garbage collection to occur for this demo.

            List<WinText> windows = new List<WinText>();

            //find the "first" window
            IntPtr hWnd = FindWindow("TeamViewer", null);

            while (hWnd != IntPtr.Zero)
            {
                //find the control window that has the text
                IntPtr hEdit = FindWindowEx(hWnd, IntPtr.Zero, null, null);

                //initialize the buffer.  using a StringBuilder here
                System.Text.StringBuilder sb = new System.Text.StringBuilder(255);  // or length from call with GETTEXTLENGTH

                //get the text from the child control
                int RetVal = SendMessage(hEdit, WM_GETTEXT, sb.Capacity, sb);

                windows.Add(new WinText() { hWnd = hWnd, Text = sb.ToString() });

                //find the next window
                hWnd = FindWindowEx(IntPtr.Zero, hWnd, "TeamViewer", null);
            }

            //do something clever
            windows.OrderBy(x => x.Text).ToList().ForEach(y => Console.Write("{0} = {1}\n", y.hWnd, y.Text));

            Console.WriteLine("\n\nFound {0} window(s).", windows.Count);

            GC.Collect();
        }
    }
}
