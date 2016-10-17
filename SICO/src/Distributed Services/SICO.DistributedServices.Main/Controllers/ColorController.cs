using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SICO.Application.Core;
using SICO.Application.Main.Colors;
using SICO.DistributedServices.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SICO.DistributedServices.Main.Controllers
{
    [Route("api/main/[controller]")]
    public class ColorController:ApiControllerBase
    {
        private readonly IColorAppService _colorAppService;
        private readonly IMapper _mapper;
        public ColorController(IColorAppService colorAppService)
        {
            _colorAppService = colorAppService;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await _colorAppService.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ListColorDto>> GetAll()
        {
            return await _colorAppService.GetAllAsync();
        }

        [HttpGet]
        [Route("page/{page:int}")]
        public async Task<PaginationDto<ListColorDto>> GetByCode(int page, int pageSize,string code = null, string name = null)
        {
            return await _colorAppService.GetByCodeAsync(page,pageSize,code,name);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ListColorDto> GetById(int id)
        {
            return await _colorAppService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ListColorDto> Post([FromBody]CreateColorDto createColorDto)
        {
            var listColorDto = new ListColorDto();

            if (ModelState.IsValid)
            {
                listColorDto = await _colorAppService.CreateAsync(createColorDto);
            }
            return listColorDto;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put(int id, [FromBody]UpdateColorDto updateColorDto)
        {
            if (ModelState.IsValid)
            {
                updateColorDto.Id = id;
                await _colorAppService.UpdateAsync(updateColorDto);
            }
        }

        [HttpPut]
        [Route("{id:int}/Activate/{status:bool}")]
        public async Task PutActivate(int id, bool status)
        {
            if (ModelState.IsValid)
            {
                await _colorAppService.ActivateAsync(id, status);
            }
        }

        [Route("Excel")]
        public async Task<IActionResult> ExportToExcel(string code, string name)
        {
            var colors = await _colorAppService.GetByCodeAsync(code, name);
            return new ExcelFileResult<ListColorToExcelDto>(colors, "Color.xlsx");
        }
    }
}
