using SICO.Domain.Core;

namespace SICO.Domain.Main.TableParameters
{
    public class TableParameter : EntityBase<int>
    {

        public string IdTable { get; set; }
        public string Description { get; set; }
    
    }
}
