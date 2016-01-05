using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class PageService
    {
        private readonly StockDataEntities _context;

        public PageService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns></returns>
        public Page GetPageById(string pageId)
        {
            return _context.Pages.FirstOrDefault(p => p.PageID == pageId);
        }

        /// <summary>
        /// Thêm
        /// </summary>
        /// <param name="page"></param>
        public void Add(Page page)
        {
            _context.Pages.Add(page);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="page"></param>
        public void Update(Page page)
        {
            _context.Pages.Attach(page);
            _context.Entry(page).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa 
        /// </summary>
        /// <param name="pageId"></param>
        public void Delete(string pageId)
        {
            Page page = GetPageById(pageId);
            _context.Pages.Remove(page);
            SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns></returns>
        public bool CheckPageIdExit(string pageId)
        {
            Page page = GetPageById(pageId);
            if (page != null)
            {
                return false;
            }
            return true;
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}