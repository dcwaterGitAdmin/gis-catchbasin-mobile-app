using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class SYNONYMDOMAINMboSet
    {

        private SYNONYMDOMAINMboSetSYNONYMDOMAIN[] sYNONYMDOMAINField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SYNONYMDOMAIN")]
        public SYNONYMDOMAINMboSetSYNONYMDOMAIN[] SYNONYMDOMAIN
        {
            get
            {
                return this.sYNONYMDOMAINField;
            }
            set
            {
                this.sYNONYMDOMAINField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class SYNONYMDOMAINMboSetSYNONYMDOMAIN
    {

        private string dOMAINIDField;

        private string mAXVALUEField;

        private string vALUEField;

        private byte dEFAULTSField;

        private string dESCRIPTIONField;

        private string oRGIDField;

        private string sITEIDField;

        private int sYNONYMDOMAINIDField;

        private string vALUEIDField;

        /// <remarks/>
        public string DOMAINID
        {
            get
            {
                return this.dOMAINIDField;
            }
            set
            {
                this.dOMAINIDField = value;
            }
        }

        /// <remarks/>
        public string MAXVALUE
        {
            get
            {
                return this.mAXVALUEField;
            }
            set
            {
                this.mAXVALUEField = value;
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

        /// <remarks/>
        public byte DEFAULTS
        {
            get
            {
                return this.dEFAULTSField;
            }
            set
            {
                this.dEFAULTSField = value;
            }
        }

        /// <remarks/>
        public string DESCRIPTION
        {
            get
            {
                return this.dESCRIPTIONField;
            }
            set
            {
                this.dESCRIPTIONField = value;
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
        public int SYNONYMDOMAINID
        {
            get
            {
                return this.sYNONYMDOMAINIDField;
            }
            set
            {
                this.sYNONYMDOMAINIDField = value;
            }
        }

        /// <remarks/>
        public string VALUEID
        {
            get
            {
                return this.vALUEIDField;
            }
            set
            {
                this.vALUEIDField = value;
            }
        }
    }
}
