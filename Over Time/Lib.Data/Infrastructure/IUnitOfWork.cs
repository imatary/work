namespace Lib.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}