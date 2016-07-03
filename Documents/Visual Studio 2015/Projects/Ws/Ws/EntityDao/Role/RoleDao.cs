using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test2.EntityDao.GenericDao;
using test2.Model;

namespace test2.EntityDao.Role
{
    public class RoleDao: GenericRepository<TestProjectEntities, role>
    {
    }
}