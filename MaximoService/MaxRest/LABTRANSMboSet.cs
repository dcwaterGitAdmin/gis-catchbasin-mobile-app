using System;
using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class LABTRANSMboSet
    {

        private LABTRANSMboSetLABTRANS[] lABTRANSField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LABTRANS")]
        public LABTRANSMboSetLABTRANS[] LABTRANS
        {
            get
            {
                return this.lABTRANSField;
            }
            set
            {
                this.lABTRANSField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class LABTRANSMboSetLABTRANS
    {

        private string aCTIVITYField;

        private bool aCTIVITYFieldSpecified;

        private int? aCTUALSTASKIDField;

        private string fCPROJECTIDField;

        private string fCTASKIDField;

        private int? tASKIDField;

        private string wONUMField;

        private bool wONUMFieldSpecified;

        private string sOURCEMBOField;

        private System.DateTime tRANSDATEField;

        private string lABORCODEField;

        private string cRAFTField;

        private decimal pAYRATEField;

        private decimal rEGULARHRSField;

        private string eNTERBYField;

        private System.DateTime eNTERDATEField;

        private string lTWO1Field;

        private byte lT7Field;

        private System.DateTime sTARTDATEField;

        private System.DateTime? sTARTTIMEField;

        private System.DateTime? fINISHDATEField;

        private System.DateTime? fINISHTIMEField;

        private LABTRANSMboSetLABTRANSTRANSTYPE tRANSTYPEField;

        private byte oUTSIDEField;

        private string mEMOField;

        private byte rOLLUPField;

        private LABTRANSMboSetLABTRANSGLDEBITACCT gLDEBITACCTField;

        private decimal lINECOSTField;

        private string gLCREDITACCTField;

        private string fINANCIALPERIODField;

        private string pONUMField;

        private int? pOLINENUMField;

        private string lOCATIONField;

        private byte gENAPPRSERVRECEIPTField;

        private System.DateTime? pAYMENTTRANSDATEField;

        private decimal? eXCHANGERATE2Field;

        private decimal? lINECOST2Field;

        private int lABTRANSIDField;

        private int? sERVRECTRANSIDField;

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

        private string cONTRACTNUMField;

        private int? iNVOICELINENUMField;

        private string iNVOICENUMField;

        private string pREMIUMPAYCODEField;

        private decimal pREMIUMPAYHOURSField;

        private decimal pREMIUMPAYRATEField;

        private LABTRANSMboSetLABTRANSPREMIUMPAYRATETYPE pREMIUMPAYRATETYPEField;

        private int? rEVISIONNUMField;

        private string sKILLLEVELField;

        private string tICKETCLASSField;

        private string tICKETIDField;

        private string tIMERSTATUSField;

        private string vENDORField;

        private Nullable<long> pOREVISIONNUMField;

        private string cREWWORKGROUPField;

        private string aMCREWField;

        private string aMCREWTYPEField;

        private string pOSITIONField;
 
        private byte dCW_TRUCKLEADField;

        private byte dCW_TRUCKSECONDField;

        private byte dCW_TRUCKDRIVERField;

        private string dCW_TRUCKNUMField;

        /// <remarks/>
        public string ACTIVITY
        {
            get
            {
                return this.aCTIVITYField;
            }
            set
            {
                this.aCTIVITYField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ACTIVITYSpecified
        {
            get
            {
                return this.aCTIVITYFieldSpecified;
            }
            set
            {
                this.aCTIVITYFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public int? ACTUALSTASKID
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
        public int? TASKID
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
        public string LABORCODE
        {
            get
            {
                return this.lABORCODEField;
            }
            set
            {
                this.lABORCODEField = value;
            }
        }

        /// <remarks/>
        public string CRAFT
        {
            get
            {
                return this.cRAFTField;
            }
            set
            {
                this.cRAFTField = value;
            }
        }

        /// <remarks/>
        public decimal PAYRATE
        {
            get
            {
                return this.pAYRATEField;
            }
            set
            {
                this.pAYRATEField = value;
            }
        }

        /// <remarks/>
        public decimal REGULARHRS
        {
            get
            {
                return this.rEGULARHRSField;
            }
            set
            {
                this.rEGULARHRSField = value;
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
        public string LTWO1
        {
            get
            {
                return this.lTWO1Field;
            }
            set
            {
                this.lTWO1Field = value;
            }
        }

        /// <remarks/>
        public byte LT7
        {
            get
            {
                return this.lT7Field;
            }
            set
            {
                this.lT7Field = value;
            }
        }

        /// <remarks/>
        public System.DateTime STARTDATE
        {
            get
            {
                return this.sTARTDATEField;
            }
            set
            {
                this.sTARTDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? STARTTIME
        {
            get
            {
                return this.sTARTTIMEField;
            }
            set
            {
                this.sTARTTIMEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? FINISHDATE
        {
            get
            {
                return this.fINISHDATEField;
            }
            set
            {
                this.fINISHDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? FINISHTIME
        {
            get
            {
                return this.fINISHTIMEField;
            }
            set
            {
                this.fINISHTIMEField = value;
            }
        }

        /// <remarks/>
        public LABTRANSMboSetLABTRANSTRANSTYPE TRANSTYPE
        {
            get
            {
                return this.tRANSTYPEField;
            }
            set
            {
                this.tRANSTYPEField = value;
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
        public string MEMO
        {
            get
            {
                return this.mEMOField;
            }
            set
            {
                this.mEMOField = value;
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
        public LABTRANSMboSetLABTRANSGLDEBITACCT GLDEBITACCT
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
        public string PONUM
        {
            get
            {
                return this.pONUMField;
            }
            set
            {
                this.pONUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public int? POLINENUM
        {
            get
            {
                return this.pOLINENUMField;
            }
            set
            {
                this.pOLINENUMField = value;
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
        public byte GENAPPRSERVRECEIPT
        {
            get
            {
                return this.gENAPPRSERVRECEIPTField;
            }
            set
            {
                this.gENAPPRSERVRECEIPTField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? PAYMENTTRANSDATE
        {
            get
            {
                return this.pAYMENTTRANSDATEField;
            }
            set
            {
                this.pAYMENTTRANSDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? EXCHANGERATE2
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? LINECOST2
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
        public int LABTRANSID
        {
            get
            {
                return this.lABTRANSIDField;
            }
            set
            {
                this.lABTRANSIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public int? SERVRECTRANSID
        {
            get
            {
                return this.sERVRECTRANSIDField;
            }
            set
            {
                this.sERVRECTRANSIDField = value;
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
        public string CONTRACTNUM
        {
            get
            {
                return this.cONTRACTNUMField;
            }
            set
            {
                this.cONTRACTNUMField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public int? INVOICELINENUM
        {
            get
            {
                return this.iNVOICELINENUMField;
            }
            set
            {
                this.iNVOICELINENUMField = value;
            }
        }

        /// <remarks/>
        public string INVOICENUM
        {
            get
            {
                return this.iNVOICENUMField;
            }
            set
            {
                this.iNVOICENUMField = value;
            }
        }

        /// <remarks/>
        public string PREMIUMPAYCODE
        {
            get
            {
                return this.pREMIUMPAYCODEField;
            }
            set
            {
                this.pREMIUMPAYCODEField = value;
            }
        }

        /// <remarks/>
        public decimal PREMIUMPAYHOURS
        {
            get
            {
                return this.pREMIUMPAYHOURSField;
            }
            set
            {
                this.pREMIUMPAYHOURSField = value;
            }
        }

        /// <remarks/>
        public decimal PREMIUMPAYRATE
        {
            get
            {
                return this.pREMIUMPAYRATEField;
            }
            set
            {
                this.pREMIUMPAYRATEField = value;
            }
        }

        /// <remarks/>
        public LABTRANSMboSetLABTRANSPREMIUMPAYRATETYPE PREMIUMPAYRATETYPE
        {
            get
            {
                return this.pREMIUMPAYRATETYPEField;
            }
            set
            {
                this.pREMIUMPAYRATETYPEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public int? REVISIONNUM
        {
            get
            {
                return this.rEVISIONNUMField;
            }
            set
            {
                this.rEVISIONNUMField = value;
            }
        }

        /// <remarks/>
        public string SKILLLEVEL
        {
            get
            {
                return this.sKILLLEVELField;
            }
            set
            {
                this.sKILLLEVELField = value;
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

        /// <remarks/>
        public string TIMERSTATUS
        {
            get
            {
                return this.tIMERSTATUSField;
            }
            set
            {
                this.tIMERSTATUSField = value;
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

        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<long> POREVISIONNUM
        {
            get
            {
                return this.pOREVISIONNUMField ;
            }
            set 
            {
                this.pOREVISIONNUMField = value;
            }
        }
        public string CREWWORKGROUP
        {
            get
            {
                return this.cREWWORKGROUPField ;
            }
            set 
            {
                this.cREWWORKGROUPField = value;
            }
        }
        public string AMCREW
        {
            get
            {
                return this.aMCREWField ;
            }
            set 
            {
                this.aMCREWField  = value;
            }
        }
        public string AMCREWTYPE
        {
            get
            {
                return this.aMCREWTYPEField ;
            }
            set 
            {
                this.aMCREWTYPEField  = value;
            }
        }

        public string POSITION
        {
            get
            {
                return this.pOSITIONField ;
            }
            set 
            {
                this.pOSITIONField  = value;
            }
        }
        
        /// <remarks/>
        public byte DCW_TRUCKLEAD
        {
            get
            {
                return this.dCW_TRUCKLEADField;
            }
            set
            {
                this.dCW_TRUCKLEADField = value;
            }
        }

        /// <remarks/>
        public byte DCW_TRUCKSECOND
        {
            get
            {
                return this.dCW_TRUCKSECONDField;
            }
            set
            {
                this.dCW_TRUCKSECONDField = value;
            }
        }

        /// <remarks/>
        public byte DCW_TRUCKDRIVER
        {
            get
            {
                return this.dCW_TRUCKDRIVERField;
            }
            set
            {
                this.dCW_TRUCKDRIVERField = value;
            }
        }

        /// <remarks/>
        public string DCW_TRUCKNUM
        {
            get
            {
                return this.dCW_TRUCKNUMField;
            }
            set
            {
                this.dCW_TRUCKNUMField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class LABTRANSMboSetLABTRANSTRANSTYPE
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
    public partial class LABTRANSMboSetLABTRANSGLDEBITACCT
    {

        private string vALUEField;

        private LABTRANSMboSetLABTRANSGLDEBITACCTGLCOMP[] gLCOMPField;

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
        [System.Xml.Serialization.XmlElementAttribute("GLCOMP")]
        public LABTRANSMboSetLABTRANSGLDEBITACCTGLCOMP[] GLCOMP
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
    public partial class LABTRANSMboSetLABTRANSGLDEBITACCTGLCOMP
    {

        private byte glorderField;

        private string valueField;

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
    public partial class LABTRANSMboSetLABTRANSPREMIUMPAYRATETYPE
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
