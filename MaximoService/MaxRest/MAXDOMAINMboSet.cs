using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class MAXDOMAINMboSet
    {

        private MAXDOMAINMboSetMAXDOMAIN[] mAXDOMAINField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("MAXDOMAIN")]
        public MAXDOMAINMboSetMAXDOMAIN[] MAXDOMAIN
        {
            get
            {
                return this.mAXDOMAINField;
            }
            set
            {
                this.mAXDOMAINField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class MAXDOMAINMboSetMAXDOMAIN
    {

        private string dOMAINIDField;

        private string dESCRIPTIONField;

        private MAXDOMAINMboSetMAXDOMAINDOMAINTYPE dOMAINTYPEField;

        private string lENGTHField;

        private ushort mAXDOMAINIDField;

        private string mAXTYPEField;

        private string sCALEField;

        private byte iNTERNALField;
        private long? nEVERCACHEField;

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
        public MAXDOMAINMboSetMAXDOMAINDOMAINTYPE DOMAINTYPE
        {
            get
            {
                return this.dOMAINTYPEField;
            }
            set
            {
                this.dOMAINTYPEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string LENGTH
        {
            get
            {
                return this.lENGTHField;
            }
            set
            {
                this.lENGTHField = value;
            }
        }

        /// <remarks/>
        public ushort MAXDOMAINID
        {
            get
            {
                return this.mAXDOMAINIDField;
            }
            set
            {
                this.mAXDOMAINIDField = value;
            }
        }

        /// <remarks/>
        public string MAXTYPE
        {
            get
            {
                return this.mAXTYPEField;
            }
            set
            {
                this.mAXTYPEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string SCALE
        {
            get
            {
                return this.sCALEField;
            }
            set
            {
                this.sCALEField = value;
            }
        }

        /// <remarks/>
        public byte INTERNAL
        {
            get
            {
                return this.iNTERNALField;
            }
            set
            {
                this.iNTERNALField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? NEVERCACHE
        {
            get
            {
                return this.nEVERCACHEField;
            }
            set
            {
                this.nEVERCACHEField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class MAXDOMAINMboSetMAXDOMAINDOMAINTYPE
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
