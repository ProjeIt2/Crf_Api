using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
 public   class TumorStatusVM
    {
        public int ID { get; set; }
        public string Barcode { get; set; }
        public string TumorSize { get; set; }
        public int? PhaseID { get; set; }
        public string PhaseName { get; set; }
        public string ClinicStaging { get; set; }
        public string PathologicalStaging { get; set; }
        public string Grade { get; set; }
        public int? TumorPercent { get; set; }
        public int? NecrosisPercent { get; set; }
        public string TumorPrimary { get; set; }
        public DateTime? TumorDate { get; set; }
        public string TumorClock { get; set; }
        public string ExcisiontimeHours { get; set; }
        public int? FormID { get; set; }
        public int? TumorAreaID { get; set; }
        public string Tumor_Area { get; set; }
        public int? TNMID { get; set; }
        public string TTNM { get; set; }
        public int? TumorTypeID { get; set; }
        public string Tumor_Type { get; set; }
    }
}
