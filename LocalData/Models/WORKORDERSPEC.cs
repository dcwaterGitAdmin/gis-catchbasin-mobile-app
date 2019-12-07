using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class WORKORDERSPEC
    {
        public long C_WORKORDERSPECID_LOCAL_ { get; set; }
        public string ALNVALUE { get; set; }
        public string ASSETATTRID { get; set; }
        public string CHANGEBY { get; set; }
        public System.DateTime CHANGEDATE { get; set; }
        public Nullable<long> CLASSSPECID { get; set; }
        public string CLASSSTRUCTUREID { get; set; }
        public long DISPLAYSEQUENCE { get; set; }
        public string LINKEDTOATTRIBUTE { get; set; }
        public string LINKEDTOSECTION { get; set; }
        public long MANDATORY { get; set; }
        public string MEASUREUNITID { get; set; }
        public Nullable<double> NUMVALUE { get; set; }
        public string ORGID { get; set; }
        public long REFOBJECTID { get; set; }
        public string REFOBJECTNAME { get; set; }
        public string SECTION { get; set; }
        public string SITEID { get; set; }
        public string TABLEVALUE { get; set; }
        public string WONUM { get; set; }
        public Nullable<long> WORKORDERSPECID { get; set; }
        public string ROWSTAMP { get; set; }
        public long C_record_state_ { get; set; }
        public long C_WORKORDERID_LOCAL_ { get; set; }
        public virtual WORKORDER Workorder { get; set; }
    }
}
