using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using DCWaterMobile.LocalData.Models;
using DCWaterMobile.MaximoService;
using DCWaterMobile.MaximoService.MaxRest;

namespace DCWaterMobile.LocalData
{
    public static class ReverseMapper
    {
        internal static void PopulateWorkorder(CompositeWorkorder compositeWorkorder, WORKORDER localWorkorder )
        {
            var refWorkorder = compositeWorkorder.WORKORDER;
            refWorkorder.WONUM = (!String.IsNullOrEmpty(localWorkorder.WONUM)) ? localWorkorder.WONUM : null;
            refWorkorder.PARENT = (!String.IsNullOrEmpty(localWorkorder.PARENT)) ? localWorkorder.PARENT : null;
            //if (!String.IsNullOrEmpty(localWorkorder.STATUS))
            //{
            //    refWorkorder.STATUS = new WORKORDERSTATUS{maxvalue=localWorkorder.STATUS,Value = localWorkorder.STATUS};
            //}
            //refWorkorder.STATUSDATE = localWorkorder.STATUSDATE;
            refWorkorder.WORKTYPE = (!String.IsNullOrEmpty(localWorkorder.WORKTYPE)) ? localWorkorder.WORKTYPE : null;
            refWorkorder.LEADCRAFT = (!String.IsNullOrEmpty(localWorkorder.LEADCRAFT)) ? localWorkorder.LEADCRAFT : null;
            refWorkorder.DESCRIPTION = (!String.IsNullOrEmpty(localWorkorder.DESCRIPTION)) ? localWorkorder.DESCRIPTION : null;
            refWorkorder.LOCATION = (!String.IsNullOrEmpty(localWorkorder.LOCATION)) ? localWorkorder.LOCATION : null;
            refWorkorder.JPNUM = (!String.IsNullOrEmpty(localWorkorder.JPNUM)) ? localWorkorder.JPNUM : null;
            refWorkorder.FAILDATE = (localWorkorder.FAILDATE.HasValue) ? localWorkorder.FAILDATE : null;
            refWorkorder.CHANGEBY = (!String.IsNullOrEmpty(localWorkorder.CHANGEBY)) ? localWorkorder.CHANGEBY : null;
            refWorkorder.CHANGEDATE = (localWorkorder.CHANGEDATE.HasValue) ? localWorkorder.CHANGEDATE.Value : DateTime.Now;
            refWorkorder.ESTDUR = Convert.ToDecimal(localWorkorder.ESTDUR);
            refWorkorder.ESTLABHRS = Convert.ToDecimal(localWorkorder.ESTLABHRS);
            refWorkorder.ESTMATCOST = Convert.ToDecimal(localWorkorder.ESTMATCOST);
            refWorkorder.ESTLABCOST = Convert.ToDecimal(localWorkorder.ESTLABCOST);
            refWorkorder.ESTTOOLCOST = Convert.ToDecimal(localWorkorder.ESTTOOLCOST);
            refWorkorder.PMNUM = (!String.IsNullOrEmpty(localWorkorder.PMNUM)) ? localWorkorder.PMNUM : null;
            refWorkorder.ACTLABHRS = Convert.ToDecimal(localWorkorder.ACTLABHRS);
            refWorkorder.ACTMATCOST = Convert.ToDecimal(localWorkorder.ACTMATCOST);
            refWorkorder.ACTLABCOST = Convert.ToDecimal(localWorkorder.ACTLABCOST);
            refWorkorder.ACTTOOLCOST = Convert.ToDecimal(localWorkorder.ACTTOOLCOST);
            refWorkorder.HASCHILDREN = Convert.ToByte(localWorkorder.HASCHILDREN);
            refWorkorder.OUTLABCOST = Convert.ToDecimal(localWorkorder.OUTLABCOST);
            refWorkorder.OUTMATCOST = Convert.ToDecimal(localWorkorder.OUTMATCOST);
            refWorkorder.OUTTOOLCOST = Convert.ToDecimal(localWorkorder.OUTTOOLCOST);
            refWorkorder.HISTORYFLAG = Convert.ToByte(localWorkorder.HISTORYFLAG);
            refWorkorder.CONTRACT = (!String.IsNullOrEmpty(localWorkorder.CONTRACT)) ? localWorkorder.CONTRACT : null;
            refWorkorder.WOPRIORITY = (localWorkorder.WOPRIORITY.HasValue) ? localWorkorder.WOPRIORITY.Value : (long?)null;
            refWorkorder.TARGCOMPDATE = (localWorkorder.TARGCOMPDATE.HasValue) ? localWorkorder.TARGCOMPDATE : null;
            refWorkorder.TARGSTARTDATE = (localWorkorder.TARGSTARTDATE.HasValue) ? localWorkorder.TARGSTARTDATE : null;
            refWorkorder.WOEQ1 = (!String.IsNullOrEmpty(localWorkorder.WOEQ1)) ? localWorkorder.WOEQ1 : null;
            refWorkorder.WOEQ2 = (!String.IsNullOrEmpty(localWorkorder.WOEQ2)) ? localWorkorder.WOEQ2 : null;
            refWorkorder.WOEQ3 = (!String.IsNullOrEmpty(localWorkorder.WOEQ3)) ? localWorkorder.WOEQ3 : null;
            refWorkorder.WOEQ4 = (!String.IsNullOrEmpty(localWorkorder.WOEQ4)) ? localWorkorder.WOEQ4 : null;
            refWorkorder.WOEQ5 = (localWorkorder.WOEQ5.HasValue) ? Convert.ToDecimal(localWorkorder.WOEQ5) : (decimal?)null;
            refWorkorder.WOEQ6 = (localWorkorder.WOEQ6.HasValue) ? localWorkorder.WOEQ6 : null;
            refWorkorder.WOEQ7 = (!String.IsNullOrEmpty(localWorkorder.WOEQ7)) ? localWorkorder.WOEQ7 : null;
            refWorkorder.WOEQ8 = (!String.IsNullOrEmpty(localWorkorder.WOEQ8)) ? localWorkorder.WOEQ8 : null;
            refWorkorder.WOEQ9 = (!String.IsNullOrEmpty(localWorkorder.WOEQ9)) ? localWorkorder.WOEQ9 : null;
            refWorkorder.WOEQ10 = (!String.IsNullOrEmpty(localWorkorder.WOEQ10)) ? localWorkorder.WOEQ10 : null;
            refWorkorder.WOEQ11 = (!String.IsNullOrEmpty(localWorkorder.WOEQ11)) ? localWorkorder.WOEQ11 : null;
            refWorkorder.WOEQ12 = (!String.IsNullOrEmpty(localWorkorder.WOEQ12)) ? localWorkorder.WOEQ12 : null;
            refWorkorder.WO1 = (!String.IsNullOrEmpty(localWorkorder.WO1)) ? localWorkorder.WO1 : null;
            refWorkorder.WO3 = (!String.IsNullOrEmpty(localWorkorder.WO3)) ? localWorkorder.WO3 : null;
            refWorkorder.WO4 = (!String.IsNullOrEmpty(localWorkorder.WO4)) ? localWorkorder.WO4 : null;
            refWorkorder.WO7 = (!String.IsNullOrEmpty(localWorkorder.WO7)) ? localWorkorder.WO7 : null;
            refWorkorder.WO9 = (!String.IsNullOrEmpty(localWorkorder.WO9)) ? localWorkorder.WO9 : null;
            refWorkorder.WO10 = (!String.IsNullOrEmpty(localWorkorder.WO10)) ? localWorkorder.WO10 : null;
            refWorkorder.REPORTEDBY = (!String.IsNullOrEmpty(localWorkorder.REPORTEDBY)) ? localWorkorder.REPORTEDBY : null;
            refWorkorder.REPORTDATE = (localWorkorder.REPORTDATE.HasValue) ? localWorkorder.REPORTDATE.Value: DateTime.Now ;
            refWorkorder.PHONE = (!String.IsNullOrEmpty(localWorkorder.PHONE)) ? localWorkorder.PHONE : null;
            refWorkorder.PROBLEMCODE = (!String.IsNullOrEmpty(localWorkorder.PROBLEMCODE)) ? localWorkorder.PROBLEMCODE : null;
            refWorkorder.CALENDAR = (!String.IsNullOrEmpty(localWorkorder.CALENDAR)) ? localWorkorder.CALENDAR : null;
            refWorkorder.DOWNTIME = Convert.ToByte(localWorkorder.DOWNTIME);
            refWorkorder.ACTSTART = (localWorkorder.ACTSTART.HasValue) ? localWorkorder.ACTSTART : null;
            refWorkorder.ACTFINISH = (localWorkorder.ACTFINISH.HasValue) ? localWorkorder.ACTFINISH : null;
            refWorkorder.SCHEDSTART = (localWorkorder.SCHEDSTART.HasValue) ? localWorkorder.SCHEDSTART : null;
            refWorkorder.SCHEDFINISH = (localWorkorder.SCHEDFINISH.HasValue) ? localWorkorder.SCHEDFINISH : null;
            refWorkorder.REMDUR = (localWorkorder.REMDUR.HasValue) ? Convert.ToDecimal(localWorkorder.REMDUR) : (decimal?)null;
            refWorkorder.CREWID = (!String.IsNullOrEmpty(localWorkorder.CREWID)) ? localWorkorder.CREWID : null;
            refWorkorder.SUPERVISOR = (!String.IsNullOrEmpty(localWorkorder.SUPERVISOR)) ? localWorkorder.SUPERVISOR : null;
            refWorkorder.WOEQ13 = (localWorkorder.WOEQ13.HasValue) ? localWorkorder.WOEQ13 : null;
            refWorkorder.WOEQ14 = (localWorkorder.WOEQ14.HasValue) ? Convert.ToDecimal(localWorkorder.WOEQ14) : (decimal?)null;
            refWorkorder.WOJP1 = (!String.IsNullOrEmpty(localWorkorder.WOJP1)) ? localWorkorder.WOJP1 : null;
            refWorkorder.WOJP2 = (!String.IsNullOrEmpty(localWorkorder.WOJP2)) ? localWorkorder.WOJP2 : null;
            refWorkorder.WOJP3 = (!String.IsNullOrEmpty(localWorkorder.WOJP3)) ? localWorkorder.WOJP3 : null;
            refWorkorder.WOJP4 = (localWorkorder.WOJP4.HasValue) ? Convert.ToDecimal(localWorkorder.WOJP4) : (decimal?)null;
            refWorkorder.WOJP5 = (localWorkorder.WOJP5.HasValue) ? localWorkorder.WOJP5 : null;
            refWorkorder.WOL1 = (!String.IsNullOrEmpty(localWorkorder.WOL1)) ? localWorkorder.WOL1 : null;
            refWorkorder.WOL2 = (!String.IsNullOrEmpty(localWorkorder.WOL2)) ? localWorkorder.WOL2 : null;
            refWorkorder.WOL3 = (localWorkorder.WOL3.HasValue) ? Convert.ToDecimal(localWorkorder.WOL3) : (decimal?)null;
            refWorkorder.WOL4 = (localWorkorder.WOL4.HasValue) ? localWorkorder.WOL4 : null;
            refWorkorder.WOLABLNK = (!String.IsNullOrEmpty(localWorkorder.WOLABLNK)) ? localWorkorder.WOLABLNK : null;
            refWorkorder.RESPONDBY = (localWorkorder.RESPONDBY.HasValue) ? localWorkorder.RESPONDBY : null;
            refWorkorder.CALCPRIORITY = (localWorkorder.CALCPRIORITY.HasValue) ? localWorkorder.CALCPRIORITY.Value : (long?)null;
            refWorkorder.CHARGESTORE = Convert.ToByte(localWorkorder.CHARGESTORE);
            refWorkorder.FAILURECODE = (!String.IsNullOrEmpty(localWorkorder.FAILURECODE)) ? localWorkorder.FAILURECODE : null;
            refWorkorder.WOLO1 = (!String.IsNullOrEmpty(localWorkorder.WOLO1)) ? localWorkorder.WOLO1 : null;
            refWorkorder.WOLO2 = (!String.IsNullOrEmpty(localWorkorder.WOLO2)) ? localWorkorder.WOLO2 : null;
            refWorkorder.WOLO3 = (!String.IsNullOrEmpty(localWorkorder.WOLO3)) ? localWorkorder.WOLO3 : null;
            refWorkorder.WOLO4 = (!String.IsNullOrEmpty(localWorkorder.WOLO4)) ? localWorkorder.WOLO4 : null;
            refWorkorder.WOLO5 = (!String.IsNullOrEmpty(localWorkorder.WOLO5)) ? localWorkorder.WOLO5 : null;
            refWorkorder.WOLO6 = (localWorkorder.WOLO6.HasValue) ? Convert.ToByte(localWorkorder.WOLO6) : (decimal?)null;
            refWorkorder.WOLO7 = (localWorkorder.WOLO7.HasValue) ? localWorkorder.WOLO7 : null;
            refWorkorder.WOLO8 = (localWorkorder.WOLO8.HasValue) ? Convert.ToByte(localWorkorder.WOLO8) : (decimal?)null;
            refWorkorder.WOLO9 = (!String.IsNullOrEmpty(localWorkorder.WOLO9)) ? localWorkorder.WOLO9 : null;
            refWorkorder.WOLO10 = (localWorkorder.WOLO10.HasValue) ? localWorkorder.WOLO10.Value : (long?)null;
            if (!String.IsNullOrEmpty(localWorkorder.GLACCOUNT))
            {
                refWorkorder.GLACCOUNT = new WORKORDERGLACCOUNT
                {
                    GLCOMP = new WORKORDERGLACCOUNTGLCOMP{glorder=0,Value=0},
                    VALUE = localWorkorder.GLACCOUNT
                };
            }
            refWorkorder.ESTSERVCOST = Convert.ToDecimal( localWorkorder.ESTSERVCOST);
            refWorkorder.ACTSERVCOST = Convert.ToDecimal(localWorkorder.ACTSERVCOST);
            refWorkorder.DISABLED = Convert.ToByte(localWorkorder.DISABLED);
            refWorkorder.ESTATAPPRLABHRS = Convert.ToDecimal(localWorkorder.ESTATAPPRLABHRS);
            refWorkorder.ESTATAPPRLABCOST = Convert.ToDecimal(localWorkorder.ESTATAPPRLABCOST);
            refWorkorder.ESTATAPPRMATCOST = Convert.ToDecimal(localWorkorder.ESTATAPPRMATCOST);
            refWorkorder.ESTATAPPRTOOLCOST = Convert.ToDecimal(localWorkorder.ESTATAPPRTOOLCOST);
            refWorkorder.ESTATAPPRSERVCOST = Convert.ToDecimal(localWorkorder.ESTATAPPRSERVCOST);
            refWorkorder.WOSEQUENCE = (localWorkorder.WOSEQUENCE.HasValue) ? localWorkorder.WOSEQUENCE.Value : (long?)null;
            refWorkorder.HASFOLLOWUPWORK = Convert.ToByte(localWorkorder.HASFOLLOWUPWORK);
            refWorkorder.WORTS1 = (!String.IsNullOrEmpty(localWorkorder.WORTS1)) ? localWorkorder.WORTS1 : null;
            refWorkorder.WORTS2 = (!String.IsNullOrEmpty(localWorkorder.WORTS2)) ? localWorkorder.WORTS2 : null;
            refWorkorder.WORTS3 = (!String.IsNullOrEmpty(localWorkorder.WORTS3)) ? localWorkorder.WORTS3 : null;
            refWorkorder.WORTS4 = (localWorkorder.WORTS4.HasValue) ? localWorkorder.WORTS4 : null;
            refWorkorder.WORTS5 = (localWorkorder.WORTS5.HasValue) ? Convert.ToDecimal(localWorkorder.WORTS5) : (decimal?)null;
            refWorkorder.SOURCESYSID = (!String.IsNullOrEmpty(localWorkorder.SOURCESYSID)) ? localWorkorder.SOURCESYSID : null;
            refWorkorder.OWNERSYSID = (!String.IsNullOrEmpty(localWorkorder.OWNERSYSID)) ? localWorkorder.OWNERSYSID : null;
            refWorkorder.PMDUEDATE = (localWorkorder.PMDUEDATE.HasValue) ? localWorkorder.PMDUEDATE : null;
            refWorkorder.PMEXTDATE = (localWorkorder.PMEXTDATE.HasValue) ? localWorkorder.PMEXTDATE : null;
            refWorkorder.PMNEXTDUEDATE = (localWorkorder.PMNEXTDUEDATE.HasValue) ? localWorkorder.PMNEXTDUEDATE : null;
            refWorkorder.WORKLOCATION = (!String.IsNullOrEmpty(localWorkorder.WORKLOCATION)) ? localWorkorder.WORKLOCATION : null;
            refWorkorder.WO11 = (!String.IsNullOrEmpty(localWorkorder.WO11)) ? localWorkorder.WO11 : null;
            refWorkorder.WO13 = Convert.ToByte(localWorkorder.WO13);
            refWorkorder.WO14 = Convert.ToByte(localWorkorder.WO14);
            refWorkorder.WO15 = Convert.ToByte(localWorkorder.WO15);
            refWorkorder.WO16 = Convert.ToByte(localWorkorder.WO16);
            refWorkorder.WO17 = Convert.ToByte(localWorkorder.WO17);
            refWorkorder.WO18 = Convert.ToByte(localWorkorder.WO18);
            refWorkorder.WO19 = Convert.ToByte(localWorkorder.WO19);
            refWorkorder.WO20 = Convert.ToByte(localWorkorder.WO20);
            refWorkorder.EXTERNALREFID = (!String.IsNullOrEmpty(localWorkorder.EXTERNALREFID)) ? localWorkorder.EXTERNALREFID : null;
            refWorkorder.SENDERSYSID = (!String.IsNullOrEmpty(localWorkorder.SENDERSYSID)) ? localWorkorder.SENDERSYSID : null;
            refWorkorder.FINCNTRLID = (!String.IsNullOrEmpty(localWorkorder.FINCNTRLID)) ? localWorkorder.FINCNTRLID : null;
            refWorkorder.GENERATEDFORPO = (!String.IsNullOrEmpty(localWorkorder.GENERATEDFORPO)) ? localWorkorder.GENERATEDFORPO : null;
            refWorkorder.GENFORPOLINEID = (localWorkorder.GENFORPOLINEID.HasValue) ? localWorkorder.GENFORPOLINEID.Value : (long?)null;
            refWorkorder.ORGID = (!String.IsNullOrEmpty(localWorkorder.ORGID)) ? localWorkorder.ORGID : null;
            refWorkorder.SITEID = (!String.IsNullOrEmpty(localWorkorder.SITEID)) ? localWorkorder.SITEID : null;
            refWorkorder.TASKID = (localWorkorder.TASKID.HasValue) ? localWorkorder.TASKID.Value : (long?)null;
            refWorkorder.INSPECTOR = (!String.IsNullOrEmpty(localWorkorder.INSPECTOR)) ? localWorkorder.INSPECTOR : null;
            refWorkorder.MEASUREMENTVALUE = (localWorkorder.MEASUREMENTVALUE.HasValue) ? Convert.ToDecimal(localWorkorder.MEASUREMENTVALUE) : (decimal?)null;
            refWorkorder.MEASUREDATE = (localWorkorder.MEASUREDATE.HasValue) ? localWorkorder.MEASUREDATE : null;
            refWorkorder.OBSERVATION = (!String.IsNullOrEmpty(localWorkorder.OBSERVATION)) ? localWorkorder.OBSERVATION : null;
            refWorkorder.POINTNUM = (!String.IsNullOrEmpty(localWorkorder.POINTNUM)) ? localWorkorder.POINTNUM : null;
            refWorkorder.WOJO1 = (!String.IsNullOrEmpty(localWorkorder.WOJO1)) ? localWorkorder.WOJO1 : null;
            refWorkorder.WOJO2 = (!String.IsNullOrEmpty(localWorkorder.WOJO2)) ? localWorkorder.WOJO2 : null;
            refWorkorder.WOJO3 = (!String.IsNullOrEmpty(localWorkorder.WOJO3)) ? localWorkorder.WOJO3 : null;
            refWorkorder.WOJO4 = (localWorkorder.WOJO4.HasValue) ? Convert.ToDecimal(localWorkorder.WOJO4) : (decimal?)null;
            refWorkorder.WOJO5 = (!String.IsNullOrEmpty(localWorkorder.WOJO5)) ? localWorkorder.WOJO5 : null;
            refWorkorder.WOJO6 = (!String.IsNullOrEmpty(localWorkorder.WOJO6)) ? localWorkorder.WOJO6 : null;
            refWorkorder.WOJO7 = (!String.IsNullOrEmpty(localWorkorder.WOJO7)) ? localWorkorder.WOJO7 : null;
            refWorkorder.WOJO8 = (!String.IsNullOrEmpty(localWorkorder.WOJO8)) ? localWorkorder.WOJO8 : null;
            refWorkorder.ISTASK = Convert.ToByte(localWorkorder.ISTASK);
            refWorkorder.SERVICE = (!String.IsNullOrEmpty(localWorkorder.SERVICE)) ? localWorkorder.SERVICE : null;
            refWorkorder.ORIGPROBLEMTYPE = (!String.IsNullOrEmpty(localWorkorder.ORIGPROBLEMTYPE)) ? localWorkorder.ORIGPROBLEMTYPE : null;
            refWorkorder.CISNUM = (!String.IsNullOrEmpty(localWorkorder.CISNUM)) ? localWorkorder.CISNUM : null;
            refWorkorder.MISSUTILITYDATE = (localWorkorder.MISSUTILITYDATE.HasValue) ? localWorkorder.MISSUTILITYDATE : null;
            refWorkorder.MISSUTILITYNUM = (!String.IsNullOrEmpty(localWorkorder.MISSUTILITYNUM)) ? localWorkorder.MISSUTILITYNUM : null;
            refWorkorder.MISSUTILITYEMERG = Convert.ToByte(localWorkorder.MISSUTILITYEMERG);
            refWorkorder.MAPNUM = (!String.IsNullOrEmpty(localWorkorder.MAPNUM)) ? localWorkorder.MAPNUM : null;
            refWorkorder.RECEIVEDVIA = (!String.IsNullOrEmpty(localWorkorder.RECEIVEDVIA)) ? localWorkorder.RECEIVEDVIA : null;
            refWorkorder.LOCATIONDETAILS = (!String.IsNullOrEmpty(localWorkorder.LOCATIONDETAILS)) ? localWorkorder.LOCATIONDETAILS : null;
            refWorkorder.OTHERCONTACT = (!String.IsNullOrEmpty(localWorkorder.OTHERCONTACT)) ? localWorkorder.OTHERCONTACT : null;
            refWorkorder.WATERDISCOLORED = Convert.ToByte(localWorkorder.WATERDISCOLORED);
            refWorkorder.WATERCOLOR = (!String.IsNullOrEmpty(localWorkorder.WATERCOLOR)) ? localWorkorder.WATERCOLOR : null;
            refWorkorder.DISCOLORHOTCOLD = (!String.IsNullOrEmpty(localWorkorder.DISCOLORHOTCOLD)) ? localWorkorder.DISCOLORHOTCOLD : null;
            refWorkorder.RUN15MINUTES = Convert.ToByte(localWorkorder.RUN15MINUTES);
            refWorkorder.PARTICLESINWATER = Convert.ToByte(localWorkorder.PARTICLESINWATER);
            refWorkorder.PARTICLECOLOR = (!String.IsNullOrEmpty(localWorkorder.PARTICLECOLOR)) ? localWorkorder.PARTICLECOLOR : null;
            refWorkorder.WATERCLOUDY = Convert.ToByte(localWorkorder.WATERCLOUDY);
            refWorkorder.WATERODOR = Convert.ToByte(localWorkorder.WATERODOR);
            refWorkorder.TYPEODOR = (!String.IsNullOrEmpty(localWorkorder.TYPEODOR)) ? localWorkorder.TYPEODOR : null;
            refWorkorder.WATERCAUSERASH = Convert.ToByte(localWorkorder.WATERCAUSERASH);
            refWorkorder.PERSONSEENDOCTOR = Convert.ToByte(localWorkorder.PERSONSEENDOCTOR);
            refWorkorder.MEDICALREPORT = (!String.IsNullOrEmpty(localWorkorder.MEDICALREPORT)) ? localWorkorder.MEDICALREPORT : null;
            refWorkorder.CONNECTIONTYPE = (!String.IsNullOrEmpty(localWorkorder.CONNECTIONTYPE)) ? localWorkorder.CONNECTIONTYPE : null;
            refWorkorder.PROBLEMBEGAN = (!String.IsNullOrEmpty(localWorkorder.PROBLEMBEGAN)) ? localWorkorder.PROBLEMBEGAN : null;
            refWorkorder.PROBLEMLOC = (!String.IsNullOrEmpty(localWorkorder.PROBLEMLOC)) ? localWorkorder.PROBLEMLOC : null;
            refWorkorder.PROBLEMTHRUOUT = Convert.ToByte(localWorkorder.PROBLEMTHRUOUT);
            refWorkorder.LOCALIZEDWHERE = (!String.IsNullOrEmpty(localWorkorder.LOCALIZEDWHERE)) ? localWorkorder.LOCALIZEDWHERE : null;
            refWorkorder.WATERTREATMENT = Convert.ToByte(localWorkorder.WATERTREATMENT);
            refWorkorder.TYPETREATMENT = (!String.IsNullOrEmpty(localWorkorder.TYPETREATMENT)) ? localWorkorder.TYPETREATMENT : null;
            refWorkorder.MEASUREMENTVALUE2 = (localWorkorder.MEASUREMENTVALUE2.HasValue) ? Convert.ToDecimal(localWorkorder.MEASUREMENTVALUE2) : (decimal?)null;
            refWorkorder.MEASUREMENTVALUE3 = (localWorkorder.MEASUREMENTVALUE3.HasValue) ? Convert.ToDecimal(localWorkorder.MEASUREMENTVALUE3) : (decimal?)null;
            refWorkorder.SAMPLELOCTYPE = (!String.IsNullOrEmpty(localWorkorder.SAMPLELOCTYPE)) ? localWorkorder.SAMPLELOCTYPE : null;
            refWorkorder.PETROLEUMODOR = Convert.ToByte(localWorkorder.PETROLEUMODOR);
            refWorkorder.CUTNUM = (!String.IsNullOrEmpty(localWorkorder.CUTNUM)) ? localWorkorder.CUTNUM : null;
            refWorkorder.DISTANCE = (localWorkorder.DISTANCE.HasValue) ? localWorkorder.DISTANCE.Value : (long?)null;
            refWorkorder.FINALPOSITION = (!String.IsNullOrEmpty(localWorkorder.FINALPOSITION)) ? localWorkorder.FINALPOSITION : null;
            refWorkorder.NUMBEROFTURNS = (localWorkorder.NUMBEROFTURNS.HasValue) ? Convert.ToDecimal(localWorkorder.NUMBEROFTURNS) : (decimal?)null;
            refWorkorder.WATERTASTE = Convert.ToByte(localWorkorder.WATERTASTE);
            refWorkorder.WATERTASTEDESC = (!String.IsNullOrEmpty(localWorkorder.WATERTASTEDESC)) ? localWorkorder.WATERTASTEDESC : null;
            refWorkorder.FUND = (!String.IsNullOrEmpty(localWorkorder.FUND)) ? localWorkorder.FUND : null;
            refWorkorder.OUTLETDIA = (!String.IsNullOrEmpty(localWorkorder.OUTLETDIA)) ? localWorkorder.OUTLETDIA : null;
            refWorkorder.VELOCITYPRES = (localWorkorder.VELOCITYPRES.HasValue) ? Convert.ToDecimal(localWorkorder.VELOCITYPRES) : (decimal?)null;
            refWorkorder.SNAKELINE = Convert.ToByte(localWorkorder.SNAKELINE);
            refWorkorder.JETLINE = Convert.ToByte(localWorkorder.JETLINE);
            refWorkorder.PROBLEMSIDE = (!String.IsNullOrEmpty(localWorkorder.PROBLEMSIDE)) ? localWorkorder.PROBLEMSIDE : null;
            refWorkorder.MEASUREMENTVALUE4 = (localWorkorder.MEASUREMENTVALUE4.HasValue) ? Convert.ToDecimal(localWorkorder.MEASUREMENTVALUE4) : (decimal?)null;
            refWorkorder.VALIDATED = Convert.ToByte(localWorkorder.VALIDATED);
            refWorkorder.CUSTOMERSTREET = (!String.IsNullOrEmpty(localWorkorder.CUSTOMERSTREET)) ? localWorkorder.CUSTOMERSTREET : null;
            refWorkorder.CUSTOMERCITY = (!String.IsNullOrEmpty(localWorkorder.CUSTOMERCITY)) ? localWorkorder.CUSTOMERCITY : null;
            refWorkorder.CUSTOMERSTATE = (!String.IsNullOrEmpty(localWorkorder.CUSTOMERSTATE)) ? localWorkorder.CUSTOMERSTATE : null;
            refWorkorder.CUSTOMERZIP = (!String.IsNullOrEmpty(localWorkorder.CUSTOMERZIP)) ? localWorkorder.CUSTOMERZIP : null;
            refWorkorder.CUSTOMEREMAIL = (!String.IsNullOrEmpty(localWorkorder.CUSTOMEREMAIL)) ? localWorkorder.CUSTOMEREMAIL : null;
            refWorkorder.ALTPHONEFAX = (!String.IsNullOrEmpty(localWorkorder.ALTPHONEFAX)) ? localWorkorder.ALTPHONEFAX : null;
            refWorkorder.OTHERCOMPANY = (!String.IsNullOrEmpty(localWorkorder.OTHERCOMPANY)) ? localWorkorder.OTHERCOMPANY : null;
            refWorkorder.PLUMBERNAME = (!String.IsNullOrEmpty(localWorkorder.PLUMBERNAME)) ? localWorkorder.PLUMBERNAME : null;
            refWorkorder.PLUMBERLICNUM = (!String.IsNullOrEmpty(localWorkorder.PLUMBERLICNUM)) ? localWorkorder.PLUMBERLICNUM : null;
            refWorkorder.SEWERRELIEVED = Convert.ToByte(localWorkorder.SEWERRELIEVED);
            refWorkorder.SNAKELOC = (!String.IsNullOrEmpty(localWorkorder.SNAKELOC)) ? localWorkorder.SNAKELOC : null;
            refWorkorder.SNAKETOSEWER = Convert.ToByte(localWorkorder.SNAKETOSEWER);
            refWorkorder.CLEANOUT = Convert.ToByte(localWorkorder.CLEANOUT);
            refWorkorder.CLEANOUTLOC = (!String.IsNullOrEmpty(localWorkorder.CLEANOUTLOC)) ? localWorkorder.CLEANOUTLOC : null;
            refWorkorder.RUNNINGTRAP = Convert.ToByte(localWorkorder.RUNNINGTRAP);
            refWorkorder.RUNNINGTRAPLOC = (!String.IsNullOrEmpty(localWorkorder.RUNNINGTRAPLOC)) ? localWorkorder.RUNNINGTRAPLOC : null;
            refWorkorder.EQUIPMENTUSED = (!String.IsNullOrEmpty(localWorkorder.EQUIPMENTUSED)) ? localWorkorder.EQUIPMENTUSED : null;
            refWorkorder.JUSTIFICATION = (!String.IsNullOrEmpty(localWorkorder.JUSTIFICATION)) ? localWorkorder.JUSTIFICATION : null;
            refWorkorder.DEBRIS = Convert.ToByte(localWorkorder.DEBRIS);
            refWorkorder.DEBRISDESC = (!String.IsNullOrEmpty(localWorkorder.DEBRISDESC)) ? localWorkorder.DEBRISDESC : null;
            refWorkorder.WEATHERCOND = (!String.IsNullOrEmpty(localWorkorder.WEATHERCOND)) ? localWorkorder.WEATHERCOND : null;
            refWorkorder.WINDS = (!String.IsNullOrEmpty(localWorkorder.WINDS)) ? localWorkorder.WINDS : null;
            refWorkorder.TEMPERATURE = (localWorkorder.TEMPERATURE.HasValue) ? localWorkorder.TEMPERATURE.Value : (long?)null;
            refWorkorder.PRECIPITATION = Convert.ToByte(localWorkorder.PRECIPITATION);
            refWorkorder.ENGINEERCOMPANY = (!String.IsNullOrEmpty(localWorkorder.ENGINEERCOMPANY)) ? localWorkorder.ENGINEERCOMPANY : null;
            refWorkorder.DEVELOPERCOMPANY = (!String.IsNullOrEmpty(localWorkorder.DEVELOPERCOMPANY)) ? localWorkorder.DEVELOPERCOMPANY : null;
            refWorkorder.DEVELOPERCONTACT = (!String.IsNullOrEmpty(localWorkorder.DEVELOPERCONTACT)) ? localWorkorder.DEVELOPERCONTACT : null;
            refWorkorder.DEVELOPERPHONE = (!String.IsNullOrEmpty(localWorkorder.DEVELOPERPHONE)) ? localWorkorder.DEVELOPERPHONE : null;
            refWorkorder.AGENCYID = (!String.IsNullOrEmpty(localWorkorder.AGENCYID)) ? localWorkorder.AGENCYID : null;
            refWorkorder.RECEIVEDAT = (!String.IsNullOrEmpty(localWorkorder.RECEIVEDAT)) ? localWorkorder.RECEIVEDAT : null;
            refWorkorder.CONTRACTORCONTACT = (!String.IsNullOrEmpty(localWorkorder.CONTRACTORCONTACT)) ? localWorkorder.CONTRACTORCONTACT : null;
            refWorkorder.ENUM = (!String.IsNullOrEmpty(localWorkorder.ENUM)) ? localWorkorder.ENUM : null;
            refWorkorder.PIPETYPE = (!String.IsNullOrEmpty(localWorkorder.PIPETYPE)) ? localWorkorder.PIPETYPE : null;
            refWorkorder.PERMITDATE = (localWorkorder.PERMITDATE.HasValue) ? localWorkorder.PERMITDATE : null;
            refWorkorder.ASBUILTREQD = Convert.ToByte(localWorkorder.ASBUILTREQD);
            refWorkorder.ASBUILTRECD = Convert.ToByte(localWorkorder.ASBUILTRECD);
            refWorkorder.CONTRACTORPHONE = (!String.IsNullOrEmpty(localWorkorder.CONTRACTORPHONE)) ? localWorkorder.CONTRACTORPHONE : null;
            refWorkorder.PROJECTTYPE = (!String.IsNullOrEmpty(localWorkorder.PROJECTTYPE)) ? localWorkorder.PROJECTTYPE : null;
            refWorkorder.ASSETLOCPRIORITY = (localWorkorder.ASSETLOCPRIORITY.HasValue) ? localWorkorder.ASSETLOCPRIORITY.Value : (long?)null;
            refWorkorder.ASSETNUM = (!String.IsNullOrEmpty(localWorkorder.ASSETNUM)) ? localWorkorder.ASSETNUM : null;
            if (localWorkorder.Asset != null)
                refWorkorder.ASSETNUM = localWorkorder.Asset.ASSETNUM;
            refWorkorder.BACKOUTPLAN = (!String.IsNullOrEmpty(localWorkorder.BACKOUTPLAN)) ? localWorkorder.BACKOUTPLAN : null;
            refWorkorder.CLASSSTRUCTUREID = (!String.IsNullOrEmpty(localWorkorder.CLASSSTRUCTUREID)) ? localWorkorder.CLASSSTRUCTUREID : null;
            refWorkorder.COMMODITY = (!String.IsNullOrEmpty(localWorkorder.COMMODITY)) ? localWorkorder.COMMODITY : null;
            refWorkorder.COMMODITYGROUP = (!String.IsNullOrEmpty(localWorkorder.COMMODITYGROUP)) ? localWorkorder.COMMODITYGROUP : null;
            refWorkorder.ENVIRONMENT = (!String.IsNullOrEmpty(localWorkorder.ENVIRONMENT)) ? localWorkorder.ENVIRONMENT : null;
            refWorkorder.HASLD = Convert.ToByte(localWorkorder.HASLD);
            refWorkorder.INTERRUPTIBLE = Convert.ToByte(localWorkorder.INTERRUPTIBLE);
            refWorkorder.JUSTIFYPRIORITY = (!String.IsNullOrEmpty(localWorkorder.JUSTIFYPRIORITY)) ? localWorkorder.JUSTIFYPRIORITY : null;
            refWorkorder.LANGCODE = (!String.IsNullOrEmpty(localWorkorder.LANGCODE)) ? localWorkorder.LANGCODE : null;
            refWorkorder.LEAD = (!String.IsNullOrEmpty(localWorkorder.LEAD)) ? localWorkorder.LEAD : null;
            refWorkorder.ONBEHALFOF = (!String.IsNullOrEmpty(localWorkorder.ONBEHALFOF)) ? localWorkorder.ONBEHALFOF : null;
            refWorkorder.ORIGRECORDCLASS = (!String.IsNullOrEmpty(localWorkorder.ORIGRECORDCLASS)) ? localWorkorder.ORIGRECORDCLASS : null;
            refWorkorder.ORIGRECORDID = (!String.IsNullOrEmpty(localWorkorder.ORIGRECORDID)) ? localWorkorder.ORIGRECORDID : null;
            refWorkorder.OWNER = (!String.IsNullOrEmpty(localWorkorder.OWNER)) ? localWorkorder.OWNER : null;
            refWorkorder.OWNERGROUP = (!String.IsNullOrEmpty(localWorkorder.OWNERGROUP)) ? localWorkorder.OWNERGROUP : null;
            refWorkorder.PARENTCHGSSTATUS = Convert.ToByte(localWorkorder.PARENTCHGSSTATUS);
            refWorkorder.PERSONGROUP = (!String.IsNullOrEmpty(localWorkorder.PERSONGROUP)) ? localWorkorder.PERSONGROUP : null;
            refWorkorder.REASONFORCHANGE = (!String.IsNullOrEmpty(localWorkorder.REASONFORCHANGE)) ? localWorkorder.REASONFORCHANGE : null;
            refWorkorder.RISK = (!String.IsNullOrEmpty(localWorkorder.RISK)) ? localWorkorder.RISK : null;
            refWorkorder.VENDOR = (!String.IsNullOrEmpty(localWorkorder.VENDOR)) ? localWorkorder.VENDOR : null;
            refWorkorder.VERIFICATION = (!String.IsNullOrEmpty(localWorkorder.VERIFICATION)) ? localWorkorder.VERIFICATION : null;
            refWorkorder.WHOMISCHANGEFOR = (!String.IsNullOrEmpty(localWorkorder.WHOMISCHANGEFOR)) ? localWorkorder.WHOMISCHANGEFOR : null;
            refWorkorder.WOACCEPTSCHARGES = Convert.ToByte(localWorkorder.WOACCEPTSCHARGES);
            if (!String.IsNullOrEmpty(localWorkorder.WOCLASS))
            {
                refWorkorder.WOCLASS = new WORKORDERWOCLASS
                {
                    maxvalue = localWorkorder.WOCLASS,
                    Value = localWorkorder.WOCLASS
                };
            }
            refWorkorder.WOGROUP = (!String.IsNullOrEmpty(localWorkorder.WOGROUP)) ? localWorkorder.WOGROUP : null;
            if(localWorkorder.WORKORDERID.HasValue)
              refWorkorder.WORKORDERID =localWorkorder.WORKORDERID.Value;
            refWorkorder.BKPCONTRACT = (!String.IsNullOrEmpty(localWorkorder.BKPCONTRACT)) ? localWorkorder.BKPCONTRACT : null;
            refWorkorder.CINUM = (!String.IsNullOrEmpty(localWorkorder.CINUM)) ? localWorkorder.CINUM : null;
            refWorkorder.FLOWACTION = (!String.IsNullOrEmpty(localWorkorder.FLOWACTION)) ? localWorkorder.FLOWACTION : null;
            refWorkorder.FLOWACTIONASSIST = Convert.ToByte(localWorkorder.FLOWACTIONASSIST);
            refWorkorder.FLOWCONTROLLED = Convert.ToByte(localWorkorder.FLOWCONTROLLED);
            refWorkorder.JOBTASKID = (localWorkorder.JOBTASKID.HasValue) ? localWorkorder.JOBTASKID.Value : (long?)null;
            refWorkorder.LAUNCHENTRYNAME = (!String.IsNullOrEmpty(localWorkorder.LAUNCHENTRYNAME)) ? localWorkorder.LAUNCHENTRYNAME : null;
            refWorkorder.NEWCHILDCLASS = (!String.IsNullOrEmpty(localWorkorder.NEWCHILDCLASS)) ? localWorkorder.NEWCHILDCLASS : null;
            refWorkorder.ROUTE = (!String.IsNullOrEmpty(localWorkorder.ROUTE)) ? localWorkorder.ROUTE : null;
            refWorkorder.ROUTESTOPID = (localWorkorder.ROUTESTOPID.HasValue) ? localWorkorder.ROUTESTOPID.Value : (long?)null;
            refWorkorder.SUSPENDFLOW = Convert.ToByte(localWorkorder.SUSPENDFLOW);
            refWorkorder.TARGETDESC = (!String.IsNullOrEmpty(localWorkorder.TARGETDESC)) ? localWorkorder.TARGETDESC : null;
            refWorkorder.WOISSWAP = Convert.ToByte(localWorkorder.WOISSWAP);
            refWorkorder.FIRSTAPPRSTATUS = (!String.IsNullOrEmpty(localWorkorder.FIRSTAPPRSTATUS)) ? localWorkorder.FIRSTAPPRSTATUS : null;
            refWorkorder.PMCOMTYPE = (!String.IsNullOrEmpty(localWorkorder.PMCOMTYPE)) ? localWorkorder.PMCOMTYPE : null;
            refWorkorder.PMCOMSTATE = (!String.IsNullOrEmpty(localWorkorder.PMCOMSTATE)) ? localWorkorder.PMCOMSTATE : null;
            refWorkorder.PMCOMBPELACTNAME = (!String.IsNullOrEmpty(localWorkorder.PMCOMBPELACTNAME)) ? localWorkorder.PMCOMBPELACTNAME : null;
            refWorkorder.PMCOMBPELENABLED = Convert.ToByte(localWorkorder.PMCOMBPELENABLED);
            refWorkorder.PMCOMBPELINPROG = Convert.ToByte(localWorkorder.PMCOMBPELINPROG);
            refWorkorder.CONPERMITNUM = (!String.IsNullOrEmpty(localWorkorder.CONPERMITNUM)) ? localWorkorder.CONPERMITNUM : null;
            refWorkorder.OCCPERMITNUM = (!String.IsNullOrEmpty(localWorkorder.OCCPERMITNUM)) ? localWorkorder.OCCPERMITNUM : null;
            refWorkorder.CALCORGID = (!String.IsNullOrEmpty(localWorkorder.CALCORGID)) ? localWorkorder.CALCORGID : null;
            refWorkorder.CALCCALENDAR = (!String.IsNullOrEmpty(localWorkorder.CALCCALENDAR)) ? localWorkorder.CALCCALENDAR : null;
            refWorkorder.CALCSHIFT = (!String.IsNullOrEmpty(localWorkorder.CALCSHIFT)) ? localWorkorder.CALCSHIFT : null;
            refWorkorder.RESTORATIONREQD = (!String.IsNullOrEmpty(localWorkorder.RESTORATIONREQD)) ? localWorkorder.RESTORATIONREQD : null;
            refWorkorder.CONTR_REL_NUM = (localWorkorder.CONTR_REL_NUM.HasValue) ? localWorkorder.CONTR_REL_NUM.Value : (long?)null;
            refWorkorder.DCW_LWBUDGETCHECK = Convert.ToByte(localWorkorder.DCW_LWBUDGETCHECK);
            refWorkorder.DCW_SENDMATL2LW = Convert.ToByte(localWorkorder.DCW_SENDMATL2LW);
            refWorkorder.DCW_SNAKEDIST2BLCKG = (!String.IsNullOrEmpty(localWorkorder.DCW_SNAKEDIST2BLCKG)) ? localWorkorder.DCW_SNAKEDIST2BLCKG : null;
            refWorkorder.CONTRACTORJUSTIFICATION = (!String.IsNullOrEmpty(localWorkorder.CONTRACTORJUSTIFICATION)) ? localWorkorder.CONTRACTORJUSTIFICATION : null;
            refWorkorder.COMPLEXITY = (localWorkorder.COMPLEXITY.HasValue) ? Convert.ToDecimal(localWorkorder.COMPLEXITY) : (decimal?)null;
            refWorkorder.DCW_UTILITYSTRIKE = localWorkorder.DCW_UTILITYSTRIKE;
            refWorkorder.DCW_REVISEDPRIORITY = (localWorkorder.DCW_REVISEDPRIORITY.HasValue) ? localWorkorder.DCW_REVISEDPRIORITY.Value : (long?)null;
            refWorkorder.REPFACSITEID = (!String.IsNullOrEmpty(localWorkorder.REPFACSITEID)) ? localWorkorder.REPFACSITEID : null;
            refWorkorder.REPAIRFACILITY = (!String.IsNullOrEmpty(localWorkorder.REPAIRFACILITY)) ? localWorkorder.REPAIRFACILITY : null;
            refWorkorder.GENFORPOREVISION = (localWorkorder.GENFORPOREVISION.HasValue) ? localWorkorder.GENFORPOREVISION.Value : (long?)null;
            refWorkorder.STOREROOMMTLSTATUS = (!String.IsNullOrEmpty(localWorkorder.STOREROOMMTLSTATUS)) ? localWorkorder.STOREROOMMTLSTATUS : null;
            refWorkorder.DIRISSUEMTLSTATUS = (!String.IsNullOrEmpty(localWorkorder.DIRISSUEMTLSTATUS)) ? localWorkorder.DIRISSUEMTLSTATUS : null;
            refWorkorder.WORKPACKMTLSTATUS = (!String.IsNullOrEmpty(localWorkorder.WORKPACKMTLSTATUS)) ? localWorkorder.WORKPACKMTLSTATUS : null;
            refWorkorder.IGNORESRMAVAIL = localWorkorder.IGNORESRMAVAIL;
            refWorkorder.IGNOREDIAVAIL = localWorkorder.IGNOREDIAVAIL;
            refWorkorder.ESTINTLABCOST = (localWorkorder.ESTINTLABCOST.HasValue) ? Convert.ToDouble(localWorkorder.ESTINTLABCOST) : (double?)null;
            refWorkorder.ESTINTLABHRS = (localWorkorder.ESTINTLABHRS.HasValue) ? Convert.ToDouble(localWorkorder.ESTINTLABHRS) : (double?)null;
            refWorkorder.ESTOUTLABHRS = (localWorkorder.ESTOUTLABHRS.HasValue) ? Convert.ToDouble(localWorkorder.ESTOUTLABHRS) : (double?)null;
            refWorkorder.ESTOUTLABCOST = (localWorkorder.ESTOUTLABCOST.HasValue) ? Convert.ToDouble(localWorkorder.ESTOUTLABCOST) : (double?)null;
            refWorkorder.ACTINTLABCOST = (localWorkorder.ACTINTLABCOST.HasValue) ? Convert.ToDouble(localWorkorder.ACTINTLABCOST) : (double?)null;
            refWorkorder.ACTINTLABHRS = (localWorkorder.ACTINTLABHRS.HasValue) ? Convert.ToDouble(localWorkorder.ACTINTLABHRS) : (double?)null;
            refWorkorder.ACTOUTLABHRS = (localWorkorder.ACTOUTLABHRS.HasValue) ? Convert.ToDouble(localWorkorder.ACTOUTLABHRS) : (double?)null;
            refWorkorder.ACTOUTLABCOST = (localWorkorder.ACTOUTLABCOST.HasValue) ? Convert.ToDouble(localWorkorder.ACTOUTLABCOST) : (double?)null;
            refWorkorder.ESTATAPPRINTLABCOST = (localWorkorder.ESTATAPPRINTLABCOST.HasValue) ? Convert.ToDouble(localWorkorder.ESTATAPPRINTLABCOST) : (double?)null;
            refWorkorder.ESTATAPPRINTLABHRS = (localWorkorder.ESTATAPPRINTLABHRS.HasValue) ? Convert.ToDouble(localWorkorder.ESTATAPPRINTLABHRS) : (double?)null;
            refWorkorder.ESTATAPPROUTLABHRS = (localWorkorder.ESTATAPPROUTLABHRS.HasValue) ? Convert.ToDouble(localWorkorder.ESTATAPPROUTLABHRS) : (double?)null;
            refWorkorder.ESTATAPPROUTLABCOST = (localWorkorder.ESTATAPPROUTLABCOST.HasValue) ? Convert.ToDouble(localWorkorder.ESTATAPPROUTLABCOST) : (double?)null;
            refWorkorder.ASSIGNEDOWNERGROUP = (!String.IsNullOrEmpty(localWorkorder.ASSIGNEDOWNERGROUP)) ? localWorkorder.ASSIGNEDOWNERGROUP : null;
            refWorkorder.AVAILSTATUSDATE = (localWorkorder.AVAILSTATUSDATE.HasValue) ? localWorkorder.AVAILSTATUSDATE : null;
            refWorkorder.LASTCOPYLINKDATE = (localWorkorder.LASTCOPYLINKDATE.HasValue) ? localWorkorder.LASTCOPYLINKDATE : null;
            refWorkorder.NESTEDJPINPROCESS = localWorkorder.NESTEDJPINPROCESS;
            refWorkorder.PLUSCFREQUENCY = (localWorkorder.PLUSCFREQUENCY.HasValue) ? localWorkorder.PLUSCFREQUENCY.Value : (long?)null;
            refWorkorder.PLUSCFREQUNIT = (!String.IsNullOrEmpty(localWorkorder.PLUSCFREQUNIT)) ? localWorkorder.PLUSCFREQUNIT : null;
            refWorkorder.PLUSCISMOBILE = localWorkorder.PLUSCISMOBILE;
            refWorkorder.PLUSCJPREVNUM = (localWorkorder.PLUSCJPREVNUM.HasValue) ? localWorkorder.PLUSCJPREVNUM.Value : (long?)null;
            refWorkorder.PLUSCLOOP = localWorkorder.PLUSCLOOP;
            refWorkorder.PLUSCNEXTDATE = (localWorkorder.PLUSCNEXTDATE.HasValue) ? localWorkorder.PLUSCNEXTDATE : null;
            refWorkorder.PLUSCOVERDUEDATE = (localWorkorder.PLUSCOVERDUEDATE.HasValue) ? localWorkorder.PLUSCOVERDUEDATE : null;
            refWorkorder.PLUSCPHYLOC = (!String.IsNullOrEmpty(localWorkorder.PLUSCPHYLOC)) ? localWorkorder.PLUSCPHYLOC : null;
            refWorkorder.INCTASKSINSCHED = localWorkorder.INCTASKSINSCHED;
            refWorkorder.SNECONSTRAINT = (localWorkorder.SNECONSTRAINT.HasValue) ? localWorkorder.SNECONSTRAINT : null;
            refWorkorder.FNLCONSTRAINT = (localWorkorder.FNLCONSTRAINT.HasValue) ? localWorkorder.FNLCONSTRAINT : null;
            refWorkorder.AMCREW = (!String.IsNullOrEmpty(localWorkorder.AMCREW)) ? localWorkorder.AMCREW : null;
            refWorkorder.CREWWORKGROUP = (!String.IsNullOrEmpty(localWorkorder.CREWWORKGROUP)) ? localWorkorder.CREWWORKGROUP : null;
            refWorkorder.REQASSTDWNTIME = localWorkorder.REQASSTDWNTIME;
            refWorkorder.APPTREQUIRED = localWorkorder.APPTREQUIRED;
            refWorkorder.AOS = localWorkorder.AOS;
            refWorkorder.AMS = localWorkorder.AMS;
            refWorkorder.LOS = localWorkorder.LOS;
            refWorkorder.LMS = localWorkorder.LMS;
            refWorkorder.PLUSSFEATURECLASS = (!String.IsNullOrEmpty(localWorkorder.PLUSSFEATURECLASS)) ? localWorkorder.PLUSSFEATURECLASS : null;
            refWorkorder.PLUSSISGIS = Convert.ToByte(localWorkorder.PLUSSISGIS);
            refWorkorder.DCW_CBASSIGNED = Convert.ToByte(localWorkorder.DCW_CBASSIGNED);

            if (localWorkorder.WorkorderSpecs != null)
            {
                var i = 0;
                foreach (var workorderSpec in localWorkorder.WorkorderSpecs.Where(s=>s.C_record_state_ != (long) LocalState.Original).ToList())
                {
                    ReverseMapper.PopulateWorkorderSpec(compositeWorkorder.WORKORDERSPEC[i++], workorderSpec);
                }
            }

            if (localWorkorder.WoStatuses != null)
            {
                var i = 0;
                foreach (var woStatus in localWorkorder.WoStatuses.Where(w => w.C_record_state_ == (long) LocalState.Added).ToList())
                {
                    ReverseMapper.PopulateWoStatus(compositeWorkorder.WOSTATUS[i++], woStatus);
                }
            }

            if (localWorkorder.FailureReports != null)
            {
                var i = 0;
                foreach (var failureReport in localWorkorder.FailureReports)
                {
                    ReverseMapper.PopulateFailureReport(compositeWorkorder.FAILUREREPORT[i++], failureReport);
                }
            }

            if (compositeWorkorder.FAILUREREMARK != null && compositeWorkorder.FAILUREREMARK[0] != null && localWorkorder.FailureRemark != null)
            {
                ReverseMapper.PopulateFailureRemark(compositeWorkorder.FAILUREREMARK[0], localWorkorder.FailureRemark);
            }

            if (localWorkorder.LabTrans != null)
            {
                var i = 0;
                foreach (var labTrans in localWorkorder.LabTrans.Where(w => w.C_record_state_ == (long)LocalState.Added).ToList())
                {
                    ReverseMapper.PopulateLabTran(compositeWorkorder.LABTRANS[i++], labTrans);
                }
            }
            if (localWorkorder.ToolTrans != null)
            {
                var i = 0;
                foreach (var toolTrans in localWorkorder.ToolTrans.Where(w => w.C_record_state_ == (long)LocalState.Added).ToList())
                {
                    ReverseMapper.PopulateToolTran(compositeWorkorder.TOOLTRANS[i++], toolTrans);
                }
            }
            if (localWorkorder.Doclinks != null)
            {
                var i = 0;
                foreach (var docLink in localWorkorder.Doclinks.Where(w => w.C_record_state_ == (long)LocalState.Added).ToList())
                {
                    ReverseMapper.PopulateDocLink(compositeWorkorder.DOCLINKS[i],compositeWorkorder.DOCINFO[i], docLink);
                    i++;
                }
            }

        }

        internal static void PopulateWorkorderSpec(WORKORDERSPECMboSetWORKORDERSPEC refWorkorderSpec, WORKORDERSPEC localWorkorderSpec )
        {
            refWorkorderSpec.ALNVALUE = (!String.IsNullOrEmpty(localWorkorderSpec.ALNVALUE)) ? localWorkorderSpec.ALNVALUE : null;
            refWorkorderSpec.ASSETATTRID = (!String.IsNullOrEmpty(localWorkorderSpec.ASSETATTRID)) ? localWorkorderSpec.ASSETATTRID : null;
            refWorkorderSpec.CHANGEBY = (!String.IsNullOrEmpty(localWorkorderSpec.CHANGEBY)) ? localWorkorderSpec.CHANGEBY : null;
            refWorkorderSpec.CHANGEDATE = localWorkorderSpec.CHANGEDATE;
            refWorkorderSpec.CLASSSPECID = (localWorkorderSpec.CLASSSPECID.HasValue) ? localWorkorderSpec.CLASSSPECID : (long?)null;
            refWorkorderSpec.CLASSSTRUCTUREID = (!String.IsNullOrEmpty(localWorkorderSpec.CLASSSTRUCTUREID)) ? localWorkorderSpec.CLASSSTRUCTUREID : null;
            refWorkorderSpec.DISPLAYSEQUENCE =  localWorkorderSpec.DISPLAYSEQUENCE;
            refWorkorderSpec.LINKEDTOATTRIBUTE = (!String.IsNullOrEmpty(localWorkorderSpec.LINKEDTOATTRIBUTE)) ? localWorkorderSpec.LINKEDTOATTRIBUTE : null;
            refWorkorderSpec.LINKEDTOSECTION = (!String.IsNullOrEmpty(localWorkorderSpec.LINKEDTOSECTION)) ? localWorkorderSpec.LINKEDTOSECTION : null;
            refWorkorderSpec.MANDATORY =  Convert.ToByte(localWorkorderSpec.MANDATORY);
            refWorkorderSpec.MEASUREUNITID = (!String.IsNullOrEmpty(localWorkorderSpec.MEASUREUNITID)) ? localWorkorderSpec.MEASUREUNITID : null;
            refWorkorderSpec.NUMVALUE = (localWorkorderSpec.NUMVALUE.HasValue) ? Convert.ToDecimal(localWorkorderSpec.NUMVALUE.Value) : (decimal?) null;
            refWorkorderSpec.ORGID = (!String.IsNullOrEmpty(localWorkorderSpec.ORGID)) ? localWorkorderSpec.ORGID : null;
            refWorkorderSpec.REFOBJECTID = localWorkorderSpec.REFOBJECTID;
            refWorkorderSpec.REFOBJECTNAME = (!String.IsNullOrEmpty(localWorkorderSpec.REFOBJECTNAME)) ? localWorkorderSpec.REFOBJECTNAME : null;
            refWorkorderSpec.SECTION = (!String.IsNullOrEmpty(localWorkorderSpec.SECTION)) ? localWorkorderSpec.SECTION : null;
            refWorkorderSpec.SITEID = (!String.IsNullOrEmpty(localWorkorderSpec.SITEID)) ? localWorkorderSpec.SITEID : null;
            refWorkorderSpec.TABLEVALUE = (!String.IsNullOrEmpty(localWorkorderSpec.TABLEVALUE)) ? localWorkorderSpec.TABLEVALUE : null;
            refWorkorderSpec.WONUM = (!String.IsNullOrEmpty(localWorkorderSpec.WONUM)) ? localWorkorderSpec.WONUM : null;
            if (localWorkorderSpec.WORKORDERSPECID.HasValue)
              refWorkorderSpec.WORKORDERSPECID = localWorkorderSpec.WORKORDERSPECID.Value;
        }

        internal static void PopulateWoStatus(WOSTATUSMboSetWOSTATUS refWoStatus, WOSTATUS localWoStatus)
        {
            refWoStatus.WONUM = (!String.IsNullOrEmpty(localWoStatus.Workorder.WONUM)) ? localWoStatus.Workorder.WONUM : null;
            refWoStatus.STATUS = (!String.IsNullOrEmpty(localWoStatus.STATUS)) ? localWoStatus.STATUS : null;
            refWoStatus.CHANGEDATE = localWoStatus.CHANGEDATE;
            refWoStatus.CHANGEBY = (!String.IsNullOrEmpty(localWoStatus.CHANGEBY)) ? localWoStatus.CHANGEBY : null;
            refWoStatus.MEMO = (!String.IsNullOrEmpty(localWoStatus.MEMO)) ? localWoStatus.MEMO : null;
            if (!String.IsNullOrEmpty(localWoStatus.STATUS))
                refWoStatus.GLACCOUNT = new WOSTATUSGLACCOUNT {VALUE=localWoStatus.GLACCOUNT, GLCOMP=new WOSTATUSGLACCOUNTGLCOMP{glorder=0,Value=0}};

            refWoStatus.FINCNTRLID = (!String.IsNullOrEmpty(localWoStatus.FINCNTRLID)) ? localWoStatus.FINCNTRLID : null;
            refWoStatus.ORGID = (!String.IsNullOrEmpty(localWoStatus.ORGID)) ? localWoStatus.ORGID : null;
            refWoStatus.SITEID = (!String.IsNullOrEmpty(localWoStatus.SITEID)) ? localWoStatus.SITEID : null;
            if (localWoStatus.WOSTATUSID.HasValue)
              refWoStatus.WOSTATUSID = Convert.ToInt32(localWoStatus.WOSTATUSID);
            refWoStatus.PARENT = (!String.IsNullOrEmpty(localWoStatus.PARENT)) ? localWoStatus.PARENT : null;
        }

        internal static void PopulateFailureReport(FAILUREREPORTMboSetFAILUREREPORT refFailureReport, FAILUREREPORT localFailureReport)
        {
            refFailureReport.WONUM = (!String.IsNullOrEmpty(localFailureReport.Workorder.WONUM)) ? localFailureReport.Workorder.WONUM : null;
            refFailureReport.LINENUM = localFailureReport.LINENUM;
            refFailureReport.FAILURECODE = localFailureReport.FAILURECODE;
            refFailureReport.TYPE = (!String.IsNullOrEmpty(localFailureReport.TYPE)) ? localFailureReport.TYPE : null; 
            refFailureReport.ORGID = (!String.IsNullOrEmpty(localFailureReport.ORGID)) ? localFailureReport.ORGID : null;
            refFailureReport.SITEID = (!String.IsNullOrEmpty(localFailureReport.SITEID)) ? localFailureReport.SITEID : null;
            refFailureReport.ASSETNUM = (!String.IsNullOrEmpty(localFailureReport.Workorder.ASSETNUM)) ? localFailureReport.Workorder.ASSETNUM : null;
            if (localFailureReport.FAILUREREPORTID.HasValue)
              refFailureReport.FAILUREREPORTID = localFailureReport.FAILUREREPORTID.Value;
            refFailureReport.TICKETCLASS = (!String.IsNullOrEmpty(localFailureReport.TICKETCLASS)) ? localFailureReport.TICKETCLASS : null;
            refFailureReport.TICKETID = (!String.IsNullOrEmpty(localFailureReport.TICKETID)) ? localFailureReport.TICKETID : null;
        }

        internal static void PopulateFailureRemark(FAILUREREMARKMboSetFAILUREREMARK refFailureRemark, FAILUREREMARK localFailureRemark)
        {
            refFailureRemark.WONUM = (!String.IsNullOrEmpty(localFailureRemark.Workorder.WONUM)) ? localFailureRemark.Workorder.WONUM : null;
            refFailureRemark.DESCRIPTION = (!String.IsNullOrEmpty(localFailureRemark.DESCRIPTION)) ? localFailureRemark.DESCRIPTION : null;
            if (localFailureRemark.ENTERDATE.HasValue)
                refFailureRemark.ENTERDATE = localFailureRemark.ENTERDATE;

            refFailureRemark.ORGID = (!String.IsNullOrEmpty(localFailureRemark.ORGID)) ? localFailureRemark.ORGID : null;
            refFailureRemark.SITEID = (!String.IsNullOrEmpty(localFailureRemark.SITEID)) ? localFailureRemark.SITEID : null;
            if (localFailureRemark.FAILUREREMARKID.HasValue)
                refFailureRemark.FAILUREREMARKID = Convert.ToInt32(localFailureRemark.FAILUREREMARKID);
            refFailureRemark.HASLD = Convert.ToByte(localFailureRemark.HASLD);
            refFailureRemark.LANGCODE = (!String.IsNullOrEmpty(localFailureRemark.LANGCODE)) ? localFailureRemark.LANGCODE : null;
            refFailureRemark.TICKETCLASS = (!String.IsNullOrEmpty(localFailureRemark.TICKETCLASS)) ? localFailureRemark.TICKETCLASS : null;
            refFailureRemark.TICKETID = (!String.IsNullOrEmpty(localFailureRemark.TICKETID)) ? localFailureRemark.TICKETID : null;
        }

        internal static void PopulateToolTran(TOOLTRANSMboSetTOOLTRANS refToolTran, TOOLTRAN localToolTran)
        {
            refToolTran.TRANSDATE = localToolTran.TRANSDATE;
            refToolTran.TOOLRATE = Convert.ToDecimal(localToolTran.TOOLRATE);
            refToolTran.TOOLQTY = Convert.ToInt64(localToolTran.TOOLQTY);
            refToolTran.TOOLHRS = Convert.ToDecimal(localToolTran.TOOLHRS);
            refToolTran.ENTERDATE = localToolTran.ENTERDATE;           
            refToolTran.ENTERBY = (!String.IsNullOrEmpty(localToolTran.ENTERBY)) ? localToolTran.ENTERBY : null;
            refToolTran.OUTSIDE = Convert.ToByte( localToolTran.OUTSIDE);
            refToolTran.ROLLUP = Convert.ToByte(localToolTran.ROLLUP);
            refToolTran.GLDEBITACCT = (!String.IsNullOrEmpty(localToolTran.GLDEBITACCT)) ? localToolTran.GLDEBITACCT : null;
            refToolTran.LINECOST = Convert.ToDecimal(localToolTran.LINECOST);
            refToolTran.GLCREDITACCT = (!String.IsNullOrEmpty(localToolTran.GLCREDITACCT)) ? localToolTran.GLCREDITACCT : null;
            refToolTran.FINANCIALPERIOD = (!String.IsNullOrEmpty(localToolTran.FINANCIALPERIOD)) ? localToolTran.FINANCIALPERIOD : null;
            refToolTran.LOCATION = (!String.IsNullOrEmpty(localToolTran.LOCATION)) ? localToolTran.LOCATION : null;
            if(localToolTran.EXCHANGERATE2.HasValue)
                refToolTran.EXCHANGERATE2 = Convert.ToDecimal(localToolTran.EXCHANGERATE2);
            if (localToolTran.LINECOST2.HasValue)
                refToolTran.LINECOST2 = Convert.ToDecimal(localToolTran.LINECOST2);
            refToolTran.SOURCESYSID = (!String.IsNullOrEmpty(localToolTran.SOURCESYSID)) ? localToolTran.SOURCESYSID : null;
            refToolTran.OWNERSYSID = (!String.IsNullOrEmpty(localToolTran.OWNERSYSID)) ? localToolTran.OWNERSYSID : null;
            refToolTran.EXTERNALREFID = (!String.IsNullOrEmpty(localToolTran.EXTERNALREFID)) ? localToolTran.EXTERNALREFID : null;
            refToolTran.SENDERSYSID = (!String.IsNullOrEmpty(localToolTran.SENDERSYSID)) ? localToolTran.SENDERSYSID : null;
            refToolTran.FINCNTRLID = (!String.IsNullOrEmpty(localToolTran.FINCNTRLID)) ? localToolTran.FINCNTRLID : null;
            refToolTran.ORGID = (!String.IsNullOrEmpty(localToolTran.ORGID)) ? localToolTran.ORGID : null;
            refToolTran.SITEID = (!String.IsNullOrEmpty(localToolTran.SITEID)) ? localToolTran.SITEID : null;
            refToolTran.REFWO = (!String.IsNullOrEmpty(localToolTran.REFWO)) ? localToolTran.REFWO : null;
            refToolTran.ENTEREDASTASK = Convert.ToByte(localToolTran.ENTEREDASTASK);
            refToolTran.ASSETNUM = (!String.IsNullOrEmpty(localToolTran.ASSETNUM)) ? localToolTran.ASSETNUM : null;
            refToolTran.ITEMNUM = (!String.IsNullOrEmpty(localToolTran.ITEMNUM)) ? localToolTran.ITEMNUM : null;
            refToolTran.ITEMSETID = (!String.IsNullOrEmpty(localToolTran.ITEMSETID)) ? localToolTran.ITEMSETID : null;
            refToolTran.ROTASSETNUM = (!String.IsNullOrEmpty(localToolTran.ROTASSETNUM)) ? localToolTran.ROTASSETNUM : null;
            refToolTran.ROTASSETSITE = (!String.IsNullOrEmpty(localToolTran.ROTASSETSITE)) ? localToolTran.ROTASSETSITE : null;
            if (localToolTran.TOOLTRANSID.HasValue)
                refToolTran.TOOLTRANSID = Convert.ToInt32(localToolTran.TOOLTRANSID);
            refToolTran.PLUSCCOMMENT = (!String.IsNullOrEmpty(localToolTran.PLUSCCOMMENT)) ? localToolTran.PLUSCCOMMENT : null;
            if (localToolTran.PLUSCDUEDATE.HasValue)
                refToolTran.PLUSCDUEDATE = localToolTran.PLUSCDUEDATE.Value;
            if (localToolTran.PLUSCEXPIRYDATE.HasValue)
                refToolTran.PLUSCEXPIRYDATE = localToolTran.PLUSCEXPIRYDATE.Value;
            refToolTran.PLUSCLOTNUM = (!String.IsNullOrEmpty(localToolTran.PLUSCLOTNUM)) ? localToolTran.PLUSCLOTNUM : null;
            refToolTran.PLUSCMANUFACTURER = (!String.IsNullOrEmpty(localToolTran.PLUSCMANUFACTURER)) ? localToolTran.PLUSCMANUFACTURER : null;
            refToolTran.PLUSCTECHNICIAN = (!String.IsNullOrEmpty(localToolTran.PLUSCTECHNICIAN)) ? localToolTran.PLUSCTECHNICIAN : null;
            if (localToolTran.PLUSCTOOLUSEDATE.HasValue)
                refToolTran.PLUSCTOOLUSEDATE = localToolTran.PLUSCTOOLUSEDATE.Value;
            refToolTran.PLUSCTYPE = (!String.IsNullOrEmpty(localToolTran.PLUSCTYPE)) ? localToolTran.PLUSCTYPE : null;
            refToolTran.HASLD = Convert.ToByte(localToolTran.HASLD);
            refToolTran.LANGCODE = (!String.IsNullOrEmpty(localToolTran.LANGCODE)) ? localToolTran.LANGCODE : null;
            refToolTran.AMCREW = (!String.IsNullOrEmpty(localToolTran.AMCREW)) ? localToolTran.AMCREW : null;
            refToolTran.TOOLSQ = (!String.IsNullOrEmpty(localToolTran.TOOLSQ)) ? localToolTran.TOOLSQ : null;

        }

        internal static void PopulateLabTran(LABTRANSMboSetLABTRANS refLabTran, LABTRAN localLabTran)
        {
            refLabTran.TRANSDATE = localLabTran.TRANSDATE;
            refLabTran.LABORCODE = (!String.IsNullOrEmpty(localLabTran.LABORCODE)) ? localLabTran.LABORCODE : null; 
            refLabTran.CRAFT = (!String.IsNullOrEmpty(localLabTran.CRAFT)) ? localLabTran.CRAFT : null;
            refLabTran.PAYRATE = Convert.ToDecimal( localLabTran.PAYRATE);
            refLabTran.REGULARHRS = Convert.ToDecimal(localLabTran.REGULARHRS);
            refLabTran.ENTERBY = (!String.IsNullOrEmpty(localLabTran.ENTERBY)) ? localLabTran.ENTERBY : null;
            refLabTran.ENTERDATE = localLabTran.ENTERDATE;
            refLabTran.LTWO1 = (!String.IsNullOrEmpty(localLabTran.LTWO1)) ? localLabTran.LTWO1 : null;
            refLabTran.LT7 =Convert.ToByte( localLabTran.LT7);
            refLabTran.STARTDATE = localLabTran.STARTDATE;
            if(localLabTran.STARTTIME.HasValue)
                refLabTran.STARTTIME = localLabTran.STARTTIME;
            if (localLabTran.FINISHDATE.HasValue)
                refLabTran.FINISHDATE = localLabTran.FINISHDATE;
            if (localLabTran.FINISHTIME.HasValue)
                refLabTran.FINISHTIME = localLabTran.FINISHTIME;
            if (!String.IsNullOrEmpty(localLabTran.TRANSTYPE))
                refLabTran.TRANSTYPE = new LABTRANSMboSetLABTRANSTRANSTYPE {maxvalue = localLabTran.TRANSTYPE, Value = localLabTran.TRANSTYPE};
            refLabTran.OUTSIDE = Convert.ToByte(localLabTran.OUTSIDE);
            refLabTran.MEMO = (!String.IsNullOrEmpty(localLabTran.MEMO)) ? localLabTran.MEMO : null;
            refLabTran.ROLLUP = Convert.ToByte(localLabTran.ROLLUP);
            if (!String.IsNullOrEmpty(localLabTran.GLDEBITACCT))
                refLabTran.GLDEBITACCT = new LABTRANSMboSetLABTRANSGLDEBITACCT { VALUE = localLabTran.GLDEBITACCT, GLCOMP = null };

            refLabTran.LINECOST = Convert.ToDecimal(localLabTran.LINECOST);
            if (!String.IsNullOrEmpty(localLabTran.GLCREDITACCT))
                refLabTran.GLCREDITACCT = localLabTran.GLCREDITACCT;
            refLabTran.FINANCIALPERIOD = (!String.IsNullOrEmpty(localLabTran.FINANCIALPERIOD)) ? localLabTran.FINANCIALPERIOD : null;

            refLabTran.PONUM = (!String.IsNullOrEmpty(localLabTran.PONUM)) ? localLabTran.PONUM : null;
            refLabTran.POLINENUM = (localLabTran.POLINENUM.HasValue) ? Convert.ToInt32( localLabTran.POLINENUM.Value) : (int?) null;
            refLabTran.LOCATION = (!String.IsNullOrEmpty(localLabTran.LOCATION)) ? localLabTran.LOCATION : null;
            refLabTran.GENAPPRSERVRECEIPT = Convert.ToByte(localLabTran.GENAPPRSERVRECEIPT);
            if (localLabTran.PAYMENTTRANSDATE.HasValue)
                refLabTran.PAYMENTTRANSDATE = localLabTran.PAYMENTTRANSDATE.Value;
            if(localLabTran.EXCHANGERATE2.HasValue)
             refLabTran.EXCHANGERATE2 = Convert.ToDecimal(localLabTran.EXCHANGERATE2);
            if (localLabTran.EXCHANGERATE2.HasValue)
                refLabTran.EXCHANGERATE2 = Convert.ToDecimal(localLabTran.EXCHANGERATE2);
             if (localLabTran.LINECOST2.HasValue)
                refLabTran.LINECOST2 = Convert.ToDecimal(localLabTran.LINECOST2);
             if (localLabTran.LABTRANSID.HasValue)
                refLabTran.LABTRANSID = Convert.ToInt32(localLabTran.LABTRANSID);
             if (localLabTran.SERVRECTRANSID.HasValue)
                 refLabTran.SERVRECTRANSID = Convert.ToInt32(localLabTran.SERVRECTRANSID);
             refLabTran.SOURCESYSID = (!String.IsNullOrEmpty(localLabTran.SOURCESYSID)) ? localLabTran.SOURCESYSID : null;
             refLabTran.OWNERSYSID = (!String.IsNullOrEmpty(localLabTran.OWNERSYSID)) ? localLabTran.OWNERSYSID : null;
             refLabTran.EXTERNALREFID = (!String.IsNullOrEmpty(localLabTran.EXTERNALREFID)) ? localLabTran.EXTERNALREFID : null;
             refLabTran.SENDERSYSID = (!String.IsNullOrEmpty(localLabTran.SENDERSYSID)) ? localLabTran.SENDERSYSID : null;
             refLabTran.FINCNTRLID = (!String.IsNullOrEmpty(localLabTran.FINCNTRLID)) ? localLabTran.FINCNTRLID : null;
             refLabTran.ORGID = (!String.IsNullOrEmpty(localLabTran.ORGID)) ? localLabTran.ORGID : null;
             refLabTran.SITEID = (!String.IsNullOrEmpty(localLabTran.SITEID)) ? localLabTran.SITEID : null;
             refLabTran.REFWO = (!String.IsNullOrEmpty(localLabTran.REFWO)) ? localLabTran.REFWO : null;
            refLabTran.ENTEREDASTASK = Convert.ToByte(localLabTran.ENTEREDASTASK);
            refLabTran.ASSETNUM = (!String.IsNullOrEmpty(localLabTran.ASSETNUM)) ? localLabTran.ASSETNUM : null;
            refLabTran.CONTRACTNUM = (!String.IsNullOrEmpty(localLabTran.CONTRACTNUM)) ? localLabTran.CONTRACTNUM : null;
            if (localLabTran.INVOICELINENUM.HasValue)
                refLabTran.INVOICELINENUM = Convert.ToInt32(localLabTran.INVOICELINENUM);
            refLabTran.PREMIUMPAYCODE = (!String.IsNullOrEmpty(localLabTran.PREMIUMPAYCODE)) ? localLabTran.PREMIUMPAYCODE : null;
            if (localLabTran.PREMIUMPAYHOURS.HasValue)
                refLabTran.PREMIUMPAYHOURS = Convert.ToDecimal(localLabTran.PREMIUMPAYHOURS.Value);
            if (localLabTran.PREMIUMPAYRATE.HasValue)
                refLabTran.PREMIUMPAYRATE = Convert.ToDecimal(localLabTran.PREMIUMPAYRATE.Value);
            if (!String.IsNullOrEmpty(localLabTran.PREMIUMPAYRATETYPE))
                refLabTran.PREMIUMPAYRATETYPE = new LABTRANSMboSetLABTRANSPREMIUMPAYRATETYPE
                {
                    maxvalue = localLabTran.PREMIUMPAYRATETYPE,
                    Value = localLabTran.PREMIUMPAYRATETYPE
                };
            if (localLabTran.REVISIONNUM.HasValue)
                refLabTran.REVISIONNUM = Convert.ToInt32(localLabTran.REVISIONNUM.Value);

            refLabTran.SKILLLEVEL = (!String.IsNullOrEmpty(localLabTran.SKILLLEVEL)) ? localLabTran.SKILLLEVEL : null;
            refLabTran.TICKETCLASS = (!String.IsNullOrEmpty(localLabTran.TICKETCLASS)) ? localLabTran.TICKETCLASS : null;
            refLabTran.TICKETID = (!String.IsNullOrEmpty(localLabTran.TICKETID)) ? localLabTran.TICKETID : null;
            refLabTran.TIMERSTATUS = (!String.IsNullOrEmpty(localLabTran.TIMERSTATUS)) ? localLabTran.TIMERSTATUS : null;
            refLabTran.VENDOR = (!String.IsNullOrEmpty(localLabTran.VENDOR)) ? localLabTran.VENDOR : null;
            if (localLabTran.POREVISIONNUM.HasValue)
                refLabTran.POREVISIONNUM = Convert.ToInt32(localLabTran.POREVISIONNUM.Value);

            refLabTran.CREWWORKGROUP = (!String.IsNullOrEmpty(localLabTran.CREWWORKGROUP)) ? localLabTran.CREWWORKGROUP : null;
            refLabTran.AMCREW = (!String.IsNullOrEmpty(localLabTran.AMCREW)) ? localLabTran.AMCREW : null;
            refLabTran.AMCREWTYPE = (!String.IsNullOrEmpty(localLabTran.AMCREWTYPE)) ? localLabTran.AMCREWTYPE : null;
            refLabTran.POSITION = (!String.IsNullOrEmpty(localLabTran.POSITION)) ? localLabTran.POSITION : null;
            refLabTran.DCW_TRUCKLEAD = Convert.ToByte(localLabTran.DCW_TRUCKLEAD);
            refLabTran.DCW_TRUCKSECOND = Convert.ToByte(localLabTran.DCW_TRUCKSECOND);
            refLabTran.DCW_TRUCKLEAD = Convert.ToByte(localLabTran.DCW_TRUCKLEAD);
        }

        internal static void PopulateDocLink(DOCLINKSMboSetDOCLINKS refDocLink, DOCINFOMboSetDOCINFO refDocInfo, DOCLINK localDocLink)
        {
            refDocLink.DOCUMENT = (!String.IsNullOrEmpty(localDocLink.DOCUMENT)) ? localDocLink.DOCUMENT : null;
            refDocLink.REFERENCE = (!String.IsNullOrEmpty(localDocLink.REFERENCE)) ? localDocLink.REFERENCE : null;
            refDocLink.DOCTYPE = (!String.IsNullOrEmpty(localDocLink.DOCTYPE)) ? localDocLink.DOCTYPE : null;
            refDocLink.URLTYPE = localDocLink.DocInfo.URLTYPE;
            refDocLink.URLNAME = localDocLink.DocInfo.URLNAME;
            if (String.IsNullOrEmpty(refDocLink.URLNAME))
                refDocLink.URLNAME = localDocLink.DocInfo.C_URLNAME_LOCAL_;

            refDocLink.DOCVERSION = (!String.IsNullOrEmpty(localDocLink.DOCVERSION)) ? localDocLink.DOCVERSION : null;
            refDocLink.GETLATESTVERSION = Convert.ToByte(localDocLink.GETLATESTVERSION);
            refDocLink.CREATEBY = (!String.IsNullOrEmpty(localDocLink.CREATEBY)) ? localDocLink.CREATEBY : null;
            if (localDocLink.CREATEDATE.HasValue)
                refDocLink.CREATEDATE = localDocLink.CREATEDATE.Value;
            refDocLink.CHANGEBY = (!String.IsNullOrEmpty(localDocLink.CHANGEBY)) ? localDocLink.CHANGEBY : null;
            if (localDocLink.CHANGEDATE.HasValue)
                refDocLink.CHANGEDATE = localDocLink.CHANGEDATE.Value;
            refDocLink.PRINTTHRULINK = Convert.ToByte(localDocLink.PRINTTHRULINK);
            refDocLink.COPYLINKTOWO =  Convert.ToByte(localDocLink.COPYLINKTOWO);
            if(localDocLink.DOCINFOID.HasValue)
                refDocLink.DOCINFOID = localDocLink.DOCINFOID.Value;
            if (localDocLink.DOCLINKSID.HasValue)
              refDocLink.DOCLINKSID = localDocLink.DOCLINKSID.Value;
            if(localDocLink.Workorder.WORKORDERID.HasValue)
                refDocLink.OWNERID = localDocLink.Workorder.WORKORDERID.Value;
            refDocLink.OWNERTABLE = (!String.IsNullOrEmpty(localDocLink.OWNERTABLE)) ? localDocLink.OWNERTABLE : null;
            refDocLink.DESCRIPTION = localDocLink.DocInfo.DESCRIPTION;
            
            var localDocInfo = localDocLink.DocInfo;
            refDocInfo.DOCUMENT = (!String.IsNullOrEmpty(localDocInfo.DOCUMENT)) ? localDocInfo.DOCUMENT : null;
            refDocInfo.DESCRIPTION = (!String.IsNullOrEmpty(localDocInfo.DESCRIPTION)) ? localDocInfo.DESCRIPTION : null;
            refDocInfo.APPLICATION = (!String.IsNullOrEmpty(localDocInfo.APPLICATION)) ? localDocInfo.APPLICATION : null;
            refDocInfo.STATUS = (!String.IsNullOrEmpty(localDocInfo.STATUS)) ? localDocInfo.STATUS : null;
            if(localDocInfo.STATUSDATE.HasValue)
             refDocInfo.STATUSDATE = localDocInfo.STATUSDATE.Value;
            refDocInfo.CREATEBY = (!String.IsNullOrEmpty(localDocInfo.CREATEBY)) ? localDocInfo.CREATEBY : null;
            if (localDocInfo.CREATEDATE.HasValue)
                refDocInfo.CREATEDATE = localDocInfo.CREATEDATE.Value;
            refDocInfo.CHANGEBY = (!String.IsNullOrEmpty(localDocInfo.CHANGEBY)) ? localDocInfo.CHANGEBY : null;
            if (localDocInfo.CHANGEDATE.HasValue)
                refDocInfo.CHANGEDATE = localDocInfo.CHANGEDATE.Value;
            if (localDocInfo.REVISION.HasValue)
                refDocInfo.REVISION = Convert.ToInt32(localDocInfo.REVISION.Value);
             refDocInfo.EXTRA1 = (!String.IsNullOrEmpty(localDocInfo.EXTRA1)) ? localDocInfo.EXTRA1 : null;
             refDocInfo.DOCLOCATION = (!String.IsNullOrEmpty(localDocInfo.DOCLOCATION)) ? localDocInfo.DOCLOCATION : null;
             refDocInfo .DOCTYPE = (!String.IsNullOrEmpty(localDocInfo.DOCTYPE)) ? localDocInfo.DOCTYPE : null;
            if (!String.IsNullOrEmpty(localDocInfo.URLTYPE))
                refDocInfo.URLTYPE = new DOCINFOMboSetDOCINFOURLTYPE
                {
                    maxvalue = localDocInfo.URLTYPE,
                    Value = localDocInfo.URLTYPE
                };
            refDocInfo.DMSNAME = (!String.IsNullOrEmpty(localDocInfo.DMSNAME)) ? localDocInfo.DMSNAME : null;
            refDocInfo.URLNAME = (!String.IsNullOrEmpty(localDocInfo.URLNAME)) ? localDocInfo.URLNAME : null;
            refDocInfo.URLPARAM1 = (!String.IsNullOrEmpty(localDocInfo.URLPARAM1)) ? localDocInfo.URLPARAM1 : null;
            refDocInfo.URLPARAM2 = (!String.IsNullOrEmpty(localDocInfo.URLPARAM2)) ? localDocInfo.URLPARAM2 : null;
            refDocInfo.URLPARAM3 = (!String.IsNullOrEmpty(localDocInfo.URLPARAM3)) ? localDocInfo.URLPARAM3 : null;
            refDocInfo.URLPARAM4 = (!String.IsNullOrEmpty(localDocInfo.URLPARAM4)) ? localDocInfo.URLPARAM4 : null;
            refDocInfo.URLPARAM5 = (!String.IsNullOrEmpty(localDocInfo.URLPARAM5)) ? localDocInfo.URLPARAM5 : null;
            refDocInfo.PRINTTHRULINKDFLT = Convert.ToByte(localDocInfo.PRINTTHRULINKDFLT);
            refDocInfo.USEDEFAULTFILEPATH = Convert.ToByte(localDocInfo.USEDEFAULTFILEPATH);
            refDocInfo.SHOW = Convert.ToByte(localDocInfo.SHOW);
            if (localDocInfo.DOCINFOID.HasValue)
                refDocInfo.DOCINFOID = Convert.ToByte(localDocInfo.DOCINFOID);
             refDocInfo.HASLD = Convert.ToByte(localDocInfo.HASLD);
             refDocInfo.LANGCODE = (!String.IsNullOrEmpty(localDocInfo.LANGCODE)) ? localDocInfo.LANGCODE : null;
             refDocInfo.CONTENTUID = (!String.IsNullOrEmpty(localDocInfo.CONTENTUID)) ? localDocInfo.CONTENTUID : null;

        }

        internal static void PopulateAsset(CompositeAsset compositeAsset, ASSET localAsset )
        {
            var refAsset = compositeAsset.ASSET;
            refAsset.ANCESTOR =  (!String.IsNullOrEmpty(localAsset.ANCESTOR))? localAsset.ANCESTOR:null;
            refAsset.ASSETID = localAsset.ASSETID ?? 0;
            refAsset.ASSETNUM =  (!String.IsNullOrEmpty(localAsset.ASSETNUM))? localAsset.ASSETNUM:null;
            refAsset.ASSETTAG =  (!String.IsNullOrEmpty(localAsset.ASSETTAG))? localAsset.ASSETTAG:null;
            refAsset.ASSETTYPE =  (!String.IsNullOrEmpty(localAsset.ASSETTYPE))? localAsset.ASSETTYPE:null;
            refAsset.ASSETUID = localAsset.ASSETUID ?? 0;
            refAsset.AUTOWOGEN = Convert.ToByte(localAsset.AUTOWOGEN);
            refAsset.BINNUM =  (!String.IsNullOrEmpty(localAsset.BINNUM))? localAsset.BINNUM:null;
            refAsset.BUDGETCOST = Convert.ToDecimal(localAsset.BUDGETCOST);
            refAsset.CALNUM =  (!String.IsNullOrEmpty(localAsset.CALNUM))? localAsset.CALNUM:null;
            refAsset.CHANGEBY =  (!String.IsNullOrEmpty(localAsset.CHANGEBY))? localAsset.CHANGEBY:null;
            refAsset.CHANGEDATE =  localAsset.CHANGEDATE;
            refAsset.CHILDREN = Convert.ToByte(localAsset.CHILDREN);
            refAsset.CLASSSTRUCTUREID =  (!String.IsNullOrEmpty(localAsset.CLASSSTRUCTUREID))? localAsset.CLASSSTRUCTUREID:null;
            refAsset.CONDITIONCODE =  (!String.IsNullOrEmpty(localAsset.CONDITIONCODE))? localAsset.CONDITIONCODE:null;
            refAsset.DESCRIPTION =  (!String.IsNullOrEmpty(localAsset.DESCRIPTION))? localAsset.DESCRIPTION:null;
            refAsset.DISABLED = Convert.ToByte(localAsset.DISABLED);
            refAsset.EQ1 =  (!String.IsNullOrEmpty(localAsset.EQ1))? localAsset.EQ1:null;
            refAsset.EQ10 =  (!String.IsNullOrEmpty(localAsset.EQ10))? localAsset.EQ10:null;
            refAsset.EQ11 =  (!String.IsNullOrEmpty(localAsset.EQ11))? localAsset.EQ11:null;
            refAsset.EQ12 =  (!String.IsNullOrEmpty(localAsset.EQ12))? localAsset.EQ12:null;
            refAsset.EQ2 =  (!String.IsNullOrEmpty(localAsset.EQ2))? localAsset.EQ2:null;
            refAsset.EQ23 =  (localAsset.EQ23.HasValue)? localAsset.EQ23.Value :(DateTime?) null;
            refAsset.EQ24 =  (localAsset.EQ24.HasValue)?Convert.ToDecimal( localAsset.EQ24.Value) :(decimal?) null;
            refAsset.EQ3 =  (!String.IsNullOrEmpty(localAsset.EQ3))? localAsset.EQ3:null;
            refAsset.EQ4 =  (!String.IsNullOrEmpty(localAsset.EQ4))? localAsset.EQ4:null;
            refAsset.EQ5 =  (localAsset.EQ5.HasValue)?Convert.ToDecimal( localAsset.EQ5.Value) :(decimal?) null;
            refAsset.EQ6 =  (localAsset.EQ6.HasValue)? localAsset.EQ6.Value :(DateTime?) null;
            refAsset.EQ7 =  (!String.IsNullOrEmpty(localAsset.EQ7))? localAsset.EQ7:null;
            refAsset.EQ8 =  (!String.IsNullOrEmpty(localAsset.EQ8))? localAsset.EQ8:null;
            refAsset.EQ9 =  (!String.IsNullOrEmpty(localAsset.EQ9))? localAsset.EQ9:null;
            refAsset.EXTERNALREFID =  (!String.IsNullOrEmpty(localAsset.EXTERNALREFID))? localAsset.EXTERNALREFID:null;
            refAsset.FAILURECODE =  (!String.IsNullOrEmpty(localAsset.FAILURECODE))? localAsset.FAILURECODE:null;
            if (!String.IsNullOrEmpty(localAsset.GLACCOUNT))
                refAsset.GLACCOUNT = new ASSETGLACCOUNT
                {
                    VALUE=localAsset.GLACCOUNT,
                    GLCOMP = new ASSETGLACCOUNTGLCOMP{glorder = 0,Value = 0} //TODO: Get real values
                };

            refAsset.GROUPNAME =  (!String.IsNullOrEmpty(localAsset.GROUPNAME))? localAsset.GROUPNAME:null;
            refAsset.HASLD = Convert.ToByte(localAsset.HASLD);
            refAsset.INSTALLDATE =  (localAsset.INSTALLDATE.HasValue)? localAsset.INSTALLDATE.Value :(DateTime?) null;
            refAsset.INVCOST = Convert.ToDecimal(localAsset.INVCOST);
            refAsset.ISRUNNING = Convert.ToByte(localAsset.ISRUNNING);
            refAsset.ITEMNUM =  (!String.IsNullOrEmpty(localAsset.ITEMNUM))? localAsset.ITEMNUM:null;
            refAsset.ITEMSETID =  (!String.IsNullOrEmpty(localAsset.ITEMSETID))? localAsset.ITEMSETID:null;
            refAsset.ITEMTYPE =  (!String.IsNullOrEmpty(localAsset.ITEMTYPE))? localAsset.ITEMTYPE:null;
            refAsset.LANGCODE =  (!String.IsNullOrEmpty(localAsset.LANGCODE))? localAsset.LANGCODE:null;
            refAsset.LOCATION =  (!String.IsNullOrEmpty(localAsset.LOCATION))? localAsset.LOCATION:null;
            refAsset.MAINTHIERCHY = Convert.ToByte(localAsset.MAINTHIERCHY);
            refAsset.MANUFACTURER =  (!String.IsNullOrEmpty(localAsset.MANUFACTURER))? localAsset.MANUFACTURER:null;
            refAsset.MOVED = Convert.ToByte(localAsset.MOVED);
            refAsset.ORGID =  (!String.IsNullOrEmpty(localAsset.ORGID))? localAsset.ORGID:null;
            refAsset.OWNERSYSID =  (!String.IsNullOrEmpty(localAsset.OWNERSYSID))? localAsset.OWNERSYSID:null;
            refAsset.PARENT =  (!String.IsNullOrEmpty(localAsset.PARENT))? localAsset.PARENT:null;
            refAsset.PRIORITY =  (localAsset.PRIORITY.HasValue)? localAsset.PRIORITY.Value :(long?) null;
            refAsset.PURCHASEPRICE = Convert.ToDecimal(localAsset.PURCHASEPRICE);
            refAsset.REPLACECOST = Convert.ToDecimal(localAsset.REPLACECOST);
            if (!String.IsNullOrEmpty(localAsset.ROTSUSPACCT))
                refAsset.ROTSUSPACCT = new ASSETGLACCOUNT
                {
                    VALUE = localAsset.ROTSUSPACCT , 
                    GLCOMP = new ASSETGLACCOUNTGLCOMP{glorder=0, Value=0}
                };

            refAsset.SENDERSYSID =  (!String.IsNullOrEmpty(localAsset.SENDERSYSID))? localAsset.SENDERSYSID:null;
            refAsset.SERIALNUM =  (!String.IsNullOrEmpty(localAsset.SERIALNUM))? localAsset.SERIALNUM:null;
            refAsset.SHIFTNUM =  (!String.IsNullOrEmpty(localAsset.SHIFTNUM))? localAsset.SHIFTNUM:null;
            refAsset.SITEID =  (!String.IsNullOrEmpty(localAsset.SITEID))? localAsset.SITEID:null;
            refAsset.SOURCESYSID =  (!String.IsNullOrEmpty(localAsset.SOURCESYSID))? localAsset.SOURCESYSID:null;
            if(!String.IsNullOrEmpty(localAsset.STATUS))
               refAsset.STATUS = new ASSETSTATUS{maxvalue = localAsset.STATUS, Value = localAsset.STATUS};

            refAsset.STATUSDATE =  (localAsset.STATUSDATE.HasValue)? localAsset.STATUSDATE.Value :(DateTime?) null;
            if (!String.IsNullOrEmpty(localAsset.TOOLCONTROLACCOUNT))
                refAsset.ROTSUSPACCT = new ASSETGLACCOUNT
                {
                    VALUE = localAsset.TOOLCONTROLACCOUNT , 
                    GLCOMP = new ASSETGLACCOUNTGLCOMP{glorder=0, Value=0}
                }; 
            refAsset.TOOLRATE =  (localAsset.TOOLRATE.HasValue)?Convert.ToDecimal( localAsset.TOOLRATE.Value) :(decimal?) null;
            refAsset.TOTALCOST = Convert.ToDecimal(localAsset.TOTALCOST);
            refAsset.TOTDOWNTIME = Convert.ToDecimal(localAsset.TOTDOWNTIME);
            refAsset.TOTUNCHARGEDCOST = Convert.ToDecimal(localAsset.TOTUNCHARGEDCOST);
            refAsset.UNCHARGEDCOST = Convert.ToDecimal(localAsset.UNCHARGEDCOST);
            refAsset.USAGE =  (!String.IsNullOrEmpty(localAsset.USAGE))? localAsset.USAGE:null;
            refAsset.VENDOR =  (!String.IsNullOrEmpty(localAsset.VENDOR))? localAsset.VENDOR:null;
            refAsset.WARRANTYEXPDATE =  (localAsset.WARRANTYEXPDATE.HasValue)? localAsset.WARRANTYEXPDATE.Value :(DateTime?) null;
            refAsset.YTDCOST = Convert.ToDecimal(localAsset.YTDCOST);
            refAsset.EQ13 =  (!String.IsNullOrEmpty(localAsset.EQ13))? localAsset.EQ13:null;
            refAsset.EQ14 =  (!String.IsNullOrEmpty(localAsset.EQ14))? localAsset.EQ14:null;
            refAsset.EQ15 =  (!String.IsNullOrEmpty(localAsset.EQ15))? localAsset.EQ15:null;
            refAsset.EQ16 =  (!String.IsNullOrEmpty(localAsset.EQ16))? localAsset.EQ16:null;
            refAsset.EQ19 =  (localAsset.EQ19.HasValue)? localAsset.EQ19.Value :(DateTime?) null;
            refAsset.EQ22 = Convert.ToByte(localAsset.EQ22);
            refAsset.MAPNUM =  (!String.IsNullOrEmpty(localAsset.MAPNUM))? localAsset.MAPNUM:null;
            refAsset.FIXEDASSET = Convert.ToByte(localAsset.FIXEDASSET);
            refAsset.X1 =  (localAsset.X1.HasValue)?Convert.ToDecimal( localAsset.X1.Value) :(decimal?) null;
            refAsset.X2 =  (localAsset.X2.HasValue)?Convert.ToDecimal( localAsset.X2.Value) :(decimal?) null;
            refAsset.Y1 =  (localAsset.Y1.HasValue)?Convert.ToDecimal( localAsset.Y1.Value) :(decimal?) null;
            refAsset.Y2 =  (localAsset.Y2.HasValue)?Convert.ToDecimal( localAsset.Y2.Value) :(decimal?) null;
            refAsset.GLOBALID =  (!String.IsNullOrEmpty(localAsset.GLOBALID))? localAsset.GLOBALID:null;
            refAsset.DIRECTION =  (!String.IsNullOrEmpty(localAsset.DIRECTION))? localAsset.DIRECTION:null;
            refAsset.ENDDESCRIPTION =  (!String.IsNullOrEmpty(localAsset.ENDDESCRIPTION))? localAsset.ENDDESCRIPTION:null;
            refAsset.ENDMEASURE =  (localAsset.ENDMEASURE.HasValue)?Convert.ToDecimal( localAsset.ENDMEASURE.Value) :(decimal?) null;
            refAsset.ISLINEAR = Convert.ToByte(localAsset.ISLINEAR);
            refAsset.STARTDESCRIPTION =  (!String.IsNullOrEmpty(localAsset.STARTDESCRIPTION))? localAsset.STARTDESCRIPTION:null;
            refAsset.STARTMEASURE =  (localAsset.STARTMEASURE.HasValue)?Convert.ToDecimal( localAsset.STARTMEASURE.Value) :(decimal?) null;
            refAsset.LRM =  (!String.IsNullOrEmpty(localAsset.LRM))? localAsset.LRM:null;
            refAsset.PLUSSFEATURECLASS =  (!String.IsNullOrEmpty(localAsset.PLUSSFEATURECLASS))? localAsset.PLUSSFEATURECLASS:null;
            refAsset.PLUSSISGIS = Convert.ToByte(localAsset.PLUSSISGIS);
            refAsset.PLUSSADDRESSCODE =  (!String.IsNullOrEmpty(localAsset.PLUSSADDRESSCODE))? localAsset.PLUSSADDRESSCODE:null;
            refAsset.DEFAULTREPFACSITEID =  (!String.IsNullOrEmpty(localAsset.DEFAULTREPFACSITEID))? localAsset.DEFAULTREPFACSITEID:null;
            refAsset.DEFAULTREPFAC =  (!String.IsNullOrEmpty(localAsset.DEFAULTREPFAC))? localAsset.DEFAULTREPFAC:null;
            refAsset.RETURNEDTOVENDOR = localAsset.RETURNEDTOVENDOR;
            refAsset.TLOAMHASH =  (!String.IsNullOrEmpty(localAsset.TLOAMHASH))? localAsset.TLOAMHASH:null;
            refAsset.TLOAMPARTITION = localAsset.TLOAMPARTITION;
            refAsset.PLUSCASSETDEPT =  (!String.IsNullOrEmpty(localAsset.PLUSCASSETDEPT))? localAsset.PLUSCASSETDEPT:null;
            refAsset.PLUSCCLASS =  (!String.IsNullOrEmpty(localAsset.PLUSCCLASS))? localAsset.PLUSCCLASS:null;
            refAsset.PLUSCDUEDATE =  (localAsset.PLUSCDUEDATE.HasValue)? localAsset.PLUSCDUEDATE.Value :(DateTime?) null;
            refAsset.PLUSCISCONDESC =  (!String.IsNullOrEmpty(localAsset.PLUSCISCONDESC))? localAsset.PLUSCISCONDESC:null;
            refAsset.PLUSCISCONTAM = localAsset.PLUSCISCONTAM;
            refAsset.PLUSCISINHOUSECAL = localAsset.PLUSCISINHOUSECAL;
            refAsset.PLUSCISMTE = localAsset.PLUSCISMTE;
            refAsset.PLUSCISMTECLASS =  (!String.IsNullOrEmpty(localAsset.PLUSCISMTECLASS))? localAsset.PLUSCISMTECLASS:null;
            refAsset.PLUSCLOOPNUM =  (!String.IsNullOrEmpty(localAsset.PLUSCLOOPNUM))? localAsset.PLUSCLOOPNUM:null;
            refAsset.PLUSCMODELNUM =  (!String.IsNullOrEmpty(localAsset.PLUSCMODELNUM))? localAsset.PLUSCMODELNUM:null;
            refAsset.PLUSCOPRGEEU =  (!String.IsNullOrEmpty(localAsset.PLUSCOPRGEEU))? localAsset.PLUSCOPRGEEU:null;
            refAsset.PLUSCOPRGEFROM =  (!String.IsNullOrEmpty(localAsset.PLUSCOPRGEFROM))? localAsset.PLUSCOPRGEFROM:null;
            refAsset.PLUSCOPRGETO =  (!String.IsNullOrEmpty(localAsset.PLUSCOPRGETO))? localAsset.PLUSCOPRGETO:null;
            refAsset.PLUSCPHYLOC =  (!String.IsNullOrEmpty(localAsset.PLUSCPHYLOC))? localAsset.PLUSCPHYLOC:null;
            refAsset.PLUSCPMEXTDATE = localAsset.PLUSCPMEXTDATE;
            refAsset.PLUSCSOLUTION = localAsset.PLUSCSOLUTION;
            refAsset.PLUSCSUMDIR =  (!String.IsNullOrEmpty(localAsset.PLUSCSUMDIR))? localAsset.PLUSCSUMDIR:null;
            refAsset.PLUSCSUMEU =  (!String.IsNullOrEmpty(localAsset.PLUSCSUMEU))? localAsset.PLUSCSUMEU:null;
            refAsset.PLUSCSUMREAD =  (!String.IsNullOrEmpty(localAsset.PLUSCSUMREAD))? localAsset.PLUSCSUMREAD:null;
            refAsset.PLUSCSUMSPAN =  (!String.IsNullOrEmpty(localAsset.PLUSCSUMSPAN))? localAsset.PLUSCSUMSPAN:null;
            refAsset.PLUSCSUMURV =  (!String.IsNullOrEmpty(localAsset.PLUSCSUMURV))? localAsset.PLUSCSUMURV:null;
            refAsset.PLUSCVENDOR =  (!String.IsNullOrEmpty(localAsset.PLUSCVENDOR))? localAsset.PLUSCVENDOR:null;
            refAsset.ISCALIBRATION = localAsset.ISCALIBRATION;
            refAsset.TEMPLATEID =  (!String.IsNullOrEmpty(localAsset.TEMPLATEID))? localAsset.TEMPLATEID:null;
            refAsset.PLUSCLPLOC =  (!String.IsNullOrEmpty(localAsset.PLUSCLPLOC))? localAsset.PLUSCLPLOC:null;
            refAsset.SADDRESSCODE =  (!String.IsNullOrEmpty(localAsset.SADDRESSCODE))? localAsset.SADDRESSCODE:null;
            refAsset.GEOWORXSYNCID =  (!String.IsNullOrEmpty(localAsset.GEOWORXSYNCID))? localAsset.GEOWORXSYNCID:null;

            if (localAsset.AssetSpecs != null)
            {
                var i = 0;
                foreach (var assetSpec in localAsset.AssetSpecs)
                {
                    ReverseMapper.PopulateAssetSpec(compositeAsset.ASSETSPEC[i++],assetSpec);
                }
            }
        }

        internal static void PopulateAssetSpec( ASSETSPECMboSetASSETSPEC assetSpec, ASSETSPEC localAssetSpec)
        {
            assetSpec.ALNVALUE = (!String.IsNullOrEmpty(localAssetSpec.ALNVALUE))?localAssetSpec.ALNVALUE : null;
            assetSpec.ASSETATTRID = (!String.IsNullOrEmpty(localAssetSpec.ASSETATTRID)) ? localAssetSpec.ASSETATTRID : null;
            assetSpec.ASSETNUM = (!String.IsNullOrEmpty(localAssetSpec.ASSETNUM)) ? localAssetSpec.ASSETNUM : null;
            if(localAssetSpec.ASSETSPECID.HasValue)
              assetSpec.ASSETSPECID = localAssetSpec.ASSETSPECID.Value;
            assetSpec.CHANGEBY = (!String.IsNullOrEmpty(localAssetSpec.CHANGEBY)) ? localAssetSpec.CHANGEBY : null;
            assetSpec.CHANGEDATE = localAssetSpec.CHANGEDATE;
            assetSpec.CLASSSTRUCTUREID = (!String.IsNullOrEmpty(localAssetSpec.CLASSSTRUCTUREID)) ? localAssetSpec.CLASSSTRUCTUREID : null;
            assetSpec.DISPLAYSEQUENCE = localAssetSpec.DISPLAYSEQUENCE;
            assetSpec.ES01 = (!String.IsNullOrEmpty(localAssetSpec.ES01)) ? localAssetSpec.ES01 : null;
            assetSpec.ES02 = (!String.IsNullOrEmpty(localAssetSpec.ES02)) ? localAssetSpec.ES02 : null;
            assetSpec.ES03 = (!String.IsNullOrEmpty(localAssetSpec.ES02)) ? localAssetSpec.ES02 : null;
            assetSpec.ES04 = localAssetSpec.ES04;
            if (localAssetSpec.ES05.HasValue)
                assetSpec.ES05 = Convert.ToDecimal(localAssetSpec.ES05.Value);
            assetSpec.INHERITEDFROMITEM = Convert.ToByte(localAssetSpec.INHERITEDFROMITEM);
            assetSpec.ITEMSPECVALCHANGED = Convert.ToByte(localAssetSpec.ITEMSPECVALCHANGED);
            assetSpec.MEASUREUNITID = (!String.IsNullOrEmpty(localAssetSpec.MEASUREUNITID)) ? localAssetSpec.MEASUREUNITID : null;
            if (localAssetSpec.NUMVALUE.HasValue)
                assetSpec.NUMVALUE = Convert.ToDecimal(localAssetSpec.NUMVALUE.Value);
            assetSpec.ORGID = (!String.IsNullOrEmpty(localAssetSpec.ORGID)) ? localAssetSpec.ORGID : null;
            assetSpec.SECTION = (!String.IsNullOrEmpty(localAssetSpec.SECTION)) ? localAssetSpec.SECTION : null;
            assetSpec.SITEID = (!String.IsNullOrEmpty(localAssetSpec.SITEID)) ? localAssetSpec.SITEID : null;
            assetSpec.CONTINUOUS = Convert.ToByte(localAssetSpec.CONTINUOUS) ;
            if (localAssetSpec.ENDMEASURE.HasValue)
                assetSpec.ENDMEASURE = Convert.ToDecimal(localAssetSpec.ENDMEASURE);
            if (localAssetSpec.ENDOFFSET.HasValue)
                assetSpec.ENDOFFSET = Convert.ToDecimal(localAssetSpec.ENDOFFSET);
            if (localAssetSpec.ENDYOFFSET.HasValue)
                assetSpec.ENDYOFFSET = Convert.ToDecimal(localAssetSpec.ENDYOFFSET);
            assetSpec.ENDYOFFSETREF = (!String.IsNullOrEmpty(localAssetSpec.ENDYOFFSETREF)) ? localAssetSpec.ENDYOFFSETREF:null;
            if (localAssetSpec.ENDZOFFSET.HasValue)
                assetSpec.ENDZOFFSET = Convert.ToDecimal(localAssetSpec.ENDZOFFSET);
            assetSpec.ENDZOFFSETREF = (!String.IsNullOrEmpty(localAssetSpec.ENDZOFFSETREF)) ? localAssetSpec.ENDZOFFSETREF:null;
            assetSpec.LINKEDTOATTRIBUTE = (!String.IsNullOrEmpty(localAssetSpec.LINKEDTOATTRIBUTE)) ? localAssetSpec.LINKEDTOATTRIBUTE : null;
            assetSpec.LINKEDTOSECTION = (!String.IsNullOrEmpty(localAssetSpec.LINKEDTOSECTION)) ? localAssetSpec.LINKEDTOSECTION : null;
            assetSpec.MANDATORY = Convert.ToByte(localAssetSpec.MANDATORY);
            if (localAssetSpec.STARTMEASURE.HasValue)
                assetSpec.STARTMEASURE = Convert.ToDecimal(localAssetSpec.STARTMEASURE);
            if (localAssetSpec.STARTOFFSET.HasValue)
                assetSpec.STARTOFFSET = Convert.ToDecimal(localAssetSpec.STARTOFFSET);
            if (localAssetSpec.STARTYOFFSET.HasValue)
                assetSpec.STARTYOFFSET = Convert.ToDecimal(localAssetSpec.STARTYOFFSET);
            assetSpec.STARTYOFFSETREF = (!String.IsNullOrEmpty(localAssetSpec.STARTYOFFSETREF)) ? localAssetSpec.STARTYOFFSETREF : null;
            if (assetSpec.STARTZOFFSET.HasValue)
                assetSpec.STARTZOFFSET = Convert.ToDecimal(localAssetSpec.STARTZOFFSET);
            assetSpec.STARTZOFFSETREF = (!String.IsNullOrEmpty(localAssetSpec.STARTZOFFSETREF)) ? localAssetSpec.STARTZOFFSETREF : null;
            assetSpec.TABLEVALUE = (!String.IsNullOrEmpty(localAssetSpec.TABLEVALUE)) ? localAssetSpec.TABLEVALUE: null;
            assetSpec.BASEMEASUREUNITID = (!String.IsNullOrEmpty(localAssetSpec.BASEMEASUREUNITID)) ? localAssetSpec.BASEMEASUREUNITID: null;
            if (localAssetSpec.STARTBASEMEASURE.HasValue)
                assetSpec.STARTBASEMEASURE = Convert.ToDecimal(localAssetSpec.STARTBASEMEASURE);
            if (localAssetSpec.ENDBASEMEASURE.HasValue)
                assetSpec.ENDBASEMEASURE = Convert.ToDecimal(localAssetSpec.ENDBASEMEASURE);
            assetSpec.STARTMEASUREUNITID = (!String.IsNullOrEmpty(localAssetSpec.STARTMEASUREUNITID)) ? localAssetSpec.STARTMEASUREUNITID : null;
            assetSpec.ENDMEASUREUNITID = (!String.IsNullOrEmpty(localAssetSpec.ENDMEASUREUNITID)) ? localAssetSpec.ENDMEASUREUNITID : null;
            if (localAssetSpec.STARTASSETFEATUREID.HasValue)
                assetSpec.STARTASSETFEATUREID = localAssetSpec.STARTASSETFEATUREID;
            if (localAssetSpec.ENDASSETFEATUREID.HasValue)
                assetSpec.ENDASSETFEATUREID = localAssetSpec.ENDASSETFEATUREID;
            assetSpec.STARTOFFSETUNITID = (!String.IsNullOrEmpty(localAssetSpec.STARTOFFSETUNITID)) ? localAssetSpec.STARTOFFSETUNITID:null;
            assetSpec.ENDOFFSETUNITID = (!String.IsNullOrEmpty(localAssetSpec.ENDOFFSETUNITID)) ? localAssetSpec.ENDOFFSETUNITID:null;
            assetSpec.LINEARASSETSPECID = Convert.ToByte(localAssetSpec.LINEARASSETSPECID);
        }
    }
}
