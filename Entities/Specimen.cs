using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Specimen : BaseEntity
    {
        public DateTime? AdditionDate { get; set; }
        public string AdditionHour { get; set; }
        public int? FormID { get; set; }
        public int? OperationProcedureID { get; set; }
        public int? AnatomicalAreaID { get; set; }
        public int? AdditionTypeID { get; set; }

    }
}
