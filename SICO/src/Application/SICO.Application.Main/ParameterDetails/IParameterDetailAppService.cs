using SICO.Application.Main.ParameterDetails.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SICO.Application.Main.ParameterDetails
{
    public interface IParameterDetailAppService
    {
        Task<IEnumerable<ArticleGroupDto>> GetArticleGroupsAsync();
    }
}
