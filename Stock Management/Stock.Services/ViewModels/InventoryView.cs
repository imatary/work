﻿using System;

namespace Stock.Services
{
    public class InventoryView
    {
        /// <summary>
        /// Mã Nhóm Sản Phẩm
        /// </summary>
        public string ProductGroupID { get; set; }
        /// <summary>
        /// Tên nhóm sản phẩm
        /// </summary>
        public string ProductGroupName { get; set; }

        /// <summary>
        /// Mã Sản Phẩm
        /// </summary>
        public string ProductID { get; set; }
        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Giá Sản Phẩm
        /// </summary>
        public long Price { get; set; }

        /// <summary>
        /// Mã Kho Hàng
        /// </summary>
        public string StockID { get; set; }

        /// <summary>
        /// Tên Kho Hàng
        /// </summary>
        public string StockName { get; set; }


        /// <summary>
        /// Mã đơn vị
        /// </summary>
        public string UnitID { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Ngày Tháng
        /// </summary>
        public DateTime InventoryDate { get; set; }

        /// <summary>
        /// Số Lượng Tồn
        /// </summary>
        public int QuantityInventory { get; set; }

        /// <summary>
        /// Số lượng đầu
        /// </summary>
        public int QuantityFirst { get; set; }

        /// <summary>
        /// Tổng tiền đầu
        /// </summary>
        public long TotalPriceFirst {
            get { return (QuantityImport * Price); }
        }

        /// <summary>
        /// Tổng Tiền
        /// </summary>
        public int TotalPrice { get; set; }

        /// <summary>
        /// Số lượng Nhập
        /// </summary>
        public int QuantityImport { get; set; }

        /// <summary>
        /// Tổng tiền nhập
        /// </summary>
        public long TotalPriceImport 
        {
            get { return (QuantityImport * Price); }  
        }

        /// <summary>
        /// Số lượng xuất
        /// </summary>
        public int QuantityExport { get; set; }

        /// <summary>
        /// Tổng tiền xuất
        /// </summary>
        public long TotalPriceExport { get { return (QuantityExport * Price); } }

        /// <summary>
        /// Tổng tồn
        /// </summary>
        public long TotalInventory { get { return (QuantityInventory * Price); } }
    }
}