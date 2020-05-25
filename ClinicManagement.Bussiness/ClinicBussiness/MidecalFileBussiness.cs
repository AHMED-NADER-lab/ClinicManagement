using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DAL;
using ClinicManagement.Bussiness.ClinicModelMV;

namespace ClinicManagement.Bussiness.ClinicBussiness
{
   public class MidecalFileBussiness
    {
        ClinicManagementEntities clinic = new ClinicManagementEntities();

        public ResponseMV ValidateMedicalFile(MedicalFilesMV viewmodel)
        {
            MedicalFilesMV res = Selectfilepatient((int)viewmodel.patientid);
            ResponseMV result = new ResponseMV();
            if (string.IsNullOrEmpty(viewmodel.FileSerial))
                result.ErrorMessages.Add("FileSerial", "not found name");
            if (viewmodel.patientid == null)
                result.ErrorMessages.Add("patientname", "not found name");
            if (res != null)
                result.ErrorMessages.Add("patientname2", "has medical file");



            result.IsValid = result.ErrorMessages.Count == 0 ? true : false;
            return result;
        }



        public List<MedicalFilesMV> listofmedicalfile()
        {
            var file = clinic.MedicalFileTBLs;
            return file.Select(c => new MedicalFilesMV
            {
                id = c.id,
                FileSerial = c.FileSerial,
                patientname = c.PatientTBL.PatientName,
                Discraption = c.Discraption,
                MedicalFileDetalisTBLslist = c.MedicalFileDetalisTBLs.ToList(),



            }).ToList();
        }


        public MedicalFilesMV Selectfile(int id)
        {

            var file = clinic.MedicalFileTBLs.Where(f=>f.id==id);
            return file.Select(c => new MedicalFilesMV
            {
                id = c.id,
                FileSerial = c.FileSerial,
                patientname = c.PatientTBL.PatientName,
                Discraption = c.Discraption,
                MedicalFileDetalisTBLslist = c.MedicalFileDetalisTBLs.ToList(),
            
                



            }).FirstOrDefault();

        }



        public ResponseMV createnewpatientmedicalfile(MedicalFilesMV newfile)
        {
            ResponseMV result = ValidateMedicalFile(newfile);
            if (result.IsValid == true)
            {
                MedicalFileTBL filetemp = new MedicalFileTBL();
                filetemp.id = newfile.id;
                filetemp.FileSerial = newfile.FileSerial;
                filetemp.patientid = newfile.patientid;
                filetemp.Discraption = newfile.Discraption;
                clinic.MedicalFileTBLs.Add(filetemp);
                clinic.SaveChanges();
            }
            return result;


        }



        public MedicalFilesMV openPatientCreate( MedicalFilesMV model = null)
        {
            LookupBussiness look = new LookupBussiness();
            if (model == null)
            {
                model = new MedicalFilesMV();

            }
           


            model.patientlist = look.fillpatient();
            

            return model;

        }


        public MedicalFilesMV Selectfilepatient(int id)
        {

            var file = clinic.MedicalFileTBLs.Where(f => f.patientid == id);
            return file.Select(c => new MedicalFilesMV
            {
                id = c.id,
                FileSerial = c.FileSerial,
                patientname = c.PatientTBL.PatientName,
                Discraption = c.Discraption,
                MedicalFileDetalisTBLslist = c.MedicalFileDetalisTBLs.ToList(),




            }).FirstOrDefault();

        }


    }
}
