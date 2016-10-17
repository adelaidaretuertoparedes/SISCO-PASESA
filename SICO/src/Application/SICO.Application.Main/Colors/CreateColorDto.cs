using System.ComponentModel.DataAnnotations;

namespace SICO.Application.Main.Colors
{
    public class CreateColorDto : Core.ValidatableDtoBase<CreateColorDto>
    {
        [Display(Name = "Color")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string LegacyCode { get; set; }
    }
}
