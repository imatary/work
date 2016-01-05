using System;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "\\umc-c357\\New folder\\INDICATE_REPORT.txt";
            bool isFileInUse = FileInUse(filePath);

            // Then you can do some checking
            if (isFileInUse)
                Console.WriteLine("File is in use");
            else
                Console.WriteLine("File is not in use");

            Console.ReadKey();
        }

        public static bool FileInUse(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    bool canRead = fs.CanRead;
                    bool canSeek = fs.CanSeek;
                }

                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }
    }
}
