using AutoMapper;
using SICO.Domain.Main.Trademarks;

namespace SICO.Application.Main.Trademarks.DtoAdapters
{
    public class ExcelTrademarkDtoProfile : Profile
    {
        public ExcelTrademarkDtoProfile()
        {
            CreateMap<Trademark, ExcelTrademarkDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status ? "Activo" : "Inactivo"));
        }
    }
}
