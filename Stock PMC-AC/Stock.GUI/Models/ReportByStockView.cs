using System;

namespace Stock.GUI.Models
{
    public class ReportByStockView
    {
        /// <summary>
        /// Tên Nhóm Hàng
        /// </summary>
        public string ProductGroupName { get; set; }

        /// <summary>
        /// Mã Mặt Hàng
        /// </summary>
        public string ProductID { get; set; }

        /// <summary>
        /// Tên Mặt Hàng
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Ngày
        /// </summary>
        public DateTime InventoryDate { get; set; }

        /// <summary>
        /// Tên Đơn Vị
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Tên Kho Hàng
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// Giá
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Số Lượng
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Thành tiền
        /// </summary>
        public int TotalPrice { get; set; }

        public int TotalPriceExport { get { return (Quantity * Price); } }
    }
}