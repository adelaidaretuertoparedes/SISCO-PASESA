using SICO.Domain.Main.DetailSizeTypes;
using SICO.Infrastructure.Data.Core;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class DetailSizeTypeConfiguration: EntityConfigurationBase<DetailSizeType>
    {

        public DetailSizeTypeConfiguration() {

            ToTable("DetailSizeType", "dbo");

            Property(x => x.Id).IsRequired();
            Property(x => x.SizeId).IsRequired();
            Property(x => x.SizeTypeId).IsRequired();
            Property(x => x.Order).IsRequired();

            HasRequired(x => x.SizeType).WithMany(x => x.DetailsSizeTypes).HasForeignKey(x => x.SizeTypeId);
            HasRequired(x => x.Size).WithMany(x => x.DetailsSizeTypes).HasForeignKey(x => x.SizeId);
        }
    }
}
