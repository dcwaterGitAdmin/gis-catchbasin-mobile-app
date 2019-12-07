using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class FAILURELIST
    {
        public long FAILURELIST_ { get; set; }
        public string FAILURECODE { get; set; }
        public Nullable<long> PARENT { get; set; }
        public string TYPE { get; set; }
        public string ORGID { get; set; }
        public string ROWSTAMP { get; set; }
    }
}
