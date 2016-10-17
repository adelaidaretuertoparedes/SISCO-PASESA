using Microsoft.AspNetCore.Mvc;
using SICO.Application.Main.SizeTypes;
using SICO.Application.Core;
using SICO.DistributedServices.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SICO.DistributedServices.Main.Controllers
{
    [Route("api/main/[controller]")]
    public class SizeTypeController: ApiControllerBase
    {
        private readonly ISizeTypeAppService _sizetypeAppService;

        public SizeTypeController(ISizeTypeAppService sizetypeAppService)
        {
            _sizetypeAppService = sizetypeAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<ListSizeTypeDto>> GetAll()
        {
            return await _sizetypeAppService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ListSizeTypeDto> GetSizeType(int id)
        {
            return await _sizetypeAppService.GetById(id);
        }

        [HttpGet]
        [Route("page/{page:int}")]
        public async Task<PaginationDto<ListSizeTypeDto>> GetCodeName(int page, int pageSize, string code = null, string name = null)
        {
            return await _sizetypeAppService.GetByCodeNameSync(page, pageSize, code, name);
        }
  
        [HttpPost]
        public async Task<ListSizeTypeDto> Post([FromBody]CreateSizeTypeDto createSizeTypeDto)
        {
            var listSizeTypeDto = new ListSizeTypeDto();
            if (ModelState.IsValid)
            {
                listSizeTypeDto = await _sizetypeAppService.CreateAsync(createSizeTypeDto);               
            }
            return listSizeTypeDto;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put(int id, [FromBody]UpdateSizeTypeDto updateSizeTypeDto)
        {
            if (ModelState.IsValid)
            {
                updateSizeTypeDto.Id = id;
                await _sizetypeAppService.UpdateAsync(updateSizeTypeDto);
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await _sizetypeAppService.DeleteAsync(id);
        }
        [HttpPut]
        [Route("{id:int}/Activate/{value:bool}")]
        public async Task PutActive(int id, bool value)
        {
            if (ModelState.IsValid)
            {
                await _sizetypeAppService.Activate(id, value);
            }
        }
    }
}
