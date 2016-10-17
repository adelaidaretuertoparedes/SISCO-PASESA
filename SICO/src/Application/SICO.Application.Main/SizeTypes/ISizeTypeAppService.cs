using SICO.Application.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SICO.Application.Main.SizeTypes
{
    public interface ISizeTypeAppService
    {
        Task<ListSizeTypeDto> CreateAsync(CreateSizeTypeDto createSizeTypeDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ListSizeTypeDto>> GetAllAsync();
        Task<ListSizeTypeDto> GetById(int id);
        Task<PaginationDto<ListSizeTypeDto>> GetByCodeNameSync(int page, int pageSize, string code = null, string name = null);
        Task UpdateAsync(UpdateSizeTypeDto updateSizeTypeDto);
        Task Activate(int id, bool value);
    }
}
