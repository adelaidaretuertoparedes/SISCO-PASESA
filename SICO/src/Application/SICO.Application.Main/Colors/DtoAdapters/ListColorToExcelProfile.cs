using AutoMapper;
using SICO.Domain.Main.Colors;

namespace SICO.Application.Main.Colors.DtoAdapters
{
    public class ListColorToExcelProfile : Profile
    {
        public ListColorToExcelProfile()
        {
            CreateMap<Color, ListColorToExcelDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status? "Activo":"Inactivo"));

        }
    }
}
