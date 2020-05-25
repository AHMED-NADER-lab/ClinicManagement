using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Bussiness.ClinicModelMV
{
  public  class SpecialtyMV
    {

        public int id { get; set; }

        [DisplayName(@"SpecialtyName")]
        public string SpecialtyName { get; set; }
    }
}
