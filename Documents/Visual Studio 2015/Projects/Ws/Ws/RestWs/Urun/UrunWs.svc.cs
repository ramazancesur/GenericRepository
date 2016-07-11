using System;
using System.Collections.Generic;
using System.ServiceModel;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Urun
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UrunWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UrunWs.svc or UrunWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class UrunWs : IUrunWs
    {
        public UrunDTO createUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO)
        {
            throw new NotImplementedException();
        }

        public UrunDTO deleteUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO, int firmID)
        {
            throw new NotImplementedException();
        }

        public FirmDTO findByFirm(CalisanDTO calisanDTO, UrunDTO urun)
        {
            throw new NotImplementedException();
        }

        public List<UrunDTO> getAll(CalisanDTO calisanDTO)
        {
            throw new NotImplementedException();
        }

        public UrunDTO updateUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO)
        {
            throw new NotImplementedException();
        }
    }
}
