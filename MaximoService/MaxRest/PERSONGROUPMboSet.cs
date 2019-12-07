namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class PERSONGROUPMboSet
    {

        private PERSONGROUPMboSetPERSONGROUP[] pERSONGROUPField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("PERSONGROUP")]
        public PERSONGROUPMboSetPERSONGROUP[] PERSONGROUP
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
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class PERSONGROUPMboSetPERSONGROUP
    {

        private byte bCCField;

        private byte ccField;

        private string dESCRIPTION_LONGDESCRIPTIONField;

        private byte sENDTOField;

        private string dESCRIPTIONField;

        private byte hASLDField;

        private string lANGCODEField;

        private string pERSONGROUPField;

        private long pERSONGROUPIDField;

        private string vEHICLENUMField;

        private long iSCREWWORKGROUPField;

        /// <remarks/>
        public byte BCC
        {
            get
            {
                return this.bCCField;
            }
            set
            {
                this.bCCField = value;
            }
        }

        /// <remarks/>
        public byte CC
        {
            get
            {
                return this.ccField;
            }
            set
            {
                this.ccField = value;
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
        public byte SENDTO
        {
            get
            {
                return this.sENDTOField;
            }
            set
            {
                this.sENDTOField = value;
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
        public long PERSONGROUPID
        {
            get
            {
                return this.pERSONGROUPIDField;
            }
            set
            {
                this.pERSONGROUPIDField = value;
            }
        }

        /// <remarks/>
        public string VEHICLENUM
        {
            get
            {
                return this.vEHICLENUMField;
            }
            set
            {
                this.vEHICLENUMField = value;
            }
        }
        /// <remarks/>
        public long ISCREWWORKGROUP
        {
            get
            {
                return this.iSCREWWORKGROUPField;
            }
            set
            {
                this.iSCREWWORKGROUPField = value;
            }
        }

    }


    
}
