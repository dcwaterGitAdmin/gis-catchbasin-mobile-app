using System;
using System.Collections.Generic;
using LocalDBLibrary.model;

namespace MaximoServiceLibrary.model
{
	public class MaximoBaseEntity : BasePersistenceEntity
	{
		// _rowstamp
		public string _rowstamp { get; set; }

		// _rowstamp
		public string href { get; set; }

        //localref
        public string localref { get; set; }
    }

	/**
	 * this class combines relevant data for a specific user, like the current selected crew id, etc.
	 */
	public class UserPreferences
	{

		public string selectedPersonGroup { get; set; }

		public DateTime lastSyncTime { get; set; }

	}

	public class MaximoUser : MaximoBaseEntity
	{
		public UserPreferences userPreferences { get; set; }
		
		public List<MaximoPersonGroup> personGroupList { get; set; }
		
		public string userName { get; set; }
		
		public string password { get; set; }

		public string baseCurrency { get; set; }
		public string loginUserName { get; set; }
		public string defaultOrg { get; set; }
		public string defaultSite { get; set; }
		public string personId { get; set; }
		public string insertOrg { get; set; }
		public string loginID { get; set; }
		public string defaultLanguage { get; set; }
		public string calendarType { get; set; }
		public string baseLang { get; set; }
		public string email { get; set; }
		public string baseCalendar { get; set; }
		public string insertSite { get; set; }
		public string displayName { get; set; }

		public void mergeFrom(MaximoUser source)
		{
			// TODO - merge fields from source object to this object...
			this.displayName = source.displayName;
		}
	}

	public class MaximoPersonGroup : MaximoBaseEntity
	{
		public double persongroupid { get; set; }
		public string persongroup { get; set; }
		public string description { get; set; }
		public string vehiclenum { get; set; }
		public bool iscrewworkgroup { get; set; }
	}

	public class MaximoPersonGroupMember
	{
		public List<MaximoPersonGroup> member { get; set; }
	}
	
	
	// MXDOMAIN
	public class MaximoDomain : MaximoBaseEntity
	{

		// Scale
		public int scale { get; set; } 

		// SYNONYMDOMAIN
		public List<SYNONYMDOMAIN> synonymdomain { get; set; } 

		// Domain
		public string domainid { get; set; } 

		// ALNDOMAINVALUE
		public List<ALNDOMAINVALUE> alndomain { get; set; } 

		// Domain Type
		public string domaintype { get; set; } 

		// MAXDOMAINID
		public Int64 maxdomainid { get; set; } 

		// Description
		public string description { get; set; } 

		// NUMDOMAINVALUE
		public List<NUMDOMAINVALUE> numericdomain { get; set; } 

		// MAXDOMVALCOND
		public List<MAXDOMVALCOND> maxdomvalcond { get; set; } 

		// Length
		public int length { get; set; } 

		// Data Type
		public string maxtype { get; set; } 

		// Disable Caching
		public bool nevercache { get; set; } 

		// MAXTABLEDOMAIN
		public List<MAXTABLEDOMAIN> maxtabledomain { get; set; } 

		// Is Internal
		//public int internal { get; set; } 
		// todo: internal is reserved word
	}

	// MXDOMAIN
	public class MAXTABLEDOMAIN : MaximoBaseEntity
	{

		// Object
		public string objectname { get; set; } 

		// Error Message Key
		public string erroraccesskey { get; set; } 

		// Error Message Group
		public string errorresourcbundle { get; set; } 

		// Organization
		public string orgid { get; set; } 

		// CROSSOVERDOMAIN
		public List<CROSSOVERDOMAIN> crossoverdomain { get; set; } 

		// MAXTABLEDOMAINID
		public Int64 maxtabledomainid { get; set; } 

		// Validation Where Clause
		public string validtnwhereclause { get; set; } 

		// Site
		public string siteid { get; set; } 

		// List Where Clause
		public string listwhereclause { get; set; } 
	}

	// MXDOMAIN
	public class MAXDOMVALCOND : MaximoBaseEntity
	{

		// Object Name
		public string objectname { get; set; } 

		// Value ID
		public string valueid { get; set; } 

		// Unique Id
		public Int64 maxdomvalcondid { get; set; } 

		// Condition Number
		public string conditionnum { get; set; } 
	}

	// MXDOMAIN
	public class NUMDOMAINVALUE : MaximoBaseEntity
	{

		// Value ID
		public string valueid { get; set; } 

		// Organization
		public string orgid { get; set; } 

		// Description
		public string description { get; set; } 

		// NUMERICDOMAINID
		public Int64 numericdomainid { get; set; } 

		// Value
		public double value { get; set; } 

		// Site
		public string siteid { get; set; } 
	}

	
	// MXDOMAIN
	public class ALNDOMAINVALUE : MaximoBaseEntity
	{

		// Value ID
		public string valueid { get; set; } 

		// Organization
		public string orgid { get; set; } 

		// ALNDOMAINID
		public Int64 alndomainid { get; set; } 

		// Description
		public string description { get; set; } 

		// Value
		public string value { get; set; } 

		// Site
		public string siteid { get; set; } 
	}

	// MXDOMAIN
	public class SYNONYMDOMAIN : MaximoBaseEntity
	{

		// Default
		public bool defaults { get; set; } 

		// Value ID
		public string valueid { get; set; } 

		// Organization
		public string orgid { get; set; } 

		// Description
		public string description { get; set; } 

		// Internal Value
		public string maxvalue { get; set; } 

		// Value
		public string value { get; set; } 

		// SYNONYMDOMAINID
		public Int64 synonymdomainid { get; set; } 

		// Site
		public string siteid { get; set; } 
	}

    // MXDOMAIN
    public class CROSSOVERDOMAIN : MaximoBaseEntity
    {

        // Destination Field
        public string destfield { get; set; }

        // Condition on Destination
        public string destcondition { get; set; }

        // Condition on Source
        public string sourcecondition { get; set; }

        // Accept NULL value
        public bool copyevenifsrcnull { get; set; }

        // Sequence
        public int sequence { get; set; }

        // No Overwrite
        public bool copyonlyifdestnull { get; set; }

        // CROSSOVERDOMAINID
        public Int64 crossoverdomainid { get; set; }

        // Source Field
        public string sourcefield { get; set; }
    }

	// MXOPERLOC
	public class MaximoLocation : MaximoBaseEntity
	{

		// Old GL Control Account
		public string oldcontrolacc { get; set; } 

		// Changed Date
		public DateTime changedate { get; set; } 

		// Ship to Address
		public string shiptoaddresscode { get; set; } 

		// Old Shrinkage Account
		public string oldshrinkageacc { get; set; } 

		// Is GIS
		public bool plussisgis { get; set; } 

		// Details
		public string description_longdescription { get; set; } 

		// Location
		public string location { get; set; } 

		// Bill to Address
		public string billtoaddresscode { get; set; } 

		// Currency Variance Account
		public string curvaracc { get; set; } 

		// Type
		public string type { get; set; } 

		// GL Control Account
		public string controlacc { get; set; } 

		// Automatically Generate Work Orders
		public bool autowogen { get; set; } 

		// Organization
		public string orgid { get; set; } 

		// Inventory Owner
		public string invowner { get; set; } 

		// Description
		public string description { get; set; } 

		// Next Calibration Due Date
		public DateTime? pluscduedate { get; set; } 

		// Item
		public string itemnum { get; set; } 

		// Site
		public string siteid { get; set; } 

		// Premise Status
		public string premisestatus { get; set; } 

		// Service Address
		public string plussaddresscode { get; set; } 

		// Matl. Mgmt Controlled
		public bool dcw_matlmgmtctrld { get; set; } 

		// External Reference ID
		public string externalrefid { get; set; } 

		// Loop Calibration
		public bool pluscloop { get; set; } 

		// Cost Adjustment Account
		public string invcostadjacc { get; set; } 

		// LOCATIONSID
		public Int64 locationsid { get; set; } 

		// Status Date
		public DateTime statusdate { get; set; } 

		// Status
		public string status { get; set; } 

		// Shift
		public string shiftnum { get; set; } 

		// Receipt Variance Account
		public string receiptvaracc { get; set; } 

		// Location
		public string parent { get; set; } 

		// LOCATIONUSERCUST
		//public List<LOCATIONUSERCUST>? locationusercust { get; set; } 

		// Customer #
		public string customernum { get; set; } 

		// LOCATIONSSPECCLASS
		//public List<LOCATIONSSPECCLASS>? locationspec { get; set; } 

		// Old Invoice Cost Adjustment Account
		public string oldinvcostadjacc { get; set; } 

		// Use in PO/PR
		public bool useinpopr { get; set; } 

		// Owner System ID
		public string ownersysid { get; set; } 

		// Has Parent
		public bool hasparent { get; set; } 

		// Has Status Changed
		public bool statusiface { get; set; } 

		// Internal Labor Account
		public string intlabrec { get; set; } 

		// Service Address
		public string saddresscode { get; set; } 

		// Due Date Extended
		public bool pluscpmextdate { get; set; } 

		// Sender System ID
		public string sendersysid { get; set; } 

		// Account #
		public string accountnum { get; set; } 

		// Priority
		public int? locpriority { get; set; } 

		// CLASSSTRUCTURE.HIERARCHYPATH
		public string hierarchypath { get; set; } 

		// Children
		public bool children { get; set; } 

		// Meter Group
		public string groupname { get; set; } 

		// Failure Class
		public string failurecode { get; set; } 

		// LOCATIONOPSKD
		//public List<LOCATIONOPSKD>? locationopskd { get; set; } 

		// Purchase Variance Account
		public string purchvaracc { get; set; } 

		// Has Children
		public bool haschildren { get; set; } 

		// Item Set
		public string itemsetid { get; set; } 

		// Invoice Variance Account
		public string invoicevaracc { get; set; } 

		// INT_LOCATIONMETER
		//public List<INT_LOCATIONMETER>? locationmeter { get; set; } 

		// Is a Repair Facility
		public bool isrepairfacility { get; set; } 

		// GIS Parameter 3
		public string gisparam3 { get; set; } 

		// GIS Parameter 2
		public string gisparam2 { get; set; } 

		// GIS Parameter 1
		public string gisparam1 { get; set; } 

		// Customer #
		public string lo2 { get; set; } 

		// Premise Status
		public string lo1 { get; set; } 

		// GL Account
		public string glaccount { get; set; } 

		// Default Storeroom
		public bool isdefault { get; set; } 

		// Changed By
		public string changeby { get; set; } 

		// Lo15
		public bool lo15 { get; set; } 

		// Shrinkage Account
		public string shrinkageacc { get; set; } 

		// Calendar
		public string calnum { get; set; } 

		// GeoWorx Sync Identifier
		public string geoworxsyncid { get; set; } 

		// Ship to Labor
		public string shiptolaborcode { get; set; } 

		// Warranty Date
		public DateTime? warrantyexpdate { get; set; } 

		// System
		public string systemid { get; set; } 

		// Feature Class
		public string plussfeatureclass { get; set; } 

		// Tool Control Account
		public string toolcontrolacc { get; set; } 

		// Quadrant
		public string quad { get; set; } 

		// LOCATIONMNTSKD
		//public List<LOCATIONMNTSKD>? locationmntskd { get; set; } 

		// Source System ID
		public string sourcesysid { get; set; } 

		// Service Address
		public string serviceaddresscode { get; set; } 

		// Account #
		public string lo4 { get; set; } 

		// Disabled
		public bool disabled { get; set; } 

		// Bill to Labor
		public string billtolaborcode { get; set; } 

		// Quadrant
		public string lo5 { get; set; } 
	}

	// DCW_KONA_DOCLINKS
	public class MaximoDocLinks : MaximoBaseEntity
	{

		// WORKORDERID
		public Int64 workorderid { get; set; } 

		// DOCLINKS
		//public List<DOCLINKS>? doclinks { get; set; } 

		// Site
		public string siteid { get; set; } 

		// Work Order
		public string wonum { get; set; } 
	}

		// SOL_WOLABTRANS
	public class MaximoLabTrans : MaximoBaseEntity
	{

		// Actual Hours of External Labor
		public string actoutlabhrs { get; set; } 

		// JOBTASKID
		public Int64? jobtaskid { get; set; } 

		// Charge to Store
		public bool chargestore { get; set; } 

		// Justification
		public string contractorjustification { get; set; } 

		// Is GIS
		public bool plussisgis { get; set; } 

		// Include Tasks in Schedule
		public bool inctasksinsched { get; set; } 

		// Scheduled Start
		public DateTime? schedstart { get; set; } 

		// Labor
		public string wolablnk { get; set; } 

		// Class
		public string woclass { get; set; } 

		// Validated
		public bool validated { get; set; } 

		// Temperature
		public int? temperature { get; set; } 

		// WORKORDERID
		public Int64 workorderid { get; set; } 

		// Estimate Service Cost at Approval
		public double estatapprservcost { get; set; } 

		// Run 15 Minutes
		public bool run15minutes { get; set; } 

		// Distance to Blockage
		public string dcw_snakedist2blckg { get; set; } 

		// Flow Action
		public string flowaction { get; set; } 

		// Weathercond
		public string weathercond { get; set; } 

		// Actual Cost of Internal Labor
		public double? actintlabcost { get; set; } 

		// Frequency Unit
		public string pluscfrequnit { get; set; } 

		// Sewer Relieved
		public bool sewerrelieved { get; set; } 

		// Service Group
		public string commoditygroup { get; set; } 

		// Appointment Required
		public bool apptrequired { get; set; } 

		// Outside Labor Cost
		public double outlabcost { get; set; } 

		// Loop Calibration
		public bool pluscloop { get; set; } 

		// Status Date
		public DateTime statusdate { get; set; } 

		// Asset's Extra Field # 5
		public double? woeq5 { get; set; } 

		// Flushing Zone
		public string woeq4 { get; set; } 

		// Parent WO
		public string parent { get; set; } 

		// Category
		public string woeq7 { get; set; } 

		// Asset's Extra Field # 6
		public DateTime? woeq6 { get; set; } 

		// Finish No Later Than
		public DateTime? fnlconstraint { get; set; } 

		// Useful Life
		public string woeq9 { get; set; } 

		// PM Extension Date
		public DateTime? pmextdate { get; set; } 

		// Asset's Extra Field # 8
		public string woeq8 { get; set; } 

		// Reason for Change
		public string reasonforchange { get; set; } 

		// Zip
		public string customerzip { get; set; } 

		// Petroleum Odor
		public bool petroleumodor { get; set; } 

		// Project
		public string woeq1 { get; set; } 

		// Estimated Cost of External Labor
		public double? estoutlabcost { get; set; } 

		// Pressure Zone
		public string woeq2 { get; set; } 

		// Snake Line
		public bool snakeline { get; set; } 

		// Location Details
		public string woeq3 { get; set; } 

		// Requires Location Downtime
		public bool los { get; set; } 

		// Cutnum
		public string cutnum { get; set; } 

		// Water Cloudy
		public bool watercloudy { get; set; } 

		// Problemside
		public string problemside { get; set; } 

		// Developer Contact
		public string developercontact { get; set; } 

		// Water Cause Rash
		public bool watercauserash { get; set; } 

		// FCID
		public string fincntrlid { get; set; } 

		// PM
		public string pmnum { get; set; } 

		// Measurement
		public double? measurementvalue { get; set; } 

		// Ignore Direct Issue Availability For Work Order Status
		public bool ignorediavail { get; set; } 

		// Location where snake was run
		public string snakeloc { get; set; } 

		// Task
		public int? taskid { get; set; } 

		// Measurementvalue2
		public double? measurementvalue2 { get; set; } 

		// Locallized
		public double? measurementvalue4 { get; set; } 

		// Equipmentused
		public string equipmentused { get; set; } 

		// Measurementvalue3
		public double? measurementvalue3 { get; set; } 

		// Estimated Hours of External Labor
		public string estoutlabhrs { get; set; } 

		// Debris
		public bool debris { get; set; } 

		// Velocitypres
		public double? velocitypres { get; set; } 

		// Location of clean-out or test tee
		public string cleanoutloc { get; set; } 

		// Permitdate
		public DateTime? permitdate { get; set; } 

		// Interruptible
		public bool interruptible { get; set; } 

		// Crew
		public string crewid { get; set; } 

		// Class Structure
		public string classstructureid { get; set; } 

		// Changed By
		public string changeby { get; set; } 

		// Runningtraploc
		public string runningtraploc { get; set; } 

		// PO Line ID
		public Int64? genforpolineid { get; set; } 

		// Calendar
		public string calccalendar { get; set; } 

		// Revised Priority
		public int? dcw_revisedpriority { get; set; } 

		// Contractor Release #
		public int? contr_rel_num { get; set; } 

		// Source System ID
		public string sourcesysid { get; set; } 

		// Failed Date
		public DateTime? faildate { get; set; } 

		// Requires Dedicated Location Maintenance Window
		public bool lms { get; set; } 

		// Next Calibration Due Date
		public DateTime? pluscnextdate { get; set; } 

		// Wol4
		public DateTime? wol4 { get; set; } 

		// Engineer Company
		public string engineercompany { get; set; } 

		// Asset
		public string assetnum { get; set; } 

		// Occupancy Permit #
		public string occpermitnum { get; set; } 

		// Estimate Material Cost at Approval
		public double estatapprmatcost { get; set; } 

		// Calculated Longitude (X)
		public double? calculatedx { get; set; } 

		// Calculated Latitude (Y)
		public double? calculatedy { get; set; } 

		// Lead
		public string lead { get; set; } 

		// PM Due Date
		public DateTime? pmduedate { get; set; } 

		// Actual Labor Cost
		public double actlabcost { get; set; } 

		// Reported By
		public string reportedby { get; set; } 

		// Operating Status
		public string woeq10 { get; set; } 

		// Asset's Extra Field # 12
		public string woeq12 { get; set; } 

		// Job Plan Revision Number
		public int? pluscjprevnum { get; set; } 

		// Asset's Extra Field # 11
		public string woeq11 { get; set; } 

		// Inspected By
		public double? woeq14 { get; set; } 

		// Description
		public string description { get; set; } 

		// Asset's Extra Field # 13
		public DateTime? woeq13 { get; set; } 

		// Whom is this change for
		public string whomischangefor { get; set; } 

		// LABTRANS
		//public List<LABTRANS>? labtrans { get; set; } 

		// Problem Throughout Location
		public bool problemthruout { get; set; } 

		// Repair Facility Site
		public string repfacsiteid { get; set; } 

		// Under Flow Control
		public bool flowcontrolled { get; set; } 

		// Nested Job Plan Processing
		public bool nestedjpinprocess { get; set; } 

		// Medical report
		public string medicalreport { get; set; } 

		// Construction Permit #
		public string conpermitnum { get; set; } 

		// Estimated Service Cost
		public double estservcost { get; set; } 

		// Ignore Storeroom Availability For Work Order Status
		public bool ignoresrmavail { get; set; } 

		// Lawson Budget Check
		public bool dcw_lwbudgetcheck { get; set; } 

		// Repair Facility Required
		public bool repairlocflag { get; set; } 

		// Physical Location
		public string pluscphyloc { get; set; } 

		// Respond By
		public DateTime? respondby { get; set; } 

		// PO Revision
		public int? genforporevision { get; set; } 

		// Estimated Hours of Internal Labor
		public string estintlabhrs { get; set; } 

		// Owner Group
		public string ownergroup { get; set; } 

		// Back Out Plan
		public string backoutplan { get; set; } 

		// Wol3
		public double? wol3 { get; set; } 

		// Wol2
		public string wol2 { get; set; } 

		// Sampleloctype
		public string sampleloctype { get; set; } 

		// Wol1
		public string wol1 { get; set; } 

		// Send Materials to Lawson
		public bool dcw_sendmatl2lw { get; set; } 

		// Requires Dedicated Asset Maintenance Window
		public bool ams { get; set; } 

		// Work Group
		public string persongroup { get; set; } 

		// WO19
		public bool wo19 { get; set; } 

		// State
		public string customerstate { get; set; } 

		// Measurement Date
		public DateTime? measuredate { get; set; } 

		// BPEL Activity Name
		public string pmcombpelactname { get; set; } 

		// Final Position
		public string finalposition { get; set; } 

		// Outside Tool Cost
		public double outtoolcost { get; set; } 

		// WO20
		public bool wo20 { get; set; } 

		// E-mail
		public string customeremail { get; set; } 

		// Agency
		public string agencyid { get; set; } 

		// Estimate Tool Cost at Approval
		public double estatapprtoolcost { get; set; } 

		// Asset/Location Priority
		public int? assetlocpriority { get; set; } 

		// Calculated Priority
		public int? calcpriority { get; set; } 

		// Calendar
		public string calendar { get; set; } 

		// Snake Ran to the Main Public Sewer
		public bool snaketosewer { get; set; } 

		// Original Problem Type
		public string origproblemtype { get; set; } 

		// Target Start
		public DateTime? targstartdate { get; set; } 

		// Water Taste
		public bool watertaste { get; set; } 

		// Originating Record
		public string origrecordid { get; set; } 

		// Downtime
		public bool downtime { get; set; } 

		// Require Asset Downtime
		public bool reqasstdwntime { get; set; } 

		// Miss Utility Emergency
		public bool missutilityemerg { get; set; } 

		// Typeodor
		public string typeodor { get; set; } 

		// Service
		public string service { get; set; } 

		// Is Restoration Required
		public string restorationreqd { get; set; } 

		// Contractor Phone
		public string contractorphone { get; set; } 

		// Approved Cost of Internal Labor
		public double? estatapprintlabcost { get; set; } 

		// Disabled
		public bool disabled { get; set; } 

		// Developer Company
		public string developercompany { get; set; } 

		// Property Line
		public string wolo5 { get; set; } 

		// Last Time doclinks Copied
		public DateTime? lastcopylinkdate { get; set; } 

		// Wolo6
		public double? wolo6 { get; set; } 

		// Customer's E-mail Address
		public string wolo3 { get; set; } 

		// Estiamted Cost of External Labor
		public string estatapproutlabhrs { get; set; } 

		// Customer's Name
		public string wolo4 { get; set; } 

		// Sub Area
		public string wolo9 { get; set; } 

		// Bldg Sewer/Running Trap Present
		public bool runningtrap { get; set; } 

		// Wolo7
		public DateTime? wolo7 { get; set; } 

		// Project Type
		public string projecttype { get; set; } 

		// Wolo8
		public double? wolo8 { get; set; } 

		// Estiamted Hours of Internal Labor
		public string estatapprintlabhrs { get; set; } 

		// Water Odor
		public bool waterodor { get; set; } 

		// Scheduled Finish
		public DateTime? schedfinish { get; set; } 

		// Work Order
		public string wonum { get; set; } 

		// Area
		public string wolo1 { get; set; } 

		// Customer's Phone #
		public string wolo2 { get; set; } 

		// Is this an Asset Swap
		public bool woisswap { get; set; } 

		// Contractor Contact
		public string contractorcontact { get; set; } 

		// Reported Date
		public DateTime? reportdate { get; set; } 

		// Outside Material Cost
		public double outmatcost { get; set; } 

		// BPEL In Progress
		public bool pmcombpelinprog { get; set; } 

		// Organization
		public string orgid { get; set; } 

		// Route Stop
		public Int64? routestopid { get; set; } 

		// CB Functional Worktypes
		public string wo1 { get; set; } 

		// Site
		public string siteid { get; set; } 

		// Ward
		public string wo3 { get; set; } 

		// Valve Position as Found
		public string wo4 { get; set; } 

		// Install Job # / Date
		public string wo7 { get; set; } 

		// External Reference ID
		public string externalrefid { get; set; } 

		// WO14
		public bool wo14 { get; set; } 

		// WO13
		public bool wo13 { get; set; } 

		// Job Plan
		public string jpnum { get; set; } 

		// Lead Craft
		public string leadcraft { get; set; } 

		// Wo9
		public string wo9 { get; set; } 

		// How Discovered
		public string wo11 { get; set; } 

		// WO18
		public bool wo18 { get; set; } 

		// Plumber Name
		public string plumbername { get; set; } 

		// Create Invoice
		public bool wo17 { get; set; } 

		// WO16
		public bool wo16 { get; set; } 

		// First Approve Status
		public string firstapprstatus { get; set; } 

		// WO15
		public bool wo15 { get; set; } 

		// CIS Number
		public string cisnum { get; set; } 

		// Other Contact
		public string othercontact { get; set; } 

		// Estimated Labor Cost
		public double estlabcost { get; set; } 

		// Duration
		public string estdur { get; set; } 

		// Vehicle #
		public string wo10 { get; set; } 

		// Priority
		public int? wopriority { get; set; } 

		// Has Follow-up Work
		public bool hasfollowupwork { get; set; } 

		// Connectiontype
		public string connectiontype { get; set; } 

		// Verification
		public string verification { get; set; } 

		// Supervisor
		public string supervisor { get; set; } 

		// PmComType
		public string pmcomtype { get; set; } 

		// Actual Tool Cost
		public double acttoolcost { get; set; } 

		// Work Type
		public string worktype { get; set; } 

		// Start No Earlier Than
		public DateTime? sneconstraint { get; set; } 

		// Actual Material Cost
		public double actmatcost { get; set; } 

		// Winds
		public string winds { get; set; } 

		// Is Mobile
		public bool pluscismobile { get; set; } 

		// Configuration Item
		public string cinum { get; set; } 

		// Sender System ID
		public string sendersysid { get; set; } 

		// Complexity
		public double? complexity { get; set; } 

		// Requires Asset Downtime
		public bool aos { get; set; } 

		// Problembegan
		public string problembegan { get; set; } 

		// Problemloc
		public string problemloc { get; set; } 

		// Distance
		public int? distance { get; set; } 

		// Originating Record Class
		public string origrecordclass { get; set; } 

		// Has Children
		public bool haschildren { get; set; } 

		// Typetreatment
		public string typetreatment { get; set; } 

		// Work Location
		public string worklocation { get; set; } 

		// Estimated Tool Cost
		public double esttoolcost { get; set; } 

		// Frequency Field
		public int? pluscfrequency { get; set; } 

		// Target Finish
		public DateTime? targcompdate { get; set; } 

		// Crew
		public string amcrew { get; set; } 

		// Observation
		public string observation { get; set; } 

		// Vendor
		public string vendor { get; set; } 

		// Receivedat
		public string receivedat { get; set; } 

		// Outlet Diameter
		public string outletdia { get; set; } 

		// Repair Facility
		public string repairfacility { get; set; } 

		// Utility Strike
		public bool dcw_utilitystrike { get; set; } 

		// Assigned Owner Group
		public string assignedownergroup { get; set; } 

		// Organization
		public string calcorgid { get; set; } 

		// Localizedwhere
		public string localizedwhere { get; set; } 

		// Water Treatment
		public bool watertreatment { get; set; } 

		// Alt. Phone # or Fax #
		public string altphonefax { get; set; } 

		// New Child Class
		public string newchildclass { get; set; } 

		// Feature Class
		public string plussfeatureclass { get; set; } 

		// Route
		public string route { get; set; } 

		// Precipitation
		public bool precipitation { get; set; } 

		// WO Group
		public string wogroup { get; set; } 

		// City
		public string customercity { get; set; } 

		// Estiamted Hours of External Labor
		public double? estatapproutlabcost { get; set; } 

		// Person Seen Doctor
		public bool personseendoctor { get; set; } 

		// PM Next Due Date
		public DateTime? pmnextduedate { get; set; } 

		// Direct Issue Material Status
		public string dirissuemtlstatus { get; set; } 

		// Work Package Material Status
		public string workpackmtlstatus { get; set; } 

		// Discolorhotcold
		public string discolorhotcold { get; set; } 

		// Particles in Water
		public bool particlesinwater { get; set; } 

		// Measurement Point
		public string pointnum { get; set; } 

		// As-Built Required
		public bool asbuiltreqd { get; set; } 

		// Inherit Status Changes
		public bool parentchgsstatus { get; set; } 

		// Changed Date
		public DateTime? changedate { get; set; } 

		// Phone
		public string phone { get; set; } 

		// Is Task
		public bool istask { get; set; } 

		// Cleanout
		public bool cleanout { get; set; } 

		// Location
		public string location { get; set; } 

		// Crew Work Group
		public string crewworkgroup { get; set; } 

		// Actual Service Cost
		public double actservcost { get; set; } 

		// History
		public bool historyflag { get; set; } 

		// Worts3
		public string worts3 { get; set; } 

		// Wojp1
		public string wojp1 { get; set; } 

		// Pipe Type
		public string pipetype { get; set; } 

		// Worts4
		public DateTime? worts4 { get; set; } 

		// Worts1
		public string worts1 { get; set; } 

		// Worts2
		public string worts2 { get; set; } 

		// Wojp5
		public DateTime? wojp5 { get; set; } 

		// Actual Start
		public DateTime? actstart { get; set; } 

		// Justification
		public string justification { get; set; } 

		// Wojp4
		public double? wojp4 { get; set; } 

		// Worts5
		public double? worts5 { get; set; } 

		// Wojp3
		public string wojp3 { get; set; } 

		// Actual Cost of External Labor
		public double? actoutlabcost { get; set; } 

		// Wojp2
		public string wojp2 { get; set; } 

		// Flow Action Assist
		public bool flowactionassist { get; set; } 

		// Calibration Overdue Date
		public DateTime? pluscoverduedate { get; set; } 

		// Launch Entry Name
		public string launchentryname { get; set; } 

		// Estimate Labor Cost at Approval
		public double estatapprlabcost { get; set; } 

		// Fund
		public string fund { get; set; } 

		// PmComState
		public string pmcomstate { get; set; } 

		// Estimated Material Cost
		public double estmatcost { get; set; } 

		// Priority Justification
		public string justifypriority { get; set; } 

		// Debris Description
		public string debrisdesc { get; set; } 

		// Suspend Flow Control
		public bool suspendflow { get; set; } 

		// Status
		public string status { get; set; } 

		// Contract
		public string contract { get; set; } 

		// ENum
		//JsonProperty(enum) 
		public string enumField { get; set; } 

		// Material Status Last Updated
		public DateTime? availstatusdate { get; set; } 

		// Particle Color
		public string particlecolor { get; set; } 

		// Water Discolored
		public bool waterdiscolored { get; set; } 

		// Extra Field
		public int? wolo10 { get; set; } 

		// Environment
		public string environment { get; set; } 

		// Miss Utility Number
		public string missutilitynum { get; set; } 

		// Payee Company
		public string othercompany { get; set; } 

		// Owner System ID
		public string ownersysid { get; set; } 

		// Owner
		public string owner { get; set; } 

		// Problem Code
		public string problemcode { get; set; } 

		// Developer Phone #
		public string developerphone { get; set; } 

		// Accepts Charges
		public bool woacceptscharges { get; set; } 

		// Map #
		public string mapnum { get; set; } 

		// Watercolor
		public string watercolor { get; set; } 

		// CB Assignment
		public bool dcw_cbassigned { get; set; } 

		// BPEL Enabled
		public bool pmcombpelenabled { get; set; } 

		// Target Description
		public string targetdesc { get; set; } 

		// Actual Hours of Internal Labor
		public string actintlabhrs { get; set; } 

		// Inspector
		public string inspector { get; set; } 

		// BKPCONTRACT
		public string bkpcontract { get; set; } 

		// Numberofturns
		public double? numberofturns { get; set; } 

		// Estimated Cost of Internal Labor
		public double? estintlabcost { get; set; } 

		// Actual Labor Hours
		public string actlabhrs { get; set; } 

		// Failure Class
		public string failurecode { get; set; } 

		// Sequence
		public int? wosequence { get; set; } 

		// Missutilitydate
		public DateTime? missutilitydate { get; set; } 

		// Risk Assessment
		public string risk { get; set; } 

		// Estimated Labor Hours
		public string estlabhrs { get; set; } 

		// As-Built Recorded
		public bool asbuiltrecd { get; set; } 

		// Shift
		public string calcshift { get; set; } 

		// Jetline
		public bool jetline { get; set; } 

		// Plumber's License #
		public string plumberlicnum { get; set; } 

		// Estimate Labor Hours at Approval
		public string estatapprlabhrs { get; set; } 

		// Location Details
		public string locationdetails { get; set; } 

		// On Behalf Of
		public string onbehalfof { get; set; } 

		// Storeroom Material Status
		public string storeroommtlstatus { get; set; } 

		// Actual Finish
		public DateTime? actfinish { get; set; } 

		// PO
		public string generatedforpo { get; set; } 

		// Receivedvia
		public string receivedvia { get; set; } 

		// WOJO6
		public string wojo6 { get; set; } 

		// GL Account
		public string glaccount { get; set; } 

		// WOJO5
		public string wojo5 { get; set; } 

		// WOJO8
		public string wojo8 { get; set; } 

		// WOJO7
		public string wojo7 { get; set; } 

		// WOJO2
		public string wojo2 { get; set; } 

		// WOJO1
		public string wojo1 { get; set; } 

		// WOJO4
		public double? wojo4 { get; set; } 

		// WOJO3
		public string wojo3 { get; set; } 

		// Time Remaining
		public string remdur { get; set; } 

		// Service
		public string commodity { get; set; } 

		// Watertastedesc
		public string watertastedesc { get; set; } 

		// Streeet Address
		public string customerstreet { get; set; } 
	}

		// ToolTrans
	public class MaximoToolTrans : MaximoBaseEntity
	{

		// Asset
		public string assetnum { get; set; }

		// Secondary Line Cost
		public double? linecost2 { get; set; }

		// Transaction Date
		public DateTime transdate { get; set; }

		// Tool Hours
		public string toolhrs { get; set; }

		// GL Debit Account
		public string gldebitacct { get; set; }

		// Sender System ID
		public string sendersysid { get; set; }

		// Rolled Up
		public bool rollup { get; set; }

		// Location
		public string location { get; set; }

		// Qualified Technician
		public string plusctechnician { get; set; }

		// Financial Period
		public string financialperiod { get; set; }

		// Manufacturer
		public string pluscmanufacturer { get; set; }

		// PLUSCTOOLUSEDATE
		public DateTime? plusctoolusedate { get; set; }

		// Secondary Exchange Rate
		public double? exchangerate2 { get; set; }

		// Tool
		public List<MaximoToolItem> toolitem { get; set; } 

		// Language Code
		public string langcode { get; set; }

		// Line Cost
		public double linecost { get; set; }

		// Manufacturer Lot
		public string plusclotnum { get; set; }

		// Rate
		public double toolrate { get; set; }

		// Organization
		public string orgid { get; set; }

		// Type
		public string plusctype { get; set; }

		// Item Set Id
		public string itemsetid { get; set; }

		// Due Date
		public DateTime? pluscduedate { get; set; }

		// Entered By
		public string enterby { get; set; }

		// Work Order
		public string refwo { get; set; }

		// GL Credit Account
		public string glcreditacct { get; set; }

		// Task
		public int? actualstaskid { get; set; }

		// Site
		public string siteid { get; set; }

		// Rotating Asset
		public string rotassetnum { get; set; }

		// Entered as Task
		public bool enteredastask { get; set; }

		// External Reference ID
		public string externalrefid { get; set; }

		// Anywhere Ref ID
		public Int64? anywhererefid { get; set; }

		// Crew
		public string amcrew { get; set; }

		// Tool Comment Field
		public string plusccomment { get; set; }

		// Quantity
		public int toolqty { get; set; }

		// Rotating Equipment Site ID
		public string rotassetsite { get; set; }

		// Entered Date
		public DateTime enterdate { get; set; }

		// Expiry Date
		public DateTime? pluscexpirydate { get; set; }

		// Tool Sequence
		public string toolsq { get; set; }

		// Owner System ID
		public string ownersysid { get; set; }

		// Source System ID
		public string sourcesysid { get; set; }

		// TOOLTRANSID
		public Int64? identifier { get; set; }

		// Has Long Description
		public bool hasld { get; set; }

		// Outside
		public bool outside { get; set; }

		// FCID
		public string fincntrlid { get; set; }
	}

		// ToolItem
	public class MaximoToolItem : MaximoBaseEntity
	{

		// Request to Change
		public bool dcw_rtc { get; set; } 

		// Createdate
		public DateTime? createdate { get; set; } 

		// Meter
		public string metername { get; set; } 

		// Order Unit
		public string orderunit { get; set; } 

		// Language Code
		public string langcode { get; set; } 

		// Capitalized
		public bool capitalized { get; set; } 

		// Fromm MM Route to Assignee
		public string dcw_frmm_routeto { get; set; } 

		// Tool
		public string itemnum { get; set; } 

		// Order thru BS4
		public bool dcw_bs4inv { get; set; } 

		// Inspect on Receipt
		public bool inspectionrequired { get; set; } 

		// Commodity Group
		public string commoditygroup { get; set; } 

		// External Reference ID
		public string externalrefid { get; set; } 

		// Project ID
		public string dcw_projectid { get; set; } 

		// Stocksubtype
		public string stocksubtype { get; set; } 

		// Status Date
		public DateTime statusdate { get; set; } 

		// Status
		public string status { get; set; } 

		// Kit
		public bool iskit { get; set; } 

		// Createdby
		public string createdby { get; set; } 

		// Rotating
		public bool rotating { get; set; } 

		// Issue Unit
		public string issueunit { get; set; } 

		// Owner System ID
		public string ownersysid { get; set; } 

		// Automatically Add as Spare
		public bool sparepartautoadd { get; set; } 

		// Outside
		public bool outside { get; set; } 

		// Has Long Description
		public bool hasld { get; set; } 

		// M&TE Classification
		public string pluscismteclass { get; set; } 

		// Tax Exempt
		public bool taxexempt { get; set; } 

		// Sender System ID
		public string sendersysid { get; set; } 

		// Maximum Quantity Issued
		public double? maxissue { get; set; } 

		// MSDS
		public string msdsnum { get; set; } 

		// Meter Group
		public string groupname { get; set; } 

		// Internal Calibration
		public bool pluscisinhousecal { get; set; } 

		// ITEMID
		public Int64 itemid { get; set; } 

		// Condition Enabled
		public bool conditionenabled { get; set; } 

		// Attach to Parent Asset on Issue
		public bool attachonissue { get; set; } 

		// Buffer Solution
		public bool pluscsolution { get; set; } 

		// Description
		public string title { get; set; } 

		// Is M&TE
		public bool pluscismte { get; set; } 

		// IN27
		public string in27 { get; set; } 

		// Item Set
		public string itemsetid { get; set; } 

		// IN26
		public string in26 { get; set; } 

		// IN25
		public string in25 { get; set; } 

		// IN24
		public string in24 { get; set; } 

		// Extra Field 23
		public double? in23 { get; set; } 

		// Extra Field 22
		public DateTime? in22 { get; set; } 

		// Extra Field 21
		public string in21 { get; set; } 

		// Extra Field 20
		public string in20 { get; set; } 

		// Type
		public string itemtype { get; set; } 

		// Extra Field 2
		public bool in2 { get; set; } 

		// Extra Field 1
		public string in1 { get; set; } 

		// Crew
		public bool iscrew { get; set; } 

		// Application
		public string application { get; set; } 

		// Extra Field 4
		public string in4 { get; set; } 

		// Requires hard reservation on use
		public bool hardresissue { get; set; } 

		// Extra Field 3
		public bool in3 { get; set; } 

		// Class Structure
		public string classstructureid { get; set; } 

		// Lot Type
		public string lottype { get; set; } 

		// Request to Stock
		public bool dcw_stockflag { get; set; } 

		// Prorate Service
		public bool prorate { get; set; } 

		// Order thru BP1
		public bool dcw_bp1inv { get; set; } 

		// Extra Field 19
		public string in19 { get; set; } 

		// TOOLQUAL
		//public List<TOOLQUAL>? toolqual { get; set; } 

		// Send to Lawson Flag
		public bool in15 { get; set; } 

		// Commodity Code
		public string commodity { get; set; } 

		// Extra Field 9
		public double? in9 { get; set; } 

		// Source System ID
		public string sourcesysid { get; set; } 

		// Receipt Tolerance %
		public double? receipttolerance { get; set; } 

		// Extra Field 5
		public string in5 { get; set; } 

		// Return to Service
		public int? dcw_rts { get; set; } 

		// Extra Field 6
		public string in6 { get; set; } 

		// Ordered thru BY2
		public bool dcw_by2inv { get; set; } 

		// Extra Field 7
		public string in7 { get; set; } 

		// Extra Field 8
		public string in8 { get; set; } 
	}

	
		// MXINVENTORY
	public class MaximoInventory : MaximoBaseEntity
	{

		// 2 Years Ago
		public double issue2yrago { get; set; } 

		// Storeroom
		public string location { get; set; } 

		// Consignment Vendor
		public string consvendor { get; set; } 

		// Current Balance
		public double? curbal { get; set; } 

		// Safety Stock
		public double? sstock { get; set; } 

		// Frequency Units
		public string frequnit { get; set; } 

		// GL Control Account
		public string controlacc { get; set; } 

		// Order Unit
		public string orderunit { get; set; } 

		// Reorder Point
		public double maxlevel { get; set; } 

		// Organization
		public string orgid { get; set; } 

		// Item
		public string itemnum { get; set; } 

		// Site
		public string siteid { get; set; } 

		// Reorder Point
		public double minlevel { get; set; } 

		// External Reference ID
		public string externalrefid { get; set; } 

		// Count Frequency
		public int ccf { get; set; } 

		// Cost Adjustment GL Account
		public string invcostadjacc { get; set; } 

		// Status Date
		public DateTime statusdate { get; set; } 

		// Status
		public string status { get; set; } 

		// Next Invoice Date
		public DateTime? nextinvoicedate { get; set; } 

		// Consignment
		public bool consignment { get; set; } 

		// Default Bin
		public string binnum { get; set; } 

		// Catalog #
		public string catalogcode { get; set; } 

		// Default Stage Bin
		public string dfltstagebin { get; set; } 

		// Extra Field 1
		public string il1 { get; set; } 

		// Extra Field 2
		public string il2 { get; set; } 

		// Extra Field 3
		public string il3 { get; set; } 

		// Issue Unit
		public string issueunit { get; set; } 

		// Last Issue Date
		public DateTime? lastissuedate { get; set; } 

		// Manufacturer
		public string manufacturer { get; set; } 

		// Economic Order Quantity
		public double orderqty { get; set; } 

		// Owner System ID
		public string ownersysid { get; set; } 

		// Storeroom Site
		public string storelocsiteid { get; set; } 

		// Has Status Changed
		public bool statusiface { get; set; } 

		// 3 Years Ago
		public double issue3yrago { get; set; } 

		// Issue Cost Type
		public string costtype { get; set; } 

		// Sender System ID
		public string sendersysid { get; set; } 

		// Frequency
		public int? frequency { get; set; } 

		// Quantity Available
		public double? avblbalance { get; set; } 

		// Model
		public string modelnum { get; set; } 

		// Change Status Memo
		public string np_statusmemo { get; set; } 

		// Item Set
		public string itemsetid { get; set; } 

		// Quantity Currently Reserved
		public double? reservedqty { get; set; } 

		// Invoice Generation Type
		public string invgentype { get; set; } 

		// Internal
		//public bool internal { get; set; } 

		// INVENTORYID
		public Int64 inventoryid { get; set; } 

		// ABC Type
		public string abctype { get; set; } 

		// Item Type
		public string itemtype { get; set; } 

		// Requires hard reservation on use
		public bool? hardresissue { get; set; } 

		// GL Account
		public string glaccount { get; set; } 

		// Lead Time (Days)
		public int deliverytime { get; set; } 

		// Primary Vendor
		public string vendor { get; set; } 

		// Shrinkage GL Account
		public string shrinkageacc { get; set; } 

		// Last Year
		public double issue1yrago { get; set; } 

		// Reorder
		public bool? reorder { get; set; } 

		// INVCOST
		//public List<INVCOST>? invcost { get; set; } 

		// Storeroom
		public string storeloc { get; set; } 

		// New Issue Cost Type
		public string newcosttype { get; set; } 

		// Source System ID
		public string sourcesysid { get; set; } 

		// Receipt Tolerance %
		public double? receipttolerance { get; set; } 

		// Year to Date
		public double issueytd { get; set; } 
	}

	
    public class FailureList : MaximoBaseEntity
    {
      
        public string orgid { get; set; }
        public int parent { get; set; }
        public int failurelist { get; set; }
        public List<FailureCode> failurecode { get; set; }
        public bool dcw_invalid { get; set; }
        public string type { get; set; }
       
    }
    public class FailureCode : MaximoBaseEntity
    {
       
        public string orgid { get; set; }
        public string description { get; set; }
        public int failurecodeid { get; set; }
        public string failurecode { get; set; }
        public string langcode { get; set; }
        public bool hasld { get; set; }
    }



}