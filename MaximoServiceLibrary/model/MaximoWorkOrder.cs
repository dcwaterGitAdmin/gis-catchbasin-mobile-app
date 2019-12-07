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

		// Actual Hours of External Labor
		public double? actoutlabhrs { get; set; } 

		// JOBTASKID
		public Int64? jobtaskid { get; set; } 

		// Details
		public string description_longdescription { get; set; } 

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

		// Debris
		public bool debris { get; set; } 

		// Estimated Hours of External Labor
		public double? estoutlabhrs { get; set; } 

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

		// Task
		public string fctaskid { get; set; } 

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
		public double? estintlabhrs { get; set; } 

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

		// Change Status Memo
		public string np_statusmemo { get; set; } 

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
		public double? estatapproutlabhrs { get; set; } 

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
		public double? estatapprintlabhrs { get; set; } 

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

		// Project ID
		public string fcprojectid { get; set; } 

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
		public double estdur { get; set; } 

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

		// Has Status Changed
		public bool statusiface { get; set; } 

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

		// Remarks
		public string remarkdesc { get; set; } 

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

		// BPEL Enabled
		public bool pmcombpelenabled { get; set; } 

		// CB Assignment
		public bool dcw_cbassigned { get; set; } 

		// Target Description
		public string targetdesc { get; set; } 

		// Actual Hours of Internal Labor
		public double? actintlabhrs { get; set; } 

		// Inspector
		public string inspector { get; set; } 

		// BKPCONTRACT
		public string bkpcontract { get; set; } 

		// Numberofturns
		public double? numberofturns { get; set; } 

		// Estimated Cost of Internal Labor
		public double? estintlabcost { get; set; } 

		// Actual Labor Hours
		public double actlabhrs { get; set; } 

		// Failure Class
		public string failurecode { get; set; } 

		// Sequence
		public int? wosequence { get; set; } 

		// Missutilitydate
		public DateTime? missutilitydate { get; set; } 

		// Risk Assessment
		public string risk { get; set; } 

		// Estimated Labor Hours
		public double estlabhrs { get; set; } 

		// As-Built Recorded
		public bool asbuiltrecd { get; set; } 

		// Shift
		public string calcshift { get; set; } 

		// Jetline
		public bool jetline { get; set; } 

		// Plumber's License #
		public string plumberlicnum { get; set; } 

		// Estimate Labor Hours at Approval
		public double estatapprlabhrs { get; set; } 

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
		public double? remdur { get; set; } 

		// Service
		public string commodity { get; set; } 

		// Watertastedesc
		public string watertastedesc { get; set; } 

		// Streeet Address
		public string customerstreet { get; set; }

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