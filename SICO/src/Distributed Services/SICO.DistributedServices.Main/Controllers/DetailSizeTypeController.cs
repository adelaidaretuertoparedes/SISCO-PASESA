using Microsoft.AspNetCore.Mvc;
using SICO.Application.Main.DetailsSizeType;
using SICO.DistributedServices.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using SICO.Application.Core;

namespace SICO.DistributedServices.Main.Controllers
{
    [Route("api/main/[controller]")]

    public class DetailSizeTypeController: ApiControllerBase
    {
        private readonly IDetailSizeTypeAppService _detailsizetypeAppService;
                         
        public DetailSizeTypeController(IDetailSizeTypeAppService detailsizetypeAppService)
        {
            _detailsizetypeAppService = detailsizetypeAppService;
        }
        public async Task Post([FromBody]CreateDetailSizeTypeDto createDetailSizeTypeDto)
        {
            if (ModelState.IsValid)
            {
              await _detailsizetypeAppService.CreateAsync(createDetailSizeTypeDto);
            }
        }

        [HttpDelete]
        [Route("{idSize:int}")]
        public async Task Delete(int idSize)
        {
            await _detailsizetypeAppService.DeleteAsync(idSize);
        }

        [HttpGet]
        [Route("~/api/main/GetDetailsSizeType")]
        public async Task<IEnumerable<ListDetailSizeTypeDto>> GetAll(int idSizeType)
        {
            return await _detailsizetypeAppService.GetBySizeTypeIdAsync(idSizeType);
        }

        [HttpGet]
        [Route("~/api/main/SizeType/{idSizeType:int}/DetailSizeTypes")]
        public async Task<IEnumerable<ListDetailSizeTypeDto>> GetSizesBySizeType(int idSizeType)
        {
            return await _detailsizetypeAppService.GetSizesBySizeType(idSizeType);
        }
    }
}
