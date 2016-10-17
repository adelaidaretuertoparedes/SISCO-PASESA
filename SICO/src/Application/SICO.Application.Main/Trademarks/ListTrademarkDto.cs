namespace SICO.Application.Main.Trademarks
{
    public class ListTrademarkDto
    {   
        public int id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }      
        public string ShortName { get; set; }
        public string Owner { get; set; }
        public string LegacyCode { get; set; }
        public bool Status { get; set; }
    }
}
