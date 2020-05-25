using ClinicManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Bussiness.ClinicModelMV
{
  public  class MedicalFileMedicinMV
    {

        public int id { get; set; }
        [DisplayName(@"fileDetalies serial")]
        public Nullable<int> fileDetaliesID { get; set; }

        public Nullable<int> medicalID { get; set; }

        [DisplayName(@"medical Name")]
        public string MedicalName { get; set; }

        public List<Lookups> listmedical { get; set; }
        public virtual MedicalFileDetalisTBL MedicalFileDetalisTBL { get; set; }
    }
}
