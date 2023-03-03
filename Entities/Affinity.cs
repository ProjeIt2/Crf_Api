using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Affinity : BaseEntity
    {
        public string AffinityType { get; set; }
        public int? AKey { get; set; }
    }
}
