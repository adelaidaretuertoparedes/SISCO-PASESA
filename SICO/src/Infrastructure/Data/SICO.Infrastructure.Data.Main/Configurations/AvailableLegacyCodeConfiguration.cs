using SICO.Domain.Main.AvailableLegacyCodes;
using System.Data.Entity.ModelConfiguration;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class AvailableLegacyCodeConfiguration : EntityTypeConfiguration<AvailableLegacyCode>
    {
        public AvailableLegacyCodeConfiguration()
        {
            //ToTable("AvailableLegacyCode", "dbo");

            Property(x => x.Code)
              .IsRequired()
              .HasMaxLength(10)
              .HasColumnType("varchar");

            Property(x => x.Type)
              .IsRequired()
              .HasMaxLength(20)
              .HasColumnType("varchar");


            Ignore(c=>c.CreationDate);
            Ignore(c => c.CreatorIpAddress);
            Ignore(c => c.CreatorUser);
            Ignore(c => c.UpdateDate);
            Ignore(c => c.UpdaterUser);
            Ignore(c => c.UpdaterIpAddress);
            Ignore(c=>c.Status);           

            
        }
    }
}
