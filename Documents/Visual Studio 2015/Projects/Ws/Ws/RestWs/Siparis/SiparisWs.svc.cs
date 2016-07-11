using System;
using System.Collections.Generic;
using System.ServiceModel;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Siparis
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SiparisWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SiparisWs.svc or SiparisWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SiparisWs : ISiparisWs
    {
        public List<OdemeDTO> allOdeme()
        {
            throw new NotImplementedException();
        }

        public List<OdemeDetayDTO> allOdemeDetay(OdemeDTO odeme)
        {
            throw new NotImplementedException();
        }

        public List<SiparisDTO> allSiparis()
        {
            throw new NotImplementedException();
        }

        public List<SiparisDetailDTO> allSiparisDetay(SiparisDTO siparis, CalisanDTO calisanDTO)
        {
            throw new NotImplementedException();
        }

        public OdemeDTO createOdeme(OdemeDTO odeme, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }

        public SiparisDTO createSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }

        public OdemeDTO deleteOdemeDTO(OdemeDTO odeme, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }

        public SiparisDTO deleteSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }

        public OdemeDTO updateOdemeDTO(OdemeDTO odeme, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }

        public SiparisDTO updateSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }
    }
}
