using System;
using System.Collections.Generic;

namespace MaximoServiceLibrary.model
{
// MXASSET
	public class MaximoAsset : MaximoBaseEntity
	{

		public string href { get; set; }
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
		public double totdowntime { get; set; } 

		// Loop Number
		public string pluscloopnum { get; set; } 

		// COF Score
		public string cof_score { get; set; } 

		// Tool Rate
		public double? toolrate { get; set; } 

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
		public DateTime? statusdate { get; set; } 

		// % READING
		public string pluscsumread { get; set; } 

		// Y1
		public double? y1 { get; set; } 

		// Y2
		public double? y2 { get; set; } 

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
		public bool? changepmstatus { get; set; } 

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
		public bool? removefromactivesp { get; set; } 

		// X2
		public double? x2 { get; set; } 

		// EQ13
		public string eq13 { get; set; } 

		// Inspected By
		public string eq14 { get; set; } 

		// EQ11
		public string eq11 { get; set; } 

		// Repair Facility Site
		public string defaultrepfacsiteid { get; set; } 

		// X1
		public double? x1 { get; set; } 

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
		public DateTime? eq19 { get; set; } 

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
		public DateTime? lof_score_date { get; set; } 

		// Start Measure
		public double? startmeasure { get; set; } 

		// Calendar
		public string calnum { get; set; } 

		// Verified
		public bool eq22 { get; set; } 

		// EQ23
		public DateTime? eq23 { get; set; } 

		// GeoWorx Sync Identifier
		public string geoworxsyncid { get; set; } 

		// EQ24
		public double? eq24 { get; set; } 

		// Warranty Expiration Date
		public DateTime? warrantyexpdate { get; set; } 

		// Feature Class
		public string plussfeatureclass { get; set; } 

		// ROF Score Date
		public DateTime? rof_score_date { get; set; } 

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
		public DateTime? eq6 { get; set; } 

		// EQ5
		public double? eq5 { get; set; } 

		// Asset End
		public string enddescription { get; set; } 

		// Flushing Zone
		public string eq4 { get; set; } 

		// Priority
		public int? priority { get; set; } 

		// Useful Life
		public string eq9 { get; set; } 

		// Asset Tag / Decal #
		public string assettag { get; set; } 

		// Description
		public string description { get; set; } 

		// EQ8
		public string eq8 { get; set; } 

		// Calibration Due Date
		public DateTime? pluscduedate { get; set; } 

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
		public bool? removefromactiveroutes { get; set; } 

		// Physical Location
		public string pluscphyloc { get; set; } 

		// Roll New Status to All Child Assets
		public bool? rolltoallchildren { get; set; } 

		// Global ID
		public string globalid { get; set; } 

		// Asset Start
		public string startdescription { get; set; } 

		// Manufacturer
		public string manufacturer { get; set; } 

		// Owner System ID
		public string ownersysid { get; set; } 

		// Last Audit Date
		public DateTime? lastauditdate { get; set; } 

		// Installation Date
		public DateTime? installdate { get; set; } 

		// %URV
		public string pluscsumurv { get; set; } 

		// Fixed Asset?
		public bool fixedasset { get; set; } 

		// End Measure
		public double? endmeasure { get; set; } 

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
		public bool? depreciationpending { get; set; } 

		// Maintain Hierarchy
		public bool mainthierchy { get; set; } 

		// Model Number
		public string pluscmodelnum { get; set; } 

		// COF Score Date
		public DateTime? cof_score_date { get; set; } 

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
        // todo : review
        public string assetnum { get; set; }

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
		public double? startyoffset { get; set; } 

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
		public double? startoffset { get; set; } 

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
		public double? endzoffset { get; set; } 

		// Mandatory
		public bool mandatory { get; set; } 

		// End Y Offset Referent
		public string endyoffsetref { get; set; } 

		// Start Z Offset
		public double? startzoffset { get; set; } 

		// Start Measure
		public double? startmeasure { get; set; } 

		// Numeric Value
		public double? numvalue { get; set; } 

		// Start Asset Feature ID
		public Int64? startassetfeatureid { get; set; } 

		// Es02
		public string es02 { get; set; } 

		// Es03
		public string es03 { get; set; } 

		// Section
		public string section { get; set; } 

		// Es04
		public DateTime? es04 { get; set; } 

		// End Y Offset
		public double? endyoffset { get; set; } 

		// Es05
		public double? es05 { get; set; } 

		// Es01
		public string es01 { get; set; } 

		// Start Base Measure
		public double? startbasemeasure { get; set; } 

		// End Offset
		public double? endoffset { get; set; } 

		// End Z Offset Referent
		public string endzoffsetref { get; set; } 

		// End Asset Feature ID
		public Int64? endassetfeatureid { get; set; } 

		// Start Z Offset Referent
		public string startzoffsetref { get; set; } 

		// Linked to Attribute
		public string linkedtoattribute { get; set; } 

		// End Base Measure
		public double? endbasemeasure { get; set; } 

		// Linear Specification Id
		public Int64 linearassetspecid { get; set; } 

		// End Measure
		public double? endmeasure { get; set; } 
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
}