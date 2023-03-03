using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class DonorMedicalHistoryVM
    {
        [Key]
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DiagnosisHistoryDate { get; set; }
        public string Barcode { get; set; }
        public int? FormID { get; set; }
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public string Diagnosis_History { get; set; }
        public int MedicalStatusID { get; set; }
        public string Medical_Status { get; set; }
        public int ICD10CodeID { get; set; }
        public string ICD10_Code { get; set; }

    }
}
