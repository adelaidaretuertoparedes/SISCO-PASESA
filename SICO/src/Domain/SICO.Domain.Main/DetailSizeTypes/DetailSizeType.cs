using SICO.Domain.Main.SizeTypes;
using SICO.Domain.Main.Sizes;
using SICO.Domain.Core;
using System;

namespace SICO.Domain.Main.DetailSizeTypes
{
    public class DetailSizeType: EntityBase<int>
    {     

        public int SizeId { get; set; }
        public int SizeTypeId { get; set; }
        public int Order { get; set; }
        public SizeType SizeType { get; set; }
        public Size Size { get; set; }
    }
}
