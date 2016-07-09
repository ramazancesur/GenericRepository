using System;
using System.Collections.Generic;

namespace Ws.RestWs.Dto
{
    public class SiparisDTO:BaseDTO
    {
        public MusteriDTO musteri { get; set; }
        public int totalAmount { get; set; }
        public List<SiparisDetailDTO> lstSiparisDetail { get; set; }
        //Musteri Sipariş Notu
        public string orderNotesCustom { get; set; }
        //Teslimat Tarihi
        public DateTime deliveryDate { get; set; }
        public CalisanDTO calisanDTO { get; set; }
        public DeliveryStatus deliveryStatus { get; set; }
    }
    public enum DeliveryStatus
    {
        ORDER_WAIT,ORDERED
    }
}