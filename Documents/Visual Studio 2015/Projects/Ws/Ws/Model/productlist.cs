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
    
    public partial class productlist
    {
        public int id { get; set; }
        public Nullable<System.DateTime> creationDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> isActive { get; set; }
        public int firmID { get; set; }
        public int productID { get; set; }
    
        public virtual firm firm { get; set; }
        public virtual product product { get; set; }
    }
}
