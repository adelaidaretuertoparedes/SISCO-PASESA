using AutoMapper;
using SICO.Domain.Main.Trademarks;

namespace SICO.Application.Main.Trademarks.DtoAdapters
{
    public class ListTrademarkProfile : Profile
    {
        public ListTrademarkProfile()
        {
            CreateMap<Trademark, ListTrademarkDto>();
           
        }
    }
}
