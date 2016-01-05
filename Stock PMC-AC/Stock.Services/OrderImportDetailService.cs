using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class OrderImportDetailService
    {
        private readonly StockACEntities _context;

        public OrderImportDetailService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<OrderImportDetail> GetOrderImportDetails()
        {
            using (var context=new StockACEntities())
            {
                return context.OrderImportDetails.ToList();
            }
        }


        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="orderImportDetail"></param>
        /// <returns></returns>
        public void Add(OrderImportDetail orderImportDetail)
        {
            _context.OrderImportDetails.Add(orderImportDetail);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="orderImportDetail"></param>
        public void Update(OrderImportDetail orderImportDetail)
        {
            _context.OrderImportDetails.Attach(orderImportDetail);
            _context.Entry(orderImportDetail).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Tổng số lượng theo ID của sản phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public int SumQuantity(string productId)
        {
            var inventories = GetOrderImportDetails().Where(inven => inven.ProductID == productId);

            var sum = inventories.Sum(inven => inven.Quantity);
            if (sum != null)
            {
                return (int) sum;
            }  
            return 0;
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}