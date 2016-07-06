using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ws.Model;
namespace Ws
{
    public class Class1
    {
        public void test()
        {
            sql8126141Entities sq = new sql8126141Entities();
            sq.address.Where(x => x.id == 2).ToList();  
        }
            
    }
}