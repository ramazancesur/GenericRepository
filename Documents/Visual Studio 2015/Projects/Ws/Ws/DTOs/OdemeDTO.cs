namespace Ws.RestWs.Dto
{
    public class OdemeDTO:BaseDTO
    {
        public int price { get; set; }
        public PaymentType paymentType { get; set; }
        public int remainCost { get; set; }
        public MusteriDTO musteri { get; set; }
    }
    public enum PaymentType
    {
        NAKIT,KREDI_KARTI,HAVALE,EFT
    }
}