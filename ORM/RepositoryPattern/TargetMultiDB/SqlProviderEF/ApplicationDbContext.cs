using RepositoryPattern.TargetMultiDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.TargetMultiDB.SqlProviderEF
{
    public abstract class ApplicationDbContext
    {
        private readonly IDbAdapter _dbAdapter;

        public ApplicationDbContext(IDbAdapter dbAdapter)
        {

        }
    }
}
