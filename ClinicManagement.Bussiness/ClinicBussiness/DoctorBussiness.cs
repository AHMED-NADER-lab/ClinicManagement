using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DAL;
using ClinicManagement.Bussiness.ClinicModelMV;
using System.Collections;

namespace ClinicManagement.Bussiness.ClinicBussiness
{
   public class DoctorBussiness
    {

        ClinicManagementEntities clinic = new ClinicManagementEntities();

        public ResponseMV ValidateDoctor(DoctorMV viewmodel)
        {
            ResponseMV result = new ResponseMV();
            if (string.IsNullOrEmpty(viewmodel.DoctorName))
                result.ErrorMessages.Add("DoctorName", "not found name");
            if (viewmodel.Specialtyid==null)
                result.ErrorMessages.Add("spec", "not found name");



            result.IsValid = result.ErrorMessages.Count == 0 ? true : false;
            return result;
        }

        public List<DoctorMV> listofdoctor()
        {
            var doctor = clinic.DoctorTBLs;
            return doctor.Select(c => new DoctorMV
            {
                Doctorid = c.Doctorid,
                DoctorName = c.DoctorName,
                Email = c.Email,
                Phone = c.Phone,
                cityname = c.CityTBL.CityName,
                areaname = c.AreaTBL.AreaName,
                Age = c.Age,
                spec=c.SpecialtyTBL.SpecialtyName,
               
                
               

            }).ToList();
        }


        public DoctorMV Selectdoctor(int id)
        {

            var docctor = clinic.DoctorTBLs.Where(c => c.Doctorid == id);
            return docctor.Select(c => new DoctorMV
            {
                Doctorid = c.Doctorid,
                DoctorName = c.DoctorName,
                Email = c.Email,
                Phone = c.Phone,
                cityname = c.CityTBL.CityName,
                areaname = c.AreaTBL.AreaName,
                Age = c.Age,
                spec = c.SpecialtyTBL.SpecialtyName,
                DoctorAppointmentsTBLs = c.DoctorAppointmentsTBLs.ToList(),
                
                


            }).FirstOrDefault();

        }


        public ResponseMV createnewpatient(DoctorMV doctor)
        {
            ResponseMV result = ValidateDoctor(doctor);
            if (result.IsValid == true)
            {
                DoctorTBL doctortemp = new DoctorTBL();
                doctortemp. Doctorid = doctor.Doctorid;
                doctortemp. DoctorName = doctor.DoctorName;
                doctortemp. Email = doctor.Email;
                doctortemp. Phone = doctor.Phone;
                doctortemp. Cityid = doctor.Cityid;
                doctortemp. Areaid = doctor.Areaid;
                doctortemp. Age = doctor.Age;
                doctortemp. Specialtyid = doctor.Specialtyid;
                clinic.DoctorTBLs.Add(doctortemp);
                clinic.SaveChanges();
            }
            return result;


        }


        public ResponseMV editecustomer(DoctorMV doctor)
        {
            ResponseMV result = ValidateDoctor(doctor);
            if (result.IsValid == true)
            {
                var doctortemp = clinic.DoctorTBLs.Where(c => c.Doctorid == doctor.Doctorid).FirstOrDefault();

                
               
                doctortemp.DoctorName = doctor.DoctorName;
                doctortemp.Email = doctor.Email;
                doctortemp.Phone = doctor.Phone;
                doctortemp.Cityid = doctor.Cityid;
                doctortemp.Areaid = doctor.Areaid;
                doctortemp.Age = doctor.Age;
                doctortemp.Specialtyid = doctor.Specialtyid;
               
                clinic.SaveChanges();

             



            }
            return result;



        }

        public Boolean SelectDoctordelete(int id)
        {
            try
            {
                var doctor = clinic.DoctorTBLs.Where(c => c.Doctorid == id).FirstOrDefault();
                clinic.DoctorTBLs.Remove(doctor);
                clinic.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
         

        }


        public DoctorMV openPatientCreate(int id = 0, DoctorMV model = null)
        {
            LookupBussiness look = new LookupBussiness();
            if (model == null)
            {
                model = new DoctorMV();

            }
            if (id != 0 && model != null)
            {
                var _class = clinic.DoctorTBLs.Find(id);
                model.areaname = _class.AreaTBL.AreaName;
                model.Areaid = _class.Areaid;
                model.cityname = _class.CityTBL.CityName;
                model.Cityid = _class.Cityid;
                model.Arealist = look.fillarea(model.Cityid);
                model.spec = _class.SpecialtyTBL.SpecialtyName;
                model.Specialtyid = _class.Specialtyid;

            }


            model.citylist = look.fillcity();
            model.speclist = look.fillspec();

            return model;

        }



    }
}
