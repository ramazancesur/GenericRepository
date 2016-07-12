using System.Collections.Generic;
using System.ServiceModel;
using Ws.EntityResources.Musteri;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Musteri
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MusteriWs" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MusteriWs.svc or MusteriWs.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MusteriWs : IMusteriWs
    {
        IMusteriResources musteriResources;
        public MusteriWs()
        {
            init();
        }
        private void init()
        {
            musteriResources = new MusteriResources();
        }
        public MusteriDTO createMusteri(MusteriDTO musteri, CalisanDTO calisan)
        {
            MusteriDTO musteriDTO = musteriResources.createMusteri(musteri, calisan);
            return musteriDTO;
        }

        public MusteriDTO deleteMusteri(MusteriDTO musteri, CalisanDTO calisan)
        {
            MusteriDTO musteriDTO = musteriResources.deleteMusteri(musteri, calisan);
            return musteriDTO;
        }

        public MusteriDTO findMusteriByClient(client client)
        {
            MusteriDTO musteri = musteriResources.findMusteriByClient(client);
            return musteri;
        }

        public List<MusteriDTO> lstMusteriDTO()
        {
            List<MusteriDTO> lstMusteri = musteriResources.lstMusteriDTO();
            return lstMusteri;
        }

        public MusteriDTO updateMusteri(MusteriDTO musteri, CalisanDTO calisan)
        {
            MusteriDTO musteriDTO = musteriResources.updateMusteri(musteri, calisan);
            return musteriDTO;
        }
    }
}
