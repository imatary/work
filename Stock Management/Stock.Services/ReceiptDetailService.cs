using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class ReceiptDetailService
    {
        private readonly StockDataEntities _context;

        public ReceiptDetailService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<ReceiptDetail> GetReceiptDetails()
        {
            var context = new StockDataEntities();

            return context.ReceiptDetails.ToList();

        }


        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="receiptDetail"></param>
        /// <returns></returns>
        public void Add(ReceiptDetail receiptDetail)
        {
            _context.ReceiptDetails.Add(receiptDetail);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="receiptDetail"></param>
        public void Update(ReceiptDetail receiptDetail)
        {
            _context.ReceiptDetails.Attach(receiptDetail);
            _context.Entry(receiptDetail).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Tổng số lượng theo ID của sản phẩm
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public int SumQuantity(string productId)
        {
            var inventories = GetReceiptDetails().Where(inven => inven.ProductID == productId);

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