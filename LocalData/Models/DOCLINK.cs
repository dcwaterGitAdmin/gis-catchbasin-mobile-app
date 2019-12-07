using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class DOCLINK
    {
        public long C_DOCLINKSID_LOCAL_ { get; set; }
        public long C_DOCINFOID_LOCAL_ { get; set; }
        public long C_OWNERID_LOCAL_ { get; set; }
        public string DOCUMENT { get; set; }
        public string REFERENCE { get; set; }
        public string DOCTYPE { get; set; }
        public string DOCVERSION { get; set; }
        public long GETLATESTVERSION { get; set; }
        public string CREATEBY { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public string CHANGEBY { get; set; }
        public Nullable<System.DateTime> CHANGEDATE { get; set; }
        public long PRINTTHRULINK { get; set; }
        public long COPYLINKTOWO { get; set; }
        public Nullable<long> DOCINFOID { get; set; }
        public Nullable<long> DOCLINKSID { get; set; }
        public Nullable<long> OWNERID { get; set; }
        public string OWNERTABLE { get; set; }
        public string ROWSTAMP { get; set; }
        public long C_record_state_ { get; set; }

        public virtual WORKORDER Workorder { get; set; }
        public virtual DOCINFO DocInfo { get; set; }
    }
}
