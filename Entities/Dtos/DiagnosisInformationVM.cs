using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class DiagnosisInformationVM
    {
        public int ID { get; set; }
        public DateTime? DiagnosisDate { get; set; }
        public int? FormID { get; set; }
        public string Barcode { get; set; }
        public int? ClinicalDiagnosisID { get; set; }
        public string DiagnosisName { get; set; }
        public int? ICD10CodeID { get; set; }
        public string ICD10_Code { get; set; }
    }
}
