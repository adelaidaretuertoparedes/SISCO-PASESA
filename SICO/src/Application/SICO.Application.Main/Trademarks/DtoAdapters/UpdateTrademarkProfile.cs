using AutoMapper;
using SICO.Domain.Main.Trademarks;

namespace SICO.Application.Main.Trademarks.DtoAdapters
{
    public class UpdateTrademarkProfile : Profile
    {
        public UpdateTrademarkProfile()
        {
            CreateMap<UpdateTrademarkDto, Trademark>();                

            CreateMap<Trademark,UpdateTrademarkDto>();
        }            
    }
}
