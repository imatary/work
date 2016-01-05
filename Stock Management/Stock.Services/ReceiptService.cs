using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class ReceiptService
    {
         private readonly StockDataEntities _context;

         public ReceiptService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<Receipt> GetReceipts()
        {
            var context = new StockDataEntities();

                return context.Receipts.ToList();

        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="receiptId">ID</param>
        /// <returns></returns>
        public Receipt GetReceiptById(string receiptId)
        {
            return _context.Receipts.FirstOrDefault(u => u.ReceiptID == receiptId);
        }

        public bool CheckReceiptIdExit(string receiptId)
        {
            Receipt receipt = GetReceiptById(receiptId);
            if (receipt != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        public void Add(Receipt receipt)
        {
            _context.Receipts.Add(receipt);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="receipt"></param>
        public void Update(Receipt receipt)
        {
            _context.Receipts.Attach(receipt);
            _context.Entry(receipt).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="receiptId"></param>
        public void Delete(string receiptId)
        {
            Receipt receipt = GetReceiptById(receiptId);
            _context.Receipts.Remove(receipt);
            SaveChanges();
        }

        /// <summary>
        /// Tạo ID kế tiếp
        /// </summary>
        /// <returns></returns>
        public string NextId()
        {
            var receipts = GetReceipts();
            if (receipts != null)
            {
                Receipt receipt = receipts.LastOrDefault();
                if (receipt != null)
                {
                    string lastId = receipt.ReceiptID.Remove(0, 3);
                    string receiptId;
                    if (!string.IsNullOrEmpty(lastId))
                    {
                        int nextId = int.Parse(lastId) + 1;
                        receiptId = string.Format("HD{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                    }
                    else
                    {
                        receiptId = string.Format("HD0000{0}", 1);
                    }
                    return receiptId;
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