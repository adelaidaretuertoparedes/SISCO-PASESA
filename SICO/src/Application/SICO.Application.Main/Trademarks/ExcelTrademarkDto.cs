using System.ComponentModel.DataAnnotations;

namespace SICO.Application.Main.Trademarks
{
    public class ExcelTrademarkDto
    {   
        [Display(Name="CODIGO")]
        public string Code { get; set; }

        [Display(Name = "MARCA")]
        public string Name { get; set; }

        [Display(Name = "NOMBRE CORTO")]
        public string ShortName { get; set; }

        [Display(Name = "PROPIETARIO")]
        public string Owner { get; set; }

        [Display(Name = "CODIGO LEGACY")]
        public string LegacyCode { get; set; }

        [Display(Name = "ESTADO")]
        public string Status { get; set; }
    }
}
