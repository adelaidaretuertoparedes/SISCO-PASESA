using Microsoft.AspNetCore.Mvc;
using SICO.Application.Main.Sizes;
using SICO.DistributedServices.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using SICO.Application.Core;

namespace SICO.DistributedServices.Main.Controllers
{
    [Route("api/main/[controller]")]

    public class SizeController: ApiControllerBase
    {
        private readonly ISizeAppService _sizeAppService;

        public SizeController(ISizeAppService sizetypeAppService)
        {
            _sizeAppService = sizetypeAppService;
        }      
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IEnumerable<ListSizeDto>> GetSize(int id)
        {
            return await _sizeAppService.GetSizeAsync(id);
        }

        [HttpGet]        
        public async Task<PaginationDto<ListSizeDto>> GetCodeName(int page, int pageSize, string code = null, string name = null)
        {
            return await _sizeAppService.GetByCodeNameSync(page, pageSize, code, name);
        }

        [HttpGet]
        [Route("query")]
        public async Task<IEnumerable<ListSizeDto>> GetByName(string name = null)
        {
            return await _sizeAppService.GetByNameSync(name);
        }

        [HttpPost]
        public async Task<ListSizeDto> Post([FromBody]CreateSizeDto createSizeDto)
        {
            var listSizeDto = new ListSizeDto();

            if (ModelState.IsValid)
            {
                listSizeDto = await _sizeAppService.CreateAsync(createSizeDto);
            }
            return listSizeDto;
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task Put(int id, UpdateSizeDto updateSizeDto)
        {
            if (ModelState.IsValid)
            {
                updateSizeDto.Id = id;
                await _sizeAppService.UpdateAsync(updateSizeDto);
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await _sizeAppService.DeleteAsync(id);
        }        
    }
}
 