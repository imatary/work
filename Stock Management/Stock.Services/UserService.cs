using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class UserService
    {
        private readonly StockDataEntities _context;

        public UserService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// Danh sách user
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            var context = new StockDataEntities();

            return context.Users.ToList();

        }


        /// <summary>
        /// Trả về tên đăng nhập theo tên
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.Username == userName);
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
        public void Delete(string userName)
        {
            User user = GetUserByUserName(userName);
            _context.Users.Remove(user);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}