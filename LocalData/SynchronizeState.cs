using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DCWaterMobile.LocalData
{
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class SynchronizeState
    {

        private SynchronizeStateLastMaximoUpload _lastMaximoUploadField;

        private SynchronizeStateLastMaximoDownload _lastMaximoDownloadField;

        private SynchronizeStateLastMaximoReferenceDownload _lastMaximoReferenceDownloadField;

        private SynchronizeStateLastMaximoFailureListUpdate _lastMaximoFailureListUpdateField;

        private SynchronizeStateLastGISUpload _lastGISUploadField;

        private SynchronizeStateLastGISDownload _lastGISDownloadField;

        private SynchronizeStateLastGISBackgroundDynamicDownload _lastGISBackgroundDynamicDownloadField;

        private SynchronizeStateMaximumGISBackgroundPackageAge _maximumGISBackgroundPackageAgeField;

        private SynchronizeStateMaximumGISBackgroundDynamicAge _maximumGISBackgroundDynamicAgeField;

        private SynchronizeStateMaximumMaximoReferenceAge _maximumMaximoReferenceAgeField;

        private SynchronizeStateMaximumMaximoFailureListAge _maximumMaximoFailureListAgeField;

        private SynchronizeStateMaximumMaximoOperationalAge _maximumMaximoOperationalAgeField;

        private SynchronizeStateMaximumGISOperationalAge _maximumGISOperationalAgeField;

        private DateTime _lastShownStatusTimeField;

        /// <remarks/>
        public SynchronizeStateLastMaximoUpload LastMaximoUpload
        {
            get
            {
                return this._lastMaximoUploadField;
            }
            set
            {
                this._lastMaximoUploadField = value;
            }
        }

        /// <remarks/>
        public SynchronizeStateLastMaximoDownload LastMaximoDownload
        {
            get
            {
                return this._lastMaximoDownloadField;
            }
            set
            {
                this._lastMaximoDownloadField = value;
            }
        }

        /// <remarks/>
        public SynchronizeStateLastMaximoReferenceDownload LastMaximoReferenceDownload
        {
            get
            {
                return this._lastMaximoReferenceDownloadField;
            }
            set
            {
                this._lastMaximoReferenceDownloadField = value;
            }
        }

        /// <remarks/>
        public SynchronizeStateLastMaximoFailureListUpdate LastMaximoFailureListUpdate
        {
            get
            {
                return this._lastMaximoFailureListUpdateField;
            }
            set
            {
                this._lastMaximoFailureListUpdateField = value;
            }
        }

        /// <remarks/>
        public SynchronizeStateLastGISUpload LastGISUpload
        {
            get
            {
                return this._lastGISUploadField;
            }
            set
            {
                this._lastGISUploadField = value;
            }
        }

        /// <remarks/>
        public SynchronizeStateLastGISDownload LastGISDownload
        {
            get
            {
                return this._lastGISDownloadField;
            }
            set
            {
                this._lastGISDownloadField = value;
            }
        }
        /// <remarks/>

        public SynchronizeStateLastGISBackgroundDynamicDownload LastGISBackgroundDynamicDownload
        {
            get
            {
                return this._lastGISBackgroundDynamicDownloadField;
            }
            set
            {
                this._lastGISBackgroundDynamicDownloadField = value;
            }
        }

        /// <remarks/>
        public SynchronizeStateMaximumGISBackgroundPackageAge MaximumGISBackgroundPackageAge
        {
            get
            {
                return this._maximumGISBackgroundPackageAgeField;
            }
            set
            {
                this._maximumGISBackgroundPackageAgeField = value;
            }
        }
        public SynchronizeStateMaximumGISBackgroundDynamicAge MaximumGISBackgroundDynamicAge
        {
            get
            {
                return this._maximumGISBackgroundDynamicAgeField;
            }
            set
            {
                this._maximumGISBackgroundDynamicAgeField = value;
            }
        }
        public SynchronizeStateMaximumMaximoReferenceAge MaximumMaximoReferenceAge
        {
            get
            {
                return this._maximumMaximoReferenceAgeField;
            }
            set
            {
                this._maximumMaximoReferenceAgeField = value;
            }
        }
        public SynchronizeStateMaximumMaximoFailureListAge MaximumMaximoFailureListAge
        {
            get
            {
                return this._maximumMaximoFailureListAgeField;
            }
            set
            {
                this._maximumMaximoFailureListAgeField = value;
            }
        }

        public SynchronizeStateMaximumMaximoOperationalAge MaximumMaximoOperationalAge
        {
            get
            {
                return this._maximumMaximoOperationalAgeField;
            }
            set
            {
                this._maximumMaximoOperationalAgeField = value;
            }
        }
        public SynchronizeStateMaximumGISOperationalAge MaximumGISOperationalAge
        {
            get
            {
                return this._maximumGISOperationalAgeField;
            }
            set
            {
                this._maximumGISOperationalAgeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timeString
        {
            get
            {
                return this._lastShownStatusTimeField.Ticks.ToString();
            }
            set
            {
                this._lastShownStatusTimeField = new DateTime(long.Parse(value));
            }
        }
        [XmlIgnore]
        public DateTime LastShownStatusTime
        {
            get
            {
                return this._lastShownStatusTimeField;
            }
            set
            {
                this._lastShownStatusTimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateLastMaximoUpload
    {

        private object _errorsField;

        private DateTime _timeField;

        /// <remarks/>
        public object Errors
        {
            get
            {
                return this._errorsField;
            }
            set
            {
                this._errorsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timeString
        {
            get
            {
                return this._timeField.Ticks.ToString();
            }
            set
            {
                this._timeField = new DateTime(long.Parse(value));
            }
        }
        [XmlIgnore]
        public DateTime time
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateLastMaximoDownload
    {

        private object _errorsField;

        private DateTime _timeField;

        /// <remarks/>
        public object Errors
        {
            get
            {
                return this._errorsField;
            }
            set
            {
                this._errorsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timeString
        {
            get
            {
                return this._timeField.Ticks.ToString();
            }
            set
            {
                this._timeField = new DateTime(long.Parse(value));
            }
        }
        [XmlIgnore]
        public DateTime time
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateLastMaximoReferenceDownload
    {

        private object _errorsField;

        private DateTime _timeField;

        /// <remarks/>
        public object Errors
        {
            get
            {
                return this._errorsField;
            }
            set
            {
                this._errorsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timeString
        {
            get
            {
                return this._timeField.Ticks.ToString();
            }
            set
            {
                this._timeField = new DateTime(long.Parse(value));
            }
        }
        [XmlIgnore]
        public DateTime time
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateLastMaximoFailureListUpdate
    {

        private DateTime _timeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timeString
        {
            get
            {
                return this._timeField.Ticks.ToString();
            }
            set
            {
                this._timeField = new DateTime(long.Parse(value));
            }
        }
        [XmlIgnore]
        public DateTime time
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateLastGISUpload
    {

        private object _errorsField;

        private DateTime _timeField;

        /// <remarks/>
        public object Errors
        {
            get
            {
                return this._errorsField;
            }
            set
            {
                this._errorsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timeString
        {
            get
            {
                return this._timeField.Ticks.ToString();
            }
            set
            {
                this._timeField = new DateTime(long.Parse(value));
            }
        }
        [XmlIgnore]
        public DateTime time
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateLastGISDownload
    {

        private object _errorsField;

        private DateTime _timeField;

        /// <remarks/>
        public object Errors
        {
            get
            {
                return this._errorsField;
            }
            set
            {
                this._errorsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timeString
        {
            get
            {
                return this._timeField.Ticks.ToString();
            }
            set
            {
                this._timeField = new DateTime(long.Parse(value));
            }
        }
        [XmlIgnore]
        public DateTime time
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateLastGISBackgroundDynamicDownload
    {

        private object _errorsField;

        private DateTime _timeField;

        /// <remarks/>
        public object Errors
        {
            get
            {
                return this._errorsField;
            }
            set
            {
                this._errorsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string timeString
        {
            get
            {
                return this._timeField.Ticks.ToString();
            }
            set
            {
                this._timeField = new DateTime(long.Parse(value));
            }
        }
        [XmlIgnore]
        public DateTime time
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateMaximumGISBackgroundPackageAge
    {

        private TimeSpan _timeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("timeSpan")]
        public string timeSpanString
        {
            get { return _timeField.ToString(); }
            set { _timeField = TimeSpan.Parse(value); }
        }
        [XmlIgnore]
        public TimeSpan timeSpan
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateMaximumGISBackgroundDynamicAge
    {

        private TimeSpan _timeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("timeSpan")]
        public string timeSpanString
        {
            get { return _timeField.ToString(); }
            set { _timeField = TimeSpan.Parse(value); }
        }
        [XmlIgnore]
        public TimeSpan timeSpan
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateMaximumMaximoReferenceAge
    {

        private TimeSpan _timeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("timeSpan")]
        public string timeSpanString
        {
            get { return _timeField.ToString(); }
            set { _timeField = TimeSpan.Parse(value); }
        }
        [XmlIgnore]
        public TimeSpan timeSpan
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateMaximumMaximoFailureListAge
    {

        private TimeSpan _timeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("timeSpan")]
        public string timeSpanString
        {
            get { return _timeField.ToString(); }
            set { _timeField = TimeSpan.Parse(value); }
        }
        [XmlIgnore]
        public TimeSpan timeSpan
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateMaximumMaximoOperationalAge
    {

        private TimeSpan _timeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("timeSpan")]
        public string timeSpanString
        {
            get { return _timeField.ToString(); }
            set { _timeField = TimeSpan.Parse(value); }
        }
        [XmlIgnore]
        public TimeSpan timeSpan
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class SynchronizeStateMaximumGISOperationalAge
    {

        private TimeSpan _timeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("timeSpan")]
        public string timeSpanString
        {
            get { return _timeField.ToString(); }
            set { _timeField = TimeSpan.Parse(value); }
        }
        [XmlIgnore]
        public TimeSpan timeSpan
        {
            get
            {
                return this._timeField;
            }
            set
            {
                this._timeField = value;
            }
        }
    }


}
