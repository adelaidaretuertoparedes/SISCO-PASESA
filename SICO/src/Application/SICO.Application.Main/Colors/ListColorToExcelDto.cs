using System.ComponentModel.DataAnnotations;

namespace SICO.Application.Main.Colors
{
    public class ListColorToExcelDto 
    {
        [Display (Name ="CÓDIGO")] 
        public string Code { get; set; }

        [Display(Name = "NOMBRE")]
        public string Name { get; set; }

        [Display(Name = "CÓDIGO LEGACY")]
        public string LegacyCode { get; set; }

        [Display(Name = "ESTADO")]
        public string Status { get; set; }
    }
}
