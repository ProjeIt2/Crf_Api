using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class CancerTreatmentVM
    {
        public int ID { get; set; }
        public DateTime? TreatmentStartDate { get; set; }
        public DateTime? TreatmentEndDate { get; set; }
        public string TreatmentResult { get; set; }
        public string FromOfTreatment { get; set; }
        public int? FormID { get; set; }
        public string Barcode { get; set; }
        public int? TreatmentID { get; set; }
        public string TreatmentType { get; set; }
        public int Status { get; set; }
    }
}
