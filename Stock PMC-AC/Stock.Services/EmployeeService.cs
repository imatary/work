using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class EmployeeService
    {
        private readonly StockACEntities _context;

        public EmployeeService()
        {
            _context = new StockACEntities();
        }

        public List<Employee> GetAllEmployees()
        {
            var context = new StockACEntities();
            return context.Employees.Include("Department").ToList();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            var context = new StockACEntities();
            return context.Employees.Include("Department")
                    .Where(em => em.IsManagerStock == false || em.IsManagerStock == null)
                    .ToList();
        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="employeeId">ID</param>
        /// <returns></returns>
        public Employee GetEmployeeById(string employeeId)
        {
            return _context.Employees.FirstOrDefault(u => u.EmployeeID == employeeId);
        }

        /// <summary>
        /// Trả về thông tin theo code
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        public Employee GetEmployeeByCode(string employeeCode)
        {
            return _context.Employees.FirstOrDefault(u => u.EmployeeCode == employeeCode);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của ID
        /// </summary>
        /// <param name="employeeId"></param>
        public bool CheckEmployeeIdExit(string employeeId)
        {
            Employee employee = GetEmployeeById(employeeId);
            if (employee != null)
            {
                return false;
            }
            return true;
        }

        public bool CheckEmployeeCodeExit(string employeeCode)
        {
            Employee employee = GetEmployeeByCode(employeeCode);
            if (employee != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="employee"></param>
        public void Update(Employee employee)
        {
            _context.Employees.Attach(employee);
            _context.Entry(employee).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="employeeId"></param>
        public void Delete(string employeeId)
        {
            Employee employee = GetEmployeeById(employeeId);
            _context.Employees.Remove(employee);
            SaveChanges();
        }

        /// <summary>
        /// Tạo ID kế tiếp
        /// </summary>
        /// <returns></returns>
        public string NextId()
        {
            Employee employee = GetAllEmployees().Last();
            if (employee != null)
            {
                string lastId = employee.EmployeeID.Remove(0, 3);
                string employeesId;
                if (!string.IsNullOrEmpty(lastId))
                {
                    int nextId = int.Parse(lastId) + 1;
                    employeesId = string.Format("NV{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                }
                else
                {
                    employeesId = string.Format("NV0000{0}", 1);
                }
                return employeesId;
            }
            return string.Format("NV0000{0}", 1);
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}