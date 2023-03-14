using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class LymphNode:BaseEntity
    {
        public string LymphLocation { get; set; }
        public int? LKey { get; set; }
    }
}
