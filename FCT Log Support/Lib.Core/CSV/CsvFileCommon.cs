using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Core
{
    public abstract class CsvFileCommon
    {
        // Fields
        private const int DelimiterIndex = 0;
        private const int QuoteIndex = 1;
        protected char[] SpecialChars = new char[] { ',', '"', '\r', '\n' };

        // Methods
        protected CsvFileCommon()
        {
        }

        // Properties
        public char Delimiter
        {
            get
            {
                return this.SpecialChars[0];
            }
            set
            {
                this.SpecialChars[0] = value;
            }
        }

        public char Quote
        {
            get
            {
                return this.SpecialChars[1];
            }
            set
            {
                this.SpecialChars[1] = value;
            }
        }
    }
}
