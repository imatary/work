﻿using System;
using System.ComponentModel.DataAnnotations;

namespace EducationSkills
{
    public class Staff
    {
        public string StaffCode { get; set; }
        public string FullName { get; set; }
        public string DeptCode { get; set; }
        public string MaBoMon { get; set; }
        [DataType(DataType.Date)]
        public DateTime? NgayThamGia { get; set; }
        //public int Count {
        //    get {
        //        int count = 0;
        //        if (NgayThamGia != null)
        //        {
        //            return count = count + 1;
        //        }
        //        else
        //        {
        //            return count;
        //        }

        //    }
        //}
    }
}
