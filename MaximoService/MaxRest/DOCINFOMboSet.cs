using System;
using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class DOCINFOMboSet
    {

        private DOCINFOMboSetDOCINFO[] dOCINFOField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DOCINFO")]
        public DOCINFOMboSetDOCINFO[] DOCINFO
        {
            get
            {
                return this.dOCINFOField;
            }
            set
            {
                this.dOCINFOField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class DOCINFOMboSetDOCINFO
    {

        private string aPPField;

        private string dESCRIPTION_LONGDESCRIPTIONField;

        private string nEWDOCTYPEField;

        private string nEWURLNAMEField;

        private byte uPLOADField;

        private bool uPLOADFieldSpecified;

        private string wEBURLField;

        private string dOCUMENTField;

        private string dESCRIPTIONField;

        private string aPPLICATIONField;

        private string sTATUSField;

        private System.DateTime sTATUSDATEField;

        private System.DateTime cREATEDATEField;

        private int? rEVISIONField;

        private string eXTRA1Field;

        private string cHANGEBYField;

        private System.DateTime cHANGEDATEField;

        private string dOCLOCATIONField;

        private string dOCTYPEField;

        private string cREATEBYField;

        private DOCINFOMboSetDOCINFOURLTYPE uRLTYPEField;

        private string dMSNAMEField;

        private string uRLNAMEField;

        private string uRLPARAM1Field;

        private string uRLPARAM2Field;

        private string uRLPARAM3Field;

        private string uRLPARAM4Field;

        private string uRLPARAM5Field;

        private byte pRINTTHRULINKDFLTField;

        private byte uSEDEFAULTFILEPATHField;

        private byte sHOWField;

        private long dOCINFOIDField;

        private byte hASLDField;

        private string lANGCODEField;

        private string cONTENTUIDField;

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
        public string NEWDOCTYPE
        {
            get
            {
                return this.nEWDOCTYPEField;
            }
            set
            {
                this.nEWDOCTYPEField = value;
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
        public string APPLICATION
        {
            get
            {
                return this.aPPLICATIONField;
            }
            set
            {
                this.aPPLICATIONField = value;
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
        public System.DateTime STATUSDATE
        {
            get
            {
                return this.sTATUSDATEField;
            }
            set
            {
                this.sTATUSDATEField = value;
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public int? REVISION
        {
            get
            {
                return this.rEVISIONField;
            }
            set
            {
                this.rEVISIONField = value;
            }
        }

        /// <remarks/>
        public string EXTRA1
        {
            get
            {
                return this.eXTRA1Field;
            }
            set
            {
                this.eXTRA1Field = value;
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
        public string DOCLOCATION
        {
            get
            {
                return this.dOCLOCATIONField;
            }
            set
            {
                this.dOCLOCATIONField = value;
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
        public DOCINFOMboSetDOCINFOURLTYPE URLTYPE
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
        public byte PRINTTHRULINKDFLT
        {
            get
            {
                return this.pRINTTHRULINKDFLTField;
            }
            set
            {
                this.pRINTTHRULINKDFLTField = value;
            }
        }

        /// <remarks/>
        public byte USEDEFAULTFILEPATH
        {
            get
            {
                return this.uSEDEFAULTFILEPATHField;
            }
            set
            {
                this.uSEDEFAULTFILEPATHField = value;
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
        public string CONTENTUID
        {
            get
            {
                return this.cONTENTUIDField;
            }
            set
            {
                this.cONTENTUIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class DOCINFOMboSetDOCINFOURLTYPE
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
