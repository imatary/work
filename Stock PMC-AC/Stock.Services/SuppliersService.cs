using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class SuppliersService
    {
        private readonly StockACEntities _context;

        public SuppliersService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<Supplier> GetSuppliers()
        {
            var context = new StockACEntities();
            return context.Suppliers.Include("Area").ToList();
        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="supplierId">ID</param>
        /// <returns></returns>
        public Supplier GetSupplierById(string supplierId)
        {
            return _context.Suppliers.FirstOrDefault(u => u.SupplierID == supplierId);
        }

        /// <summary>
        /// Trả về theo tên
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public Supplier GetSupplierByName(string supplierName)
        {
            return _context.Suppliers.FirstOrDefault(u => u.SupplierName == supplierName);
        }

        /// <summary>
        /// Tạo ID Kế tiếp
        /// </summary>
        /// <returns></returns>
        public string NextId()
        {
            Supplier suppliers = GetSuppliers().Last();
            if (suppliers != null)
            {
                string lastId = suppliers.SupplierID.Remove(0, 3);
                string suppliersId;
                if (!string.IsNullOrEmpty(lastId))
                {
                    int nextId = int.Parse(lastId) + 1;
                    suppliersId = string.Format("NCC{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                }
                else
                {
                    suppliersId = string.Format("NCC0000{0}", 1);
                }
                return suppliersId;
            }
            return string.Format("NCC0000{0}", 1);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của ID
        /// </summary>
        /// <param name="supplierId"></param>
        public bool CheckSupplierIdExit(string supplierId)
        {
            Supplier supplier = GetSupplierById(supplierId);
            if (supplier != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của tên Nhà cung cấp
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public bool CheckSupplierNameExit(string supplierName)
        {
            Supplier supplier = GetSupplierByName(supplierName);
            if (supplier != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Trả về tên theo ID
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        public string GetSupplierNameById(string supplierId)
        {
            if (!string.IsNullOrEmpty(supplierId))
            {
                Supplier supplier = GetSupplierById(supplierId);
                if (supplier != null)
                {
                    string supplierName = supplier.SupplierName;
                    return supplierName;
                }
            }

            return "Khác";
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public void Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="supplier"></param>
        public void Update(Supplier supplier)
        {
            _context.Suppliers.Attach(supplier);
            _context.Entry(supplier).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="supplierId"></param>
        public void Delete(string supplierId)
        {
            Supplier supplier = GetSupplierById(supplierId);
            _context.Suppliers.Remove(supplier);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}