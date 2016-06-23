using OverTime.Infrastructure;
using OverTime.Models;

namespace OverTime.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {

    }
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}