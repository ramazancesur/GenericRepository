namespace Ws.RestWs.Dto
{
    public class SiparisDetailDTO:BaseDTO
    {
        public double price { get; set; }
        public UrunDTO urunDTO { get; set; }
        public int unitSize { get; set; }
        public UnitType unitType { get; set; }
    }
    public enum UnitType
    {
        ADET, KILOGRAM, GRAM, KUTU, KOLI, DESTE, DUZINE
    }
}