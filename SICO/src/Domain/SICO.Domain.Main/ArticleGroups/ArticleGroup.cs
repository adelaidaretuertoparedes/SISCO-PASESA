using SICO.Domain.Core;

namespace SICO.Domain.Main.ArticleGroups
{
    public class ArticleGroup: EntityBase<short>
    {      

        public string Name { get; set; }

        public int Code { get; set; }
    }
}
