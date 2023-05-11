using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaOutsourcedServices.DO
{
    public class DO_OutSourcedVendor
    {

    }
    public class DO_OutSourcedService
    {
        public int BusinessKey { get; set; }
        public int ServiceId { get; set; }
        public string OutsourcedStatus { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTill { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
        //property for display Service Name in Tree View
        public string ServiceName { get; set; }
        public string ClassName { get; set; }
        public string GroupName { get; set; }
        public int GroupId { get; set; }
    }

    public class DO_OutSourcedCommonData
    {
        //properties for cascading drop down
        public int ServiceId { get; set; }
        public int ClassId { get; set; }
        public int GroupId { get; set; }
        public string ClassDesc { get; set; }
        public string GroupDesc { get; set; }
        public string ServiceDesc { get; set; }
    }
}
