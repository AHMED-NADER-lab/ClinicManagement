using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicManagement.Bussiness.ClinicBussiness;
using ClinicManagement.Bussiness.ClinicModelMV;





namespace ClinicManagementMVC.Controllers
{
    public class PatientController : Controller
    {
        PatientBussiness patient = new PatientBussiness();
        
        // GET: Patient
        public ActionResult Index()
        {
            return View(patient.listofcustomer());
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        public ActionResult Create()
        {

          PatientMV patientopen=patient.openPatientCreate();
            return View(patientopen);
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Createnewpatient(PatientMV newpatient)
        {
            int f = (int)newpatient.ActionsList;
            
            newpatient.SerialPatient = newpatient.PatientName.Substring(0, 3) + newpatient.Phone.ToString();
            ResponseMV result = patient.createnewpatient(newpatient);

            if (result.IsValid == true) {
                TempData["ModelName"] = "sucess save     " + newpatient.PatientName;
                return RedirectToAction("Index"); }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                newpatient = patient.openPatientCreate(model:newpatient);
                return View("Create", newpatient);
            }

        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            PatientMV resulltpatient = patient.Selectpatient(id);
            resulltpatient = patient.openPatientCreate(id, resulltpatient);

            return View(resulltpatient);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Editpatient(PatientMV newpatient)
        {
            ResponseMV result = patient.editepatient( newpatient);

            if (result.IsValid == true) {

                TempData["ModelName"] = "sucess edite       " + newpatient.PatientName;
                return RedirectToAction("Index"); }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                newpatient = patient.openPatientCreate(newpatient.PatientId, newpatient);
                return View("Edit", newpatient);
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
          Boolean result=  patient.SelectPatientdelete(id);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["deletmasg"] = "can not  delete ";
                return RedirectToAction("Index");
            }
        }

        // POST: Patient/Delete/5
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


        public ActionResult GetDistrictsByCityId(int cityId)
        {
            LookupBussiness lookArea = new LookupBussiness();
            return Json(lookArea.fillarea(cityId));
        }
    }
}
