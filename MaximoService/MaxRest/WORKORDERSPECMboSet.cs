using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class WORKORDERSPECMboSet
    {

        private WORKORDERSPECMboSetWORKORDERSPEC[] wORKORDERSPECField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WORKORDERSPEC")]
        public WORKORDERSPECMboSetWORKORDERSPEC[] WORKORDERSPEC
        {
            get
            {
                return this.wORKORDERSPECField;
            }
            set
            {
                this.wORKORDERSPECField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class WORKORDERSPECMboSetWORKORDERSPEC
    {

        private string aLNVALUEField;

        private string aSSETATTRIDField;

        private string cHANGEBYField;

        private System.DateTime cHANGEDATEField;

        private long? cLASSSPECIDField;

        private string cLASSSTRUCTUREIDField;

        private long dISPLAYSEQUENCEField;

        private string lINKEDTOATTRIBUTEField;

        private string lINKEDTOSECTIONField;

        private byte mANDATORYField;

        private string mEASUREUNITIDField;

        private decimal? nUMVALUEField;

        private string oRGIDField;

        private long rEFOBJECTIDField;

        private string rEFOBJECTNAMEField;

        private string sECTIONField;

        private string sITEIDField;

        private string tABLEVALUEField;

        private string wONUMField;

        private long wORKORDERSPECIDField;

        private string vALUEField;

        /// <remarks/>
        public string ALNVALUE
        {
            get
            {
                return this.aLNVALUEField;
            }
            set
            {
                this.aLNVALUEField = value;
            }
        }

        /// <remarks/>
        public string ASSETATTRID
        {
            get
            {
                return this.aSSETATTRIDField;
            }
            set
            {
                this.aSSETATTRIDField = value;
            }
        }

        /// <remarks/>
        public string CHANGEBY
        {
            get
            {
                return this.cHANGEBYField;
            }
            set
            {
                this.cHANGEBYField = value;
            }
        }

        /// <remarks/>
        public System.DateTime CHANGEDATE
        {
            get
            {
                return this.cHANGEDATEField;
            }
            set
            {
                this.cHANGEDATEField = value;
            }
        }

        /// <remarks/>
        public long? CLASSSPECID
        {
            get
            {
                return this.cLASSSPECIDField;
            }
            set
            {
                this.cLASSSPECIDField = value;
            }
        }

        /// <remarks/>
        public string CLASSSTRUCTUREID
        {
            get
            {
                return this.cLASSSTRUCTUREIDField;
            }
            set
            {
                this.cLASSSTRUCTUREIDField = value;
            }
        }

        /// <remarks/>
        public long DISPLAYSEQUENCE
        {
            get
            {
                return this.dISPLAYSEQUENCEField;
            }
            set
            {
                this.dISPLAYSEQUENCEField = value;
            }
        }

        /// <remarks/>
        public string LINKEDTOATTRIBUTE
        {
            get
            {
                return this.lINKEDTOATTRIBUTEField;
            }
            set
            {
                this.lINKEDTOATTRIBUTEField = value;
            }
        }

        /// <remarks/>
        public string LINKEDTOSECTION
        {
            get
            {
                return this.lINKEDTOSECTIONField;
            }
            set
            {
                this.lINKEDTOSECTIONField = value;
            }
        }

        /// <remarks/>
        public byte MANDATORY
        {
            get
            {
                return this.mANDATORYField;
            }
            set
            {
                this.mANDATORYField = value;
            }
        }

        /// <remarks/>
        public string MEASUREUNITID
        {
            get
            {
                return this.mEASUREUNITIDField;
            }
            set
            {
                this.mEASUREUNITIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? NUMVALUE
        {
            get
            {
                return this.nUMVALUEField;
            }
            set
            {
                this.nUMVALUEField = value;
            }
        }

        /// <remarks/>
        public string ORGID
        {
            get
            {
                return this.oRGIDField;
            }
            set
            {
                this.oRGIDField = value;
            }
        }

        /// <remarks/>
        public long REFOBJECTID
        {
            get
            {
                return this.rEFOBJECTIDField;
            }
            set
            {
                this.rEFOBJECTIDField = value;
            }
        }

        /// <remarks/>
        public string REFOBJECTNAME
        {
            get
            {
                return this.rEFOBJECTNAMEField;
            }
            set
            {
                this.rEFOBJECTNAMEField = value;
            }
        }

        /// <remarks/>
        public string SECTION
        {
            get
            {
                return this.sECTIONField;
            }
            set
            {
                this.sECTIONField = value;
            }
        }

        /// <remarks/>
        public string SITEID
        {
            get
            {
                return this.sITEIDField;
            }
            set
            {
                this.sITEIDField = value;
            }
        }

        /// <remarks/>
        public string TABLEVALUE
        {
            get
            {
                return this.tABLEVALUEField;
            }
            set
            {
                this.tABLEVALUEField = value;
            }
        }

        /// <remarks/>
        public string WONUM
        {
            get
            {
                return this.wONUMField;
            }
            set
            {
                this.wONUMField = value;
            }
        }

        /// <remarks/>
        public long WORKORDERSPECID
        {
            get
            {
                return this.wORKORDERSPECIDField;
            }
            set
            {
                this.wORKORDERSPECIDField = value;
            }
        }
        /// <remarks/>
        public string VALUE
        {
            get
            {
                return this.vALUEField;
            }
            set
            {
                this.vALUEField = value;
            }
        }

        private string rowstampField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rowstamp
        {
            get
            {
                return this.rowstampField;
            }
            set
            {
                this.rowstampField = value;
            }
        }


    }


}
