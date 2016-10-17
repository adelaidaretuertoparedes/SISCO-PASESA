using SICO.Domain.Core;
using System.Data.Entity.ModelConfiguration;

namespace SICO.Infrastructure.Data.Core
{
    public abstract class EntityConfigurationBase<TEntity>: EntityTypeConfiguration<TEntity> 
        where TEntity : AuditEntityBase
    {
        public EntityConfigurationBase()
        {   

            Property(x => x.CreatorIpAddress)
               .IsRequired()
               .HasMaxLength(20)
               .HasColumnType("varchar");

            Property(x => x.CreatorUser)
               .IsRequired()
               .HasMaxLength(20)
               .HasColumnType("varchar");

            Property(x => x.UpdaterIpAddress)
                .IsOptional()
                .HasMaxLength(20)
            .HasColumnType("varchar");

            Property(x => x.UpdaterUser)
                .IsOptional()
                .HasMaxLength(20)
                .HasColumnType("varchar");

        }
    }
}
