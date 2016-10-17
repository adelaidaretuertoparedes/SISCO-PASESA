using SICO.Domain.Core;
using SICO.Domain.Main.DetailSizeTypes;
using System.Collections.Generic;

namespace SICO.Domain.Main.Sizes
{
    public class Size: EntityBase<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string LegacyCode { get; set; }
        public virtual ICollection<DetailSizeType> DetailsSizeTypes { get; set; }

    }
}
