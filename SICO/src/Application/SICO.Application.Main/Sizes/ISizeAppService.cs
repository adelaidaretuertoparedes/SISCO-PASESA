using SICO.Application.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SICO.Application.Main.Sizes
{
    public interface ISizeAppService
    {
        Task<ListSizeDto> CreateAsync(CreateSizeDto createSizeDto);
        Task DeleteAsync(int id);
        Task DeleteBySizeTypeIdAsync(int idSizeType);
        Task<PaginationDto<ListSizeDto>> GetByCodeNameSync(int page, int pageSize, string code = null, string name = null);
        Task<IEnumerable<ListSizeDto>> GetByNameSync(string name = null);
        Task<IEnumerable<ListSizeDto>> GetAllAsync();        
        Task<IEnumerable<ListSizeDto>> GetSizeAsync(int id);
        Task UpdateAsync(UpdateSizeDto updateSizeDto);
    }
}
