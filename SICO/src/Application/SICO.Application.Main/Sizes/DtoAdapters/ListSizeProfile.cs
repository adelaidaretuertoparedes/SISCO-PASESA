using AutoMapper;
using SICO.Domain.Main.Sizes;

namespace SICO.Application.Main.Sizes.DtoAdapters
{
    public class ListSizeProfile:Profile
    {
        public ListSizeProfile()
        {
            CreateMap<ListSizeDto, Size>();
            CreateMap<Size, ListSizeDto>();
        }
    }
}
