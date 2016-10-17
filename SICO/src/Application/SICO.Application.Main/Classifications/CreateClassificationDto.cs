namespace SICO.Application.Main.Classifications
{
    public class CreateClassificationDto : Core.ValidatableDtoBase<CreateClassificationDto>
    {
        //Codigo
        public string Code { get; set; } 
        //Clasificacion
        public string Name { get; set; }
        //Grupo
        public int ArticleGroupCode { get; set; }
        
    }
}