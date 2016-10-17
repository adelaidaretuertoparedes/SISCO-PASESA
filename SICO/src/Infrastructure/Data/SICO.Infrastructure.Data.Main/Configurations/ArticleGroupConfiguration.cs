using SICO.Domain.Main.ArticleGroups;
using SICO.Infrastructure.Data.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace SICO.Infrastructure.Data.Main.Configurations
{
    public class ArticleGroupConfiguration : EntityConfigurationBaseAudit<ArticleGroup>
    {
        public ArticleGroupConfiguration()
        {
            // Primary Key            
            Property(c => c.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Code)
                .IsRequired();
        }
    }
}
