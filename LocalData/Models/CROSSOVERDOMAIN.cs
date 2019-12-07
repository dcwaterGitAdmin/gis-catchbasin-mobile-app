using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class CROSSOVERDOMAIN
    {
        public string DOMAINID { get; set; }
        public string SOURCEFIELD { get; set; }
        public string DESTFIELD { get; set; }
        public string ROWSTAMP { get; set; }
        public long CROSSOVERDOMAINID { get; set; }
        public string ORGID { get; set; }
        public string SITEID { get; set; }
        public long COPYEVENIFSRCNULL { get; set; }
        public long COPYONLYIFDESTNULL { get; set; }
        public string DESTCONDITION { get; set; }
        public Nullable<long> SEQUENCE { get; set; }
        public string SOURCECONDITION { get; set; }
    }
}
