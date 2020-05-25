using ClinicManagement.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Bussiness.ClinicModelMV
{
  public  class DoctorAppointmentsMV
    {
        public int id { get; set; }
        //public Nullable<int> Day { get; set; }
        public DayOfWeek Day { get; set; }
        public string Dayname { get; set; }
        public Nullable<int> DoctorID { get; set; }
        [DisplayName(@"Doctor Name")]
        public string doctorName { get; set; }
        public string spec { get; set; }
        public List<Lookups> DoctorList { get; set; }
        public virtual DoctorTBL DoctorTBL { get; set; }
    }
}
