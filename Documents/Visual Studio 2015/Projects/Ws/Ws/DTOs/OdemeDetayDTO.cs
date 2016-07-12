namespace Ws.RestWs.Dto
{
    public class OdemeDetayDTO:BaseDTO
    {
        public OdemeDTO odeme { get; set; }
        public int oldPrice { get; set; }
        public int newPrice { get; set; }
    }
}