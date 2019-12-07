using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCWaterMobile.MaximoService.MaxRest
{
    public class WORKORDERMbo
    {
        private string wONUMField;

        private string pARENTField;

        private WORKORDERSTATUS sTATUSField;

        private System.DateTime sTATUSDATEField;

        private string wORKTYPEField;

        private string lEADCRAFTField;

        private string dESCRIPTIONField;

        private string lOCATIONField;

        private string jPNUMField;

        private Nullable<System.DateTime> fAILDATEField;

        private string cHANGEBYField;

        private System.DateTime cHANGEDATEField;

        private decimal eSTDURField;

        private decimal eSTLABHRSField;

        private decimal eSTMATCOSTField;

        private decimal eSTLABCOSTField;

        private decimal eSTTOOLCOSTField;

        private string pMNUMField;

        private decimal aCTLABHRSField;

        private decimal aCTMATCOSTField;

        private decimal aCTLABCOSTField;

        private decimal aCTTOOLCOSTField;

        private byte hASCHILDRENField;

        private decimal oUTLABCOSTField;

        private decimal oUTMATCOSTField;

        private decimal oUTTOOLCOSTField;

        private byte hISTORYFLAGField;

        private string cONTRACTField;

        private long? wOPRIORITYField;

        private System.DateTime? tARGCOMPDATEField;

        private System.DateTime? tARGSTARTDATEField;

        private string wOEQ1Field;

        private string wOEQ2Field;

        private string wOEQ3Field;

        private string wOEQ4Field;

        private decimal? wOEQ5Field;

        private DateTime? wOEQ6Field;

        private string wOEQ7Field;

        private string wOEQ8Field;

        private string wOEQ9Field;

        private string wOEQ10Field;

        private string wOEQ11Field;

        private string wOEQ12Field;

        private string wO1Field;

        private string wO3Field;

        private string wO4Field;

        private string wO7Field;

        private string wO9Field;

        private string wO10Field;

        private string rEPORTEDBYField;

        private System.DateTime rEPORTDATEField;

        private string pHONEField;

        private string pROBLEMCODEField;

        private string cALENDARField;

        private byte dOWNTIMEField;

        private DateTime? aCTSTARTField;

        private DateTime? aCTFINISHField;

        private DateTime? sCHEDSTARTField;

        private DateTime? sCHEDFINISHField;

        private decimal? rEMDURField;

        private string cREWIDField;

        private string sUPERVISORField;

        private DateTime? wOEQ13Field;

        private decimal? wOEQ14Field;

        private string wOJP1Field;

        private string wOJP2Field;

        private string wOJP3Field;

        private decimal? wOJP4Field;

        private DateTime? wOJP5Field;

        private string wOL1Field;

        private string wOL2Field;

        private decimal? wOL3Field;

        private DateTime? wOL4Field;

        private string wOLABLNKField;

        private DateTime? rESPONDBYField;

        private long? cALCPRIORITYField;

        private byte cHARGESTOREField;

        private string fAILURECODEField;

        private string wOLO1Field;

        private string wOLO2Field;

        private string wOLO3Field;

        private string wOLO4Field;

        private string wOLO5Field;

        private decimal? wOLO6Field;

        private DateTime? wOLO7Field;

        private decimal? wOLO8Field;

        private string wOLO9Field;

        private long? wOLO10Field;

        private WORKORDERGLACCOUNT gLACCOUNTField;

        private decimal eSTSERVCOSTField;

        private decimal aCTSERVCOSTField;

        private byte dISABLEDField;

        private decimal eSTATAPPRLABHRSField;

        private decimal eSTATAPPRLABCOSTField;

        private decimal eSTATAPPRMATCOSTField;

        private decimal eSTATAPPRTOOLCOSTField;

        private decimal eSTATAPPRSERVCOSTField;

        private long? wOSEQUENCEField;

        private byte hASFOLLOWUPWORKField;

        private string wORTS1Field;

        private string wORTS2Field;

        private string wORTS3Field;

        private DateTime? wORTS4Field;

        private decimal? wORTS5Field;

        private string sOURCESYSIDField;

        private string oWNERSYSIDField;

        private DateTime? pMDUEDATEField;

        private DateTime? pMEXTDATEField;

        private DateTime? pMNEXTDUEDATEField;

        private string wORKLOCATIONField;

        private string wO11Field;

        private byte wO13Field;

        private byte wO14Field;

        private byte wO15Field;

        private byte wO16Field;

        private byte wO17Field;

        private byte wO18Field;

        private byte wO19Field;

        private byte wO20Field;

        private string eXTERNALREFIDField;

        private string sENDERSYSIDField;

        private string fINCNTRLIDField;

        private string gENERATEDFORPOField;

        private long? gENFORPOLINEIDField;

        private string oRGIDField;

        private string sITEIDField;

        private long? tASKIDField;

        private string iNSPECTORField;

        private decimal? mEASUREMENTVALUEField;

        private DateTime? mEASUREDATEField;

        private string oBSERVATIONField;

        private string pOINTNUMField;

        private string wOJO1Field;

        private string wOJO2Field;

        private string wOJO3Field;

        private decimal? wOJO4Field;

        private string wOJO5Field;

        private string wOJO6Field;

        private string wOJO7Field;

        private string wOJO8Field;

        private byte iSTASKField;

        private string sERVICEField;

        private string oRIGPROBLEMTYPEField;

        private string cISNUMField;

        private DateTime? mISSUTILITYDATEField;

        private string mISSUTILITYNUMField;

        private byte mISSUTILITYEMERGField;

        private string mAPNUMField;

        private string rECEIVEDVIAField;

        private string lOCATIONDETAILSField;

        private string oTHERCONTACTField;

        private byte wATERDISCOLOREDField;

        private string wATERCOLORField;

        private string dISCOLORHOTCOLDField;

        private byte rUN15MINUTESField;

        private byte pARTICLESINWATERField;

        private string pARTICLECOLORField;

        private byte wATERCLOUDYField;

        private byte wATERODORField;

        private string tYPEODORField;

        private byte wATERCAUSERASHField;

        private byte pERSONSEENDOCTORField;

        private string mEDICALREPORTField;

        private string cONNECTIONTYPEField;

        private string pROBLEMBEGANField;

        private string pROBLEMLOCField;

        private byte pROBLEMTHRUOUTField;

        private string lOCALIZEDWHEREField;

        private byte wATERTREATMENTField;

        private string tYPETREATMENTField;

        private decimal? mEASUREMENTVALUE2Field;

        private decimal? mEASUREMENTVALUE3Field;

        private string sAMPLELOCTYPEField;

        private byte pETROLEUMODORField;

        private string cUTNUMField;

        private long? dISTANCEField;

        private string fINALPOSITIONField;

        private decimal? nUMBEROFTURNSField;

        private byte wATERTASTEField;

        private string wATERTASTEDESCField;

        private string fUNDField;

        private string oUTLETDIAField;

        private decimal? vELOCITYPRESField;

        private byte sNAKELINEField;

        private byte jETLINEField;

        private string pROBLEMSIDEField;

        private decimal? mEASUREMENTVALUE4Field;

        private byte vALIDATEDField;

        private string cUSTOMERSTREETField;

        private string cUSTOMERCITYField;

        private string cUSTOMERSTATEField;

        private string cUSTOMERZIPField;

        private string cUSTOMEREMAILField;

        private string aLTPHONEFAXField;

        private string oTHERCOMPANYField;

        private string pLUMBERNAMEField;

        private string pLUMBERLICNUMField;

        private byte sEWERRELIEVEDField;

        private string sNAKELOCField;

        private byte sNAKETOSEWERField;

        private byte cLEANOUTField;

        private string cLEANOUTLOCField;

        private byte rUNNINGTRAPField;

        private string rUNNINGTRAPLOCField;

        private string eQUIPMENTUSEDField;

        private string jUSTIFICATIONField;

        private byte dEBRISField;

        private string dEBRISDESCField;

        private string wEATHERCONDField;

        private string wINDSField;

        private long? tEMPERATUREField;

        private byte pRECIPITATIONField;

        private string eNGINEERCOMPANYField;

        private string dEVELOPERCOMPANYField;

        private string dEVELOPERCONTACTField;

        private string dEVELOPERPHONEField;

        private string aGENCYIDField;

        private string rECEIVEDATField;

        private string cONTRACTORCONTACTField;

        private string eNUMField;

        private string pIPETYPEField;

        private DateTime? pERMITDATEField;

        private byte aSBUILTREQDField;

        private byte aSBUILTRECDField;

        private string cONTRACTORPHONEField;

        private string pROJECTTYPEField;

        private decimal aCTTOTALCOSTField;

        private bool aCTTOTALCOSTFieldSpecified;

        private string aSSETCUSTField;

        private WORKORDERASSETFILTERBY aSSETFILTERBYField;

        private string aSSETUSERField;

        private long? aSSETLOCPRIORITYField;

        private string aSSETNUMField;

        private byte aSSETWARRANTYNOTICEField;

        private bool aSSETWARRANTYNOTICEFieldSpecified;

        private string bACKOUTPLANField;

        private string bACKOUTPLAN_LONGDESCRIPTIONField;

        private string cLASSSTRUCTUREIDField;

        private string cOMMODITYField;

        private string cOMMODITYGROUPField;

        private string dESCRIPTION_LONGDESCRIPTIONField;

        private long? dISPLAYTASKIDField;

        private string dISPLAYWONUMField;

        private string dUPFLAGField;

        private string eNVIRONMENTField;

        private string eNVIRONMENT_LONGDESCRIPTIONField;

        private decimal eSTATAPPRTOTALCOSTField;

        private bool eSTATAPPRTOTALCOSTFieldSpecified;

        private decimal eSTTOTALCOSTField;

        private bool eSTTOTALCOSTFieldSpecified;

        private string fCPROJECTIDField;

        private string fCTASKIDField;

        private string fR1CODEField;

        private string fR2CODEField;

        private byte hASLDField;
        
        private byte hASPARENTField;

        private bool hASPARENTFieldSpecified;

        private byte iNTERRUPTIBLEField;
             
        private byte jPASSETSField;

        private bool jPASSETSFieldSpecified;

        private long? jPTASKField;

        private string jUSTIFYPRIORITYField;
   
        private string jUSTIFYPRIORITY_LONGDESCRIPTIONField;

        private string lANGCODEField;

        private string lEADField;
        
        private byte lOCWARRANTYNOTICEField;

        private bool lOCWARRANTYNOTICEFieldSpecified;

        private string nEWTASKPARENTPMNUMField;

        private string nP_STATUSMEMOField;

        private string oBJECTNAMEField;

        private string oNBEHALFOFField;

        private string oNBEHALFOFIDField;

        private string oNBEHALFOFNAMEField;

        private string oRIGRECORDCLASSField;

        private string oRIGRECORDIDField;

        private string oRIGTKIDField;

        private string oRIGWOIDField;

        private string oWNERField;

        private string oWNERGROUPField;

        private byte pARENTCHGSSTATUSField;

        private string pERSONGROUPField;

        private string rEASONFORCHANGEField;

        private string rEASONFORCHANGE_LONGDESCRIPTIONField;

        private string rEMARKDESCField;

        private string rEMARKDESC_LONGDESCRIPTIONField;

        private System.DateTime rEMARKENTERDATEField;

        private bool rEMARKENTERDATEFieldSpecified;

        private string rEPORTEDBYIDField;

        private string rEPORTEDBYNAMEField;

        private string rISKField;
        
        private string sAFETYPLANIDField;

        private WORKORDERSAFETYPLAN_LOOKUP_LIST_TYPE sAFETYPLAN_LOOKUP_LIST_TYPEField;

        private string sELECTSLAS_MODEField;

        private byte sLAAPPLIEDField;

        private bool sLAAPPLIEDFieldSpecified;

        private byte sPASSETSField;

        private bool sPASSETSFieldSpecified;

        private byte sPLOCATIONSField;

        private bool sPLOCATIONSFieldSpecified;

        private string vENDORField;

        private string vERIFICATIONField;
        
        private string vERIFICATION_LONGDESCRIPTIONField;

        private byte wARRANTYEXISTField;

        private bool wARRANTYEXISTFieldSpecified;

        private DateTime? wARRANTYEXPDATEField;

        private string wHOMISCHANGEFORField;

        private string wHOMISCHANGEFOR_LONGDESCRIPTIONField;

        private byte wOACCEPTSCHARGESField;

        private byte cHANGEBYPARENTField;

        private WORKORDERWOCLASS wOCLASSField;

        private string wOGROUPField;

        private long wORKORDERIDField;

        private string bKPCONTRACTField;

        private bool cHANGEBYPARENTFieldSpecified;

        private DateTime? fILTERDATEField;

        private string cINUMField;

        private string eNDFEATURELABELField;

        private string fEATUREField;

        private string fEATURELABELField;

        private string fLOWACTIONField;

        private byte fLOWACTIONASSISTField;

        private byte fLOWCONTROLLEDField;

        private long? jOBTASKIDField;

        private WORKORDERJPCLASS jPCLASSField;

        private byte jPINCLUDECLASSLESSField;

        private bool jPINCLUDECLASSLESSFieldSpecified;

        private string lAUNCHENTRYNAMEField;

        private string nEWCHILDCLASSField;
     
        private string pREDESSORWOSField;

        private string rOUTEField;

        private long? rOUTESTOPIDField;

        private string sTARTFEATURELABELField;

        private byte sTATUSIFACEField;

        private bool sTATUSIFACEFieldSpecified;

        private byte sUSPENDFLOWField;

        private string tARGETDESCField;

        private string tARGETDESC_LONGDESCRIPTIONField;

        private string wOASSETField;

        private string wOCIField;

        private string wOLOCField;

        private byte wOISSWAPField;

        private byte hASLINEARField;

        private bool hASLINEARFieldSpecified;

        private string fIRSTAPPRSTATUSField;

        private string aSSETRECONRSTKTField;

        private string pMCOMTYPEField;

        private string pMCOMSTATEField;

        private string pMCOMBPELACTNAMEField;

        private byte pMCOMBPELENABLEDField;

        private byte pMCOMBPELINPROGField;

        private string cONPERMITNUMField;

        private string oCCPERMITNUMField;

        private string cALCORGIDField;

        private string cALCCALENDARField;

        private string cALCSHIFTField;

        private string rESTORATIONREQDField;

        private long? cONTR_REL_NUMField;

        private byte dCW_LWBUDGETCHECKField;

        private byte dCW_SENDMATL2LWField;

        private string dCW_SNAKEDIST2BLCKGField;

        private string cONTRACTORJUSTIFICATIONField;

        private decimal? cOMPLEXITYField;

        private long dCW_UTILITYSTRIKEField;

        private Nullable<long> dCW_REVISEDPRIORITYField;
        
        private string rEPFACSITEIDFieldField;
        private string rEPAIRFACILITYFieldField;
        private Nullable<long> gENFORPOREVISIONField;
        private string sTOREROOMMTLSTATUSField;
        private string dIRISSUEMTLSTATUSField;
        private string wORKPACKMTLSTATUSField;
        private long iGNORESRMAVAILField;
        private long iGNOREDIAVAILField;
        private Nullable<double> eSTINTLABCOSTField;
        private Nullable<double> eSTINTLABHRSField;
        private Nullable<double> eSTOUTLABHRSField;
        private Nullable<double> eSTOUTLABCOSTField;
        private Nullable<double> aCTINTLABCOSTField;
        private Nullable<double> aCTINTLABHRSField;
        private Nullable<double> aCTOUTLABHRSField;
        private Nullable<double> aCTOUTLABCOSTField;
        private Nullable<double> eSTATAPPRINTLABCOSTField;
        private Nullable<double> eSTATAPPRINTLABHRSField;
        private Nullable<double> eSTATAPPROUTLABHRSField;
        private Nullable<double> eSTATAPPROUTLABCOSTField;
        private string aSSIGNEDOWNERGROUPField;
        private Nullable<System.DateTime> aVAILSTATUSDATEField;
        private Nullable<System.DateTime> lASTCOPYLINKDATEField;
        private long nESTEDJPINPROCESSField;
        private Nullable<long> pLUSCFREQUENCYField;
        private string pLUSCFREQUNITField;
        private long pLUSCISMOBILEField;
        private Nullable<long> pLUSCJPREVNUMField;
        private long pLUSCLOOPField;
        private Nullable<System.DateTime> pLUSCNEXTDATEField;
        private Nullable<System.DateTime> pLUSCOVERDUEDATEField;
        private string pLUSCPHYLOCField;
        private long iNCTASKSINSCHEDField;
        private Nullable<System.DateTime> sNECONSTRAINTField;
        private Nullable<System.DateTime> fNLCONSTRAINTField;
        private string aMCREWField;
        private string cREWWORKGROUPField;
        private long rEQASSTDWNTIMEField;
        private long aPPTREQUIREDField;
        private long aOSField;
        private long aMSField;
        private long lOSField;
        private long lMSField;         

        private string pLUSSFEATURECLASSField;

        private byte pLUSSISGISField;

        private byte dCW_CBASSIGNEDField;

        /// <remarks/>
        public decimal ACTTOTALCOST
        {
            get
            {
                return this.aCTTOTALCOSTField;
            }
            set
            {
                this.aCTTOTALCOSTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ACTTOTALCOSTSpecified
        {
            get
            {
                return this.aCTTOTALCOSTFieldSpecified;
            }
            set
            {
                this.aCTTOTALCOSTFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string ASSETCUST
        {
            get
            {
                return this.aSSETCUSTField;
            }
            set
            {
                this.aSSETCUSTField = value;
            }
        }

        /// <remarks/>
        public WORKORDERASSETFILTERBY ASSETFILTERBY
        {
            get
            {
                return this.aSSETFILTERBYField;
            }
            set
            {
                this.aSSETFILTERBYField = value;
            }
        }

        /// <remarks/>
        public string ASSETUSER
        {
            get
            {
                return this.aSSETUSERField;
            }
            set
            {
                this.aSSETUSERField = value;
            }
        }

        /// <remarks/>
        public byte ASSETWARRANTYNOTICE
        {
            get
            {
                return this.aSSETWARRANTYNOTICEField;
            }
            set
            {
                this.aSSETWARRANTYNOTICEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ASSETWARRANTYNOTICESpecified
        {
            get
            {
                return this.aSSETWARRANTYNOTICEFieldSpecified;
            }
            set
            {
                this.aSSETWARRANTYNOTICEFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string BACKOUTPLAN_LONGDESCRIPTION
        {
            get
            {
                return this.bACKOUTPLAN_LONGDESCRIPTIONField;
            }
            set
            {
                this.bACKOUTPLAN_LONGDESCRIPTIONField = value;
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? DISPLAYTASKID
        {
            get
            {
                return this.dISPLAYTASKIDField;
            }
            set
            {
                this.dISPLAYTASKIDField = value;
            }
        }

        /// <remarks/>
        public string DISPLAYWONUM
        {
            get
            {
                return this.dISPLAYWONUMField;
            }
            set
            {
                this.dISPLAYWONUMField = value;
            }
        }

        /// <remarks/>
        public string DUPFLAG
        {
            get
            {
                return this.dUPFLAGField;
            }
            set
            {
                this.dUPFLAGField = value;
            }
        }

        /// <remarks/>
        public string ENVIRONMENT_LONGDESCRIPTION
        {
            get
            {
                return this.eNVIRONMENT_LONGDESCRIPTIONField;
            }
            set
            {
                this.eNVIRONMENT_LONGDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public decimal ESTATAPPRTOTALCOST
        {
            get
            {
                return this.eSTATAPPRTOTALCOSTField;
            }
            set
            {
                this.eSTATAPPRTOTALCOSTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ESTATAPPRTOTALCOSTSpecified
        {
            get
            {
                return this.eSTATAPPRTOTALCOSTFieldSpecified;
            }
            set
            {
                this.eSTATAPPRTOTALCOSTFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal ESTTOTALCOST
        {
            get
            {
                return this.eSTTOTALCOSTField;
            }
            set
            {
                this.eSTTOTALCOSTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ESTTOTALCOSTSpecified
        {
            get
            {
                return this.eSTTOTALCOSTFieldSpecified;
            }
            set
            {
                this.eSTTOTALCOSTFieldSpecified = value;
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
        public string FR1CODE
        {
            get
            {
                return this.fR1CODEField;
            }
            set
            {
                this.fR1CODEField = value;
            }
        }

        /// <remarks/>
        public string FR2CODE
        {
            get
            {
                return this.fR2CODEField;
            }
            set
            {
                this.fR2CODEField = value;
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
        public byte JPASSETS
        {
            get
            {
                return this.jPASSETSField;
            }
            set
            {
                this.jPASSETSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool JPASSETSSpecified
        {
            get
            {
                return this.jPASSETSFieldSpecified;
            }
            set
            {
                this.jPASSETSFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? JPTASK
        {
            get
            {
                return this.jPTASKField;
            }
            set
            {
                this.jPTASKField = value;
            }
        }

        /// <remarks/>
        public string JUSTIFYPRIORITY_LONGDESCRIPTION
        {
            get
            {
                return this.jUSTIFYPRIORITY_LONGDESCRIPTIONField;
            }
            set
            {
                this.jUSTIFYPRIORITY_LONGDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public byte LOCWARRANTYNOTICE
        {
            get
            {
                return this.lOCWARRANTYNOTICEField;
            }
            set
            {
                this.lOCWARRANTYNOTICEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LOCWARRANTYNOTICESpecified
        {
            get
            {
                return this.lOCWARRANTYNOTICEFieldSpecified;
            }
            set
            {
                this.lOCWARRANTYNOTICEFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string NEWTASKPARENTPMNUM
        {
            get
            {
                return this.nEWTASKPARENTPMNUMField;
            }
            set
            {
                this.nEWTASKPARENTPMNUMField = value;
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
        public string ONBEHALFOFID
        {
            get
            {
                return this.oNBEHALFOFIDField;
            }
            set
            {
                this.oNBEHALFOFIDField = value;
            }
        }

        /// <remarks/>
        public string ONBEHALFOFNAME
        {
            get
            {
                return this.oNBEHALFOFNAMEField;
            }
            set
            {
                this.oNBEHALFOFNAMEField = value;
            }
        }

        /// <remarks/>
        public string ORIGTKID
        {
            get
            {
                return this.oRIGTKIDField;
            }
            set
            {
                this.oRIGTKIDField = value;
            }
        }

        /// <remarks/>
        public string ORIGWOID
        {
            get
            {
                return this.oRIGWOIDField;
            }
            set
            {
                this.oRIGWOIDField = value;
            }
        }

        /// <remarks/>
        public string REASONFORCHANGE_LONGDESCRIPTION
        {
            get
            {
                return this.rEASONFORCHANGE_LONGDESCRIPTIONField;
            }
            set
            {
                this.rEASONFORCHANGE_LONGDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public string REMARKDESC
        {
            get
            {
                return this.rEMARKDESCField;
            }
            set
            {
                this.rEMARKDESCField = value;
            }
        }

        /// <remarks/>
        public string REMARKDESC_LONGDESCRIPTION
        {
            get
            {
                return this.rEMARKDESC_LONGDESCRIPTIONField;
            }
            set
            {
                this.rEMARKDESC_LONGDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public System.DateTime REMARKENTERDATE
        {
            get
            {
                return this.rEMARKENTERDATEField;
            }
            set
            {
                this.rEMARKENTERDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool REMARKENTERDATESpecified
        {
            get
            {
                return this.rEMARKENTERDATEFieldSpecified;
            }
            set
            {
                this.rEMARKENTERDATEFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string REPORTEDBYID
        {
            get
            {
                return this.rEPORTEDBYIDField;
            }
            set
            {
                this.rEPORTEDBYIDField = value;
            }
        }

        /// <remarks/>
        public string REPORTEDBYNAME
        {
            get
            {
                return this.rEPORTEDBYNAMEField;
            }
            set
            {
                this.rEPORTEDBYNAMEField = value;
            }
        }

        /// <remarks/>
        public string SAFETYPLANID
        {
            get
            {
                return this.sAFETYPLANIDField;
            }
            set
            {
                this.sAFETYPLANIDField = value;
            }
        }

        /// <remarks/>
        public WORKORDERSAFETYPLAN_LOOKUP_LIST_TYPE SAFETYPLAN_LOOKUP_LIST_TYPE
        {
            get
            {
                return this.sAFETYPLAN_LOOKUP_LIST_TYPEField;
            }
            set
            {
                this.sAFETYPLAN_LOOKUP_LIST_TYPEField = value;
            }
        }

        /// <remarks/>
        public string SELECTSLAS_MODE
        {
            get
            {
                return this.sELECTSLAS_MODEField;
            }
            set
            {
                this.sELECTSLAS_MODEField = value;
            }
        }

        /// <remarks/>
        public byte SLAAPPLIED
        {
            get
            {
                return this.sLAAPPLIEDField;
            }
            set
            {
                this.sLAAPPLIEDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SLAAPPLIEDSpecified
        {
            get
            {
                return this.sLAAPPLIEDFieldSpecified;
            }
            set
            {
                this.sLAAPPLIEDFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte SPASSETS
        {
            get
            {
                return this.sPASSETSField;
            }
            set
            {
                this.sPASSETSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SPASSETSSpecified
        {
            get
            {
                return this.sPASSETSFieldSpecified;
            }
            set
            {
                this.sPASSETSFieldSpecified = value;
            }
        }

        /// <remarks/>
        public byte SPLOCATIONS
        {
            get
            {
                return this.sPLOCATIONSField;
            }
            set
            {
                this.sPLOCATIONSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SPLOCATIONSSpecified
        {
            get
            {
                return this.sPLOCATIONSFieldSpecified;
            }
            set
            {
                this.sPLOCATIONSFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string VERIFICATION_LONGDESCRIPTION
        {
            get
            {
                return this.vERIFICATION_LONGDESCRIPTIONField;
            }
            set
            {
                this.vERIFICATION_LONGDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public byte WARRANTYEXIST
        {
            get
            {
                return this.wARRANTYEXISTField;
            }
            set
            {
                this.wARRANTYEXISTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WARRANTYEXISTSpecified
        {
            get
            {
                return this.wARRANTYEXISTFieldSpecified;
            }
            set
            {
                this.wARRANTYEXISTFieldSpecified = value;
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
        public string WHOMISCHANGEFOR_LONGDESCRIPTION
        {
            get
            {
                return this.wHOMISCHANGEFOR_LONGDESCRIPTIONField;
            }
            set
            {
                this.wHOMISCHANGEFOR_LONGDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public byte CHANGEBYPARENT
        {
            get
            {
                return this.cHANGEBYPARENTField;
            }
            set
            {
                this.cHANGEBYPARENTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CHANGEBYPARENTSpecified
        {
            get
            {
                return this.cHANGEBYPARENTFieldSpecified;
            }
            set
            {
                this.cHANGEBYPARENTFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? FILTERDATE
        {
            get
            {
                return this.fILTERDATEField;
            }
            set
            {
                this.fILTERDATEField = value;
            }
        }

        /// <remarks/>
        public string ENDFEATURELABEL
        {
            get
            {
                return this.eNDFEATURELABELField;
            }
            set
            {
                this.eNDFEATURELABELField = value;
            }
        }

        /// <remarks/>
        public string FEATURE
        {
            get
            {
                return this.fEATUREField;
            }
            set
            {
                this.fEATUREField = value;
            }
        }

        /// <remarks/>
        public string FEATURELABEL
        {
            get
            {
                return this.fEATURELABELField;
            }
            set
            {
                this.fEATURELABELField = value;
            }
        }

        /// <remarks/>
        public WORKORDERJPCLASS JPCLASS
        {
            get
            {
                return this.jPCLASSField;
            }
            set
            {
                this.jPCLASSField = value;
            }
        }

        /// <remarks/>
        public byte JPINCLUDECLASSLESS
        {
            get
            {
                return this.jPINCLUDECLASSLESSField;
            }
            set
            {
                this.jPINCLUDECLASSLESSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool JPINCLUDECLASSLESSSpecified
        {
            get
            {
                return this.jPINCLUDECLASSLESSFieldSpecified;
            }
            set
            {
                this.jPINCLUDECLASSLESSFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string PREDESSORWOS
        {
            get
            {
                return this.pREDESSORWOSField;
            }
            set
            {
                this.pREDESSORWOSField = value;
            }
        }

        /// <remarks/>
        public string STARTFEATURELABEL
        {
            get
            {
                return this.sTARTFEATURELABELField;
            }
            set
            {
                this.sTARTFEATURELABELField = value;
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
        public string TARGETDESC_LONGDESCRIPTION
        {
            get
            {
                return this.tARGETDESC_LONGDESCRIPTIONField;
            }
            set
            {
                this.tARGETDESC_LONGDESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        public string WOASSET
        {
            get
            {
                return this.wOASSETField;
            }
            set
            {
                this.wOASSETField = value;
            }
        }

        /// <remarks/>
        public string WOCI
        {
            get
            {
                return this.wOCIField;
            }
            set
            {
                this.wOCIField = value;
            }
        }

        /// <remarks/>
        public string WOLOC
        {
            get
            {
                return this.wOLOCField;
            }
            set
            {
                this.wOLOCField = value;
            }
        }

        /// <remarks/>
        public byte HASLINEAR
        {
            get
            {
                return this.hASLINEARField;
            }
            set
            {
                this.hASLINEARField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HASLINEARSpecified
        {
            get
            {
                return this.hASLINEARFieldSpecified;
            }
            set
            {
                this.hASLINEARFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string ASSETRECONRSTKT
        {
            get
            {
                return this.aSSETRECONRSTKTField;
            }
            set
            {
                this.aSSETRECONRSTKTField = value;
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
        public WORKORDERSTATUS STATUS
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
        public string WORKTYPE
        {
            get
            {
                return this.wORKTYPEField;
            }
            set
            {
                this.wORKTYPEField = value;
            }
        }

        /// <remarks/>
        public string LEADCRAFT
        {
            get
            {
                return this.lEADCRAFTField;
            }
            set
            {
                this.lEADCRAFTField = value;
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
        public string JPNUM
        {
            get
            {
                return this.jPNUMField;
            }
            set
            {
                this.jPNUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? FAILDATE
        {
            get
            {
                return this.fAILDATEField;
            }
            set
            {
                this.fAILDATEField = value;
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
        public decimal ESTDUR
        {
            get
            {
                return this.eSTDURField;
            }
            set
            {
                this.eSTDURField = value;
            }
        }

        /// <remarks/>
        public decimal ESTLABHRS
        {
            get
            {
                return this.eSTLABHRSField;
            }
            set
            {
                this.eSTLABHRSField = value;
            }
        }

        /// <remarks/>
        public decimal ESTMATCOST
        {
            get
            {
                return this.eSTMATCOSTField;
            }
            set
            {
                this.eSTMATCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal ESTLABCOST
        {
            get
            {
                return this.eSTLABCOSTField;
            }
            set
            {
                this.eSTLABCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal ESTTOOLCOST
        {
            get
            {
                return this.eSTTOOLCOSTField;
            }
            set
            {
                this.eSTTOOLCOSTField = value;
            }
        }

        /// <remarks/>
        public string PMNUM
        {
            get
            {
                return this.pMNUMField;
            }
            set
            {
                this.pMNUMField = value;
            }
        }

        /// <remarks/>
        public decimal ACTLABHRS
        {
            get
            {
                return this.aCTLABHRSField;
            }
            set
            {
                this.aCTLABHRSField = value;
            }
        }

        /// <remarks/>
        public decimal ACTMATCOST
        {
            get
            {
                return this.aCTMATCOSTField;
            }
            set
            {
                this.aCTMATCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal ACTLABCOST
        {
            get
            {
                return this.aCTLABCOSTField;
            }
            set
            {
                this.aCTLABCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal ACTTOOLCOST
        {
            get
            {
                return this.aCTTOOLCOSTField;
            }
            set
            {
                this.aCTTOOLCOSTField = value;
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
        public decimal OUTLABCOST
        {
            get
            {
                return this.oUTLABCOSTField;
            }
            set
            {
                this.oUTLABCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal OUTMATCOST
        {
            get
            {
                return this.oUTMATCOSTField;
            }
            set
            {
                this.oUTMATCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal OUTTOOLCOST
        {
            get
            {
                return this.oUTTOOLCOSTField;
            }
            set
            {
                this.oUTTOOLCOSTField = value;
            }
        }

        /// <remarks/>
        public byte HISTORYFLAG
        {
            get
            {
                return this.hISTORYFLAGField;
            }
            set
            {
                this.hISTORYFLAGField = value;
            }
        }

        /// <remarks/>
        public string CONTRACT
        {
            get
            {
                return this.cONTRACTField;
            }
            set
            {
                this.cONTRACTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? WOPRIORITY
        {
            get
            {
                return this.wOPRIORITYField;
            }
            set
            {
                this.wOPRIORITYField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? TARGCOMPDATE
        {
            get
            {
                return this.tARGCOMPDATEField;
            }
            set
            {
                this.tARGCOMPDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? TARGSTARTDATE
        {
            get
            {
                return this.tARGSTARTDATEField;
            }
            set
            {
                this.tARGSTARTDATEField = value;
            }
        }

        /// <remarks/>
        public string WOEQ1
        {
            get
            {
                return this.wOEQ1Field;
            }
            set
            {
                this.wOEQ1Field = value;
            }
        }

        /// <remarks/>
        public string WOEQ2
        {
            get
            {
                return this.wOEQ2Field;
            }
            set
            {
                this.wOEQ2Field = value;
            }
        }

        /// <remarks/>
        public string WOEQ3
        {
            get
            {
                return this.wOEQ3Field;
            }
            set
            {
                this.wOEQ3Field = value;
            }
        }

        /// <remarks/>
        public string WOEQ4
        {
            get
            {
                return this.wOEQ4Field;
            }
            set
            {
                this.wOEQ4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? WOEQ5
        {
            get
            {
                return this.wOEQ5Field;
            }
            set
            {
                this.wOEQ5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? WOEQ6
        {
            get
            {
                return this.wOEQ6Field;
            }
            set
            {
                this.wOEQ6Field = value;
            }
        }

        /// <remarks/>
        public string WOEQ7
        {
            get
            {
                return this.wOEQ7Field;
            }
            set
            {
                this.wOEQ7Field = value;
            }
        }

        /// <remarks/>
        public string WOEQ8
        {
            get
            {
                return this.wOEQ8Field;
            }
            set
            {
                this.wOEQ8Field = value;
            }
        }

        /// <remarks/>
        public string WOEQ9
        {
            get
            {
                return this.wOEQ9Field;
            }
            set
            {
                this.wOEQ9Field = value;
            }
        }

        /// <remarks/>
        public string WOEQ10
        {
            get
            {
                return this.wOEQ10Field;
            }
            set
            {
                this.wOEQ10Field = value;
            }
        }

        /// <remarks/>
        public string WOEQ11
        {
            get
            {
                return this.wOEQ11Field;
            }
            set
            {
                this.wOEQ11Field = value;
            }
        }

        /// <remarks/>
        public string WOEQ12
        {
            get
            {
                return this.wOEQ12Field;
            }
            set
            {
                this.wOEQ12Field = value;
            }
        }

        /// <remarks/>
        public string WO1
        {
            get
            {
                return this.wO1Field;
            }
            set
            {
                this.wO1Field = value;
            }
        }

        /// <remarks/>
        public string WO3
        {
            get
            {
                return this.wO3Field;
            }
            set
            {
                this.wO3Field = value;
            }
        }

        /// <remarks/>
        public string WO4
        {
            get
            {
                return this.wO4Field;
            }
            set
            {
                this.wO4Field = value;
            }
        }

        /// <remarks/>
        public string WO7
        {
            get
            {
                return this.wO7Field;
            }
            set
            {
                this.wO7Field = value;
            }
        }

        /// <remarks/>
        public string WO9
        {
            get
            {
                return this.wO9Field;
            }
            set
            {
                this.wO9Field = value;
            }
        }

        /// <remarks/>
        public string WO10
        {
            get
            {
                return this.wO10Field;
            }
            set
            {
                this.wO10Field = value;
            }
        }

        /// <remarks/>
        public string REPORTEDBY
        {
            get
            {
                return this.rEPORTEDBYField;
            }
            set
            {
                this.rEPORTEDBYField = value;
            }
        }

        /// <remarks/>
        public System.DateTime REPORTDATE
        {
            get
            {
                return this.rEPORTDATEField;
            }
            set
            {
                this.rEPORTDATEField = value;
            }
        }

        /// <remarks/>
        public string PHONE
        {
            get
            {
                return this.pHONEField;
            }
            set
            {
                this.pHONEField = value;
            }
        }

        /// <remarks/>
        public string PROBLEMCODE
        {
            get
            {
                return this.pROBLEMCODEField;
            }
            set
            {
                this.pROBLEMCODEField = value;
            }
        }

        /// <remarks/>
        public string CALENDAR
        {
            get
            {
                return this.cALENDARField;
            }
            set
            {
                this.cALENDARField = value;
            }
        }

        /// <remarks/>
        public byte DOWNTIME
        {
            get
            {
                return this.dOWNTIMEField;
            }
            set
            {
                this.dOWNTIMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? ACTSTART
        {
            get
            {
                return this.aCTSTARTField;
            }
            set
            {
                this.aCTSTARTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? ACTFINISH
        {
            get
            {
                return this.aCTFINISHField;
            }
            set
            {
                this.aCTFINISHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? SCHEDSTART
        {
            get
            {
                return this.sCHEDSTARTField;
            }
            set
            {
                this.sCHEDSTARTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? SCHEDFINISH
        {
            get
            {
                return this.sCHEDFINISHField;
            }
            set
            {
                this.sCHEDFINISHField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? REMDUR
        {
            get
            {
                return this.rEMDURField;
            }
            set
            {
                this.rEMDURField = value;
            }
        }

        /// <remarks/>
        public string CREWID
        {
            get
            {
                return this.cREWIDField;
            }
            set
            {
                this.cREWIDField = value;
            }
        }

        /// <remarks/>
        public string SUPERVISOR
        {
            get
            {
                return this.sUPERVISORField;
            }
            set
            {
                this.sUPERVISORField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? WOEQ13
        {
            get
            {
                return this.wOEQ13Field;
            }
            set
            {
                this.wOEQ13Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? WOEQ14
        {
            get
            {
                return this.wOEQ14Field;
            }
            set
            {
                this.wOEQ14Field = value;
            }
        }

        /// <remarks/>
        public string WOJP1
        {
            get
            {
                return this.wOJP1Field;
            }
            set
            {
                this.wOJP1Field = value;
            }
        }

        /// <remarks/>
        public string WOJP2
        {
            get
            {
                return this.wOJP2Field;
            }
            set
            {
                this.wOJP2Field = value;
            }
        }

        /// <remarks/>
        public string WOJP3
        {
            get
            {
                return this.wOJP3Field;
            }
            set
            {
                this.wOJP3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? WOJP4
        {
            get
            {
                return this.wOJP4Field;
            }
            set
            {
                this.wOJP4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? WOJP5
        {
            get
            {
                return this.wOJP5Field;
            }
            set
            {
                this.wOJP5Field = value;
            }
        }

        /// <remarks/>
        public string WOL1
        {
            get
            {
                return this.wOL1Field;
            }
            set
            {
                this.wOL1Field = value;
            }
        }

        /// <remarks/>
        public string WOL2
        {
            get
            {
                return this.wOL2Field;
            }
            set
            {
                this.wOL2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? WOL3
        {
            get
            {
                return this.wOL3Field;
            }
            set
            {
                this.wOL3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public DateTime? WOL4
        {
            get
            {
                return this.wOL4Field;
            }
            set
            {
                this.wOL4Field = value;
            }
        }

        /// <remarks/>
        public string WOLABLNK
        {
            get
            {
                return this.wOLABLNKField;
            }
            set
            {
                this.wOLABLNKField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public DateTime? RESPONDBY
        {
            get
            {
                return this.rESPONDBYField;
            }
            set
            {
                this.rESPONDBYField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? CALCPRIORITY
        {
            get
            {
                return this.cALCPRIORITYField;
            }
            set
            {
                this.cALCPRIORITYField = value;
            }
        }

        /// <remarks/>
        public byte CHARGESTORE
        {
            get
            {
                return this.cHARGESTOREField;
            }
            set
            {
                this.cHARGESTOREField = value;
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
        public string WOLO1
        {
            get
            {
                return this.wOLO1Field;
            }
            set
            {
                this.wOLO1Field = value;
            }
        }

        /// <remarks/>
        public string WOLO2
        {
            get
            {
                return this.wOLO2Field;
            }
            set
            {
                this.wOLO2Field = value;
            }
        }

        /// <remarks/>
        public string WOLO3
        {
            get
            {
                return this.wOLO3Field;
            }
            set
            {
                this.wOLO3Field = value;
            }
        }

        /// <remarks/>
        public string WOLO4
        {
            get
            {
                return this.wOLO4Field;
            }
            set
            {
                this.wOLO4Field = value;
            }
        }

        /// <remarks/>
        public string WOLO5
        {
            get
            {
                return this.wOLO5Field;
            }
            set
            {
                this.wOLO5Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? WOLO6
        {
            get
            {
                return this.wOLO6Field;
            }
            set
            {
                this.wOLO6Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? WOLO7
        {
            get
            {
                return this.wOLO7Field;
            }
            set
            {
                this.wOLO7Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? WOLO8
        {
            get
            {
                return this.wOLO8Field;
            }
            set
            {
                this.wOLO8Field = value;
            }
        }

        /// <remarks/>
        public string WOLO9
        {
            get
            {
                return this.wOLO9Field;
            }
            set
            {
                this.wOLO9Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? WOLO10
        {
            get
            {
                return this.wOLO10Field;
            }
            set
            {
                this.wOLO10Field = value;
            }
        }

        /// <remarks/>
        public WORKORDERGLACCOUNT GLACCOUNT
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
        public decimal ESTSERVCOST
        {
            get
            {
                return this.eSTSERVCOSTField;
            }
            set
            {
                this.eSTSERVCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal ACTSERVCOST
        {
            get
            {
                return this.aCTSERVCOSTField;
            }
            set
            {
                this.aCTSERVCOSTField = value;
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
        public decimal ESTATAPPRLABHRS
        {
            get
            {
                return this.eSTATAPPRLABHRSField;
            }
            set
            {
                this.eSTATAPPRLABHRSField = value;
            }
        }

        /// <remarks/>
        public decimal ESTATAPPRLABCOST
        {
            get
            {
                return this.eSTATAPPRLABCOSTField;
            }
            set
            {
                this.eSTATAPPRLABCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal ESTATAPPRMATCOST
        {
            get
            {
                return this.eSTATAPPRMATCOSTField;
            }
            set
            {
                this.eSTATAPPRMATCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal ESTATAPPRTOOLCOST
        {
            get
            {
                return this.eSTATAPPRTOOLCOSTField;
            }
            set
            {
                this.eSTATAPPRTOOLCOSTField = value;
            }
        }

        /// <remarks/>
        public decimal ESTATAPPRSERVCOST
        {
            get
            {
                return this.eSTATAPPRSERVCOSTField;
            }
            set
            {
                this.eSTATAPPRSERVCOSTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? WOSEQUENCE
        {
            get
            {
                return this.wOSEQUENCEField;
            }
            set
            {
                this.wOSEQUENCEField = value;
            }
        }

        /// <remarks/>
        public byte HASFOLLOWUPWORK
        {
            get
            {
                return this.hASFOLLOWUPWORKField;
            }
            set
            {
                this.hASFOLLOWUPWORKField = value;
            }
        }

        /// <remarks/>
        public string WORTS1
        {
            get
            {
                return this.wORTS1Field;
            }
            set
            {
                this.wORTS1Field = value;
            }
        }

        /// <remarks/>
        public string WORTS2
        {
            get
            {
                return this.wORTS2Field;
            }
            set
            {
                this.wORTS2Field = value;
            }
        }

        /// <remarks/>
        public string WORTS3
        {
            get
            {
                return this.wORTS3Field;
            }
            set
            {
                this.wORTS3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? WORTS4
        {
            get
            {
                return this.wORTS4Field;
            }
            set
            {
                this.wORTS4Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? WORTS5
        {
            get
            {
                return this.wORTS5Field;
            }
            set
            {
                this.wORTS5Field = value;
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? PMDUEDATE
        {
            get
            {
                return this.pMDUEDATEField;
            }
            set
            {
                this.pMDUEDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? PMEXTDATE
        {
            get
            {
                return this.pMEXTDATEField;
            }
            set
            {
                this.pMEXTDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? PMNEXTDUEDATE
        {
            get
            {
                return this.pMNEXTDUEDATEField;
            }
            set
            {
                this.pMNEXTDUEDATEField = value;
            }
        }

        /// <remarks/>
        public string WORKLOCATION
        {
            get
            {
                return this.wORKLOCATIONField;
            }
            set
            {
                this.wORKLOCATIONField = value;
            }
        }

        /// <remarks/>
        public string WO11
        {
            get
            {
                return this.wO11Field;
            }
            set
            {
                this.wO11Field = value;
            }
        }

        /// <remarks/>
        public byte WO13
        {
            get
            {
                return this.wO13Field;
            }
            set
            {
                this.wO13Field = value;
            }
        }

        /// <remarks/>
        public byte WO14
        {
            get
            {
                return this.wO14Field;
            }
            set
            {
                this.wO14Field = value;
            }
        }

        /// <remarks/>
        public byte WO15
        {
            get
            {
                return this.wO15Field;
            }
            set
            {
                this.wO15Field = value;
            }
        }

        /// <remarks/>
        public byte WO16
        {
            get
            {
                return this.wO16Field;
            }
            set
            {
                this.wO16Field = value;
            }
        }

        /// <remarks/>
        public byte WO17
        {
            get
            {
                return this.wO17Field;
            }
            set
            {
                this.wO17Field = value;
            }
        }

        /// <remarks/>
        public byte WO18
        {
            get
            {
                return this.wO18Field;
            }
            set
            {
                this.wO18Field = value;
            }
        }

        /// <remarks/>
        public byte WO19
        {
            get
            {
                return this.wO19Field;
            }
            set
            {
                this.wO19Field = value;
            }
        }

        /// <remarks/>
        public byte WO20
        {
            get
            {
                return this.wO20Field;
            }
            set
            {
                this.wO20Field = value;
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
        public string GENERATEDFORPO
        {
            get
            {
                return this.gENERATEDFORPOField;
            }
            set
            {
                this.gENERATEDFORPOField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? GENFORPOLINEID
        {
            get
            {
                return this.gENFORPOLINEIDField;
            }
            set
            {
                this.gENFORPOLINEIDField = value;
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
        public string INSPECTOR
        {
            get
            {
                return this.iNSPECTORField;
            }
            set
            {
                this.iNSPECTORField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? MEASUREMENTVALUE
        {
            get
            {
                return this.mEASUREMENTVALUEField;
            }
            set
            {
                this.mEASUREMENTVALUEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? MEASUREDATE
        {
            get
            {
                return this.mEASUREDATEField;
            }
            set
            {
                this.mEASUREDATEField = value;
            }
        }

        /// <remarks/>
        public string OBSERVATION
        {
            get
            {
                return this.oBSERVATIONField;
            }
            set
            {
                this.oBSERVATIONField = value;
            }
        }

        /// <remarks/>
        public string POINTNUM
        {
            get
            {
                return this.pOINTNUMField;
            }
            set
            {
                this.pOINTNUMField = value;
            }
        }

        /// <remarks/>
        public string WOJO1
        {
            get
            {
                return this.wOJO1Field;
            }
            set
            {
                this.wOJO1Field = value;
            }
        }

        /// <remarks/>
        public string WOJO2
        {
            get
            {
                return this.wOJO2Field;
            }
            set
            {
                this.wOJO2Field = value;
            }
        }

        /// <remarks/>
        public string WOJO3
        {
            get
            {
                return this.wOJO3Field;
            }
            set
            {
                this.wOJO3Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? WOJO4
        {
            get
            {
                return this.wOJO4Field;
            }
            set
            {
                this.wOJO4Field = value;
            }
        }

        /// <remarks/>
        public string WOJO5
        {
            get
            {
                return this.wOJO5Field;
            }
            set
            {
                this.wOJO5Field = value;
            }
        }

        /// <remarks/>
        public string WOJO6
        {
            get
            {
                return this.wOJO6Field;
            }
            set
            {
                this.wOJO6Field = value;
            }
        }

        /// <remarks/>
        public string WOJO7
        {
            get
            {
                return this.wOJO7Field;
            }
            set
            {
                this.wOJO7Field = value;
            }
        }

        /// <remarks/>
        public string WOJO8
        {
            get
            {
                return this.wOJO8Field;
            }
            set
            {
                this.wOJO8Field = value;
            }
        }

        /// <remarks/>
        public byte ISTASK
        {
            get
            {
                return this.iSTASKField;
            }
            set
            {
                this.iSTASKField = value;
            }
        }

        /// <remarks/>
        public string SERVICE
        {
            get
            {
                return this.sERVICEField;
            }
            set
            {
                this.sERVICEField = value;
            }
        }

        /// <remarks/>
        public string ORIGPROBLEMTYPE
        {
            get
            {
                return this.oRIGPROBLEMTYPEField;
            }
            set
            {
                this.oRIGPROBLEMTYPEField = value;
            }
        }

        /// <remarks/>
        public string CISNUM
        {
            get
            {
                return this.cISNUMField;
            }
            set
            {
                this.cISNUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? MISSUTILITYDATE
        {
            get
            {
                return this.mISSUTILITYDATEField;
            }
            set
            {
                this.mISSUTILITYDATEField = value;
            }
        }

        /// <remarks/>
        public string MISSUTILITYNUM
        {
            get
            {
                return this.mISSUTILITYNUMField;
            }
            set
            {
                this.mISSUTILITYNUMField = value;
            }
        }

        /// <remarks/>
        public byte MISSUTILITYEMERG
        {
            get
            {
                return this.mISSUTILITYEMERGField;
            }
            set
            {
                this.mISSUTILITYEMERGField = value;
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
        public string RECEIVEDVIA
        {
            get
            {
                return this.rECEIVEDVIAField;
            }
            set
            {
                this.rECEIVEDVIAField = value;
            }
        }

        /// <remarks/>
        public string LOCATIONDETAILS
        {
            get
            {
                return this.lOCATIONDETAILSField;
            }
            set
            {
                this.lOCATIONDETAILSField = value;
            }
        }

        /// <remarks/>
        public string OTHERCONTACT
        {
            get
            {
                return this.oTHERCONTACTField;
            }
            set
            {
                this.oTHERCONTACTField = value;
            }
        }

        /// <remarks/>
        public byte WATERDISCOLORED
        {
            get
            {
                return this.wATERDISCOLOREDField;
            }
            set
            {
                this.wATERDISCOLOREDField = value;
            }
        }

        /// <remarks/>
        public string WATERCOLOR
        {
            get
            {
                return this.wATERCOLORField;
            }
            set
            {
                this.wATERCOLORField = value;
            }
        }

        /// <remarks/>
        public string DISCOLORHOTCOLD
        {
            get
            {
                return this.dISCOLORHOTCOLDField;
            }
            set
            {
                this.dISCOLORHOTCOLDField = value;
            }
        }

        /// <remarks/>
        public byte RUN15MINUTES
        {
            get
            {
                return this.rUN15MINUTESField;
            }
            set
            {
                this.rUN15MINUTESField = value;
            }
        }

        /// <remarks/>
        public byte PARTICLESINWATER
        {
            get
            {
                return this.pARTICLESINWATERField;
            }
            set
            {
                this.pARTICLESINWATERField = value;
            }
        }

        /// <remarks/>
        public string PARTICLECOLOR
        {
            get
            {
                return this.pARTICLECOLORField;
            }
            set
            {
                this.pARTICLECOLORField = value;
            }
        }

        /// <remarks/>
        public byte WATERCLOUDY
        {
            get
            {
                return this.wATERCLOUDYField;
            }
            set
            {
                this.wATERCLOUDYField = value;
            }
        }

        /// <remarks/>
        public byte WATERODOR
        {
            get
            {
                return this.wATERODORField;
            }
            set
            {
                this.wATERODORField = value;
            }
        }

        /// <remarks/>
        public string TYPEODOR
        {
            get
            {
                return this.tYPEODORField;
            }
            set
            {
                this.tYPEODORField = value;
            }
        }

        /// <remarks/>
        public byte WATERCAUSERASH
        {
            get
            {
                return this.wATERCAUSERASHField;
            }
            set
            {
                this.wATERCAUSERASHField = value;
            }
        }

        /// <remarks/>
        public byte PERSONSEENDOCTOR
        {
            get
            {
                return this.pERSONSEENDOCTORField;
            }
            set
            {
                this.pERSONSEENDOCTORField = value;
            }
        }

        /// <remarks/>
        public string MEDICALREPORT
        {
            get
            {
                return this.mEDICALREPORTField;
            }
            set
            {
                this.mEDICALREPORTField = value;
            }
        }

        /// <remarks/>
        public string CONNECTIONTYPE
        {
            get
            {
                return this.cONNECTIONTYPEField;
            }
            set
            {
                this.cONNECTIONTYPEField = value;
            }
        }

        /// <remarks/>
        public string PROBLEMBEGAN
        {
            get
            {
                return this.pROBLEMBEGANField;
            }
            set
            {
                this.pROBLEMBEGANField = value;
            }
        }

        /// <remarks/>
        public string PROBLEMLOC
        {
            get
            {
                return this.pROBLEMLOCField;
            }
            set
            {
                this.pROBLEMLOCField = value;
            }
        }

        /// <remarks/>
        public byte PROBLEMTHRUOUT
        {
            get
            {
                return this.pROBLEMTHRUOUTField;
            }
            set
            {
                this.pROBLEMTHRUOUTField = value;
            }
        }

        /// <remarks/>
        public string LOCALIZEDWHERE
        {
            get
            {
                return this.lOCALIZEDWHEREField;
            }
            set
            {
                this.lOCALIZEDWHEREField = value;
            }
        }

        /// <remarks/>
        public byte WATERTREATMENT
        {
            get
            {
                return this.wATERTREATMENTField;
            }
            set
            {
                this.wATERTREATMENTField = value;
            }
        }

        /// <remarks/>
        public string TYPETREATMENT
        {
            get
            {
                return this.tYPETREATMENTField;
            }
            set
            {
                this.tYPETREATMENTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? MEASUREMENTVALUE2
        {
            get
            {
                return this.mEASUREMENTVALUE2Field;
            }
            set
            {
                this.mEASUREMENTVALUE2Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? MEASUREMENTVALUE3
        {
            get
            {
                return this.mEASUREMENTVALUE3Field;
            }
            set
            {
                this.mEASUREMENTVALUE3Field = value;
            }
        }

        /// <remarks/>
        public string SAMPLELOCTYPE
        {
            get
            {
                return this.sAMPLELOCTYPEField;
            }
            set
            {
                this.sAMPLELOCTYPEField = value;
            }
        }

        /// <remarks/>
        public byte PETROLEUMODOR
        {
            get
            {
                return this.pETROLEUMODORField;
            }
            set
            {
                this.pETROLEUMODORField = value;
            }
        }

        /// <remarks/>
        public string CUTNUM
        {
            get
            {
                return this.cUTNUMField;
            }
            set
            {
                this.cUTNUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? DISTANCE
        {
            get
            {
                return this.dISTANCEField;
            }
            set
            {
                this.dISTANCEField = value;
            }
        }

        /// <remarks/>
        public string FINALPOSITION
        {
            get
            {
                return this.fINALPOSITIONField;
            }
            set
            {
                this.fINALPOSITIONField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? NUMBEROFTURNS
        {
            get
            {
                return this.nUMBEROFTURNSField;
            }
            set
            {
                this.nUMBEROFTURNSField = value;
            }
        }

        /// <remarks/>
        public byte WATERTASTE
        {
            get
            {
                return this.wATERTASTEField;
            }
            set
            {
                this.wATERTASTEField = value;
            }
        }

        /// <remarks/>
        public string WATERTASTEDESC
        {
            get
            {
                return this.wATERTASTEDESCField;
            }
            set
            {
                this.wATERTASTEDESCField = value;
            }
        }

        /// <remarks/>
        public string FUND
        {
            get
            {
                return this.fUNDField;
            }
            set
            {
                this.fUNDField = value;
            }
        }

        /// <remarks/>
        public string OUTLETDIA
        {
            get
            {
                return this.oUTLETDIAField;
            }
            set
            {
                this.oUTLETDIAField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? VELOCITYPRES
        {
            get
            {
                return this.vELOCITYPRESField;
            }
            set
            {
                this.vELOCITYPRESField = value;
            }
        }

        /// <remarks/>
        public byte SNAKELINE
        {
            get
            {
                return this.sNAKELINEField;
            }
            set
            {
                this.sNAKELINEField = value;
            }
        }

        /// <remarks/>
        public byte JETLINE
        {
            get
            {
                return this.jETLINEField;
            }
            set
            {
                this.jETLINEField = value;
            }
        }

        /// <remarks/>
        public string PROBLEMSIDE
        {
            get
            {
                return this.pROBLEMSIDEField;
            }
            set
            {
                this.pROBLEMSIDEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? MEASUREMENTVALUE4
        {
            get
            {
                return this.mEASUREMENTVALUE4Field;
            }
            set
            {
                this.mEASUREMENTVALUE4Field = value;
            }
        }

        /// <remarks/>
        public byte VALIDATED
        {
            get
            {
                return this.vALIDATEDField;
            }
            set
            {
                this.vALIDATEDField = value;
            }
        }

        /// <remarks/>
        public string CUSTOMERSTREET
        {
            get
            {
                return this.cUSTOMERSTREETField;
            }
            set
            {
                this.cUSTOMERSTREETField = value;
            }
        }

        /// <remarks/>
        public string CUSTOMERCITY
        {
            get
            {
                return this.cUSTOMERCITYField;
            }
            set
            {
                this.cUSTOMERCITYField = value;
            }
        }

        /// <remarks/>
        public string CUSTOMERSTATE
        {
            get
            {
                return this.cUSTOMERSTATEField;
            }
            set
            {
                this.cUSTOMERSTATEField = value;
            }
        }

        /// <remarks/>
        public string CUSTOMERZIP
        {
            get
            {
                return this.cUSTOMERZIPField;
            }
            set
            {
                this.cUSTOMERZIPField = value;
            }
        }

        /// <remarks/>
        public string CUSTOMEREMAIL
        {
            get
            {
                return this.cUSTOMEREMAILField;
            }
            set
            {
                this.cUSTOMEREMAILField = value;
            }
        }

        /// <remarks/>
        public string ALTPHONEFAX
        {
            get
            {
                return this.aLTPHONEFAXField;
            }
            set
            {
                this.aLTPHONEFAXField = value;
            }
        }

        /// <remarks/>
        public string OTHERCOMPANY
        {
            get
            {
                return this.oTHERCOMPANYField;
            }
            set
            {
                this.oTHERCOMPANYField = value;
            }
        }

        /// <remarks/>
        public string PLUMBERNAME
        {
            get
            {
                return this.pLUMBERNAMEField;
            }
            set
            {
                this.pLUMBERNAMEField = value;
            }
        }

        /// <remarks/>
        public string PLUMBERLICNUM
        {
            get
            {
                return this.pLUMBERLICNUMField;
            }
            set
            {
                this.pLUMBERLICNUMField = value;
            }
        }

        /// <remarks/>
        public byte SEWERRELIEVED
        {
            get
            {
                return this.sEWERRELIEVEDField;
            }
            set
            {
                this.sEWERRELIEVEDField = value;
            }
        }

        /// <remarks/>
        public string SNAKELOC
        {
            get
            {
                return this.sNAKELOCField;
            }
            set
            {
                this.sNAKELOCField = value;
            }
        }

        /// <remarks/>
        public byte SNAKETOSEWER
        {
            get
            {
                return this.sNAKETOSEWERField;
            }
            set
            {
                this.sNAKETOSEWERField = value;
            }
        }

        /// <remarks/>
        public byte CLEANOUT
        {
            get
            {
                return this.cLEANOUTField;
            }
            set
            {
                this.cLEANOUTField = value;
            }
        }

        /// <remarks/>
        public string CLEANOUTLOC
        {
            get
            {
                return this.cLEANOUTLOCField;
            }
            set
            {
                this.cLEANOUTLOCField = value;
            }
        }

        /// <remarks/>
        public byte RUNNINGTRAP
        {
            get
            {
                return this.rUNNINGTRAPField;
            }
            set
            {
                this.rUNNINGTRAPField = value;
            }
        }

        /// <remarks/>
        public string RUNNINGTRAPLOC
        {
            get
            {
                return this.rUNNINGTRAPLOCField;
            }
            set
            {
                this.rUNNINGTRAPLOCField = value;
            }
        }

        /// <remarks/>
        public string EQUIPMENTUSED
        {
            get
            {
                return this.eQUIPMENTUSEDField;
            }
            set
            {
                this.eQUIPMENTUSEDField = value;
            }
        }

        /// <remarks/>
        public string JUSTIFICATION
        {
            get
            {
                return this.jUSTIFICATIONField;
            }
            set
            {
                this.jUSTIFICATIONField = value;
            }
        }

        /// <remarks/>
        public byte DEBRIS
        {
            get
            {
                return this.dEBRISField;
            }
            set
            {
                this.dEBRISField = value;
            }
        }

        /// <remarks/>
        public string DEBRISDESC
        {
            get
            {
                return this.dEBRISDESCField;
            }
            set
            {
                this.dEBRISDESCField = value;
            }
        }

        /// <remarks/>
        public string WEATHERCOND
        {
            get
            {
                return this.wEATHERCONDField;
            }
            set
            {
                this.wEATHERCONDField = value;
            }
        }

        /// <remarks/>
        public string WINDS
        {
            get
            {
                return this.wINDSField;
            }
            set
            {
                this.wINDSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? TEMPERATURE
        {
            get
            {
                return this.tEMPERATUREField;
            }
            set
            {
                this.tEMPERATUREField = value;
            }
        }

        /// <remarks/>
        public byte PRECIPITATION
        {
            get
            {
                return this.pRECIPITATIONField;
            }
            set
            {
                this.pRECIPITATIONField = value;
            }
        }

        /// <remarks/>
        public string ENGINEERCOMPANY
        {
            get
            {
                return this.eNGINEERCOMPANYField;
            }
            set
            {
                this.eNGINEERCOMPANYField = value;
            }
        }

        /// <remarks/>
        public string DEVELOPERCOMPANY
        {
            get
            {
                return this.dEVELOPERCOMPANYField;
            }
            set
            {
                this.dEVELOPERCOMPANYField = value;
            }
        }

        /// <remarks/>
        public string DEVELOPERCONTACT
        {
            get
            {
                return this.dEVELOPERCONTACTField;
            }
            set
            {
                this.dEVELOPERCONTACTField = value;
            }
        }

        /// <remarks/>
        public string DEVELOPERPHONE
        {
            get
            {
                return this.dEVELOPERPHONEField;
            }
            set
            {
                this.dEVELOPERPHONEField = value;
            }
        }

        /// <remarks/>
        public string AGENCYID
        {
            get
            {
                return this.aGENCYIDField;
            }
            set
            {
                this.aGENCYIDField = value;
            }
        }

        /// <remarks/>
        public string RECEIVEDAT
        {
            get
            {
                return this.rECEIVEDATField;
            }
            set
            {
                this.rECEIVEDATField = value;
            }
        }

        /// <remarks/>
        public string CONTRACTORCONTACT
        {
            get
            {
                return this.cONTRACTORCONTACTField;
            }
            set
            {
                this.cONTRACTORCONTACTField = value;
            }
        }

        /// <remarks/>
        public string ENUM
        {
            get
            {
                return this.eNUMField;
            }
            set
            {
                this.eNUMField = value;
            }
        }

        /// <remarks/>
        public string PIPETYPE
        {
            get
            {
                return this.pIPETYPEField;
            }
            set
            {
                this.pIPETYPEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? PERMITDATE
        {
            get
            {
                return this.pERMITDATEField;
            }
            set
            {
                this.pERMITDATEField = value;
            }
        }

        /// <remarks/>
        public byte ASBUILTREQD
        {
            get
            {
                return this.aSBUILTREQDField;
            }
            set
            {
                this.aSBUILTREQDField = value;
            }
        }

        /// <remarks/>
        public byte ASBUILTRECD
        {
            get
            {
                return this.aSBUILTRECDField;
            }
            set
            {
                this.aSBUILTRECDField = value;
            }
        }

        /// <remarks/>
        public string CONTRACTORPHONE
        {
            get
            {
                return this.cONTRACTORPHONEField;
            }
            set
            {
                this.cONTRACTORPHONEField = value;
            }
        }

        /// <remarks/>
        public string PROJECTTYPE
        {
            get
            {
                return this.pROJECTTYPEField;
            }
            set
            {
                this.pROJECTTYPEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? ASSETLOCPRIORITY
        {
            get
            {
                return this.aSSETLOCPRIORITYField;
            }
            set
            {
                this.aSSETLOCPRIORITYField = value;
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
        public string BACKOUTPLAN
        {
            get
            {
                return this.bACKOUTPLANField;
            }
            set
            {
                this.bACKOUTPLANField = value;
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
        public string COMMODITY
        {
            get
            {
                return this.cOMMODITYField;
            }
            set
            {
                this.cOMMODITYField = value;
            }
        }

        /// <remarks/>
        public string COMMODITYGROUP
        {
            get
            {
                return this.cOMMODITYGROUPField;
            }
            set
            {
                this.cOMMODITYGROUPField = value;
            }
        }

        /// <remarks/>
        public string ENVIRONMENT
        {
            get
            {
                return this.eNVIRONMENTField;
            }
            set
            {
                this.eNVIRONMENTField = value;
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
        public byte INTERRUPTIBLE
        {
            get
            {
                return this.iNTERRUPTIBLEField;
            }
            set
            {
                this.iNTERRUPTIBLEField = value;
            }
        }

        /// <remarks/>
        public string JUSTIFYPRIORITY
        {
            get
            {
                return this.jUSTIFYPRIORITYField;
            }
            set
            {
                this.jUSTIFYPRIORITYField = value;
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
        public string LEAD
        {
            get
            {
                return this.lEADField;
            }
            set
            {
                this.lEADField = value;
            }
        }

        /// <remarks/>
        public string ONBEHALFOF
        {
            get
            {
                return this.oNBEHALFOFField;
            }
            set
            {
                this.oNBEHALFOFField = value;
            }
        }

        /// <remarks/>
        public string ORIGRECORDCLASS
        {
            get
            {
                return this.oRIGRECORDCLASSField;
            }
            set
            {
                this.oRIGRECORDCLASSField = value;
            }
        }

        /// <remarks/>
        public string ORIGRECORDID
        {
            get
            {
                return this.oRIGRECORDIDField;
            }
            set
            {
                this.oRIGRECORDIDField = value;
            }
        }

        /// <remarks/>
        public string OWNER
        {
            get
            {
                return this.oWNERField;
            }
            set
            {
                this.oWNERField = value;
            }
        }

        /// <remarks/>
        public string OWNERGROUP
        {
            get
            {
                return this.oWNERGROUPField;
            }
            set
            {
                this.oWNERGROUPField = value;
            }
        }

        /// <remarks/>
        public byte PARENTCHGSSTATUS
        {
            get
            {
                return this.pARENTCHGSSTATUSField;
            }
            set
            {
                this.pARENTCHGSSTATUSField = value;
            }
        }

        /// <remarks/>
        public string PERSONGROUP
        {
            get
            {
                return this.pERSONGROUPField;
            }
            set
            {
                this.pERSONGROUPField = value;
            }
        }

        /// <remarks/>
        public string REASONFORCHANGE
        {
            get
            {
                return this.rEASONFORCHANGEField;
            }
            set
            {
                this.rEASONFORCHANGEField = value;
            }
        }

        /// <remarks/>
        public string RISK
        {
            get
            {
                return this.rISKField;
            }
            set
            {
                this.rISKField = value;
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
        public string VERIFICATION
        {
            get
            {
                return this.vERIFICATIONField;
            }
            set
            {
                this.vERIFICATIONField = value;
            }
        }

        /// <remarks/>
        public string WHOMISCHANGEFOR
        {
            get
            {
                return this.wHOMISCHANGEFORField;
            }
            set
            {
                this.wHOMISCHANGEFORField = value;
            }
        }

        /// <remarks/>
        public byte WOACCEPTSCHARGES
        {
            get
            {
                return this.wOACCEPTSCHARGESField;
            }
            set
            {
                this.wOACCEPTSCHARGESField = value;
            }
        }

        /// <remarks/>
        public WORKORDERWOCLASS WOCLASS
        {
            get
            {
                return this.wOCLASSField;
            }
            set
            {
                this.wOCLASSField = value;
            }
        }

        /// <remarks/>
        public string WOGROUP
        {
            get
            {
                return this.wOGROUPField;
            }
            set
            {
                this.wOGROUPField = value;
            }
        }

        /// <remarks/>
        public long WORKORDERID
        {
            get
            {
                return this.wORKORDERIDField;
            }
            set
            {
                this.wORKORDERIDField = value;
            }
        }

        /// <remarks/>
        public string BKPCONTRACT
        {
            get
            {
                return this.bKPCONTRACTField;
            }
            set
            {
                this.bKPCONTRACTField = value;
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
        public string FLOWACTION
        {
            get
            {
                return this.fLOWACTIONField;
            }
            set
            {
                this.fLOWACTIONField = value;
            }
        }

        /// <remarks/>
        public byte FLOWACTIONASSIST
        {
            get
            {
                return this.fLOWACTIONASSISTField;
            }
            set
            {
                this.fLOWACTIONASSISTField = value;
            }
        }

        /// <remarks/>
        public byte FLOWCONTROLLED
        {
            get
            {
                return this.fLOWCONTROLLEDField;
            }
            set
            {
                this.fLOWCONTROLLEDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? JOBTASKID
        {
            get
            {
                return this.jOBTASKIDField;
            }
            set
            {
                this.jOBTASKIDField = value;
            }
        }

        /// <remarks/>
        public string LAUNCHENTRYNAME
        {
            get
            {
                return this.lAUNCHENTRYNAMEField;
            }
            set
            {
                this.lAUNCHENTRYNAMEField = value;
            }
        }

        /// <remarks/>
        public string NEWCHILDCLASS
        {
            get
            {
                return this.nEWCHILDCLASSField;
            }
            set
            {
                this.nEWCHILDCLASSField = value;
            }
        }

        /// <remarks/>
        public string ROUTE
        {
            get
            {
                return this.rOUTEField;
            }
            set
            {
                this.rOUTEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? ROUTESTOPID
        {
            get
            {
                return this.rOUTESTOPIDField;
            }
            set
            {
                this.rOUTESTOPIDField = value;
            }
        }

        /// <remarks/>
        public byte SUSPENDFLOW
        {
            get
            {
                return this.sUSPENDFLOWField;
            }
            set
            {
                this.sUSPENDFLOWField = value;
            }
        }

        /// <remarks/>
        public string TARGETDESC
        {
            get
            {
                return this.tARGETDESCField;
            }
            set
            {
                this.tARGETDESCField = value;
            }
        }

        /// <remarks/>
        public byte WOISSWAP
        {
            get
            {
                return this.wOISSWAPField;
            }
            set
            {
                this.wOISSWAPField = value;
            }
        }

        /// <remarks/>
        public string FIRSTAPPRSTATUS
        {
            get
            {
                return this.fIRSTAPPRSTATUSField;
            }
            set
            {
                this.fIRSTAPPRSTATUSField = value;
            }
        }

        /// <remarks/>
        public string PMCOMTYPE
        {
            get
            {
                return this.pMCOMTYPEField;
            }
            set
            {
                this.pMCOMTYPEField = value;
            }
        }

        /// <remarks/>
        public string PMCOMSTATE
        {
            get
            {
                return this.pMCOMSTATEField;
            }
            set
            {
                this.pMCOMSTATEField = value;
            }
        }

        /// <remarks/>
        public string PMCOMBPELACTNAME
        {
            get
            {
                return this.pMCOMBPELACTNAMEField;
            }
            set
            {
                this.pMCOMBPELACTNAMEField = value;
            }
        }

        /// <remarks/>
        public byte PMCOMBPELENABLED
        {
            get
            {
                return this.pMCOMBPELENABLEDField;
            }
            set
            {
                this.pMCOMBPELENABLEDField = value;
            }
        }

        /// <remarks/>
        public byte PMCOMBPELINPROG
        {
            get
            {
                return this.pMCOMBPELINPROGField;
            }
            set
            {
                this.pMCOMBPELINPROGField = value;
            }
        }

        /// <remarks/>
        public string CONPERMITNUM
        {
            get
            {
                return this.cONPERMITNUMField;
            }
            set
            {
                this.cONPERMITNUMField = value;
            }
        }

        /// <remarks/>
        public string OCCPERMITNUM
        {
            get
            {
                return this.oCCPERMITNUMField;
            }
            set
            {
                this.oCCPERMITNUMField = value;
            }
        }

        /// <remarks/>
        public string CALCORGID
        {
            get
            {
                return this.cALCORGIDField;
            }
            set
            {
                this.cALCORGIDField = value;
            }
        }

        /// <remarks/>
        public string CALCCALENDAR
        {
            get
            {
                return this.cALCCALENDARField;
            }
            set
            {
                this.cALCCALENDARField = value;
            }
        }

        /// <remarks/>
        public string CALCSHIFT
        {
            get
            {
                return this.cALCSHIFTField;
            }
            set
            {
                this.cALCSHIFTField = value;
            }
        }

        /// <remarks/>
        public string RESTORATIONREQD
        {
            get
            {
                return this.rESTORATIONREQDField;
            }
            set
            {
                this.rESTORATIONREQDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? CONTR_REL_NUM
        {
            get
            {
                return this.cONTR_REL_NUMField;
            }
            set
            {
                this.cONTR_REL_NUMField = value;
            }
        }

        /// <remarks/>
        public byte DCW_LWBUDGETCHECK
        {
            get
            {
                return this.dCW_LWBUDGETCHECKField;
            }
            set
            {
                this.dCW_LWBUDGETCHECKField = value;
            }
        }

        /// <remarks/>
        public byte DCW_SENDMATL2LW
        {
            get
            {
                return this.dCW_SENDMATL2LWField;
            }
            set
            {
                this.dCW_SENDMATL2LWField = value;
            }
        }

        /// <remarks/>
        public string DCW_SNAKEDIST2BLCKG
        {
            get
            {
                return this.dCW_SNAKEDIST2BLCKGField;
            }
            set
            {
                this.dCW_SNAKEDIST2BLCKGField = value;
            }
        }

        /// <remarks/>
        public string CONTRACTORJUSTIFICATION
        {
            get
            {
                return this.cONTRACTORJUSTIFICATIONField;
            }
            set
            {
                this.cONTRACTORJUSTIFICATIONField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? COMPLEXITY
        {
            get
            {
                return this.cOMPLEXITYField;
            }
            set
            {
                this.cOMPLEXITYField = value;
            }
        }

        /// <remarks/>
        public long DCW_UTILITYSTRIKE
        {
            get
            {
                return this.dCW_UTILITYSTRIKEField;
            }
            set
            {
                this.dCW_UTILITYSTRIKEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? DCW_REVISEDPRIORITY
        {
            get
            {
                return this.dCW_REVISEDPRIORITYField;
            }
            set
            {
                this.dCW_REVISEDPRIORITYField = value;
            }
        }

        public string REPFACSITEID 
        {
            get
            {
                return this.rEPFACSITEIDFieldField;
            }
            set 
            {
                this.rEPFACSITEIDFieldField = value;
            }
        }
        public string REPAIRFACILITY 
        {
            get
            {
                return this.rEPAIRFACILITYFieldField;
            }
            set 
            {
                this.rEPAIRFACILITYFieldField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<long> GENFORPOREVISION
        {
            get
            {
                return this.gENFORPOREVISIONField;
            }
            set 
            {
                this.gENFORPOREVISIONField = value;
            }
        }
        public string STOREROOMMTLSTATUS
        {
            get
            {
                return this.sTOREROOMMTLSTATUSField;
            }
            set 
            {
                this.sTOREROOMMTLSTATUSField = value;
            }
        }
        public string DIRISSUEMTLSTATUS
        {
            get
            {
                return this.dIRISSUEMTLSTATUSField;
            }
            set 
            {
                this.dIRISSUEMTLSTATUSField = value;
            }
        }
        public string WORKPACKMTLSTATUS
        {
            get
            {
                return this.wORKPACKMTLSTATUSField;
            }
            set 
            {
                this.wORKPACKMTLSTATUSField = value;
            }
        }
        public long IGNORESRMAVAIL
        {
            get
            {
                return this.iGNORESRMAVAILField;
            }
            set 
            {
                this.iGNORESRMAVAILField = value;
            }
        }
        public long IGNOREDIAVAIL
        {
            get
            {
                return this.iGNOREDIAVAILField;
            }
            set 
            {
                this.iGNOREDIAVAILField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ESTINTLABCOST
        {
            get
            {
                return this.eSTINTLABCOSTField;
            }
            set 
            {
                this.eSTINTLABCOSTField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ESTINTLABHRS
        {
            get
            {
                return this.eSTINTLABHRSField;
            }
            set 
            {
                this.eSTINTLABHRSField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ESTOUTLABHRS
        {
            get
            {
                return this.eSTOUTLABHRSField;
            }
            set 
            {
                this.eSTOUTLABHRSField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ESTOUTLABCOST
        {
            get
            {
                return this.eSTOUTLABCOSTField;
            }
            set 
            {
                this.eSTOUTLABCOSTField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ACTINTLABCOST
        {
            get
            {
                return this.aCTINTLABCOSTField;
            }
            set 
            {
                this.aCTINTLABCOSTField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ACTINTLABHRS
        {
            get
            {
                return this.aCTINTLABHRSField;
            }
            set 
            {
                this.aCTINTLABHRSField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ACTOUTLABHRS
        {
            get
            {
                return this.aCTOUTLABHRSField;
            }
            set 
            {
                this.aCTOUTLABHRSField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ACTOUTLABCOST 
        {
            get
            {
                return this.aCTOUTLABCOSTField;
            }
            set 
            {
                this.aCTOUTLABCOSTField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ESTATAPPRINTLABCOST
        {
            get
            {
                return this.eSTATAPPRINTLABCOSTField;
            }
            set 
            {
                this.eSTATAPPRINTLABCOSTField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ESTATAPPRINTLABHRS
        {
            get
            {
                return this.eSTATAPPRINTLABHRSField;
            }
            set 
            {
                this.eSTATAPPRINTLABHRSField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ESTATAPPROUTLABHRS
        {
            get
            {
                return this.eSTATAPPROUTLABHRSField;
            }
            set 
            {
                this.eSTATAPPROUTLABHRSField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<double> ESTATAPPROUTLABCOST
        {
            get
            {
                return this.eSTATAPPROUTLABCOSTField;
            }
            set 
            {
                this.eSTATAPPROUTLABCOSTField = value;
            }
        }
        public string ASSIGNEDOWNERGROUP
        {
            get
            {
                return this.aSSIGNEDOWNERGROUPField;
            }
            set 
            {
                this.aSSIGNEDOWNERGROUPField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<System.DateTime> AVAILSTATUSDATE
        {
            get
            {
                return this.aVAILSTATUSDATEField;
            }
            set 
            {
                this.aVAILSTATUSDATEField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<System.DateTime> LASTCOPYLINKDATE
        {
            get
            {
                return this.lASTCOPYLINKDATEField;
            }
            set 
            {
                this.lASTCOPYLINKDATEField = value;
            }
        }
        public long NESTEDJPINPROCESS
        {
            get
            {
                return this.nESTEDJPINPROCESSField;
            }
            set 
            {
                this.nESTEDJPINPROCESSField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<long> PLUSCFREQUENCY
        {
            get
            {
                return this.pLUSCFREQUENCYField;
            }
            set 
            {
                this.pLUSCFREQUENCYField = value;
            }
        }
        public string PLUSCFREQUNIT
        {
            get
            {
                return this.pLUSCFREQUNITField;
            }
            set 
            {
                this.pLUSCFREQUNITField = value;
            }
        }
        public long PLUSCISMOBILE
        {
            get
            {
                return this.pLUSCISMOBILEField;
            }
            set 
            {
                this.pLUSCISMOBILEField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<long> PLUSCJPREVNUM
        {
            get
            {
                return this.pLUSCJPREVNUMField;
            }
            set 
            {
                this.pLUSCJPREVNUMField = value;
            }
        }
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

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<System.DateTime> PLUSCNEXTDATE
        {
            get
            {
                return this.pLUSCNEXTDATEField;
            }
            set 
            {
                this.pLUSCNEXTDATEField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<System.DateTime> PLUSCOVERDUEDATE
        {
            get
            {
                return this.pLUSCOVERDUEDATEField;
            }
            set 
            {
                this.pLUSCOVERDUEDATEField = value;
            }
        }
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
        public long INCTASKSINSCHED
        {
            get
            {
                return this.iNCTASKSINSCHEDField;
            }
            set 
            {
                this.iNCTASKSINSCHEDField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<System.DateTime> SNECONSTRAINT
        {
            get
            {
                return this.sNECONSTRAINTField;
            }
            set 
            {
                this.sNECONSTRAINTField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<System.DateTime> FNLCONSTRAINT
        {
            get
            {
                return this.fNLCONSTRAINTField;
            }
            set 
            {
                this.fNLCONSTRAINTField = value;
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
        public string CREWWORKGROUP
        {
            get
            {
                return this.cREWWORKGROUPField;
            }
            set 
            {
                this.cREWWORKGROUPField = value;
            }
        }
        public long REQASSTDWNTIME
        {
            get
            {
                return this.rEQASSTDWNTIMEField;
            }
            set 
            {
                this.rEQASSTDWNTIMEField = value;
            }
        }
        public long APPTREQUIRED
        {
            get
            {
                return this.aPPTREQUIREDField;
            }
            set 
            {
                this.aPPTREQUIREDField = value;
            }
        }
        public long AOS
        {
            get
            {
                return this.aOSField;
            }
            set 
            {
                this.aOSField = value;
            }
        }
        public long AMS
        {
            get
            {
                return this.aMSField;
            }
            set 
            {
                this.aMSField = value;
            }
        }
        public long LOS
        {
            get
            {
                return this.lOSField;
            }
            set 
            {
                this.lOSField = value;
            }
        }
        public long LMS
        {
            get
            {
                return this.lMSField;
            }
            set 
            {
                this.lMSField = value;
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
        public byte DCW_CBASSIGNED
        {
            get
            {
                return this.dCW_CBASSIGNEDField;
            }
            set
            {
                this.dCW_CBASSIGNEDField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class WORKORDERASSETFILTERBY
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
    public partial class WORKORDERGLACCOUNT
    {

        private string vALUEField;

        private WORKORDERGLACCOUNTGLCOMP gLCOMPField;

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
        public WORKORDERGLACCOUNTGLCOMP GLCOMP
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
    public partial class WORKORDERGLACCOUNTGLCOMP
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
    public partial class WORKORDERSAFETYPLAN_LOOKUP_LIST_TYPE
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
    public partial class WORKORDERJPCLASS
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
    public partial class WORKORDERSTATUS
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
    public partial class WORKORDERWOCLASS
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
