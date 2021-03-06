﻿using System;

namespace BarcodeShipping.Data
{
    public class User
    {
        public string OperatorCode { get; set; }

        public string OperatorName { get; set; }

        public int LineID { get; set; }

        public int OperationID { get; set; }

        public string ProcessID { get; set; }

        public bool CheckItemOnWIP { get; set; }
    }
}