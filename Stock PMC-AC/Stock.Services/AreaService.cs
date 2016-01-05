using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class AreaService
    {
        private readonly StockACEntities _context;

        public AreaService()
        {
            _context = new StockACEntities();
        }

        /// <summary>
        /// Trả về danh sách đơn vị
        /// </summary>
        /// <returns></returns>
        public List<Area> GetAreas()
        {
            var context = new StockACEntities();
            return context.Areas.ToList();
        }

        /// <summary>
        /// Trả về theo ID
        /// </summary>
        /// <param name="areaId">Stock ID</param>
        /// <returns></returns>
        public Area GetAreaById(string areaId)
        {
            return _context.Areas.FirstOrDefault(u => u.AreaID == areaId);
        }

        /// <summary>
        /// Trả về theo tên
        /// </summary>
        /// <param name="areaName"></param>
        /// <returns></returns>
        public Area GetAreaByName(string areaName)
        {
            return _context.Areas.FirstOrDefault(u => u.AreaName == areaName);
        }

        /// <summary>
        /// Trả về tên khu vực theo ID
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public string GetAreaNameById(string areaId)
        {
            if (!string.IsNullOrEmpty(areaId))
            {
                var area = _context.Areas.FirstOrDefault(a => a.AreaID == areaId);
                if (area != null)
                {
                    string areaName = area.AreaName;
                    return areaName;
                }
            }

            return "Khác";
        }

        /// <summary>
        /// Tạo ID Kế tiếp
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Tạo ID kế tiếp
        /// </summary>
        /// <returns></returns>
        public string NextId()
        {
            var areas = GetAreas();
            if (areas != null)
            {
                Area area = areas.LastOrDefault();
                if (area != null)
                {
                    string lastId = area.AreaID.Remove(0, 3);
                    string orderImportId;
                    if (!string.IsNullOrEmpty(lastId))
                    {
                        int nextId = int.Parse(lastId) + 1;
                        orderImportId = string.Format("KV{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                    }
                    else
                    {
                        orderImportId = string.Format("KV0000{0}", 1);
                    }
                    return orderImportId;
                }
                return string.Format("KV0000{0}", 1);
            }
            return string.Format("KV0000{0}", 1);
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của ID
        /// </summary>
        /// <param name="areaId"></param>
        public bool CheckAreaIdExit(string areaId)
        {
            Area area = GetAreaById(areaId);
            if (area != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra sự tồn tại của tên Khu vực
        /// </summary>
        /// <param name="areaName"></param>
        /// <returns></returns>
        public bool CheckAreaNameExits(string areaName)
        {
            Area area = GetAreaByName(areaName);
            if (area != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public void Add(Data.Area area)
        {
            _context.Areas.Add(area);
            SaveChanges();
        }

        public bool IsChangeAreaName(string areaName)
        {
            Area area = GetAreaByName(areaName);
            if (area.AreaName == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cập nhật thông tin
        /// </summary>
        /// <param name="area"></param>
        public void Update(Area area)
        {
            _context.Areas.Attach(area);
            _context.Entry(area).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa theo ID
        /// </summary>
        /// <param name="areaid"></param>
        public void Delete(string areaid)
        {
            Area area = GetAreaById(areaid);
            _context.Areas.Remove(area);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }  
    }
}