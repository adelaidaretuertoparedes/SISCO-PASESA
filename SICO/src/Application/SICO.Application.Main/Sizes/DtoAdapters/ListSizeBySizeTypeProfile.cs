using AutoMapper;
using SICO.Domain.Main.Sizes;

namespace SICO.Application.Main.Sizes.DtoAdapters
{
    public class ListSizeBySizeTypeProfile: Profile
    {
        public ListSizeBySizeTypeProfile()
        {
            CreateMap<ListSizeBySizeTypeDto, Size>();
            CreateMap<Size, ListSizeBySizeTypeDto>();
        }
    }
}
