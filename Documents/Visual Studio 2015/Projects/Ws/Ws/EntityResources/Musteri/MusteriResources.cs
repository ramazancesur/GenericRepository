using System;
using System.Collections.Generic;
using System.Linq;
using test2.EntityDao.Client;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Musteri
{
    public class MusteriResources
    {
        ClientDao clientDao;
        public MusteriResources()
        {
            init();
        }
        private void init()
        {
            clientDao = new ClientDao();
        }

        public MusteriDTO createMusteri(MusteriDTO musteri,CalisanDTO calisan)
        {
            // ******* Client create ******* //
            client client = new client();
            client.creationDate = DateTime.Now;
            client.updateDate = DateTime.Now;
            client.isActive = 1;
            client.note = musteri.note;
            client.title = musteri.name;
            return musteri;
        }
     }
}