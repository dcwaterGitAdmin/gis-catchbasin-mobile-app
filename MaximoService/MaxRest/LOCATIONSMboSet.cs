using System;
using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class LOCATIONSMboSet
    {

        private LOCATIONSMboSetLOCATIONS[] lOCATIONSField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LOCATIONS")]
        public LOCATIONSMboSetLOCATIONS[] LOCATIONS
        {
            get
            {
                return this.lOCATIONSField;
            }
            set
            {
                this.lOCATIONSField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class LOCATIONSMboSetLOCATIONS
    {

        private string aDDTOSTORELOCField;

        private string aDDTOSTORESITEIDField;

        private string cALNUMField;

        private byte cHILDRENField;

        private bool cHILDRENFieldSpecified;

        private string dESCRIPTION_LONGDESCRIPTIONField;

        private string fAILURECODEField;

        private string gROUPNAMEField;

        private byte hASCHILDRENField;

        private bool hASCHILDRENFieldSpecified;

        private byte hASPARENTField;

        private bool hASPARENTFieldSpecified;

        private string iTEMNUMField;

        private string iTEMSETIDField;

        private byte lOCPRIORITYField;

        private bool lOCPRIORITYFieldSpecified;

        private int? nEWPERCENTField;

        private string oBJECTNAMEField;

        private string pARENTField;

        private string sHIFTNUMField;

        private string sYSTEMIDField;

        private System.DateTime? wARRANTYEXPDATEField;

        private string cINUMField;

        private string hIERARCHYPATHField;

        private byte sTATUSIFACEField;

        private bool sTATUSIFACEFieldSpecified;

        private string pLUSSDESCRIPTION_LONGDESCRIPTIONField;

        private string pLUSSDIRECTIONS_LONGDESCRIPTIONField;

        private string lOCATIONField;

        private string dESCRIPTIONField;

        private LOCATIONSMboSetLOCATIONSTYPE tYPEField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT cONTROLACCField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT gLACCOUNTField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT pURCHVARACCField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT iNVOICEVARACCField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT cURVARACCField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT sHRINKAGEACCField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT iNVCOSTADJACCField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT rECEIPTVARACCField;

        private string cHANGEBYField;

        private System.DateTime cHANGEDATEField;

        private string lO1Field;

        private string lO2Field;

        private string lO4Field;

        private string lO5Field;

        private byte dISABLEDField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT oLDCONTROLACCField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT oLDSHRINKAGEACCField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT oLDINVCOSTADJACCField;

        private string cLASSSTRUCTUREIDField;

        private string gISPARAM1Field;

        private string gISPARAM2Field;

        private string gISPARAM3Field;

        private byte lO15Field;

        private string sOURCESYSIDField;

        private string oWNERSYSIDField;

        private string eXTERNALREFIDField;

        private string sENDERSYSIDField;

        private string sITEIDField;

        private string oRGIDField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT iNTLABRECField;

        private byte iSDEFAULTField;

        private string sHIPTOADDRESSCODEField;

        private string sHIPTOLABORCODEField;

        private string bILLTOADDRESSCODEField;

        private string bILLTOLABORCODEField;

        private string pREMISESTATUSField;

        private string cUSTOMERNUMField;

        private string aCCOUNTNUMField;

        private string qUADField;

        private byte aUTOWOGENField;

        private byte hASLDField;

        private string lANGCODEField;

        private long lOCATIONSIDField;

        private string sERVICEADDRESSCODEField;

        private LOCATIONSMboSetLOCATIONSSTATUS sTATUSField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNT tOOLCONTROLACCField;

        private byte uSEINPOPRField;

        private System.DateTime sTATUSDATEField;

        private byte dCW_MATLMGMTCTRLDField;
        
        private string iNVOWNERField;
        
        private long iSREPAIRFACILITYField;
        
        private System.DateTime pLUSCDUEDATEField;
        
        private long pLUSCLOOPField;
        
        private long pLUSCPMEXTDATEField;

        private string sADDRESSCODEField;

        private string pLUSSFEATURECLASSField;

        private byte pLUSSISGISField;

        private string pLUSSADDRESSCODEField;

        private string gEOWORXSYNCIDField;


        /// <remarks/>
        public string ADDTOSTORELOC
        {
            get
            {
                return this.aDDTOSTORELOCField;
            }
            set
            {
                this.aDDTOSTORELOCField = value;
            }
        }

        /// <remarks/>
        public string ADDTOSTORESITEID
        {
            get
            {
                return this.aDDTOSTORESITEIDField;
            }
            set
            {
                this.aDDTOSTORESITEIDField = value;
            }
        }

        /// <remarks/>
        public string CALNUM
        {
            get
            {
                return this.cALNUMField;
            }
            set
            {
                this.cALNUMField = value;
            }
        }

        /// <remarks/>
        public byte CHILDREN
        {
            get
            {
                return this.cHILDRENField;
            }
            set
            {
                this.cHILDRENField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CHILDRENSpecified
        {
            get
            {
                return this.cHILDRENFieldSpecified;
            }
            set
            {
                this.cHILDRENFieldSpecified = value;
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
        public string GROUPNAME
        {
            get
            {
                return this.gROUPNAMEField;
            }
            set
            {
                this.gROUPNAMEField = value;
            }
        }

        /// <remarks/>
        public byte HASCHILDREN
        {
            get
            {
                return this.hASCHILDRENField;
            }
            set
            {
                this.hASCHILDRENField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HASCHILDRENSpecified
        {
            get
            {
                return this.hASCHILDRENFieldSpecified;
            }
            set
            {
                this.hASCHILDRENFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte HASPARENT
        {
            get
            {
                return this.hASPARENTField;
            }
            set
            {
                this.hASPARENTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HASPARENTSpecified
        {
            get
            {
                return this.hASPARENTFieldSpecified;
            }
            set
            {
                this.hASPARENTFieldSpecified = value;
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
        public byte LOCPRIORITY
        {
            get
            {
                return this.lOCPRIORITYField;
            }
            set
            {
                this.lOCPRIORITYField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LOCPRIORITYSpecified
        {
            get
            {
                return this.lOCPRIORITYFieldSpecified;
            }
            set
            {
                this.lOCPRIORITYFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public int? NEWPERCENT
        {
            get
            {
                return this.nEWPERCENTField;
            }
            set
            {
                this.nEWPERCENTField = value;
            }
        }

        /// <remarks/>
        public string OBJECTNAME
        {
            get
            {
                return this.oBJECTNAMEField;
            }
            set
            {
                this.oBJECTNAMEField = value;
            }
        }

        /// <remarks/>
        public string PARENT
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
        public string SHIFTNUM
        {
            get
            {
                return this.sHIFTNUMField;
            }
            set
            {
                this.sHIFTNUMField = value;
            }
        }

        /// <remarks/>
        public string SYSTEMID
        {
            get
            {
                return this.sYSTEMIDField;
            }
            set
            {
                this.sYSTEMIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? WARRANTYEXPDATE
        {
            get
            {
                return this.wARRANTYEXPDATEField;
            }
            set
            {
                this.wARRANTYEXPDATEField = value;
            }
        }

        /// <remarks/>
        public string CINUM
        {
            get
            {
                return this.cINUMField;
            }
            set
            {
                this.cINUMField = value;
            }
        }

        /// <remarks/>
        public string HIERARCHYPATH
        {
            get
            {
                return this.hIERARCHYPATHField;
            }
            set
            {
                this.hIERARCHYPATHField = value;
            }
        }

        /// <remarks/>
        public byte STATUSIFACE
        {
            get
            {
                return this.sTATUSIFACEField;
            }
            set
            {
                this.sTATUSIFACEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool STATUSIFACESpecified
        {
            get
            {
                return this.sTATUSIFACEFieldSpecified;
            }
            set
            {
                this.sTATUSIFACEFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string PLUSSDESCRIPTION_LONGDESCRIPTION
        {
            get
            {
                return this.pLUSSDESCRIPTION_LONGDESCRIPTIONField;
            }
            set
            {
                this.pLUSSDESCRIPTION_LONGDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public string PLUSSDIRECTIONS_LONGDESCRIPTION
        {
            get
            {
                return this.pLUSSDIRECTIONS_LONGDESCRIPTIONField;
            }
            set
            {
                this.pLUSSDIRECTIONS_LONGDESCRIPTIONField = value;
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
        public LOCATIONSMboSetLOCATIONSTYPE TYPE
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
        public LOCATIONSMboSetLOCATIONSGLACCOUNT CONTROLACC
        {
            get
            {
                return this.cONTROLACCField;
            }
            set
            {
                this.cONTROLACCField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSGLACCOUNT GLACCOUNT
        {
            get
            {
                return this.gLACCOUNTField;
            }
            set
            {
                this.gLACCOUNTField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSGLACCOUNT PURCHVARACC
        {
            get
            {
                return this.pURCHVARACCField;
            }
            set
            {
                this.pURCHVARACCField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSGLACCOUNT INVOICEVARACC
        {
            get
            {
                return this.iNVOICEVARACCField;
            }
            set
            {
                this.iNVOICEVARACCField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSGLACCOUNT CURVARACC
        {
            get
            {
                return this.cURVARACCField;
            }
            set
            {
                this.cURVARACCField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSGLACCOUNT SHRINKAGEACC
        {
            get
            {
                return this.sHRINKAGEACCField;
            }
            set
            {
                this.sHRINKAGEACCField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSGLACCOUNT INVCOSTADJACC
        {
            get
            {
                return this.iNVCOSTADJACCField;
            }
            set
            {
                this.iNVCOSTADJACCField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSGLACCOUNT RECEIPTVARACC
        {
            get
            {
                return this.rECEIPTVARACCField;
            }
            set
            {
                this.rECEIPTVARACCField = value;
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
        public string LO1
        {
            get
            {
                return this.lO1Field;
            }
            set
            {
                this.lO1Field = value;
            }
        }

        /// <remarks/>
        public string LO2
        {
            get
            {
                return this.lO2Field;
            }
            set
            {
                this.lO2Field = value;
            }
        }

        /// <remarks/>
        public string LO4
        {
            get
            {
                return this.lO4Field;
            }
            set
            {
                this.lO4Field = value;
            }
        }

        /// <remarks/>
        public string LO5
        {
            get
            {
                return this.lO5Field;
            }
            set
            {
                this.lO5Field = value;
            }
        }

        /// <remarks/>
        public byte DISABLED
        {
            get
            {
                return this.dISABLEDField;
            }
            set
            {
                this.dISABLEDField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSGLACCOUNT OLDCONTROLACC
        {
            get
            {
                return this.oLDCONTROLACCField;
            }
            set
            {
                this.oLDCONTROLACCField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSGLACCOUNT OLDSHRINKAGEACC
        {
            get
            {
                return this.oLDSHRINKAGEACCField;
            }
            set
            {
                this.oLDSHRINKAGEACCField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSGLACCOUNT OLDINVCOSTADJACC
        {
            get
            {
                return this.oLDINVCOSTADJACCField;
            }
            set
            {
                this.oLDINVCOSTADJACCField = value;
            }
        }

        /// <remarks/>
        public string CLASSSTRUCTUREID
        {
            get
            {
                return this.cLASSSTRUCTUREIDField;
            }
            set
            {
                this.cLASSSTRUCTUREIDField = value;
            }
        }

        /// <remarks/>
        public string GISPARAM1
        {
            get
            {
                return this.gISPARAM1Field;
            }
            set
            {
                this.gISPARAM1Field = value;
            }
        }

        /// <remarks/>
        public string GISPARAM2
        {
            get
            {
                return this.gISPARAM2Field;
            }
            set
            {
                this.gISPARAM2Field = value;
            }
        }

        /// <remarks/>
        public string GISPARAM3
        {
            get
            {
                return this.gISPARAM3Field;
            }
            set
            {
                this.gISPARAM3Field = value;
            }
        }

        /// <remarks/>
        public byte LO15
        {
            get
            {
                return this.lO15Field;
            }
            set
            {
                this.lO15Field = value;
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
        public LOCATIONSMboSetLOCATIONSGLACCOUNT INTLABREC
        {
            get
            {
                return this.iNTLABRECField;
            }
            set
            {
                this.iNTLABRECField = value;
            }
        }

        /// <remarks/>
        public byte ISDEFAULT
        {
            get
            {
                return this.iSDEFAULTField;
            }
            set
            {
                this.iSDEFAULTField = value;
            }
        }

        /// <remarks/>
        public string SHIPTOADDRESSCODE
        {
            get
            {
                return this.sHIPTOADDRESSCODEField;
            }
            set
            {
                this.sHIPTOADDRESSCODEField = value;
            }
        }

        /// <remarks/>
        public string SHIPTOLABORCODE
        {
            get
            {
                return this.sHIPTOLABORCODEField;
            }
            set
            {
                this.sHIPTOLABORCODEField = value;
            }
        }

        /// <remarks/>
        public string BILLTOADDRESSCODE
        {
            get
            {
                return this.bILLTOADDRESSCODEField;
            }
            set
            {
                this.bILLTOADDRESSCODEField = value;
            }
        }

        /// <remarks/>
        public string BILLTOLABORCODE
        {
            get
            {
                return this.bILLTOLABORCODEField;
            }
            set
            {
                this.bILLTOLABORCODEField = value;
            }
        }

        /// <remarks/>
        public string PREMISESTATUS
        {
            get
            {
                return this.pREMISESTATUSField;
            }
            set
            {
                this.pREMISESTATUSField = value;
            }
        }

        /// <remarks/>
        public string CUSTOMERNUM
        {
            get
            {
                return this.cUSTOMERNUMField;
            }
            set
            {
                this.cUSTOMERNUMField = value;
            }
        }

        /// <remarks/>
        public string ACCOUNTNUM
        {
            get
            {
                return this.aCCOUNTNUMField;
            }
            set
            {
                this.aCCOUNTNUMField = value;
            }
        }

        /// <remarks/>
        public string QUAD
        {
            get
            {
                return this.qUADField;
            }
            set
            {
                this.qUADField = value;
            }
        }

        /// <remarks/>
        public byte AUTOWOGEN
        {
            get
            {
                return this.aUTOWOGENField;
            }
            set
            {
                this.aUTOWOGENField = value;
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
        public long LOCATIONSID
        {
            get
            {
                return this.lOCATIONSIDField;
            }
            set
            {
                this.lOCATIONSIDField = value;
            }
        }

        /// <remarks/>
        public string SERVICEADDRESSCODE
        {
            get
            {
                return this.sERVICEADDRESSCODEField;
            }
            set
            {
                this.sERVICEADDRESSCODEField = value;
            }
        }

        /// <remarks/>
        public LOCATIONSMboSetLOCATIONSSTATUS STATUS
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
        public LOCATIONSMboSetLOCATIONSGLACCOUNT TOOLCONTROLACC
        {
            get
            {
                return this.tOOLCONTROLACCField;
            }
            set
            {
                this.tOOLCONTROLACCField = value;
            }
        }

        /// <remarks/>
        public byte USEINPOPR
        {
            get
            {
                return this.uSEINPOPRField;
            }
            set
            {
                this.uSEINPOPRField = value;
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
        public byte DCW_MATLMGMTCTRLD
        {
            get
            {
                return this.dCW_MATLMGMTCTRLDField;
            }
            set
            {
                this.dCW_MATLMGMTCTRLDField = value;
            }
        }
        /// <remarks/>
        public string INVOWNER
        {
            get
            {
                return this.iNVOWNERField;
            }
            set
            {
                this.iNVOWNERField = value;
            }
        }

        /// <remarks/>
        public long ISREPAIRFACILITY
        {
            get
            {
                return this.iSREPAIRFACILITYField;
            }
            set
            {
                this.iSREPAIRFACILITYField = value;
            }
        }

        /// <remarks/>
        public System.DateTime PLUSCDUEDATE
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

        /// <remarks/>
        public long PLUSCLOOP
        {
            get
            {
                return this.pLUSCLOOPField;
            }
            set
            {
                this.pLUSCLOOPField = value;
            }
        }

        /// <remarks/>
        public long PLUSCPMEXTDATE
        {
            get
            {
                return this.pLUSCPMEXTDATEField;
            }
            set
            {
                this.pLUSCPMEXTDATEField = value;
            }
        }

        /// <remarks/>
        public string SADDRESSCODE
        {
            get
            {
                return this.sADDRESSCODEField;
            }
            set
            {
                this.sADDRESSCODEField = value;
            }
        }

        /// <remarks/>
        public string PLUSSFEATURECLASS
        {
            get
            {
                return this.pLUSSFEATURECLASSField;
            }
            set
            {
                this.pLUSSFEATURECLASSField = value;
            }
        }

        /// <remarks/>
        public byte PLUSSISGIS
        {
            get
            {
                return this.pLUSSISGISField;
            }
            set
            {
                this.pLUSSISGISField = value;
            }
        }

        /// <remarks/>
        public string PLUSSADDRESSCODE
        {
            get
            {
                return this.pLUSSADDRESSCODEField;
            }
            set
            {
                this.pLUSSADDRESSCODEField = value;
            }
        }

        /// <remarks/>
        public string GEOWORXSYNCID
        {
            get
            {
                return this.gEOWORXSYNCIDField;
            }
            set
            {
                this.gEOWORXSYNCIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class LOCATIONSMboSetLOCATIONSTYPE
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

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class LOCATIONSMboSetLOCATIONSGLACCOUNT
    {

        private string vALUEField;

        private LOCATIONSMboSetLOCATIONSGLACCOUNTGLCOMP gLCOMPField;

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
        public LOCATIONSMboSetLOCATIONSGLACCOUNTGLCOMP GLCOMP
        {
            get
            {
                return this.gLCOMPField;
            }
            set
            {
                this.gLCOMPField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class LOCATIONSMboSetLOCATIONSGLACCOUNTGLCOMP
    {

        private byte glorderField;

        private byte valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte glorder
        {
            get
            {
                return this.glorderField;
            }
            set
            {
                this.glorderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
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

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class LOCATIONSMboSetLOCATIONSSTATUS
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
