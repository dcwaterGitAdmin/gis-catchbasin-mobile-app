using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class MAXROWSTAMP
    {
        public Nullable<System.DateTime> CHANGEDATE { get; set; }
        public long CURMAXROWSTAMP { get; set; }
        public long MAXROWSTAMPID { get; set; }
        public string TABLENAME { get; set; }
        public string ROWSTAMP { get; set; }
    }
}
