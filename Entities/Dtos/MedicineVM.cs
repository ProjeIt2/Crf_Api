using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class MedicineVM
    {
        public int ID { get; set; }
        public string Dosage { get; set; }
        public decimal? Unit { get; set; }
        public string Density { get; set; }
        public int? FormID { get; set; }
        public string Barcode { get; set; }
        public int? PillID { get; set; }
        public string PillName { get; set; }
        public int? UsageID { get; set; }
        public string UsageType { get; set; }
        public int? CurrentStatusID { get; set; }
        public string Current_Status { get; set; }
    }
}
