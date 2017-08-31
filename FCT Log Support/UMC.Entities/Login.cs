using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMC.Entities
{
    public class Login
    {
        public string OperatorCode { get; set; }

        public string OperatorName { get; set; }

        public int LineID { get; set; }

        public int OperationID { get; set; }

        public string ProcessID { get; set; }

        public bool CheckItemOnWIP { get; set; }
    }
}
