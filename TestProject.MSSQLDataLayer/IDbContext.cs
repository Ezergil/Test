using System;
using System.Data.Entity;
using System.Threading.Tasks;
using TestProject.Abstraction;

namespace TestProject.MSSQLDataLayer
{
    public interface IDbContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity;
        Task<int> CommitAsync();
    }
}