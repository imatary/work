using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class ProductService
    {
        private readonly StockACEntities _context;

        public ProductService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            var context = new StockACEntities();
            return context.Products.ToList();
        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="productId">ID</param>
        /// <returns></returns>
        public Product GetProductById(string productId)
        {
            return _context.Products.FirstOrDefault(u => u.ProductID == productId);
        }

        /// <summary>
        /// Trả về theo tên của sản phẩm
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public Product GetProductByName(string productName)
        {
            return _context.Products.FirstOrDefault(u => u.ProductName == productName);
        }

        /// <summary>
        /// Trả về theo barcode
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public Product GetProductByBarcode(string barcode)
        {
            return _context.Products.FirstOrDefault(u => u.Barcode == barcode);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của ID
        /// </summary>
        /// <param name="productId"></param>
        public bool CheckProductIdExit(string productId)
        {
            Product product = GetProductById(productId);
            if (product != null)
            {
                return false;
            }
            return true;
        }

        public bool CheckProductNameExit(string productName)
        {
            Product product = GetProductByName(productName);
            if (product != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của barcode
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public bool CheckProductBarcodeExit(string barcode)
        {
            Product product = GetProductByBarcode(barcode);
            if (product != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public void Add(Product product)
        {
            _context.Products.Add(product);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="product"></param>
        public void Update(Product product)
        {
            _context.Products.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="product"></param>
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            SaveChanges();
        }

        /// <summary>
        /// Tạo ID kế tiếp
        /// </summary>
        /// <returns></returns>
        public string NextId()
        {
            var products = GetProducts();
            if (products != null)
            {
                Product product = products.LastOrDefault();
                if (product != null)
                {
                    string lastId = product.ProductID.Remove(0, 3);
                    string orderImportId;
                    if (!string.IsNullOrEmpty(lastId))
                    {
                        int nextId = int.Parse(lastId) + 1;
                        orderImportId = string.Format("SP{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                    }
                    else
                    {
                        orderImportId = string.Format("SP0000{0}", 1);
                    }
                    return orderImportId;
                }
                return string.Format("SP0000{0}", 1);
            }
            return string.Format("SP0000{0}", 1);
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }  
    }
}