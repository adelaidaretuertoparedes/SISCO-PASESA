using SICO.Domain.Core;

namespace SICO.Domain.Main.Trademarks
{
    public class Trademark:EntityBase<int>
    {
        public string Code { get; set; }
        public string LegacyCode { get; set; }
        public string Name { get; set; }  
        public string ShortName { get; set; }
        public string Owner { get; set; }
    }
}
