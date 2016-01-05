using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class OrderImportService
    {
        private readonly StockACEntities _context;

        public OrderImportService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<OrderImport> GetOrderImports()
        {
            using (var context=new StockACEntities())
            {
                return context.OrderImports.ToList();
            }
        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="orderImportId">ID</param>
        /// <returns></returns>
        public OrderImport GetOrderImportById(string orderImportId)
        {
            return _context.OrderImports.FirstOrDefault(u => u.OrderImportID == orderImportId);
        }

        public bool CheckOrderImportIdExit(string orderImportId)
        {
            OrderImport orderImport = GetOrderImportById(orderImportId);
            if (orderImport != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="orderImport"></param>
        /// <returns></returns>
        public void Add(OrderImport orderImport)
        {
            _context.OrderImports.Add(orderImport);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="orderImport"></param>
        public void Update(OrderImport orderImport)
        {
            _context.OrderImports.Attach(orderImport);
            _context.Entry(orderImport).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="orderImportId"></param>
        public void Delete(string orderImportId)
        {
            OrderImport orderImport = GetOrderImportById(orderImportId);
            _context.OrderImports.Remove(orderImport);
            SaveChanges();
        }

        /// <summary>
        /// Tạo ID kế tiếp
        /// </summary>
        /// <returns></returns>
        public string NextId()
        {
            var orderImports = GetOrderImports();
            if (orderImports != null)
            {
                OrderImport orderImport = orderImports.LastOrDefault();
                if (orderImport != null)
                {
                    string lastId = orderImport.OrderImportID.Remove(0, 3);
                    string orderImportId;
                    if (!string.IsNullOrEmpty(lastId))
                    {
                        int nextId = int.Parse(lastId) + 1;
                        orderImportId = string.Format("HD{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                    }
                    else
                    {
                        orderImportId = string.Format("HD0000{0}", 1);
                    }
                    return orderImportId;
                }
                return string.Format("HD0000{0}", 1);
            }
            return string.Format("HD0000{0}", 1);
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}