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
    
    public partial class stockdetail
    {
        public int id { get; set; }
        public Nullable<System.DateTime> creationDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> isActive { get; set; }
        public Nullable<int> amount { get; set; }
        public Nullable<int> unitType { get; set; }
        public Nullable<int> unitSize { get; set; }
        public int priceID { get; set; }
        public int stockID { get; set; }
    
        public virtual price price { get; set; }
        public virtual stock stock { get; set; }
    }
}
