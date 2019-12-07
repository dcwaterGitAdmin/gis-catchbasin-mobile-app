using System;
using System.Collections.Generic;
using System.IO;

namespace DCWaterMobile.LocalData.Models
{
    public partial class MAXDOMAIN
    {
        public string DOMAINID { get; set; }
        public string DESCRIPTION { get; set; }
        public string DOMAINTYPE { get; set; }
        public string ROWSTAMP { get; set; }
        public Nullable<long> LENGTH { get; set; }
        public double MAXDOMAINID { get; set; }
        public string MAXTYPE { get; set; }
        public Nullable<long> SCALE { get; set; }
        public long INTERNAL { get; set; }
        public Nullable<long> NEVERCACHE { get; set; }
    }
}
