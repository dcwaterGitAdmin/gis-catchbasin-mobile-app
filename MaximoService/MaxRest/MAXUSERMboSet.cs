using System;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class MAXUSERMboSet
    {
        private MAXUSERMboSetMAXUSER[] mAXUSERField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("MAXUSER")]
        public MAXUSERMboSetMAXUSER[] MAXUSER
        {
            get
            {
                return this.mAXUSERField;
            }
            set
            {
                this.mAXUSERField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class MAXUSERMboSetMAXUSER
    {

        private string dBPASSWORDField;

        private string dBPASSWORDCHECKField;

        private string nEWPERSONIDField;

        private string nP_STATUSMEMOField;

        private string pASSWORDCHECKField;

        private string pASSWORDINPUTField;

        private string pASSWORDOLDField;

        private byte sYNCHPASSWORDSField;

        private byte eMAILPSWDField;

        private string gENERATEDPSWDField;

        private byte sTATUSIFACEField;

        private string iM_PASSWORDField;

        private string dATABASEUSERIDField;

        private string dEFSITEField;

        private string dEFSTOREROOMField;

        private long fAILEDLOGINSField;

        private byte fORCEEXPIRATIONField;

        private string lOGINIDField;

        private long mAXUSERIDField;

        private string mEMOField;

        private string pASSWORDField;

        private string pERSONIDField;

        private Nullable<DateTime> pWEXPIRATIONField;

        private string pWHINTANSWERField;

        private string pWHINTQUESTIONField;

        private byte qUERYWITHSITEField;

        private MAXUSERMboSetMAXUSERSTATUS sTATUSField;

        private string sTOREROOMSITEField;

        private byte sYSUSERField;

        private MAXUSERMboSetMAXUSERTYPE tYPEField;

        private string uSERIDField;

        private byte sCREENREADERField;

        private byte iNACTIVESITESField;

        /// <remarks/>
        public string DBPASSWORD
        {
            get
            {
                return this.dBPASSWORDField;
            }
            set
            {
                this.dBPASSWORDField = value;
            }
        }

        /// <remarks/>
        public string DBPASSWORDCHECK
        {
            get
            {
                return this.dBPASSWORDCHECKField;
            }
            set
            {
                this.dBPASSWORDCHECKField = value;
            }
        }

        /// <remarks/>
        public string NEWPERSONID
        {
            get
            {
                return this.nEWPERSONIDField;
            }
            set
            {
                this.nEWPERSONIDField = value;
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
        public string PASSWORDCHECK
        {
            get
            {
                return this.pASSWORDCHECKField;
            }
            set
            {
                this.pASSWORDCHECKField = value;
            }
        }

        /// <remarks/>
        public string PASSWORDINPUT
        {
            get
            {
                return this.pASSWORDINPUTField;
            }
            set
            {
                this.pASSWORDINPUTField = value;
            }
        }

        /// <remarks/>
        public string PASSWORDOLD
        {
            get
            {
                return this.pASSWORDOLDField;
            }
            set
            {
                this.pASSWORDOLDField = value;
            }
        }

        /// <remarks/>
        public byte SYNCHPASSWORDS
        {
            get
            {
                return this.sYNCHPASSWORDSField;
            }
            set
            {
                this.sYNCHPASSWORDSField = value;
            }
        }

        /// <remarks/>
        public byte EMAILPSWD
        {
            get
            {
                return this.eMAILPSWDField;
            }
            set
            {
                this.eMAILPSWDField = value;
            }
        }

        /// <remarks/>
        public string GENERATEDPSWD
        {
            get
            {
                return this.gENERATEDPSWDField;
            }
            set
            {
                this.gENERATEDPSWDField = value;
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
        public string IM_PASSWORD
        {
            get
            {
                return this.iM_PASSWORDField;
            }
            set
            {
                this.iM_PASSWORDField = value;
            }
        }

        /// <remarks/>
        public string DATABASEUSERID
        {
            get
            {
                return this.dATABASEUSERIDField;
            }
            set
            {
                this.dATABASEUSERIDField = value;
            }
        }

        /// <remarks/>
        public string DEFSITE
        {
            get
            {
                return this.dEFSITEField;
            }
            set
            {
                this.dEFSITEField = value;
            }
        }

        /// <remarks/>
        public string DEFSTOREROOM
        {
            get
            {
                return this.dEFSTOREROOMField;
            }
            set
            {
                this.dEFSTOREROOMField = value;
            }
        }

        /// <remarks/>
        public long FAILEDLOGINS
        {
            get
            {
                return this.fAILEDLOGINSField;
            }
            set
            {
                this.fAILEDLOGINSField = value;
            }
        }

        /// <remarks/>
        public byte FORCEEXPIRATION
        {
            get
            {
                return this.fORCEEXPIRATIONField;
            }
            set
            {
                this.fORCEEXPIRATIONField = value;
            }
        }

        /// <remarks/>
        public string LOGINID
        {
            get
            {
                return this.lOGINIDField;
            }
            set
            {
                this.lOGINIDField = value;
            }
        }

        /// <remarks/>
        public long MAXUSERID
        {
            get
            {
                return this.mAXUSERIDField;
            }
            set
            {
                this.mAXUSERIDField = value;
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
        public string PASSWORD
        {
            get
            {
                return this.pASSWORDField;
            }
            set
            {
                this.pASSWORDField = value;
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<DateTime> PWEXPIRATION
        {
            get
            {
                return this.pWEXPIRATIONField;
            }
            set
            {
                this.pWEXPIRATIONField = value;
            }
        }

        /// <remarks/>
        public string PWHINTANSWER
        {
            get
            {
                return this.pWHINTANSWERField;
            }
            set
            {
                this.pWHINTANSWERField = value;
            }
        }

        /// <remarks/>
        public string PWHINTQUESTION
        {
            get
            {
                return this.pWHINTQUESTIONField;
            }
            set
            {
                this.pWHINTQUESTIONField = value;
            }
        }

        /// <remarks/>
        public byte QUERYWITHSITE
        {
            get
            {
                return this.qUERYWITHSITEField;
            }
            set
            {
                this.qUERYWITHSITEField = value;
            }
        }

        /// <remarks/>
        public MAXUSERMboSetMAXUSERSTATUS STATUS
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
        public string STOREROOMSITE
        {
            get
            {
                return this.sTOREROOMSITEField;
            }
            set
            {
                this.sTOREROOMSITEField = value;
            }
        }

        /// <remarks/>
        public byte SYSUSER
        {
            get
            {
                return this.sYSUSERField;
            }
            set
            {
                this.sYSUSERField = value;
            }
        }

        /// <remarks/>
        public MAXUSERMboSetMAXUSERTYPE TYPE
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
        public string USERID
        {
            get
            {
                return this.uSERIDField;
            }
            set
            {
                this.uSERIDField = value;
            }
        }

        /// <remarks/>
        public byte SCREENREADER
        {
            get
            {
                return this.sCREENREADERField;
            }
            set
            {
                this.sCREENREADERField = value;
            }
        }

        /// <remarks/>
        public byte INACTIVESITES
        {
            get
            {
                return this.iNACTIVESITESField;
            }
            set
            {
                this.iNACTIVESITESField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class MAXUSERMboSetMAXUSERSTATUS
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
    public partial class MAXUSERMboSetMAXUSERTYPE
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
