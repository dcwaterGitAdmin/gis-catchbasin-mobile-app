using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class TOOLTRAN
    {
        public long C_TOOLTRANSID_LOCAL_ { get; set; }
        public Nullable<long> C_REFWO_LOCAL_ { get; set; }
        public Nullable<long> C_ASSETNUM_LOCAL_ { get; set; }
        public System.DateTime TRANSDATE { get; set; }
        public double TOOLRATE { get; set; }
        public long TOOLQTY { get; set; }
        public double TOOLHRS { get; set; }
        public System.DateTime ENTERDATE { get; set; }
        public string ENTERBY { get; set; }
        public long OUTSIDE { get; set; }
        public long ROLLUP { get; set; }
        public string GLDEBITACCT { get; set; }
        public double LINECOST { get; set; }
        public string GLCREDITACCT { get; set; }
        public string FINANCIALPERIOD { get; set; }
        public string LOCATION { get; set; }
        public Nullable<double> EXCHANGERATE2 { get; set; }
        public Nullable<double> LINECOST2 { get; set; }
        public string SOURCESYSID { get; set; }
        public string OWNERSYSID { get; set; }
        public string EXTERNALREFID { get; set; }
        public string SENDERSYSID { get; set; }
        public string FINCNTRLID { get; set; }
        public string ORGID { get; set; }
        public string SITEID { get; set; }
        public string REFWO { get; set; }
        public long ENTEREDASTASK { get; set; }
        public string ROWSTAMP { get; set; }
        public string ASSETNUM { get; set; }
        public string ITEMNUM { get; set; }
        public string ITEMSETID { get; set; }
        public string ROTASSETNUM { get; set; }
        public string ROTASSETSITE { get; set; }
        public Nullable<long> TOOLTRANSID { get; set; }
        public string PLUSCCOMMENT { get; set; }
        public Nullable<System.DateTime> PLUSCDUEDATE { get; set; }
        public Nullable<System.DateTime> PLUSCEXPIRYDATE { get; set; }
        public string PLUSCLOTNUM { get; set; }
        public string PLUSCMANUFACTURER { get; set; }
        public string PLUSCTECHNICIAN { get; set; }
        public Nullable<System.DateTime> PLUSCTOOLUSEDATE { get; set; }
        public string PLUSCTYPE { get; set; }
        public long HASLD { get; set; }
        public string LANGCODE { get; set; }
        public string AMCREW { get; set; }
        public string TOOLSQ { get; set; }
        public long C_record_state_ { get; set; }

        public virtual WORKORDER Workorder { get; set; }
    }
}
