using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryPattern.TargetMultiDB.Core
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        public TEntity NewEntity { get; }
        public void Add(TEntity item);
        public void Update(TEntity item);
        public void Remove(TEntity item);
        public TEntity Get(int Id);
        public TEntity Get(string name);
        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}
