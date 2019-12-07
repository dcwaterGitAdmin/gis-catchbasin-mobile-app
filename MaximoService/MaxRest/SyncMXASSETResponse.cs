using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class SyncMXASSETResponse
    {

        private SyncMXASSETResponseMXASSETSet mXASSETSetField;

        private System.DateTime creationDateTimeField;

        private string transLanguageField;

        private string baseLanguageField;

        private ulong messageIDField;

        private string maximoVersionField;

        /// <remarks/>
        public SyncMXASSETResponseMXASSETSet MXASSETSet
        {
            get
            {
                return this.mXASSETSetField;
            }
            set
            {
                this.mXASSETSetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime creationDateTime
        {
            get
            {
                return this.creationDateTimeField;
            }
            set
            {
                this.creationDateTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string transLanguage
        {
            get
            {
                return this.transLanguageField;
            }
            set
            {
                this.transLanguageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string baseLanguage
        {
            get
            {
                return this.baseLanguageField;
            }
            set
            {
                this.baseLanguageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ulong messageID
        {
            get
            {
                return this.messageIDField;
            }
            set
            {
                this.messageIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string maximoVersion
        {
            get
            {
                return this.maximoVersionField;
            }
            set
            {
                this.maximoVersionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class SyncMXASSETResponseMXASSETSet
    {

        private SyncMXASSETResponseMXASSETSetASSET aSSETField;

        /// <remarks/>
        public SyncMXASSETResponseMXASSETSetASSET ASSET
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
    public partial class SyncMXASSETResponseMXASSETSetASSET
    {

        private uint aSSETIDField;

        private uint aSSETNUMField;

        private string aSSETTAGField;

        private byte aUTOWOGENField;

        private decimal bUDGETCOSTField;

        private string cHANGEBYField;

        private System.DateTime cHANGEDATEField;

        private byte cHANGEPMSTATUSField;

        private byte cHILDRENField;

        private string dESCRIPTIONField;

        private byte dISABLEDField;

        private byte eQ22Field;

        private string fAILURECODEField;

        private byte fIXEDASSETField;

        private SyncMXASSETResponseMXASSETSetASSETGLACCOUNT gLACCOUNTField;

        private string gLOBALIDField;

        private string hIERARCHYPATHField;

        private decimal iNVCOSTField;

        private byte iSLINEARField;

        private byte iSRUNNINGField;

        private string iTEMSETIDField;

        private byte mAINTHIERCHYField;

        private byte mOVEDField;

        private string nEWSITEField;

        private string oRGIDField;

        private string pLUSSFEATURECLASSField;

        private byte pLUSSISGISField;

        private decimal pURCHASEPRICEField;

        private byte rEMOVEFROMACTIVEROUTESField;

        private byte rEMOVEFROMACTIVESPField;

        private decimal rEPLACECOSTField;

        private byte rOLLTOALLCHILDRENField;

        private string sITEIDField;

        private SyncMXASSETResponseMXASSETSetASSETSTATUS sTATUSField;

        private System.DateTime sTATUSDATEField;

        private decimal tOTALCOSTField;

        private decimal tOTDOWNTIMEField;

        private decimal tOTUNCHARGEDCOSTField;

        private decimal uNCHARGEDCOSTField;

        private decimal yTDCOSTField;

        private SyncMXASSETResponseMXASSETSetASSETASSETSPEC[] aSSETSPECField;

        /// <remarks/>
        public uint ASSETID
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
        public uint ASSETNUM
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
        public SyncMXASSETResponseMXASSETSetASSETGLACCOUNT GLACCOUNT
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
        public SyncMXASSETResponseMXASSETSetASSETSTATUS STATUS
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
        [System.Xml.Serialization.XmlElementAttribute("ASSETSPEC")]
        public SyncMXASSETResponseMXASSETSetASSETASSETSPEC[] ASSETSPEC
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

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class SyncMXASSETResponseMXASSETSetASSETGLACCOUNT
    {

        private string vALUEField;

        private SyncMXASSETResponseMXASSETSetASSETGLACCOUNTGLCOMP gLCOMPField;

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
        public SyncMXASSETResponseMXASSETSetASSETGLACCOUNTGLCOMP GLCOMP
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
    public partial class SyncMXASSETResponseMXASSETSetASSETGLACCOUNTGLCOMP
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
    public partial class SyncMXASSETResponseMXASSETSetASSETSTATUS
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
    public partial class SyncMXASSETResponseMXASSETSetASSETASSETSPEC
    {

        private string aLNVALUEField;

        private string aSSETATTRIDField;

        private uint aSSETSPECIDField;

        private string cHANGEBYField;

        private System.DateTime cHANGEDATEField;

        private ushort cLASSSTRUCTUREIDField;

        private byte cONTINUOUSField;

        private ushort dISPLAYSEQUENCEField;

        private byte iNHERITEDFROMITEMField;

        private byte iTEMSPECVALCHANGEDField;

        private byte lINEARASSETSPECIDField;

        private byte mANDATORYField;

        private decimal nUMVALUEField;

        private bool nUMVALUEFieldSpecified;

        private string oRGIDField;

        /// <remarks/>
        public string ALNVALUE
        {
            get
            {
                return this.aLNVALUEField;
            }
            set
            {
                this.aLNVALUEField = value;
            }
        }

        /// <remarks/>
        public string ASSETATTRID
        {
            get
            {
                return this.aSSETATTRIDField;
            }
            set
            {
                this.aSSETATTRIDField = value;
            }
        }

        /// <remarks/>
        public uint ASSETSPECID
        {
            get
            {
                return this.aSSETSPECIDField;
            }
            set
            {
                this.aSSETSPECIDField = value;
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
        public ushort CLASSSTRUCTUREID
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
        public byte CONTINUOUS
        {
            get
            {
                return this.cONTINUOUSField;
            }
            set
            {
                this.cONTINUOUSField = value;
            }
        }

        /// <remarks/>
        public ushort DISPLAYSEQUENCE
        {
            get
            {
                return this.dISPLAYSEQUENCEField;
            }
            set
            {
                this.dISPLAYSEQUENCEField = value;
            }
        }

        /// <remarks/>
        public byte INHERITEDFROMITEM
        {
            get
            {
                return this.iNHERITEDFROMITEMField;
            }
            set
            {
                this.iNHERITEDFROMITEMField = value;
            }
        }

        /// <remarks/>
        public byte ITEMSPECVALCHANGED
        {
            get
            {
                return this.iTEMSPECVALCHANGEDField;
            }
            set
            {
                this.iTEMSPECVALCHANGEDField = value;
            }
        }

        /// <remarks/>
        public byte LINEARASSETSPECID
        {
            get
            {
                return this.lINEARASSETSPECIDField;
            }
            set
            {
                this.lINEARASSETSPECIDField = value;
            }
        }

        /// <remarks/>
        public byte MANDATORY
        {
            get
            {
                return this.mANDATORYField;
            }
            set
            {
                this.mANDATORYField = value;
            }
        }

        /// <remarks/>
        public decimal NUMVALUE
        {
            get
            {
                return this.nUMVALUEField;
            }
            set
            {
                this.nUMVALUEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NUMVALUESpecified
        {
            get
            {
                return this.nUMVALUEFieldSpecified;
            }
            set
            {
                this.nUMVALUEFieldSpecified = value;
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

}
