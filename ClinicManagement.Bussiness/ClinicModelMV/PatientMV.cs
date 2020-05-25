using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagement.Bussiness.Enums;

namespace ClinicManagement.Bussiness.ClinicModelMV
{
    public class PatientMV
    {
        public int PatientId { get; set; }
        [DisplayName(@"Serial Patient")]
        public string SerialPatient { get; set; }
        [DisplayName("Patient Name")]
        public string PatientName { get; set; }
        [DisplayName("Phone")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter correct phone")]
        [StringLength(12)]
        public string Phone { get; set; }
        [DisplayName("Age")]
        [Range(1, 100, ErrorMessage = "age must be between 1 and 100")]
        public Nullable<int> Age { get; set; }
        [DisplayName(@"city Name")]
        public Nullable<int> cityid { get; set; }
        [DisplayName("Area Name")]
        public Nullable<int> Areaid { get; set; }
        [DisplayName(@"MedicalFile Series")]
        public Nullable<int> MedicalFileId { get; set; }
        public string cityname { get; set; }
        public string areaname { get; set; }

        public List<Lookups> Arealist { get; set; }
        public List<Lookups> citylist { get; set; }

        public Nullable<short> Gender { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Select a correct license")]
        public  GenderEnum ActionsList { get; set; }



    }
}
