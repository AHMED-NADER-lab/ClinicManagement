using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicManagement.Bussiness.ClinicBussiness;
using ClinicManagement.Bussiness.ClinicModelMV;

namespace ClinicManagementMVC.Controllers
{
    public class MedicalFileController : Controller
    {
        MidecalFileBussiness file = new MidecalFileBussiness();
        MedicalFileDetalisBussiness filedetailes = new MedicalFileDetalisBussiness();
        MedicalFileMeicinBussiness medical = new MedicalFileMeicinBussiness();

        public ActionResult Index()
        {

            return View(file.listofmedicalfile());
        }

     

        // GET: MedicalFile/Create
        public ActionResult Create()
        {
            MedicalFilesMV newfileopen = file.openPatientCreate();
            return View(newfileopen);
        }

        // POST: MedicalFile/Create
        [HttpPost]
        public ActionResult Createnewfile(MedicalFilesMV filenew)
            
        {
         
            ResponseMV result = file.createnewpatientmedicalfile(filenew);

            if (result.IsValid == true) { return RedirectToAction("Index"); }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                filenew = file.openPatientCreate(filenew);
                return View("Create", filenew);
            }

        }

        // Create new file medical for new patient
        public ActionResult CreateNewDetalies(int id)
        {
            MedicalFileDetalisMV newfileopen = filedetailes.openFileDetalesCreate();
            TempData["Fileid"]  = id;
            return View(newfileopen);
        }

        // POST: MedicalFile/Edit/5
        [HttpPost]
        public ActionResult SubmitDetalies(MedicalFileDetalisMV newdetalies)
        {
         
            newdetalies.Date = DateTime.Now ;
            newdetalies.FileID = (int) TempData["Fileid"];
            ResponseMV result = filedetailes.createnewDetails(newdetalies);

            if (result.IsValid == true) {

                return RedirectToAction("medicalFileDetailes",new { id= newdetalies.FileID });
            }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                newdetalies = filedetailes.openFileDetalesCreate(newdetalies);
                return View("CreateNewDetalies", newdetalies);
            }

        }


        public ActionResult  MedicinList(int id)
        {


            return View(medical.listofmedica(id));
        }



        //create medicine of the file patient
        public ActionResult Createnewmedicine(int id)
        {
            MedicalFileMedicinMV medicalopen = medical.openmedicinCreate();
            TempData["FileDetaliesid"] = id;
            return View(medicalopen);
        }

        // POST: MedicalFileMedicine/Create
        [HttpPost]
        public ActionResult submitemedicine(MedicalFileMedicinMV newmedical)
        {
            newmedical.fileDetaliesID = (int)TempData["FileDetaliesid"];
            ResponseMV result = medical.createnewpatient(newmedical);
            if (result.IsValid == true)
            {
                TempData["save"] = "save Sucess Medicien";

                return RedirectToAction("Createnewmedicine", new { id = newmedical.fileDetaliesID });
            }
            else
            {
                foreach (var item in result.ErrorMessages)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                newmedical = medical.openmedicinCreate(newmedical);
                return View("Createnewmedicine", newmedical);
            }
        }





        //  show MedicalFile and this Details
        public ActionResult medicalFileDetailes(int id)
        {
           

            return View(file.Selectfile(id));
        }


        //  show MedicalFile  Details
        public ActionResult Details(int id)
        {
            filedetailes.listofmedicalfiledetailes(id);

            return View(filedetailes.listofmedicalfiledetailes(id));
        }


    }




}
