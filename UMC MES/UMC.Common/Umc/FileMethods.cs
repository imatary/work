using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Umc
{
    public static class FileMethods
{
    // Methods
    public static object DeserializeXml(string filePath, Type type)
    {
        object obj2;
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        if (type == null)
        {
            throw Error.ArgumentNull("type");
        }
        using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            obj2 = new XmlSerializer(type).Deserialize(stream);
            stream.Close();
        }
        return obj2;
    }

    public static Encoding GetEncoding(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        return GetEncodingCore(filePath);
    }

    private static Encoding GetEncodingCore(string filePath)
    {
        Encoding encoding = Encoding.Default;
        byte[] buffer = new byte[5];
        using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            stream.Read(buffer, 0, 5);
            stream.Close();
        }
        if (((buffer[0] == 0xef) && (buffer[1] == 0xbb)) && (buffer[2] == 0xbf))
        {
            return Encoding.UTF8;
        }
        if ((buffer[0] == 0xfe) && (buffer[1] == 0xff))
        {
            return Encoding.Unicode;
        }
        if (((buffer[0] == 0) && (buffer[1] == 0)) && ((buffer[2] == 0xfe) && (buffer[3] == 0xff)))
        {
            return Encoding.UTF32;
        }
        if (((buffer[0] == 0x2b) && (buffer[1] == 0x2f)) && (buffer[2] == 0x76))
        {
            encoding = Encoding.UTF7;
        }
        return encoding;
    }

    private static void ParseTextRow(string line, char delimiter, ICollection<string[]> collection)
    {
        List<string> list = new List<string>();
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < line.Length; i++)
        {
            char ch = line[i];
            builder.Append(ch);
            if (ch == delimiter)
            {
                string str = builder.ToString();
                if (!str.StartsWith("\"") || str.EndsWith("\""))
                {
                    list.Add(str.TrimStart(new char[] { '"' }).TrimEnd(new char[] { '"' }));
                }
            }
        }
        collection.Add(list.ToArray());
    }

    public static IEnumerable<string[]> ParseTextRows(string filePath, char delimiter)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        if (delimiter == '\0')
        {
            throw Error.Argument("invalid delimiter!");
        }
        List<string[]> collection = new List<string[]>();
        foreach (string str in ReadTextLines(filePath))
        {
            string line = str;
            ParseTextRow(line, delimiter, collection);
        }
        return collection;
    }

    public static byte[] ReadBinary(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int) stream.Length);
            stream.Close();
            return buffer;
        }
    }

    public static string ReadText(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        Encoding encodingCore = GetEncodingCore(filePath);
        return ReadText(filePath, encodingCore);
    }

    public static string ReadText(string filePath, Encoding encoding)
    {
        string str2;
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (StreamReader reader = new StreamReader(stream, encoding))
            {
                string str = reader.ReadToEnd();
                reader.Close();
                str2 = str;
            }
        }
        return str2;
    }

    public static string[] ReadTextLines(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        Encoding encodingCore = GetEncodingCore(filePath);
        return ReadTextLines(filePath, encodingCore);
    }

    public static string[] ReadTextLines(string filePath, Encoding encoding)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        List<string> list = new List<string>();
        using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (StreamReader reader = new StreamReader(stream, encoding))
            {
                while (!reader.EndOfStream)
                {
                    string item = reader.ReadLine();
                    list.Add(item);
                }
                reader.Close();
            }
        }
        return list.ToArray();
    }

    public static void SerializeXml(string filePath, object obj)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        if (obj == null)
        {
            throw Error.ArgumentNull("obj");
        }
        using (FileStream stream = File.Open(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            new XmlSerializer(obj.GetType()).Serialize((Stream) stream, obj);
            stream.Flush();
            stream.Close();
        }
    }

    public static void WriteBinary(string filePath, byte[] binary)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        if (binary == null)
        {
            throw Error.ArgumentNull("binary");
        }
        using (FileStream stream = File.Open(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(binary);
                writer.Flush();
                writer.Close();
            }
        }
    }

    public static void WriteText(string filePath, string text, Encoding encoding)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw Error.Argument("invalid file path!");
        }
        if (string.IsNullOrEmpty(text))
        {
            throw Error.Argument("invalid text!");
        }
        if (encoding == null)
        {
            throw Error.ArgumentNull("encoding");
        }
        using (FileStream stream = File.Open(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
            using (StreamWriter writer = new StreamWriter(stream, encoding))
            {
                writer.Write(text);
                writer.Flush();
                writer.Close();
            }
            stream.Close();
        }
    }
}


}