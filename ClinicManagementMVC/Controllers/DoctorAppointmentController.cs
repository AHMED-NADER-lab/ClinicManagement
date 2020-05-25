using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ClinicManagement.Bussiness.ClinicBussiness;
using ClinicManagement.Bussiness.ClinicModelMV;

namespace ClinicManagementMVC.Controllers
{
    public class DoctorAppointmentController : Controller
    {
        DoctorAppointmentBussiness doctorapp = new DoctorAppointmentBussiness();
        // GET: DoctorAppointment
        public ActionResult Index()
        {
            return View(doctorapp.listofAppointment());
        }

        // GET: DoctorAppointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctorAppointment/Create
        public ActionResult Create()
        {
            DoctorAppointmentsMV doctoropen = doctorapp.openFileDetalesCreate();
            return View(doctoropen);
        }

        // POST: DoctorAppointment/Create
        [HttpPost]
        public ActionResult Createnewappointment(DoctorAppointmentsMV newappintment)
        {
           






            ResponseMV result = doctorapp.createnewAppointment(newappintment);

            if (result.IsValid == true) { return RedirectToAction("Index"); }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                newappintment = doctorapp.openFileDetalesCreate( newappintment);
                return View("Create", newappintment);
            }
        }

        // GET: DoctorAppointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorAppointment/Edit/5
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

        // GET: DoctorAppointment/Delete/5
        public ActionResult Delete(int id)
        {

          Boolean result =  doctorapp.deleteAppointment(id);
            if (result == false)
            {
                TempData["ModelName"] = "can not delete" ;
            }
            return RedirectToAction("Index");
        }

        // POST: DoctorAppointment/Delete/5
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
    }
}
