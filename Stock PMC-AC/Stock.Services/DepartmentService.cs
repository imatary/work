using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class DepartmentService
    {
        private readonly StockACEntities _context;

        public DepartmentService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartments()
        {
            var context = new StockACEntities();
            return context.Departments.ToList();
        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="departmentId">ID</param>
        /// <returns></returns>
        public Department GetDepartmentById(string departmentId)
        {
            return _context.Departments.FirstOrDefault(u => u.DepartmentID == departmentId);
        }

        /// <summary>
        /// Trả về theo Tên
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public Department GetDepartmentName(string departmentName)
        {
            return _context.Departments.FirstOrDefault(u => u.DepartmentName == departmentName);
        }


        /// <summary>
        /// Trả về tên khu vực theo ID
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public string GetDepartmentNameById(string departmentId)
        {
            if (!string.IsNullOrEmpty(departmentId))
            {
                Department department = GetDepartmentById(departmentId);
                if (department != null)
                {
                    string departmentName = department.DepartmentName;
                    return departmentName;
                }
            }

            return "Khác";
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của ID
        /// </summary>
        /// <param name="departmentId"></param>
        public bool CheckDepartmentIdExit(string departmentId)
        {
            Department department = GetDepartmentById(departmentId);
            if (department != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của tên bộ phận
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public bool CheckDepartmentNameExits(string departmentName)
        {
            Department department = GetDepartmentName(departmentName);
            if (department != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public void Add(Department department)
        {
            _context.Departments.Add(department);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="department"></param>
        public void Update(Department department)
        {
            _context.Departments.Attach(department);
            _context.Entry(department).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="departmentId"></param>
        public void Delete(string departmentId)
        {
            Department department = GetDepartmentById(departmentId);
            _context.Departments.Remove(department);
            SaveChanges();
        }

        public string NextId()
        {
            var departments = GetDepartments();
            if (departments != null)
            {
                Department department = departments.LastOrDefault();
                if (department != null)
                {
                    string lastId = department.DepartmentID.Remove(0, 3);
                    string orderImportId;
                    if (!string.IsNullOrEmpty(lastId))
                    {
                        int nextId = int.Parse(lastId) + 1;
                        orderImportId = string.Format("BP{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                    }
                    else
                    {
                        orderImportId = string.Format("BP0000{0}", 1);
                    }
                    return orderImportId;
                }
                return string.Format("BP0000{0}", 1);
            }
            return string.Format("BP0000{0}", 1);
        }


        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}