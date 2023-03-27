using System;

namespace RepositoryPattern.TargetRepos.Core
{
    public interface IUnitOfWork : IDisposable
        
    {
        //List of Repositories
        //public void Update(TEntity entity);
        public void SaveChanges();
        public void Update<TEntity>(TEntity entity)
           where TEntity : class;
    }
}
