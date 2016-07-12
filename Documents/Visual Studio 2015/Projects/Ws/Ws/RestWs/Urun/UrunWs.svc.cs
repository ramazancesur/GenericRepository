using System.Collections.Generic;
using System.ServiceModel;
using Ws.EntityResources.Urun;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Urun
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UrunWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UrunWs.svc or UrunWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class UrunWs : IUrunWs
    {
        IUrunResources urunResources;
        public UrunWs()
        {
            init();
        }
        private void init()
        {
            urunResources = new UrunResources();
        }
        public UrunDTO createUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO)
        {
            UrunDTO urun = urunResources.createUrunDTO(urunDTO, createdCalisanDTO);
            return urun;
        }

        public UrunDTO deleteUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO, int firmID)
        {
            UrunDTO urun = urunResources.deleteUrunDTO(urunDTO, createdCalisanDTO, firmID);
            return urun;
        }   
       
        public FirmDTO findByFirm(CalisanDTO calisanDTO, UrunDTO urun)
        {
            throw new System.Exception();
            FirmDTO firm = urunResources.findByFirm(calisanDTO, urun);
            return firm;
        }
       

        public List<UrunDTO> getAll(CalisanDTO calisanDTO)
        {
            List<UrunDTO> lstUrun = urunResources.getAll(calisanDTO);
            return lstUrun;
        }

        public UrunDTO updateUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO)
        {
            UrunDTO urun = urunResources.updateUrunDTO(urunDTO, createdCalisanDTO);
            return urun;
        }
    }
}
