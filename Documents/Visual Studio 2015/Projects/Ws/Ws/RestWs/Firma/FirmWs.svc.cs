using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Ws.EntityResources.Firma;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Firma
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FirmWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FirmWs.svc or FirmWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FirmWs : IFirmWs
    {
        private IFirmResources firmResources;
        public FirmWs()
        {
            init();
        }
        private void init()
        {
            firmResources = new FirmResources();
        }
        public List<FirmDTO> allFirm()
        {
            List<FirmDTO> lstFirm = firmResources.allFirm();
            return lstFirm;
        }

        public FirmDTO createFirm(FirmDTO firmDTO, CalisanDTO calisanDTO)
        {
            FirmDTO firm = firmResources.createFirm(firmDTO, calisanDTO);
            return firm;
        }

        public FirmDTO DeleteFirm(FirmDTO firmDTO, CalisanDTO calisanDTO)
        {
            FirmDTO firm = firmResources.DeleteFirm(firmDTO, calisanDTO);
            return firm;
        }

        public List<FirmDTO> findbyName(string name)
        {
            List<FirmDTO> lstFirm = firmResources.findbyName(name);
            return lstFirm;
        }

        public FirmDTO updatedFirm(FirmDTO firmDTO, CalisanDTO calisanDTO)
        {
            FirmDTO firm = firmResources.updatedFirm(firmDTO, calisanDTO);
            return firm;
        }
    }
}
