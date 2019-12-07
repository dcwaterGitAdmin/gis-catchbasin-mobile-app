using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class FAILURELISTMboSet
    {

        private FAILURELISTMboSetFAILURELIST[] fAILURELISTField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FAILURELIST")]
        public FAILURELISTMboSetFAILURELIST[] FAILURELIST
        {
            get
            {
                return this.fAILURELISTField;
            }
            set
            {
                this.fAILURELISTField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class FAILURELISTMboSetFAILURELIST
    {

        private string fAILURECLASSField;

        private string fLCDESCRIPTIONField;

        private int fAILURELISTField;

        private string fAILURECODEField;

        private int? pARENTField;

        private FAILURELISTMboSetFAILURELISTTYPE tYPEField;

        private string oRGIDField;

        /// <remarks/>
        public string FAILURECLASS
        {
            get
            {
                return this.fAILURECLASSField;
            }
            set
            {
                this.fAILURECLASSField = value;
            }
        }

        /// <remarks/>
        public string FLCDESCRIPTION
        {
            get
            {
                return this.fLCDESCRIPTIONField;
            }
            set
            {
                this.fLCDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public int FAILURELIST
        {
            get
            {
                return this.fAILURELISTField;
            }
            set
            {
                this.fAILURELISTField = value;
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public int? PARENT
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
        public FAILURELISTMboSetFAILURELISTTYPE TYPE
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
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class FAILURELISTMboSetFAILURELISTTYPE
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
