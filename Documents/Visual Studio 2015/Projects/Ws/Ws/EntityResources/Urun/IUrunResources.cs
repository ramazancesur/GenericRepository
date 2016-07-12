using System.Collections.Generic;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Urun
{
    interface IUrunResources
    {
        List<UrunDTO> getAll(CalisanDTO calisanDTO);
        FirmDTO findByFirm(CalisanDTO calisanDTO, UrunDTO urun);
        UrunDTO deleteUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO, int firmID);
        UrunDTO updateUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO);
        UrunDTO createUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO);
    }
}
