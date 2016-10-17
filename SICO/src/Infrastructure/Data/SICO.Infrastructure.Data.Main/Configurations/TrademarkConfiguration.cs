using SICO.Domain.Main.Trademarks;
using SICO.Infrastructure.Data.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class TrademarkConfiguration : EntityConfigurationBase<Trademark>
    {
        public TrademarkConfiguration()
        {
            ToTable("Trademark","dbo");

            Property(x => x.Code)                
                .HasMaxLength(6)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .IsRequired();

            Property(x => x.LegacyCode)
                .HasColumnType("char")
                .HasMaxLength(2)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
                       
            Property(x => x.ShortName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.Owner)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();
        }
    }
}
