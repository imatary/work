using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class OrderExportDetailService
    {
        private readonly StockACEntities _context;

        public OrderExportDetailService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<OrderExportDetail> GetOrderExportDetails()
        {
            using (var context=new StockACEntities())
            {
                return context.OrderExportDetails.ToList();
            }
        }


        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="orderExportDetail"></param>
        /// <returns></returns>
        public void Add(OrderExportDetail orderExportDetail)
        {
            _context.OrderExportDetails.Add(orderExportDetail);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="orderExportDetail"></param>
        public void Update(OrderExportDetail orderExportDetail)
        {
            _context.OrderExportDetails.Attach(orderExportDetail);
            _context.Entry(orderExportDetail).State = EntityState.Modified;
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }  
    }
}