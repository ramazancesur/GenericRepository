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
    
    public partial class employee
    {
        public employee()
        {
            this.log = new HashSet<log>();
            this.order = new HashSet<order>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> creationDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> isActive { get; set; }
        public string title { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int firmID { get; set; }
        public int roleID { get; set; }
    
        public virtual firm firm { get; set; }
        public virtual role role { get; set; }
        public virtual ICollection<log> log { get; set; }
        public virtual ICollection<order> order { get; set; }
    }
}
