using System;
using System.Collections.Generic;
using System.ServiceModel;
using Ws.EntityResources.Siparis;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Siparis
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SiparisWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SiparisWs.svc or SiparisWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SiparisWs : ISiparisWs
    {
        ISiparisResources siparisResources;
        public SiparisWs()
        {
            init();
        }
        private void init()
        {
            siparisResources = new SiparisResources();
        }
        public List<OdemeDTO> allOdeme()
        {
            List<OdemeDTO> lstOdeme = siparisResources.allOdeme();
            return lstOdeme;
        }

        public List<OdemeDetayDTO> allOdemeDetay(OdemeDTO odeme)
        {
            List<OdemeDetayDTO> lstOdemeDetay = siparisResources.allOdemeDetay(odeme);
            return lstOdemeDetay;
        }

        public List<SiparisDTO> allSiparis()
        {
            List<SiparisDTO> lstSiparis = siparisResources.allSiparis();
            return lstSiparis;
        }

        public List<SiparisDetailDTO> allSiparisDetay(SiparisDTO siparis, CalisanDTO calisanDTO)
        {
            List<SiparisDetailDTO> lstSiparisDetail = siparisResources.allSiparisDetay(siparis, calisanDTO);
            return lstSiparisDetail;
        }

        public OdemeDTO createOdeme(OdemeDTO odeme, CalisanDTO calisan)
        {
            OdemeDTO odemeDTO = siparisResources.createOdeme(odeme, calisan);
            return odemeDTO;
        }

        public SiparisDTO createSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan)
        {
            SiparisDTO siparisDTO = siparisResources.createSiparisDTO(siparis, odeme, calisan);
            return siparisDTO;
        }

        public OdemeDTO deleteOdemeDTO(OdemeDTO odeme, CalisanDTO calisan)
        {
            OdemeDTO odemeDTO = siparisResources.deleteOdemeDTO(odeme, calisan);
            return odemeDTO;
        }

        public SiparisDTO deleteSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan)
        {
            SiparisDTO siparisDTO = siparisResources.deleteSiparisDTO(siparis, odeme, calisan);
            return siparisDTO;
        }

        public OdemeDTO updateOdemeDTO(OdemeDTO odeme, CalisanDTO calisan)
        {
            OdemeDTO odemeDTO = siparisResources.updateOdemeDTO(odeme, calisan);
            return odemeDTO;
        }

        public SiparisDTO updateSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan)
        {
            SiparisDTO siparisDTO = siparisResources.updateSiparisDTO(siparis, odeme, calisan);
            return siparisDTO;
        }
    }
}
