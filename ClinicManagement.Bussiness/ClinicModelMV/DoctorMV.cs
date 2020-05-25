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
  public  class DoctorMV
    {

        public int Doctorid { get; set; }
        [DisplayName(@"Doctor Name")]
        public string DoctorName { get; set; }
        [DisplayName(@"Email")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        [DisplayName(@"Phone")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter correct phone")]
        [StringLength(12)]
        public string Phone { get; set; }
        [DisplayName(@"Age")]
        [Range(1, 100, ErrorMessage = "age must be between 1 and 100")]
        public Nullable<int> Age { get; set; }
        [DisplayName(@"City Name")]
        public Nullable<int> Cityid { get; set; }
        [DisplayName(@"Area Name")]
        public Nullable<int> Areaid { get; set; }
        [DisplayName(@"Specialty Name")]
        public Nullable<int> Specialtyid { get; set; }

        public string cityname { get; set; }
        public string areaname { get; set; }
        public string spec { get; set; }

        public List<Lookups> Arealist { get; set; }
        public List<Lookups> citylist { get; set; }
        public List<Lookups> speclist { get; set; }

        public virtual List<DoctorAppointmentsTBL> DoctorAppointmentsTBLs { get; set; }
    


    }
}
