using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCWaterMobile.MaximoService.MaxRest;

namespace DCWaterMobile.LocalData.Models
{
    public partial class WOSTATUS
    {
        public long C_WOSTATUSID_LOCAL_ { get; set; }
        public long C_WORKORDERID_LOCAL_ { get; set; }
        public string WONUM { get; set; }
        public string STATUS { get; set; }
        public System.DateTime CHANGEDATE { get; set; }
        public string CHANGEBY { get; set; }
        public string MEMO { get; set; }
        public string GLACCOUNT { get; set; }
        public string FINCNTRLID { get; set; }
        public string ORGID { get; set; }
        public string SITEID { get; set; }
        public Nullable<long> WOSTATUSID { get; set; }
        public string PARENT { get; set; }
        public string ROWSTAMP { get; set; }
        public long C_record_state_ { get; set; }

        public virtual WORKORDER Workorder { get; set; }
    }
}
