using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProjectInformation : BaseEntity
    {
        public string ProjectName { get; set; }
        public string ProjectDetails { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string BarcodeStartTag { get; set; }
        public int? BarcodeStartNo { get; set; }
        public int? BarcodeEndNo { get; set; }
        public string TransitCondition { get; set; }
        public string ShippingCondition { get; set; }
        public int? BoneMarrowAliquotLab { get; set; }
        public int? SerumAliquotLab { get; set; }
        public int? BuffyCoatAliquotLab { get; set; }
        public int? RestBloodAliquotLab { get; set; }
        public int? PriorityCount { get; set; }
        public bool ProjectStatus { get; set; }
        public int? ShippingConditionID { get; set; }
        public int? StorageConditionID { get; set; }
        public int? TransportConditionID { get; set; }
        public string WONumber { get; set; }
        public string HemolysisIndex { get; set; }
        public bool? Healty { get; set; }
        public int? SponsorID { get; set; }
        public bool? AbroadProject { get; set; }
        public bool? HematologyStatus { get; set; }
        public bool Fresh { get; set; }
    }
}
