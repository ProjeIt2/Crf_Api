using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class SocialLife : BaseEntity
    {     //------------------Smoke-------------
 
        public string SmokeStatus { get; set; }

        //[Required(ErrorMessage = "Bu alan zorunludur")]
        public string SmokeType { get; set; }

        //[Required(ErrorMessage = "Bu alan zorunludur")]
        public string SmokeAmount { get; set; }

        //[Required(ErrorMessage = "Bu alan zorunludur")]
        public string SmokeCurrentStatus { get; set; }

        //[Required(ErrorMessage = "Bu alan zorunludur")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? QuitSmokingDate { get; set; }
        //-------------------------------------

                //------------------Alcohol-------------
       public string AlcoholStatus { get; set; }

        //[Required(ErrorMessage = "Bu alan zorunludur")]
        public string AlcoholType { get; set; }


        //[Required(ErrorMessage = "Bu alan zorunludur")]
        public string AlcoholAmount { get; set; }


        //[Required(ErrorMessage = "Bu alan zorunludur")]
        public string AlcoholCurrentStatus { get; set; }

        //[Required(ErrorMessage = "Bu alan zorunludur")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? QuitAlcoholingDate { get; set; }
        //-------------------------------------


        //------------------Drug-------------

        public string DrugStatus { get; set; }

        public string DrugType { get; set; }

        public string DrugAmount { get; set; }

        public string DrugCurrentStatus { get; set; }
        //-------------------------------------


        //Relational Properties
        public int? FormID { get; set; }
    }
}
