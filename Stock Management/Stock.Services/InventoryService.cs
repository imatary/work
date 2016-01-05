using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class InventoryService
    {
        private readonly StockDataEntities _context;

        public InventoryService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// Trả về danh sách đơn vị
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetInventories()
        {
            var context = new StockDataEntities();

            return context.Inventories.ToList();


        }

        public List<Inventory> GetQuantityInventories()
        {
            var context = new StockDataEntities();
            return context.Inventories.Where(inven => inven.InventoryLast <= 5 && !string.IsNullOrEmpty(inven.InventoryLast.ToString())).ToList();
            
        }

        public List<InventoryView> GetAllInventories()
        {
            var context = new StockDataEntities();
            List<InventoryView> inventories = (from inventory in context.Inventories
                join product in context.Products on inventory.ProductID equals product.ProductID
                join productGroup in context.ProductGroups on product.ProductGroupID equals productGroup.ProductGroupID
                //join stock in context.Stocks on product.StockID equals stock.StockID
                join unit in context.Units on product.UnitID equals unit.UnitID
                where inventory.TotalOut > 0
                select new InventoryView()
                {
                    ProductGroupID = product.ProductGroupID,
                    ProductGroupName = productGroup.ProductGroupName,
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    Price =  (long) product.Price,
                    QuantityFirst =  (int) inventory.InventoryFirt,
                    QuantityImport =  (int) inventory.TotalIn,
                    QuantityExport = (int) inventory.TotalOut,
                    QuantityInventory = (int) inventory.InventoryLast,
                    InventoryDate = inventory.InventoryDate,
                    UnitID = product.UnitID,
                    UnitName = unit.UnitName,
                    StockID = product.StockID,
                }).ToList();
            return inventories;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ReportTotalView> GetReportTotals()
        {
            var context = new StockDataEntities();
            var reportTotals = (from inventory in context.Inventories

                join product in context.Products on inventory.ProductID equals product.ProductID

                //join stock in context.Stocks on product.StockID equals stock.StockName

                join unit in context.Units on product.UnitID equals unit.UnitID

                //join productGroup in context.ProductGroups on product.ProductGroupID equals productGroup.ProductGroupID
                select new ReportTotalView()
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    SPQ = unit.UnitName,
                    Price = (float) product.Price,
                    Inventory = (int) inventory.InventoryFirt,
                    Plan = (int) (inventory.Plan==null ? inventory.Plan : 0),
                    TotalIn = (int) inventory.TotalIn,
                    TotalOut = (int) inventory.TotalOut,
                    InventoryLast = (int) inventory.InventoryLast,
                    InventoryPrice = (float) product.Price,
                    InventoryDate = inventory.InventoryDate,
                    SearchByDate = inventory.Date,
                    
                }).ToList();

            return reportTotals;
        } 

        //public Inventory GetInventoryById(Guid inventoryId)
        //{
        //    return _context.Inventories.FirstOrDefault(inven => inven.ID == inventoryId);
        //}

        public List<ReportByDepartment> GetReportsByDepartments()
        {
            var context = new StockDataEntities();
            var reportsByDepartments = (from issueDetails in context.IssueDetails
                join product in context.Products on issueDetails.ProductID equals product.ProductID
                join unit in context.Units on product.UnitID equals unit.UnitID
                join department in context.Departments on issueDetails.DepartmentID equals department.DepartmentID
            
            
                select new ReportByDepartment()
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    SPQ = unit.UnitName,
                    Price = (float) product.Price,
                    DepartmentID = department.DepartmentName,


                }).ToList();
            return reportsByDepartments;
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Inventory GetInventoryByProductId(string productId)
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
        /// <param name="totalOut"></param>
        /// <returns></returns>
        public bool CheckQuantity(string productId, int totalOut)
        {
            Inventory inventory = GetInventoryByProductId(productId);
            if (inventory != null)
            {
                if (totalOut > inventory.InventoryLast)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventory"></param>
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
        /// <param name="receiptId"></param>
        public void InsertOrUpdateReceipt(string productId, int quantity, string receiptId, int plan)
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
                        InventoryFirt = 0,
                        ReceiptID = receiptId,
                        TotalIn = quantity,
                        Plan = plan,
                    };

                    if (string.IsNullOrEmpty(inventory.TotalOut.ToString()))
                    {
                        inventory.TotalOut = 0;
                    }

                    Add(inventory);
                }
                else
                {
                    // Update Quantiry
                    inventory = GetInventoryByProductId(productId);
                    
                    if (inventory != null)
                    {
                        inventory.ReceiptID = receiptId;
                        if (inventory.TotalIn > 0)
                        {
                            inventory.TotalIn += quantity;
                        }
                        else
                        {
                            inventory.TotalIn = quantity;
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

        public void InsertOrUpdateIssue(string productId, int quantity, string issueId)
        {
            try
            {
                Inventory inventory;
                if (CheckExits(productId))
                {
                    inventory = new Inventory
                    {
                        Date = DateTime.Now.Date.ToString("MM-yyyy"),
                        InventoryDate = DateTime.Now.Date,
                        ProductID = productId,
                        InventoryFirt = 0,
                        IssueID = issueId,
                        TotalOut = quantity,
                        Plan = 0,
                    };

                    if (string.IsNullOrEmpty(inventory.TotalIn.ToString()))
                    {
                        inventory.TotalIn = 0;
                    }

                    Add(inventory);
                }
                else
                {
                    inventory = GetInventoryByProductId(productId);
                    if (inventory != null)
                    {
                        if (inventory.TotalOut > 0)
                        {
                            inventory.TotalOut += quantity;
                        }
                        else
                        {
                            inventory.TotalOut = quantity;
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