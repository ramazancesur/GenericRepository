using System;
using System.Collections.Generic;
using System.Linq;
using test2.EntityDao.Address;
using test2.EntityDao.Client;
using test2.EntityDao.Contact;
using Ws.Helper;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Musteri
{
    public class MusteriResources
    {
        ClientDao clientDao;
        AdressDao addressDao;
        CreateLog createLog;
        ContactDao contactDao;

        public MusteriResources()
        {
            init();
        }
        private void init()
        {
            clientDao = new ClientDao();
            addressDao = new AdressDao();
            createLog = new CreateLog();
            contactDao = new ContactDao();
        }

        public MusteriDTO createMusteri(MusteriDTO musteri,CalisanDTO calisan)
        {
            // ******** address is inserting ******** //
            address address = new address();
            address.isActive = 1;
            address.creationDate = DateTime.Now;
            address.updateDate = DateTime.Now;
            address.address1 = musteri.address;
            addressDao.Add(address);
            createLog.SaveLog(calisan, addressDao, 1);

            // ******* Contact create ******* //
            contact contact = new contact();
            contact.isActive = 1;
            contact.creationDate = DateTime.Now;
            contact.updateDate = DateTime.Now;
            contact.value = musteri.phoneNumber1;
            contact.contactType =(int) ContactType.CLIENT;
            contactDao.Add(contact);
            createLog.SaveLog(calisan, contact, 1);

            // ******* Client create ******* //
            client client = new client();
            client.creationDate = DateTime.Now;
            client.updateDate = DateTime.Now;
            client.isActive = 1;
            client.note = musteri.note;
            client.title = musteri.name;
            client.name = musteri.name;
            client.surname = musteri.surname;
            client.addressID = address.id;
            client.contactID = contact.id;
            clientDao.Add(client);
            createLog.SaveLog(calisan, client, 1);
                      
            return musteri;
        }
     }
}