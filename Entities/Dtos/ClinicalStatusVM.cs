using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
  public  class ClinicalStatusVM
    {
        public int ID { get; set; }
        public string TumorSize { get; set; }
        public string Phase { get; set; }
        public string Grade { get; set; }
        public int? FormID { get; set; }
        public string Barcode { get; set; }
        public int? TNMID { get; set; }
        public string TTNM { get; set; }
        public int? TumorAreaID { get; set; }
        public string Tumor_Area { get; set; }
        public int? DoctorRequestedReportID { get; set; }
        public string ReportName { get; set; }
        public int? TumorTypeID { get; set; }
        public string Tumor_Type { get; set; }
        public int? PhaseID { get; set; }
        public string PhaseName { get; set; }
    }
}
