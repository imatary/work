using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class UserService
    {
        private readonly StockACEntities _context;

        public UserService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Danh sách user
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            using (var context = new StockACEntities())
            {
                //List<User> users = context.Users.Include("Employee")
                //    .Select(u => new {
                //        u.Employee.EmployeeName,
                //        u.LastLogin
                //    }).ToList();

                return context.Users.ToList();
            }
        }

        /// <summary>
        /// Trả về thông tin user theo ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUserById(int userId)
        {
            using (var context = new StockACEntities())
            {
                //List<User> users = context.Users.Include("Employee")
                //    .Select(u => new {
                //        u.Employee.EmployeeName,
                //        u.LastLogin
                //    }).ToList();

                return context.Users.FirstOrDefault(u => u.UserID == userId);
            }
            //return _context.Users.FirstOrDefault(u => u.UserID == userId);
        }

        /// <summary>
        /// Trả về user theo employeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public User GetUserByEmployeeId(string employeeId)
        {
            return _context.Users.FirstOrDefault(u => u.EmployeeID == employeeId);
        }

        /// <summary>
        /// Trả về tên đăng nhập theo tên
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);
        }


        /// <summary>
        /// Kiểm tra password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckPassword(string userName, string password)
        {
            User user = GetUserByUserName(userName);
            if (user != null)
            {
                if (password != user.Password)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của tên đăng nhập
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckUserNameExit(string userName)
        {
            User user = GetUserByUserName(userName);
            if (user != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới đơn vị
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void Add(User user)
        {
            _context.Users.Add(user);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin đơn vị
        /// </summary>
        /// <param name="user"></param>
        public void Update(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa 
        /// </summary>
        /// <param name="userName"></param>
        //public void Delete(string userName)
        //{
        //    User user = GetUserByUserName(userName);
        //    _context.Users.Remove(userName);
        //    SaveChanges();
        //}

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}