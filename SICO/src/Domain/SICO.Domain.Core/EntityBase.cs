using System;

namespace SICO.Domain.Core
{
    public abstract class EntityBase<T>: AuditEntityBase
        where T : struct
    {
        public EntityBase()
        {
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            Status = true;
        }
        public virtual T Id { get; set; }        

    }
}
