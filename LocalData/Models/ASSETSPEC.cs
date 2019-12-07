using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class ASSETSPEC
    {
        public long C_ASSETSPECID_LOCAL_ { get; set; }
        public long C_ASSETNUM_LOCAL_ { get; set; }
        public string ALNVALUE { get; set; }
        public string ASSETATTRID { get; set; }
        public string ASSETNUM { get; set; }
        public Nullable<long> ASSETSPECID { get; set; }
        public string CHANGEBY { get; set; }
        public System.DateTime CHANGEDATE { get; set; }
        public string CLASSSTRUCTUREID { get; set; }
        public long DISPLAYSEQUENCE { get; set; }
        public string ES01 { get; set; }
        public string ES02 { get; set; }
        public string ES03 { get; set; }
        public Nullable<System.DateTime> ES04 { get; set; }
        public Nullable<double> ES05 { get; set; }
        public long INHERITEDFROMITEM { get; set; }
        public long ITEMSPECVALCHANGED { get; set; }
        public string MEASUREUNITID { get; set; }
        public Nullable<double> NUMVALUE { get; set; }
        public string ORGID { get; set; }
        public string SECTION { get; set; }
        public string SITEID { get; set; }
        public long CONTINUOUS { get; set; }
        public Nullable<double> ENDMEASURE { get; set; }
        public Nullable<double> ENDOFFSET { get; set; }
        public Nullable<double> ENDYOFFSET { get; set; }
        public string ENDYOFFSETREF { get; set; }
        public Nullable<double> ENDZOFFSET { get; set; }
        public string ENDZOFFSETREF { get; set; }
        public string LINKEDTOATTRIBUTE { get; set; }
        public string LINKEDTOSECTION { get; set; }
        public long MANDATORY { get; set; }
        public Nullable<double> STARTMEASURE { get; set; }
        public Nullable<double> STARTOFFSET { get; set; }
        public Nullable<double> STARTYOFFSET { get; set; }
        public string STARTYOFFSETREF { get; set; }
        public Nullable<double> STARTZOFFSET { get; set; }
        public string STARTZOFFSETREF { get; set; }
        public string TABLEVALUE { get; set; }
        public string BASEMEASUREUNITID { get; set; }
        public Nullable<double> STARTBASEMEASURE { get; set; }
        public Nullable<double> ENDBASEMEASURE { get; set; }
        public string STARTMEASUREUNITID { get; set; }
        public string ENDMEASUREUNITID { get; set; }
        public Nullable<long> STARTASSETFEATUREID { get; set; }
        public Nullable<long> ENDASSETFEATUREID { get; set; }
        public string STARTOFFSETUNITID { get; set; }
        public string ENDOFFSETUNITID { get; set; }
        public long LINEARASSETSPECID { get; set; }
        public string ROWSTAMP { get; set; }
        public long C_record_state_ { get; set; }

        public virtual ASSET Asset { get; set; }
    }
}
