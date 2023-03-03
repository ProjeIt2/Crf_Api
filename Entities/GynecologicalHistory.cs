using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class GynecologicalHistory : BaseEntity
    {

        public string MenstrualStatus { get; set; }
        public DateTime? LastMenstrualDate { get; set; }
        public int Pregnant { get; set; }

        public int Parturition { get; set; }

        //Relational Properties
        public int? FormID { get; set; }
    }
}
