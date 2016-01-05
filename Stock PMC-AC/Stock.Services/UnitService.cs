using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class UnitService
    {
        private readonly StockACEntities _context;

        public UnitService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách đơn vị
        /// </summary>
        /// <returns></returns>
        public List<Unit> GetUnits()
        {
            //using (var context=new StockACEntities())
            //{
            var context = new StockACEntities();
                return context.Units.ToList();
            //}    
        }

        /// <summary>
        /// Trả về đơn vị theo ID
        /// </summary>
        /// <param name="unitId">Unit ID</param>
        /// <returns></returns>
        public Unit GetUnitById(string unitId)
        {
            return _context.Units.FirstOrDefault(u => u.UnitID == unitId);
        }

        /// <summary>
        /// Trả về theo tên
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public Unit GetUnitByName(string unitName)
        {
            return _context.Units.FirstOrDefault(u => u.UnitName == unitName);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của ID
        /// </summary>
        /// <param name="unitId"></param>
        public bool CheckUnitIdExit(string unitId)
        {
            Unit unit = GetUnitById(unitId);
            if (unit != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của tên đơn vị
        /// </summary>
        /// <param name="unitName"></param>
        /// <returns></returns>
        public bool CheckUnitNameExit(string unitName)
        {
            Unit unit = GetUnitByName(unitName);
            if (unit != null)
            {
                return false;
            }
            return true;
        }

        public string GetUnitNameById(string unitId)
        {
            if (!string.IsNullOrEmpty(unitId))
            {
                Unit unit = GetUnitById(unitId);
                if (unit != null)
                {
                    string unitName = unit.UnitName;
                    return unitName;
                }
            }

            return "Khác";
        }

        /// <summary>
        /// Thêm mới đơn vị
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public void Add(Unit unit)
        {
            _context.Units.Add(unit);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật thông tin đơn vị
        /// </summary>
        /// <param name="unit"></param>
        public void Update(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa Unit theo ID
        /// </summary>
        /// <param name="unitId"></param>
        public void Delete(string unitId)
        {
            Unit unit = GetUnitById(unitId);
            _context.Units.Remove(unit);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}