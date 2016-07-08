using System;
using System.Collections.Generic;
using System.Linq;
using test2.EntityDao.Address;
using test2.EntityDao.Contact;
using test2.EntityDao.Employee;
using test2.EntityDao.Firm;
using test2.EntityDao.Role;
using Ws.Helper;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Satici
{
    public class SaticiResources
    {
        EmployeeDao employeeDao;
        AdressDao addresDao;
        FirmDao firmDao;
        CreateLog createLog;
        RoleDao roleDao;
        ContactDao contactDao;
        public SaticiResources()
        {
            init();
        }
        private void init()
        {
            firmDao = new FirmDao();
            addresDao = new AdressDao();
            employeeDao = new EmployeeDao();
            createLog = new CreateLog();
            roleDao = new RoleDao();
            contactDao = new ContactDao();
        }
        public List<SaticiDTO> allSaticiDTO()
        {
            List<SaticiDTO> lstSaticiDto = new List<SaticiDTO>();
            SaticiDTO satici;
            List<employee> lstEmployee = employeeDao.FindBy(x => x.isActive == 1).ToList();
            foreach (var emp in lstEmployee)
            {
                // *********** employee ********** //
                satici = new SaticiDTO();
                satici.isActive = 1;
                if (emp.creationDate.HasValue)
                    satici.createTime = emp.creationDate.Value;
                else
                {
                    satici.createTime = DateTime.Now;
                    emp.creationDate = DateTime.Now;
                    employeeDao.Edit(emp);
                }
                if (emp.updateDate.HasValue)
                    satici.updateTime = emp.updateDate.Value;
                else
                {
                    emp.updateDate = DateTime.Now;
                    employeeDao.Edit(emp);
                    satici.updateTime = DateTime.Now;
                }

                satici.version = 1;
                satici.name = emp.username;
                satici.passwd = emp.password;
                try
                {
                    satici.roleName = roleDao.FindBy(x => x.id == emp.roleID).FirstOrDefault().name;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                satici.sallerName = emp.username;
                
                // *********** firm islemleri ************** //
                           
                firm firm = firmDao.FindBy(x => x.id == emp.firmID).FirstOrDefault();
                satici.campanyName = firm.name;
                try
                {
                    satici.address = addresDao.findById(firm.addressID).address1;
                }
                catch(Exception ex)
                {
                    satici.address = "";
                    Console.WriteLine(ex.Message);
                }
                satici.companyLogoPath = firm.logo;
                
                // *********** Contact table ********** //
                contact contact = contactDao.FindBy(z => z.id == firm.contactID).FirstOrDefault();
                if (contact.contactType.HasValue)
                {
                    ContactType conType = (ContactType)Enum.ToObject(typeof(ContactType), contact.contactType.Value);
                    satici.contactType = conType;
                }
                satici.phoneNumber = contact.value;
                satici.id = emp.id;
                lstSaticiDto.Add(satici);
            }

            return lstSaticiDto;
        }
        public SaticiDTO deleteSatici(SaticiDTO satici, CalisanDTO calisan)
        {
            // ********* address deleted ******** //
            List<address> lstAddress = addresDao.FindBy(x => x.address1 == satici.address
                                               && x.isActive == 1).ToList();
            foreach (var address in lstAddress)
            {
                address.updateDate = DateTime.Now;
                address.isActive = 0;
                addresDao.Edit(address);
                createLog.SaveLog(calisan, address, 0);
            }
            // ********** Firm deleted ************** //
            List<firm> lstFirm = firmDao.FindBy(x => x.name == satici.campanyName && x.isActive == 1).ToList();
            foreach (var firm in lstFirm)
            {
                firm.updateDate = DateTime.Now;
                firm.isActive = 0;
                firmDao.Edit(firm);
                createLog.SaveLog(calisan, firm, 0);
            }
            // ********* Employee deleted ********* //
            List<employee> lstEmployee = employeeDao.FindBy(x => x.title == satici.name && x.creationDate.Value.ToShortTimeString() == satici.createTime.ToShortTimeString()
                           && x.isActive == 1).ToList();
            foreach (var emp in lstEmployee)
            {
                emp.isActive = 0;
                emp.updateDate = DateTime.Now;
                employeeDao.Edit(emp);
                createLog.SaveLog(calisan, emp, 0);
            }
            // ****** Contact deleted ******** //
            List<contact> lstContact = contactDao.FindBy(x => x.value == satici.phoneNumber).ToList();
            foreach (var contact in lstContact)
            {
                contact.isActive = 0;
                contact.updateDate = DateTime.Now;
                contactDao.Edit(contact);
                createLog.SaveLog(calisan, contact, 0);
            }
            return satici;
        }
        #region updateSatici
        public SaticiDTO updateSatici(SaticiDTO satici, CalisanDTO calisan)
        {
            // ********* address updated ******** //
            address address = addresDao.FindBy(x => x.creationDate.Value.ToShortTimeString() == satici.createTime.ToShortTimeString()
                                               && x.isActive == 1).FirstOrDefault();
            address.address1 = satici.address;
            address.updateDate = DateTime.Now;
            addresDao.Edit(address);
            createLog.SaveLog(calisan, address, 2);
            // ********** Firm Updated ************** //
            List<firm> lstFirm = firmDao.FindBy(x => x.name == satici.campanyName && x.isActive == 1).ToList();
            foreach (var firm in lstFirm)
            {
                firm.updateDate = DateTime.Now;
                firm.isActive = satici.isActive;
                firm.logo = satici.companyLogoPath;
                firmDao.Add(firm);
                createLog.SaveLog(calisan, firm, 2);
            }
            // ********* Employee Updated ********* //
            List<employee> lstEmployee = employeeDao.FindBy(x => x.title == satici.name && x.creationDate.Value.ToShortTimeString() == satici.createTime.ToShortTimeString()
                             && x.isActive == 1).ToList();
            foreach (var emp in lstEmployee)
            {
                try
                {
                    emp.firmID = lstFirm[0].id;
                    emp.isActive = 1;
                    emp.updateDate = DateTime.Now;
                    emp.username = satici.sallerName;
                    emp.title = satici.name;
                    emp.password = satici.passwd;
                    try
                    {
                        emp.roleID = roleDao.FindBy(x => x.name == satici.roleName && x.isActive == 1).LastOrDefault().id;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    employeeDao.Add(emp);
                    createLog.SaveLog(calisan, emp, 2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // ****** Contact Insertion ******** //
            contact contact = contactDao.FindBy(x => x.value == satici.phoneNumber).FirstOrDefault();
            contact.contactType = (int)satici.contactType;
            contact.updateDate = DateTime.Now;
            contactDao.Edit(contact);
            createLog.SaveLog(calisan, contact, 2);

            return satici;
        }
        #endregion

        #region createSatici
        public SaticiDTO createSatici(SaticiDTO satici, CalisanDTO calisan)
        {
            // ********* address adding ******** //
            address address = new address();
            address.address1 = satici.address;
            address.isActive = 1;
            address.regionID = 0;
            address.creationDate = DateTime.Now;
            address.updateDate = DateTime.Now;
            addresDao.Add(address);
            createLog.SaveLog(calisan, address, 1);
            // ********** Firm Eklendi ************** //
            firm firm = new firm();
            firm.creationDate = DateTime.Now;
            firm.updateDate = DateTime.Now;
            firm.isActive = 1;
            firm.name = satici.campanyName;
            firm.addressID = address.id;
            firm.logo = satici.companyLogoPath;
            firmDao.Add(firm);
            createLog.SaveLog(calisan, firm, 1);

            // ********* Employee Insertion ********* //
            employee emp = new employee();
            emp.firmID = firm.id;
            emp.isActive = 1;
            emp.creationDate = DateTime.Now;
            emp.updateDate = DateTime.Now;
            emp.username = satici.sallerName;
            emp.title = satici.name;
            emp.password = satici.passwd;
            try
            {
                emp.roleID = roleDao.FindBy(x => x.name == satici.roleName && x.isActive == 1).LastOrDefault().id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            employeeDao.Add(emp);
            createLog.SaveLog(calisan, emp, 1);
            // ****** Contact Insertion ******** //
            contact contact = new contact();
            contact.creationDate = DateTime.Now;
            contact.updateDate = DateTime.Now;
            contact.isActive = 1;
            contact.contactType = (int)satici.contactType;
            contact.value = satici.phoneNumber;
            contactDao.Add(contact);
            createLog.SaveLog(calisan, contact, 1);

            return satici;
        }
        #endregion
    }
}
