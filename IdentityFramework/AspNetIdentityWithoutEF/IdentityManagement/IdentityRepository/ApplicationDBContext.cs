using IdentityOwinIntegrationWithoutEF.SQLAdapter;
using System;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class ApplicationDBContext : IApplicationDBContext
    {
        private readonly SqlAdapterEF _sqlAdapter;
        public ApplicationDBContext()
        {
            _sqlAdapter = new SqlAdapterEF(AppConfigKeys.IdentityManagement);
            IdentityRepository = new IdentityRepository(_sqlAdapter);
        }

        public IIdentityRepository IdentityRepository { get; private set; }

        public void Dispose()
        {
            _sqlAdapter.Dispose();
        }

        public void Save()
        {
            _sqlAdapter.SaveChanges();
        }

        public void Update<TEntity>(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}