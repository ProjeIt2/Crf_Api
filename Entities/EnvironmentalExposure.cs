using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class EnvironmentalExposure :BaseEntity
    {
       
        public string EExposureType { get; set; }
        public int? EnvMentalKey { get; set; }
        public int? CompanyID { get; set; }
       
    }
}
