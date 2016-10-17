
namespace SICO.Application.Main.Sizes
{
    public class ListSizeDto: Core.ValidatableDtoBase<ListSizeDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string LegacyCode { get; set; }
    }
}
