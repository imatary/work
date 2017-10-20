using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CartonLabels.App
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private CartonLabelDbContext _context;

        public Repository()
        {
            _context = new CartonLabelDbContext();
        }

        public Repository(CartonLabelDbContext context)
        {
            _context = context;
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public TEntity Read(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public TEntity Read(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var set = _context.Set<TEntity>();
            var entity = set.Find(id);
            set.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(string id)
        {
            var set = _context.Set<TEntity>();
            var entity = set.Find(id);
            set.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> ReadWhere(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public void DeleteWhere(IEnumerable<TEntity> entities)
        {
            var set = _context.Set<TEntity>();
            set.RemoveRange(entities);
            _context.SaveChanges();
        }
    }
}
