//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarWebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            this.CarRentalDetails = new HashSet<CarRentalDetail>();
        }
    
        public Nullable<int> CarType { get; set; }
        public Nullable<int> Mileage { get; set; }
        public byte[] Image { get; set; }
        public bool IsUndamaged { get; set; }
        public bool IsAvailable { get; set; }
        public string CarNumber { get; set; }
        public int BranchID { get; set; }
    
        public virtual Branch Branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarRentalDetail> CarRentalDetails { get; set; }
        public virtual CarType CarType1 { get; set; }
    }
}
