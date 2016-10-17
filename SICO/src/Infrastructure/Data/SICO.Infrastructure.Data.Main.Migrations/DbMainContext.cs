using SICO.Infrastructure.Data.Main.Contexts;
using System.Data.Entity;

namespace SICO.Infrastructure.Data.Main.Migrations
{
    public class DbMainContext : MainContext
    {
        static DbMainContext()
        {
            Database.SetInitializer<DbMainContext>(null);
        }        
        public DbMainContext() : base("Server=10.9.4.18;Database=SGCBD_QA;User ID=sa;Password=pasesa;MultipleActiveResultSets=true")
        {

        }       
    }
}
