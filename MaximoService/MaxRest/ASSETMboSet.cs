using System;
using System.Collections.Generic;

namespace DCWaterMobile.MaximoService.MaxRest
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class ASSETMboSet
    {

        private ASSETMbo[] _assets;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ASSET")]
        public ASSETMbo[] Assets
        {
            get
            {
                return this._assets;
            }
            set
            {
                this._assets = value;
            }
        }
    }

}
