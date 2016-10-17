using SICO.Domain.Main.Parameters;
using System.Data.Entity.ModelConfiguration;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class ParameterConfiguration : EntityTypeConfiguration<Parameter>
    {
        public ParameterConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Id).HasMaxLength(30);

            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Description)
                .IsOptional()
                .HasMaxLength(200);            
            
        }
    }
}
