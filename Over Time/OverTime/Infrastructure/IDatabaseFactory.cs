using System;
using OverTime.Models;

namespace OverTime.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        ApplicationDbContext Get();
    }
}