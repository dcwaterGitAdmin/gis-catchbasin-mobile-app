using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class ASSET
    {
        public ASSET()
        {
            this.AssetSpecs = new List<ASSETSPEC>();
        }
        public long C_ASSETNUM_LOCAL_ { get; set; }
        public string ANCESTOR { get; set; }
        public Nullable<long> ASSETID { get; set; }
        public string ASSETNUM { get; set; }
        public string ASSETTAG { get; set; }
        public string ASSETTYPE { get; set; }
        public Nullable<long> ASSETUID { get; set; }
        public long AUTOWOGEN { get; set; }
        public string BINNUM { get; set; }
        public double BUDGETCOST { get; set; }
        public string CALNUM { get; set; }
        public string CHANGEBY { get; set; }
        public System.DateTime CHANGEDATE { get; set; }
        public long CHILDREN { get; set; }
        public string CLASSSTRUCTUREID { get; set; }
        public string CONDITIONCODE { get; set; }
        public string DESCRIPTION { get; set; }
        public long DISABLED { get; set; }
        public string EQ1 { get; set; }
        public string EQ10 { get; set; }
        public string EQ11 { get; set; }
        public string EQ12 { get; set; }
        public string EQ2 { get; set; }
        public Nullable<System.DateTime> EQ23 { get; set; }
        public Nullable<double> EQ24 { get; set; }
        public string EQ3 { get; set; }
        public string EQ4 { get; set; }
        public Nullable<double> EQ5 { get; set; }
        public Nullable<System.DateTime> EQ6 { get; set; }
        public string EQ7 { get; set; }
        public string EQ8 { get; set; }
        public string EQ9 { get; set; }
        public string EXTERNALREFID { get; set; }
        public string FAILURECODE { get; set; }
        public string GLACCOUNT { get; set; }
        public string GROUPNAME { get; set; }
        public long HASLD { get; set; }
        public Nullable<System.DateTime> INSTALLDATE { get; set; }
        public double INVCOST { get; set; }
        public long ISRUNNING { get; set; }
        public string ITEMNUM { get; set; }
        public string ITEMSETID { get; set; }
        public string ITEMTYPE { get; set; }
        public string LANGCODE { get; set; }
        public string LOCATION { get; set; }
        public long MAINTHIERCHY { get; set; }
        public string MANUFACTURER { get; set; }
        public long MOVED { get; set; }
        public string ORGID { get; set; }
        public string OWNERSYSID { get; set; }
        public string PARENT { get; set; }
        public Nullable<long> PRIORITY { get; set; }
        public double PURCHASEPRICE { get; set; }
        public double REPLACECOST { get; set; }
        public string ROTSUSPACCT { get; set; }
        public string SENDERSYSID { get; set; }
        public string SERIALNUM { get; set; }
        public string SHIFTNUM { get; set; }
        public string SITEID { get; set; }
        public string SOURCESYSID { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> STATUSDATE { get; set; }
        public string TOOLCONTROLACCOUNT { get; set; }
        public Nullable<double> TOOLRATE { get; set; }
        public double TOTALCOST { get; set; }
        public double TOTDOWNTIME { get; set; }
        public double TOTUNCHARGEDCOST { get; set; }
        public double UNCHARGEDCOST { get; set; }
        public string USAGE { get; set; }
        public string VENDOR { get; set; }
        public Nullable<System.DateTime> WARRANTYEXPDATE { get; set; }
        public double YTDCOST { get; set; }
        public string EQ13 { get; set; }
        public string EQ14 { get; set; }
        public string EQ15 { get; set; }
        public string EQ16 { get; set; }
        public Nullable<System.DateTime> EQ19 { get; set; }
        public long EQ22 { get; set; }
        public string MAPNUM { get; set; }
        public long FIXEDASSET { get; set; }
        public Nullable<double> X1 { get; set; }
        public Nullable<double> X2 { get; set; }
        public Nullable<double> Y1 { get; set; }
        public Nullable<double> Y2 { get; set; }
        public string GLOBALID { get; set; }
        public string DIRECTION { get; set; }
        public string ENDDESCRIPTION { get; set; }
        public Nullable<double> ENDMEASURE { get; set; }
        public long ISLINEAR { get; set; }
        public string STARTDESCRIPTION { get; set; }
        public Nullable<double> STARTMEASURE { get; set; }
        public string LRM { get; set; }
        public string DEFAULTREPFACSITEID { get; set; }
        public string DEFAULTREPFAC { get; set; }
        public long RETURNEDTOVENDOR { get; set; }
        public string TLOAMHASH { get; set; }
        public long TLOAMPARTITION { get; set; }
        public string PLUSCASSETDEPT { get; set; }
        public string PLUSCCLASS { get; set; }
        public Nullable<System.DateTime> PLUSCDUEDATE { get; set; }
        public string PLUSCISCONDESC { get; set; }
        public long PLUSCISCONTAM { get; set; }
        public long PLUSCISINHOUSECAL { get; set; }
        public long PLUSCISMTE { get; set; }
        public string PLUSCISMTECLASS { get; set; }
        public string PLUSCLOOPNUM { get; set; }
        public string PLUSCMODELNUM { get; set; }
        public string PLUSCOPRGEEU { get; set; }
        public string PLUSCOPRGEFROM { get; set; }
        public string PLUSCOPRGETO { get; set; }
        public string PLUSCPHYLOC { get; set; }
        public long PLUSCPMEXTDATE { get; set; }
        public long PLUSCSOLUTION { get; set; }
        public string PLUSCSUMDIR { get; set; }
        public string PLUSCSUMEU { get; set; }
        public string PLUSCSUMREAD { get; set; }
        public string PLUSCSUMSPAN { get; set; }
        public string PLUSCSUMURV { get; set; }
        public string PLUSCVENDOR { get; set; }
        public long ISCALIBRATION { get; set; }
        public string TEMPLATEID { get; set; }
        public string PLUSCLPLOC { get; set; }
        public string SADDRESSCODE { get; set; }
        public string PLUSSFEATURECLASS { get; set; }
        public long PLUSSISGIS { get; set; }
        public string PLUSSADDRESSCODE { get; set; }
        public string ROWSTAMP { get; set; }
        public long C_record_state_ { get; set; }
        public string C_mobile_asset_type_ { get; set;  }
        public string GEOWORXSYNCID { get; set; }

        // Related Records
        public virtual ICollection<ASSETSPEC>  AssetSpecs { get; set; }
          
    }
}
