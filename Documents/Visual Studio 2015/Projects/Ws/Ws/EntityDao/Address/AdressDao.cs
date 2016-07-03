using System;
using System.Collections.Generic;
using test2.EntityDao.GenericDao;
using test2.Model;

namespace test2.EntityDao.Address
{
    public class AdressDao : GenericRepository<TestProjectEntities, address>, IAdressRepo
    {
        public address findById(int ID)
        {
            address Address = Context.address.Find(ID);
     
            return Address;

        }

    }
}