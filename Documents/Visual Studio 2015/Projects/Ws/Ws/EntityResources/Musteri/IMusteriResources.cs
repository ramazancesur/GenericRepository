using System.Collections.Generic;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Musteri
{
    public interface IMusteriResources
    {
        MusteriDTO findMusteriByClient(client client);
        List<MusteriDTO> lstMusteriDTO();
        MusteriDTO updateMusteri(MusteriDTO musteri, CalisanDTO calisan);
        MusteriDTO deleteMusteri(MusteriDTO musteri, CalisanDTO calisan);
        MusteriDTO createMusteri(MusteriDTO musteri, CalisanDTO calisan);
    }
}