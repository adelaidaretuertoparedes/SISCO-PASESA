using SICO.Application.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SICO.Application.Main.DetailsSizeType
{
    public interface IDetailSizeTypeAppService
    {

        Task<IEnumerable<ListDetailSizeTypeDto>> GetBySizeTypeIdAsync(int idSizeType);
        Task CreateAsync(CreateDetailSizeTypeDto createDetailSizeTypeDto);
        Task DeleteAsync(int idSize);
        Task<IEnumerable<ListDetailSizeTypeDto>> GetSizesBySizeType(int idSizeType);
    }
}
