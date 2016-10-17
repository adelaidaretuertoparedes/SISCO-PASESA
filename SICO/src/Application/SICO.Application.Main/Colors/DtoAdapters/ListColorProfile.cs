using AutoMapper;
using SICO.Domain.Main.Colors;

namespace SICO.Application.Main.Colors.DtoAdapters
{
    public class ListColorProfile : Profile
    {
        public ListColorProfile()
        {
            CreateMap<ListColorDto, Color>();               

            CreateMap<Color,ListColorDto>()
                .ForMember(d => d.ActiveDescription, o => o.MapFrom(s => s.Status? "Activo":"Inactivo"));

            CreateMap<ListColorDto, CreateColorDto>();
            CreateMap<CreateColorDto, ListColorDto>();
        }
    }
}
