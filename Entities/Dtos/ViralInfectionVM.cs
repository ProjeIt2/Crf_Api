using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
 public  class ViralInfectionVM
    {
        public int ID { get; set; }
        public string TestStatus { get; set; }
        public string Result { get; set; }
        public int? FormID { get; set; }
        public string Barcode { get; set; }
        public int? VirusID { get; set; }
        public string VirusName { get; set; }
    }
}
