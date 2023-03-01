using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DiagnosisHistory : BaseEntity
    {
        public string Diagnosis_History { get; set; }
        public int? DKey { get; set; }
    }
}
