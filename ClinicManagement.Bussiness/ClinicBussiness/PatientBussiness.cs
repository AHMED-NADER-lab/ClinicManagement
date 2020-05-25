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
   public class PatientBussiness
    {
        ClinicManagementEntities clinic = new ClinicManagementEntities();

        public ResponseMV Validatepatient(PatientMV viewmodel)
        {
            ResponseMV result = new ResponseMV();
            if (string.IsNullOrEmpty(viewmodel.PatientName))
                result.ErrorMessages.Add("PatientName", "not found name");
            if (string.IsNullOrEmpty(viewmodel.SerialPatient))
                result.ErrorMessages.Add("SerialPatient", "not found name");



            result.IsValid = result.ErrorMessages.Count == 0 ? true : false;
            return result;
        }



        public List<PatientMV> listofcustomer()
        {
            var patients = clinic.PatientTBLs;
            return patients.Select(c => new PatientMV
            {
                PatientId = c.PatientId,
                SerialPatient = c.SerialPatient,
                PatientName = c.PatientName,
                Phone = c.Phone,
                cityname = c.CityTBL.CityName,
                areaname = c.AreaTBL.AreaName,
                Age = c.Age,
                ActionsList=(GenderEnum)c.Gender
                

            }).ToList();
        }

        public ResponseMV createnewpatient(PatientMV patient)
        {
            ResponseMV result = Validatepatient(patient);
            if (result.IsValid == true)
            {
                PatientTBL patienttemp = new PatientTBL();
                patienttemp.PatientId = patient.PatientId;
              patienttemp.SerialPatient = patient.SerialPatient;
               patienttemp.PatientName = patient.PatientName;
               patienttemp.Phone = patient.Phone;
              patienttemp.cityid = patient.cityid;
             patienttemp.Areaid = patient.Areaid;
              patienttemp.Age = patient.Age;
                clinic.PatientTBLs.Add(patienttemp);
                clinic.SaveChanges();
            }
            return result;


        }


        public PatientMV Selectpatient(int id)
        {

            var patient = clinic.PatientTBLs.Where(c => c.PatientId == id);
            return patient.Select(c => new PatientMV
            {
                PatientId = c.PatientId,
                SerialPatient = c.SerialPatient,
                PatientName = c.PatientName,
                Phone = c.Phone,
                cityname = c.CityTBL.CityName,
                areaname = c.AreaTBL.AreaName,
                Age = c.Age,
                
                


            }).FirstOrDefault();

        }

        public Boolean SelectPatientdelete(int id)
        {
            try
            {
                var patient = clinic.PatientTBLs.FirstOrDefault(c => c.PatientId == id);
                clinic.PatientTBLs.Remove(patient);
                clinic.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
            

        }


        public ResponseMV editepatient( PatientMV patient)
        {
            ResponseMV result = Validatepatient(patient);
            if (result.IsValid == true)
            {
                var patienttemp = clinic.PatientTBLs.Where(c => c.PatientId == patient.PatientId).FirstOrDefault();

                patienttemp.PatientId = patient.PatientId;
                patienttemp.SerialPatient = patient.SerialPatient;
                patienttemp.PatientName = patient.PatientName;
                patienttemp.Phone = patient.Phone;
                patienttemp.cityid = patient.cityid;
                patienttemp.Areaid = patient.Areaid;
                patienttemp.Age = patient.Age;
           
                clinic.SaveChanges();
               

               
            }
            return result;



        }


        public PatientMV openPatientCreate(int id = 0,PatientMV model = null)
        {
            LookupBussiness look = new LookupBussiness();
            if (model == null)
            {
                model = new PatientMV();
               
            }
            if (id != 0 && model!=null)
            {
                var _class = clinic.PatientTBLs.Find(id);
                model.areaname = _class.AreaTBL.AreaName;
                model.Areaid = _class.Areaid;
                model.cityname = _class.CityTBL.CityName;
                model.cityid = _class.cityid;
                model.Arealist = look.fillarea(model.cityid);
            }


            model.citylist = look.fillcity();
          


            return model;

        }





    }
}
