using System.Collections.Generic;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class ManagersService
    {
        private readonly StockACEntities _context;

        public ManagersService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ManagersView> GetManagers()
        {
            //            SELECT        
            //Users.UserName AS Expr1, 
            //Users.EmployeeID AS Expr2, 
            //Departments.DepartmentName, Departments.DepartmentID 
            //AS Expr3, Employees.*
            //FROM Departments 
            //INNER JOIN Employees ON Departments.DepartmentID = Employees.DepartmentID 
            //INNER JOIN Users ON Employees.EmployeeID = Users.EmployeeID
            //WHERE Employees.IsManagerStock=1
            
            //var inventories = (from inventory in context.Inventories
            //                       join product in context.Products on inventory.ProductID equals product.ProductID
            //                       join productGroup in context.ProductGroups on product.ProductGroupID equals productGroup.ProductGroupID
            //                       //join stock in context.Stocks on product.StockID equals stock.StockID
            //                       join unit in context.Units on product.UnitID equals unit.UnitID
            //        where product.StockID == stockId


            using (var context=new StockACEntities())
            {
                var managers = (from department in context.Departments
                                join employee in context.Employees on department.DepartmentID equals employee.DepartmentID
                                join user in context.Users on employee.EmployeeID equals user.EmployeeID
                                where employee.IsManagerStock == true
                                select new ManagersView()
                                {
                                    DepartmentName = department.DepartmentName,
                                    UserName = user.UserName,
                                    EmployeeCode = employee.EmployeeCode,
                                    EmployeeID = employee.EmployeeID,
                                    EmployeeName = employee.EmployeeName,
                                    Alias = employee.Alias,
                                    Sex = employee.Sex,
                                    Address = employee.Address,
                                    HomeTell = employee.HomeTell,
                                    Mobile = employee.Mobile,
                                    Fax = employee.Fax,
                                    Email = employee.Email,
                                    Birthday = employee.Birthday

                                }).ToList();

                return managers;
            }    
        }

        public List<ManagersView> GetEmployeeManagers()
        {
            //            SELECT        
            //Users.UserName AS Expr1, 
            //Users.EmployeeID AS Expr2, 
            //Departments.DepartmentName, Departments.DepartmentID 
            //AS Expr3, Employees.*
            //FROM Departments 
            //INNER JOIN Employees ON Departments.DepartmentID = Employees.DepartmentID 
            //INNER JOIN Users ON Employees.EmployeeID = Users.EmployeeID
            //WHERE Employees.IsManagerStock=1

            //var inventories = (from inventory in context.Inventories
            //                       join product in context.Products on inventory.ProductID equals product.ProductID
            //                       join productGroup in context.ProductGroups on product.ProductGroupID equals productGroup.ProductGroupID
            //                       //join stock in context.Stocks on product.StockID equals stock.StockID
            //                       join unit in context.Units on product.UnitID equals unit.UnitID
            //        where product.StockID == stockId


            using (var context = new StockACEntities())
            {
                var managers = (from department in context.Departments
                                join employee in context.Employees on department.DepartmentID equals employee.DepartmentID
                                where employee.IsManagerStock == true
                                select new ManagersView()
                                {   EmployeeCode = employee.EmployeeCode,
                                    EmployeeID = employee.EmployeeID,
                                    EmployeeName = employee.EmployeeName,
                                    Email = employee.Email,
                                }).ToList();

                return managers;
            }
        }
    }
}