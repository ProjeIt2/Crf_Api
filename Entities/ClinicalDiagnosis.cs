using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class ClinicalDiagnosis:BaseEntity
    {
        public string DiagnosisName { get; set; }
        public int? BranchID { get; set; }
        public int? CKey { get; set; }
    }
}
