using System;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;

namespace DCWaterMobile.MaximoService.MaxRest
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ibm.com/maximo")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ibm.com/maximo", IsNullable = false)]
    public partial class WORKORDERMboSet
    {

        private WORKORDERMbo[] _workorders;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WORKORDER")]
        public WORKORDERMbo[] Workorders
        {
            get
            {
                return this._workorders;
            }
            set
            {
                this._workorders = value;
            }
        }
    }

}
