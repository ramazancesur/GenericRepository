using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Satici
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SaticiWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SaticiWs.svc or SaticiWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SaticiWs : ISaticiWs
    {
        public List<SaticiDTO> allSaticiDTO()
        {
            throw new NotImplementedException();
        }

        public SaticiDTO createSatici(SaticiDTO satici, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }

        public SaticiDTO deleteSatici(SaticiDTO satici, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }

        public SaticiDTO updateSatici(SaticiDTO satici, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }
    }
}
