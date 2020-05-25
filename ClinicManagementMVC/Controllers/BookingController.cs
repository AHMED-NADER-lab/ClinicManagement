using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicManagement.Bussiness.ClinicBussiness;
using ClinicManagement.Bussiness.ClinicModelMV;

namespace ClinicManagementMVC.Controllers
{
    public class BookingController : Controller
    {
        BookingBussiness booking = new BookingBussiness();
        DoctorAppointmentBussiness doctorday = new DoctorAppointmentBussiness();
       static  Boolean check = true;
        // GET: Booking
        public ActionResult Index()
        {
            return View(booking.listofBooks());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            BookingMV bookingopen = booking.openbookingCreate();
            return View(bookingopen);
        }

        // POST: Booking/Create
        [HttpPost]
        public ActionResult CreateNewBook(BookingMV newbooking)
        {
          
            if (check == false)
            {
                TempData["checkbooking"] = "please check your date";
                newbooking = booking.openbookingCreate(newbooking);
                return View("Create", newbooking);
            }
            DateTime timebb = (DateTime)newbooking.BookingPagedata;
            newbooking.FinishTime = timebb.AddMinutes(30);
            newbooking.type = "Pending";
            ResponseMV result = booking.createnewbooking(newbooking);

            if (result.IsValid == true && check==true) {
                TempData["SaveBooking"] = "Booking save success";
                return RedirectToAction("Index"); }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                if (check == false)
                {
                    TempData["checkbooking"] = "please check your date";
                }
              
                newbooking = booking.openbookingCreate(newbooking);
                return View("Create", newbooking);
            }
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
          Boolean result=  booking.getbooking(id);


            if (result == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["deletemasg"] = "can not deletet  ";
                return RedirectToAction("Index");
            }
        }

        // POST: Booking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult GetDoctorbyspecId(int id)
        {
            LookupBussiness lookArea = new LookupBussiness();
            return Json(lookArea.filldoctorwithspec(id));
        }



        [HttpPost]
        public ActionResult search()
        {

            string value = Request.Form["datefrist"];
            string value2 = Request.Form["secandDate"];
            DateTime frist = DateTime.Parse(value);
            DateTime secand = DateTime.Parse(value2);

            List<BookingMV> result = booking.listofBookssearch(frist, secand);
            return View("Index", result);

        }


        [HttpPost]
        public ActionResult getdaydoctor(int id,DateTime bookingdate)
        {
            check = true;
         
          DoctorAppointmentsMV doc=  doctorday.selectday(id,(int)bookingdate.DayOfWeek);
            if (doc == null)
            {
                check = false;
                return Content("the day for this doctor not correct ", "text/plain");

            }
            //if (bookingdate.DayOfWeek==doc.Dayhhhhhhhhhhhhhhh) { return Content("this day for th doctor is:     " + doc.Dayhhhhhhhhhhhhhhh+" this day is   "+ bookingdate.DayOfWeek, "text/plain"); }

            return Content("this day for th doctor is:     " + doc.Dayhhhhhhhhhhhhhhh + " this day is   " + bookingdate.DayOfWeek, "text/plain");




        }

        public ActionResult finishbooking(int id)
        {
            Boolean result = booking.ubdatebookimg(id);

            return RedirectToAction("Index");
        }


        public ActionResult getlistdaydoctor(int id)
        {
            List<string> ddd = new List<string>() { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            List<  DoctorAppointmentsMV> doc = doctorday.listdaydoctor(id);
          
            for (int i = 0; i < doc.Count; i++)
            {
                for (int q = 0; q < ddd.Count; q++)
                {
                    if (doc[i].Dayhhhhhhhhhhhhhhh == (DayOfWeek)q)
                    {
                        doc[i].Dayname = ddd[q];

                    }
                }
               

            }
            return Json(doc);
        }

    }
}
