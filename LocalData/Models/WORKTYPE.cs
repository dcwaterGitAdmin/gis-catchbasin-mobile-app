using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class WORKTYPE
    {
        public string WORKTYPE_ { get; set; }
        public string WTYPEDESC { get; set; }
        public long PROMPTFAIL { get; set; }
        public long PROMPTDOWN { get; set; }
        public string ORGID { get; set; }
        public string TYPE { get; set; }
        public string WOCLASS { get; set; }
        public long WORKTYPEID { get; set; }
        public string COMPLETESTATUS { get; set; }
        public string STARTSTATUS { get; set; }
        public long KEEPTASKSTATUSHIST { get; set; }
        public string ROWSTAMP { get; set; }
        public string CONTENTUID { get; set; }
        public long DCW_APPTRACK { get; set; }
        public long DCW_CDCTRACK { get; set; }
        public long DCW_DSSTRACK { get; set; }
        public long DCW_DWSTRACK { get; set; }
        public long DCW_FACTRACK { get; set; }
        public long DCW_MOBTRACK { get; set; }
        public long DCW_QUICKREP { get; set; }
        public long DCW_WOTRACK { get; set; }
        public long DCW_WQTRACK { get; set; }
    }
}
