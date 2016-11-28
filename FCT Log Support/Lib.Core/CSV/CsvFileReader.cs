using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Lib.Core
{
    public class CsvFileReader : CsvFileCommon, IDisposable
    {
        // Fields
        private string CurrLine;
        private int CurrPos;
        private EmptyLineBehavior EmptyLineBehavior;
        private StreamReader Reader;

        // Methods
        public CsvFileReader(Stream stream, EmptyLineBehavior emptyLineBehavior = 0)
        {
            this.Reader = new StreamReader(stream);
            this.EmptyLineBehavior = emptyLineBehavior;
        }

        public CsvFileReader(string path, EmptyLineBehavior emptyLineBehavior = 0)
        {
            this.Reader = new StreamReader(path);
            this.EmptyLineBehavior = emptyLineBehavior;
        }

        public void Dispose()
        {
            this.Reader.Dispose();
        }

        private string ReadQuotedColumn()
        {
            Debug.Assert((this.CurrPos < this.CurrLine.Length) && (this.CurrLine[this.CurrPos] == base.Quote));
            this.CurrPos++;
            StringBuilder builder = new StringBuilder();
            while (true)
            {
                while (this.CurrPos == this.CurrLine.Length)
                {
                    this.CurrLine = this.Reader.ReadLine();
                    this.CurrPos = 0;
                    if (this.CurrLine == null)
                    {
                        return builder.ToString();
                    }
                    builder.Append(Environment.NewLine);
                }
                if (this.CurrLine[this.CurrPos] == base.Quote)
                {
                    int num = this.CurrPos + 1;
                    if ((num >= this.CurrLine.Length) || (this.CurrLine[num] != base.Quote))
                    {
                        if (this.CurrPos < this.CurrLine.Length)
                        {
                            Debug.Assert(this.CurrLine[this.CurrPos] == base.Quote);
                            this.CurrPos++;
                            builder.Append(this.ReadUnquotedColumn());
                        }
                        return builder.ToString();
                    }
                    this.CurrPos++;
                }
                int currPos = this.CurrPos;
                this.CurrPos = currPos + 1;
                builder.Append(this.CurrLine[currPos]);
            }
        }

        public bool ReadRow(List<string> columns)
        {
            if (columns == null)
            {
                throw new ArgumentNullException("columns");
            }
            Label_0014:
            this.CurrLine = this.Reader.ReadLine();
            this.CurrPos = 0;
            if (this.CurrLine == null)
            {
                return false;
            }
            if (this.CurrLine.Length == 0)
            {
                switch (this.EmptyLineBehavior)
                {
                    case EmptyLineBehavior.NoColumns:
                        columns.Clear();
                        return true;

                    case EmptyLineBehavior.Ignore:
                        goto Label_0014;

                    case EmptyLineBehavior.EndOfFile:
                        return false;
                }
            }
            int index = 0;
            while (true)
            {
                string str;
                if ((this.CurrPos < this.CurrLine.Length) && (this.CurrLine[this.CurrPos] == base.Quote))
                {
                    str = this.ReadQuotedColumn();
                }
                else
                {
                    str = this.ReadUnquotedColumn();
                }
                if (index < columns.Count)
                {
                    columns[index] = str;
                }
                else
                {
                    columns.Add(str);
                }
                index++;
                if ((this.CurrLine == null) || (this.CurrPos == this.CurrLine.Length))
                {
                    if (index < columns.Count)
                    {
                        columns.RemoveRange(index, columns.Count - index);
                    }
                    return true;
                }
                Debug.Assert(this.CurrLine[this.CurrPos] == base.Delimiter);
                this.CurrPos++;
            }
        }

        private string ReadUnquotedColumn()
        {
            int currPos = this.CurrPos;
            this.CurrPos = this.CurrLine.IndexOf(base.Delimiter, this.CurrPos);
            if (this.CurrPos == -1)
            {
                this.CurrPos = this.CurrLine.Length;
            }
            if (this.CurrPos > currPos)
            {
                return this.CurrLine.Substring(currPos, this.CurrPos - currPos);
            }
            return string.Empty;
        }
    }
}
