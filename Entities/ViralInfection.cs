using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ViralInfection : BaseEntity
    {
        public string TestStatus { get; set; }
        public string Result { get; set; }
        public int? FormID { get; set; }
        public int? VirusID { get; set; }
    }
}
