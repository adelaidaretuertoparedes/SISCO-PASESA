using System.ComponentModel.DataAnnotations;

namespace SICO.Application.Main.Trademarks
{
    public class UpdateTrademarkDto : Core.ValidatableDtoBase<UpdateTrademarkDto>
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Marca")]
        public string Name { get; set; }

        [Display(Name = "Nombre Corto")]
        public string ShortName { get; set; }

        [Display(Name = "Propietario")]
        public string Owner { get; set; }

    }
}
