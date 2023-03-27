using RepositoryPattern.TargetMultiDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace RepositoryPattern.TargetMultiDB.SqlProviderEF
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly IDbAdapter _dbAdapter;

        public Repository(IDbAdapter dbAdapter)
        {
            _dbAdapter = dbAdapter;
        }

        public TEntity NewEntity => Activator.CreateInstance<TEntity>();

        public void Add(TEntity item)
        {
            (_dbAdapter as EFAdapter).Set<TEntity>().Add(item); 
        }

        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return (_dbAdapter as EFAdapter).Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int Id)
        {
            return (_dbAdapter as EFAdapter).Set<TEntity>().Find(Id);
        }

        public TEntity Get(string name)
        {
            return (_dbAdapter as EFAdapter).Set<TEntity>().Find(name);
        }

        public void Remove(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
