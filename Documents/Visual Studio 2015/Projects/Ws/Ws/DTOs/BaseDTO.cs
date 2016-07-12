using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ws.RestWs.Dto
{
    public class BaseDTO
    {
        public int ID { get; set; }
        public string name { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public int isActive { get; set; }
        public int version { get; set; }

    }
    
}