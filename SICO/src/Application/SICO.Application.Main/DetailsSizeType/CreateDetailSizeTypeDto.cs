using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SICO.Application.Main.DetailsSizeType
{
    public class CreateDetailSizeTypeDto: Core.ValidatableDtoBase<CreateDetailSizeTypeDto>
    {
        public int SizeId { get; set; }
        public int SizeTypeId { get; set; }
        public int Order { get; set; }
    }
}
