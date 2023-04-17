using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Form : BaseEntity
    {
        public string Barcode { get; set; }
        public int HospitalID { get; set; }
        public bool? isntFull { get; set; }
        public bool? ReportStatus { get; set; }
        public int? PersonnelID { get; set; }
        public int? DoctorID { get; set; }
        public int? ProjectInformationID { get; set; }
        //public int? PatientInformationID { get; set; }
        public bool? FormStatus { get; set; }
        public bool? Situation { get; set; }
        public int? ClinicalDiagnosisID { get; set; }
        public bool? QuotaStatus { get; set; }
        public bool? ClinicalDiagQuota { get; set; }
        public int? LocationID { get; set; }
        public bool? Healty { get; set; }
        public bool? FormFullStatus { get; set; }
        public bool? ResultReport { get; set; }
    }
}
