//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicManagement.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AreaTBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AreaTBL()
        {
            this.DoctorTBLs = new HashSet<DoctorTBL>();
            this.PatientTBLs = new HashSet<PatientTBL>();
        }
    
        public int id { get; set; }
        public string AreaName { get; set; }
        public Nullable<int> CityId { get; set; }
    
        public virtual CityTBL CityTBL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoctorTBL> DoctorTBLs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientTBL> PatientTBLs { get; set; }
    }
}
