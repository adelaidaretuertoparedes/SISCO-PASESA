using Microsoft.AspNetCore.Mvc;
using SICO.Application.Core;
using SICO.Application.Main.Classifications;
using SICO.DistributedServices.Core;
using System.Threading.Tasks;

namespace SICO.DistributedServices.Main.Controllers
{
    [Route("api/main/[controller]")]
    public class ClassificationController:ApiControllerBase
    {
        private readonly IClassificationAppService _classificationAppService;

        public ClassificationController(IClassificationAppService classificationAppService)
        {
            _classificationAppService = classificationAppService;
        }

        [HttpGet]
        [Route("~/api/main/classifications")]
        public async Task<PaginationDto<ListClassificationDto>> GetAllClassification(int page, int pageSize, string name = null, string code = null, int? articleGroupCode = null)
        {
            return await _classificationAppService.GetAllClassificationAsync(page, pageSize, name:name, code:code, articleGroupCode:articleGroupCode);
        }

        [HttpPost]
        public async Task<ListClassificationDto> Post([FromBody]CreateClassificationDto createClassificationDto)
        {
            var listClassificationDto = new ListClassificationDto();

            if (ModelState.IsValid)
            {
                listClassificationDto = await _classificationAppService.CreateAsync(createClassificationDto);
            }
            return listClassificationDto;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put(int id, [FromBody] UpdateClassificationDto updateClassificationDto)
        {
            if (ModelState.IsValid)
            {
                updateClassificationDto.Id = id;
                await _classificationAppService.UpdateAsync(updateClassificationDto);
            }
        }

        [HttpPut]
        [Route("{id:int}/Active/{status:bool}")]
        public async Task Active(int id, bool status)
        {
            if (ModelState.IsValid)
            {
                await _classificationAppService.ActiveAsync(id, status);
            }
        }

    }
}
