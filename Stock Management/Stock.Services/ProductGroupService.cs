using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class ProductGroupService
    {
        private readonly StockDataEntities _context;

        public ProductGroupService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<ProductGroup> GetProductGroups()
        {
            var context = new StockDataEntities();

            return context.ProductGroups.ToList();


        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="productGroupId">ID</param>
        /// <returns></returns>
        public ProductGroup GetProductGrouprById(string productGroupId)
        {
            return _context.ProductGroups.FirstOrDefault(u => u.ProductGroupID == productGroupId);
        }

        /// <summary>
        /// Trả về theo tên nhóm hàng
        /// </summary>
        /// <param name="productGroupName"></param>
        /// <returns></returns>
        public ProductGroup GetProductGroupByName(string productGroupName)
        {
            return _context.ProductGroups.FirstOrDefault(u => u.ProductGroupName == productGroupName);
        }

        /// <summary>
        /// Trả về tên theo ID
        /// </summary>
        /// <param name="productGroupId"></param>
        /// <returns></returns>
        public string GetProductGroupNameById(string productGroupId)
        {
            if (!string.IsNullOrEmpty(productGroupId))
            {
                ProductGroup productGroup = GetProductGrouprById(productGroupId);
                if (productGroup != null)
                {
                    string productGroupName = productGroup.ProductGroupName;
                    return productGroupName;
                }
            }

            return "Khác";
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của ID
        /// </summary>
        /// <param name="productGroupId"></param>
        public bool CheckProductGroupIdExit(string productGroupId)
        {
            ProductGroup productGroup = GetProductGrouprById(productGroupId);
            if (productGroup != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm sự tồn tại của nhóm hàng
        /// </summary>
        /// <param name="productGroupName"></param>
        /// <returns></returns>
        public bool CheckProductGroupNameExit(string productGroupName)
        {
            ProductGroup productGroup = GetProductGroupByName(productGroupName);
            if (productGroup != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="productGroup"></param>
        /// <returns></returns>
        public void Add(ProductGroup productGroup)
        {
            _context.ProductGroups.Add(productGroup);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="productGroup"></param>
        public void Update(ProductGroup productGroup)
        {
            _context.ProductGroups.Attach(productGroup);
            _context.Entry(productGroup).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="productGroupId"></param>
        public void Delete(string productGroupId)
        {
            ProductGroup productGroup = GetProductGrouprById(productGroupId);
            _context.ProductGroups.Remove(productGroup);
            SaveChanges();
        }

        /// <summary>
        /// Tạo ID kế tiếp
        /// </summary>
        /// <returns></returns>
        public string NextId()
        {
            var productGroups = GetProductGroups();
            if (productGroups != null)
            {
                ProductGroup productGroup = productGroups.LastOrDefault();
                if (productGroup != null)
                {
                    string lastId = productGroup.ProductGroupID.Remove(0, 3);
                    string productGroupId;
                    if (!string.IsNullOrEmpty(lastId))
                    {
                        int nextId = int.Parse(lastId) + 1;
                        productGroupId = string.Format("NH{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                    }
                    else
                    {
                        productGroupId = string.Format("NH0000{0}", 1);
                    }
                    return productGroupId;
                }
                return string.Format("NH0000{0}", 1);
            }
            return string.Format("NH0000{0}", 1);
        }
        private void SaveChanges()
        {
            _context.SaveChanges();
        }  
    }
}