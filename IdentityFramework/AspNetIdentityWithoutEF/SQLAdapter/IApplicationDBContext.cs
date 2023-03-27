using System;

namespace IdentityOwinIntegrationWithoutEF.SQLAdapter
{
    public interface IApplicationDBContext : IDisposable
    {
        IIdentityRepository IdentityRepository { get; }
        void Update<TEntity>(TEntity item);
        void Save();
    }
}
