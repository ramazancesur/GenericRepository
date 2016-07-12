using Ws.Model;
using Ws.RestWs.Dto;
using test2.EntityDao.Firm;
using test2.EntityDao.Address;
using test2.EntityDao.Log;
using System.Linq;
using System.Collections.Generic;
using test2.EntityDao.Contact;
using System;

namespace Ws.EntityResources.Firma
{
    public class FirmResources:IFirmResources
    {
        FirmDao firmDao;
        AdressDao addressDao;
        LogDao logDao;
        ContactDao contactDao;
        public FirmResources()
        {
            init();
        }
        private void init()
        {
            firmDao = new FirmDao();
            addressDao = new AdressDao();
            logDao = new LogDao();
            contactDao = new ContactDao();
        }
        #region createFirm
        public FirmDTO createFirm(FirmDTO firmDTO, CalisanDTO calisanDTO)
        {
            firm firm = new firm();
            address address = addressDao.FindBy(x => x.address1 == firmDTO.address).FirstOrDefault();
            firm.addressID = address.id;
            firm.isActive = 1;
            firm.firmType = 1;
            firm.name = firmDTO.firmName;
            firm.updateDate = DateTime.Now;
            firm.creationDate = DateTime.Now;
            firmDao.Add(firm);
            #region log tablosu için
            log log = new log();
            log.isActive = 1;
          
            log.newValue = "Yeni Firma Eklendi " + firmDTO.firmName + "su id ye sahip " + firmDTO.ID + " şu kişi tarafondan " + calisanDTO.id;
            log.tableName = "firm";
            log.columnName = "all Columns";
            log.creationDate = DateTime.Now;
            log.employeeID = calisanDTO.id;
            log.updateDate = DateTime.Now;
            logDao.Add(log);
            #endregion
            return firmDTO;
        }
        #endregion

        #region allFirm is started
        public List<FirmDTO> allFirm()
        {
            List<FirmDTO> lstFirmDTO = new List<FirmDTO>();
            List<firm> lstFirms = firmDao.FindBy(x => x.isActive == 1).ToList();
            FirmDTO firmDTO;
            address address;
            contact contact;
            foreach (var firm in lstFirms)
            {
                firmDTO = new FirmDTO();
                address = new address();
                address = addressDao.findById(firm.id);
                firmDTO.address = address.address1;
                firmDTO.firmName = firm.name;
                firmDTO.ID = firm.id;
                if (firm.isActive.HasValue)
                {
                    firmDTO.isActive = firm.isActive.Value;
                }
                else
                {
                    firm.isActive = 0;
                    firmDao.Edit(firm);
                    firmDTO.isActive = 0;
                }
                contact = new contact();
                contact = contactDao.FindBy(x => x.id == firm.contactID).FirstOrDefault();
                firmDTO.phoneNumber1 = contact.value;
                try
                {
                    firmDTO.version = firmDTO.version + 1;
                }
                catch
                {
                    firmDTO.version = 1;
                }
                lstFirmDTO.Add(firmDTO);
            }
            return lstFirmDTO;
        }
        #endregion

        #region update Firm
        public FirmDTO updatedFirm(FirmDTO firmDTO,CalisanDTO calisanDTO)
        {
            firm firm = new firm();
            address address = addressDao.FindBy(x => x.address1 == firmDTO.address).FirstOrDefault();
            firm.addressID = address.id;
            firm.isActive = 1;
            firm.firmType = 1;
            firm.name = firmDTO.firmName;
            firm.updateDate = DateTime.Now;
            firm.creationDate = DateTime.Now;
            firmDao.Edit(firm);

            #region log tablosu için
            log log = new log();
            log.isActive = 1;
            log.newValue = "Firma update edildi " + firmDTO.firmName + "su id ye sahip " + firmDTO.ID + " şu kişi tarafondan " + calisanDTO.id ;
            log.tableName = "firm";
            log.columnName = "all Columns";
            log.creationDate = DateTime.Now;
            log.employeeID = calisanDTO.id;
            log.updateDate = DateTime.Now;
            logDao.Add(log);
            #endregion
            return firmDTO;

        }
        #endregion
        #region findbyName
        public List<FirmDTO> findbyName(string name)
        {
            List<FirmDTO> lstFirmDTO = new List<FirmDTO>();
            List<firm> lstFirms = firmDao.FindBy(x => x.name == name).ToList();
            FirmDTO firmDTO;
            address address;
            contact contact;
            foreach (var firm in lstFirms)
            {
                firmDTO = new FirmDTO();
                address = new address();
                address = addressDao.findById(firm.id);
                firmDTO.address = address.address1;
                firmDTO.firmName = firm.name;
                firmDTO.ID = firm.id;
                if (firm.isActive.HasValue)
                {
                    firmDTO.isActive = firm.isActive.Value;
                }
                else
                {
                    firm.isActive = 0;
                    firmDao.Edit(firm);
                    firmDTO.isActive = 0;
                }
                contact = new contact();
                contact = contactDao.FindBy(x => x.id == firm.contactID).FirstOrDefault();
                firmDTO.phoneNumber1 = contact.value;
                try
                {
                    firmDTO.version = firmDTO.version + 1;
                }
                catch
                {
                    firmDTO.version = 1;
                }
                lstFirmDTO.Add(firmDTO);
            }
            return lstFirmDTO;
        }
        #endregion
        
        #region Remove Firm
        public FirmDTO DeleteFirm(FirmDTO firmDTO,CalisanDTO calisanDTO)
        {
            firm firm = firmDao.FindBy(x => x.id == firmDTO.ID).FirstOrDefault();
            firm.isActive = 0;
            firmDao.Edit(firm);
            #region log tablosu için
            log log = new log();
            log.isActive = 1;
            log.newValue = "Firma Silindi " + firmDTO.firmName + "su id ye sahip " + firmDTO.ID + " şu kişi tarafondan " + calisanDTO.id ;
            log.tableName = "firm";
            log.columnName = "all Columns";
            log.creationDate = DateTime.Now;
            log.employeeID = calisanDTO.id;
            log.updateDate = DateTime.Now;
            logDao.Add(log);
            #endregion
            return firmDTO;
        }
        #endregion
    }
}