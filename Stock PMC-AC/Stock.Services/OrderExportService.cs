using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class OrderExportService
    {
        private readonly StockACEntities _context;

        public OrderExportService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<OrderExport> GetOrderExports()
        {
            using (var context=new StockACEntities())
            {
                return context.OrderExports.ToList();
            }
        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="orderExportId">ID</param>
        /// <returns></returns>
        public OrderExport GetOrderExportById(string orderExportId)
        {
            return _context.OrderExports.FirstOrDefault(u => u.OrderExportID == orderExportId);
        }

        public bool CheckOrderExportIdExit(string orderExportId)
        {
            OrderExport orderExport = GetOrderExportById(orderExportId);
            if (orderExport != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="orderExport"></param>
        /// <returns></returns>
        public void Add(OrderExport orderExport)
        {
            _context.OrderExports.Add(orderExport);
            SaveChanges();
        }

        /// <summary>
        /// Tạo ID kế tiếp
        /// </summary>
        /// <returns></returns>
        public string NextId()
        {
            var orderExports = GetOrderExports();
            if (orderExports != null)
            {
                OrderExport orderExport = orderExports.LastOrDefault();
                if (orderExport != null)
                {
                    string lastId = orderExport.OrderExportID.Remove(0, 3);
                    string orderExportId;
                    if (!string.IsNullOrEmpty(lastId))
                    {
                        int nextId = int.Parse(lastId) + 1;
                        orderExportId = string.Format("XK{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                    }
                    else
                    {
                        orderExportId = string.Format("XK0000{0}", 1);
                    }
                    return orderExportId;
                }
                return string.Format("XK0000{0}", 1);
            }
            return string.Format("XK0000{0}", 1);
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="orderExport"></param>
        public void Update(OrderExport orderExport)
        {
            _context.OrderExports.Attach(orderExport);
            _context.Entry(orderExport).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="orderExportId"></param>
        public void Delete(string orderExportId)
        {
            OrderExport orderExport = GetOrderExportById(orderExportId);
            _context.OrderExports.Remove(orderExport);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}