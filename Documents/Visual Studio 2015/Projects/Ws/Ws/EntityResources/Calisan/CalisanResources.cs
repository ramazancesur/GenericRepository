using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test2.EntityDao.Address;
using test2.EntityDao.Employee;
using test2.EntityDao.Firm;
using test2.EntityDao.Log;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Calisan
{
    public class CalisanResources
    {
        LogDao logDao;
        EmployeeDao employeeDao;
        AdressDao addresDao;
        FirmDao firmDao;
        private void init()
        {
            logDao = new LogDao();
            employeeDao = new EmployeeDao();
            addresDao = new AdressDao();
            firmDao = new FirmDao();
        }
        public CalisanResources()
        {
            init();
        }
        #region createCalisan
        public CalisanDTO createCalisan(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO)
        {
            // **************** Employee Creation ******************* //
            employee employee = new employee();
            employee.id = calisanDTO.id;
            employee.isActive = 1;
            employee.firmID = calisanDTO.firmID;
            employee.username = calisanDTO.userName;
            employee.password = calisanDTO.passwd;
            employee.roleID = calisanDTO.roleID;
            employee.title = calisanDTO.title;
            employee.updateDate = DateTime.Now;
            employee.creationDate = DateTime.Now;
            employeeDao.Add(employee);
            // *************** Employee Creation End ****************** //
            #region log tablosu için
            log log = new log();
            log.isActive = 1;
            if (createdCalisanDTO.nameSurname != null)
            {
                log.newValue = "Yeni calisan Eklendi " + calisanDTO.nameSurname + "su id ye sahip " + calisanDTO.id + " şu kişi tarafondan " + createdCalisanDTO.id;
            }
            log.tableName = "firm";
            log.columnName = "all Columns";
            log.creationDate = DateTime.Now;
            log.employeeID = calisanDTO.id;
            log.updateDate = DateTime.Now;
            logDao.Add(log);
            #endregion
            return calisanDTO;
        }
        #endregion
        #region calisanların listesi
       
        public List<CalisanDTO> allCalisanList()
        {
            // *************** Employee Listesi ****************** //
          
            List<employee> lstEmployee = employeeDao.FindBy(x => x.isActive == 1).ToList();
            List<CalisanDTO> lstCalisan = new List<CalisanDTO>();
            CalisanDTO calisan;
            address address;
            foreach (var emp in lstEmployee)
            {
                calisan = new CalisanDTO();
                address = new address();
                firm firm = firmDao.FindBy(x => x.id == emp.firmID).FirstOrDefault();
                address = addresDao.FindBy(x => x.id == firm.addressID).FirstOrDefault();
                calisan.address = address.address1;
                if (emp.creationDate.HasValue)
                {
                    calisan.createTime = emp.creationDate.Value;
                }
                else
                {
                    emp.creationDate = DateTime.Now;
                    employeeDao.Edit(emp);
                    calisan.createTime = emp.creationDate.Value;
                }
                switch (emp.roleID)
                {
                    case 1:
                        calisan.employeeType = EmployeeType.PATRON;
                        break;
                    case 2:
                        calisan.employeeType = EmployeeType.ISCİ;
                        break;
                    case 3:
                        calisan.employeeType = EmployeeType.ARAC;
                        break;
                    case 4:
                        calisan.employeeType = EmployeeType.ADMIN;
                        break;
                    default:
                        break;
                }
                calisan.firmID = firm.id;
                calisan.id = emp.id;
                calisan.isActive = 1;
                calisan.nameSurname = emp.title+" "+emp.username;
                calisan.passwd = emp.password;
                calisan.roleID = emp.roleID;
                calisan.title = emp.title;
                if (emp.updateDate.HasValue)
                {
                    calisan.updateTime = emp.updateDate.Value;
                }
                else
                {
                    emp.updateDate = DateTime.Now;
                    employeeDao.Edit(emp);
                    calisan.updateTime = emp.updateDate.Value;
                }
                calisan.userName = emp.username;
                calisan.version += 1;
                lstCalisan.Add(calisan);
            }
            return lstCalisan;
        }
        #endregion

        #region Updated Employee
        public CalisanDTO updateEmployee(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO)
        {
            // ************ Employee entity state is passive **************** //
            employee emp = employeeDao.FindBy(x => x.id == calisanDTO.id).FirstOrDefault();
            if (emp != null)
            {
                employeeDao.Edit(emp);
            }
            else
            {
                return null;
            }
            // ************** Log Kaydı Databaseye Atıldı ************** //
            #region Logs
            log log = new log();
            log.isActive = 1;
            if (createdCalisanDTO.nameSurname != null)
            {
                log.newValue = "Çalışan Guncellendi  " + calisanDTO.nameSurname + "su id ye sahip " + calisanDTO.id + " şu kişi tarafondan " + createdCalisanDTO.id;
            }
            log.tableName = "firm";
            log.columnName = "all Columns";
            log.creationDate = DateTime.Now;
            log.employeeID = calisanDTO.id;
            log.updateDate = DateTime.Now;
            logDao.Add(log);
            #endregion
            return calisanDTO;
        }
        #endregion

        #region Delete Employee
        public CalisanDTO removeCalisan(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO)
        {
            // ************ Employee entity state is passive **************** //
            employee emp = employeeDao.FindBy(x => x.id == calisanDTO.id).FirstOrDefault();
            if (emp != null)
            {
                emp.isActive = 0;
                employeeDao.Edit(emp);
            }
            else
            {
                return null;
            }
            // ************** Log Kaydı Databaseye Atıldı ************** //
            #region Logs
            log log = new log();
            log.isActive = 1;
            if (createdCalisanDTO.nameSurname != null)
            {
                log.newValue = "Çalışan Silindi  " + calisanDTO.nameSurname + "su id ye sahip " + calisanDTO.id + " şu kişi tarafondan " + createdCalisanDTO.id;
            }
            log.tableName = "firm";
            log.columnName = "all Columns";
            log.creationDate = DateTime.Now;
            log.employeeID = calisanDTO.id;
            log.updateDate = DateTime.Now;
            logDao.Add(log);
            #endregion
            return calisanDTO;
        }

        #endregion
    }
}