﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClinicManagementEntities : DbContext
    {
        public ClinicManagementEntities()
            : base("name=ClinicManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AreaTBL> AreaTBLs { get; set; }
        public virtual DbSet<CityTBL> CityTBLs { get; set; }
        public virtual DbSet<DoctorTBL> DoctorTBLs { get; set; }
        public virtual DbSet<MedicalFileDetalisTBL> MedicalFileDetalisTBLs { get; set; }
        public virtual DbSet<MedicalFilesMedicinTBL> MedicalFilesMedicinTBLs { get; set; }
        public virtual DbSet<MedicalTBL> MedicalTBLs { get; set; }
        public virtual DbSet<SpecialtyTBL> SpecialtyTBLs { get; set; }
        public virtual DbSet<MedicalFileTBL> MedicalFileTBLs { get; set; }
        public virtual DbSet<BookingTBL> BookingTBLs { get; set; }
        public virtual DbSet<DoctorAppointmentsTBL> DoctorAppointmentsTBLs { get; set; }
        public virtual DbSet<PatientTBL> PatientTBLs { get; set; }
    }
}
