using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ws.RestWs.Dto
{
    public class LisanceDTO:BaseDTO
    {
        public string licenceKey{ get; set; }
        public SaticiDTO satici { get; set; }
        public DateTime lisansStartTime { get; set; }
        public DateTime lisansEndTime { get; set; } 
    }
}