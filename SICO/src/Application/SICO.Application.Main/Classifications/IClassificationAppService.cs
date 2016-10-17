using SICO.Application.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SICO.Application.Main.Classifications
{
    public interface IClassificationAppService
    {
        Task<ListClassificationDto> CreateAsync(CreateClassificationDto createClassificationDto);
        Task<IEnumerable<ListClassificationDto>> GetAllAsync();
        /*Buscar con Filtros de Busqueda Async Name, Code y ArticleGroupCode*/
        Task<PaginationDto<ListClassificationDto>> GetAllClassificationAsync(int page, int pageSize, string name = null, string code = null, int? articleGroupCode = null);
        Task UpdateAsync(UpdateClassificationDto updateClassificationDto);
        Task ActiveAsync(int id, bool status);

    }
}
