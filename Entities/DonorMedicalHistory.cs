using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class DonorMedicalHistory : BaseEntity
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DiagnosisHistoryDate { get; set; }
        public int? FormID { get; set; }
         public int? DiseaseID { get; set; }
        public int? DiagnosisHistoryID { get; set; }
         public int? MedicalStatusID { get; set; }
        public int? ICD10CodeID { get; set; }
   
    }
}
