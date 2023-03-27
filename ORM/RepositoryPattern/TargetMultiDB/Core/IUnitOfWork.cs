using System;

namespace RepositoryPattern.TargetMultiDB.Core
{
    public interface IUnitOfWork<TRepository, TEntity> : IDisposable
        where TRepository : IRepository<TEntity>
        where TEntity : class
    {
        public TRepository Repository { get; }
        public void Update(TEntity entity);
        public void SaveChanges();
    }
}
