using SICO.Domain.Main.Colors;
using SICO.Infrastructure.Data.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class ColorConfiguration : EntityConfigurationBase<Color>
    {
        public ColorConfiguration()
        {
            ToTable("Color","dbo");

            Property(x=>x.Code)
                    .HasMaxLength(6)
                    .HasColumnType("varchar")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                    .IsRequired();

            Property(x => x.LegacyCode)
                    .HasMaxLength(3)
                    .HasColumnType("char")
                    .IsRequired();

            Property(x => x.Name)
                    .HasMaxLength(50)
                    .HasColumnType("varchar")
                    .IsRequired();
        }
    }
}
