using SICO.Domain.Main.Sizes;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class SizeConfiguration : EntityTypeConfiguration<Size>
    {
        public SizeConfiguration()
        {
            ToTable("Size", "dbo");
            Property(x => x.Id).IsRequired();
            Property(x => x.Name).HasMaxLength(50).IsRequired();

            Property(x => x.Code)
                .HasColumnType("varchar")
                .HasMaxLength(7)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(x => x.LegacyCode)
                .HasColumnType("varchar")
                .HasMaxLength(3).IsRequired();

            //HasRequired(x => x.SizeType).WithMany(x => x.Sizes).HasForeignKey(x=>x.SizeTypeId);
        }
    }
}
