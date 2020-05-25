using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DAL;
using ClinicManagement.Bussiness.ClinicModelMV;

namespace ClinicManagement.Bussiness.ClinicBussiness
{
 public   class MedicalFileDetalisBussiness
    {

        ClinicManagementEntities clinic = new ClinicManagementEntities();

        public ResponseMV ValidateMedicalFileDetailes(MedicalFileDetalisMV viewmodel)
        {
            ResponseMV result = new ResponseMV();
            if (viewmodel.doctorID==null)
                result.ErrorMessages.Add("doctorname", "not found name");
            if (viewmodel.FileID == null)
                result.ErrorMessages.Add("FileID", "not found name");



            result.IsValid = result.ErrorMessages.Count == 0 ? true : false;
            return result;
        }



        public List<MedicalFileDetalisMV> listofmedicalfiledetailes(int id)
        {
            var medicalDetalies = clinic.MedicalFileDetalisTBLs.Where(d=>d.FileID==id);
            return medicalDetalies.Select(c => new MedicalFileDetalisMV
            {
               doctorname=c.DoctorTBL.DoctorName,
               Description=c.Description,
               Date=c.Date,

            }).ToList();
        }



        public ResponseMV createnewDetails(MedicalFileDetalisMV newdetails)
        {
            ResponseMV result = ValidateMedicalFileDetailes(newdetails);
            if (result.IsValid == true)
            {
                MedicalFileDetalisTBL detailstemp = new MedicalFileDetalisTBL();
                detailstemp.doctorID = newdetails.doctorID;
                detailstemp.Description = newdetails.Description;
                detailstemp.FileID = newdetails.FileID;
                detailstemp.Date = newdetails.Date;

                clinic.MedicalFileDetalisTBLs.Add(detailstemp);
                clinic.SaveChanges();
            }
            return result;


        }

        public MedicalFileDetalisMV openFileDetalesCreate(MedicalFileDetalisMV model = null)
        {
            LookupBussiness look = new LookupBussiness();
            if (model == null)
            {
                model = new MedicalFileDetalisMV();

            }
          


            model.doctorlist = look.filldoctor();

            return model;

        }


    }
}
