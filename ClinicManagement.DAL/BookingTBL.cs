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
    
    public partial class BookingTBL
    {
        public int id { get; set; }
        public Nullable<int> patientid { get; set; }
        public Nullable<int> Specialtyid { get; set; }
        public Nullable<int> Doctorid { get; set; }
        public Nullable<System.DateTime> BookingPagedata { get; set; }
        public Nullable<System.DateTime> DateBooking { get; set; }
        public Nullable<System.DateTime> FinishTime { get; set; }
        public string type { get; set; }
    
        public virtual DoctorTBL DoctorTBL { get; set; }
        public virtual SpecialtyTBL SpecialtyTBL { get; set; }
        public virtual PatientTBL PatientTBL { get; set; }
    }
}
