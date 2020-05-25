using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DAL;
using ClinicManagement.Bussiness.ClinicModelMV;

namespace ClinicManagement.Bussiness.ClinicBussiness
{
   public class BookingBussiness
    {

        ClinicManagementEntities clinic = new ClinicManagementEntities();

        public ResponseMV Validatebooking(BookingMV viewmodel)

        {
            DateTime timebook = new DateTime();
            timebook = (DateTime)viewmodel.BookingPagedata;
          

            BookingMV resulttime = Bookssearch(viewmodel);
            ResponseMV result = new ResponseMV();
            if (viewmodel.Doctorid==null)
                result.ErrorMessages.Add("Doctorid", "not found name");
            if (viewmodel.patientid == null)
                result.ErrorMessages.Add("patientid", "not found name");
            if (viewmodel.Specialtyid == null)
                result.ErrorMessages.Add("Specialtyid", "not found name");
            if ( resulttime!=null)
                result.ErrorMessages.Add("BookingPagedata", "not correct time you must choose after     "+resulttime.FinishTime);
            if (viewmodel.DateBooking == null )
                result.ErrorMessages.Add("DateBooking", "can not save empty date");
            if (viewmodel.DateBooking < DateTime.Now)
                result.ErrorMessages.Add("DateBooking1", "this date not coorect choose day after this date"+ viewmodel.DateBooking);
            if (viewmodel.BookingPagedata == null)
                result.ErrorMessages.Add("BookingPagedata1", "can not save empty time");
            if (timebook.Minute>0&& timebook.Minute!=30)
                result.ErrorMessages.Add("BookingPagedata2", "can not save this time you must choose time without minute");




            result.IsValid = result.ErrorMessages.Count == 0 ? true : false;
            return result;
        }



        public List<BookingMV> listofBooks()
        {
            var books = clinic.BookingTBLs;
            return books.Select(c => new BookingMV
            {
               DoctorNmae=c.DoctorTBL.DoctorName,
               PatientName=c.PatientTBL.PatientName,
               SpecNmae=c.SpecialtyTBL.SpecialtyName,
               BookingPagedata=c.BookingPagedata,
               DateBooking=c.DateBooking,
                FinishTime = c.FinishTime,
                type=c.type,
                id=c.id


        }).ToList();
        }


        public ResponseMV createnewbooking(BookingMV Booking)
        {
            ResponseMV result = Validatebooking(Booking);
            if (result.IsValid == true)
            {
                BookingTBL doctortemp = new BookingTBL();
                doctortemp.Doctorid = Booking.Doctorid;
                doctortemp.patientid = Booking.patientid;
                doctortemp.Specialtyid = Booking.Specialtyid;
                doctortemp.BookingPagedata = Booking.BookingPagedata;
                doctortemp.DateBooking = Booking.DateBooking;
                doctortemp.FinishTime = Booking.FinishTime;
                doctortemp.type = Booking.type;
              
                
                clinic.BookingTBLs.Add(doctortemp);
                clinic.SaveChanges();
            }
            return result;


        }


        public BookingMV openbookingCreate( BookingMV model = null)
        {
            LookupBussiness look = new LookupBussiness();
            if (model == null)
            {
                model = new BookingMV();

            }
           
            model.PatientList = look.fillpatient();
            model.SpecList = look.fillspec();

            return model;

        }



        public List<BookingMV> listofBookssearch(DateTime fristdate,DateTime secanddate)
        {
            var books = clinic.BookingTBLs.Where(b=>b.DateBooking>fristdate&&b.DateBooking<secanddate);
            return books.Select(c => new BookingMV
            {
                DoctorNmae = c.DoctorTBL.DoctorName,
                PatientName = c.PatientTBL.PatientName,
                SpecNmae = c.SpecialtyTBL.SpecialtyName,
                BookingPagedata = c.BookingPagedata,
            }).ToList();
        }



        public BookingMV Bookssearch(BookingMV timebooking)
        {
            var books = clinic.BookingTBLs.Where(b=>b.BookingPagedata==timebooking.BookingPagedata && b.Doctorid==timebooking.Doctorid && b.DateBooking==timebooking.DateBooking && b.type== "Pending");
            return books.Select(c => new BookingMV
            {
                id=c.id,
                DoctorNmae = c.DoctorTBL.DoctorName,
                PatientName = c.PatientTBL.PatientName,
                SpecNmae = c.SpecialtyTBL.SpecialtyName,
                BookingPagedata = c.BookingPagedata,
                DateBooking=c.DateBooking,
                FinishTime=c.FinishTime,
            }).SingleOrDefault();
        }


        public Boolean getbooking(int id)
        {
            try
            {
                var books = clinic.BookingTBLs.Where(b => b.id == id).SingleOrDefault();
                clinic.BookingTBLs.Remove(books);
                clinic.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
          

        }

        public Boolean ubdatebookimg(int id)
        {
           
                var books = clinic.BookingTBLs.Where(b => b.id == id).SingleOrDefault();
                books.type = "finish";
                clinic.SaveChanges();
            return true;
              


        }



    }
}
