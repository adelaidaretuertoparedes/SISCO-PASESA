using SICO.Application.Core;
using SICO.Domain.Main.Colors;
using SICO.Domain.Main.Trademarks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SICO.Application.Main.Colors
{
    public interface IColorAppService
    {
        Task<ListColorDto> CreateAsync(CreateColorDto createColorDto);
        Task UpdateAsync(UpdateColorDto updateColorDto);
        Task DeleteAsync(int id);
        Task ActivateAsync(int id, bool status);
        Task<IEnumerable<ListColorDto>> GetAllAsync();
        Task<PaginationDto<ListColorDto>> GetByCodeAsync(int page, int pageSize,string code=null, string name= null);
        Task<ListColorDto> GetByIdAsync(int id);
        Task<IEnumerable<ListColorToExcelDto>> GetByCodeAsync(string code = null, string name = null);
    }
}
