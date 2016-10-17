using SICO.Domain.Core;
using SICO.Domain.Main.Parameters;
using System.Collections.Generic;

namespace SICO.Domain.Main.ParameterDetails
{
    public class ParameterDetail: AuditEntityBase
    {
        public virtual short Id { get; set; }

        public virtual string Name { get; set; }

        public Parameter Parameter { get; set; }

        public virtual short? ParentParameterDetailId { get; set; }

        public virtual string ParameterId { get; set; }

        public ParameterDetail ParentParameterDetail { get; set; }

        public virtual string Valor1 { get; set; }

        public virtual string Valor2 { get; set; }

        public virtual string Valor3 { get; set; }

        public virtual ICollection<ParameterDetail> ChildParameterDetails
        {
            get;
            set;
        }
    }
}
