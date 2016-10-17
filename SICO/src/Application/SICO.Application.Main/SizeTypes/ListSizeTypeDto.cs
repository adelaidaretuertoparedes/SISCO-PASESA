
namespace SICO.Application.Main.SizeTypes
{
    public class ListSizeTypeDto : Core.ValidatableDtoBase<ListSizeTypeDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string LegacyCode { get; set; }
        public bool Status { get; set; }
        public string ActiveDescription { get; set; }
    }
}
