using test2.EntityDao.GenericDao;
using Ws.Model;
namespace test2.EntityDao.Address
{
    interface IAdressRepo:IGenericRepository<address>
    {
        address findById(int ID);      
    }
}
