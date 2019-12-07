using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class FAILURECODEMboSet
    {

        private FAILURECODEMboSetFAILURECODE[] fAILURECODEField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FAILURECODE")]
        public FAILURECODEMboSetFAILURECODE[] FAILURECODE
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
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class FAILURECODEMboSetFAILURECODE
    {

        private string dESCRIPTION_LONGDESCRIPTIONField;

        private string fAILURECODEField;

        private string dESCRIPTIONField;

        private string oRGIDField;

        private ushort fAILURECODEIDField;

        private byte hASLDField;

        private string lANGCODEField;

        /// <remarks/>
        public string DESCRIPTION_LONGDESCRIPTION
        {
            get
            {
                return this.dESCRIPTION_LONGDESCRIPTIONField;
            }
            set
            {
                this.dESCRIPTION_LONGDESCRIPTIONField = value;
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
        public ushort FAILURECODEID
        {
            get
            {
                return this.fAILURECODEIDField;
            }
            set
            {
                this.fAILURECODEIDField = value;
            }
        }

        /// <remarks/>
        public byte HASLD
        {
            get
            {
                return this.hASLDField;
            }
            set
            {
                this.hASLDField = value;
            }
        }

        /// <remarks/>
        public string LANGCODE
        {
            get
            {
                return this.lANGCODEField;
            }
            set
            {
                this.lANGCODEField = value;
            }
        }
    }
}
