using System.Collections.Generic;

namespace Ws.RestWs.Dto
{
    public class HarcamaDTO:BaseDTO
    {
        public MoneyType moneyType { get; set; }
        public string harcamaAciklamasi { get; set; }
        public double spendAccount { get; set; }
        public CalisanDTO calisan { get; set; }
        public List<UrunDTO> lstUrunler { get; set; }
    }
    public enum MoneyType
    {
        TL, USD, EURO
    }
}