﻿using System;

namespace CPU_Nichicon_Supports_MES
{
    public class Item
    {
        public string BoardNo { get; set; }
        public string Model { get; set; }
        //public string Model {
        //    get {
        //        string model = null;
        //        if (BoardNo != null)
        //        {
        //            string[] tmp = BoardNo.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        //            model = tmp[0];
        //        }
        //        return model;
        //    }
        //}

        public DateTime EndDateTime { get; set; }

        public string Date {
            get
            {
                if (EndDateTime != null)
                {
                    return DateTime.Now.ToShortDateString();
                }

                return null;
            }
        }
        public string Time {
            get
            {
                return DateTime.Now.ToShortTimeString();
            }
        }
        public int Result { get; set; }
        public string Status {
            get
            {
                string _status = null;
                if (Result==1)
                {
                    _status = "P";
                }
                if (Result == 0)
                {
                    _status = "F";
                }
                return _status;
            }
        }
        public string State {
            get
            {
                string _status = null;
                if (Result == 1)
                {
                    _status = "PASS";
                }
                if (Result == 0)
                {
                    _status = "FAIL";
                }
                return _status;
            }
        }
    }
}
