﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSkills
{
    public static class Ultils
    {
        public static DateTime CalYearDateTime (this DateTime datetime)
        {
            DateTime genrateDate = new DateTime();


            return genrateDate;
        }

        public static bool IsNull(string value)
        {
            if (value != "" && !string.IsNullOrEmpty(value) && value.Length >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
