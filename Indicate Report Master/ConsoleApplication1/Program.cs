using System;
using System.IO;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        const string FilePathWip21 = @"C:\Share\1\INDICATE_REPORT.txt";
        static void Main(string[] args)
        {
            
            //File.WriteAllText(FilePathWip21, string.Empty);

            new Thread(() => ReadFromFile()).Start();

            WriteToFile();
        }

        private static void ReadFromFile()
        {
            long offset = 0;

            FileSystemWatcher fsw = new FileSystemWatcher
            {
                Path = "C:\\Share\\1",
                Filter = "INDICATE_REPORT.txt"
            };

            FileStream file = File.Open(
                FilePathWip21,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Write);

            StreamReader reader = new StreamReader(file);
            while (true)
            {
                fsw.WaitForChanged(WatcherChangeTypes.Changed);

                file.Seek(offset, SeekOrigin.Begin);
                if (!reader.EndOfStream)
                {
                    do
                    {
                        Console.WriteLine(reader.ReadLine());
                    } while (!reader.EndOfStream);

                    offset = file.Position;
                }
            }
        }

        private static void WriteToFile()
        {
            for (int i = 0; i < 500; i++)
            {
                FileStream writeFile = File.Open(
                    FilePathWip21,
                    FileMode.Append,
                    FileAccess.Write,
                    FileShare.Read);
                string input = "u16354|ICT|Model_01|600|" + i + "|26/07/2015";

                using (FileStream file = writeFile)
                {
                    using (var sw = new StreamWriter(file))
                    {

                        sw.WriteLine(input);
                        Thread.Sleep(100);
                    }
                }
            }
        }
    }
}
