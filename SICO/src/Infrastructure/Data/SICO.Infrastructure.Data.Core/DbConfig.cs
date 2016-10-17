using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace SICO.Infrastructure.Data.Core
{
    public class DbConfig: DbConfiguration
    {
        public DbConfig()
        {
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }
}
