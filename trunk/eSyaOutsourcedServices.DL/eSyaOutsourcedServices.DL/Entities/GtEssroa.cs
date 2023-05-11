using System;
using System.Collections.Generic;

namespace eSyaOutsourcedServices.DL.Entities
{
    public partial class GtEssroa
    {
        public int BusinessKey { get; set; }
        public int ServiceId { get; set; }
        public int VendorCode { get; set; }
        public decimal Rate { get; set; }
        public string VendorServiceId { get; set; }
        public string VendorServiceDesc { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTill { get; set; }
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
