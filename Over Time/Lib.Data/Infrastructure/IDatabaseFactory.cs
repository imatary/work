using System;

namespace Lib.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        OverTimeDbContext Get();
    }
}