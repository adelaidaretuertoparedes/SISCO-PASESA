using SICO.Domain.Main.TableParameters;
using System.Data.Entity.ModelConfiguration;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class TableParameterConfiguration : EntityTypeConfiguration<TableParameter>
    {
        public TableParameterConfiguration()
        {
            ToTable("TableParameter", "dbo");
            Property(x => x.IdTable).HasMaxLength(20).IsRequired().HasColumnType("varchar");
            Property(x => x.Description).HasMaxLength(100).IsRequired().HasColumnType("varchar");
        }
    }
}
