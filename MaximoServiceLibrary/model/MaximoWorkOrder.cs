using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace MaximoServiceLibrary.model
{
	public class MaximoWorkOrderForUpdate
	{
		public string remarkdesc { get; set; } 

		public List<MaximoWorkOrderSpec> workorderspec { get; set; }
		
		public List<MaximoWorkOrderFailureReport> failurereport { get; set; }


	}
	
	// MXWO
	public class MaximoWorkOrder : MaximoBaseEntity
	{
		public string href { get; set; }

		public MaximoAsset asset { get; set; }

        public List<MaximoWorkOrderSpec> workorderspec { get; set; }

        public MaximoWorkOrderFailureRemark failureRemark { get; set; }

        public List<MaximoWorkOrderFailureReport> failurereport { get; set; }
        
		public List<MaximoDocument> docs { get; set; }

		public List<MaximoLabTrans> labtrans { get; set; }

		public List<MaximoToolTrans> tooltrans { get; set; }

		public List<MaximoWorkOrder> followups { get; set; }

		[Newtonsoft.Json.JsonIgnore]
		public DateTime? startTimerDate { get; set; }

		[Newtonsoft.Json.JsonIgnore]
		public string timerImageUri { get; set; }

		[Newtonsoft.Json.JsonIgnore]
		[LiteDB.BsonIgnore]
		public BitmapImage timerImage { get
			{
				return new BitmapImage(new Uri(timerImageUri ?? "pack://application:,,,/CatchBasin;component/Resources/Images/stopWatch.png"));
			} }

		// auto-generated fields

		// Asset
		public string assetnum { get; set; } 

		// Changed Date
		public DateTime? changedate { get; set; } 

		// Customer's Name
		public string wolo4 { get; set; } 

		// Details
		public string description_longdescription { get; set; } 

		// Location
		public string location { get; set; } 

		// Scheduled Start
		public DateTime? schedstart { get; set; } 

		// History
		public bool historyflag { get; set; } 

		// Calculated Longitude (X)
		public double? calculatedx { get; set; } 

		// Calculated Latitude (Y)
		public double? calculatedy { get; set; } 

		// Scheduled Finish
		public DateTime? schedfinish { get; set; } 

		// Work Order
		public string wonum { get; set; } 

		// Class
		public string woclass { get; set; } 

		// Actual Start
		public DateTime? actstart { get; set; } 

		// Justification
		public string justification { get; set; } 

		// Customer's Phone #
		public string wolo2 { get; set; } 

		// Reported Date
		public DateTime? reportdate { get; set; } 

		// Reported By
		public string reportedby { get; set; } 

		// WORKORDERID
		public Int64 workorderid { get; set; } 

		// Organization
		public string orgid { get; set; } 

		// Description
		public string description { get; set; } 

		// CB Functional Worktypes
		public string wo1 { get; set; } 

		// Site
		public string siteid { get; set; } 

		// External Reference ID
		public string externalrefid { get; set; } 

		// Job Plan
		public string jpnum { get; set; } 

		// How Discovered
		public string wo11 { get; set; } 

		// Plumber Name
		public string plumbername { get; set; } 

		// Remark Date
		public DateTime? remarkenterdate { get; set; } 

		// Status Date
		public DateTime statusdate { get; set; } 

		// Status
		public string status { get; set; } 

		// CIS Number
		public string cisnum { get; set; } 

		// Other Contact
		public string othercontact { get; set; } 

		// Parent WO
		public string parent { get; set; } 

		// Priority
		public int? wopriority { get; set; } 

		// Zip
		public string customerzip { get; set; } 

		// WORKORDERSPECCLASS
		//public List<WORKORDERSPECCLASS>? workorderspec { get; set; } 

		// Payee Company
		public string othercompany { get; set; } 

		// Supervisor
		public string supervisor { get; set; } 

		// Location Details
		public string woeq3 { get; set; } 

		// Owner System ID
		public string ownersysid { get; set; } 

		// Problem Code
		public string problemcode { get; set; } 

		// Work Type
		public string worktype { get; set; } 

		// Has Status Changed
		public bool statusiface { get; set; } 

		// Sender System ID
		public string sendersysid { get; set; } 

		// Work Group
		public string persongroup { get; set; } 

		// State
		public string customerstate { get; set; } 

		// Failure Class
		public string failurecode { get; set; } 

		// Change Status Memo
		public string np_statusmemo { get; set; } 

		// E-mail
		public string customeremail { get; set; } 

		// Problem Code
		public string fr1code { get; set; } 

		// Originating Record Class
		public string origrecordclass { get; set; } 

		// Agency
		public string agencyid { get; set; } 

		// Plumber's License #
		public string plumberlicnum { get; set; } 

		// Location Details
		public string locationdetails { get; set; } 

		// Permitdate
		public DateTime? permitdate { get; set; } 

		// Actual Finish
		public DateTime? actfinish { get; set; } 

		// Receivedvia
		public string receivedvia { get; set; } 

		// Original Problem Type
		public string origproblemtype { get; set; } 

		// Class Structure
		public string classstructureid { get; set; } 

		// Changed By
		public string changeby { get; set; } 

		// DCW_WOSTATUS
		//public List<DCW_WOSTATUS>? wostatus { get; set; } 

		// Remarks
		public string remarkdesc { get; set; } 

		// Problem Code
		public string fr2code { get; set; } 

		// Alt. Phone # or Fax #
		public string altphonefax { get; set; } 

		// New Child Class
		public string newchildclass { get; set; } 

		// Originating Record
		public string origrecordid { get; set; } 

		// Description Long Description
		public string remarkdesc_longdescription { get; set; } 

		// Service
		public string service { get; set; } 

		// Streeet Address
		public string customerstreet { get; set; } 

		// City
		public string customercity { get; set; } 

	}
	
	// todo : control
	public class MaximoWorkOrderSpec : MaximoBaseEntity
	{
		public string _rowstamp { get; set; }
		public string assetattrid { get; set; }
		public string orgid { get; set; }
		public string classstructureid { get; set; }
		public int workorderspecid { get; set; }
		public string alnvalue { get; set; }
		public double? numvalue { get; set; }
		public string href { get; set; }
	}

	public class MaximoWorkOrderFailureRemark : MaximoBaseEntity
	{
		public int failureremarkid { get; set; }
		public DateTime enterdate { get; set; }
		public string orgid { get; set; }
		public string description { get; set; }
		public string siteid { get; set; }
		public string wonum { get; set; }
		public string langcode { get; set; }
		public bool hasld { get; set; }
	}

	public class MaximoWorkOrderFailureReport : MaximoBaseEntity
	{
		public int failurereportid { get; set; }
		public string _rowstamp { get; set; }
		public string failurecode { get; set; }
		public string type { get; set; }
		public string href { get; set; }
	}
	
}