using System;
using System.Collections.Generic;
using System.ServiceModel;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Calisan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalisanWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CalisanWs.svc or CalisanWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CalisanWs : ICalisanWs
    {
        public List<CalisanDTO> allCaliisanList()
        {
            throw new NotImplementedException();
        }

        public CalisanDTO createCalisan(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO)
        {
            throw new NotImplementedException();
        }

        public CalisanDTO removeCalisan(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO)
        {
            throw new NotImplementedException();
        }

        public CalisanDTO updateEmployee(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO)
        {
            throw new NotImplementedException();
        }
    }
}
