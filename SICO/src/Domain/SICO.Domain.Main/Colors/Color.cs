using SICO.Domain.Core;

namespace SICO.Domain.Main.Colors
{
    public class Color: EntityBase<int>
    {
        public string Code { get; set; }
        public string LegacyCode { get; set; }   
        public string Name { get; set; }       
    }
}
