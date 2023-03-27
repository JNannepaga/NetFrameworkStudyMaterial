using RepositoryPattern.TargetRepos.Core;
using System.Data.Entity;

namespace RepositoryPattern.TargetRepos.SqlProviderEF
{
    public class ApplicationDbContext : IUnitOfWork
    {
        protected readonly IDbAdapter _dbAdapter;
        public ApplicationDbContext(IDbAdapter dbAdapter)
        {
            _dbAdapter = dbAdapter;
        }

        public void Dispose()
        {
            _dbAdapter.Dispose();
        }

        public void SaveChanges()
        {
            (_dbAdapter as EFAdapter).SaveChanges();
        }

        public void Update<TEntity>(TEntity entity)
            where TEntity : class
        {
            (_dbAdapter as EFAdapter).Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
