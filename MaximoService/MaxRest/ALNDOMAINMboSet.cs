using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class ALNDOMAINMboSet
    {

        private ALNDOMAINMboSetALNDOMAIN[] aLNDOMAINField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ALNDOMAIN")]
        public ALNDOMAINMboSetALNDOMAIN[] ALNDOMAIN
        {
            get
            {
                return this.aLNDOMAINField;
            }
            set
            {
                this.aLNDOMAINField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class ALNDOMAINMboSetALNDOMAIN
    {

        private string dOMAINIDField;

        private string vALUEField;

        private ushort aLNDOMAINIDField;

        private string dESCRIPTIONField;

        private string oRGIDField;

        private string sITEIDField;

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
        public ushort ALNDOMAINID
        {
            get
            {
                return this.aLNDOMAINIDField;
            }
            set
            {
                this.aLNDOMAINIDField = value;
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
