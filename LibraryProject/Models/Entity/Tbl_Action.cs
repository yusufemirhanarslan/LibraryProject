//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryProject.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Action
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Action()
        {
            this.Tbl_Punishment = new HashSet<Tbl_Punishment>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Book { get; set; }
        public Nullable<int> Users { get; set; }
        public Nullable<byte> Staff { get; set; }
        public Nullable<System.DateTime> Ship_Date { get; set; }
        public Nullable<System.DateTime> Return_Date { get; set; }
        public Nullable<bool> Action_State { get; set; }
        public Nullable<System.DateTime> Delivery_Date { get; set; }
    
        public virtual Tbl_Book Tbl_Book { get; set; }
        public virtual Tbl_Users Tbl_Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Punishment> Tbl_Punishment { get; set; }
        public virtual Tbl_Staff Tbl_Staff { get; set; }
    }
}
