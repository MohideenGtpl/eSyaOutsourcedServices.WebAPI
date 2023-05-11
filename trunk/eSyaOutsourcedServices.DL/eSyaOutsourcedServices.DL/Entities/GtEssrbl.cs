﻿using System;
using System.Collections.Generic;

namespace eSyaOutsourcedServices.DL.Entities
{
    public partial class GtEssrbl
    {
        public int BusinessKey { get; set; }
        public int ServiceId { get; set; }
        public string InternalServiceCode { get; set; }
        public decimal ServiceCost { get; set; }
        public decimal NightLinePercentage { get; set; }
        public decimal HolidayPercentage { get; set; }
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