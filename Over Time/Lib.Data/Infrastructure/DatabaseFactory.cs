using Lib.Data;

namespace Lib.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private OverTimeDbContext _dataContext;
        public OverTimeDbContext Get()
        {
            return _dataContext ?? (_dataContext = new OverTimeDbContext());
        }
        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}