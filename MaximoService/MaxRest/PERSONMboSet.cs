using System;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class PERSONMboSet
    {

        private PERSONMboSetPERSON[] pERSONField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("PERSON")]
        public PERSONMboSetPERSON[] PERSON
        {
            get
            {
                return this.pERSONField;
            }
            set
            {
                this.pERSONField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class PERSONMboSetPERSON
    {

        private Nullable<DateTime> dISPLAYFROMField;

        private string dISPLAYNAME_LONGDESCRIPTIONField;

        private string nP_STATUSMEMOField;

        private string pRIMARYCALNUMField;

        private string pRIMARYCALORGField;

        private string pRIMARYEMAILField;

        private string pRIMARYPHONEField;

        private string pRIMARYSHIFTNUMField;

        private byte sTATUSIFACEField;

        private byte aCCEPTINGWFMAILField;

        private string aDDRESSLINE1Field;

        private string aDDRESSLINE2Field;

        private string aDDRESSLINE3Field;

        private string bILLTOADDRESSField;

        private Nullable<DateTime> bIRTHDATEField;

        private string cITYField;

        private string cOUNTRYField;

        private string cOUNTYField;

        private string dELEGATEField;

        private Nullable<DateTime> dELEGATEFROMDATEField;

        private Nullable<DateTime> dELEGATETODATEField;

        private string dEPARTMENTField;

        private string dISPLAYNAMEField;

        private string dROPPOINTField;

        private string eMPLOYEETYPEField;

        private string eXTERNALREFIDField;

        private string fIRSTNAMEField;

        private byte hASLDField;

        private Nullable<DateTime> hIREDATEField;

        private string jOBCODEField;

        private string lANGCODEField;

        private string lANGUAGEField;

        private Nullable<DateTime> lASTEVALDATEField;

        private string lASTNAMEField;

        private string lOCALEField;

        private string lOCATIONField;

        private string lOCATIONORGField;

        private string lOCATIONSITEField;

        private byte lOCTOSERVREQField;

        private Nullable<DateTime> nEXTEVALDATEField;

        private string oWNERSYSIDField;

        private string pCARDEXPDATEField;

        private string pCARDNUMField;

        private string pCARDTYPEField;

        private string pCARDVERIFICATIONField;

        private string pERSONIDField;

        private long pERSONUIDField;

        private string pOSTALCODEField;

        private string rEGIONDISTRICTField;

        private string sENDERSYSIDField;

        private string sHIPTOADDRESSField;

        private string sOURCESYSIDField;

        private string sTATEPROVINCEField;

        private PERSONMboSetPERSONSTATUS sTATUSField;

        private Nullable<DateTime> sTATUSDATEField;

        private string sUPERVISORField;

        private Nullable<DateTime> tERMINATIONDATEField;

        private PERSONMboSetPERSONTIMEZONE tIMEZONEField;

        private string tITLEField;

        private PERSONMboSetPERSONTRANSEMAILELECTION tRANSEMAILELECTIONField;

        private Nullable<long> vIPField;

        private PERSONMboSetPERSONWFMAILELECTION wFMAILELECTIONField;

        private Nullable<long> wOPRIORITYField;

        private string pRIMARYSMSField;

        private string oWNERGROUPField;

        private string iM_IDField;

        private string cALTYPEField;

        private string dFLTAPPField;

        private long? dEVICECLASSField;

        /// <remarks/>
        public Nullable<DateTime> DISPLAYFROM
        {
            get
            {
                return this.dISPLAYFROMField;
            }
            set
            {
                this.dISPLAYFROMField = value;
            }
        }

        /// <remarks/>
        public string DISPLAYNAME_LONGDESCRIPTION
        {
            get
            {
                return this.dISPLAYNAME_LONGDESCRIPTIONField;
            }
            set
            {
                this.dISPLAYNAME_LONGDESCRIPTIONField = value;
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
        public string PRIMARYCALNUM
        {
            get
            {
                return this.pRIMARYCALNUMField;
            }
            set
            {
                this.pRIMARYCALNUMField = value;
            }
        }

        /// <remarks/>
        public string PRIMARYCALORG
        {
            get
            {
                return this.pRIMARYCALORGField;
            }
            set
            {
                this.pRIMARYCALORGField = value;
            }
        }

        /// <remarks/>
        public string PRIMARYEMAIL
        {
            get
            {
                return this.pRIMARYEMAILField;
            }
            set
            {
                this.pRIMARYEMAILField = value;
            }
        }

        /// <remarks/>
        public string PRIMARYPHONE
        {
            get
            {
                return this.pRIMARYPHONEField;
            }
            set
            {
                this.pRIMARYPHONEField = value;
            }
        }

        /// <remarks/>
        public string PRIMARYSHIFTNUM
        {
            get
            {
                return this.pRIMARYSHIFTNUMField;
            }
            set
            {
                this.pRIMARYSHIFTNUMField = value;
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
        public byte ACCEPTINGWFMAIL
        {
            get
            {
                return this.aCCEPTINGWFMAILField;
            }
            set
            {
                this.aCCEPTINGWFMAILField = value;
            }
        }

        /// <remarks/>
        public string ADDRESSLINE1
        {
            get
            {
                return this.aDDRESSLINE1Field;
            }
            set
            {
                this.aDDRESSLINE1Field = value;
            }
        }

        /// <remarks/>
        public string ADDRESSLINE2
        {
            get
            {
                return this.aDDRESSLINE2Field;
            }
            set
            {
                this.aDDRESSLINE2Field = value;
            }
        }

        /// <remarks/>
        public string ADDRESSLINE3
        {
            get
            {
                return this.aDDRESSLINE3Field;
            }
            set
            {
                this.aDDRESSLINE3Field = value;
            }
        }

        /// <remarks/>
        public string BILLTOADDRESS
        {
            get
            {
                return this.bILLTOADDRESSField;
            }
            set
            {
                this.bILLTOADDRESSField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<DateTime> BIRTHDATE
        {
            get
            {
                return this.bIRTHDATEField;
            }
            set
            {
                this.bIRTHDATEField = value;
            }
        }

        /// <remarks/>
        public string CITY
        {
            get
            {
                return this.cITYField;
            }
            set
            {
                this.cITYField = value;
            }
        }

        /// <remarks/>
        public string COUNTRY
        {
            get
            {
                return this.cOUNTRYField;
            }
            set
            {
                this.cOUNTRYField = value;
            }
        }

        /// <remarks/>
        public string COUNTY
        {
            get
            {
                return this.cOUNTYField;
            }
            set
            {
                this.cOUNTYField = value;
            }
        }

        /// <remarks/>
        public string DELEGATE
        {
            get
            {
                return this.dELEGATEField;
            }
            set
            {
                this.dELEGATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<DateTime> DELEGATEFROMDATE
        {
            get
            {
                return this.dELEGATEFROMDATEField;
            }
            set
            {
                this.dELEGATEFROMDATEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<DateTime> DELEGATETODATE
        {
            get
            {
                return this.dELEGATETODATEField;
            }
            set
            {
                this.dELEGATETODATEField = value;
            }
        }

        /// <remarks/>
        public string DEPARTMENT
        {
            get
            {
                return this.dEPARTMENTField;
            }
            set
            {
                this.dEPARTMENTField = value;
            }
        }

        /// <remarks/>
        public string DISPLAYNAME
        {
            get
            {
                return this.dISPLAYNAMEField;
            }
            set
            {
                this.dISPLAYNAMEField = value;
            }
        }

        /// <remarks/>
        public string DROPPOINT
        {
            get
            {
                return this.dROPPOINTField;
            }
            set
            {
                this.dROPPOINTField = value;
            }
        }

        /// <remarks/>
        public string EMPLOYEETYPE
        {
            get
            {
                return this.eMPLOYEETYPEField;
            }
            set
            {
                this.eMPLOYEETYPEField = value;
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
        public string FIRSTNAME
        {
            get
            {
                return this.fIRSTNAMEField;
            }
            set
            {
                this.fIRSTNAMEField = value;
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
        public Nullable<DateTime> HIREDATE
        {
            get
            {
                return this.hIREDATEField;
            }
            set
            {
                this.hIREDATEField = value;
            }
        }

        /// <remarks/>
        public string JOBCODE
        {
            get
            {
                return this.jOBCODEField;
            }
            set
            {
                this.jOBCODEField = value;
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
        public string LANGUAGE
        {
            get
            {
                return this.lANGUAGEField;
            }
            set
            {
                this.lANGUAGEField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<DateTime> LASTEVALDATE
        {
            get
            {
                return this.lASTEVALDATEField;
            }
            set
            {
                this.lASTEVALDATEField = value;
            }
        }

        /// <remarks/>
        public string LASTNAME
        {
            get
            {
                return this.lASTNAMEField;
            }
            set
            {
                this.lASTNAMEField = value;
            }
        }

        /// <remarks/>
        public string LOCALE
        {
            get
            {
                return this.lOCALEField;
            }
            set
            {
                this.lOCALEField = value;
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
        public string LOCATIONORG
        {
            get
            {
                return this.lOCATIONORGField;
            }
            set
            {
                this.lOCATIONORGField = value;
            }
        }

        /// <remarks/>
        public string LOCATIONSITE
        {
            get
            {
                return this.lOCATIONSITEField;
            }
            set
            {
                this.lOCATIONSITEField = value;
            }
        }

        /// <remarks/>
        public byte LOCTOSERVREQ
        {
            get
            {
                return this.lOCTOSERVREQField;
            }
            set
            {
                this.lOCTOSERVREQField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<DateTime> NEXTEVALDATE
        {
            get
            {
                return this.nEXTEVALDATEField;
            }
            set
            {
                this.nEXTEVALDATEField = value;
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
        public string PCARDEXPDATE
        {
            get
            {
                return this.pCARDEXPDATEField;
            }
            set
            {
                this.pCARDEXPDATEField = value;
            }
        }

        /// <remarks/>
        public string PCARDNUM
        {
            get
            {
                return this.pCARDNUMField;
            }
            set
            {
                this.pCARDNUMField = value;
            }
        }

        /// <remarks/>
        public string PCARDTYPE
        {
            get
            {
                return this.pCARDTYPEField;
            }
            set
            {
                this.pCARDTYPEField = value;
            }
        }

        /// <remarks/>
        public string PCARDVERIFICATION
        {
            get
            {
                return this.pCARDVERIFICATIONField;
            }
            set
            {
                this.pCARDVERIFICATIONField = value;
            }
        }

        /// <remarks/>
        public string PERSONID
        {
            get
            {
                return this.pERSONIDField;
            }
            set
            {
                this.pERSONIDField = value;
            }
        }

        /// <remarks/>
        public long PERSONUID
        {
            get
            {
                return this.pERSONUIDField;
            }
            set
            {
                this.pERSONUIDField = value;
            }
        }

        /// <remarks/>
        public string POSTALCODE
        {
            get
            {
                return this.pOSTALCODEField;
            }
            set
            {
                this.pOSTALCODEField = value;
            }
        }

        /// <remarks/>
        public string REGIONDISTRICT
        {
            get
            {
                return this.rEGIONDISTRICTField;
            }
            set
            {
                this.rEGIONDISTRICTField = value;
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
        public string SHIPTOADDRESS
        {
            get
            {
                return this.sHIPTOADDRESSField;
            }
            set
            {
                this.sHIPTOADDRESSField = value;
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
        public string STATEPROVINCE
        {
            get
            {
                return this.sTATEPROVINCEField;
            }
            set
            {
                this.sTATEPROVINCEField = value;
            }
        }

        /// <remarks/>
        public PERSONMboSetPERSONSTATUS STATUS
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
        public Nullable<DateTime> STATUSDATE
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
        public Nullable<DateTime> TERMINATIONDATE
        {
            get
            {
                return this.tERMINATIONDATEField;
            }
            set
            {
                this.tERMINATIONDATEField = value;
            }
        }

        /// <remarks/>
        public PERSONMboSetPERSONTIMEZONE TIMEZONE
        {
            get
            {
                return this.tIMEZONEField;
            }
            set
            {
                this.tIMEZONEField = value;
            }
        }

        /// <remarks/>
        public string TITLE
        {
            get
            {
                return this.tITLEField;
            }
            set
            {
                this.tITLEField = value;
            }
        }

        /// <remarks/>
        public PERSONMboSetPERSONTRANSEMAILELECTION TRANSEMAILELECTION
        {
            get
            {
                return this.tRANSEMAILELECTIONField;
            }
            set
            {
                this.tRANSEMAILELECTIONField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<long> VIP
        {
            get
            {
                return this.vIPField;
            }
            set
            {
                this.vIPField = value;
            }
        }

        /// <remarks/>
        public PERSONMboSetPERSONWFMAILELECTION WFMAILELECTION
        {
            get
            {
                return this.wFMAILELECTIONField;
            }
            set
            {
                this.wFMAILELECTIONField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Nullable<long> WOPRIORITY
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
        public string PRIMARYSMS
        {
            get
            {
                return this.pRIMARYSMSField;
            }
            set
            {
                this.pRIMARYSMSField = value;
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
        public string IM_ID
        {
            get
            {
                return this.iM_IDField;
            }
            set
            {
                this.iM_IDField = value;
            }
        }

        /// <remarks/>
        public string CALTYPE
        {
            get
            {
                return this.cALTYPEField;
            }
            set
            {
                this.cALTYPEField = value;
            }
        }

        /// <remarks/>
        public string DFLTAPP
        {
            get
            {
                return this.dFLTAPPField;
            }
            set
            {
                this.dFLTAPPField = value;
            }
        }

        /// <remarks/>
        public long? DEVICECLASS
        {
            get
            {
                return this.dEVICECLASSField;
            }
            set
            {
                this.dEVICECLASSField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class PERSONMboSetPERSONSTATUS
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
    public partial class PERSONMboSetPERSONTIMEZONE
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
    public partial class PERSONMboSetPERSONTRANSEMAILELECTION
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
    public partial class PERSONMboSetPERSONWFMAILELECTION
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
