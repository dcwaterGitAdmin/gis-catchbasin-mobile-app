using System;
using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class FAILUREREMARKMboSet
    {

        private FAILUREREMARKMboSetFAILUREREMARK[] fAILUREREMARKField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FAILUREREMARK")]
        public FAILUREREMARKMboSetFAILUREREMARK[] FAILUREREMARK
        {
            get
            {
                return this.fAILUREREMARKField;
            }
            set
            {
                this.fAILUREREMARKField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class FAILUREREMARKMboSetFAILUREREMARK
    {

        private string dESCRIPTION_LONGDESCRIPTIONField;

        private string wONUMField;

        private string dESCRIPTIONField;

        private DateTime? eNTERDATEField;

        private string oRGIDField;

        private string sITEIDField;

        private int fAILUREREMARKIDField;

        private byte hASLDField;

        private string lANGCODEField;

        private string tICKETCLASSField;

        private string tICKETIDField;

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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public DateTime? ENTERDATE
        {
            get
            {
                return this.eNTERDATEField;
            }
            set
            {
                this.eNTERDATEField = value;
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
        public int FAILUREREMARKID
        {
            get
            {
                return this.fAILUREREMARKIDField;
            }
            set
            {
                this.fAILUREREMARKIDField = value;
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
