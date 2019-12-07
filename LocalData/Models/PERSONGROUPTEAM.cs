using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class PERSONGROUPTEAM
    {
        public long GROUPDEFAULT { get; set; }
        public long ORGDEFAULT { get; set; }
        public string PERSONGROUP { get; set; }
        public long PERSONGROUPTEAMID { get; set; }
        public string RESPPARTY { get; set; }
        public string RESPPARTYGROUP { get; set; }
        public Nullable<long> RESPPARTYGROUPSEQ { get; set; }
        public long RESPPARTYSEQ { get; set; }
        public long SITEDEFAULT { get; set; }
        public string USEFORORG { get; set; }
        public string USEFORSITE { get; set; }
        public string ROWSTAMP { get; set; }
        public string DCW_DESIGNATION { get; set; }
    }
}
