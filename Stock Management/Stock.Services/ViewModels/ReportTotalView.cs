﻿using System;

namespace Stock.Services
{
    public class ReportTotalView
    {
        public string ProductID { get; set; }


        public string ProductName { get; set; }

        public string Description { get; set; }

        public string SPQ { get; set; }

        public float Price { get; set; }

        public int Inventory { get; set; }

        public int Plan { get; set; }

        public int TotalIn { get; set; }

        public int TotalOut { get; set; }

        public int InventoryLast { get; set; }

        public float InventoryPrice { get; set; }

        public DateTime? InventoryDate { get; set; }

        public string SearchByDate { get; set; }
    }
}