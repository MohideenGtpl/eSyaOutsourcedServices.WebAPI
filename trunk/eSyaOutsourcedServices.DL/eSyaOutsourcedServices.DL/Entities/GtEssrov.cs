using System;
using System.Collections.Generic;

namespace eSyaOutsourcedServices.DL.Entities
{
    public partial class GtEssrov
    {
        public int BusinessKey { get; set; }
        public int VendorCode { get; set; }
        public int ServiceClass { get; set; }
        public bool IsInternalVendor { get; set; }
        public int Priority { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
