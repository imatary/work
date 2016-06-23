using OverTime.Infrastructure;
using OverTime.Models;

namespace OverTime.Repositories
{
    public interface IEmployeesRepositoty : IRepository<Employess>
    {
        
    }
    public class EmployeesRepository : RepositoryBase<Employess>, IEmployeesRepositoty
    {
        public EmployeesRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}