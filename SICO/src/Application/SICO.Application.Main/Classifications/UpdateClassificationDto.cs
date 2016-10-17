namespace SICO.Application.Main.Classifications
{
    public class UpdateClassificationDto : Core.ValidatableDtoBase<UpdateClassificationDto>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int ArticleGroupCode { get; set; }

    }
}
