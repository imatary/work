using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class ColorService
    {
        private readonly StockACEntities _context;

        public ColorService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách
        /// </summary>
        /// <returns></returns>
        public List<Color> GetColors()
        {
            var context = new StockACEntities();
            return context.Colors.ToList();
        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="colorId">ID</param>
        /// <returns></returns>
        public Color GetColorById(int colorId)
        {
            return _context.Colors.FirstOrDefault(u => u.ColorID == colorId);
        }

        /// <summary>
        /// Trả về thông tin theo tên
        /// </summary>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public Color GetColorByName(string colorName)
        {
            return _context.Colors.FirstOrDefault(u => u.ColorName == colorName);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của tên
        /// </summary>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public bool CheckUnitNameExit(string colorName)
        {
            Color color = GetColorByName(colorName);
            if (color != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public void Add(Color color)
        {
            _context.Colors.Add(color);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="color"></param>
        public void Update(Color color)
        {
            _context.Colors.Attach(color);
            _context.Entry(color).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="color"></param>
        public void Delete(Color color)
        {
            _context.Colors.Remove(color);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        } 
    }
}