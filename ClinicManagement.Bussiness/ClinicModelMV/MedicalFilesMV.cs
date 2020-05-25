using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.DAL;

namespace ClinicManagement.Bussiness.ClinicModelMV
{
  public  class MedicalFilesMV
    {

        public int id { get; set; }
        [DisplayName(@"File Serial")]
        public string FileSerial { get; set; }
        [DisplayName(@"Discraption")]
        public string Discraption { get; set; }

        public Nullable<int> patientid { get; set; }

        public string patientname { get; set; }


        public virtual List<MedicalFileDetalisTBL> MedicalFileDetalisTBLslist { get; set; }
        



        public virtual PatientTBL PatientTBL { get; set; }


        public List<Lookups> patientlist { get; set; }



    }
}
