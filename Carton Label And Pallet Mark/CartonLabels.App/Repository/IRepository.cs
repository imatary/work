using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonLabels.App
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity Read(int id);
        TEntity Read(string id);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(string id);

        IEnumerable<TEntity> ReadWhere(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> ReadAll();
    }

}

