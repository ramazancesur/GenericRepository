using System;
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

            // ********* Emloyee Insertion ********* //
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
    }
}
