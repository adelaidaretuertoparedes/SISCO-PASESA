using System.Data.Entity;
using SICO.Infrastructure.Data.Core;
using SICO.Infrastructure.Data.Main.Configurations;

namespace SICO.Infrastructure.Data.Main.Contexts
{
    public class MainContext : DataContext
    {        
        public MainContext(string nameOrConnectionString):base(nameOrConnectionString)
        {

        }       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ParameterConfiguration());
            modelBuilder.Configurations.Add(new ParameterDetailConfiguration());

            //Viems
            modelBuilder.Configurations.Add(new ArticleGroupConfiguration());

            //Tables
            modelBuilder.Configurations.Add(new TrademarkConfiguration());
            modelBuilder.Configurations.Add(new SizeConfiguration());
            modelBuilder.Configurations.Add(new SizeTypeConfiguration());
            modelBuilder.Configurations.Add(new AvailableLegacyCodeConfiguration());
            modelBuilder.Configurations.Add(new TableParameterConfiguration());
            modelBuilder.Configurations.Add(new ClassificationConfiguration());
            modelBuilder.Configurations.Add(new ColorConfiguration());
            modelBuilder.Configurations.Add(new DetailSizeTypeConfiguration());
        }
    }
}
