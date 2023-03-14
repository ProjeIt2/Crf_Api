using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class DoctorRequestedReport : BaseEntity
    {
        public int? Piece { get; set; }
        public int? ProjectInformationID { get; set; }
        public int? ReportID { get; set; }
    }
}
