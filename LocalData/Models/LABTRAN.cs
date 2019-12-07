using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class LABTRAN
    {
        public long C_LABTRANSID_LOCAL_ { get; set; }
        public Nullable<long> C_REFWO_LOCAL_ { get; set; }
        public Nullable<long> C_ASSETNUM_LOCAL_ { get; set; }
        public System.DateTime TRANSDATE { get; set; }
        public string LABORCODE { get; set; }
        public string CRAFT { get; set; }
        public double PAYRATE { get; set; }
        public double REGULARHRS { get; set; }
        public string ENTERBY { get; set; }
        public System.DateTime ENTERDATE { get; set; }
        public string LTWO1 { get; set; }
        public long LT7 { get; set; }
        public System.DateTime STARTDATE { get; set; }
        public Nullable<System.DateTime> STARTTIME { get; set; }
        public Nullable<System.DateTime> FINISHDATE { get; set; }
        public Nullable<System.DateTime> FINISHTIME { get; set; }
        public string TRANSTYPE { get; set; }
        public long OUTSIDE { get; set; }
        public string MEMO { get; set; }
        public long ROLLUP { get; set; }
        public string GLDEBITACCT { get; set; }
        public double LINECOST { get; set; }
        public string GLCREDITACCT { get; set; }
        public string FINANCIALPERIOD { get; set; }
        public string PONUM { get; set; }
        public Nullable<long> POLINENUM { get; set; }
        public string LOCATION { get; set; }
        public long GENAPPRSERVRECEIPT { get; set; }
        public Nullable<System.DateTime> PAYMENTTRANSDATE { get; set; }
        public Nullable<double> EXCHANGERATE2 { get; set; }
        public Nullable<double> LINECOST2 { get; set; }
        public Nullable<long> LABTRANSID { get; set; }
        public Nullable<long> SERVRECTRANSID { get; set; }
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
        public string CONTRACTNUM { get; set; }
        public Nullable<long> INVOICELINENUM { get; set; }
        public string INVOICENUM { get; set; }
        public string PREMIUMPAYCODE { get; set; }
        public Nullable<double> PREMIUMPAYHOURS { get; set; }
        public Nullable<double> PREMIUMPAYRATE { get; set; }
        public string PREMIUMPAYRATETYPE { get; set; }
        public Nullable<long> REVISIONNUM { get; set; }
        public string SKILLLEVEL { get; set; }
        public string TICKETCLASS { get; set; }
        public string TICKETID { get; set; }
        public string TIMERSTATUS { get; set; }
        public string VENDOR { get; set; }
        public Nullable<long> POREVISIONNUM { get; set; }
        public string CREWWORKGROUP { get; set; }
        public string AMCREW { get; set; }
        public string AMCREWTYPE { get; set; }
        public string POSITION { get; set; }
        public long DCW_TRUCKDRIVER { get; set; }
        public long DCW_TRUCKLEAD { get; set; }
        public string DCW_TRUCKNUM { get; set; }
        public long DCW_TRUCKSECOND { get; set; }
        public long C_record_state_ { get; set; }

        public virtual WORKORDER Workorder { get; set; }
    }
}
