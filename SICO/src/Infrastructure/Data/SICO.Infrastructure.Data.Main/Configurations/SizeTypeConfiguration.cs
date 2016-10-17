using SICO.Domain.Main.SizeTypes;
using SICO.Infrastructure.Data.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class SizeTypeConfiguration : EntityConfigurationBase<SizeType>
    {
        public SizeTypeConfiguration()
        {
            ToTable("SizeType", "dbo");
            Property(x => x.Id).IsRequired();
            Property(x => x.Name).HasMaxLength(50).IsRequired();

            Property(x => x.Code)
                .HasColumnType("varchar")
                .HasMaxLength(6)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(x => x.LegacyCode)
                .HasColumnType("varchar")
                .HasMaxLength(3).IsRequired();

            Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(100);


        
            //Property(x => x.Classification.Code).HasMaxLength(6);
            //Property(x => x.Classification.Id).IsRequired();

            //HasRequired(x => x.Classification).WithMany(x => x.SizeTypes).HasForeignKey(x => x.ClasificationId);

        }
    }
}
