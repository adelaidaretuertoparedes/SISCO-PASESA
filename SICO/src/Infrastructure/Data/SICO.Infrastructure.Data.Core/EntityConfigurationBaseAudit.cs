using SICO.Domain.Core;
using System.Data.Entity.ModelConfiguration;

namespace SICO.Infrastructure.Data.Core
{
    public abstract class EntityConfigurationBaseAudit<TEntity>: EntityTypeConfiguration<TEntity> 
        where TEntity : AuditEntityBase
    {
        public EntityConfigurationBaseAudit()
        {
            Ignore(c=>c.Status);

            Ignore(c => c.CreationDate);

            Ignore(c => c.CreatorIpAddress);

            Ignore(c => c.CreatorUser);

            Ignore(c => c.UpdateDate);

            Ignore(c => c.UpdaterIpAddress);

            Ignore(c => c.UpdaterUser);

        }
    }
}
