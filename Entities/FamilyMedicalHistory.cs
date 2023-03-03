using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class FamilyMedicalHistory : BaseEntity
    {
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DiagnosisDate { get; set; }
        //Relational Properties
        public int? FormID { get; set; }
        public int? AffinityID { get; set; }
        public int? DiagnosisID { get; set; }
    }
}
