using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication2
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //var windowHandle = ExternalWriter.FindWindow("TeamViewer", "TeamViewer");
        //    //var textboxHandle = ExternalWriter.FindWindowEx(windowHandle, IntPtr.Zero, null, null);

        //    //string message = "Hello World!";
        //    ////byte[] buffer = ToBytes(message);
        //    //ExternalWriter.SendMessage(textboxHandle, ExternalWriter.WM_SETTEXT, IntPtr.Zero, message);

        //    //Console.WriteLine();

        //    //Console.ReadKey();
        //}

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm());
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


    class MyForm : Form
    {
        Button btn;
        BackgroundWorker worker;
        ProgressBar bar;
        public MyForm()
        {
            Controls.Add(btn = new Button { Text = "Click me" });
            btn.Click += new EventHandler(btn_Click);

            Controls.Add(bar = new ProgressBar { Dock = DockStyle.Bottom, Visible = false, Minimum = 0, Maximum = 100 });

            worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bar.Visible = false;
            if (e.Error != null)
            {
                Text = e.Error.Message;
            }
            else if (e.Cancelled)
            {
                Text = "cancelled";
            }
            else
            {
                Text = e.Result == null ? "complete" : e.Result.ToString();
            }
            btn.Enabled = true;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int count = 0; count < 100; count++)
            {
                worker.ReportProgress(count);
                Thread.Sleep(50);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            bar.Value = e.ProgressPercentage;
        }

        void btn_Click(object sender, EventArgs e)
        {
            bar.Value = 0;
            bar.Visible = true;
            btn.Enabled = false;
            worker.RunWorkerAsync();
        }
    }
}
