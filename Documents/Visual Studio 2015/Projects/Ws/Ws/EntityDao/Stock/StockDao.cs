using System.Collections.Generic;
using test2.EntityDao.GenericDao;
using test2.Model;

namespace test2.EntityDao.Stock
{
    public class StockDao: GenericRepository<TestProjectEntities, stock>
    {
        TestProjectEntities test = new TestProjectEntities();
        public address findById(int ID)
        {
            address Address = Context.address.Find(ID);
            
            return Address;


        }
    }
}