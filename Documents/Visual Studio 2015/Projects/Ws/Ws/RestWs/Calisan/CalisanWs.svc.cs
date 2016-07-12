using System;
using System.Collections.Generic;
using System.ServiceModel;
using Ws.EntityResources.Calisan;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Calisan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalisanWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CalisanWs.svc or CalisanWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CalisanWs : ICalisanWs
    {
        private ICalisanResources calisanResources;
        public CalisanWs()
        {
            init();
        }
        private void init()
        {
            calisanResources = new CalisanResources();
        }
        public List<CalisanDTO> allCaliisanList()
        {
            List<CalisanDTO> lstCalisan = calisanResources.allCalisanList();
            return lstCalisan;
        }

        public CalisanDTO createCalisan(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO)
        {
            CalisanDTO calisanDRTO = calisanResources.createCalisan(calisanDTO, createdCalisanDTO);
            return calisanDRTO;
        }

        public CalisanDTO removeCalisan(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO)
        {
            CalisanDTO calisanDRTO = calisanResources.removeCalisan(calisanDTO, createdCalisanDTO);
            return calisanDRTO;
        }

        public CalisanDTO updateEmployee(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO)
        {
            CalisanDTO calisanDRTO = calisanResources.updateEmployee(calisanDTO, createdCalisanDTO);
            return calisanDRTO;
        }
    }
}
