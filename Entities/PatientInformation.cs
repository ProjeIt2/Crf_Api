using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PatientInformation : BaseEntity
    {
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string Height { get; set; }
        public int? Weight { get; set; }
        public string EducationDegree { get; set; }
        public string TcNo { get; set; }
        public string ProtokolNumber { get; set; }
        public string NameSurname { get; set; }
        public int? Age { get; set; }
        public string FileNo { get; set; }
        public int? FormID { get; set; }
    }
}
