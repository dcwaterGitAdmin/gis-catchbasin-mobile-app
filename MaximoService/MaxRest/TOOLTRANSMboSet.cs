using System.Collections.Generic;
using System;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class TOOLTRANSMboSet
    {

        private TOOLTRANSMboSetTOOLTRANS[] tOOLTRANSField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TOOLTRANS")]
        public TOOLTRANSMboSetTOOLTRANS[] TOOLTRANS
        {
            get
            {
                return this.tOOLTRANSField;
            }
            set
            {
                this.tOOLTRANSField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class TOOLTRANSMboSetTOOLTRANS
    {

        private long? aCTUALSTASKIDField;

        private string fCPROJECTIDField;

        private string fCTASKIDField;

        private long? tASKIDField;

        private string wONUMField;

        private bool wONUMFieldSpecified;

        private string sOURCEMBOField;

        private System.DateTime tRANSDATEField;

        private decimal tOOLRATEField;

        private long tOOLQTYField;

        private decimal tOOLHRSField;

        private System.DateTime eNTERDATEField;

        private string eNTERBYField;

        private byte oUTSIDEField;

        private byte rOLLUPField;

        private string gLDEBITACCTField;

        private decimal lINECOSTField;

        private string gLCREDITACCTField;

        private string fINANCIALPERIODField;

        private string lOCATIONField;

        private decimal eXCHANGERATE2Field;

        private decimal lINECOST2Field;

        private string sOURCESYSIDField;

        private string oWNERSYSIDField;

        private string eXTERNALREFIDField;

        private string sENDERSYSIDField;

        private string fINCNTRLIDField;

        private string oRGIDField;

        private string sITEIDField;

        private string rEFWOField;

        private byte eNTEREDASTASKField;

        private string aSSETNUMField;

        private string iTEMNUMField;

        private string iTEMSETIDField;

        private string rOTASSETNUMField;

        private string rOTASSETSITEField;

        private long tOOLTRANSIDField;

        private string pLUSCCOMMENTField;
        private Nullable<System.DateTime> pLUSCDUEDATEField;
        private Nullable<System.DateTime> pLUSCEXPIRYDATEField;
        private string pLUSCLOTNUMField;
        private string pLUSCMANUFACTURERField;
        private string pLUSCTECHNICIANField;
        private Nullable<System.DateTime> pLUSCTOOLUSEDATEField;
        private string pLUSCTYPEField;
        private long hASLDField;
        private string lANGCODEField;
        private string aMCREWField;
        private string tOOLSQField;


        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? ACTUALSTASKID
        {
            get
            {
                return this.aCTUALSTASKIDField;
            }
            set
            {
                this.aCTUALSTASKIDField = value;
            }
        }

        /// <remarks/>
        public string FCPROJECTID
        {
            get
            {
                return this.fCPROJECTIDField;
            }
            set
            {
                this.fCPROJECTIDField = value;
            }
        }

        /// <remarks/>
        public string FCTASKID
        {
            get
            {
                return this.fCTASKIDField;
            }
            set
            {
                this.fCTASKIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? TASKID
        {
            get
            {
                return this.tASKIDField;
            }
            set
            {
                this.tASKIDField = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WONUMSpecified
        {
            get
            {
                return this.wONUMFieldSpecified;
            }
            set
            {
                this.wONUMFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string SOURCEMBO
        {
            get
            {
                return this.sOURCEMBOField;
            }
            set
            {
                this.sOURCEMBOField = value;
            }
        }

        /// <remarks/>
        public System.DateTime TRANSDATE
        {
            get
            {
                return this.tRANSDATEField;
            }
            set
            {
                this.tRANSDATEField = value;
            }
        }

        /// <remarks/>
        public decimal TOOLRATE
        {
            get
            {
                return this.tOOLRATEField;
            }
            set
            {
                this.tOOLRATEField = value;
            }
        }

        /// <remarks/>
        public long TOOLQTY
        {
            get
            {
                return this.tOOLQTYField;
            }
            set
            {
                this.tOOLQTYField = value;
            }
        }

        /// <remarks/>
        public decimal TOOLHRS
        {
            get
            {
                return this.tOOLHRSField;
            }
            set
            {
                this.tOOLHRSField = value;
            }
        }

        /// <remarks/>
        public System.DateTime ENTERDATE
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
        public string ENTERBY
        {
            get
            {
                return this.eNTERBYField;
            }
            set
            {
                this.eNTERBYField = value;
            }
        }

        /// <remarks/>
        public byte OUTSIDE
        {
            get
            {
                return this.oUTSIDEField;
            }
            set
            {
                this.oUTSIDEField = value;
            }
        }

        /// <remarks/>
        public byte ROLLUP
        {
            get
            {
                return this.rOLLUPField;
            }
            set
            {
                this.rOLLUPField = value;
            }
        }

        /// <remarks/>
        public string GLDEBITACCT
        {
            get
            {
                return this.gLDEBITACCTField;
            }
            set
            {
                this.gLDEBITACCTField = value;
            }
        }

        /// <remarks/>
        public decimal LINECOST
        {
            get
            {
                return this.lINECOSTField;
            }
            set
            {
                this.lINECOSTField = value;
            }
        }

        /// <remarks/>
        public string GLCREDITACCT
        {
            get
            {
                return this.gLCREDITACCTField;
            }
            set
            {
                this.gLCREDITACCTField = value;
            }
        }

        /// <remarks/>
        public string FINANCIALPERIOD
        {
            get
            {
                return this.fINANCIALPERIODField;
            }
            set
            {
                this.fINANCIALPERIODField = value;
            }
        }

        /// <remarks/>
        public string LOCATION
        {
            get
            {
                return this.lOCATIONField;
            }
            set
            {
                this.lOCATIONField = value;
            }
        }

        /// <remarks/>
        public decimal EXCHANGERATE2
        {
            get
            {
                return this.eXCHANGERATE2Field;
            }
            set
            {
                this.eXCHANGERATE2Field = value;
            }
        }

        /// <remarks/>
        public decimal LINECOST2
        {
            get
            {
                return this.lINECOST2Field;
            }
            set
            {
                this.lINECOST2Field = value;
            }
        }

        /// <remarks/>
        public string SOURCESYSID
        {
            get
            {
                return this.sOURCESYSIDField;
            }
            set
            {
                this.sOURCESYSIDField = value;
            }
        }

        /// <remarks/>
        public string OWNERSYSID
        {
            get
            {
                return this.oWNERSYSIDField;
            }
            set
            {
                this.oWNERSYSIDField = value;
            }
        }

        /// <remarks/>
        public string EXTERNALREFID
        {
            get
            {
                return this.eXTERNALREFIDField;
            }
            set
            {
                this.eXTERNALREFIDField = value;
            }
        }

        /// <remarks/>
        public string SENDERSYSID
        {
            get
            {
                return this.sENDERSYSIDField;
            }
            set
            {
                this.sENDERSYSIDField = value;
            }
        }

        /// <remarks/>
        public string FINCNTRLID
        {
            get
            {
                return this.fINCNTRLIDField;
            }
            set
            {
                this.fINCNTRLIDField = value;
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
        public string REFWO
        {
            get
            {
                return this.rEFWOField;
            }
            set
            {
                this.rEFWOField = value;
            }
        }

        /// <remarks/>
        public byte ENTEREDASTASK
        {
            get
            {
                return this.eNTEREDASTASKField;
            }
            set
            {
                this.eNTEREDASTASKField = value;
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
        public string ITEMNUM
        {
            get
            {
                return this.iTEMNUMField;
            }
            set
            {
                this.iTEMNUMField = value;
            }
        }

        /// <remarks/>
        public string ITEMSETID
        {
            get
            {
                return this.iTEMSETIDField;
            }
            set
            {
                this.iTEMSETIDField = value;
            }
        }

        /// <remarks/>
        public string ROTASSETNUM
        {
            get
            {
                return this.rOTASSETNUMField;
            }
            set
            {
                this.rOTASSETNUMField = value;
            }
        }

        /// <remarks/>
        public string ROTASSETSITE
        {
            get
            {
                return this.rOTASSETSITEField;
            }
            set
            {
                this.rOTASSETSITEField = value;
            }
        }

        /// <remarks/>
        public long TOOLTRANSID
        {
            get
            {
                return this.tOOLTRANSIDField;
            }
            set
            {
                this.tOOLTRANSIDField = value;
            }
        }

        public string PLUSCCOMMENT
        {
            get
            {
                return this.pLUSCCOMMENTField;
            }
            set 
            {
                this.pLUSCCOMMENTField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<System.DateTime> PLUSCDUEDATE
        {
            get
            {
                return this.pLUSCDUEDATEField;
            }
            set 
            {
                this.pLUSCDUEDATEField = value;
            }
        }
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<System.DateTime> PLUSCEXPIRYDATE
        {
            get
            {
                return this.pLUSCEXPIRYDATEField;
            }
            set 
            {
                this.pLUSCEXPIRYDATEField = value;
            }
        }
        public string PLUSCLOTNUM
        {
            get
            {
                return this.pLUSCLOTNUMField;
            }
            set 
            {
                this.pLUSCLOTNUMField = value;
            }
        }
        public string PLUSCMANUFACTURER
        {
            get
            {
                return this.pLUSCMANUFACTURERField;
            }
            set 
            {
                this.pLUSCMANUFACTURERField = value;
            }
        }
        public string PLUSCTECHNICIAN
        {
            get
            {
                return this.pLUSCTECHNICIANField;
            }
            set 
            {
                this.pLUSCTECHNICIANField = value;
            }
        }
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<System.DateTime> PLUSCTOOLUSEDATE
        {
            get
            {
                return this.pLUSCTOOLUSEDATEField;
            }
            set 
            {
                this.pLUSCTOOLUSEDATEField = value;
            }
        }
        public string PLUSCTYPE
        {
            get
            {
                return this.pLUSCTYPEField;
            }
            set 
            {
                this.pLUSCTYPEField = value;
            }
        }
        public long HASLD
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
        public string AMCREW
        {
            get
            {
                return this.aMCREWField;
            }
            set 
            {
                this.aMCREWField = value;
            }
        }
        public string TOOLSQ
        {
            get
            {
                return this.tOOLSQField;
            }
            set 
            {
                this.tOOLSQField = value;
            }
        }

    }

}
