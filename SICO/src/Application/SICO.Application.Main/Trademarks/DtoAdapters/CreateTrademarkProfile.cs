using AutoMapper;
using SICO.Domain.Main.Trademarks;

namespace SICO.Application.Main.Trademarks.DtoAdapters
{
    public class CreateTrademarkProfile : Profile
    {
        public CreateTrademarkProfile()
        {
            CreateMap<CreateTrademarkDto, Trademark>();                

            CreateMap<Trademark,CreateTrademarkDto>();
        }            
    }
}
