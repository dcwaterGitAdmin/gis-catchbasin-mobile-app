namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class LABORCRAFTRATEMboSet
    {

        private LABORCRAFTRATEMboSetLABORCRAFTRATE[] lABORCRAFTRATEField;

        private int rsStartField;

        private int rsTotalField;

        private int rsCountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LABORCRAFTRATE")]
        public LABORCRAFTRATEMboSetLABORCRAFTRATE[] LABORCRAFTRATE
        {
            get
            {
                return this.lABORCRAFTRATEField;
            }
            set
            {
                this.lABORCRAFTRATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int rsStart
        {
            get
            {
                return this.rsStartField;
            }
            set
            {
                this.rsStartField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int rsTotal
        {
            get
            {
                return this.rsTotalField;
            }
            set
            {
                this.rsTotalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int rsCount
        {
            get
            {
                return this.rsCountField;
            }
            set
            {
                this.rsCountField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class LABORCRAFTRATEMboSetLABORCRAFTRATE
    {

        private string cONTRACTNUMField;

        private string cONTROLACCOUNTField;

        private string cRAFTField;

        private int dEFAULTCRAFTField;

        private string dEFAULTTICKETGLACCField;

        private decimal dISPLAYRATEField;

        private LABORCRAFTRATEMboSetLABORCRAFTRATEGLACCOUNT gLACCOUNTField;

        private int iNHERITField;

        private int iSACTIVEField;

        private string lABORCODEField;

        private int lABORCRAFTRATEIDField;

        private string oRGIDField;

        private decimal rATEField;

        private string sKILLLEVELField;

        private decimal? sTANDARDRATEField;

        private string vENDORField;

        /// <remarks/>
        public string CONTRACTNUM
        {
            get
            {
                return this.cONTRACTNUMField;
            }
            set
            {
                this.cONTRACTNUMField = value;
            }
        }

        /// <remarks/>
        public string CONTROLACCOUNT
        {
            get
            {
                return this.cONTROLACCOUNTField;
            }
            set
            {
                this.cONTROLACCOUNTField = value;
            }
        }

        /// <remarks/>
        public string CRAFT
        {
            get
            {
                return this.cRAFTField;
            }
            set
            {
                this.cRAFTField = value;
            }
        }

        /// <remarks/>
        public int DEFAULTCRAFT
        {
            get
            {
                return this.dEFAULTCRAFTField;
            }
            set
            {
                this.dEFAULTCRAFTField = value;
            }
        }

        /// <remarks/>
        public string DEFAULTTICKETGLACC
        {
            get
            {
                return this.dEFAULTTICKETGLACCField;
            }
            set
            {
                this.dEFAULTTICKETGLACCField = value;
            }
        }

        /// <remarks/>
        public decimal DISPLAYRATE
        {
            get
            {
                return this.dISPLAYRATEField;
            }
            set
            {
                this.dISPLAYRATEField = value;
            }
        }

        /// <remarks/>
        public LABORCRAFTRATEMboSetLABORCRAFTRATEGLACCOUNT GLACCOUNT
        {
            get
            {
                return this.gLACCOUNTField;
            }
            set
            {
                this.gLACCOUNTField = value;
            }
        }

        /// <remarks/>
        public int INHERIT
        {
            get
            {
                return this.iNHERITField;
            }
            set
            {
                this.iNHERITField = value;
            }
        }

        /// <remarks/>
        public int ISACTIVE
        {
            get
            {
                return this.iSACTIVEField;
            }
            set
            {
                this.iSACTIVEField = value;
            }
        }

        /// <remarks/>
        public string LABORCODE
        {
            get
            {
                return this.lABORCODEField;
            }
            set
            {
                this.lABORCODEField = value;
            }
        }

        /// <remarks/>
        public int LABORCRAFTRATEID
        {
            get
            {
                return this.lABORCRAFTRATEIDField;
            }
            set
            {
                this.lABORCRAFTRATEIDField = value;
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
        public decimal RATE
        {
            get
            {
                return this.rATEField;
            }
            set
            {
                this.rATEField = value;
            }
        }

        /// <remarks/>
        public string SKILLLEVEL
        {
            get
            {
                return this.sKILLLEVELField;
            }
            set
            {
                this.sKILLLEVELField = value;
            }
        }

        /// <remarks/>
        public decimal? STANDARDRATE
        {
            get
            {
                return this.sTANDARDRATEField;
            }
            set
            {
                this.sTANDARDRATEField = value;
            }
        }

        /// <remarks/>
        public string VENDOR
        {
            get
            {
                return this.vENDORField;
            }
            set
            {
                this.vENDORField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class LABORCRAFTRATEMboSetLABORCRAFTRATEGLACCOUNT
    {

        private string vALUEField;

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
    }
}