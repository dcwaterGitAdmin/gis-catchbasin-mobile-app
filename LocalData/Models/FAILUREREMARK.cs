using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class FAILUREREMARK
    {
        public long C_FAILUREREMARKID_LOCAL_ { get; set; }
//        public Nullable<long> C_WONUM_LOCAL_ { get; set; }
        public string WONUM { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<System.DateTime> ENTERDATE { get; set; }
        public string ORGID { get; set; }
        public string SITEID { get; set; }
        public string ROWSTAMP { get; set; }
        public Nullable<long> FAILUREREMARKID { get; set; }
        public long HASLD { get; set; }
        public string LANGCODE { get; set; }
        public string TICKETCLASS { get; set; }
        public string TICKETID { get; set; }
        public long C_record_state_ { get; set; }

        public virtual WORKORDER Workorder { get; set; }
    }
}
