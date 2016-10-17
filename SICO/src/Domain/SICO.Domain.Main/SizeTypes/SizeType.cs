using SICO.Domain.Core;
using SICO.Domain.Main.DetailSizeTypes;

using System.Collections.Generic;

namespace SICO.Domain.Main.SizeTypes
{
    public class SizeType : EntityBase<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string LegacyCode { get; set; }
        public string Description{ get; set; }      
        public virtual ICollection<DetailSizeType> DetailsSizeTypes { get; set; }

    }
}
