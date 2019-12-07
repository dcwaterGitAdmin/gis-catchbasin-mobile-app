namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class PERSONGROUPTEAMMboSet
    {

        private PERSONGROUPTEAMMboSetPERSONGROUPTEAM[] pERSONGROUPTEAMField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PERSONGROUPTEAM")]
        public PERSONGROUPTEAMMboSetPERSONGROUPTEAM[] PERSONGROUPTEAM
        {
            get
            {
                return this.pERSONGROUPTEAMField;
            }
            set
            {
                this.pERSONGROUPTEAMField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class PERSONGROUPTEAMMboSetPERSONGROUPTEAM
    {

        private string cALNUMField;

        private string sHIFTNUMField;

        private int gROUPDEFAULTField;

        private int oRGDEFAULTField;

        private string pERSONGROUPField;

        private int pERSONGROUPTEAMIDField;

        private string rESPPARTYField;

        private string rESPPARTYGROUPField;

        private int? rESPPARTYGROUPSEQField;

        private int rESPPARTYSEQField;

        private int sITEDEFAULTField;

        private string uSEFORORGField;

        private string uSEFORSITEField;

        private string dCW_DESIGNATIONField;

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
        public int GROUPDEFAULT
        {
            get
            {
                return this.gROUPDEFAULTField;
            }
            set
            {
                this.gROUPDEFAULTField = value;
            }
        }

        /// <remarks/>
        public int ORGDEFAULT
        {
            get
            {
                return this.oRGDEFAULTField;
            }
            set
            {
                this.oRGDEFAULTField = value;
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
        public int PERSONGROUPTEAMID
        {
            get
            {
                return this.pERSONGROUPTEAMIDField;
            }
            set
            {
                this.pERSONGROUPTEAMIDField = value;
            }
        }

        /// <remarks/>
        public string RESPPARTY
        {
            get
            {
                return this.rESPPARTYField;
            }
            set
            {
                this.rESPPARTYField = value;
            }
        }

        /// <remarks/>
        public string RESPPARTYGROUP
        {
            get
            {
                return this.rESPPARTYGROUPField;
            }
            set
            {
                this.rESPPARTYGROUPField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public int? RESPPARTYGROUPSEQ
        {
            get
            {
                return this.rESPPARTYGROUPSEQField;
            }
            set
            {
                this.rESPPARTYGROUPSEQField = value;
            }
        }

        /// <remarks/>
        public int RESPPARTYSEQ
        {
            get
            {
                return this.rESPPARTYSEQField;
            }
            set
            {
                this.rESPPARTYSEQField = value;
            }
        }

        /// <remarks/>
        public int SITEDEFAULT
        {
            get
            {
                return this.sITEDEFAULTField;
            }
            set
            {
                this.sITEDEFAULTField = value;
            }
        }

        /// <remarks/>
        public string USEFORORG
        {
            get
            {
                return this.uSEFORORGField;
            }
            set
            {
                this.uSEFORORGField = value;
            }
        }

        /// <remarks/>
        public string USEFORSITE
        {
            get
            {
                return this.uSEFORSITEField;
            }
            set
            {
                this.uSEFORSITEField = value;
            }
        }

        /// <remarks/>
        public string DCW_DESIGNATION
        {
            get
            {
                return this.dCW_DESIGNATIONField;
            }
            set
            {
                this.dCW_DESIGNATIONField = value;
            }
        }
    }
}
