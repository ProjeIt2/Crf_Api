using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class ICD10Code: BaseEntity
    {
        public string ICD10_Code { get; set; }
        public int? IKey { get; set; }
    }
}
