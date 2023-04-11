using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Entities.Dtos
{
  public  class FormListVM
    {
        [Key]
        public int ID { get; set; }
        public string Barcode { get; set; }
        public bool? FormFullStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
        public int PatientInformationID { get; set; }
        public string ProtokolNumber { get; set; }
        public string TcNo { get; set; }
        public int PersonnelID { get; set; }
        public string PersonnelFullName { get; set; }
        public int ProjectInformationID { get; set; }
        public string ProjectName { get; set; }
        public int DoctorID { get; set; }
        public string DoctorFullName { get; set; }
        public int CompanyID { get; set; }

    }
}
