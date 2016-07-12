using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ws.RestWs.Dto
{
    public class FirmDTO:BaseDTO
    {
        public string firmName { get; set; }
        public string address { get; set; }
        public string phoneNumber1 { get; set; }

        
    }
}