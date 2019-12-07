using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class DOCLINKSMboSet
    {

        private DOCLINKSMboSetDOCLINKS[] dOCLINKSField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DOCLINKS")]
        public DOCLINKSMboSetDOCLINKS[] DOCLINKS
        {
            get
            {
                return this.dOCLINKSField;
            }
            set
            {
                this.dOCLINKSField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class DOCLINKSMboSetDOCLINKS
    {

        private byte aDDINFOField;

        private bool aDDINFOFieldSpecified;

        private string aPPField;

        private string dMSNAMEField;

        private string dESCRIPTIONField;

        private string rEFERENCEField;

        private string dOCVERSIONField;

        private byte sHOWField;

        private bool sHOWFieldSpecified;

        private byte uPLOADField;

        private bool uPLOADFieldSpecified;

        private string uRLNAMEField;

        private string uRLTYPEField;

        private string wEBURLField;

        private string dOCUMENTField;

        private string dOCTYPEField;

        private byte gETLATESTVERSIONField;

        private string kEYCOLUMNField;

        private string nEWURLNAMEField;

        private string cREATEBYField;

        private System.DateTime cREATEDATEField;

        private string cHANGEBYField;

        private System.DateTime cHANGEDATEField;

        private byte pRINTTHRULINKField;

        private byte cOPYLINKTOWOField;

        private long dOCINFOIDField;

        private long dOCLINKSIDField;

        private long oWNERIDField;

        private string oWNERTABLEField;

        private string dOCUMENTDATAField;
        
        private string uRLPARAM1Field;

        private string uRLPARAM2Field;

        private string uRLPARAM3Field;

        private string uRLPARAM4Field;

        private string uRLPARAM5Field;
 
        /// <remarks/>
        public byte ADDINFO
        {
            get
            {
                return this.aDDINFOField;
            }
            set
            {
                this.aDDINFOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ADDINFOSpecified
        {
            get
            {
                return this.aDDINFOFieldSpecified;
            }
            set
            {
                this.aDDINFOFieldSpecified = value;
            }
        }

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
        public string DMSNAME
        {
            get
            {
                return this.dMSNAMEField;
            }
            set
            {
                this.dMSNAMEField = value;
            }
        }

        /// <remarks/>
        public string DOCVERSION
        {
            get
            {
                return this.dOCVERSIONField;
            }
            set
            {
                this.dOCVERSIONField = value;
            }
        }

        /// <remarks/>
        public string REFERENCE
        {
            get
            {
                return this.rEFERENCEField;
            }
            set
            {
                this.rEFERENCEField = value;
            }
        }

        /// <remarks/>
        public byte SHOW
        {
            get
            {
                return this.sHOWField;
            }
            set
            {
                this.sHOWField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SHOWSpecified
        {
            get
            {
                return this.sHOWFieldSpecified;
            }
            set
            {
                this.sHOWFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte UPLOAD
        {
            get
            {
                return this.uPLOADField;
            }
            set
            {
                this.uPLOADField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UPLOADSpecified
        {
            get
            {
                return this.uPLOADFieldSpecified;
            }
            set
            {
                this.uPLOADFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string URLNAME
        {
            get
            {
                return this.uRLNAMEField;
            }
            set
            {
                this.uRLNAMEField = value;
            }
        }
        /// <remarks/>
        public string URLPARAM1
        {
            get
            {
                return this.uRLPARAM1Field;
            }
            set
            {
                this.uRLPARAM1Field = value;
            }
        }

        /// <remarks/>
        public string URLPARAM2
        {
            get
            {
                return this.uRLPARAM2Field;
            }
            set
            {
                this.uRLPARAM2Field = value;
            }
        }

        /// <remarks/>
        public string URLPARAM3
        {
            get
            {
                return this.uRLPARAM3Field;
            }
            set
            {
                this.uRLPARAM3Field = value;
            }
        }

        /// <remarks/>
        public string URLPARAM4
        {
            get
            {
                return this.uRLPARAM4Field;
            }
            set
            {
                this.uRLPARAM4Field = value;
            }
        }

        /// <remarks/>
        public string URLPARAM5
        {
            get
            {
                return this.uRLPARAM5Field;
            }
            set
            {
                this.uRLPARAM5Field = value;
            }
        }
 
        /// <remarks/>
        public string URLTYPE
        {
            get
            {
                return this.uRLTYPEField;
            }
            set
            {
                this.uRLTYPEField = value;
            }
        }

        /// <remarks/>
        public string WEBURL
        {
            get
            {
                return this.wEBURLField;
            }
            set
            {
                this.wEBURLField = value;
            }
        }

        /// <remarks/>
        public string DOCUMENT
        {
            get
            {
                return this.dOCUMENTField;
            }
            set
            {
                this.dOCUMENTField = value;
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
        public byte GETLATESTVERSION
        {
            get
            {
                return this.gETLATESTVERSIONField;
            }
            set
            {
                this.gETLATESTVERSIONField = value;
            }
        }
        /// <remarks/>
        public string KEYCOLUMN
        {
            get
            {
                return this.kEYCOLUMNField;
            }
            set
            {
                this.kEYCOLUMNField = value;
            }
        }

        /// <remarks/>
        public string NEWURLNAME
        {
            get
            {
                return this.nEWURLNAMEField;
            }
            set
            {
                this.nEWURLNAMEField = value;
            }
        }

        /// <remarks/>
        public string CREATEBY
        {
            get
            {
                return this.cREATEBYField;
            }
            set
            {
                this.cREATEBYField = value;
            }
        }

        /// <remarks/>
        public System.DateTime CREATEDATE
        {
            get
            {
                return this.cREATEDATEField;
            }
            set
            {
                this.cREATEDATEField = value;
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
        public byte PRINTTHRULINK
        {
            get
            {
                return this.pRINTTHRULINKField;
            }
            set
            {
                this.pRINTTHRULINKField = value;
            }
        }

        /// <remarks/>
        public byte COPYLINKTOWO
        {
            get
            {
                return this.cOPYLINKTOWOField;
            }
            set
            {
                this.cOPYLINKTOWOField = value;
            }
        }

        /// <remarks/>
        public long DOCINFOID
        {
            get
            {
                return this.dOCINFOIDField;
            }
            set
            {
                this.dOCINFOIDField = value;
            }
        }

        /// <remarks/>
        public long DOCLINKSID
        {
            get
            {
                return this.dOCLINKSIDField;
            }
            set
            {
                this.dOCLINKSIDField = value;
            }
        }

        /// <remarks/>
        public long OWNERID
        {
            get
            {
                return this.oWNERIDField;
            }
            set
            {
                this.oWNERIDField = value;
            }
        }

        /// <remarks/>
        public string OWNERTABLE
        {
            get
            {
                return this.oWNERTABLEField;
            }
            set
            {
                this.oWNERTABLEField = value;
            }
        }

        /// <remarks/>
        public string DOCUMENTDATA
        {
            get { return this.dOCUMENTDATAField; }
            set { this.dOCUMENTDATAField = value; }
        }

        private string rowstampField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rowstamp
        {
            get
            {
                return this.rowstampField;
            }
            set
            {
                this.rowstampField = value;
            }
        }

        
    }
}
