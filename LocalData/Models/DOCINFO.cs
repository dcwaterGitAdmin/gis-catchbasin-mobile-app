using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class DOCINFO
    {
        public long C_DOCINFOID_LOCAL_ { get; set; }
        public string DOCUMENT { get; set; }
        public string DESCRIPTION { get; set; }
        public string APPLICATION { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> STATUSDATE { get; set; }
        public Nullable<System.DateTime> CREATEDATE { get; set; }
        public Nullable<long> REVISION { get; set; }
        public string EXTRA1 { get; set; }
        public string CHANGEBY { get; set; }
        public Nullable<System.DateTime> CHANGEDATE { get; set; }
        public string DOCLOCATION { get; set; }
        public string DOCTYPE { get; set; }
        public string CREATEBY { get; set; }
        public string URLTYPE { get; set; }
        public string DMSNAME { get; set; }
        public string URLNAME { get; set; }
        public string URLPARAM1 { get; set; }
        public string URLPARAM2 { get; set; }
        public string URLPARAM3 { get; set; }
        public string URLPARAM4 { get; set; }
        public string URLPARAM5 { get; set; }
        public long PRINTTHRULINKDFLT { get; set; }
        public long USEDEFAULTFILEPATH { get; set; }
        public long SHOW { get; set; }
        public string ROWSTAMP { get; set; }
        public Nullable<long> DOCINFOID { get; set; }
        public long HASLD { get; set; }
        public string LANGCODE { get; set; }
        public string CONTENTUID { get; set; }
        public string C_URLNAME_LOCAL_ { get; set; }
        public long C_record_state_ { get; set; }

        public virtual ICollection<DOCLINK> DocLinks { get; set; }
    }
}
