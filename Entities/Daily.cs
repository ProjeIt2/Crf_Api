using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Daily :BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? PersonelID { get; set; }
        public bool? TemporaryDuty { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public string StartTime { get; set; }
        public int? SenderID { get; set; }
        public string SenderName { get; set; }
        public string SelectLabel { get; set; }
        public int? ConnectTaskID { get; set; }
        public bool? Completed { get; set; }
        public string SendBack { get; set; }
        public string HospitalName { get; set; }
        public string DoctorName { get; set; }
        public int? BranchNameID { get; set; }
        public int? ProjectInformationID { get; set; }
        public bool? VisiteStatus { get; set; }
     public string MadeStatus { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
