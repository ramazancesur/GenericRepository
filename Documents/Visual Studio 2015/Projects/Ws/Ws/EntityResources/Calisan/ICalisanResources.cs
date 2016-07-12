using System.Collections.Generic;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Calisan
{
    interface ICalisanResources
    {
        List<CalisanDTO> allCalisanList();
        CalisanDTO createCalisan(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO);
        CalisanDTO updateEmployee(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO);
        CalisanDTO removeCalisan(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO);
    }
}
