using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   public class SpecimenVM
    {
        public int ID { get; set; }
        public DateTime? AdditionDate { get; set; }
        public string AdditionHour { get; set; }
        public int? FormID { get; set; }
        public string Barcode { get; set; }
        public int? OperationProcedureID { get; set; }
        public string Operation_Procedure { get; set; }
        public int? AnatomicalAreaID { get; set; }
        public string Anatomical_Area { get; set; }
        public int? AdditionTypeID { get; set; }
        public string Addition_Type { get; set; }
    }
}
