using System.Linq;
using test2.EntityDao.GenericDao;
using Ws.Model;

namespace test2.EntityDao.Address
{
    public class AdressDao : GenericRepository<sql8126141Entities, address>, IAdressRepo
    {
        public address findById(int ID)
        {
            address Addres = Context.address.Where(x => x.id == ID).FirstOrDefault() ;
            return Addres;
        }

    }
}