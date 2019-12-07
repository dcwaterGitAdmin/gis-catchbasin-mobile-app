using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class WORKLOG
    {
        public long C_WORKLOGID_LOCAL_ { get; set; }
        public string CLASS { get; set; }
        public long CLIENTVIEWABLE { get; set; }
        public string CREATEBY { get; set; }
        public System.DateTime CREATEDATE { get; set; }
        public string DESCRIPTION { get; set; }
        public long HASLD { get; set; }
        public string LANGCODE { get; set; }
        public string LOGTYPE { get; set; }
        public string MODIFYBY { get; set; }
        public System.DateTime MODIFYDATE { get; set; }
        public string ORGID { get; set; }
        public string RECORDKEY { get; set; }
        public string SITEID { get; set; }
        public long WORKLOGID { get; set; }
        public string ROWSTAMP { get; set; }
        public Nullable<long> ASSIGNMENTID { get; set; }
        public long C_record_state_ { get; set; }
    }
}
