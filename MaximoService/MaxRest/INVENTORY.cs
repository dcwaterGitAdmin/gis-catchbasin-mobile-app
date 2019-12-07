using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCWaterMobile.MaximoService.MaxRest
{
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
        public partial class INVENTORYMboSet
        {

            private INVENTORYMboSetINVENTORY[] iNVENTORYField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("INVENTORY")]
            public INVENTORYMboSetINVENTORY[] INVENTORY
            {
                get
                {
                    return this.iNVENTORYField;
                }
                set
                {
                    this.iNVENTORYField = value;
                }
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
        public partial class INVENTORYMboSetINVENTORY
        {

            private decimal? sTDCOSTField;

            private decimal? aVGCOSTField;

            private decimal? lASTCOSTField;

            private string aDDTOSTORELOCField;

            private decimal aVBLBALANCEField;

            private bool aVBLBALANCEFieldSpecified;

            private string cONDITIONCODEField;

            private decimal? cONDRATEField;

            private decimal cURBALField;

            private bool cURBALFieldSpecified;

            private decimal cURBALTOTALField;

            private bool cURBALTOTALFieldSpecified;

            private decimal eXPIREDQTYField;

            private bool eXPIREDQTYFieldSpecified;

            private decimal hOLDINGBALField;

            private bool hOLDINGBALFieldSpecified;

            private string lOTNUMField;

            private System.DateTime? pHYSCNTDATEField;

            private decimal rESERVEDQTYField;

            private bool rESERVEDQTYFieldSpecified;

            private string iTEMTYPEField;

            private string nP_STATUSMEMOField;

            private byte sTATUSIFACEField;

            private bool sTATUSIFACEFieldSpecified;

            private decimal pHYSCNTTOTALField;

            private bool pHYSCNTTOTALFieldSpecified;

            private string iTEMNUMField;

            private string lOCATIONField;

            private string bINNUMField;

            private string vENDORField;

            private string mANUFACTURERField;

            private string mODELNUMField;

            private string cATALOGCODEField;

            private decimal mINLEVELField;

            private decimal mAXLEVELField;

            private INVENTORYMboSetINVENTORYCATEGORY cATEGORYField;

            private string oRDERUNITField;

            private string iSSUEUNITField;

            private decimal oRDERQTYField;

            private System.DateTime? lASTISSUEDATEField;

            private decimal iSSUEYTDField;

            private decimal iSSUE1YRAGOField;

            private decimal iSSUE2YRAGOField;

            private decimal iSSUE3YRAGOField;

            private string aBCTYPEField;

            private int cCFField;

            private decimal? sSTOCKField;

            private int dELIVERYTIMEField;

            private string iL1Field;

            private string iL2Field;

            private string iL3Field;

            private INVENTORYMboSetINVENTORYGLACCOUNT gLACCOUNTField;

            private INVENTORYMboSetINVENTORYGLACCOUNT cONTROLACCField;

            private INVENTORYMboSetINVENTORYGLACCOUNT sHRINKAGEACCField;

            private INVENTORYMboSetINVENTORYGLACCOUNT iNVCOSTADJACCField;

            private string sOURCESYSIDField;

            private string oWNERSYSIDField;

            private string eXTERNALREFIDField;

            private string sENDERSYSIDField;

            private string oRGIDField;

            private string sITEIDField;

            private byte iNTERNALField;

            private int iNVENTORYIDField;

            private string iTEMSETIDField;

            private string sTORELOCField;

            private string sTORELOCSITEIDField;

            private string sTATUSField;

            private System.DateTime sTATUSDATEField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public decimal? STDCOST
            {
                get
                {
                    return this.sTDCOSTField;
                }
                set
                {
                    this.sTDCOSTField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public decimal? AVGCOST
            {
                get
                {
                    return this.aVGCOSTField;
                }
                set
                {
                    this.aVGCOSTField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public decimal? LASTCOST
            {
                get
                {
                    return this.lASTCOSTField;
                }
                set
                {
                    this.lASTCOSTField = value;
                }
            }

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
            public decimal AVBLBALANCE
            {
                get
                {
                    return this.aVBLBALANCEField;
                }
                set
                {
                    this.aVBLBALANCEField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool AVBLBALANCESpecified
            {
                get
                {
                    return this.aVBLBALANCEFieldSpecified;
                }
                set
                {
                    this.aVBLBALANCEFieldSpecified = value;
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
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public decimal? CONDRATE
            {
                get
                {
                    return this.cONDRATEField;
                }
                set
                {
                    this.cONDRATEField = value;
                }
            }

            /// <remarks/>
            public decimal CURBAL
            {
                get
                {
                    return this.cURBALField;
                }
                set
                {
                    this.cURBALField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool CURBALSpecified
            {
                get
                {
                    return this.cURBALFieldSpecified;
                }
                set
                {
                    this.cURBALFieldSpecified = value;
                }
            }

            /// <remarks/>
            public decimal CURBALTOTAL
            {
                get
                {
                    return this.cURBALTOTALField;
                }
                set
                {
                    this.cURBALTOTALField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool CURBALTOTALSpecified
            {
                get
                {
                    return this.cURBALTOTALFieldSpecified;
                }
                set
                {
                    this.cURBALTOTALFieldSpecified = value;
                }
            }

            /// <remarks/>
            public decimal EXPIREDQTY
            {
                get
                {
                    return this.eXPIREDQTYField;
                }
                set
                {
                    this.eXPIREDQTYField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool EXPIREDQTYSpecified
            {
                get
                {
                    return this.eXPIREDQTYFieldSpecified;
                }
                set
                {
                    this.eXPIREDQTYFieldSpecified = value;
                }
            }

            /// <remarks/>
            public decimal HOLDINGBAL
            {
                get
                {
                    return this.hOLDINGBALField;
                }
                set
                {
                    this.hOLDINGBALField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool HOLDINGBALSpecified
            {
                get
                {
                    return this.hOLDINGBALFieldSpecified;
                }
                set
                {
                    this.hOLDINGBALFieldSpecified = value;
                }
            }

            /// <remarks/>
            public string LOTNUM
            {
                get
                {
                    return this.lOTNUMField;
                }
                set
                {
                    this.lOTNUMField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.DateTime? PHYSCNTDATE
            {
                get
                {
                    return this.pHYSCNTDATEField;
                }
                set
                {
                    this.pHYSCNTDATEField = value;
                }
            }

            /// <remarks/>
            public decimal RESERVEDQTY
            {
                get
                {
                    return this.rESERVEDQTYField;
                }
                set
                {
                    this.rESERVEDQTYField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool RESERVEDQTYSpecified
            {
                get
                {
                    return this.rESERVEDQTYFieldSpecified;
                }
                set
                {
                    this.rESERVEDQTYFieldSpecified = value;
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
            public decimal PHYSCNTTOTAL
            {
                get
                {
                    return this.pHYSCNTTOTALField;
                }
                set
                {
                    this.pHYSCNTTOTALField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool PHYSCNTTOTALSpecified
            {
                get
                {
                    return this.pHYSCNTTOTALFieldSpecified;
                }
                set
                {
                    this.pHYSCNTTOTALFieldSpecified = value;
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
            public string MODELNUM
            {
                get
                {
                    return this.mODELNUMField;
                }
                set
                {
                    this.mODELNUMField = value;
                }
            }

            /// <remarks/>
            public string CATALOGCODE
            {
                get
                {
                    return this.cATALOGCODEField;
                }
                set
                {
                    this.cATALOGCODEField = value;
                }
            }

            /// <remarks/>
            public decimal MINLEVEL
            {
                get
                {
                    return this.mINLEVELField;
                }
                set
                {
                    this.mINLEVELField = value;
                }
            }

            /// <remarks/>
            public decimal MAXLEVEL
            {
                get
                {
                    return this.mAXLEVELField;
                }
                set
                {
                    this.mAXLEVELField = value;
                }
            }

            /// <remarks/>
            public INVENTORYMboSetINVENTORYCATEGORY CATEGORY
            {
                get
                {
                    return this.cATEGORYField;
                }
                set
                {
                    this.cATEGORYField = value;
                }
            }

            /// <remarks/>
            public string ORDERUNIT
            {
                get
                {
                    return this.oRDERUNITField;
                }
                set
                {
                    this.oRDERUNITField = value;
                }
            }

            /// <remarks/>
            public string ISSUEUNIT
            {
                get
                {
                    return this.iSSUEUNITField;
                }
                set
                {
                    this.iSSUEUNITField = value;
                }
            }

            /// <remarks/>
            public decimal ORDERQTY
            {
                get
                {
                    return this.oRDERQTYField;
                }
                set
                {
                    this.oRDERQTYField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public System.DateTime? LASTISSUEDATE
            {
                get
                {
                    return this.lASTISSUEDATEField;
                }
                set
                {
                    this.lASTISSUEDATEField = value;
                }
            }

            /// <remarks/>
            public decimal ISSUEYTD
            {
                get
                {
                    return this.iSSUEYTDField;
                }
                set
                {
                    this.iSSUEYTDField = value;
                }
            }

            /// <remarks/>
            public decimal ISSUE1YRAGO
            {
                get
                {
                    return this.iSSUE1YRAGOField;
                }
                set
                {
                    this.iSSUE1YRAGOField = value;
                }
            }

            /// <remarks/>
            public decimal ISSUE2YRAGO
            {
                get
                {
                    return this.iSSUE2YRAGOField;
                }
                set
                {
                    this.iSSUE2YRAGOField = value;
                }
            }

            /// <remarks/>
            public decimal ISSUE3YRAGO
            {
                get
                {
                    return this.iSSUE3YRAGOField;
                }
                set
                {
                    this.iSSUE3YRAGOField = value;
                }
            }

            /// <remarks/>
            public string ABCTYPE
            {
                get
                {
                    return this.aBCTYPEField;
                }
                set
                {
                    this.aBCTYPEField = value;
                }
            }

            /// <remarks/>
            public int CCF
            {
                get
                {
                    return this.cCFField;
                }
                set
                {
                    this.cCFField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
            public decimal? SSTOCK
            {
                get
                {
                    return this.sSTOCKField;
                }
                set
                {
                    this.sSTOCKField = value;
                }
            }

            /// <remarks/>
            public int DELIVERYTIME
            {
                get
                {
                    return this.dELIVERYTIMEField;
                }
                set
                {
                    this.dELIVERYTIMEField = value;
                }
            }

            /// <remarks/>
            public string IL1
            {
                get
                {
                    return this.iL1Field;
                }
                set
                {
                    this.iL1Field = value;
                }
            }

            /// <remarks/>
            public string IL2
            {
                get
                {
                    return this.iL2Field;
                }
                set
                {
                    this.iL2Field = value;
                }
            }

            /// <remarks/>
            public string IL3
            {
                get
                {
                    return this.iL3Field;
                }
                set
                {
                    this.iL3Field = value;
                }
            }

            /// <remarks/>
            public INVENTORYMboSetINVENTORYGLACCOUNT GLACCOUNT
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
            public INVENTORYMboSetINVENTORYGLACCOUNT CONTROLACC
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
            public INVENTORYMboSetINVENTORYGLACCOUNT SHRINKAGEACC
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
            public INVENTORYMboSetINVENTORYGLACCOUNT INVCOSTADJACC
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
            public byte INTERNAL
            {
                get
                {
                    return this.iNTERNALField;
                }
                set
                {
                    this.iNTERNALField = value;
                }
            }

            /// <remarks/>
            public int INVENTORYID
            {
                get
                {
                    return this.iNVENTORYIDField;
                }
                set
                {
                    this.iNVENTORYIDField = value;
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
            public string STORELOC
            {
                get
                {
                    return this.sTORELOCField;
                }
                set
                {
                    this.sTORELOCField = value;
                }
            }

            /// <remarks/>
            public string STORELOCSITEID
            {
                get
                {
                    return this.sTORELOCSITEIDField;
                }
                set
                {
                    this.sTORELOCSITEIDField = value;
                }
            }

            /// <remarks/>
            public string STATUS
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
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
        public partial class INVENTORYMboSetINVENTORYCATEGORY
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
        public partial class INVENTORYMboSetINVENTORYGLACCOUNT
        {

            private string vALUEField;

            private INVENTORYMboSetINVENTORYGLACCOUNTGLCOMP[] gLCOMPField;

            /// <remarks/>
            public string VALUE
            {
                get { return this.vALUEField; }
                set { this.vALUEField = value; }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("GLCOMP")]
            public INVENTORYMboSetINVENTORYGLACCOUNTGLCOMP[] GLCOMP
            {
                get { return this.gLCOMPField; }
                set { this.gLCOMPField = value; }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
            public partial class INVENTORYMboSetINVENTORYGLACCOUNTGLCOMP
            {

                private byte glorderField;

                private string valueField;

                /// <remarks/>
                [System.Xml.Serialization.XmlAttributeAttribute()]
                public byte glorder
                {
                    get { return this.glorderField; }
                    set { this.glorderField = value; }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlTextAttribute()]
                public string Value
                {
                    get { return this.valueField; }
                    set { this.valueField = value; }
                }
            }
        }
}
