using System;
using System.Collections.Generic;

namespace MaximoServiceLibrary.model
{

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
    public class MaximoPersonGroup
    {
        public double persongroupid { get; set; }
        public string _rowstamp { get; set; }
        public string persongroup { get; set; }
        public string description { get; set; }
        public string vehiclenum { get; set; }
        public bool iscrewworkgroup { get; set; }

    }
    public class MaximoPersonGroupMember
    {
        public List<MaximoPersonGroup> member { get; set; }
    }

    public class MaximoWorkOrder{

        public MaximoAsset asset { get; set; }
        public double actoutlabhrs { get; set; }
        public double estatapproutlabhrs { get; set; }
        public bool chargestore { get; set; }
        public bool plussisgis { get; set; }
        public bool runningtrap { get; set; }
        public bool inctasksinsched { get; set; }
        public double estatapprintlabhrs { get; set; }
        public bool waterodor { get; set; }
        public string wonum { get; set; }
        public string woclass { get; set; }
        public bool validated { get; set; }
        public bool woisswap { get; set; }
        public DateTime reportdate { get; set; }
        public double workorderid { get; set; }
        public double estatapprservcost { get; set; }
        public string _rowstamp { get; set; }
        public double outmatcost { get; set; }
        public bool pmcombpelinprog { get; set; }
        public bool run15minutes { get; set; }
        public string orgid { get; set; }
        public double actintlabcost { get; set; }
        public string siteid { get; set; }
        public bool sewerrelieved { get; set; }
        public string href { get; set; }
        public bool apptrequired { get; set; }
        public bool wo14 { get; set; }
        public bool wo13 { get; set; }
        public double outlabcost { get; set; }
        public bool wo18 { get; set; }
        public bool pluscloop { get; set; }
        public bool wo17 { get; set; }
        public DateTime statusdate { get; set; }
        public bool wo16 { get; set; }
        public string firstapprstatus { get; set; }
        public bool wo15 { get; set; }
        public double estlabcost { get; set; }
        public double estdur { get; set; }
        public bool hasfollowupwork { get; set; }
        public bool petroleumodor { get; set; }
        public double estoutlabcost { get; set; }
        public bool snakeline { get; set; }
        public string woeq3 { get; set; }
        public bool los { get; set; }
        public double acttoolcost { get; set; }
        public string worktype { get; set; }
        public bool watercloudy { get; set; }
        public bool statusiface { get; set; }
        public double actmatcost { get; set; }
        public bool watercauserash { get; set; }
        public bool pluscismobile { get; set; }
        public bool ignorediavail { get; set; }
        public bool aos { get; set; }
        public double estoutlabhrs { get; set; }
        public bool debris { get; set; }
        public bool haschildren { get; set; }
        public double esttoolcost { get; set; }
        public bool interruptible { get; set; }
        public string changeby { get; set; }
        public bool dcw_utilitystrike { get; set; }
        public string remarkdesc { get; set; }
        public bool watertreatment { get; set; }
        public string newchildclass { get; set; }
        public bool precipitation { get; set; }
        public string wogroup { get; set; }
        public double estatapproutlabcost { get; set; }
        public DateTime faildate { get; set; }
        public bool personseendoctor { get; set; }
        public bool lms { get; set; }
        public bool particlesinwater { get; set; }
        public bool asbuiltreqd { get; set; }
        public bool parentchgsstatus { get; set; }
        public string assetnum { get; set; }
        public DateTime changedate { get; set; }
        public bool istask { get; set; }
        public bool cleanout { get; set; }
        public double estatapprmatcost { get; set; }
        public double actservcost { get; set; }
        public bool historyflag { get; set; }
        public string lead { get; set; }
        public DateTime actstart { get; set; }
        public double actlabcost { get; set; }
        public double actoutlabcost { get; set; }
        public bool flowactionassist { get; set; }
        public string reportedby { get; set; }
        public string description { get; set; }
        public double estatapprlabcost { get; set; }
        public bool problemthruout { get; set; }
        public double estmatcost { get; set; }
        public bool flowcontrolled { get; set; }
        public bool suspendflow { get; set; }
        public string status { get; set; }
        public bool nestedjpinprocess { get; set; }
        public double estservcost { get; set; }
        public bool ignoresrmavail { get; set; }
        public bool dcw_lwbudgetcheck { get; set; }
        public bool repairlocflag { get; set; }
        public bool waterdiscolored { get; set; }
        public double estintlabhrs { get; set; }
        public string problemcode { get; set; }
        public bool dcw_sendmatl2lw { get; set; }
        public bool ams { get; set; }
        public bool woacceptscharges { get; set; }
        public bool dcw_cbassigned { get; set; }
        public bool pmcombpelenabled { get; set; }
        public double actintlabhrs { get; set; }
        public string persongroup { get; set; }
        public bool wo19 { get; set; }
        public double estintlabcost { get; set; }
        public double actlabhrs { get; set; }
        public string failurecode { get; set; }
        public double outtoolcost { get; set; }
        public bool wo20 { get; set; }
        public double estlabhrs { get; set; }
        public bool asbuiltrecd { get; set; }
        public bool jetline { get; set; }
        public double estatapprlabhrs { get; set; }
        public string locationdetails { get; set; }
        public double estatapprtoolcost { get; set; }
        public DateTime actfinish { get; set; }
        public string receivedvia { get; set; }
        public bool snaketosewer { get; set; }
        public bool watertaste { get; set; }
        public bool downtime { get; set; }
        public bool reqasstdwntime { get; set; }
        public bool missutilityemerg { get; set; }
        public string service { get; set; }
        public double estatapprintlabcost { get; set; }
        public bool disabled { get; set; }
        public DateTime lastcopylinkdate { get; set; }
        public DateTime schedstart { get; set; }
        public string pluscfrequnit { get; set; }
        public string pmnum { get; set; }
        public double complexity { get; set; }
        public double pluscfrequency { get; set; }
        public DateTime targcompdate { get; set; }
        public string classstructureid { get; set; }
        public DateTime pmnextduedate { get; set; }
        public DateTime pmduedate { get; set; }
        public string glaccount { get; set; }
        public DateTime targstartdate { get; set; }
    }

    public class MaximoWorkOrderList
    {
        public List<MaximoWorkOrder> member { get; set; }
    }

    public class MaximoAsset
    {
        public string assetnum { get; set; }
        public DateTime changedate { get; set; }
        public bool plussisgis { get; set; }
        public bool tloampartition { get; set; }
        public double totdowntime { get; set; }
        public bool autowogen { get; set; }
        public string assetusercust_collectionref { get; set; }
        public string _rowstamp { get; set; }
        public string orgid { get; set; }
        public string assettag { get; set; }
        public string description { get; set; }
        public string siteid { get; set; }
        public string href { get; set; }
        public bool islinear { get; set; }
        public bool isrunning { get; set; }
        public string status { get; set; }
        public bool removefromactiveroutes { get; set; }
        public bool returnedtovendor { get; set; }
        public bool rolltoallchildren { get; set; }
        public double ytdcost { get; set; }
        public string globalid { get; set; }
        public double unchargedcost { get; set; }
        public bool fixedasset { get; set; }
        public double assetid { get; set; }
        public string mapnum { get; set; }
        public double totunchargedcost { get; set; }
        public bool plusciscontam { get; set; }
        public bool pluscpmextdate { get; set; }
        public double totalcost { get; set; }
        public bool changepmstatus { get; set; }
        public double purchaseprice { get; set; }
        public string hierarchypath { get; set; }
        public string newsite { get; set; }
        public double budgetcost { get; set; }
        public bool children { get; set; }
        public string assetspec_collectionref { get; set; }
        public string failurecode { get; set; }
        public bool pluscisinhousecal { get; set; }
        public bool removefromactivesp { get; set; }
        public bool pluscsolution { get; set; }
        public bool mainthierchy { get; set; }
        public string itemsetid { get; set; }
        public bool pluscismte { get; set; }
        public string glaccount { get; set; }
        public string changeby { get; set; }
        public string assetmntskd_collectionref { get; set; }
        public double replacecost { get; set; }
        public bool eq22 { get; set; }
        public bool iscalibration { get; set; }
        public string geoworxsyncid { get; set; }
        public double invcost { get; set; }
        public bool moved { get; set; }
        public string plussfeatureclass { get; set; }
        public string assetopskd_collectionref { get; set; }
        public string assetmeter_collectionref { get; set; }
        public List<MaximoAssetSpec> assetspec { get; set; }
        public bool disabled { get; set; }
    }

    public class MaximoAssetMember
    {
        public List<MaximoAsset> member { get; set; }
    }

    public class MaximoAssetSpec
    {

        public string alnvalue { get; set; }
        public DateTime changedate { get; set; }
        public bool continuous { get; set; }
        public string classstructureid { get; set; }
        public string changeby { get; set; }
        public bool inheritedfromitem { get; set; }
        public bool mandatory { get; set; }
        public string localref { get; set; }
        public double numvalue { get; set; }
        public bool itemspecvalchanged { get; set; }
        public double displaysequence { get; set; }
        public string _rowstamp { get; set; }
        public string assetattrid { get; set; }
        public string orgid { get; set; }
        public string href { get; set; }
        public double assetspecid { get; set; }
        public double linearassetspecid { get; set; }
    }    
}