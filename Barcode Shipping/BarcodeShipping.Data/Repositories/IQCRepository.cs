using System.Data.Entity;
using System.Linq;

namespace BarcodeShipping.Data.Repositories
{
    public class IqcRepository : IRepository
    {
        private readonly IQCDataEntities _context = new IQCDataEntities();

        public void Dispose()
        {
            _context.Dispose();
        }
        /// <summary>
        /// insert entry
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public bool Insert<T>(T entity) where T : class
        {
            if (entity == null)
            {
                return false;
            }
            _context.Entry(entity).State = EntityState.Added;
            //context.Set<T>().Add(entity);
            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// get entryes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }
        /// <summary>
        /// delete entry
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public bool Delete<T>(T entity) where T : class
        {
            if (entity == null)
                return false;
            _context.Entry(entity).State = EntityState.Deleted;
            //_context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// update entry
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public bool Update<T>(T entity) where T : class
        {
            if (entity == null) 
                return false;
            //_context.Set<T>().Attach(entity);
            _context.Entry(entity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return true;
        }


        //public bool UpdateEvents(CalendarEvent instance)
        //{
        //    var cache = _context.CalendarEvents.FirstOrDefault(o => o.id == instance.id);
        //    if (cache != null)
        //    {
        //        _context.Entry(cache).CurrentValues.SetValues(instance);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
    }
}