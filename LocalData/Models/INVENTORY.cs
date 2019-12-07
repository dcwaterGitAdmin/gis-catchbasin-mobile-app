using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class INVENTORY
    {
        public string ITEMNUM { get; set; }
        public string LOCATION { get; set; }
        public string BINNUM { get; set; }
        public string VENDOR { get; set; }
        public string MANUFACTURER { get; set; }
        public string MODELNUM { get; set; }
        public string CATALOGCODE { get; set; }
        public double MINLEVEL { get; set; }
        public double MAXLEVEL { get; set; }
        public string CATEGORY { get; set; }
        public string ORDERUNIT { get; set; }
        public string ISSUEUNIT { get; set; }
        public double ORDERQTY { get; set; }
        public Nullable<System.DateTime> LASTISSUEDATE { get; set; }
        public double ISSUEYTD { get; set; }
        public double ISSUE1YRAGO { get; set; }
        public double ISSUE2YRAGO { get; set; }
        public double ISSUE3YRAGO { get; set; }
        public string ABCTYPE { get; set; }
        public long CCF { get; set; }
        public Nullable<double> SSTOCK { get; set; }
        public long DELIVERYTIME { get; set; }
        public string IL1 { get; set; }
        public string IL2 { get; set; }
        public string IL3 { get; set; }
        public string GLACCOUNT { get; set; }
        public string CONTROLACC { get; set; }
        public string SHRINKAGEACC { get; set; }
        public string INVCOSTADJACC { get; set; }
        public string SOURCESYSID { get; set; }
        public string OWNERSYSID { get; set; }
        public string EXTERNALREFID { get; set; }
        public string SENDERSYSID { get; set; }
        public string ORGID { get; set; }
        public string SITEID { get; set; }
        public long INTERNAL { get; set; }
        public long INVENTORYID { get; set; }
        public string ITEMSETID { get; set; }
        public string STORELOC { get; set; }
        public string STORELOCSITEID { get; set; }
        public string STATUS { get; set; }
        public System.DateTime STATUSDATE { get; set; }
        public string ROWSTAMP { get; set; }
    }
}
