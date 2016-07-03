using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test2.EntityDao.GenericDao;
using test2.Model;

namespace test2.EntityDao.Client
{
    interface IClientRepo: IGenericRepository<client>
    {
    }
}
