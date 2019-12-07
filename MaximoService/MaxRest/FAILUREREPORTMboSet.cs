using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class FAILUREREPORTMboSet
    {

        private FAILUREREPORTMboSetFAILUREREPORT[] fAILUREREPORTField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FAILUREREPORT")]
        public FAILUREREPORTMboSetFAILUREREPORT[] FAILUREREPORT
        {
            get
            {
                return this.fAILUREREPORTField;
            }
            set
            {
                this.fAILUREREPORTField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class FAILUREREPORTMboSetFAILUREREPORT
    {

        private long? pARENTField;

        private string wONUMField;

        private string fAILURECODEField;

        private long lINENUMField;

        private string tYPEField;

        private string oRGIDField;

        private string sITEIDField;

        private string aSSETNUMField;

        private long fAILUREREPORTIDField;

        private string tICKETCLASSField;

        private string tICKETIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? PARENT
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
        public string FAILURECODE
        {
            get
            {
                return this.fAILURECODEField;
            }
            set
            {
                this.fAILURECODEField = value;
            }
        }

        /// <remarks/>
        public long LINENUM
        {
            get
            {
                return this.lINENUMField;
            }
            set
            {
                this.lINENUMField = value;
            }
        }

        /// <remarks/>
        public string TYPE
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
        public string ASSETNUM
        {
            get
            {
                return this.aSSETNUMField;
            }
            set
            {
                this.aSSETNUMField = value;
            }
        }

        /// <remarks/>
        public long FAILUREREPORTID
        {
            get
            {
                return this.fAILUREREPORTIDField;
            }
            set
            {
                this.fAILUREREPORTIDField = value;
            }
        }

        /// <remarks/>
        public string TICKETCLASS
        {
            get
            {
                return this.tICKETCLASSField;
            }
            set
            {
                this.tICKETCLASSField = value;
            }
        }

        /// <remarks/>
        public string TICKETID
        {
            get
            {
                return this.tICKETIDField;
            }
            set
            {
                this.tICKETIDField = value;
            }
        }
    }

}
