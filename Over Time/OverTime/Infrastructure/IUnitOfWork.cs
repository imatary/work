namespace OverTime.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}