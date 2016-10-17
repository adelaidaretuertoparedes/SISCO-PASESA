using SICO.Application.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SICO.Application.Main.Trademarks
{
    public interface ITrademarkAppService
    {

        Task<ListTrademarkDto> CreateAsync(CreateTrademarkDto createTrademarkDto);

        Task DeleteAsync(int id);
   
        Task<PaginationDto<ListTrademarkDto>> GetAsync(int page, int pageSize, string code=null,string name=null);

        Task<IEnumerable<ExcelTrademarkDto>> GetAsync(string code = null, string name = null);

        Task UpdateAsync(UpdateTrademarkDto updateTrademarkDto);

        Task ActivateAsync(int id, bool status);
    }
}
