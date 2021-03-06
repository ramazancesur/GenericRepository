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
    
    public partial class order
    {
        public order()
        {
            this.orderdetail = new HashSet<orderdetail>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> creationDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> isActive { get; set; }
        public Nullable<int> deliveryStatus { get; set; }
        public Nullable<System.DateTime> deliveryDate { get; set; }
        public int firmID { get; set; }
        public int clientID { get; set; }
        public int paymentID { get; set; }
        public int employeeID { get; set; }
        public Nullable<int> totalPrice { get; set; }
        public string Notes { get; set; }
    
        public virtual client client { get; set; }
        public virtual employee employee { get; set; }
        public virtual firm firm { get; set; }
        public virtual payment payment { get; set; }
        public virtual ICollection<orderdetail> orderdetail { get; set; }
    }
}
