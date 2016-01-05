using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;


namespace Stock.Services
{
    public class StockService
    {
        private readonly StockACEntities _context;

        public StockService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách đơn vị
        /// </summary>
        /// <returns></returns>
        public List<Data.Stock> GetStocks()
        {
            var context = new StockACEntities();
            return context.Stocks.ToList();
        }

        //public List<StockView> GetStockViews()
        //{
        //    return _context.Stocks.ToList();
        //}

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="stockId">Stock ID</param>
        /// <returns></returns>
        public Data.Stock GetStockById(string stockId)
        {
            return _context.Stocks.FirstOrDefault(u => u.StockID == stockId);
        }

        /// <summary>
        /// Trả về theo tên
        /// </summary>
        /// <param name="stockName"></param>
        /// <returns></returns>
        public Data.Stock GetStockByName(string stockName)
        {
            return _context.Stocks.FirstOrDefault(u => u.StockName == stockName);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của ID
        /// </summary>
        /// <param name="stockId"></param>
        public bool CheckStockIdExit(string stockId)
        {
            Data.Stock stock = GetStockById(stockId);
            if (stock != null)
            {
                return false;
            }
            return true;
        }

        public bool CheckStockNameExit(string stockName)
        {
            Data.Stock stock = GetStockByName(stockName);
            if (stock != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public void Add(Data.Stock stock)
        {
            _context.Stocks.Add(stock);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="stock"></param>
        public void Update(Data.Stock stock)
        {
            _context.Stocks.Attach(stock);
            _context.Entry(stock).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="unitId"></param>
        public void Delete(string unitId)
        {
            Data.Stock stock = GetStockById(unitId);
            _context.Stocks.Remove(stock);
            SaveChanges();
        }

        /// <summary>
        /// Tạo ID Kế tiếp
        /// </summary>
        /// <returns></returns>
        public string NextId()
        {
            var stocks = GetStocks();
            if (stocks != null)
            {
                Data.Stock stock = stocks.LastOrDefault();
                if (stock != null)
                {
                    string lastId = stock.StockID.Remove(0, 3);
                    string orderImportId;
                    if (!string.IsNullOrEmpty(lastId))
                    {
                        int nextId = int.Parse(lastId) + 1;
                        orderImportId = string.Format("K{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                    }
                    else
                    {
                        orderImportId = string.Format("K0000{0}", 1);
                    }
                    return orderImportId;
                }
                return string.Format("K0000{0}", 1);
            }
            return string.Format("K0000{0}", 1);
        }

        /// <summary>
        /// Trả về tên Kho theo ID
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        public string GetStockNameById(string stockId)
        {
            if (!string.IsNullOrEmpty(stockId))
            {
                Data.Stock stock = GetStockById(stockId);
                if (stock != null)
                {
                    string stockName = stock.StockName;
                    return stockName;
                }
            }

            return "Khác";
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}