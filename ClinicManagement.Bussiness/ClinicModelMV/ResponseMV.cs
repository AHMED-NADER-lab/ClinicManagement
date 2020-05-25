using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Bussiness.ClinicModelMV
{
    public class ResponseMV
    {

        public bool IsValid { get; set; }

        public Dictionary<string, string> ErrorMessages { get; set; }

        public ResponseMV()
        {
            ErrorMessages = new Dictionary<string, string>();
        }
    }
}
