//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ws.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class region
    {
        public region()
        {
            this.address = new HashSet<address>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> creationDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> isActive { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<address> address { get; set; }
    }
}
