using System;

namespace Stock.GUI.Models
{
    public class ReportByDepartment
    {
        public string ProductID { get; set; }

        public string DepartmentID { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string SPQ { get; set; }

        public float Price { get; set; }

        public int Stock { get; set; }

        public int Plan { get; set; }

        public int Total{ get; set; }

        public float TotalPrice
        {
            get { return Total*Price; }
        }


        //public int TotalOut { get; set; }

        //public int InventoryLast { get; set; }

        //public float InventoryPrice { get; set; }

        //public DateTime? InventoryDate { get; set; }

        //public string SearchByDate { get; set; } 
    }
}