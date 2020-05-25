using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Bussiness.ClinicModelMV
{
   public class Areamv
    {
        public int id { get; set; }
        public string AreaName { get; set; }
        public Nullable<int> CityId { get; set; }
    }
}
