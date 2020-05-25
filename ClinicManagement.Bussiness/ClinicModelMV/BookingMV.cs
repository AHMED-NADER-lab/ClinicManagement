using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Bussiness.ClinicModelMV
{
  public  class BookingMV
    {

        public int id { get; set; }
        [DisplayName(@"Patient Name")]
        public Nullable<int> patientid { get; set; }
        [DisplayName(@"Specialty Name")]
        public Nullable<int> Specialtyid { get; set; }
        [DisplayName(@"Doctor Name")]
        public Nullable<int> Doctorid { get; set; }
        [DisplayName(@"Booking time")]

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public Nullable<System.DateTime> BookingPagedata { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public Nullable<System.DateTime> FinishTime { get; set; }

        public String PatientName { get; set; }
        public String DoctorNmae { get; set; }
        public String SpecNmae { get; set; }

        public List<Lookups> PatientList { get; set; }
        public List<Lookups> SpecList { get; set; }
         public List<Lookups> DoctorList { get; set; }
        [DisplayName(@"Booking Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateBooking { get; set; }
        public string type { get; set; }



    }
}
