using System;
namespace Ws.RestWs.Dto
{
    public class UrunDTO:BaseDTO
    {
        public string productName { get; set; }
        public double price { get; set; }
        //Kalan
        public int remain { get; set; }
        public DateTime commingDate { get; set; }
        public FirmDTO firmDTO { get; set; }
    }
}