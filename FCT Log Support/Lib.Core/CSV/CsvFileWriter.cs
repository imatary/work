using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lib.Core
{
    public class CsvFileWriter : CsvFileCommon, IDisposable
    {
        // Fields
        private string OneQuote;
        private string QuotedFormat;
        private string TwoQuotes;
        private StreamWriter Writer;

        // Methods
        public CsvFileWriter(Stream stream)
        {
            this.OneQuote = null;
            this.TwoQuotes = null;
            this.QuotedFormat = null;
            this.Writer = new StreamWriter(stream);
        }

        public CsvFileWriter(string path)
        {
            this.OneQuote = null;
            this.TwoQuotes = null;
            this.QuotedFormat = null;
            this.Writer = new StreamWriter(path);
        }

        public void Dispose()
        {
            this.Writer.Dispose();
        }

        public void WriteRow(List<string> columns)
        {
            if (columns == null)
            {
                throw new ArgumentNullException("columns");
            }
            if ((this.OneQuote == null) || (this.OneQuote[0] != base.Quote))
            {
                this.OneQuote = string.Format("{0}", base.Quote);
                this.TwoQuotes = string.Format("{0}{0}", base.Quote);
                this.QuotedFormat = string.Format("{0}{{0}}{0}", base.Quote);
            }
            for (int i = 0; i < columns.Count; i++)
            {
                if (i > 0)
                {
                    this.Writer.Write(base.Delimiter);
                }
                if (columns[i].IndexOfAny(base.SpecialChars) == -1)
                {
                    this.Writer.Write(columns[i]);
                }
                else
                {
                    this.Writer.Write(this.QuotedFormat, columns[i].Replace(this.OneQuote, this.TwoQuotes));
                }
            }
            this.Writer.WriteLine();
        }
    }



}
