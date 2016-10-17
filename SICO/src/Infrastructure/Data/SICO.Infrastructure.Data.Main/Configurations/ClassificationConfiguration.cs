using SICO.Domain.Main.Classifications;
using SICO.Infrastructure.Data.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class ClassificationConfiguration : EntityConfigurationBase<Classification>
    {
        public ClassificationConfiguration()
        {
            ToTable("Classification", "dbo");
            Property(x => x.Code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .HasMaxLength(6)
                .IsRequired()
                .HasColumnType("varchar");

            Property(x => x.ArticleGroupCode).IsRequired().HasColumnType("int");

            Property(x => x.Name).HasMaxLength(50).IsRequired().HasColumnType("varchar");

           Ignore(x=>x.ArticleGroup);
        }
    }
}
