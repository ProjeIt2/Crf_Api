using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class FamilyMedicalHistoryVM
    {
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DiagnosisHistoryDate { get; set; }
        public string Barcode { get; set; }
        public int? FormID { get; set; }
        public int DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public int AffinityID { get; set; }
        public string AffinityType { get; set; }

    }
}
