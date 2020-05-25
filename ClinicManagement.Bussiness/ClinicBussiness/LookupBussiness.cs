using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DAL;
using ClinicManagement.Bussiness.ClinicModelMV;
using ClinicManagement.Bussiness.Enums;

namespace ClinicManagement.Bussiness.ClinicBussiness
{
  public  class LookupBussiness
    {
        ClinicManagementEntities clinic = new ClinicManagementEntities();

        public List<Lookups> fillcity()
        {
            var city = clinic.CityTBLs;

            return city.Select(e => new Lookups
            {
                id = e.id,
                name = e.CityName,

            }).ToList();
        }
        public List<Lookups> fillarea(int ?city)
        {
            var area = clinic.AreaTBLs.Where(c=>c.CityId==city);

            return area.Select(e => new Lookups
            {
                id = e.id,
                name = e.AreaName,

            }).ToList();
        }


        public List<Lookups> fillMedicin()
        {
            var Medicin = clinic.MedicalTBLs;

            return Medicin.Select(e => new Lookups
            {
                id = e.id,
                name = e.MedicalName,

            }).ToList();
        }

        public List<Lookups> fillspec()
        {
            var Medicin = clinic.SpecialtyTBLs;

            return Medicin.Select(e => new Lookups
            {
                id = e.id,
                name = e.SpecialtyName,

            }).ToList();
        }




        public List<Lookups> fillpatient()
        {
            var patient = clinic.PatientTBLs;

            return patient.Select(e => new Lookups
            {
                id = e.PatientId,
                name = e.PatientName,

            }).ToList();
        }


        public List<Lookups> filldoctor()
        {
            var doctor = clinic.DoctorTBLs;

            return doctor.Select(e => new Lookups
            {
                id = e.Doctorid,
                name = e.DoctorName,
            }).ToList();
        }



        public List<Lookups> filldoctorwithspec(int id)
        {
            var doctor = clinic.DoctorTBLs.Where(d=>d.Specialtyid==id);

            return doctor.Select(e => new Lookups
            {
                id = e.Doctorid,
                name = e.DoctorName,
            }).ToList();
        }




    


    }
}
