using System.Collections.Generic;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Siparis
{
    interface ISiparisResources
    {
        List<OdemeDTO> allOdeme();
        List<SiparisDetailDTO> allSiparisDetay(SiparisDTO siparis, CalisanDTO calisanDTO);
        List<SiparisDTO> allSiparis();
        List<OdemeDetayDTO> allOdemeDetay(OdemeDTO odeme);
        OdemeDTO deleteOdemeDTO(OdemeDTO odeme, CalisanDTO calisan);
        OdemeDTO updateOdemeDTO(OdemeDTO odeme, CalisanDTO calisan);
        OdemeDTO createOdeme(OdemeDTO odeme, CalisanDTO calisan);
        SiparisDTO updateSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan);
        SiparisDTO deleteSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan);
        SiparisDTO createSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan);
    }
}
