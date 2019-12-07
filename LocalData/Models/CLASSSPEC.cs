using System;

namespace DCWaterMobile.LocalData.Models
{
    public partial class CLASSSPEC
    {
        public string CLASSSTRUCTUREID { get; set; }
        public string ASSETATTRID { get; set; }
        public string MEASUREUNITID { get; set; }
        public string DOMAINID { get; set; }
        public string ATTRDESCPREFIX { get; set; }
        public string CS01 { get; set; }
        public string CS02 { get; set; }
        public string CS03 { get; set; }
        public Nullable<System.DateTime> CS04 { get; set; }
        public Nullable<double> CS05 { get; set; }
        public string ORGID { get; set; }
        public long CLASSSPECID { get; set; }
        public string SECTION { get; set; }
        public string SITEID { get; set; }
        public long APPLYDOWNHIER { get; set; }
        public Nullable<long> ASSETATTRIBUTEID { get; set; }
        public string INHERITEDFROM { get; set; }
        public Nullable<long> INHERITEDFROMID { get; set; }
        public string LINKEDTOATTRIBUTE { get; set; }
        public string LINKEDTOSECTION { get; set; }
        public string LOOKUPNAME { get; set; }
        public string TABLEATTRIBUTE { get; set; }
        public long CONTINUOUS { get; set; }
        public string LINEARTYPE { get; set; }
        public string ROWSTAMP { get; set; }
    }
}
