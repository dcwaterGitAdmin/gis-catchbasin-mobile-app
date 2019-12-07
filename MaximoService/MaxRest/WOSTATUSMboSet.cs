using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class WOSTATUSMboSet
    {

        private WOSTATUSMboSetWOSTATUS[] wOSTATUSField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WOSTATUS")]
        public WOSTATUSMboSetWOSTATUS[] WOSTATUS
        {
            get
            {
                return this.wOSTATUSField;
            }
            set
            {
                this.wOSTATUSField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class WOSTATUSMboSetWOSTATUS
    {

        private string fCPROJECTIDField;

        private string fCTASKIDField;

        private string wONUMField;

        private string sTATUSField;

        private System.DateTime cHANGEDATEField;

        private string cHANGEBYField;

        private string mEMOField;

        private WOSTATUSGLACCOUNT gLACCOUNTField;

        private string fINCNTRLIDField;

        private string oRGIDField;

        private string sITEIDField;

        private int wOSTATUSIDField;

        private string pARENTField;

        /// <remarks/>
        public string FCPROJECTID
        {
            get
            {
                return this.fCPROJECTIDField;
            }
            set
            {
                this.fCPROJECTIDField = value;
            }
        }

        /// <remarks/>
        public string FCTASKID
        {
            get
            {
                return this.fCTASKIDField;
            }
            set
            {
                this.fCTASKIDField = value;
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
        public string STATUS
        {
            get
            {
                return this.sTATUSField;
            }
            set
            {
                this.sTATUSField = value;
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
        public string MEMO
        {
            get
            {
                return this.mEMOField;
            }
            set
            {
                this.mEMOField = value;
            }
        }

        /// <remarks/>
        public WOSTATUSGLACCOUNT GLACCOUNT
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
        public string FINCNTRLID
        {
            get
            {
                return this.fINCNTRLIDField;
            }
            set
            {
                this.fINCNTRLIDField = value;
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
        public int WOSTATUSID
        {
            get
            {
                return this.wOSTATUSIDField;
            }
            set
            {
                this.wOSTATUSIDField = value;
            }
        }

        /// <remarks/>
        public string PARENT
        {
            get
            {
                return this.pARENTField;
            }
            set
            {
                this.pARENTField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class WOSTATUSGLACCOUNT
    {

        private string vALUEField;

        private WOSTATUSGLACCOUNTGLCOMP gLCOMPField;

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

        /// <remarks/>
        public WOSTATUSGLACCOUNTGLCOMP GLCOMP
        {
            get
            {
                return this.gLCOMPField;
            }
            set
            {
                this.gLCOMPField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class WOSTATUSGLACCOUNTGLCOMP
    {

        private byte glorderField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte glorder
        {
            get
            {
                return this.glorderField;
            }
            set
            {
                this.glorderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
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
