using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Stock.Data;

namespace Stock.Services
{
    public class ItemService
    {
        private readonly StockDataEntities _context;

        public ItemService()
        {
            _context = new StockDataEntities();
        }

        /// <summary>
        /// Danh sách item theo user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<Item> GetItemsByUserName(string userName)
        {
            var context = new StockDataEntities();

            var items = from item in context.Items
                where item.Users.Any(u => u.Username == userName)
                select item;

            return items.ToList();


        } 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Item GetItemById(string itemId)
        {
            return _context.Items.FirstOrDefault(p => p.ItemID == itemId);
        }

        /// <summary>
        /// Thêm
        /// </summary>
        /// <param name="item"></param>
        public void Add(Item item)
        {
            _context.Items.Add(item);
            SaveChanges();
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="item"></param>
        public void Update(Item item)
        {
            _context.Items.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Xóa 
        /// </summary>
        /// <param name="itemId"></param>
        public void Delete(string itemId)
        {
            Item item = GetItemById(itemId);
            _context.Items.Remove(item);
            SaveChanges();
        }


        public bool CheckItemIdExit(string itemId)
        {
            Item item = GetItemById(itemId);
            if (item != null)
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
