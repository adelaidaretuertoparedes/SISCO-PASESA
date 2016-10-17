using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SICO.Application.Main.Sizes
{
    public class UpdateSizeDto : Core.ValidatableDtoBase<UpdateSizeDto>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        //public int Order { get; set; }
    }
}
