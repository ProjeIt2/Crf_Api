using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Medicine : BaseEntity
    {
        public string Dosage { get; set; }
        public decimal? Unit { get; set; }
        public string Density { get; set; }
        public int? FormID { get; set; }
        public int? PillID { get; set; }
        public int? UsageID { get; set; }
        public int? CurrentStatusID { get; set; }
    }
}
