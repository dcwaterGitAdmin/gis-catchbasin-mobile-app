using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCWaterMobile.MaximoService.MaxRest
{
        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
        public partial class CreateDCW_CBWOResponse
        {

            private DCW_CBWOSet dCW_CBWOSetField;

            private System.DateTime creationDateTimeField;

            private string transLanguageField;

            private string baseLanguageField;

            private ulong messageIDField;

            private string maximoVersionField;

            /// <remarks/>
            public DCW_CBWOSet DCW_CBWOSet
            {
                get
                {
                    return this.dCW_CBWOSetField;
                }
                set
                {
                    this.dCW_CBWOSetField = value;
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


}
