using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test2.EntityDao.Log;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.Helper
{
    public class CreateLog
    {
        log log;
        LogDao logDao;
        private void init()
        {
            log = new log();
            logDao = new LogDao();
        }
        public CreateLog()
        {
            init();
        }
        /// <summary>
        /// Log tablosuna veri kaydeder
        /// </summary>
        /// <typeparam name="T">işlem yapılan tablo</typeparam>
        /// <param name="createdCalisanDTO"></param>
        /// <param name="tableName">işlem yapılan tablo</param>
        /// <param name="state">Delete=0  Insert=1  Update=2 </param>
        /// <returns></returns>
        public log SaveLog<T>(CalisanDTO createdCalisanDTO, T tableName,int state) where T:class
        {
            #region Logs
            log = new log();
            string info = "";
            if (state == 0)
            {
                info = "Silme Işlemi";
            }
            else if (state == 1)
            {
                info = "Ekleme işlemi";
            }
            else
            {
                info = "Guncelleme Işlemi";
            }
            log.isActive = 1;
            if (createdCalisanDTO.nameSurname != null)
            {
              
                log.newValue = info+" gerçekleşen tablo " +tableName.GetType().GetProperty("name") + "su id ye sahip " + tableName.GetType().GetProperty("ID") + " şu kişi tarafondan " + createdCalisanDTO.id;
            }
            log.tableName = tableName.GetType().Name;
            log.columnName = "all Columns";
            log.creationDate = DateTime.Now;
            log.employeeID = createdCalisanDTO.id;
            log.updateDate = DateTime.Now;
            logDao.Add(log);
            #endregion
            return log;
        }
    }
}