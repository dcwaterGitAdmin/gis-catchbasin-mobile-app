using System;
using System.Collections.Generic;

namespace DCWaterMobile.LocalData.Models
{
    public partial class PERSON
    {
        public long ACCEPTINGWFMAIL { get; set; }
        public string ADDRESSLINE1 { get; set; }
        public string ADDRESSLINE2 { get; set; }
        public string ADDRESSLINE3 { get; set; }
        public string BILLTOADDRESS { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public string CITY { get; set; }
        public string COUNTRY { get; set; }
        public string COUNTY { get; set; }
        public string DELEGATE { get; set; }
        public Nullable<System.DateTime> DELEGATEFROMDATE { get; set; }
        public Nullable<System.DateTime> DELEGATETODATE { get; set; }
        public string DEPARTMENT { get; set; }
        public string DISPLAYNAME { get; set; }
        public string DROPPOINT { get; set; }
        public string EMPLOYEETYPE { get; set; }
        public string EXTERNALREFID { get; set; }
        public string FIRSTNAME { get; set; }
        public long HASLD { get; set; }
        public Nullable<System.DateTime> HIREDATE { get; set; }
        public string JOBCODE { get; set; }
        public string LANGCODE { get; set; }
        public string LANGUAGE { get; set; }
        public Nullable<System.DateTime> LASTEVALDATE { get; set; }
        public string LASTNAME { get; set; }
        public string LOCALE { get; set; }
        public string LOCATION { get; set; }
        public string LOCATIONORG { get; set; }
        public string LOCATIONSITE { get; set; }
        public long LOCTOSERVREQ { get; set; }
        public Nullable<System.DateTime> NEXTEVALDATE { get; set; }
        public string OWNERSYSID { get; set; }
        public string PCARDEXPDATE { get; set; }
        public string PCARDNUM { get; set; }
        public string PCARDTYPE { get; set; }
        public string PCARDVERIFICATION { get; set; }
        public string PERSONID { get; set; }
        public long PERSONUID { get; set; }
        public string POSTALCODE { get; set; }
        public string REGIONDISTRICT { get; set; }
        public string SENDERSYSID { get; set; }
        public string SHIPTOADDRESS { get; set; }
        public string SOURCESYSID { get; set; }
        public string STATEPROVINCE { get; set; }
        public string STATUS { get; set; }
        public System.DateTime STATUSDATE { get; set; }
        public string SUPERVISOR { get; set; }
        public Nullable<System.DateTime> TERMINATIONDATE { get; set; }
        public string TIMEZONE { get; set; }
        public string TITLE { get; set; }
        public string TRANSEMAILELECTION { get; set; }
        public Nullable<long> VIP { get; set; }
        public string WFMAILELECTION { get; set; }
        public Nullable<long> WOPRIORITY { get; set; }
        public string ROWSTAMP { get; set; }
        public string PRIMARYSMS { get; set; }
        public string OWNERGROUP { get; set; }
        public string IM_ID { get; set; }
        public string CALTYPE { get; set; }
        public string DFLTAPP { get; set; }
        public Nullable<long> DEVICECLASS { get; set; }
    }
}
