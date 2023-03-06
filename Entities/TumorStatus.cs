using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TumorStatus : BaseEntity
    {
        public string TumorSize { get; set; }
         public int? PhaseID { get; set; }
        public string ClinicStaging { get; set; }
        public string PathologicalStaging { get; set; }
        public int? TumorTypeID { get; set; }
        public string Grade { get; set; }
        public int? TumorPercent { get; set; }
        public int? NecrosisPercent { get; set; }
        public string TumorPrimary { get; set; }
        public DateTime? TumorDate { get; set; }
        public string TumorClock { get; set; }
        public string ExcisiontimeHours { get; set; }
        public int? FormID { get; set; }
        public int? TumorAreaID { get; set; }
        public int? TNMID { get; set; }


    }
}
