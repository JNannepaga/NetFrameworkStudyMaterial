using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IdentityOwinIntegrationWithoutEF.SQLAdapter
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity NewEntity { get; }
        void Add(TEntity item);
        void Remove(TEntity item);
        TEntity Get(int Id);
        TEntity Get(string name);
        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}
