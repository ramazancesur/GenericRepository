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
    public class MusteriResources:IMusteriResources
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
        public MusteriDTO findMusteriByClient(client client)
        {
            MusteriDTO musteri = new MusteriDTO();
            musteri.ID = client.id;
            if (client.creationDate.HasValue)
            {
                musteri.createTime = client.creationDate.Value;
            }
            else
            {
                client.creationDate = DateTime.Now;
                clientDao.Edit(client);
                musteri.createTime = client.creationDate.Value;
            }

            if (client.updateDate.HasValue)
            {
                musteri.updateTime = client.updateDate.Value;
            }
            else
            {
                client.updateDate = DateTime.Now;
                clientDao.Edit(client);
                musteri.updateTime = client.updateDate.Value;
            }
            musteri.isActive = 1;
            musteri.name = client.name;
            musteri.note = client.note;
            musteri.surname = client.surname;
            musteri.clientName = client.name;
            musteri.version = 1;

            contact contact = contactDao.FindBy(x => x.id == client.contactID).LastOrDefault();
            musteri.phoneNumber1 = contact.value;

            address addres = addressDao.findById(client.addressID);
            musteri.address = addres.address1;
            return musteri;

        }

        #region allMusteri
        public List<MusteriDTO> lstMusteriDTO()
        {
            List<MusteriDTO> lstMusteri = new List<MusteriDTO>();
            List<client> lstClient = clientDao.FindBy(x => x.isActive == 1).ToList();
            MusteriDTO musteri;
            foreach (var client in lstClient)
            {
                musteri = new MusteriDTO();
                musteri = findMusteriByClient(client);
                lstMusteri.Add(musteri);
            }

            return lstMusteri;
        }
        #endregion

        #region Musteri Guncelleme
        public MusteriDTO updateMusteri(MusteriDTO musteri, CalisanDTO calisan)
        {
            // ********* Address Update ********* //
            address address = addressDao.FindBy(x => x.address1 == musteri.address).LastOrDefault();
            if (address == null)
            {
                address = new address();
                address.isActive = 1;
                address.creationDate = DateTime.Now;
                address.updateDate = DateTime.Now;
                address.address1 = musteri.address;
                addressDao.Add(address);
                createLog.SaveLog(calisan, addressDao, 1);
            }
            else
            {
                address.updateDate = DateTime.Now;
                addressDao.Edit(address);
                createLog.SaveLog(calisan, addressDao, 2);
            }

            // ********* Contact Update  ************ //
            contact contact = contactDao.FindBy(x => x.value == musteri.phoneNumber1).LastOrDefault();
            if (contact == null)
            {
                contact = new contact();
                contact.isActive = 1;
                contact.creationDate = DateTime.Now;
                contact.updateDate = DateTime.Now;
                contact.value = musteri.phoneNumber1;
                contact.contactType = (int)ContactType.CLIENT;
                contactDao.Add(contact);
                createLog.SaveLog(calisan, contact, 1);
            }
            else
            {
                contact.updateDate = DateTime.Now;
                contactDao.Edit(contact);
                createLog.SaveLog(calisan, contact, 2);
            }

            // ******* Client İşlemleri ******* //

            client client = clientDao.FindBy(x => x.id == musteri.ID).FirstOrDefault();
            client.updateDate = DateTime.Now;
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

        #endregion

        #region deleteMusteri
        public MusteriDTO deleteMusteri(MusteriDTO musteri, CalisanDTO calisan)
        {
            // *********** address delete *********** //
            List<address> lstAddress = addressDao.FindBy(x => x.address1 == musteri.address).ToList();
            foreach (var address in lstAddress)
            {
                address.isActive = 0;
                address.updateDate = DateTime.Now;
                addressDao.Edit(address);
                createLog.SaveLog(calisan, address, 0);
            }
            // *********** Contact Delete ************* //
            List<contact> lstContact = contactDao.FindBy(x => x.value == musteri.address).ToList();
            foreach (var contact in lstContact)
            {
                contact.isActive = 0;
                contact.updateDate = DateTime.Now;
                contactDao.Edit(contact);
                createLog.SaveLog(calisan, contact, 0);
            }
            // ******* Client Delete ********* //
            client client = clientDao.FindBy(x => x.id == musteri.ID).FirstOrDefault();
            client.updateDate = DateTime.Now;
            client.isActive = 0;
            clientDao.Edit(client);

            return musteri;
        }

        #endregion

        #region createMusteri
        public MusteriDTO createMusteri(MusteriDTO musteri, CalisanDTO calisan)
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
            contact.contactType = (int)ContactType.CLIENT;
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
        #endregion
    }
}