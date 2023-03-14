using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CancerTreatment : BaseEntity
    {
        public DateTime? TreatmentStartDate { get; set; }
        public DateTime? TreatmentEndDate { get; set; }
        public string TreatmentResult { get; set; }
        public string FromOfTreatment { get; set; }
        public int? FormID { get; set; }
        public int? TreatmentID { get; set; }
    }
}
