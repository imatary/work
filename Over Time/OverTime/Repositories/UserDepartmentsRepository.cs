using OverTime.Infrastructure;
using OverTime.Models;

namespace OverTime.Repositories
{
    public interface IUserDepartmentsRepository:IRepository<UserDepartments>
    {

    }
    public class UserDepartmentsRepository : RepositoryBase<UserDepartments>, IUserDepartmentsRepository
    {
        public UserDepartmentsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}