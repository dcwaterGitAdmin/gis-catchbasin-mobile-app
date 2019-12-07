using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class FAILUREREPORT
    {
        public long C_FAILUREREPORTID_LOCAL_ { get; set; }
        public Nullable<long> C_WONUM_LOCAL_ { get; set; }
        public Nullable<long> C_ASSETNUM_LOCAL_ { get; set; }
        public string WONUM { get; set; }
        public string FAILURECODE { get; set; }
        public long LINENUM { get; set; }
        public string TYPE { get; set; }
        public string ORGID { get; set; }
        public string SITEID { get; set; }
        public string ROWSTAMP { get; set; }
        public string ASSETNUM { get; set; }
        public Nullable<long> FAILUREREPORTID { get; set; }
        public string TICKETCLASS { get; set; }
        public string TICKETID { get; set; }
        public long C_record_state_ { get; set; }

        public virtual WORKORDER Workorder { get; set; }
    }
}
