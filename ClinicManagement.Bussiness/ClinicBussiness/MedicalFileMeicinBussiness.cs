using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DAL;
using ClinicManagement.Bussiness.ClinicModelMV;

namespace ClinicManagement.Bussiness.ClinicBussiness
{
   public class MedicalFileMeicinBussiness
    {


        ClinicManagementEntities clinic = new ClinicManagementEntities();

        public ResponseMV ValidateMedicalFileMedicine(MedicalFileMedicinMV viewmodel)
        {
            ResponseMV result = new ResponseMV();
            if (viewmodel.medicalID==null)
                result.ErrorMessages.Add("medicalID", "not found name");
          


            result.IsValid = result.ErrorMessages.Count == 0 ? true : false;
            return result;
        }


        public List<MedicalFileMedicinMV> listofmedica(int id )
        {
            var MedicalList = clinic.MedicalFilesMedicinTBLs.Where(s=>s.fileDetaliesID==id);
            return MedicalList.Select(c => new MedicalFileMedicinMV
            {
                medicalID = c.medicalID,
                MedicalName = c.MedicalTBL.MedicalName,
                id = c.id,
                fileDetaliesID = c.fileDetaliesID,
               


            }).ToList();
        }


        public ResponseMV createnewpatient(MedicalFileMedicinMV newmedical)
        {
            ResponseMV result = ValidateMedicalFileMedicine(newmedical);
            if (result.IsValid == true)
            {
                MedicalFilesMedicinTBL medicaltemp = new MedicalFilesMedicinTBL();

                medicaltemp. medicalID = newmedical.medicalID;


                medicaltemp. fileDetaliesID = newmedical.fileDetaliesID;
               
                clinic.MedicalFilesMedicinTBLs.Add(medicaltemp);
                clinic.SaveChanges();
            }
            return result;


        }

        public MedicalFileMedicinMV openmedicinCreate( MedicalFileMedicinMV model = null)
        {
            LookupBussiness look = new LookupBussiness();
            if (model == null)
            {
                model = new MedicalFileMedicinMV();

            }
          


            model.listmedical = look.fillMedicin();
           

            return model;

        }


 








    }
}
