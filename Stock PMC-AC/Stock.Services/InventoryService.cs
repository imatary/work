using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class InventoryService
    {
        private readonly StockACEntities _context;

        public InventoryService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách đơn vị
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetInventories()
        {
            var context = new StockACEntities();
            return context.Inventories.ToList();
        }

        public List<Inventory> GetQuantityInventories()
        {
            using (var context=new StockACEntities())
            {
                return context.Inventories.Where(
                        inven => inven.QuantityInventory <= 5 && !string.IsNullOrEmpty(inven.QuantityInventory.ToString())).ToList();
            }
        }

        public List<InventoryView> GetAllInventories()
        {
            var context = new StockACEntities();
            List<InventoryView> inventories = (from inventory in context.Inventories
                join product in context.Products on inventory.ProductID equals product.ProductID
                join productGroup in context.ProductGroups on product.ProductGroupID equals productGroup.ProductGroupID
                //join stock in context.Stocks on product.StockID equals stock.StockID
                join unit in context.Units on product.UnitID equals unit.UnitID
                where inventory.QuantityExport > 0
                select new InventoryView()
                {
                    ProductGroupID = product.ProductGroupID,
                    ProductGroupName = productGroup.ProductGroupName,
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    Price =  (long) product.Price,
                    QuantityFirst =  (int) inventory.QuantityFirst,
                    QuantityImport =  (int) inventory.QuantityImport,
                    QuantityExport = (int) inventory.QuantityExport,
                    QuantityInventory = (int) inventory.QuantityInventory,
                    InventoryDate = inventory.InventoryDate,
                    UnitID = product.UnitID,
                    UnitName = unit.UnitName,
                    StockID = product.StockID,
                }).ToList();
            return inventories;
        }

        //public Inventory GetInventoryById(Guid inventoryId)
        //{
        //    return _context.Inventories.FirstOrDefault(inven => inven.ID == inventoryId);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        private Inventory GetInventoryByProductId(string productId)
        {
            return _context.Inventories.FirstOrDefault(inven => inven.ProductID == productId);
        }

        public bool CheckExits(string inventoryId)
        {
            Inventory inventory = GetInventoryByProductId(inventoryId);
            if (inventory != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra nếu số lượng xuất
        /// mà lớn hơn số lượng nhập vào thì thông báo lỗi
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantityExport"></param>
        /// <returns></returns>
        public bool CheckQuantity(string productId, int quantityExport)
        {
            Inventory inventory = GetInventoryByProductId(productId);
            if (inventory != null)
            {
                if (quantityExport > inventory.QuantityInventory)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        public void Add(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="inventory"></param>
        private void Update(Inventory inventory)
        {
            _context.Inventories.Attach(inventory);
            _context.Entry(inventory).State = EntityState.Modified;
            SaveChanges();
        }


        /// <summary>
        /// Thêm mới hoặc cập nhật vào bảng
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <param name="orderImportId"></param>
        public void InsertOrUpdateInventoryImport(string productId, int quantity, string orderImportId)
        {
            try
            {
                Inventory inventory;
                if (CheckExits(productId))
                {
                    inventory = new Inventory
                    {
                        InventoryDate = DateTime.Now.Date,
                        ProductID = productId,
                        QuantityFirst = 0,
                        OrderImportID = orderImportId,
                        QuantityImport = quantity,
                    };

                    if (string.IsNullOrEmpty(inventory.QuantityExport.ToString()))
                    {
                        inventory.QuantityExport = 0;
                    }

                    Add(inventory);
                }
                else
                {
                    // Update Quantiry
                    inventory = GetInventoryByProductId(productId);
                    if (inventory != null)
                    {
                        if (inventory.QuantityImport > 0)
                        {
                            inventory.QuantityImport += quantity;
                        }
                        else
                        {
                            inventory.QuantityImport = quantity;
                        }

                    }
                    try
                    {
                        Update(inventory);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertOrUpdateInventoryExport(string productId, int quantity, string orderExportId)
        {
            try
            {
                Inventory inventory;
                if (CheckExits(productId))
                {
                    inventory = new Inventory
                    {
                        InventoryDate = DateTime.Now.Date,
                        ProductID = productId,
                        QuantityFirst = 0,
                        OrderImportID = orderExportId,
                        QuantityExport = quantity,
                    };

                    if (string.IsNullOrEmpty(inventory.QuantityImport.ToString()))
                    {
                        inventory.QuantityImport = 0;
                    }

                    Add(inventory);
                }
                else
                {
                    inventory = GetInventoryByProductId(productId);
                    if (inventory != null)
                    {
                        if (inventory.QuantityExport > 0)
                        {
                            inventory.QuantityExport += quantity;
                        }
                        else
                        {
                            inventory.QuantityExport = quantity;
                        }
                        
                    }
                    try
                    {
                        Update(inventory);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveChanges()
        {
            _context.SaveChanges();
        }  
    }
}