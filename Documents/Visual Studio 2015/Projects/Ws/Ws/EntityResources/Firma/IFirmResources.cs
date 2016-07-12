using System.Collections.Generic;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Firma
{
    interface IFirmResources
    {
        FirmDTO createFirm(FirmDTO firmDTO, CalisanDTO calisanDTO);
        List<FirmDTO> allFirm();
        FirmDTO updatedFirm(FirmDTO firmDTO, CalisanDTO calisanDTO);
        List<FirmDTO> findbyName(string name);
        FirmDTO DeleteFirm(FirmDTO firmDTO, CalisanDTO calisanDTO);
    }
}
