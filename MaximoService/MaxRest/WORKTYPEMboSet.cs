using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class WORKTYPEMboSet
    {

        private WORKTYPEMboSetWORKTYPE[] wORKTYPEField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WORKTYPE")]
        public WORKTYPEMboSetWORKTYPE[] WORKTYPE
        {
            get
            {
                return this.wORKTYPEField;
            }
            set
            {
                this.wORKTYPEField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class WORKTYPEMboSetWORKTYPE
    {

        private string wORKTYPEField;

        private string wTYPEDESCField;

        private byte pROMPTFAILField;

        private byte pROMPTDOWNField;

        private string oRGIDField;

        private WORKTYPEMboSetWORKTYPETYPE tYPEField;

        private WORKTYPEMboSetWORKTYPEWOCLASS wOCLASSField;

        private byte wORKTYPEIDField;

        private WORKTYPEMboSetWORKTYPECOMPLETESTATUS cOMPLETESTATUSField;

        private WORKTYPEMboSetWORKTYPESTARTSTATUS sTARTSTATUSField;

        private byte kEEPTASKSTATUSHISTField;

        private byte dCW_APPTRACKField;

        private byte dCW_CDCTRACKField;

        private byte dCW_DSSTRACKField;

        private byte dCW_DWSTRACKField;

        private byte dCW_FACTRACKField;

        private byte dCW_MOBTRACKField;

        private byte dCW_QUICKREPField;

        private byte dCW_WOTRACKField;

        private byte dCW_WQTRACKField;
        /// <remarks/>
        public string WORKTYPE
        {
            get
            {
                return this.wORKTYPEField;
            }
            set
            {
                this.wORKTYPEField = value;
            }
        }

        /// <remarks/>
        public string WTYPEDESC
        {
            get
            {
                return this.wTYPEDESCField;
            }
            set
            {
                this.wTYPEDESCField = value;
            }
        }

        /// <remarks/>
        public byte PROMPTFAIL
        {
            get
            {
                return this.pROMPTFAILField;
            }
            set
            {
                this.pROMPTFAILField = value;
            }
        }

        /// <remarks/>
        public byte PROMPTDOWN
        {
            get
            {
                return this.pROMPTDOWNField;
            }
            set
            {
                this.pROMPTDOWNField = value;
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
        public WORKTYPEMboSetWORKTYPETYPE TYPE
        {
            get
            {
                return this.tYPEField;
            }
            set
            {
                this.tYPEField = value;
            }
        }

        /// <remarks/>
        public WORKTYPEMboSetWORKTYPEWOCLASS WOCLASS
        {
            get
            {
                return this.wOCLASSField;
            }
            set
            {
                this.wOCLASSField = value;
            }
        }

        /// <remarks/>
        public byte WORKTYPEID
        {
            get
            {
                return this.wORKTYPEIDField;
            }
            set
            {
                this.wORKTYPEIDField = value;
            }
        }

        /// <remarks/>
        public WORKTYPEMboSetWORKTYPECOMPLETESTATUS COMPLETESTATUS
        {
            get
            {
                return this.cOMPLETESTATUSField;
            }
            set
            {
                this.cOMPLETESTATUSField = value;
            }
        }

        /// <remarks/>
        public WORKTYPEMboSetWORKTYPESTARTSTATUS STARTSTATUS
        {
            get
            {
                return this.sTARTSTATUSField;
            }
            set
            {
                this.sTARTSTATUSField = value;
            }
        }

        /// <remarks/>
        public byte KEEPTASKSTATUSHIST
        {
            get
            {
                return this.kEEPTASKSTATUSHISTField;
            }
            set
            {
                this.kEEPTASKSTATUSHISTField = value;
            }
        }

        /// <remarks/>
        public byte DCW_APPTRACK
        {
            get
            {
                return this.dCW_APPTRACKField;
            }
            set
            {
                this.dCW_APPTRACKField = value;
            }
        }

        /// <remarks/>
        public byte DCW_CDCTRACK
        {
            get
            {
                return this.dCW_CDCTRACKField;
            }
            set
            {
                this.dCW_CDCTRACKField = value;
            }
        }

        /// <remarks/>
        public byte DCW_DSSTRACK
        {
            get
            {
                return this.dCW_DSSTRACKField;
            }
            set
            {
                this.dCW_DSSTRACKField = value;
            }
        }

        /// <remarks/>
        public byte DCW_DWSTRACK
        {
            get
            {
                return this.dCW_DWSTRACKField;
            }
            set
            {
                this.dCW_DWSTRACKField = value;
            }
        }

        /// <remarks/>
        public byte DCW_FACTRACK
        {
            get
            {
                return this.dCW_FACTRACKField;
            }
            set
            {
                this.dCW_FACTRACKField = value;
            }
        }


        /// <remarks/>
        public byte DCW_MOBTRACK
        {
            get
            {
                return this.dCW_MOBTRACKField;
            }
            set
            {
                this.dCW_MOBTRACKField = value;
            }
        }

        /// <remarks/>
        public byte DCW_QUICKREP
        {
            get
            {
                return this.dCW_QUICKREPField;
            }
            set
            {
                this.dCW_QUICKREPField = value;
            }
        }

        /// <remarks/>
        public byte DCW_WOTRACK
        {
            get
            {
                return this.dCW_WOTRACKField;
            }
            set
            {
                this.dCW_WOTRACKField = value;
            }
        }

        /// <remarks/>
        public byte DCW_WQTRACK
        {
            get
            {
                return this.dCW_WQTRACKField;
            }
            set
            {
                this.dCW_WQTRACKField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class WORKTYPEMboSetWORKTYPETYPE
    {

        private string maxvalueField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string maxvalue
        {
            get
            {
                return this.maxvalueField;
            }
            set
            {
                this.maxvalueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class WORKTYPEMboSetWORKTYPEWOCLASS
    {

        private string maxvalueField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string maxvalue
        {
            get
            {
                return this.maxvalueField;
            }
            set
            {
                this.maxvalueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class WORKTYPEMboSetWORKTYPECOMPLETESTATUS
    {

        private string maxvalueField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string maxvalue
        {
            get
            {
                return this.maxvalueField;
            }
            set
            {
                this.maxvalueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class WORKTYPEMboSetWORKTYPESTARTSTATUS
    {

        private string maxvalueField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string maxvalue
        {
            get
            {
                return this.maxvalueField;
            }
            set
            {
                this.maxvalueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
}
