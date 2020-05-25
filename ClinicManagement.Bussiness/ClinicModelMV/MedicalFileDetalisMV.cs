using ClinicManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Bussiness.ClinicModelMV
{
  public  class MedicalFileDetalisMV
    {
        public int id { get; set; }
        [DisplayName(@"File Serial")]
        public Nullable<int> FileID { get; set; }
        [DisplayName(@"Doctor Name")]
        public Nullable<int> doctorID { get; set; }
        [DisplayName(@"Doctor Name")]
        public string doctorname { get; set; }
        public List< Lookups> doctorlist { get; set; }
      

        public string Description { get; set; }
        [DisplayName(@"Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date { get; set; }
        public virtual List<MedicalFilesMedicinTBL> MedicalFilesMedicinTBLs { get; set; }



    }
}
