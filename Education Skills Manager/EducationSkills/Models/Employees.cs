﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSkills.Models
{
    public class Employees
    {
        public string StaffCode { get; set; }
        public string FullName { get; set; }
        public string DeptCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sex { get; set; }
        public DateTime? EntryDate { get; set; }
        public string PosName { get; set; }
    }
}
