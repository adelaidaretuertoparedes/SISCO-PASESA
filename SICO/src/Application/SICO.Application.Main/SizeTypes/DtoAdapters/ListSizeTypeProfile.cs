using AutoMapper;
using SICO.Domain.Main.SizeTypes;

namespace SICO.Application.Main.SizeTypes.DtoAdapters
{
    public class ListSizeTypeProfile:Profile
    {
        public ListSizeTypeProfile()
        {
            CreateMap<ListSizeTypeDto, SizeType>();
            CreateMap<SizeType, ListSizeTypeDto>()
             //.ForMember(d => d.ClasificationName, o => o.MapFrom(s => s.Classification.Name));
                .ForMember(d => d.ActiveDescription, o => o.MapFrom(s => s.Status ? "Activo" : "Inactivo"));
        }
    }
}
