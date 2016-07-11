using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Firma
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FirmWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FirmWs.svc or FirmWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FirmWs : IFirmWs
    {
        public List<FirmDTO> allFirm()
        {
            throw new NotImplementedException();
        }

        public FirmDTO createFirm(FirmDTO firmDTO, CalisanDTO calisanDTO)
        {
            throw new NotImplementedException();
        }

        public FirmDTO DeleteFirm(FirmDTO firmDTO, CalisanDTO calisanDTO)
        {
            throw new NotImplementedException();
        }

        public List<FirmDTO> findbyName(string name)
        {
            throw new NotImplementedException();
        }

        public FirmDTO updatedFirm(FirmDTO firmDTO, CalisanDTO calisanDTO)
        {
            throw new NotImplementedException();
        }
    }
}
