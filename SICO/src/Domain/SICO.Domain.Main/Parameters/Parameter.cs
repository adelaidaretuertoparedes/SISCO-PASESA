using SICO.Domain.Main.ParameterDetails;
using System.Collections.Generic;

namespace SICO.Domain.Main.Parameters
{
    public class Parameter
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Status { get; set; }
        public virtual string Id { get; set; }
        public ICollection<ParameterDetail> ParameterDetails { get; set; }
        public virtual bool Maintainable { get; set; }       
    }
}
