using System;
using System.ComponentModel.DataAnnotations;

namespace SICO.Application.Main.Trademarks
{
    public class CreateTrademarkDto : Core.ValidatableDtoBase<CreateTrademarkDto>
    {
        [Display(Name = "Marca")]
        public string Name { get; set; }

        [Display(Name = "Nombre Corto")]
        public string ShortName { get; set; }

        [Display(Name = "Propietario")]
        public string Owner { get; set; }
    }
}
