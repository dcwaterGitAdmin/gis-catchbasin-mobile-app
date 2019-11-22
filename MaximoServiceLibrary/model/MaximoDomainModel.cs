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
	}


	public class MaximoUser
	{
		public string baseCurrency { get; set; }
		public string loginUserName { get; set; }
		public string defaultOrg { get; set; }
		public string defaultSite { get; set; }
		public string userName { get; set; }
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

	// MXWO
	public class MaximoWorkOrder : MaximoBaseEntity
	{
		public MaximoAsset asset { get; set; }

		// auto-generated fields

		// Actual Hours of External Labor
		public string actoutlabhrs { get; set; }

		// JOBTASKID
		public Int64 jobtaskid { get; set; }

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
		public DateTime schedstart { get; set; }

		// Labor
		public string wolablnk { get; set; }

		// Class
		public string woclass { get; set; }

		// Validated
		public bool validated { get; set; }

		// Temperature
		public int temperature { get; set; }

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
		public double actintlabcost { get; set; }

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
		public double woeq5 { get; set; }

		// Flushing Zone
		public string woeq4 { get; set; }

		// Parent WO
		public string parent { get; set; }

		// Category
		public string woeq7 { get; set; }

		// Asset's Extra Field # 6
		public DateTime woeq6 { get; set; }

		// Finish No Later Than
		public DateTime fnlconstraint { get; set; }

		// Useful Life
		public string woeq9 { get; set; }

		// PM Extension Date
		public DateTime pmextdate { get; set; }

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
		public double estoutlabcost { get; set; }

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
		public double measurementvalue { get; set; }

		// Ignore Direct Issue Availability For Work Order Status
		public bool ignorediavail { get; set; }

		// Location where snake was run
		public string snakeloc { get; set; }

		// Task
		public int taskid { get; set; }

		// Measurementvalue2
		public double measurementvalue2 { get; set; }

		// Locallized
		public double measurementvalue4 { get; set; }

		// Equipmentused
		public string equipmentused { get; set; }

		// Measurementvalue3
		public double measurementvalue3 { get; set; }

		// Debris
		public bool debris { get; set; }

		// Estimated Hours of External Labor
		public string estoutlabhrs { get; set; }

		// Velocitypres
		public double velocitypres { get; set; }

		// Location of clean-out or test tee
		public string cleanoutloc { get; set; }

		// Permitdate
		public DateTime permitdate { get; set; }

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
		public Int64 genforpolineid { get; set; }

		// Calendar
		public string calccalendar { get; set; }

		// Revised Priority
		public int dcw_revisedpriority { get; set; }

		// Contractor Release #
		public int contr_rel_num { get; set; }

		// Task
		public string fctaskid { get; set; }

		// Source System ID
		public string sourcesysid { get; set; }

		// Failed Date
		public DateTime faildate { get; set; }

		// Requires Dedicated Location Maintenance Window
		public bool lms { get; set; }

		// Next Calibration Due Date
		public DateTime pluscnextdate { get; set; }

		// Wol4
		public DateTime wol4 { get; set; }

		// Engineer Company
		public string engineercompany { get; set; }

		// Asset
		public string assetnum { get; set; }

		// Occupancy Permit #
		public string occpermitnum { get; set; }

		// Estimate Material Cost at Approval
		public double estatapprmatcost { get; set; }

		// Calculated Longitude (X)
		public double calculatedx { get; set; }

		// Calculated Latitude (Y)
		public double calculatedy { get; set; }

		// Lead
		public string lead { get; set; }

		// PM Due Date
		public DateTime pmduedate { get; set; }

		// Actual Labor Cost
		public double actlabcost { get; set; }

		// Reported By
		public string reportedby { get; set; }

		// Operating Status
		public string woeq10 { get; set; }

		// Asset's Extra Field # 12
		public string woeq12 { get; set; }

		// Job Plan Revision Number
		public int pluscjprevnum { get; set; }

		// Asset's Extra Field # 11
		public string woeq11 { get; set; }

		// Inspected By
		public double woeq14 { get; set; }

		// Description
		public string description { get; set; }

		// Asset's Extra Field # 13
		public DateTime woeq13 { get; set; }

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
		public DateTime respondby { get; set; }

		// PO Revision
		public int genforporevision { get; set; }

		// Estimated Hours of Internal Labor
		public string estintlabhrs { get; set; }

		// Owner Group
		public string ownergroup { get; set; }

		// Back Out Plan
		public string backoutplan { get; set; }

		// Wol3
		public double wol3 { get; set; }

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
		public DateTime measuredate { get; set; }

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
		public int assetlocpriority { get; set; }

		// Calculated Priority
		public int calcpriority { get; set; }

		// Calendar
		public string calendar { get; set; }

		// Snake Ran to the Main Public Sewer
		public bool snaketosewer { get; set; }

		// Original Problem Type
		public string origproblemtype { get; set; }

		// Target Start
		public DateTime targstartdate { get; set; }

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
		public double estatapprintlabcost { get; set; }

		// Disabled
		public bool disabled { get; set; }

		// Developer Company
		public string developercompany { get; set; }

		// Property Line
		public string wolo5 { get; set; }

		// Last Time doclinks Copied
		public DateTime lastcopylinkdate { get; set; }

		// Wolo6
		public double wolo6 { get; set; }

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
		public DateTime wolo7 { get; set; }

		// Project Type
		public string projecttype { get; set; }

		// Wolo8
		public double wolo8 { get; set; }

		// Estiamted Hours of Internal Labor
		public string estatapprintlabhrs { get; set; }

		// Water Odor
		public bool waterodor { get; set; }

		// Scheduled Finish
		public DateTime schedfinish { get; set; }

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
		public DateTime reportdate { get; set; }

		// Outside Material Cost
		public double outmatcost { get; set; }

		// BPEL In Progress
		public bool pmcombpelinprog { get; set; }

		// Organization
		public string orgid { get; set; }

		// Route Stop
		public Int64 routestopid { get; set; }

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
		public string estdur { get; set; }

		// Vehicle #
		public string wo10 { get; set; }

		// Priority
		public int wopriority { get; set; }

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
		public DateTime sneconstraint { get; set; }

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
		public double complexity { get; set; }

		// Requires Asset Downtime
		public bool aos { get; set; }

		// Problembegan
		public string problembegan { get; set; }

		// Problemloc
		public string problemloc { get; set; }

		// Distance
		public int distance { get; set; }

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
		public int pluscfrequency { get; set; }

		// Target Finish
		public DateTime targcompdate { get; set; }

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
		public double estatapproutlabcost { get; set; }

		// Person Seen Doctor
		public bool personseendoctor { get; set; }

		// PM Next Due Date
		public DateTime pmnextduedate { get; set; }

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
		public DateTime changedate { get; set; }

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
		public DateTime worts4 { get; set; }

		// Worts1
		public string worts1 { get; set; }

		// Worts2
		public string worts2 { get; set; }

		// Wojp5
		public DateTime wojp5 { get; set; }

		// Actual Start
		public DateTime actstart { get; set; }

		// Justification
		public string justification { get; set; }

		// Wojp4
		public double wojp4 { get; set; }

		// Worts5
		public double worts5 { get; set; }

		// Wojp3
		public string wojp3 { get; set; }

		// Actual Cost of External Labor
		public double actoutlabcost { get; set; }

		// Wojp2
		public string wojp2 { get; set; }

		// Flow Action Assist
		public bool flowactionassist { get; set; }

		// Calibration Overdue Date
		public DateTime pluscoverduedate { get; set; }

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
		public DateTime availstatusdate { get; set; }

		// Particle Color
		public string particlecolor { get; set; }

		// Water Discolored
		public bool waterdiscolored { get; set; }

		// Extra Field
		public int wolo10 { get; set; }

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
		public string actintlabhrs { get; set; }

		// Inspector
		public string inspector { get; set; }

		// BKPCONTRACT
		public string bkpcontract { get; set; }

		// Numberofturns
		public double numberofturns { get; set; }

		// Estimated Cost of Internal Labor
		public double estintlabcost { get; set; }

		// Actual Labor Hours
		public string actlabhrs { get; set; }

		// Failure Class
		public string failurecode { get; set; }

		// Sequence
		public int wosequence { get; set; }

		// Missutilitydate
		public DateTime missutilitydate { get; set; }

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
		public DateTime actfinish { get; set; }

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
		public double wojo4 { get; set; }

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

	// MXASSET
	public class MaximoAsset : MaximoBaseEntity
	{
		// meta fields
		public string assetusercust_collectionref { get; set; }
		public string assetspec_collectionref { get; set; }
		public string assetmntskd_collectionref { get; set; }
		public string assetopskd_collectionref { get; set; }
		public string assetmeter_collectionref { get; set; }


		// relation fields 
		// INT_ASSETMETER
		//public List<INT_ASSETMETER> assetmeter { get; set; } 

		// ASSETOPSKD
		//public List<ASSETOPSKD> assetopskd { get; set; } 

		// ASSETMNTSKD
		//public List<ASSETMNTSKD> assetmntskd { get; set; } 

		// ASSETUSERCUST
		//public List<ASSETUSERCUST> assetusercust { get; set; } 

		// ASSETSPECCLASS
		public List<MaximoAssetSpec> assetspec { get; set; }


		// auto-generated fields

		// Is GIS
		public bool plussisgis { get; set; }

		// Details
		public string description_longdescription { get; set; }

		// Applied As
		public string pluscsumdir { get; set; }

		// Partition
		public bool tloampartition { get; set; }

		// Total Downtime
		public string totdowntime { get; set; }

		// Loop Number
		public string pluscloopnum { get; set; }

		// COF Score
		public string cof_score { get; set; }

		// Tool Rate
		public double toolrate { get; set; }

		// Calibration Vendor
		public string pluscvendor { get; set; }

		// Organization
		public string orgid { get; set; }

		// Serial #
		public string serialnum { get; set; }

		// Rotating Item
		public string itemnum { get; set; }

		// Site
		public string siteid { get; set; }

		// Service Address
		public string plussaddresscode { get; set; }

		// External Reference ID
		public string externalrefid { get; set; }

		// Linear
		public bool islinear { get; set; }

		// Asset Up
		public bool isrunning { get; set; }

		// Last Changed Date
		public DateTime statusdate { get; set; }

		// % READING
		public string pluscsumread { get; set; }

		// Y1
		public double y1 { get; set; }

		// Y2
		public double y2 { get; set; }

		// Parent
		public string parent { get; set; }

		// Returned To Vendor
		public bool returnedtovendor { get; set; }

		// Bin
		public string binnum { get; set; }

		// Loop Location
		public string plusclploc { get; set; }

		// YTD Cost
		public double ytdcost { get; set; }

		// Condition Code
		public string conditioncode { get; set; }

		// %SPAN
		public string pluscsumspan { get; set; }

		// Uncharged Cost
		public double unchargedcost { get; set; }

		// To
		public string pluscoprgeto { get; set; }

		// Asset
		public Int64 assetid { get; set; }

		// Operating Range From
		public string pluscoprgefrom { get; set; }

		// Sender System ID
		public string sendersysid { get; set; }

		// Purchase Price
		public double purchaseprice { get; set; }

		// Change the Status of All Associated PMs to Inactive
		public bool changepmstatus { get; set; }

		// Hierarchy Path
		public string hierarchypath { get; set; }

		// Class
		public string pluscclass { get; set; }

		// Operating Status
		public string eq10 { get; set; }

		// Budgeted
		public double budgetcost { get; set; }

		// Asset Department
		public string pluscassetdept { get; set; }

		// Remove Asset Reference from Active Safety Plans
		public bool removefromactivesp { get; set; }

		// X2
		public double x2 { get; set; }

		// EQ13
		public string eq13 { get; set; }

		// Inspected By
		public string eq14 { get; set; }

		// EQ11
		public string eq11 { get; set; }

		// Repair Facility Site
		public string defaultrepfacsiteid { get; set; }

		// X1
		public double x1 { get; set; }

		// EQ12
		public string eq12 { get; set; }

		// Default Repair Facility
		public string defaultrepfac { get; set; }

		// Comments
		public string eq16 { get; set; }

		// Buffer Solution Flag
		public bool pluscsolution { get; set; }

		// Condition Code
		public string eq15 { get; set; }

		// Item Set
		public string itemsetid { get; set; }

		// Last Audit By
		public string lastauditby { get; set; }

		// Is M&TE
		public bool pluscismte { get; set; }

		// Date Inspected
		public DateTime eq19 { get; set; }

		// Type
		public string assettype { get; set; }

		// Changed By
		public string changeby { get; set; }

		// Accuracy EU
		public string pluscsumeu { get; set; }

		// Vendor
		public string vendor { get; set; }

		// Asset Template
		public string templateid { get; set; }

		// Replacement Cost
		public double replacecost { get; set; }

		// Control Account
		public string toolcontrolaccount { get; set; }

		// LOF Score Date
		public DateTime lof_score_date { get; set; }

		// Start Measure
		public double startmeasure { get; set; }

		// Calendar
		public string calnum { get; set; }

		// Verified
		public bool eq22 { get; set; }

		// EQ23
		public DateTime eq23 { get; set; }

		// GeoWorx Sync Identifier
		public string geoworxsyncid { get; set; }

		// EQ24
		public double eq24 { get; set; }

		// Warranty Expiration Date
		public DateTime warrantyexpdate { get; set; }

		// Feature Class
		public string plussfeatureclass { get; set; }

		// ROF Score Date
		public DateTime rof_score_date { get; set; }

		// Source System ID
		public string sourcesysid { get; set; }

		// ROF Score
		public string rof_score { get; set; }

		// Changed Date
		public DateTime changedate { get; set; }

		// Asset #
		public string assetnum { get; set; }

		// Location
		public string location { get; set; }

		// Partition ID
		public string tloamhash { get; set; }

		// Automatically Generate Work Orders
		public bool autowogen { get; set; }

		// Category
		public string eq7 { get; set; }

		// EQ6
		public DateTime eq6 { get; set; }

		// EQ5
		public double eq5 { get; set; }

		// Asset End
		public string enddescription { get; set; }

		// Flushing Zone
		public string eq4 { get; set; }

		// Priority
		public int priority { get; set; }

		// Useful Life
		public string eq9 { get; set; }

		// Asset Tag / Decal #
		public string assettag { get; set; }

		// Description
		public string description { get; set; }

		// EQ8
		public string eq8 { get; set; }

		// Calibration Due Date
		public DateTime pluscduedate { get; set; }

		// Location Details
		public string eq3 { get; set; }

		// Pressure Zone
		public string eq2 { get; set; }

		// Project
		public string eq1 { get; set; }

		// Status
		public string status { get; set; }

		// Shift
		public string shiftnum { get; set; }

		// Remove Asset Reference from Active Routes
		public bool removefromactiveroutes { get; set; }

		// Physical Location
		public string pluscphyloc { get; set; }

		// Roll New Status to All Child Assets
		public bool rolltoallchildren { get; set; }

		// Global ID
		public string globalid { get; set; }

		// Asset Start
		public string startdescription { get; set; }

		// Manufacturer
		public string manufacturer { get; set; }

		// Owner System ID
		public string ownersysid { get; set; }

		// Last Audit Date
		public DateTime lastauditdate { get; set; }

		// Installation Date
		public DateTime installdate { get; set; }

		// %URV
		public string pluscsumurv { get; set; }

		// Fixed Asset?
		public bool fixedasset { get; set; }

		// End Measure
		public double endmeasure { get; set; }

		// Map #
		public string mapnum { get; set; }

		// LRM
		public string lrm { get; set; }

		// Total Uncharged Cost
		public double totunchargedcost { get; set; }

		// Is Contaminated
		public bool plusciscontam { get; set; }

		// M&TE Classification
		public string pluscismteclass { get; set; }

		// Total Cost
		public double totalcost { get; set; }

		// Service Address
		public string saddresscode { get; set; }

		// Extend Date
		public bool pluscpmextdate { get; set; }

		// Direction
		public string direction { get; set; }

		// To Site
		public string newsite { get; set; }

		// Children
		public bool children { get; set; }

		// Meter Group
		public string groupname { get; set; }

		// Is Contaminated Description
		public string plusciscondesc { get; set; }

		// Rotating Suspense Account
		public string rotsuspacct { get; set; }

		// Failure Class
		public string failurecode { get; set; }

		// Internal Calibration
		public bool pluscisinhousecal { get; set; }

		// Depreciation Pending
		public bool depreciationpending { get; set; }

		// Maintain Hierarchy
		public bool mainthierchy { get; set; }

		// Model Number
		public string pluscmodelnum { get; set; }

		// COF Score Date
		public DateTime cof_score_date { get; set; }

		// Ancestor
		public string ancestor { get; set; }

		// Units
		public string pluscoprgeeu { get; set; }

		// Item Type
		public string itemtype { get; set; }

		// GL Account
		public string glaccount { get; set; }

		// Calibration
		public bool iscalibration { get; set; }

		// Inventory Cost
		public double invcost { get; set; }

		// Moved
		public bool moved { get; set; }

		// Usage
		public string usage { get; set; }

		// LOF Score
		public string lof_score { get; set; }

		// Disabled
		public bool disabled { get; set; }
	}


// ASSETSPECCLASS
	public class MaximoAssetSpec : MaximoBaseEntity
	{
		// Changed Date
		public DateTime changedate { get; set; }

		// Table Value
		public string tablevalue { get; set; }

		// Unit of Measure
		public string measureunitid { get; set; }

		// Alphanumeric Value
		public string alnvalue { get; set; }

		// Item Specification Value Changed 
		public bool itemspecvalchanged { get; set; }

		// Display Sequence
		public int displaysequence { get; set; }

		// Start Y Offset
		public double startyoffset { get; set; }

		// Unit of Start Offset
		public string startoffsetunitid { get; set; }

		// End Unit of Measure
		public string endmeasureunitid { get; set; }

		// Unit of End Offset
		public string endoffsetunitid { get; set; }

		// Start Y Offset Referent
		public string startyoffsetref { get; set; }

		// Attribute
		public string assetattrid { get; set; }

		// Organization
		public string orgid { get; set; }

		// Linked to Section
		public string linkedtosection { get; set; }

		// Start Offset
		public double startoffset { get; set; }

		// ASSETSPECID
		public Int64 assetspecid { get; set; }

		// Start Unit of Measure
		public string startmeasureunitid { get; set; }

		// Continuous
		public bool continuous { get; set; }

		// Unit of Base Measure
		public string basemeasureunitid { get; set; }

		// Class Structure
		public string classstructureid { get; set; }

		// Inherited from Item
		public bool inheritedfromitem { get; set; }

		// Changed By
		public string changeby { get; set; }

		// End Z Offset
		public double endzoffset { get; set; }

		// Mandatory
		public bool mandatory { get; set; }

		// End Y Offset Referent
		public string endyoffsetref { get; set; }

		// Start Z Offset
		public double startzoffset { get; set; }

		// Start Measure
		public double startmeasure { get; set; }

		// Numeric Value
		public double numvalue { get; set; }

		// Start Asset Feature ID
		public Int64 startassetfeatureid { get; set; }

		// Es02
		public string es02 { get; set; }

		// Es03
		public string es03 { get; set; }

		// Section
		public string section { get; set; }

		// Es04
		public DateTime es04 { get; set; }

		// End Y Offset
		public double endyoffset { get; set; }

		// Es05
		public double es05 { get; set; }

		// Es01
		public string es01 { get; set; }

		// Start Base Measure
		public double startbasemeasure { get; set; }

		// End Offset
		public double endoffset { get; set; }

		// End Z Offset Referent
		public string endzoffsetref { get; set; }

		// End Asset Feature ID
		public Int64 endassetfeatureid { get; set; }

		// Start Z Offset Referent
		public string startzoffsetref { get; set; }

		// Linked to Attribute
		public string linkedtoattribute { get; set; }

		// End Base Measure
		public double endbasemeasure { get; set; }

		// Linear Specification Id
		public Int64 linearassetspecid { get; set; }

		// End Measure
		public double endmeasure { get; set; }
	}
	
	// MXL_ASSETATTRIBUTE
	public class MaximoAttribute : MaximoBaseEntity
	{

		// Prefix
		public string attrdescprefix { get; set; } 

		// Attribute
		public string assetattrid { get; set; } 

		// ASSETATTRIBUTEID
		public Int64 assetattributeid { get; set; } 

		// Organization
		public string orgid { get; set; } 

		// Unit of Measure
		public string measureunitid { get; set; } 

		// Description
		public string description { get; set; } 

		// Site
		public string siteid { get; set; } 

		// Domain
		public string domainid { get; set; } 

		// Data Type
		public string datatype { get; set; } 
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
		//public List<CROSSOVERDOMAIN> crossoverdomain { get; set; } 

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

}