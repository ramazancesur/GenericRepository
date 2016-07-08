using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ws.RestWs.Dto
{
    public class Siparis:BaseDTO
    {
        public MusteriDTO musteri { get; set; }
        public double totalAmount { get; set; }
        public List<UrunDTO> lstUruns { get; set; }
        //Musteri Sipariş Notu
        public string orderNotesCustom { get; set; }
        //Satıcı Sipariş Notu
        public string orderNotesSaler { get; set; }
        //KalanBorc
        public double remainDept { get; set; }
        //Teslimat Tarihi
        public DateTime deliveryDate { get; set; }
    }
}