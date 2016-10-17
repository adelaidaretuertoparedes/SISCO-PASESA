namespace SICO.Application.Main.Colors
{
    public class ListColorDto : Core.ValidatableDtoBase<ListColorDto>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string LegacyCode { get; set; }
        public string Name { get; set; }
        public string ActiveDescription { get; set; }
        public bool Status { get; set; }
    }
}
