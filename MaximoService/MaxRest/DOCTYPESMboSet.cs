using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class DOCTYPESMboSet
    {

        private DOCTYPESMboSetDOCTYPES[] dOCTYPESField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DOCTYPES")]
        public DOCTYPESMboSetDOCTYPES[] DOCTYPES
        {
            get
            {
                return this.dOCTYPESField;
            }
            set
            {
                this.dOCTYPESField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class DOCTYPESMboSetDOCTYPES
    {

        private string aPPField;

        private string dOCTYPEField;

        private string dESCRIPTIONField;

        private string dEFAULTFILEPATHField;

        private ushort dOCTYPESIDField;

        /// <remarks/>
        public string APP
        {
            get
            {
                return this.aPPField;
            }
            set
            {
                this.aPPField = value;
            }
        }

        /// <remarks/>
        public string DOCTYPE
        {
            get
            {
                return this.dOCTYPEField;
            }
            set
            {
                this.dOCTYPEField = value;
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
        public string DEFAULTFILEPATH
        {
            get
            {
                return this.dEFAULTFILEPATHField;
            }
            set
            {
                this.dEFAULTFILEPATHField = value;
            }
        }

        /// <remarks/>
        public ushort DOCTYPESID
        {
            get
            {
                return this.dOCTYPESIDField;
            }
            set
            {
                this.dOCTYPESIDField = value;
            }
        }
    }


}
