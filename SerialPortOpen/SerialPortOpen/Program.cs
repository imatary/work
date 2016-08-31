using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace SerialPortOpen
{
    class Program
    {
        static void Main(string[] args)
        {
            var portNames = SerialPort.GetPortNames();

            foreach (var port in portNames)
            {
                Console.WriteLine(port);
            }

            Console.ReadKey();
        }
    }
}
