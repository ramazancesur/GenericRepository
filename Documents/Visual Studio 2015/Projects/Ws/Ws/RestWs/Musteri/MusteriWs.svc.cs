using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Musteri
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MusteriWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MusteriWs.svc or MusteriWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MusteriWs : IMusteriWs
    {
        public MusteriDTO createMusteri(MusteriDTO musteri, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }

        public MusteriDTO deleteMusteri(MusteriDTO musteri, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }

        public MusteriDTO findMusteriByClient(client client)
        {
            throw new NotImplementedException();
        }

        public List<MusteriDTO> lstMusteriDTO()
        {
            throw new NotImplementedException();
        }

        public MusteriDTO updateMusteri(MusteriDTO musteri, CalisanDTO calisan)
        {
            throw new NotImplementedException();
        }
    }
}
