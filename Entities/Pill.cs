using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Pill : BaseEntity
    {
        public string PillName { get; set; }
        public int? PKey { get; set; }
    }
}
