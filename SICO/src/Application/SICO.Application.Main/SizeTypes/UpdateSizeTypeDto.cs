using SICO.Application.Main.DetailsSizeType;
using System.Collections.Generic;

namespace SICO.Application.Main.SizeTypes
{
    public class UpdateSizeTypeDto: Core.ValidatableDtoBase<UpdateSizeTypeDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> sizeIds { get; set; }
        public List<int> sizeDeleteIds { get; set; }
        public List<ListDetailSizeTypeDto> lstDetailSizeType { get; set; }

    }
}
