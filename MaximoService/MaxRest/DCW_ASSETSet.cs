using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCWaterMobile.MaximoService.MaxRest
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class DCW_CBASSETSet
    {

        private DCW_ASSET[] aSSETField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ASSET")]
        public DCW_ASSET[] ASSET
        {
            get
            {
                return this.aSSETField;
            }
            set
            {
                this.aSSETField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class DCW_ASSET
    {
        #region ASSETMbo
        private byte aDDTOSTOREField;

        private bool aDDTOSTOREFieldSpecified;

        private string dESCRIPTION_LONGDESCRIPTIONField;

        private string fROMCONDITIONCODEField;

        private ASSETGLACCOUNT gLCREDITACCTField;

        private ASSETGLACCOUNT gLDEBITACCTField;

        private byte hASCHILDRENField;

        private bool hASCHILDRENFieldSpecified;

        private byte hASPARENTField;

        private bool hASPARENTFieldSpecified;

        private System.DateTime mOVEDATEField;

        private bool mOVEDATEFieldSpecified;

        private string mOVEDBYField;

        private string mOVEMEMOField;

        private string mOVEMODIFYBINNUMField;

        private string nEWASSETNUMField;

        private bool nEWASSETNUMFieldSpecified;

        private string nEWDEPARTMENTField;

        private string nEWLOCATIONField;

        private string nEWPARENTField;

        private string nEWREPLACEASSETNUMField;

        private string nEWSITEField;

        private string nEWSTATUSField;

        private string nP_STATUSMEMOField;

        private string oBJECTNAMEField;

        private string rEFWOField;

        private string rEPLACEASSETNUMField;

        private string rEPLACEASSETSITEField;

        private long? tASKIDField;

        private string wONUMField;

        private System.DateTime aSOFDATEField;

        private bool aSOFDATEFieldSpecified;

        private string cINUMField;

        private decimal fROMMEASUREField;

        private bool fROMMEASUREFieldSpecified;

        private string hIERARCHYPATHField;

        private long? mULTIIDField;

        private byte sTATUSIFACEField;

        private bool sTATUSIFACEFieldSpecified;

        private decimal tOMEASUREField;

        private bool tOMEASUREFieldSpecified;

        private string sTARTDESCRIPTION_LONGDESCRIPTIONField;

        private string eNDDESCRIPTION_LONGDESCRIPTIONField;

        private byte rOLLTOALLCHILDRENField;

        private bool rOLLTOALLCHILDRENFieldSpecified;

        private byte rEMOVEFROMACTIVEROUTESField;

        private bool rEMOVEFROMACTIVEROUTESFieldSpecified;

        private byte rEMOVEFROMACTIVESPField;

        private bool rEMOVEFROMACTIVESPFieldSpecified;

        private byte cHANGEPMSTATUSField;

        private bool cHANGEPMSTATUSFieldSpecified;

        private string pLUSSDESCRIPTION_LONGDESCRIPTIONField;

        private string pLUSSDIRECTIONS_LONGDESCRIPTIONField;

        private string aNCESTORField;

        private long aSSETIDField;

        private string aSSETNUMField;

        private string aSSETTAGField;

        private string aSSETTYPEField;

        private long aSSETUIDField;

        private byte aUTOWOGENField;

        private string bINNUMField;

        private decimal bUDGETCOSTField;

        private string cALNUMField;

        private string cHANGEBYField;

        private System.DateTime cHANGEDATEField;

        private byte cHILDRENField;

        private string cLASSSTRUCTUREIDField;

        private string cONDITIONCODEField;

        private string dESCRIPTIONField;

        private byte dISABLEDField;

        private string eQ1Field;

        private string eQ10Field;

        private string eQ11Field;

        private string eQ12Field;

        private string eQ2Field;

        private System.DateTime? eQ23Field;

        private decimal? eQ24Field;

        private string eQ3Field;

        private string eQ4Field;

        private decimal? eQ5Field;

        private System.DateTime? eQ6Field;

        private string eQ7Field;

        private string eQ8Field;

        private string eQ9Field;

        private string eXTERNALREFIDField;

        private string fAILURECODEField;

        private ASSETGLACCOUNT gLACCOUNTField;

        private string gROUPNAMEField;

        private byte hASLDField;

        private System.DateTime? iNSTALLDATEField;

        private decimal iNVCOSTField;

        private byte iSRUNNINGField;

        private string iTEMNUMField;

        private string iTEMSETIDField;

        private string iTEMTYPEField;

        private string lANGCODEField;

        private string lOCATIONField;

        private byte mAINTHIERCHYField;

        private string mANUFACTURERField;

        private byte mOVEDField;

        private string oRGIDField;

        private string oWNERSYSIDField;

        private string pARENTField;

        private long? pRIORITYField;

        private decimal pURCHASEPRICEField;

        private decimal rEPLACECOSTField;

        private ASSETGLACCOUNT rOTSUSPACCTField;

        private string sENDERSYSIDField;

        private string sERIALNUMField;

        private string sHIFTNUMField;

        private string sITEIDField;

        private string sOURCESYSIDField;

        private ASSETSTATUS sTATUSField;

        private System.DateTime? sTATUSDATEField;

        private ASSETGLACCOUNT tOOLCONTROLACCOUNTField;

        private decimal? tOOLRATEField;

        private decimal tOTALCOSTField;

        private decimal tOTDOWNTIMEField;

        private decimal tOTUNCHARGEDCOSTField;

        private decimal uNCHARGEDCOSTField;

        private string uSAGEField;

        private string vENDORField;

        private System.DateTime? wARRANTYEXPDATEField;

        private decimal yTDCOSTField;

        private string eQ13Field;

        private string eQ14Field;

        private string eQ15Field;

        private string eQ16Field;

        private System.DateTime? eQ19Field;

        private byte eQ22Field;

        private string mAPNUMField;

        private byte fIXEDASSETField;

        private decimal? x1Field;

        private decimal? x2Field;

        private decimal? y1Field;

        private decimal? y2Field;

        private string gLOBALIDField;

        private string dIRECTIONField;

        private string eNDDESCRIPTIONField;

        private decimal? eNDMEASUREField;

        private byte iSLINEARField;

        private string sTARTDESCRIPTIONField;

        private decimal? sTARTMEASUREField;

        private string lRMField;

        private string pLUSSFEATURECLASSField;

        private byte pLUSSISGISField;

        private string pLUSSADDRESSCODEField;

        private string dEFAULTREPFACSITEIDField;
        private string dEFAULTREPFACField;
        private long rETURNEDTOVENDORField;
        private string tLOAMHASHField;
        private long tLOAMPARTITIONField;
        private string pLUSCASSETDEPTField;
        private string pLUSCCLASSField;
        private Nullable<System.DateTime> pLUSCDUEDATEField;
        private string pLUSCISCONDESCField;
        private long pLUSCISCONTAMField;
        private long pLUSCISINHOUSECALField;
        private long pLUSCISMTEField;
        private string pLUSCISMTECLASSField;
        private string pLUSCLOOPNUMField;
        private string pLUSCMODELNUMField;
        private string pLUSCOPRGEEUField;
        private string pLUSCOPRGEFROMField;
        private string pLUSCOPRGETOField;
        private string pLUSCPHYLOCField;
        private long pLUSCPMEXTDATEField;
        private long pLUSCSOLUTIONField;
        private string pLUSCSUMDIRField;
        private string pLUSCSUMEUField;
        private string pLUSCSUMREADField;
        private string pLUSCSUMSPANField;
        private string pLUSCSUMURVField;
        private string pLUSCVENDORField;
        private long iSCALIBRATIONField;
        private string tEMPLATEIDField;
        private string pLUSCLPLOCField;
        private string sADDRESSCODEField;
        private ASSETSPECMboSetASSETSPEC[] aSSETSPECField;

        /// <remarks/>
        public byte ADDTOSTORE
        {
            get
            {
                return this.aDDTOSTOREField;
            }
            set
            {
                this.aDDTOSTOREField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ADDTOSTORESpecified
        {
            get
            {
                return this.aDDTOSTOREFieldSpecified;
            }
            set
            {
                this.aDDTOSTOREFieldSpecified = value;
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
        public string FROMCONDITIONCODE
        {
            get
            {
                return this.fROMCONDITIONCODEField;
            }
            set
            {
                this.fROMCONDITIONCODEField = value;
            }
        }

        /// <remarks/>
        public ASSETGLACCOUNT GLCREDITACCT
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
        public ASSETGLACCOUNT GLDEBITACCT
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
        public System.DateTime MOVEDATE
        {
            get
            {
                return this.mOVEDATEField;
            }
            set
            {
                this.mOVEDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MOVEDATESpecified
        {
            get
            {
                return this.mOVEDATEFieldSpecified;
            }
            set
            {
                this.mOVEDATEFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string MOVEDBY
        {
            get
            {
                return this.mOVEDBYField;
            }
            set
            {
                this.mOVEDBYField = value;
            }
        }

        /// <remarks/>
        public string MOVEMEMO
        {
            get
            {
                return this.mOVEMEMOField;
            }
            set
            {
                this.mOVEMEMOField = value;
            }
        }

        /// <remarks/>
        public string MOVEMODIFYBINNUM
        {
            get
            {
                return this.mOVEMODIFYBINNUMField;
            }
            set
            {
                this.mOVEMODIFYBINNUMField = value;
            }
        }

        /// <remarks/>
        public string NEWASSETNUM
        {
            get
            {
                return this.nEWASSETNUMField;
            }
            set
            {
                this.nEWASSETNUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NEWASSETNUMSpecified
        {
            get
            {
                return this.nEWASSETNUMFieldSpecified;
            }
            set
            {
                this.nEWASSETNUMFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string NEWDEPARTMENT
        {
            get
            {
                return this.nEWDEPARTMENTField;
            }
            set
            {
                this.nEWDEPARTMENTField = value;
            }
        }

        /// <remarks/>
        public string NEWLOCATION
        {
            get
            {
                return this.nEWLOCATIONField;
            }
            set
            {
                this.nEWLOCATIONField = value;
            }
        }

        /// <remarks/>
        public string NEWPARENT
        {
            get
            {
                return this.nEWPARENTField;
            }
            set
            {
                this.nEWPARENTField = value;
            }
        }

        /// <remarks/>
        public string NEWREPLACEASSETNUM
        {
            get
            {
                return this.nEWREPLACEASSETNUMField;
            }
            set
            {
                this.nEWREPLACEASSETNUMField = value;
            }
        }

        /// <remarks/>
        public string NEWSITE
        {
            get
            {
                return this.nEWSITEField;
            }
            set
            {
                this.nEWSITEField = value;
            }
        }

        /// <remarks/>
        public string NEWSTATUS
        {
            get
            {
                return this.nEWSTATUSField;
            }
            set
            {
                this.nEWSTATUSField = value;
            }
        }

        /// <remarks/>
        public string NP_STATUSMEMO
        {
            get
            {
                return this.nP_STATUSMEMOField;
            }
            set
            {
                this.nP_STATUSMEMOField = value;
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
        public string REPLACEASSETNUM
        {
            get
            {
                return this.rEPLACEASSETNUMField;
            }
            set
            {
                this.rEPLACEASSETNUMField = value;
            }
        }

        /// <remarks/>
        public string REPLACEASSETSITE
        {
            get
            {
                return this.rEPLACEASSETSITEField;
            }
            set
            {
                this.rEPLACEASSETSITEField = value;
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
        public System.DateTime ASOFDATE
        {
            get
            {
                return this.aSOFDATEField;
            }
            set
            {
                this.aSOFDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ASOFDATESpecified
        {
            get
            {
                return this.aSOFDATEFieldSpecified;
            }
            set
            {
                this.aSOFDATEFieldSpecified = value;
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
        public decimal FROMMEASURE
        {
            get
            {
                return this.fROMMEASUREField;
            }
            set
            {
                this.fROMMEASUREField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FROMMEASURESpecified
        {
            get
            {
                return this.fROMMEASUREFieldSpecified;
            }
            set
            {
                this.fROMMEASUREFieldSpecified = value;
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? MULTIID
        {
            get
            {
                return this.mULTIIDField;
            }
            set
            {
                this.mULTIIDField = value;
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
        public decimal TOMEASURE
        {
            get
            {
                return this.tOMEASUREField;
            }
            set
            {
                this.tOMEASUREField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TOMEASURESpecified
        {
            get
            {
                return this.tOMEASUREFieldSpecified;
            }
            set
            {
                this.tOMEASUREFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string STARTDESCRIPTION_LONGDESCRIPTION
        {
            get
            {
                return this.sTARTDESCRIPTION_LONGDESCRIPTIONField;
            }
            set
            {
                this.sTARTDESCRIPTION_LONGDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public string ENDDESCRIPTION_LONGDESCRIPTION
        {
            get
            {
                return this.eNDDESCRIPTION_LONGDESCRIPTIONField;
            }
            set
            {
                this.eNDDESCRIPTION_LONGDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public byte ROLLTOALLCHILDREN
        {
            get
            {
                return this.rOLLTOALLCHILDRENField;
            }
            set
            {
                this.rOLLTOALLCHILDRENField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ROLLTOALLCHILDRENSpecified
        {
            get
            {
                return this.rOLLTOALLCHILDRENFieldSpecified;
            }
            set
            {
                this.rOLLTOALLCHILDRENFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte REMOVEFROMACTIVEROUTES
        {
            get
            {
                return this.rEMOVEFROMACTIVEROUTESField;
            }
            set
            {
                this.rEMOVEFROMACTIVEROUTESField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool REMOVEFROMACTIVEROUTESSpecified
        {
            get
            {
                return this.rEMOVEFROMACTIVEROUTESFieldSpecified;
            }
            set
            {
                this.rEMOVEFROMACTIVEROUTESFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte REMOVEFROMACTIVESP
        {
            get
            {
                return this.rEMOVEFROMACTIVESPField;
            }
            set
            {
                this.rEMOVEFROMACTIVESPField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool REMOVEFROMACTIVESPSpecified
        {
            get
            {
                return this.rEMOVEFROMACTIVESPFieldSpecified;
            }
            set
            {
                this.rEMOVEFROMACTIVESPFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte CHANGEPMSTATUS
        {
            get
            {
                return this.cHANGEPMSTATUSField;
            }
            set
            {
                this.cHANGEPMSTATUSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CHANGEPMSTATUSSpecified
        {
            get
            {
                return this.cHANGEPMSTATUSFieldSpecified;
            }
            set
            {
                this.cHANGEPMSTATUSFieldSpecified = value;
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
        public string ANCESTOR
        {
            get
            {
                return this.aNCESTORField;
            }
            set
            {
                this.aNCESTORField = value;
            }
        }

        /// <remarks/>
        public long ASSETID
        {
            get
            {
                return this.aSSETIDField;
            }
            set
            {
                this.aSSETIDField = value;
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
        public string ASSETTAG
        {
            get
            {
                return this.aSSETTAGField;
            }
            set
            {
                this.aSSETTAGField = value;
            }
        }

        /// <remarks/>
        public string ASSETTYPE
        {
            get
            {
                return this.aSSETTYPEField;
            }
            set
            {
                this.aSSETTYPEField = value;
            }
        }

        /// <remarks/>
        public long ASSETUID
        {
            get
            {
                return this.aSSETUIDField;
            }
            set
            {
                this.aSSETUIDField = value;
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
        public string BINNUM
        {
            get
            {
                return this.bINNUMField;
            }
            set
            {
                this.bINNUMField = value;
            }
        }

        /// <remarks/>
        public decimal BUDGETCOST
        {
            get
            {
                return this.bUDGETCOSTField;
            }
            set
            {
                this.bUDGETCOSTField = value;
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
        public string CONDITIONCODE
        {
            get
            {
                return this.cONDITIONCODEField;
            }
            set
            {
                this.cONDITIONCODEField = value;
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
        public string EQ1
        {
            get
            {
                return this.eQ1Field;
            }
            set
            {
                this.eQ1Field = value;
            }
        }

        /// <remarks/>
        public string EQ10
        {
            get
            {
                return this.eQ10Field;
            }
            set
            {
                this.eQ10Field = value;
            }
        }

        /// <remarks/>
        public string EQ11
        {
            get
            {
                return this.eQ11Field;
            }
            set
            {
                this.eQ11Field = value;
            }
        }

        /// <remarks/>
        public string EQ12
        {
            get
            {
                return this.eQ12Field;
            }
            set
            {
                this.eQ12Field = value;
            }
        }

        /// <remarks/>
        public string EQ2
        {
            get
            {
                return this.eQ2Field;
            }
            set
            {
                this.eQ2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? EQ23
        {
            get
            {
                return this.eQ23Field;
            }
            set
            {
                this.eQ23Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? EQ24
        {
            get
            {
                return this.eQ24Field;
            }
            set
            {
                this.eQ24Field = value;
            }
        }

        /// <remarks/>
        public string EQ3
        {
            get
            {
                return this.eQ3Field;
            }
            set
            {
                this.eQ3Field = value;
            }
        }

        /// <remarks/>
        public string EQ4
        {
            get
            {
                return this.eQ4Field;
            }
            set
            {
                this.eQ4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? EQ5
        {
            get
            {
                return this.eQ5Field;
            }
            set
            {
                this.eQ5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? EQ6
        {
            get
            {
                return this.eQ6Field;
            }
            set
            {
                this.eQ6Field = value;
            }
        }

        /// <remarks/>
        public string EQ7
        {
            get
            {
                return this.eQ7Field;
            }
            set
            {
                this.eQ7Field = value;
            }
        }

        /// <remarks/>
        public string EQ8
        {
            get
            {
                return this.eQ8Field;
            }
            set
            {
                this.eQ8Field = value;
            }
        }

        /// <remarks/>
        public string EQ9
        {
            get
            {
                return this.eQ9Field;
            }
            set
            {
                this.eQ9Field = value;
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
        public ASSETGLACCOUNT GLACCOUNT
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? INSTALLDATE
        {
            get
            {
                return this.iNSTALLDATEField;
            }
            set
            {
                this.iNSTALLDATEField = value;
            }
        }

        /// <remarks/>
        public decimal INVCOST
        {
            get
            {
                return this.iNVCOSTField;
            }
            set
            {
                this.iNVCOSTField = value;
            }
        }

        /// <remarks/>
        public byte ISRUNNING
        {
            get
            {
                return this.iSRUNNINGField;
            }
            set
            {
                this.iSRUNNINGField = value;
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
        public string ITEMTYPE
        {
            get
            {
                return this.iTEMTYPEField;
            }
            set
            {
                this.iTEMTYPEField = value;
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
        public byte MAINTHIERCHY
        {
            get
            {
                return this.mAINTHIERCHYField;
            }
            set
            {
                this.mAINTHIERCHYField = value;
            }
        }

        /// <remarks/>
        public string MANUFACTURER
        {
            get
            {
                return this.mANUFACTURERField;
            }
            set
            {
                this.mANUFACTURERField = value;
            }
        }

        /// <remarks/>
        public byte MOVED
        {
            get
            {
                return this.mOVEDField;
            }
            set
            {
                this.mOVEDField = value;
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? PRIORITY
        {
            get
            {
                return this.pRIORITYField;
            }
            set
            {
                this.pRIORITYField = value;
            }
        }

        /// <remarks/>
        public decimal PURCHASEPRICE
        {
            get
            {
                return this.pURCHASEPRICEField;
            }
            set
            {
                this.pURCHASEPRICEField = value;
            }
        }

        /// <remarks/>
        public decimal REPLACECOST
        {
            get
            {
                return this.rEPLACECOSTField;
            }
            set
            {
                this.rEPLACECOSTField = value;
            }
        }

        /// <remarks/>
        public ASSETGLACCOUNT ROTSUSPACCT
        {
            get
            {
                return this.rOTSUSPACCTField;
            }
            set
            {
                this.rOTSUSPACCTField = value;
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
        public string SERIALNUM
        {
            get
            {
                return this.sERIALNUMField;
            }
            set
            {
                this.sERIALNUMField = value;
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
        public ASSETSTATUS STATUS
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? STATUSDATE
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
        public ASSETGLACCOUNT TOOLCONTROLACCOUNT
        {
            get
            {
                return this.tOOLCONTROLACCOUNTField;
            }
            set
            {
                this.tOOLCONTROLACCOUNTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? TOOLRATE
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
        public decimal TOTALCOST
        {
            get
            {
                return this.tOTALCOSTField;
            }
            set
            {
                this.tOTALCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal TOTDOWNTIME
        {
            get
            {
                return this.tOTDOWNTIMEField;
            }
            set
            {
                this.tOTDOWNTIMEField = value;
            }
        }

        /// <remarks/>
        public decimal TOTUNCHARGEDCOST
        {
            get
            {
                return this.tOTUNCHARGEDCOSTField;
            }
            set
            {
                this.tOTUNCHARGEDCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal UNCHARGEDCOST
        {
            get
            {
                return this.uNCHARGEDCOSTField;
            }
            set
            {
                this.uNCHARGEDCOSTField = value;
            }
        }

        /// <remarks/>
        public string USAGE
        {
            get
            {
                return this.uSAGEField;
            }
            set
            {
                this.uSAGEField = value;
            }
        }

        /// <remarks/>
        public string VENDOR
        {
            get
            {
                return this.vENDORField;
            }
            set
            {
                this.vENDORField = value;
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
        public decimal YTDCOST
        {
            get
            {
                return this.yTDCOSTField;
            }
            set
            {
                this.yTDCOSTField = value;
            }
        }

        /// <remarks/>
        public string EQ13
        {
            get
            {
                return this.eQ13Field;
            }
            set
            {
                this.eQ13Field = value;
            }
        }

        /// <remarks/>
        public string EQ14
        {
            get
            {
                return this.eQ14Field;
            }
            set
            {
                this.eQ14Field = value;
            }
        }

        /// <remarks/>
        public string EQ15
        {
            get
            {
                return this.eQ15Field;
            }
            set
            {
                this.eQ15Field = value;
            }
        }

        /// <remarks/>
        public string EQ16
        {
            get
            {
                return this.eQ16Field;
            }
            set
            {
                this.eQ16Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? EQ19
        {
            get
            {
                return this.eQ19Field;
            }
            set
            {
                this.eQ19Field = value;
            }
        }

        /// <remarks/>
        public byte EQ22
        {
            get
            {
                return this.eQ22Field;
            }
            set
            {
                this.eQ22Field = value;
            }
        }

        /// <remarks/>
        public string MAPNUM
        {
            get
            {
                return this.mAPNUMField;
            }
            set
            {
                this.mAPNUMField = value;
            }
        }

        /// <remarks/>
        public byte FIXEDASSET
        {
            get
            {
                return this.fIXEDASSETField;
            }
            set
            {
                this.fIXEDASSETField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? X1
        {
            get
            {
                return this.x1Field;
            }
            set
            {
                this.x1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? X2
        {
            get
            {
                return this.x2Field;
            }
            set
            {
                this.x2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? Y1
        {
            get
            {
                return this.y1Field;
            }
            set
            {
                this.y1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? Y2
        {
            get
            {
                return this.y2Field;
            }
            set
            {
                this.y2Field = value;
            }
        }

        /// <remarks/>
        public string GLOBALID
        {
            get
            {
                return this.gLOBALIDField;
            }
            set
            {
                this.gLOBALIDField = value;
            }
        }

        /// <remarks/>
        public string DIRECTION
        {
            get
            {
                return this.dIRECTIONField;
            }
            set
            {
                this.dIRECTIONField = value;
            }
        }

        /// <remarks/>
        public string ENDDESCRIPTION
        {
            get
            {
                return this.eNDDESCRIPTIONField;
            }
            set
            {
                this.eNDDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? ENDMEASURE
        {
            get
            {
                return this.eNDMEASUREField;
            }
            set
            {
                this.eNDMEASUREField = value;
            }
        }

        /// <remarks/>
        public byte ISLINEAR
        {
            get
            {
                return this.iSLINEARField;
            }
            set
            {
                this.iSLINEARField = value;
            }
        }

        /// <remarks/>
        public string STARTDESCRIPTION
        {
            get
            {
                return this.sTARTDESCRIPTIONField;
            }
            set
            {
                this.sTARTDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? STARTMEASURE
        {
            get
            {
                return this.sTARTMEASUREField;
            }
            set
            {
                this.sTARTMEASUREField = value;
            }
        }

        /// <remarks/>
        public string LRM
        {
            get
            {
                return this.lRMField;
            }
            set
            {
                this.lRMField = value;
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
        public string DEFAULTREPFACSITEID
        {
            get
            {
                return this.dEFAULTREPFACSITEIDField;
            }
            set
            {
                this.dEFAULTREPFACSITEIDField = value;
            }
        }

        /// <remarks/>
        public string DEFAULTREPFAC
        {
            get
            {
                return this.dEFAULTREPFACField;
            }
            set
            {
                this.dEFAULTREPFACField = value;
            }
        }

        /// <remarks/>
        public long RETURNEDTOVENDOR
        {
            get
            {
                return this.rETURNEDTOVENDORField;
            }
            set
            {
                this.rETURNEDTOVENDORField = value;
            }
        }

        /// <remarks/>
        public string TLOAMHASH
        {
            get
            {
                return this.tLOAMHASHField;
            }
            set
            {
                this.tLOAMHASHField = value;
            }
        }

        /// <remarks/>
        public long TLOAMPARTITION
        {
            get
            {
                return this.tLOAMPARTITIONField;
            }
            set
            {
                this.tLOAMPARTITIONField = value;
            }
        }

        /// <remarks/>
        public string PLUSCASSETDEPT
        {
            get
            {
                return this.pLUSCASSETDEPTField;
            }
            set
            {
                this.pLUSCASSETDEPTField = value;
            }
        }

        /// <remarks/>
        public string PLUSCCLASS
        {
            get
            {
                return this.pLUSCCLASSField;
            }
            set
            {
                this.pLUSCCLASSField = value;
            }
        }

        /// <remarks/>
        public DateTime? PLUSCDUEDATE
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
        public string PLUSCISCONDESC
        {
            get
            {
                return this.pLUSCISCONDESCField;
            }
            set
            {
                this.pLUSCISCONDESCField = value;
            }
        }

        /// <remarks/>
        public long PLUSCISCONTAM
        {
            get
            {
                return this.pLUSCISCONTAMField;
            }
            set
            {
                this.pLUSCISCONTAMField = value;
            }
        }

        /// <remarks/>
        public long PLUSCISINHOUSECAL
        {
            get
            {
                return this.pLUSCISINHOUSECALField;
            }
            set
            {
                this.pLUSCISINHOUSECALField = value;
            }
        }

        /// <remarks/>
        public long PLUSCISMTE
        {
            get
            {
                return this.pLUSCISMTEField;
            }
            set
            {
                this.pLUSCISMTEField = value;
            }
        }

        /// <remarks/>
        public string PLUSCISMTECLASS
        {
            get
            {
                return this.pLUSCISMTECLASSField;
            }
            set
            {
                this.pLUSCISMTECLASSField = value;
            }
        }

        /// <remarks/>
        public string PLUSCLOOPNUM
        {
            get
            {
                return this.pLUSCLOOPNUMField;
            }
            set
            {
                this.pLUSCLOOPNUMField = value;
            }
        }

        /// <remarks/>
        public string PLUSCMODELNUM
        {
            get
            {
                return this.pLUSCMODELNUMField;
            }
            set
            {
                this.pLUSCMODELNUMField = value;
            }
        }

        /// <remarks/>
        public string PLUSCOPRGEEU
        {
            get
            {
                return this.pLUSCOPRGEEUField;
            }
            set
            {
                this.pLUSCOPRGEEUField = value;
            }
        }

        /// <remarks/>
        public string PLUSCOPRGEFROM
        {
            get
            {
                return this.pLUSCOPRGEFROMField;
            }
            set
            {
                this.pLUSCOPRGEFROMField = value;
            }
        }

        /// <remarks/>
        public string PLUSCOPRGETO
        {
            get
            {
                return this.pLUSCOPRGETOField;
            }
            set
            {
                this.pLUSCOPRGETOField = value;
            }
        }

        /// <remarks/>
        public string PLUSCPHYLOC
        {
            get
            {
                return this.pLUSCPHYLOCField;
            }
            set
            {
                this.pLUSCPHYLOCField = value;
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
        public long PLUSCSOLUTION
        {
            get
            {
                return this.pLUSCSOLUTIONField;
            }
            set
            {
                this.pLUSCSOLUTIONField = value;
            }
        }

        /// <remarks/>
        public string PLUSCSUMDIR
        {
            get
            {
                return this.pLUSCSUMDIRField;
            }
            set
            {
                this.pLUSCSUMDIRField = value;
            }
        }

        /// <remarks/>
        public string PLUSCSUMEU
        {
            get
            {
                return this.pLUSCSUMEUField;
            }
            set
            {
                this.pLUSCSUMEUField = value;
            }
        }

        /// <remarks/>
        public string PLUSCSUMREAD
        {
            get
            {
                return this.pLUSCSUMREADField;
            }
            set
            {
                this.pLUSCSUMREADField = value;
            }
        }

        /// <remarks/>
        public string PLUSCSUMSPAN
        {
            get
            {
                return this.pLUSCSUMSPANField;
            }
            set
            {
                this.pLUSCSUMSPANField = value;
            }
        }

        /// <remarks/>
        public string PLUSCSUMURV
        {
            get
            {
                return this.pLUSCSUMURVField;
            }
            set
            {
                this.pLUSCSUMURVField = value;
            }
        }

        /// <remarks/>
        public string PLUSCVENDOR
        {
            get
            {
                return this.pLUSCVENDORField;
            }
            set
            {
                this.pLUSCVENDORField = value;
            }
        }

        /// <remarks/>
        public long ISCALIBRATION
        {
            get
            {
                return this.iSCALIBRATIONField;
            }
            set
            {
                this.iSCALIBRATIONField = value;
            }
        }

        /// <remarks/>
        public string TEMPLATEID
        {
            get
            {
                return this.tEMPLATEIDField;
            }
            set
            {
                this.tEMPLATEIDField = value;
            }
        }

        /// <remarks/>
        public string PLUSCLPLOC
        {
            get
            {
                return this.pLUSCLPLOCField;
            }
            set
            {
                this.pLUSCLPLOCField = value;
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
        #endregion ASSETMBO

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ASSETSPEC")]
        public ASSETSPECMboSetASSETSPEC[] ASSETSPEC
        {
            get
            {
                return this.aSSETSPECField;
            }
            set
            {
                this.aSSETSPECField = value;
            }
        }
    }
}
