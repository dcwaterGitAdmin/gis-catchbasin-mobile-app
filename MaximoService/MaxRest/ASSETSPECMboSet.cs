using System;
using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class ASSETSPECMboSet
    {

        private ASSETSPECMboSetASSETSPEC[] aSSETSPECField;

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

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    public partial class ASSETSPECMboSetASSETSPEC
    {

        private string eNDFEATURELABELField;

        private string sTARTFEATURELABELField;

        private string aLNVALUEField;

        private string aSSETATTRIDField;

        private string aSSETNUMField;

        private long aSSETSPECIDField;

        private string cHANGEBYField;

        private System.DateTime cHANGEDATEField;

        private string cLASSSTRUCTUREIDField;

        private long dISPLAYSEQUENCEField;

        private string eS01Field;

        private string eS02Field;

        private string eS03Field;

        private System.DateTime? eS04Field;

        private decimal? eS05Field;

        private byte iNHERITEDFROMITEMField;

        private byte iTEMSPECVALCHANGEDField;

        private string mEASUREUNITIDField;

        private decimal? nUMVALUEField;

        private string oRGIDField;

        private string sECTIONField;

        private string sITEIDField;

        private byte cONTINUOUSField;

        private decimal? eNDMEASUREField;

        private decimal? eNDOFFSETField;

        private decimal? eNDYOFFSETField;

        private string eNDYOFFSETREFField;

        private decimal? eNDZOFFSETField;

        private string eNDZOFFSETREFField;

        private string lINKEDTOATTRIBUTEField;

        private string lINKEDTOSECTIONField;

        private byte mANDATORYField;

        private decimal? sTARTMEASUREField;

        private decimal? sTARTOFFSETField;

        private decimal? sTARTYOFFSETField;

        private string sTARTYOFFSETREFField;

        private decimal? sTARTZOFFSETField;

        private string sTARTZOFFSETREFField;

        private string tABLEVALUEField;

        private string bASEMEASUREUNITIDField;

        private decimal? sTARTBASEMEASUREField;

        private decimal? eNDBASEMEASUREField;

        private string sTARTMEASUREUNITIDField;

        private string eNDMEASUREUNITIDField;

        private long? sTARTASSETFEATUREIDField;

        private long? eNDASSETFEATUREIDField;

        private string sTARTOFFSETUNITIDField;

        private string eNDOFFSETUNITIDField;

        private byte lINEARASSETSPECIDField;

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
        public long ASSETSPECID
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
        public long DISPLAYSEQUENCE
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
        public string ES01
        {
            get
            {
                return this.eS01Field;
            }
            set
            {
                this.eS01Field = value;
            }
        }

        /// <remarks/>
        public string ES02
        {
            get
            {
                return this.eS02Field;
            }
            set
            {
                this.eS02Field = value;
            }
        }

        /// <remarks/>
        public string ES03
        {
            get
            {
                return this.eS03Field;
            }
            set
            {
                this.eS03Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.DateTime? ES04
        {
            get
            {
                return this.eS04Field;
            }
            set
            {
                this.eS04Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? ES05
        {
            get
            {
                return this.eS05Field;
            }
            set
            {
                this.eS05Field = value;
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
        public string MEASUREUNITID
        {
            get
            {
                return this.mEASUREUNITIDField;
            }
            set
            {
                this.mEASUREUNITIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? NUMVALUE
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
        public string SECTION
        {
            get
            {
                return this.sECTIONField;
            }
            set
            {
                this.sECTIONField = value;
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? ENDOFFSET
        {
            get
            {
                return this.eNDOFFSETField;
            }
            set
            {
                this.eNDOFFSETField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? ENDYOFFSET
        {
            get
            {
                return this.eNDYOFFSETField;
            }
            set
            {
                this.eNDYOFFSETField = value;
            }
        }

        /// <remarks/>
        public string ENDYOFFSETREF
        {
            get
            {
                return this.eNDYOFFSETREFField;
            }
            set
            {
                this.eNDYOFFSETREFField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? ENDZOFFSET
        {
            get
            {
                return this.eNDZOFFSETField;
            }
            set
            {
                this.eNDZOFFSETField = value;
            }
        }

        /// <remarks/>
        public string ENDZOFFSETREF
        {
            get
            {
                return this.eNDZOFFSETREFField;
            }
            set
            {
                this.eNDZOFFSETREFField = value;
            }
        }

        /// <remarks/>
        public string LINKEDTOATTRIBUTE
        {
            get
            {
                return this.lINKEDTOATTRIBUTEField;
            }
            set
            {
                this.lINKEDTOATTRIBUTEField = value;
            }
        }

        /// <remarks/>
        public string LINKEDTOSECTION
        {
            get
            {
                return this.lINKEDTOSECTIONField;
            }
            set
            {
                this.lINKEDTOSECTIONField = value;
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? STARTOFFSET
        {
            get
            {
                return this.sTARTOFFSETField;
            }
            set
            {
                this.sTARTOFFSETField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? STARTYOFFSET
        {
            get
            {
                return this.sTARTYOFFSETField;
            }
            set
            {
                this.sTARTYOFFSETField = value;
            }
        }

        /// <remarks/>
        public string STARTYOFFSETREF
        {
            get
            {
                return this.sTARTYOFFSETREFField;
            }
            set
            {
                this.sTARTYOFFSETREFField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? STARTZOFFSET
        {
            get
            {
                return this.sTARTZOFFSETField;
            }
            set
            {
                this.sTARTZOFFSETField = value;
            }
        }

        /// <remarks/>
        public string STARTZOFFSETREF
        {
            get
            {
                return this.sTARTZOFFSETREFField;
            }
            set
            {
                this.sTARTZOFFSETREFField = value;
            }
        }

        /// <remarks/>
        public string TABLEVALUE
        {
            get
            {
                return this.tABLEVALUEField;
            }
            set
            {
                this.tABLEVALUEField = value;
            }
        }

        /// <remarks/>
        public string BASEMEASUREUNITID
        {
            get
            {
                return this.bASEMEASUREUNITIDField;
            }
            set
            {
                this.bASEMEASUREUNITIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? STARTBASEMEASURE
        {
            get
            {
                return this.sTARTBASEMEASUREField;
            }
            set
            {
                this.sTARTBASEMEASUREField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public decimal? ENDBASEMEASURE
        {
            get
            {
                return this.eNDBASEMEASUREField;
            }
            set
            {
                this.eNDBASEMEASUREField = value;
            }
        }

        /// <remarks/>
        public string STARTMEASUREUNITID
        {
            get
            {
                return this.sTARTMEASUREUNITIDField;
            }
            set
            {
                this.sTARTMEASUREUNITIDField = value;
            }
        }

        /// <remarks/>
        public string ENDMEASUREUNITID
        {
            get
            {
                return this.eNDMEASUREUNITIDField;
            }
            set
            {
                this.eNDMEASUREUNITIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? STARTASSETFEATUREID
        {
            get
            {
                return this.sTARTASSETFEATUREIDField;
            }
            set
            {
                this.sTARTASSETFEATUREIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public long? ENDASSETFEATUREID
        {
            get
            {
                return this.eNDASSETFEATUREIDField;
            }
            set
            {
                this.eNDASSETFEATUREIDField = value;
            }
        }

        /// <remarks/>
        public string STARTOFFSETUNITID
        {
            get
            {
                return this.sTARTOFFSETUNITIDField;
            }
            set
            {
                this.sTARTOFFSETUNITIDField = value;
            }
        }

        /// <remarks/>
        public string ENDOFFSETUNITID
        {
            get
            {
                return this.eNDOFFSETUNITIDField;
            }
            set
            {
                this.eNDOFFSETUNITIDField = value;
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

        private string rowstampField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rowstamp
        {
            get
            {
                return this.rowstampField;
            }
            set
            {
                this.rowstampField = value;
            }
        }

    }
}
