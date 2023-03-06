using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class TumorType : BaseEntity
    {
        public string Tumor_Type { get; set; }
        public int? TKey { get; set; }
    }
}
