using SICO.Domain.Core;
using SICO.Domain.Main.ArticleGroups;

namespace SICO.Domain.Main.Classifications
{
    public class Classification : EntityBase<int>
    {
        //Campo Code Classification
        public string Code { get; set; }
        //Campo Code Article Group
        public int ArticleGroupCode { get; set; }
        //Campo Name Classification
        public string Name { get; set; }

        public virtual ArticleGroup ArticleGroup { get; set; }

    }
}
