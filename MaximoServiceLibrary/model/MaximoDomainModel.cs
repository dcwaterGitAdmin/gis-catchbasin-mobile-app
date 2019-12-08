using System;
using System.Collections.Generic;
using LocalDBLibrary.model;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace MaximoServiceLibrary.model
{
	public class MaximoBaseEntity : BasePersistenceEntity
	{
		// _rowstamp
		public string _rowstamp { get; set; }

		// _rowstamp
		//public string href;

		//localref
		//public string localref { get; set; }
	}

	/**
	 * this class combines relevant data for a specific user, like the current selected crew id, etc.
	 */
	public class UserPreferences
	{

		public string selectedPersonGroup { get; set; }

		public DateTime lastSyncTime { get; set; }

		public MaximoPersonGroup setting {get{
				return AppContext.personGroupRepository.findOne(this.selectedPersonGroup);
			} }

	}

	public class MaximoUser : MaximoBaseEntity
	{
		public UserPreferences userPreferences { get; set; }
		
		public List<MaximoPersonGroup> personGroupList { get; set; }
		
		public string persongroup { get; set; }

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
		public string _rowstamp { get; set; }
		public string persongroup { get; set; }
		public string description { get; set; }
		public string vehiclenum { get; set; }
		public bool iscrewworkgroup { get; set; }
		public string persongroupteam_collectionref { get; set; }
		public List<MaximoPersonGroupTeamMember> persongroupteam { get; set; }
		public string langcode { get; set; }
		public string href { get; set; }
		public bool hasld { get; set; }

		[JsonIgnore]
		public string leadMan { get; set; }
		[JsonIgnore]
		public string secondMan { get; set; }
		[JsonIgnore]
		public string driverMan { get; set; }
		[JsonIgnore]
		public MaximoInventory vehicle { get; set; }
	}


	public class MaximoPersonGroupTeamMember
	{
		public bool groupdefault { get; set; }
		public int persongroupteamid { get; set; }
		public int resppartyseq { get; set; }
		public string _rowstamp { get; set; }
		public string respparty { get; set; }
		public bool sitedefault { get; set; }
		public int resppartygroupseq { get; set; }
		public string resppartygroup { get; set; }
		public string localref { get; set; }
		public bool orgdefault { get; set; }
		public string href { get; set; }
		public string dcw_designation { get; set; }
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

	public class MaximoLabTrans : MaximoBaseEntity
	{
		public string assetnum { get; set; }
		public double payrate { get; set; }
		public string craft { get; set; }
		public DateTime transdate { get; set; }
		public string gldebitacct { get; set; }
		public bool rollup { get; set; }
		public DateTime startdateentered { get; set; }
		public double regularhrs { get; set; }
		public bool lt7 { get; set; }
		public string laborcode { get; set; }
		public double linecost { get; set; }
		public string orgid { get; set; }
		public string enterby { get; set; }
		public string refwo { get; set; }
		public string siteid { get; set; }
		public DateTime starttimeentered { get; set; }
		public bool enteredastask { get; set; }
		public string href { get; set; }
		public DateTime finishtimeentered { get; set; }
		public string transtype { get; set; }
		public int labtransid { get; set; }
		public bool dcw_truckdriver { get; set; }
		public bool dcw_trucksecond { get; set; }
		public bool genapprservreceipt { get; set; }
		public DateTime enterdate { get; set; }
		public bool dcw_trucklead { get; set; }
		public string dcw_trucknum { get; set; }
		public DateTime finishdateentered { get; set; }
		public bool outside { get; set; }

		public virtual TimeSpan duration { get { return getDuration(); } }
		public virtual DateTime startDate { get { return getStartDate(); } }
		public virtual DateTime finishDate { get { return getFinishDate(); } }

		public TimeSpan getDuration()
		{
			return finishdateentered + finishtimeentered.TimeOfDay - startdateentered - starttimeentered.TimeOfDay;
		}

		public DateTime getStartDate()
		{
			return  startdateentered + starttimeentered.TimeOfDay;
		}

		public DateTime getFinishDate()
		{
			return finishdateentered + finishtimeentered.TimeOfDay ;
		}
	}


	public class MaximoToolTrans : MaximoBaseEntity
	{

		public int tooltransid { get; set; }
		public string assetnum { get; set; }
		public double linecost2 { get; set; }
		public DateTime transdate { get; set; }
		public double toolhrs { get; set; }
		public string gldebitacct { get; set; }
		public bool rollup { get; set; }
		public double exchangerate2 { get; set; }
		public string langcode { get; set; }
		public int toolqty { get; set; }
		public double linecost { get; set; }
		public double toolrate { get; set; }
		public DateTime enterdate { get; set; }
		public string orgid { get; set; }
		public string itemsetid { get; set; }
		public string itemnum { get; set; }
		public string enterby { get; set; }
		public string refwo { get; set; }
		public string siteid { get; set; }
		public bool enteredastask { get; set; }
		public string href { get; set; }
		public bool hasld { get; set; }
		public bool outside { get; set; }
	}

	public class Format : MaximoBaseEntity
	{
		public string label { get; set; }
	}

	public  class MaximoDocument : MaximoBaseEntity
	{
		public int docinfoid { get; set; }
		public bool addinfo { get; set; }
		public string docType { get; set; }
		public string changeby { get; set; }
		public string createby { get; set; }
		public Format format { get; set; }
		public int ownerid { get; set; }
		public string urlType { get; set; }
		public bool upload { get; set; }
		public int attachmentSize { get; set; }
		public DateTime modified { get; set; }
		public DateTime created { get; set; }
		public string description { get; set; }
		public string fileName { get; set; }
		public string ownertable { get; set; }
		public string href { get; set; }

		[LiteDB.BsonIgnore]
		public virtual BitmapImage BitmapImage
		{
			get
			{
				return new BitmapImage(new Uri(description));
			}
		}
	}


	public class MaximoPerson
	{
		public DateTime statusdate { get; set; }
		public string status { get; set; }
		public string department { get; set; }
		public int deviceclass { get; set; }
		public string locationsite { get; set; }
		public string localref { get; set; }
		public string transemailelection { get; set; }
		public string lastname { get; set; }
		public string firstname { get; set; }
		public bool acceptingwfmail { get; set; }
		public string _rowstamp { get; set; }
		public string locationorg { get; set; }
		public string personid { get; set; }
		public int personuid { get; set; }
		public bool loctoservreq { get; set; }
		public string wfmailelection { get; set; }
		public string href { get; set; }
		public string displayname { get; set; }
	}

	public class MaximoLaborCraftRate
	{
		public string craft { get; set; }
		public string _rowstamp { get; set; }
		public double rate { get; set; }
		public int laborcraftrateid { get; set; }
		public string localref { get; set; }
		public bool defaultcraft { get; set; }
		public bool inherit { get; set; }
		public string href { get; set; }
	}

	public class MaximoLabor : MaximoBaseEntity
	{
		public string laborcraftrate_collectionref { get; set; }
		public List<MaximoPerson> person { get; set; }
		public double reportedhrs { get; set; }
		public double ytdothrs { get; set; }
		public double ytdhrsrefused { get; set; }
		public string labinventorysite { get; set; }
		public string status { get; set; }
		public string laborcode { get; set; }
		public string lbslocation_collectionref { get; set; }
		public string worksite { get; set; }
		public string _rowstamp { get; set; }
		public string orgid { get; set; }
		public string person_collectionref { get; set; }
		public int laborid { get; set; }
		public string personid { get; set; }
		public double availfactor { get; set; }
		public bool lbsdatafromwo { get; set; }
		public bool la10 { get; set; }
		public List<MaximoLaborCraftRate> laborcraftrate { get; set; }
		public string href { get; set; }
	}

	public class MaximoInventory : MaximoBaseEntity
	{
		public double issue2yrago { get; set; }
		public string sendersysid { get; set; }
		public string location { get; set; }
		public string invcost_collectionref { get; set; }
		public double curbal { get; set; }
		public double sstock { get; set; }
		public string controlacc { get; set; }
		public string orderunit { get; set; }
		public double avblbalance { get; set; }
		public double maxlevel { get; set; }
		public string _rowstamp { get; set; }
		public string orgid { get; set; }
		public double reservedqty { get; set; }
		public string itemsetid { get; set; }
		public string itemnum { get; set; }
		public string siteid { get; set; }
		public double minlevel { get; set; }
		public string href { get; set; }
		public bool @internal { get; set; }
		public int inventoryid { get; set; }
		public int ccf { get; set; }
		public string abctype { get; set; }
		public string itemtype { get; set; }
		public bool hardresissue { get; set; }
		public DateTime statusdate { get; set; }
		public string status { get; set; }
		public int deliverytime { get; set; }
		public string vendor { get; set; }
		public bool consignment { get; set; }
		public double issue1yrago { get; set; }
		public string binnum { get; set; }
		public bool reorder { get; set; }
		public string il1 { get; set; }
		public List<Invcost> invcost { get; set; }
		public double orderqty { get; set; }
		public string issueunit { get; set; }
		public DateTime lastissuedate { get; set; }
		public double issueytd { get; set; }
		public bool statusiface { get; set; }
		public double issue3yrago { get; set; }
		public string costtype { get; set; }
	}

	public class Invcost
	{
		public string _rowstamp { get; set; }
		public double stdcost { get; set; }
		public string orgid { get; set; }
		public int condrate { get; set; }
		public double avgcost { get; set; }
		public string localref { get; set; }
		public int invcostid { get; set; }
		public double lastcost { get; set; }
		public string controlacc { get; set; }
		public string href { get; set; }
	}
}