using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DAL;
using ClinicManagement.Bussiness.ClinicModelMV;

namespace ClinicManagement.Bussiness.ClinicBussiness
{
 public   class DoctorAppointmentBussiness
    {
        ClinicManagementEntities clinic = new ClinicManagementEntities();

        public ResponseMV ValidateAppointment(DoctorAppointmentsMV viewmodel)
        {
            ResponseMV result = new ResponseMV();
            if (viewmodel.DoctorID==null)
                result.ErrorMessages.Add("DoctorID", "not found name");
            if (viewmodel.Dayhhhhhhhhhhhhhhh.Equals( null))
                result.ErrorMessages.Add("Day", "not found name");
            //if (checkappoitment((int)viewmodel.DoctorID, viewmodel.Day) != null)
            //{
            //    result.ErrorMessages.Add("doctorName", "can not take this day");
            //}

            //if (checkdoctorappointiment((int)viewmodel.DoctorID) != null)
            //{
            //    result.ErrorMessages.Add("doctorName2", "THIS DOCTOR HAS APPOINTMENT AND CAN NOT CREATE NEW APPOINTMENT FOR HIM");
            //}

            if (checkappoitment(viewmodel) != null)
            {
                result.ErrorMessages.Add("Day2", "take this day appointment");
            }




            result.IsValid = result.ErrorMessages.Count == 0 ? true : false;
            return result;
        }


        public List<DoctorAppointmentsMV> listofAppointment()
        {
            var DoctorAppointmentList = clinic.DoctorAppointmentsTBLs;
            return DoctorAppointmentList.Select(c => new DoctorAppointmentsMV
            {

                id = c.id,
                doctorName = c.DoctorTBL.DoctorName,

                Dayhhhhhhhhhhhhhhh = (DayOfWeek)c.Day,


                spec =c.DoctorTBL.SpecialtyTBL.SpecialtyName,


            }).ToList();
        }

        //public DoctorAppointmentsMV checkappoitment(int id, string day)
        //{
        //    var specresult = clinic.DoctorTBLs.Where(a => a.Doctorid == id).SingleOrDefault();
        //    var DoctorAppointmentList = clinic.DoctorAppointmentsTBLs.Where(a => a.DoctorTBL.SpecialtyTBL.SpecialtyName == specresult.SpecialtyTBL.SpecialtyName && a.Day == day);
        //    return DoctorAppointmentList.Select(c => new DoctorAppointmentsMV
        //    {
        //        doctorName = c.DoctorTBL.DoctorName,
        //        Day = c.Day,
        //        spec = c.DoctorTBL.SpecialtyTBL.SpecialtyName,


        //    }).SingleOrDefault();
        //}


        public DoctorAppointmentsMV checkappoitment(DoctorAppointmentsMV newappdoctor)
        {

         

            var DoctorAppointmentList = clinic.DoctorAppointmentsTBLs.Where(a => a.DoctorID == newappdoctor.DoctorID && a.Day ==(int)newappdoctor.Dayhhhhhhhhhhhhhhh);
            return DoctorAppointmentList.Select(c => new DoctorAppointmentsMV
            {
                doctorName = c.DoctorTBL.DoctorName,
                Dayhhhhhhhhhhhhhhh = (DayOfWeek)c.Day,
                spec = c.DoctorTBL.SpecialtyTBL.SpecialtyName,


            }).SingleOrDefault();
        }


        public ResponseMV createnewAppointment(DoctorAppointmentsMV newAppointment)
        {
            ResponseMV result = ValidateAppointment(newAppointment);
            if (result.IsValid == true)
            {
              
                DoctorAppointmentsTBL Appointmenttemp = new DoctorAppointmentsTBL();
                Appointmenttemp.DoctorID = newAppointment.DoctorID;
              Appointmenttemp.Day = (int)newAppointment.Dayhhhhhhhhhhhhhhh;
                clinic.DoctorAppointmentsTBLs.Add(Appointmenttemp);
                clinic.SaveChanges();
            }
            return result;


        }


        public DoctorAppointmentsMV openFileDetalesCreate(DoctorAppointmentsMV model = null)
        {
            LookupBussiness look = new LookupBussiness();
            if (model == null)
            {
                model = new DoctorAppointmentsMV();
            }
            model.DoctorList = look.filldoctor();
            return model;
        }


        public Boolean deleteAppointment(int id)
        {
            try
            {
                var DoctorAppointmentList = clinic.DoctorAppointmentsTBLs.Where(a => a.id == id).SingleOrDefault();
                clinic.DoctorAppointmentsTBLs.Remove(DoctorAppointmentList);
                clinic.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
           
        }

        //used in booking to check day and the date of the booking
        public  DoctorAppointmentsMV selectday(int id,int day)
        {
            var DoctorAppointmentList = clinic.DoctorAppointmentsTBLs.Where(d => d.DoctorID == id && d.Day==(int?)day);
            return DoctorAppointmentList.Select(c => new DoctorAppointmentsMV
            {
                doctorName = c.DoctorTBL.DoctorName,
                Dayhhhhhhhhhhhhhhh = (DayOfWeek)c.Day,
                spec = c.DoctorTBL.SpecialtyTBL.SpecialtyName,


            }).SingleOrDefault();
        }


        public List<DoctorAppointmentsMV> listdaydoctor(int id)
        {
            var DoctorAppointmentList = clinic.DoctorAppointmentsTBLs.Where(d => d.DoctorID == id );
            return DoctorAppointmentList.Select(c => new DoctorAppointmentsMV
            {

                Dayhhhhhhhhhhhhhhh = (DayOfWeek)c.Day,
                


            }).ToList();
        }




        public DoctorAppointmentsMV checkdoctorappointiment(int id)
        {
            var DoctorAppointmentList = clinic.DoctorAppointmentsTBLs.Where(d => d.DoctorID == id);
            return DoctorAppointmentList.Select(c => new DoctorAppointmentsMV
            {
                doctorName = c.DoctorTBL.DoctorName,
                Dayhhhhhhhhhhhhhhh = (DayOfWeek)c.Day,
                spec = c.DoctorTBL.SpecialtyTBL.SpecialtyName,


            }).SingleOrDefault();
        }




    }
}
