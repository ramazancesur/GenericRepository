using System.Collections.Generic;

namespace Ws.RestWs.Dto
{
    public enum ReportType
    {
        GUNLUK, HAFTALIK, AYLIK, YILLIK
    }
    public class SatisRaporlariDTO:BaseDTO
    {
        public ReportType raportType { get; set; }
        public List<SiparisDTO> lstSiparisListesi { get; set; }
        //Net Kar
        public double purePrefit { get; set; }
    }
}