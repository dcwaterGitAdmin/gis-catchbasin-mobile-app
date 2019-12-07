using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class LABORCRAFTRATE
    {
        public string CONTRACTNUM { get; set; }
        public string CONTROLACCOUNT { get; set; }
        public string CRAFT { get; set; }
        public long DEFAULTCRAFT { get; set; }
        public string DEFAULTTICKETGLACC { get; set; }
        public string GLACCOUNT { get; set; }
        public long INHERIT { get; set; }
        public string LABORCODE { get; set; }
        public long LABORCRAFTRATEID { get; set; }
        public string ORGID { get; set; }
        public Nullable<double> RATE { get; set; }
        public string SKILLLEVEL { get; set; }
        public string VENDOR { get; set; }
        public string ROWSTAMP { get; set; }
    }
}
