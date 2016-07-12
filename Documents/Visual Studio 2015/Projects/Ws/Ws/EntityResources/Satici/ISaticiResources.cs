using System.Collections.Generic;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Satici
{
    interface ISaticiResources
    {
        List<SaticiDTO> allSaticiDTO();
        SaticiDTO deleteSatici(SaticiDTO satici, CalisanDTO calisan);
        SaticiDTO updateSatici(SaticiDTO satici, CalisanDTO calisan);
        SaticiDTO createSatici(SaticiDTO satici, CalisanDTO calisan);
    }
}
