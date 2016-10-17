using Microsoft.AspNetCore.Mvc;
using SICO.Application.Main.ParameterDetails;
using SICO.Application.Main.ParameterDetails.Dtos;
using SICO.DistributedServices.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SICO.DistributedServices.Main.Controllers
{
    [Route("api/main/[controller]")]
    public class ParameterDetailController : ApiControllerBase
    {
        private readonly IParameterDetailAppService _parameterDetailAppService;

        public ParameterDetailController(IParameterDetailAppService parameterDetailAppService)
        {
            _parameterDetailAppService = parameterDetailAppService;
        }

        [Route("ArticleGroup")]       
        public async Task<IEnumerable<ArticleGroupDto>> GetArticleGroups()
        {
            return await _parameterDetailAppService.GetArticleGroupsAsync();
        }
    }
}
