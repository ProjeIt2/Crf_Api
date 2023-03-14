using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClinicalStatus : BaseEntity
    {
        public string TumorSize { get; set; }
        public string Phase { get; set; }
        public string Grade { get; set; }
        public int? FormID { get; set; }
        public int? TNMID { get; set; }
        public int? TumorAreaID { get; set; }
        public int? DoctorRequestedReportID { get; set; }
        public int? TumorTypeID { get; set; }
        public int? PhaseID { get; set; }

    }
}
