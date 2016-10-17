using System;

namespace SICO.Domain.Core
{
    public abstract class AuditEntityBase
    {
        public DateTime CreationDate { get; set; }
        public string CreatorIpAddress { get; set; }
        public string CreatorUser { get; set; }
        public bool Status { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdaterIpAddress { get; set; }
        public string UpdaterUser { get; set; }
    }
}
