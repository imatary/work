using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace ComPortTest
{
    class Program
    {
        private const uint GENERIC_ALL = 0x10000000;
        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const uint GENERIC_EXECUTE = 0x20000000;
        private const int OPEN_EXISTING = 3;
        public const int INVALID_HANDLE_VALUE = -1;
        static void Main(string[] args)
        {
            //for (int i = 1; i <= 32; i++)
            //    Console.WriteLine("Port {0}: {1}", i, PortExists(i));

            //foreach (string s in SerialPort.GetPortNames())
            //{
            //    Console.WriteLine(s);
            //}





            

            SerialPort mySerialPort = new SerialPort("COM2");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            mySerialPort.Open();

            Console.WriteLine("Press any key to continue...");
            Console.WriteLine();
            Console.ReadKey();
            mySerialPort.Close();

            Console.ReadKey();
        }


        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Debug.Print("Data Received:");
            Debug.Print(indata);
        }


        private static bool PortExists(int number)
        {
            SafeFileHandle h = CreateFile(@"\\.\COM" + number.ToString(), GENERIC_READ + GENERIC_WRITE,
                0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

            bool portExists = !h.IsInvalid;

            if (portExists)
                h.Close();

            return portExists;
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern SafeFileHandle CreateFile(string lpFileName, System.UInt32 dwDesiredAccess,
            System.UInt32 dwShareMode, IntPtr pSecurityAttributes, System.UInt32 dwCreationDisposition,
            System.UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);
    }
}
