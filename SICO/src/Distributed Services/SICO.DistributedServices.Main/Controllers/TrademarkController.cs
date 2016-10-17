using Microsoft.AspNetCore.Mvc;
using SICO.Application.Core;
using SICO.Application.Main.Trademarks;
using SICO.DistributedServices.Core;
using SICO.Infrastructure.CrossCutting.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SICO.DistributedServices.Main.Controllers
{
    [Route("api/main/[controller]")]
    public class TrademarkController:ApiControllerBase
    {
        private readonly ITrademarkAppService _trademarkAppService;

        public TrademarkController(ITrademarkAppService trademarkAppService)
        {
            _trademarkAppService = trademarkAppService;
        }
              
        [HttpGet]
        [Route("~/api/main/trademarks")]
        public async Task<PaginationDto<ListTrademarkDto>> GetList(int page, int pageSize, string code=null,string name=null)
        {
            return await _trademarkAppService.GetAsync(page,pageSize,code:(code ?? "").TrimMiddle(), name: (name ?? "").TrimMiddle());
        }

        [HttpPost]
        public async Task<ListTrademarkDto> Post([FromBody]CreateTrademarkDto createTrademarkDto)
        {   
            var listTrademarkDto = new ListTrademarkDto();

            if (ModelState.IsValid)
            {
                listTrademarkDto = await _trademarkAppService.CreateAsync(createTrademarkDto);
            }
            return listTrademarkDto;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put(int id, [FromBody]UpdateTrademarkDto updateTrademarkDto)
        {
            if (ModelState.IsValid)
            {
                updateTrademarkDto.Id = id;
                await _trademarkAppService.UpdateAsync(updateTrademarkDto);
            }
        }
              
        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await _trademarkAppService.DeleteAsync(id);
        }

        [Route("{id:int}/ActiveOnOff/{status:bool}")]
        public async Task ActiveOnOff(int id, bool status)
        {
            await _trademarkAppService.ActivateAsync(id,status);
        }

        [Route("Excel")]
        public async Task<IActionResult> ExportToExcel(string code = null, string name = null)
        {
            var excelTrademarkDto = await _trademarkAppService.GetAsync(code:code, name:name);

            return new ExcelFileResult<ExcelTrademarkDto>(excelTrademarkDto, "Trademark.xlsx");                                                                        
        }
    }
}
