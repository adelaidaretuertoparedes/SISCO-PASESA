
using System.Collections.Generic;

namespace SICO.Application.Main.SizeTypes
{
    public class CreateSizeTypeDto : Core.ValidatableDtoBase<CreateSizeTypeDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<int> sizeIds { get; set; }
    }
}
