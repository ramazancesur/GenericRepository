using System.Collections.Generic;
using System.ServiceModel;
using Ws.EntityResources.Satici;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Satici
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SaticiWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SaticiWs.svc or SaticiWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SaticiWs : ISaticiWs
    {
        ISaticiResources saticiResources;
        public SaticiWs()
        {
            init();
        }
        private void init()
        {
            saticiResources = new SaticiResources();
        }
        public List<SaticiDTO> allSaticiDTO()
        {
            List<SaticiDTO> lstSatici = saticiResources.allSaticiDTO();
            return lstSatici;
        }

        public SaticiDTO createSatici(SaticiDTO satici, CalisanDTO calisan)
        {
            SaticiDTO saticiDTO = saticiResources.createSatici(satici, calisan);
            return saticiDTO;
        }

        public SaticiDTO deleteSatici(SaticiDTO satici, CalisanDTO calisan)
        {
            SaticiDTO saticiDTO = saticiResources.deleteSatici(satici, calisan);
            return saticiDTO;
        }

        public SaticiDTO updateSatici(SaticiDTO satici, CalisanDTO calisan)
        {
            SaticiDTO saticiDTO = saticiResources.updateSatici(satici, calisan);
            return saticiDTO;
        }
    }
}
