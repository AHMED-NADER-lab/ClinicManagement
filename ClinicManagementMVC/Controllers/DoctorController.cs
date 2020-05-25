using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicManagement.Bussiness.ClinicBussiness;
using ClinicManagement.Bussiness.ClinicModelMV;

namespace ClinicManagementMVC.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        DoctorBussiness doctor = new DoctorBussiness();
        public ActionResult Index()
        {

            return View(doctor.listofdoctor());
        }

     

        // GET: Doctor/Create
        public ActionResult Create()
        {
            DoctorMV doctoropen = doctor.openPatientCreate();
            return View(doctoropen);
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Createnewdoctor(DoctorMV newdoctor)
        {
            ResponseMV result = doctor.createnewpatient(newdoctor);

            if (result.IsValid == true) {

                TempData["ModelName"] = "sucess save     " + newdoctor.DoctorName;
                return RedirectToAction("Index"); }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                newdoctor = doctor.openPatientCreate(model: newdoctor);
                return View("Create", newdoctor);
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            DoctorMV resulltpatient = doctor.Selectdoctor(id);
            resulltpatient = doctor.openPatientCreate(id, resulltpatient);

            return View(resulltpatient);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult EditDoctor( DoctorMV modeldoctor)
        {
            ResponseMV result = doctor.editecustomer( modeldoctor);

            if (result.IsValid == true) {

                TempData["ModelName"] = "sucess save     " + modeldoctor.DoctorName;
                return RedirectToAction("Index"); }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                modeldoctor = doctor.openPatientCreate(modeldoctor.Doctorid , modeldoctor);
                return View("Edit", modeldoctor);
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
           Boolean result= doctor.SelectDoctordelete(id);
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

        // POST: Doctor/Delete/5
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
        DoctorAppointmentBussiness docapp = new DoctorAppointmentBussiness();


        public ActionResult Details(int id)
        {

            ViewBag.list = new List<string>() { "Sunday","Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
             DoctorMV resulltpatient = doctor.Selectdoctor(id);
            return View(resulltpatient);
        }

        public ActionResult openCreateAppointment(int id)
        {
            DoctorAppointmentsMV newdoctorapp = new DoctorAppointmentsMV();
            newdoctorapp.DoctorID = id;
            return View(newdoctorapp);
        }

        // POST: DoctorAppointment/Create
        [HttpPost]
        public ActionResult CreatenewAppointmentDoctor(DoctorAppointmentsMV newdoctorapp)
        {
            ResponseMV result = docapp.createnewAppointment(newdoctorapp);

            if (result.IsValid == true)
            {

                TempData["ModelName"] = "sucess save     " + newdoctorapp.doctorName+"   "+newdoctorapp.Dayhhhhhhhhhhhhhhh;
                return RedirectToAction("openCreateAppointment", new { id = newdoctorapp.DoctorID }); 
            }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
               
                return View("openCreateAppointment", newdoctorapp);
            }
        }





        public ActionResult GetDistrictsByCityId(int cityId)
        {
            LookupBussiness lookArea = new LookupBussiness();
            return Json(lookArea.fillarea(cityId));
        }
    }
}
