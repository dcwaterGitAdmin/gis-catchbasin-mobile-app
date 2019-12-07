using System;
using System.Collections.Generic;
using System.Linq;
using DCWaterMobile.LocalData.Models;
using DCWaterMobile.MaximoService;
using DCWaterMobile.MaximoService.MaxRest;

namespace DCWaterMobile.LocalData
{
    public static class Comparer
    {
        public static bool IsDirty(WORKORDER workorder)
        {
            if (workorder.C_record_state_ != (long) LocalState.Original)
                return true;

            if (workorder.WorkorderSpecs != null)
            {
                var dirtyCount = (from ws in workorder.WorkorderSpecs
                                      where ws.C_record_state_ != (long)LocalState.Original
                                      select ws).Count();
                if (dirtyCount > 0)
                    return true;

            }
            if (workorder.WoStatuses != null)
            {
                var dirtyCount = (from ws in workorder.WoStatuses
                                  where ws.C_record_state_ != (long)LocalState.Original
                                  select ws).Count();
                if (dirtyCount > 0)
                    return true;

            }


            if (workorder.LabTrans != null)
            {
                var dirtyCount = (from ws in workorder.LabTrans
                                      where ws.C_record_state_ != (long)LocalState.Original
                                      select ws).Count();
                if (dirtyCount > 0)
                    return true;
                
            }

            if (workorder.ToolTrans != null)
            {
                var dirtyCount = (from ws in workorder.ToolTrans
                                      where ws.C_record_state_ != (long)LocalState.Original
                                      select ws).Count();
                if (dirtyCount > 0)
                    return true;
            }
            if (workorder.Doclinks != null)
            {
                var dirtyCount = (from ws in workorder.Doclinks
                                      where ws.C_record_state_ != (long)LocalState.Original
                                      select ws).Count();
                if (dirtyCount > 0)
                    return true;
            }
            if (workorder.FailureReports != null)
            {
                var dirtyCount = (from ws in workorder.FailureReports
                                  where ws.C_record_state_ != (long)LocalState.Original
                                  select ws).Count();
                if (dirtyCount > 0)
                    return true;
            }

            if (workorder.FailureRemark != null)
            {
                if (workorder.FailureRemark.C_record_state_ != (long) LocalState.Original)
                    return true;
            }

            if (workorder.Asset != null)
            {
                return IsDirty(workorder.Asset);
            }

            return false;
        }

        public static bool IsDirty(ASSET asset)
        {
            if (asset == null)
                return false;

            if (asset.C_record_state_ != (long) LocalState.Original)
                return true;
            if (asset.AssetSpecs != null)
            {
                var dirtySpecCount = (from assetSpec in asset.AssetSpecs
                    where assetSpec.C_record_state_ != (long) LocalState.Original
                    select assetSpec).Count();
                return dirtySpecCount > 0;
            }
            return false;
        }

        public static bool NeedsUpdate(WORKORDER localWorkorder, CompositeWorkorder downloadedWorkorder)
        {
            if ((localWorkorder == null) && ((downloadedWorkorder == null) || (downloadedWorkorder.WORKORDER == null)))
                return false;

            if (localWorkorder == null)
                return true;

            if (localWorkorder.C_record_state_ != (long) LocalState.Original)
                return true;
            var downloadedWo = downloadedWorkorder.WORKORDER;
            if (!IsEqualTo(localWorkorder.CHANGEDATE, downloadedWo.CHANGEDATE)) return true;
            if (!IsEqualTo(localWorkorder.WONUM, downloadedWo.WONUM)) return true;
            if (!IsEqualTo(localWorkorder.PARENT, downloadedWo.PARENT)) return true;
            if (!IsEqualTo(localWorkorder.STATUS, downloadedWo.STATUS)) return true;
            if (!IsEqualTo(localWorkorder.STATUSDATE, downloadedWo.STATUSDATE)) return true;
            if (!IsEqualTo(localWorkorder.WORKTYPE, downloadedWo.WORKTYPE)) return true;
            if (!IsEqualTo(localWorkorder.LEADCRAFT, downloadedWo.LEADCRAFT)) return true;
            if (!IsEqualTo(localWorkorder.DESCRIPTION, downloadedWo.DESCRIPTION)) return true;
            if (!IsEqualTo(localWorkorder.LOCATION, downloadedWo.LOCATION)) return true;
            if (!IsEqualTo(localWorkorder.JPNUM, downloadedWo.JPNUM)) return true;
            if (!IsEqualTo(localWorkorder.FAILDATE, downloadedWo.FAILDATE)) return true;
            if (!IsEqualTo(localWorkorder.CHANGEBY, downloadedWo.CHANGEBY)) return true;
            if (!IsEqualTo(localWorkorder.ESTDUR, downloadedWo.ESTDUR)) return true;
            if (!IsEqualTo(localWorkorder.ESTLABHRS, downloadedWo.ESTLABHRS)) return true;
            if (!IsEqualTo(localWorkorder.ESTMATCOST, downloadedWo.ESTMATCOST)) return true;
            if (!IsEqualTo(localWorkorder.ESTLABCOST, downloadedWo.ESTLABCOST)) return true;
            if (!IsEqualTo(localWorkorder.ESTTOOLCOST, downloadedWo.ESTTOOLCOST)) return true;
            if (!IsEqualTo(localWorkorder.PMNUM, downloadedWo.PMNUM)) return true;
            if (!IsEqualTo(localWorkorder.ACTLABHRS, downloadedWo.ACTLABHRS)) return true;
            if (!IsEqualTo(localWorkorder.ACTMATCOST, downloadedWo.ACTMATCOST)) return true;
            if (!IsEqualTo(localWorkorder.ACTLABCOST, downloadedWo.ACTLABCOST)) return true;
            if (!IsEqualTo(localWorkorder.ACTTOOLCOST, downloadedWo.ACTTOOLCOST)) return true;
            if (!IsEqualTo(localWorkorder.HASCHILDREN, downloadedWo.HASCHILDREN)) return true;
            if (!IsEqualTo(localWorkorder.OUTLABCOST, downloadedWo.OUTLABCOST)) return true;
            if (!IsEqualTo(localWorkorder.OUTMATCOST, downloadedWo.OUTMATCOST)) return true;
            if (!IsEqualTo(localWorkorder.OUTTOOLCOST, downloadedWo.OUTTOOLCOST)) return true;
            if (!IsEqualTo(localWorkorder.HISTORYFLAG, downloadedWo.HISTORYFLAG)) return true;
            if (!IsEqualTo(localWorkorder.CONTRACT, downloadedWo.CONTRACT)) return true;
            if (!IsEqualTo(localWorkorder.WOPRIORITY, downloadedWo.WOPRIORITY)) return true;
            if (!IsEqualTo(localWorkorder.TARGCOMPDATE, downloadedWo.TARGCOMPDATE)) return true;
            if (!IsEqualTo(localWorkorder.TARGSTARTDATE, downloadedWo.TARGSTARTDATE)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ1, downloadedWo.WOEQ1)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ2, downloadedWo.WOEQ2)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ3, downloadedWo.WOEQ3)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ4, downloadedWo.WOEQ4)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ5, downloadedWo.WOEQ5)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ6, downloadedWo.WOEQ6)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ7, downloadedWo.WOEQ7)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ8, downloadedWo.WOEQ8)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ9, downloadedWo.WOEQ9)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ10, downloadedWo.WOEQ10)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ11, downloadedWo.WOEQ11)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ12, downloadedWo.WOEQ12)) return true;
            if (!IsEqualTo(localWorkorder.WO1, downloadedWo.WO1)) return true;
            if (!IsEqualTo(localWorkorder.WO3, downloadedWo.WO3)) return true;
            if (!IsEqualTo(localWorkorder.WO4, downloadedWo.WO4)) return true;
            if (!IsEqualTo(localWorkorder.WO7, downloadedWo.WO7)) return true;
            if (!IsEqualTo(localWorkorder.WO9, downloadedWo.WO9)) return true;
            if (!IsEqualTo(localWorkorder.WO10, downloadedWo.WO10)) return true;
            if (!IsEqualTo(localWorkorder.REPORTEDBY, downloadedWo.REPORTEDBY)) return true;
            if (!IsEqualTo(localWorkorder.REPORTDATE, downloadedWo.REPORTDATE)) return true;
            if (!IsEqualTo(localWorkorder.PHONE, downloadedWo.PHONE)) return true;
            if (!IsEqualTo(localWorkorder.PROBLEMCODE, downloadedWo.PROBLEMCODE)) return true;
            if (!IsEqualTo(localWorkorder.CALENDAR, downloadedWo.CALENDAR)) return true;
            if (!IsEqualTo(localWorkorder.DOWNTIME, downloadedWo.DOWNTIME)) return true;
            if (!IsEqualTo(localWorkorder.ACTSTART, downloadedWo.ACTSTART)) return true;
            if (!IsEqualTo(localWorkorder.ACTFINISH, downloadedWo.ACTFINISH)) return true;
            if (!IsEqualTo(localWorkorder.SCHEDSTART, downloadedWo.SCHEDSTART)) return true;
            if (!IsEqualTo(localWorkorder.SCHEDFINISH, downloadedWo.SCHEDFINISH)) return true;
            if (!IsEqualTo(localWorkorder.REMDUR, downloadedWo.REMDUR)) return true;
            if (!IsEqualTo(localWorkorder.CREWID, downloadedWo.CREWID)) return true;
            if (!IsEqualTo(localWorkorder.SUPERVISOR, downloadedWo.SUPERVISOR)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ13, downloadedWo.WOEQ13)) return true;
            if (!IsEqualTo(localWorkorder.WOEQ14, downloadedWo.WOEQ14)) return true;
            if (!IsEqualTo(localWorkorder.WOJP1, downloadedWo.WOJP1)) return true;
            if (!IsEqualTo(localWorkorder.WOJP2, downloadedWo.WOJP2)) return true;
            if (!IsEqualTo(localWorkorder.WOJP3, downloadedWo.WOJP3)) return true;
            if (!IsEqualTo(localWorkorder.WOJP4, downloadedWo.WOJP4)) return true;
            if (!IsEqualTo(localWorkorder.WOJP5, downloadedWo.WOJP5)) return true;
            if (!IsEqualTo(localWorkorder.WOL1, downloadedWo.WOL1)) return true;
            if (!IsEqualTo(localWorkorder.WOL2, downloadedWo.WOL2)) return true;
            if (!IsEqualTo(localWorkorder.WOL3, downloadedWo.WOL3)) return true;
            if (!IsEqualTo(localWorkorder.WOL4, downloadedWo.WOL4)) return true;
            if (!IsEqualTo(localWorkorder.WOLABLNK, downloadedWo.WOLABLNK)) return true;
            if (!IsEqualTo(localWorkorder.RESPONDBY, downloadedWo.RESPONDBY)) return true;
            if (!IsEqualTo(localWorkorder.CALCPRIORITY, downloadedWo.CALCPRIORITY)) return true;
            if (!IsEqualTo(localWorkorder.CHARGESTORE, downloadedWo.CHARGESTORE)) return true;
            if (!IsEqualTo(localWorkorder.FAILURECODE, downloadedWo.FAILURECODE)) return true;
            if (!IsEqualTo(localWorkorder.WOLO1, downloadedWo.WOLO1)) return true;
            if (!IsEqualTo(localWorkorder.WOLO2, downloadedWo.WOLO2)) return true;
            if (!IsEqualTo(localWorkorder.WOLO3, downloadedWo.WOLO3)) return true;
            if (!IsEqualTo(localWorkorder.WOLO4, downloadedWo.WOLO4)) return true;
            if (!IsEqualTo(localWorkorder.WOLO5, downloadedWo.WOLO5)) return true;
            if (!IsEqualTo(localWorkorder.WOLO6, downloadedWo.WOLO6)) return true;
            if (!IsEqualTo(localWorkorder.WOLO7, downloadedWo.WOLO7)) return true;
            if (!IsEqualTo(localWorkorder.WOLO8, downloadedWo.WOLO8)) return true;
            if (!IsEqualTo(localWorkorder.WOLO9, downloadedWo.WOLO9)) return true;
            if (!IsEqualTo(localWorkorder.WOLO10, downloadedWo.WOLO10)) return true;
            if (!IsEqualTo(localWorkorder.GLACCOUNT, downloadedWo.GLACCOUNT)) return true;
            if (!IsEqualTo(localWorkorder.ESTSERVCOST, downloadedWo.ESTSERVCOST)) return true;
            if (!IsEqualTo(localWorkorder.ACTSERVCOST, downloadedWo.ACTSERVCOST)) return true;
            if (!IsEqualTo(localWorkorder.DISABLED, downloadedWo.DISABLED)) return true;
            if (!IsEqualTo(localWorkorder.ESTATAPPRLABHRS, downloadedWo.ESTATAPPRLABHRS)) return true;
            if (!IsEqualTo(localWorkorder.ESTATAPPRLABCOST, downloadedWo.ESTATAPPRLABCOST)) return true;
            if (!IsEqualTo(localWorkorder.ESTATAPPRMATCOST, downloadedWo.ESTATAPPRMATCOST)) return true;
            if (!IsEqualTo(localWorkorder.ESTATAPPRTOOLCOST, downloadedWo.ESTATAPPRTOOLCOST)) return true;
            if (!IsEqualTo(localWorkorder.ESTATAPPRSERVCOST, downloadedWo.ESTATAPPRSERVCOST)) return true;
            if (!IsEqualTo(localWorkorder.WOSEQUENCE, downloadedWo.WOSEQUENCE)) return true;
            if (!IsEqualTo(localWorkorder.HASFOLLOWUPWORK, downloadedWo.HASFOLLOWUPWORK)) return true;
            if (!IsEqualTo(localWorkorder.WORTS1, downloadedWo.WORTS1)) return true;
            if (!IsEqualTo(localWorkorder.WORTS2, downloadedWo.WORTS2)) return true;
            if (!IsEqualTo(localWorkorder.WORTS3, downloadedWo.WORTS3)) return true;
            if (!IsEqualTo(localWorkorder.WORTS4, downloadedWo.WORTS4)) return true;
            if (!IsEqualTo(localWorkorder.WORTS5, downloadedWo.WORTS5)) return true;
            if (!IsEqualTo(localWorkorder.SOURCESYSID, downloadedWo.SOURCESYSID)) return true;
            if (!IsEqualTo(localWorkorder.OWNERSYSID, downloadedWo.OWNERSYSID)) return true;
            if (!IsEqualTo(localWorkorder.PMDUEDATE, downloadedWo.PMDUEDATE)) return true;
            if (!IsEqualTo(localWorkorder.PMEXTDATE, downloadedWo.PMEXTDATE)) return true;
            if (!IsEqualTo(localWorkorder.PMNEXTDUEDATE, downloadedWo.PMNEXTDUEDATE)) return true;
            if (!IsEqualTo(localWorkorder.WORKLOCATION, downloadedWo.WORKLOCATION)) return true;
            if (!IsEqualTo(localWorkorder.WO11, downloadedWo.WO11)) return true;
            if (!IsEqualTo(localWorkorder.WO13, downloadedWo.WO13)) return true;
            if (!IsEqualTo(localWorkorder.WO14, downloadedWo.WO14)) return true;
            if (!IsEqualTo(localWorkorder.WO15, downloadedWo.WO15)) return true;
            if (!IsEqualTo(localWorkorder.WO16, downloadedWo.WO16)) return true;
            if (!IsEqualTo(localWorkorder.WO17, downloadedWo.WO17)) return true;
            if (!IsEqualTo(localWorkorder.WO18, downloadedWo.WO18)) return true;
            if (!IsEqualTo(localWorkorder.WO19, downloadedWo.WO19)) return true;
            if (!IsEqualTo(localWorkorder.WO20, downloadedWo.WO20)) return true;
            if (!IsEqualTo(localWorkorder.EXTERNALREFID, downloadedWo.EXTERNALREFID)) return true;
            if (!IsEqualTo(localWorkorder.SENDERSYSID, downloadedWo.SENDERSYSID)) return true;
            if (!IsEqualTo(localWorkorder.FINCNTRLID, downloadedWo.FINCNTRLID)) return true;
            if (!IsEqualTo(localWorkorder.GENERATEDFORPO, downloadedWo.GENERATEDFORPO)) return true;
            if (!IsEqualTo(localWorkorder.GENFORPOLINEID, downloadedWo.GENFORPOLINEID)) return true;
            if (!IsEqualTo(localWorkorder.ORGID, downloadedWo.ORGID)) return true;
            if (!IsEqualTo(localWorkorder.SITEID, downloadedWo.SITEID)) return true;
            if (!IsEqualTo(localWorkorder.TASKID, downloadedWo.TASKID)) return true;
            if (!IsEqualTo(localWorkorder.INSPECTOR, downloadedWo.INSPECTOR)) return true;
            if (!IsEqualTo(localWorkorder.MEASUREMENTVALUE, downloadedWo.MEASUREMENTVALUE)) return true;
            if (!IsEqualTo(localWorkorder.MEASUREDATE, downloadedWo.MEASUREDATE)) return true;
            if (!IsEqualTo(localWorkorder.OBSERVATION, downloadedWo.OBSERVATION)) return true;
            if (!IsEqualTo(localWorkorder.POINTNUM, downloadedWo.POINTNUM)) return true;
            if (!IsEqualTo(localWorkorder.WOJO1, downloadedWo.WOJO1)) return true;
            if (!IsEqualTo(localWorkorder.WOJO2, downloadedWo.WOJO2)) return true;
            if (!IsEqualTo(localWorkorder.WOJO3, downloadedWo.WOJO3)) return true;
            if (!IsEqualTo(localWorkorder.WOJO4, downloadedWo.WOJO4)) return true;
            if (!IsEqualTo(localWorkorder.WOJO5, downloadedWo.WOJO5)) return true;
            if (!IsEqualTo(localWorkorder.WOJO6, downloadedWo.WOJO6)) return true;
            if (!IsEqualTo(localWorkorder.WOJO7, downloadedWo.WOJO7)) return true;
            if (!IsEqualTo(localWorkorder.WOJO8, downloadedWo.WOJO8)) return true;
            if (!IsEqualTo(localWorkorder.ISTASK, downloadedWo.ISTASK)) return true;
            if (!IsEqualTo(localWorkorder.SERVICE, downloadedWo.SERVICE)) return true;
            if (!IsEqualTo(localWorkorder.ORIGPROBLEMTYPE, downloadedWo.ORIGPROBLEMTYPE)) return true;
            if (!IsEqualTo(localWorkorder.CISNUM, downloadedWo.CISNUM)) return true;
            if (!IsEqualTo(localWorkorder.MISSUTILITYDATE, downloadedWo.MISSUTILITYDATE)) return true;
            if (!IsEqualTo(localWorkorder.MISSUTILITYNUM, downloadedWo.MISSUTILITYNUM)) return true;
            if (!IsEqualTo(localWorkorder.MISSUTILITYEMERG, downloadedWo.MISSUTILITYEMERG)) return true;
            if (!IsEqualTo(localWorkorder.MAPNUM, downloadedWo.MAPNUM)) return true;
            if (!IsEqualTo(localWorkorder.RECEIVEDVIA, downloadedWo.RECEIVEDVIA)) return true;
            if (!IsEqualTo(localWorkorder.LOCATIONDETAILS, downloadedWo.LOCATIONDETAILS)) return true;
            if (!IsEqualTo(localWorkorder.OTHERCONTACT, downloadedWo.OTHERCONTACT)) return true;
            if (!IsEqualTo(localWorkorder.WATERDISCOLORED, downloadedWo.WATERDISCOLORED)) return true;
            if (!IsEqualTo(localWorkorder.WATERCOLOR, downloadedWo.WATERCOLOR)) return true;
            if (!IsEqualTo(localWorkorder.DISCOLORHOTCOLD, downloadedWo.DISCOLORHOTCOLD)) return true;
            if (!IsEqualTo(localWorkorder.RUN15MINUTES, downloadedWo.RUN15MINUTES)) return true;
            if (!IsEqualTo(localWorkorder.PARTICLESINWATER, downloadedWo.PARTICLESINWATER)) return true;
            if (!IsEqualTo(localWorkorder.PARTICLECOLOR, downloadedWo.PARTICLECOLOR)) return true;
            if (!IsEqualTo(localWorkorder.WATERCLOUDY, downloadedWo.WATERCLOUDY)) return true;
            if (!IsEqualTo(localWorkorder.WATERODOR, downloadedWo.WATERODOR)) return true;
            if (!IsEqualTo(localWorkorder.TYPEODOR, downloadedWo.TYPEODOR)) return true;
            if (!IsEqualTo(localWorkorder.WATERCAUSERASH, downloadedWo.WATERCAUSERASH)) return true;
            if (!IsEqualTo(localWorkorder.PERSONSEENDOCTOR, downloadedWo.PERSONSEENDOCTOR)) return true;
            if (!IsEqualTo(localWorkorder.MEDICALREPORT, downloadedWo.MEDICALREPORT)) return true;
            if (!IsEqualTo(localWorkorder.CONNECTIONTYPE, downloadedWo.CONNECTIONTYPE)) return true;
            if (!IsEqualTo(localWorkorder.PROBLEMBEGAN, downloadedWo.PROBLEMBEGAN)) return true;
            if (!IsEqualTo(localWorkorder.PROBLEMLOC, downloadedWo.PROBLEMLOC)) return true;
            if (!IsEqualTo(localWorkorder.PROBLEMTHRUOUT, downloadedWo.PROBLEMTHRUOUT)) return true;
            if (!IsEqualTo(localWorkorder.LOCALIZEDWHERE, downloadedWo.LOCALIZEDWHERE)) return true;
            if (!IsEqualTo(localWorkorder.WATERTREATMENT, downloadedWo.WATERTREATMENT)) return true;
            if (!IsEqualTo(localWorkorder.TYPETREATMENT, downloadedWo.TYPETREATMENT)) return true;
            if (!IsEqualTo(localWorkorder.MEASUREMENTVALUE2, downloadedWo.MEASUREMENTVALUE2)) return true;
            if (!IsEqualTo(localWorkorder.MEASUREMENTVALUE3, downloadedWo.MEASUREMENTVALUE3)) return true;
            if (!IsEqualTo(localWorkorder.SAMPLELOCTYPE, downloadedWo.SAMPLELOCTYPE)) return true;
            if (!IsEqualTo(localWorkorder.PETROLEUMODOR, downloadedWo.PETROLEUMODOR)) return true;
            if (!IsEqualTo(localWorkorder.CUTNUM, downloadedWo.CUTNUM)) return true;
            if (!IsEqualTo(localWorkorder.DISTANCE, downloadedWo.DISTANCE)) return true;
            if (!IsEqualTo(localWorkorder.FINALPOSITION, downloadedWo.FINALPOSITION)) return true;
            if (!IsEqualTo(localWorkorder.NUMBEROFTURNS, downloadedWo.NUMBEROFTURNS)) return true;
            if (!IsEqualTo(localWorkorder.WATERTASTE, downloadedWo.WATERTASTE)) return true;
            if (!IsEqualTo(localWorkorder.WATERTASTEDESC, downloadedWo.WATERTASTEDESC)) return true;
            if (!IsEqualTo(localWorkorder.FUND, downloadedWo.FUND)) return true;
            if (!IsEqualTo(localWorkorder.OUTLETDIA, downloadedWo.OUTLETDIA)) return true;
            if (!IsEqualTo(localWorkorder.VELOCITYPRES, downloadedWo.VELOCITYPRES)) return true;
            if (!IsEqualTo(localWorkorder.SNAKELINE, downloadedWo.SNAKELINE)) return true;
            if (!IsEqualTo(localWorkorder.JETLINE, downloadedWo.JETLINE)) return true;
            if (!IsEqualTo(localWorkorder.PROBLEMSIDE, downloadedWo.PROBLEMSIDE)) return true;
            if (!IsEqualTo(localWorkorder.MEASUREMENTVALUE4, downloadedWo.MEASUREMENTVALUE4)) return true;
            if (!IsEqualTo(localWorkorder.VALIDATED, downloadedWo.VALIDATED)) return true;
            if (!IsEqualTo(localWorkorder.CUSTOMERSTREET, downloadedWo.CUSTOMERSTREET)) return true;
            if (!IsEqualTo(localWorkorder.CUSTOMERCITY, downloadedWo.CUSTOMERCITY)) return true;
            if (!IsEqualTo(localWorkorder.CUSTOMERSTATE, downloadedWo.CUSTOMERSTATE)) return true;
            if (!IsEqualTo(localWorkorder.CUSTOMERZIP, downloadedWo.CUSTOMERZIP)) return true;
            if (!IsEqualTo(localWorkorder.CUSTOMEREMAIL, downloadedWo.CUSTOMEREMAIL)) return true;
            if (!IsEqualTo(localWorkorder.ALTPHONEFAX, downloadedWo.ALTPHONEFAX)) return true;
            if (!IsEqualTo(localWorkorder.OTHERCOMPANY, downloadedWo.OTHERCOMPANY)) return true;
            if (!IsEqualTo(localWorkorder.PLUMBERNAME, downloadedWo.PLUMBERNAME)) return true;
            if (!IsEqualTo(localWorkorder.PLUMBERLICNUM, downloadedWo.PLUMBERLICNUM)) return true;
            if (!IsEqualTo(localWorkorder.SEWERRELIEVED, downloadedWo.SEWERRELIEVED)) return true;
            if (!IsEqualTo(localWorkorder.SNAKELOC, downloadedWo.SNAKELOC)) return true;
            if (!IsEqualTo(localWorkorder.SNAKETOSEWER, downloadedWo.SNAKETOSEWER)) return true;
            if (!IsEqualTo(localWorkorder.CLEANOUT, downloadedWo.CLEANOUT)) return true;
            if (!IsEqualTo(localWorkorder.CLEANOUTLOC, downloadedWo.CLEANOUTLOC)) return true;
            if (!IsEqualTo(localWorkorder.RUNNINGTRAP, downloadedWo.RUNNINGTRAP)) return true;
            if (!IsEqualTo(localWorkorder.RUNNINGTRAPLOC, downloadedWo.RUNNINGTRAPLOC)) return true;
            if (!IsEqualTo(localWorkorder.EQUIPMENTUSED, downloadedWo.EQUIPMENTUSED)) return true;
            if (!IsEqualTo(localWorkorder.JUSTIFICATION, downloadedWo.JUSTIFICATION)) return true;
            if (!IsEqualTo(localWorkorder.DEBRIS, downloadedWo.DEBRIS)) return true;
            if (!IsEqualTo(localWorkorder.DEBRISDESC, downloadedWo.DEBRISDESC)) return true;
            if (!IsEqualTo(localWorkorder.WEATHERCOND, downloadedWo.WEATHERCOND)) return true;
            if (!IsEqualTo(localWorkorder.WINDS, downloadedWo.WINDS)) return true;
            if (!IsEqualTo(localWorkorder.TEMPERATURE, downloadedWo.TEMPERATURE)) return true;
            if (!IsEqualTo(localWorkorder.PRECIPITATION, downloadedWo.PRECIPITATION)) return true;
            if (!IsEqualTo(localWorkorder.ENGINEERCOMPANY, downloadedWo.ENGINEERCOMPANY)) return true;
            if (!IsEqualTo(localWorkorder.DEVELOPERCOMPANY, downloadedWo.DEVELOPERCOMPANY)) return true;
            if (!IsEqualTo(localWorkorder.DEVELOPERCONTACT, downloadedWo.DEVELOPERCONTACT)) return true;
            if (!IsEqualTo(localWorkorder.DEVELOPERPHONE, downloadedWo.DEVELOPERPHONE)) return true;
            if (!IsEqualTo(localWorkorder.AGENCYID, downloadedWo.AGENCYID)) return true;
            if (!IsEqualTo(localWorkorder.RECEIVEDAT, downloadedWo.RECEIVEDAT)) return true;
            if (!IsEqualTo(localWorkorder.CONTRACTORCONTACT, downloadedWo.CONTRACTORCONTACT)) return true;
            if (!IsEqualTo(localWorkorder.ENUM, downloadedWo.ENUM)) return true;
            if (!IsEqualTo(localWorkorder.PIPETYPE, downloadedWo.PIPETYPE)) return true;
            if (!IsEqualTo(localWorkorder.PERMITDATE, downloadedWo.PERMITDATE)) return true;
            if (!IsEqualTo(localWorkorder.ASBUILTREQD, downloadedWo.ASBUILTREQD)) return true;
            if (!IsEqualTo(localWorkorder.ASBUILTRECD, downloadedWo.ASBUILTRECD)) return true;
            if (!IsEqualTo(localWorkorder.CONTRACTORPHONE, downloadedWo.CONTRACTORPHONE)) return true;
            if (!IsEqualTo(localWorkorder.PROJECTTYPE, downloadedWo.PROJECTTYPE)) return true;
            if (!IsEqualTo(localWorkorder.ASSETLOCPRIORITY, downloadedWo.ASSETLOCPRIORITY)) return true;
            if (!IsEqualTo(localWorkorder.ASSETNUM, downloadedWo.ASSETNUM)) return true;
            if (!IsEqualTo(localWorkorder.BACKOUTPLAN, downloadedWo.BACKOUTPLAN)) return true;
            if (!IsEqualTo(localWorkorder.CLASSSTRUCTUREID, downloadedWo.CLASSSTRUCTUREID)) return true;
            if (!IsEqualTo(localWorkorder.COMMODITY, downloadedWo.COMMODITY)) return true;
            if (!IsEqualTo(localWorkorder.COMMODITYGROUP, downloadedWo.COMMODITYGROUP)) return true;
            if (!IsEqualTo(localWorkorder.ENVIRONMENT, downloadedWo.ENVIRONMENT)) return true;
            if (!IsEqualTo(localWorkorder.HASLD, downloadedWo.HASLD)) return true;
            if (!IsEqualTo(localWorkorder.INTERRUPTIBLE, downloadedWo.INTERRUPTIBLE)) return true;
            if (!IsEqualTo(localWorkorder.JUSTIFYPRIORITY, downloadedWo.JUSTIFYPRIORITY)) return true;
            if (!IsEqualTo(localWorkorder.LANGCODE, downloadedWo.LANGCODE)) return true;
            if (!IsEqualTo(localWorkorder.LEAD, downloadedWo.LEAD)) return true;
            if (!IsEqualTo(localWorkorder.ONBEHALFOF, downloadedWo.ONBEHALFOF)) return true;
            if (!IsEqualTo(localWorkorder.ORIGRECORDCLASS, downloadedWo.ORIGRECORDCLASS)) return true;
            if (!IsEqualTo(localWorkorder.ORIGRECORDID, downloadedWo.ORIGRECORDID)) return true;
            if (!IsEqualTo(localWorkorder.OWNER, downloadedWo.OWNER)) return true;
            if (!IsEqualTo(localWorkorder.OWNERGROUP, downloadedWo.OWNERGROUP)) return true;
            if (!IsEqualTo(localWorkorder.PARENTCHGSSTATUS, downloadedWo.PARENTCHGSSTATUS)) return true;
            if (!IsEqualTo(localWorkorder.PERSONGROUP, downloadedWo.PERSONGROUP)) return true;
            if (!IsEqualTo(localWorkorder.REASONFORCHANGE, downloadedWo.REASONFORCHANGE)) return true;
            if (!IsEqualTo(localWorkorder.RISK, downloadedWo.RISK)) return true;
            if (!IsEqualTo(localWorkorder.VENDOR, downloadedWo.VENDOR)) return true;
            if (!IsEqualTo(localWorkorder.VERIFICATION, downloadedWo.VERIFICATION)) return true;
            if (!IsEqualTo(localWorkorder.WHOMISCHANGEFOR, downloadedWo.WHOMISCHANGEFOR)) return true;
            if (!IsEqualTo(localWorkorder.WOACCEPTSCHARGES, downloadedWo.WOACCEPTSCHARGES)) return true;
            if (!IsEqualTo(localWorkorder.WOCLASS, downloadedWo.WOCLASS)) return true;
            if (!IsEqualTo(localWorkorder.WOGROUP, downloadedWo.WOGROUP)) return true;
            if (!IsEqualTo(localWorkorder.WORKORDERID, downloadedWo.WORKORDERID)) return true;
            if (!IsEqualTo(localWorkorder.BKPCONTRACT, downloadedWo.BKPCONTRACT)) return true;
            if (!IsEqualTo(localWorkorder.CINUM, downloadedWo.CINUM)) return true;
            if (!IsEqualTo(localWorkorder.FLOWACTION, downloadedWo.FLOWACTION)) return true;
            if (!IsEqualTo(localWorkorder.FLOWACTIONASSIST, downloadedWo.FLOWACTIONASSIST)) return true;
            if (!IsEqualTo(localWorkorder.FLOWCONTROLLED, downloadedWo.FLOWCONTROLLED)) return true;
            if (!IsEqualTo(localWorkorder.JOBTASKID, downloadedWo.JOBTASKID)) return true;
            if (!IsEqualTo(localWorkorder.LAUNCHENTRYNAME, downloadedWo.LAUNCHENTRYNAME)) return true;
            if (!IsEqualTo(localWorkorder.NEWCHILDCLASS, downloadedWo.NEWCHILDCLASS)) return true;
            if (!IsEqualTo(localWorkorder.ROUTE, downloadedWo.ROUTE)) return true;
            if (!IsEqualTo(localWorkorder.ROUTESTOPID, downloadedWo.ROUTESTOPID)) return true;
            if (!IsEqualTo(localWorkorder.SUSPENDFLOW, downloadedWo.SUSPENDFLOW)) return true;
            if (!IsEqualTo(localWorkorder.TARGETDESC, downloadedWo.TARGETDESC)) return true;
            if (!IsEqualTo(localWorkorder.WOISSWAP, downloadedWo.WOISSWAP)) return true;
            if (!IsEqualTo(localWorkorder.FIRSTAPPRSTATUS, downloadedWo.FIRSTAPPRSTATUS)) return true;
            if (!IsEqualTo(localWorkorder.PMCOMTYPE, downloadedWo.PMCOMTYPE)) return true;
            if (!IsEqualTo(localWorkorder.PMCOMSTATE, downloadedWo.PMCOMSTATE)) return true;
            if (!IsEqualTo(localWorkorder.PMCOMBPELACTNAME, downloadedWo.PMCOMBPELACTNAME)) return true;
            if (!IsEqualTo(localWorkorder.PMCOMBPELENABLED, downloadedWo.PMCOMBPELENABLED)) return true;
            if (!IsEqualTo(localWorkorder.PMCOMBPELINPROG, downloadedWo.PMCOMBPELINPROG)) return true;
            if (!IsEqualTo(localWorkorder.CONPERMITNUM, downloadedWo.CONPERMITNUM)) return true;
            if (!IsEqualTo(localWorkorder.OCCPERMITNUM, downloadedWo.OCCPERMITNUM)) return true;
            if (!IsEqualTo(localWorkorder.CALCORGID, downloadedWo.CALCORGID)) return true;
            if (!IsEqualTo(localWorkorder.CALCCALENDAR, downloadedWo.CALCCALENDAR)) return true;
            if (!IsEqualTo(localWorkorder.CALCSHIFT, downloadedWo.CALCSHIFT)) return true;
            if (!IsEqualTo(localWorkorder.RESTORATIONREQD, downloadedWo.RESTORATIONREQD)) return true;
            if (!IsEqualTo(localWorkorder.CONTR_REL_NUM, downloadedWo.CONTR_REL_NUM)) return true;
            if (!IsEqualTo(localWorkorder.DCW_LWBUDGETCHECK, downloadedWo.DCW_LWBUDGETCHECK)) return true;
            if (!IsEqualTo(localWorkorder.DCW_SENDMATL2LW, downloadedWo.DCW_SENDMATL2LW)) return true;
            if (!IsEqualTo(localWorkorder.DCW_SNAKEDIST2BLCKG, downloadedWo.DCW_SNAKEDIST2BLCKG)) return true;
            if (!IsEqualTo(localWorkorder.CONTRACTORJUSTIFICATION, downloadedWo.CONTRACTORJUSTIFICATION)) return true;
            if (!IsEqualTo(localWorkorder.COMPLEXITY, downloadedWo.COMPLEXITY)) return true;
            if (!IsEqualTo(localWorkorder.DCW_UTILITYSTRIKE, downloadedWo.DCW_UTILITYSTRIKE)) return true;
            if (!IsEqualTo(localWorkorder.DCW_REVISEDPRIORITY, downloadedWo.DCW_REVISEDPRIORITY)) return true;
            if (!IsEqualTo(localWorkorder.REPFACSITEID, downloadedWo.REPFACSITEID)) return true;
            if (!IsEqualTo(localWorkorder.REPAIRFACILITY, downloadedWo.REPAIRFACILITY)) return true;
            if (!IsEqualTo(localWorkorder.GENFORPOREVISION, downloadedWo.GENFORPOREVISION)) return true;
            if (!IsEqualTo(localWorkorder.STOREROOMMTLSTATUS, downloadedWo.STOREROOMMTLSTATUS)) return true;
            if (!IsEqualTo(localWorkorder.DIRISSUEMTLSTATUS, downloadedWo.DIRISSUEMTLSTATUS)) return true;
            if (!IsEqualTo(localWorkorder.WORKPACKMTLSTATUS, downloadedWo.WORKPACKMTLSTATUS)) return true;
            if (!IsEqualTo(localWorkorder.IGNORESRMAVAIL, downloadedWo.IGNORESRMAVAIL)) return true;
            if (!IsEqualTo(localWorkorder.IGNOREDIAVAIL, downloadedWo.IGNOREDIAVAIL)) return true;
            if (!IsEqualTo(localWorkorder.ESTINTLABCOST, downloadedWo.ESTINTLABCOST)) return true;
            if (!IsEqualTo(localWorkorder.ESTINTLABHRS, downloadedWo.ESTINTLABHRS)) return true;
            if (!IsEqualTo(localWorkorder.ESTOUTLABHRS, downloadedWo.ESTOUTLABHRS)) return true;
            if (!IsEqualTo(localWorkorder.ESTOUTLABCOST, downloadedWo.ESTOUTLABCOST)) return true;
            if (!IsEqualTo(localWorkorder.ACTINTLABCOST, downloadedWo.ACTINTLABCOST)) return true;
            if (!IsEqualTo(localWorkorder.ACTINTLABHRS, downloadedWo.ACTINTLABHRS)) return true;
            if (!IsEqualTo(localWorkorder.ACTOUTLABHRS, downloadedWo.ACTOUTLABHRS)) return true;
            if (!IsEqualTo(localWorkorder.ACTOUTLABCOST, downloadedWo.ACTOUTLABCOST)) return true;
            if (!IsEqualTo(localWorkorder.ESTATAPPRINTLABCOST, downloadedWo.ESTATAPPRINTLABCOST)) return true;
            if (!IsEqualTo(localWorkorder.ESTATAPPRINTLABHRS, downloadedWo.ESTATAPPRINTLABHRS)) return true;
            if (!IsEqualTo(localWorkorder.ESTATAPPROUTLABHRS, downloadedWo.ESTATAPPROUTLABHRS)) return true;
            if (!IsEqualTo(localWorkorder.ESTATAPPROUTLABCOST, downloadedWo.ESTATAPPROUTLABCOST)) return true;
            if (!IsEqualTo(localWorkorder.ASSIGNEDOWNERGROUP, downloadedWo.ASSIGNEDOWNERGROUP)) return true;
            if (!IsEqualTo(localWorkorder.AVAILSTATUSDATE, downloadedWo.AVAILSTATUSDATE)) return true;
            if (!IsEqualTo(localWorkorder.LASTCOPYLINKDATE, downloadedWo.LASTCOPYLINKDATE)) return true;
            if (!IsEqualTo(localWorkorder.NESTEDJPINPROCESS, downloadedWo.NESTEDJPINPROCESS)) return true;
            if (!IsEqualTo(localWorkorder.PLUSCFREQUENCY, downloadedWo.PLUSCFREQUENCY)) return true;
            if (!IsEqualTo(localWorkorder.PLUSCFREQUNIT, downloadedWo.PLUSCFREQUNIT)) return true;
            if (!IsEqualTo(localWorkorder.PLUSCISMOBILE, downloadedWo.PLUSCISMOBILE)) return true;
            if (!IsEqualTo(localWorkorder.PLUSCJPREVNUM, downloadedWo.PLUSCJPREVNUM)) return true;
            if (!IsEqualTo(localWorkorder.PLUSCLOOP, downloadedWo.PLUSCLOOP)) return true;
            if (!IsEqualTo(localWorkorder.PLUSCNEXTDATE, downloadedWo.PLUSCNEXTDATE)) return true;
            if (!IsEqualTo(localWorkorder.PLUSCOVERDUEDATE, downloadedWo.PLUSCOVERDUEDATE)) return true;
            if (!IsEqualTo(localWorkorder.PLUSCPHYLOC, downloadedWo.PLUSCPHYLOC)) return true;
            if (!IsEqualTo(localWorkorder.INCTASKSINSCHED, downloadedWo.INCTASKSINSCHED)) return true;
            if (!IsEqualTo(localWorkorder.SNECONSTRAINT, downloadedWo.SNECONSTRAINT)) return true;
            if (!IsEqualTo(localWorkorder.FNLCONSTRAINT, downloadedWo.FNLCONSTRAINT)) return true;
            if (!IsEqualTo(localWorkorder.AMCREW, downloadedWo.AMCREW)) return true;
            if (!IsEqualTo(localWorkorder.CREWWORKGROUP, downloadedWo.CREWWORKGROUP)) return true;
            if (!IsEqualTo(localWorkorder.REQASSTDWNTIME, downloadedWo.REQASSTDWNTIME)) return true;
            if (!IsEqualTo(localWorkorder.APPTREQUIRED, downloadedWo.APPTREQUIRED)) return true;
            if (!IsEqualTo(localWorkorder.AOS, downloadedWo.AOS)) return true;
            if (!IsEqualTo(localWorkorder.AMS, downloadedWo.AMS)) return true;
            if (!IsEqualTo(localWorkorder.LOS, downloadedWo.LOS)) return true;
            if (!IsEqualTo(localWorkorder.LMS, downloadedWo.LMS)) return true;
            if (!IsEqualTo(localWorkorder.PLUSSFEATURECLASS, downloadedWo.PLUSSFEATURECLASS)) return true;
            if (!IsEqualTo(localWorkorder.PLUSSISGIS, downloadedWo.PLUSSISGIS)) return true;
            if (!IsEqualTo(localWorkorder.DCW_CBASSIGNED, downloadedWo.DCW_CBASSIGNED)) return true;
            //if (!IsEqualTo(localWorkorder.ROWSTAMP, downloadedWO.ROWSTAMP)) return true;

            if (Comparer.NeedsUpdate(localWorkorder.WorkorderSpecs, downloadedWorkorder.WORKORDERSPEC))
                return true;
            if (Comparer.NeedsUpdate(localWorkorder.WoStatuses, downloadedWorkorder.WOSTATUS))
                return true;
            if (Comparer.NeedsUpdate(localWorkorder.FailureRemark, downloadedWorkorder.FAILUREREMARK))
                return true;
            if (Comparer.NeedsUpdate(localWorkorder.FailureReports, downloadedWorkorder.FAILUREREPORT))
                return true;
            if (Comparer.NeedsUpdate(localWorkorder.Doclinks, downloadedWorkorder.DOCLINKS, downloadedWorkorder.DOCINFO))
                return true;
            if (Comparer.NeedsUpdate(localWorkorder.LabTrans, downloadedWorkorder.LABTRANS))
                return true;
            if (Comparer.NeedsUpdate(localWorkorder.ToolTrans, downloadedWorkorder.TOOLTRANS))
                return true;
/*
            if (Comparer.NeedsUpdate(localWorkorder.Asset, downloadedWorkorder.compositeAsset))
                return true;

            if (Comparer.NeedsUpdate(localWorkorder.LOCATION, downloadedWorkorder.LOCATIONS))
                return true;
*/
            return false;
        }


        public static bool NeedsUpdate(ICollection<WOSTATUS> localWoStatuses, WOSTATUSMboSetWOSTATUS[] downloadedWoStatuses)
        {
            if ((localWoStatuses == null) && ((downloadedWoStatuses == null) || (downloadedWoStatuses.Length == 0)))
                return false;

            if (localWoStatuses == null)
                return true;

            if (localWoStatuses.Count() != downloadedWoStatuses.Length)
              return true;
            foreach (var downloadedWoStatus in downloadedWoStatuses)
            {
                var localWoStatus = (from s in localWoStatuses
                    where s.WOSTATUSID == downloadedWoStatus.WOSTATUSID
                    select s).FirstOrDefault();
                if (localWoStatus == null)
                    return true;
                else
                {
                    if (localWoStatus.C_record_state_ != (long)LocalState.Original)
                        return true;
//                    if (!IsEqualTo(localWoStatus.WONUM, downloadedWoStatus.WONUM)) return true;
//                    if (!IsEqualTo(localWoStatus.WOSTATUSID, downloadedWoStatus.WOSTATUSID)) return true;
                    if (!IsEqualTo(localWoStatus.STATUS, downloadedWoStatus.STATUS)) return true;
                    if (!IsEqualTo(localWoStatus.CHANGEDATE, downloadedWoStatus.CHANGEDATE)) return true;
                    if (!IsEqualTo(localWoStatus.CHANGEBY, downloadedWoStatus.CHANGEBY)) return true;
                    if (!IsEqualTo(localWoStatus.MEMO, downloadedWoStatus.MEMO)) return true;
                    if (!IsEqualTo(localWoStatus.GLACCOUNT, downloadedWoStatus.GLACCOUNT)) return true;
                    if (!IsEqualTo(localWoStatus.FINCNTRLID, downloadedWoStatus.FINCNTRLID)) return true;
                    if (!IsEqualTo(localWoStatus.ORGID, downloadedWoStatus.ORGID)) return true;
                    if (!IsEqualTo(localWoStatus.SITEID, downloadedWoStatus.SITEID)) return true;
                    if (!IsEqualTo(localWoStatus.PARENT, downloadedWoStatus.PARENT)) return true;
                }
            }

            return false;
        }

        public static bool NeedsUpdate(ICollection<WORKORDERSPEC> localWorkorderSpecs, WORKORDERSPECMboSetWORKORDERSPEC[] downloadedWorkorderSpecs)
        {
            if (((localWorkorderSpecs == null)||(localWorkorderSpecs.Count==0)) && ((downloadedWorkorderSpecs == null) || (downloadedWorkorderSpecs.Length == 0)))
                return false;

            if (((localWorkorderSpecs == null) || (localWorkorderSpecs.Count==0)))
                return true;

            if (localWorkorderSpecs.Count() != downloadedWorkorderSpecs.Length)
                return true;
            foreach (var downloadedWoSpec in downloadedWorkorderSpecs)
            {
                var localWoSpec = (from s in localWorkorderSpecs
                                     where s.WORKORDERSPECID == downloadedWoSpec.WORKORDERSPECID
                                     select s).FirstOrDefault();
                if (localWoSpec == null)
                    return true;
                else
                {
                    if (localWoSpec.C_record_state_ != (long)LocalState.Original)
                        return true;

                    //                    if (!IsEqualTo(localWoSpec.WONUM, downloadedWoSpec.WONUM)) return true;
                    //                    if (!IsEqualTo(localWoSpec.WORKORDERSPECID, downloadedWoSpec.WORKORDERSPECID)) return true;
                    if (!IsEqualTo(localWoSpec.ASSETATTRID, downloadedWoSpec.ASSETATTRID)) return true;
                    if (!IsEqualTo(localWoSpec.ALNVALUE, downloadedWoSpec.ALNVALUE)) return true;
                    if (!IsEqualTo(localWoSpec.CHANGEBY, downloadedWoSpec.CHANGEBY)) return true;
                    if (!IsEqualTo(localWoSpec.CHANGEDATE, downloadedWoSpec.CHANGEDATE)) return true;
                    if (!IsEqualTo(localWoSpec.CLASSSPECID, downloadedWoSpec.CLASSSPECID)) return true;
                    if (!IsEqualTo(localWoSpec.CLASSSTRUCTUREID, downloadedWoSpec.CLASSSTRUCTUREID)) return true;
                    if (!IsEqualTo(localWoSpec.ORGID, downloadedWoSpec.ORGID)) return true;
                    if (!IsEqualTo(localWoSpec.SITEID, downloadedWoSpec.SITEID)) return true;
                    if (!IsEqualTo(localWoSpec.DISPLAYSEQUENCE, downloadedWoSpec.DISPLAYSEQUENCE)) return true;
                    if (!IsEqualTo(localWoSpec.LINKEDTOATTRIBUTE, downloadedWoSpec.LINKEDTOATTRIBUTE)) return true;
                    if (!IsEqualTo(localWoSpec.LINKEDTOSECTION, downloadedWoSpec.LINKEDTOSECTION)) return true;
                    if (!IsEqualTo(localWoSpec.MANDATORY, downloadedWoSpec.MANDATORY)) return true;
                    if (!IsEqualTo(localWoSpec.MEASUREUNITID, downloadedWoSpec.MEASUREUNITID)) return true;
                    if (!IsEqualTo(localWoSpec.NUMVALUE, downloadedWoSpec.NUMVALUE)) return true;
                    if (!IsEqualTo(localWoSpec.REFOBJECTID, downloadedWoSpec.REFOBJECTID)) return true;
                    if (!IsEqualTo(localWoSpec.REFOBJECTNAME, downloadedWoSpec.REFOBJECTNAME)) return true;
                    if (!IsEqualTo(localWoSpec.SECTION, downloadedWoSpec.SECTION)) return true;
                    if (!IsEqualTo(localWoSpec.TABLEVALUE, downloadedWoSpec.TABLEVALUE)) return true;
                }
            }

            return false;
        }


        public static bool NeedsUpdate(ICollection<LABTRAN> localLabTrans, LABTRANSMboSetLABTRANS[] downloadedLabTrans)
        {
            if (((localLabTrans == null) || (localLabTrans.Count == 0)) && ((downloadedLabTrans == null) || (downloadedLabTrans.Length == 0)))
                return false;

            if (((localLabTrans == null) || (localLabTrans.Count == 0)))
                return true;

            if (localLabTrans.Count() != downloadedLabTrans.Length)
                return true;
            foreach (var downloadedLabTran in downloadedLabTrans)
            {
                var localLabTran = (from l in localLabTrans
                                    where l.LABTRANSID == downloadedLabTran.LABTRANSID
                                   select l).FirstOrDefault();
                if (localLabTran == null)
                    return true;
                else
                {
                    if (localLabTran.C_record_state_ != (long)LocalState.Original)
                        return true;
//                    if (!IsEqualTo(localLabTran.ROWSTAMP, downloadedLabTran.ROWSTAMP)) return true;
//                    if (!IsEqualTo(localLabTran.REFWO, downloadedLabTran.REFWO)) return true;
//                    if (!IsEqualTo(localLabTran.LABTRANSID, downloadedLabTran.LABTRANSID)) return true;
                    if (!IsEqualTo(localLabTran.TRANSDATE, downloadedLabTran.TRANSDATE)) return true;
                    if (!IsEqualTo(localLabTran.LABORCODE, downloadedLabTran.LABORCODE)) return true;
                    if (!IsEqualTo(localLabTran.CRAFT, downloadedLabTran.CRAFT)) return true;
                    if (!IsEqualTo(localLabTran.PAYRATE, downloadedLabTran.PAYRATE)) return true;
                    if (!IsEqualTo(localLabTran.REGULARHRS, downloadedLabTran.REGULARHRS)) return true;
                    if (!IsEqualTo(localLabTran.ENTERBY, downloadedLabTran.ENTERBY)) return true;
                    if (!IsEqualTo(localLabTran.ENTERDATE, downloadedLabTran.ENTERDATE)) return true;
                    if (!IsEqualTo(localLabTran.LTWO1, downloadedLabTran.LTWO1)) return true;
                    if (!IsEqualTo(localLabTran.LT7, downloadedLabTran.LT7)) return true;
                    if (!IsEqualTo(localLabTran.STARTDATE, downloadedLabTran.STARTDATE)) return true;
                    if (!IsEqualTo(localLabTran.STARTTIME, downloadedLabTran.STARTTIME)) return true;
                    if (!IsEqualTo(localLabTran.FINISHDATE, downloadedLabTran.FINISHDATE)) return true;
                    if (!IsEqualTo(localLabTran.FINISHTIME, downloadedLabTran.FINISHTIME)) return true;
                    if (!IsEqualTo(localLabTran.TRANSTYPE, downloadedLabTran.TRANSTYPE)) return true;
                    if (!IsEqualTo(localLabTran.OUTSIDE, downloadedLabTran.OUTSIDE)) return true;
                    if (!IsEqualTo(localLabTran.MEMO, downloadedLabTran.MEMO)) return true;
                    if (!IsEqualTo(localLabTran.ROLLUP, downloadedLabTran.ROLLUP)) return true;
                    if (!IsEqualTo(localLabTran.GLDEBITACCT, downloadedLabTran.GLDEBITACCT)) return true;
                    if (!IsEqualTo(localLabTran.LINECOST, downloadedLabTran.LINECOST)) return true;
                    if (!IsEqualTo(localLabTran.GLCREDITACCT, downloadedLabTran.GLCREDITACCT)) return true;
                    if (!IsEqualTo(localLabTran.FINANCIALPERIOD, downloadedLabTran.FINANCIALPERIOD)) return true;
                    if (!IsEqualTo(localLabTran.PONUM, downloadedLabTran.PONUM)) return true;
                    if (!IsEqualTo(localLabTran.POLINENUM, downloadedLabTran.POLINENUM)) return true;
                    if (!IsEqualTo(localLabTran.LOCATION, downloadedLabTran.LOCATION)) return true;
                    if (!IsEqualTo(localLabTran.GENAPPRSERVRECEIPT, downloadedLabTran.GENAPPRSERVRECEIPT)) return true;
                    if (!IsEqualTo(localLabTran.PAYMENTTRANSDATE, downloadedLabTran.PAYMENTTRANSDATE)) return true;
                    if (!IsEqualTo(localLabTran.EXCHANGERATE2, downloadedLabTran.EXCHANGERATE2)) return true;
                    if (!IsEqualTo(localLabTran.LINECOST2, downloadedLabTran.LINECOST2)) return true;
                    if (!IsEqualTo(localLabTran.SERVRECTRANSID, downloadedLabTran.SERVRECTRANSID)) return true;
                    if (!IsEqualTo(localLabTran.SOURCESYSID, downloadedLabTran.SOURCESYSID)) return true;
                    if (!IsEqualTo(localLabTran.OWNERSYSID, downloadedLabTran.OWNERSYSID)) return true;
                    if (!IsEqualTo(localLabTran.EXTERNALREFID, downloadedLabTran.EXTERNALREFID)) return true;
                    if (!IsEqualTo(localLabTran.SENDERSYSID, downloadedLabTran.SENDERSYSID)) return true;
                    if (!IsEqualTo(localLabTran.FINCNTRLID, downloadedLabTran.FINCNTRLID)) return true;
                    if (!IsEqualTo(localLabTran.ORGID, downloadedLabTran.ORGID)) return true;
                    if (!IsEqualTo(localLabTran.SITEID, downloadedLabTran.SITEID)) return true;
                    if (!IsEqualTo(localLabTran.ENTEREDASTASK, downloadedLabTran.ENTEREDASTASK)) return true;
                    if (!IsEqualTo(localLabTran.ASSETNUM, downloadedLabTran.ASSETNUM)) return true;
                    if (!IsEqualTo(localLabTran.CONTRACTNUM, downloadedLabTran.CONTRACTNUM)) return true;
                    if (!IsEqualTo(localLabTran.INVOICELINENUM, downloadedLabTran.INVOICELINENUM)) return true;
                    if (!IsEqualTo(localLabTran.INVOICENUM, downloadedLabTran.INVOICENUM)) return true;
                    if (!IsEqualTo(localLabTran.PREMIUMPAYCODE, downloadedLabTran.PREMIUMPAYCODE)) return true;
                    if (!IsEqualTo(localLabTran.PREMIUMPAYHOURS, downloadedLabTran.PREMIUMPAYHOURS)) return true;
                    if (!IsEqualTo(localLabTran.PREMIUMPAYRATE, downloadedLabTran.PREMIUMPAYRATE)) return true;
                    if (!IsEqualTo(localLabTran.PREMIUMPAYRATETYPE, downloadedLabTran.PREMIUMPAYRATETYPE)) return true;
                    if (!IsEqualTo(localLabTran.REVISIONNUM, downloadedLabTran.REVISIONNUM)) return true;
                    if (!IsEqualTo(localLabTran.SKILLLEVEL, downloadedLabTran.SKILLLEVEL)) return true;
                    if (!IsEqualTo(localLabTran.TICKETCLASS, downloadedLabTran.TICKETCLASS)) return true;
                    if (!IsEqualTo(localLabTran.TICKETID, downloadedLabTran.TICKETID)) return true;
                    if (!IsEqualTo(localLabTran.TIMERSTATUS, downloadedLabTran.TIMERSTATUS)) return true;
                    if (!IsEqualTo(localLabTran.VENDOR, downloadedLabTran.VENDOR)) return true;
                    if (!IsEqualTo(localLabTran.POREVISIONNUM, downloadedLabTran.POREVISIONNUM)) return true;
                    if (!IsEqualTo(localLabTran.CREWWORKGROUP, downloadedLabTran.CREWWORKGROUP)) return true;
                    if (!IsEqualTo(localLabTran.AMCREW, downloadedLabTran.AMCREW)) return true;
                    if (!IsEqualTo(localLabTran.AMCREWTYPE, downloadedLabTran.AMCREWTYPE)) return true;
                    if (!IsEqualTo(localLabTran.POSITION, downloadedLabTran.POSITION)) return true;
                    if (!IsEqualTo(localLabTran.DCW_TRUCKLEAD, downloadedLabTran.DCW_TRUCKLEAD)) return true;
                    if (!IsEqualTo(localLabTran.DCW_TRUCKSECOND, downloadedLabTran.DCW_TRUCKSECOND)) return true;
                    if (!IsEqualTo(localLabTran.DCW_TRUCKDRIVER, downloadedLabTran.DCW_TRUCKDRIVER)) return true;
                    if (!IsEqualTo(localLabTran.DCW_TRUCKNUM, downloadedLabTran.DCW_TRUCKNUM)) return true;
                }
            }

            return false;
        }

        public static bool NeedsUpdate(ICollection<TOOLTRAN> localToolTrans, TOOLTRANSMboSetTOOLTRANS[] downloadedToolTrans)
        {
            if (((localToolTrans == null) || (localToolTrans.Count == 0)) && ((downloadedToolTrans == null) || (downloadedToolTrans.Length == 0)))
                return false;

            if (((localToolTrans == null) || (localToolTrans.Count == 0)))
                return true;

            if (localToolTrans.Count() != downloadedToolTrans.Length)
                return true;
            foreach (var downloadedToolTran in downloadedToolTrans)
            {
                var localToolTran = (from l in localToolTrans
                                    where l.TOOLTRANSID == downloadedToolTran.TOOLTRANSID
                                    select l).FirstOrDefault();
                if (localToolTran == null)
                    return true;
                else
                {
                    if (localToolTran.C_record_state_ != (long)LocalState.Original)
                        return true;
//                    if (!IsEqualTo(localToolTran.TOOLTRANSID, downloadedToolTran.TOOLTRANSID)) return true;
//                    if (!IsEqualTo(localToolTran.ROWSTAMP, downloadedToolTran.ROWSTAMP)) return true;
//                    if (!IsEqualTo(localToolTran.REFWO, downloadedToolTran.REFWO)) return true;
                    if (!IsEqualTo(localToolTran.TRANSDATE, downloadedToolTran.TRANSDATE)) return true;
                    if (!IsEqualTo(localToolTran.TOOLRATE, downloadedToolTran.TOOLRATE)) return true;
                    if (!IsEqualTo(localToolTran.TOOLQTY, downloadedToolTran.TOOLQTY)) return true;
                    if (!IsEqualTo(localToolTran.TOOLHRS, downloadedToolTran.TOOLHRS)) return true;
                    if (!IsEqualTo(localToolTran.ENTERDATE, downloadedToolTran.ENTERDATE)) return true;
                    if (!IsEqualTo(localToolTran.ENTERBY, downloadedToolTran.ENTERBY)) return true;
                    if (!IsEqualTo(localToolTran.OUTSIDE, downloadedToolTran.OUTSIDE)) return true;
                    if (!IsEqualTo(localToolTran.ROLLUP, downloadedToolTran.ROLLUP)) return true;
                    if (!IsEqualTo(localToolTran.GLDEBITACCT, downloadedToolTran.GLDEBITACCT)) return true;
                    if (!IsEqualTo(localToolTran.LINECOST, downloadedToolTran.LINECOST)) return true;
                    if (!IsEqualTo(localToolTran.GLCREDITACCT, downloadedToolTran.GLCREDITACCT)) return true;
                    if (!IsEqualTo(localToolTran.FINANCIALPERIOD, downloadedToolTran.FINANCIALPERIOD)) return true;
                    if (!IsEqualTo(localToolTran.LOCATION, downloadedToolTran.LOCATION)) return true;
                    if (!IsEqualTo(localToolTran.EXCHANGERATE2, downloadedToolTran.EXCHANGERATE2)) return true;
                    if (!IsEqualTo(localToolTran.LINECOST2, downloadedToolTran.LINECOST2)) return true;
                    if (!IsEqualTo(localToolTran.SOURCESYSID, downloadedToolTran.SOURCESYSID)) return true;
                    if (!IsEqualTo(localToolTran.OWNERSYSID, downloadedToolTran.OWNERSYSID)) return true;
                    if (!IsEqualTo(localToolTran.EXTERNALREFID, downloadedToolTran.EXTERNALREFID)) return true;
                    if (!IsEqualTo(localToolTran.SENDERSYSID, downloadedToolTran.SENDERSYSID)) return true;
                    if (!IsEqualTo(localToolTran.FINCNTRLID, downloadedToolTran.FINCNTRLID)) return true;
                    if (!IsEqualTo(localToolTran.ORGID, downloadedToolTran.ORGID)) return true;
                    if (!IsEqualTo(localToolTran.SITEID, downloadedToolTran.SITEID)) return true;
                    if (!IsEqualTo(localToolTran.ENTEREDASTASK, downloadedToolTran.ENTEREDASTASK)) return true;
                    if (!IsEqualTo(localToolTran.ASSETNUM, downloadedToolTran.ASSETNUM)) return true;
                    if (!IsEqualTo(localToolTran.ITEMNUM, downloadedToolTran.ITEMNUM)) return true;
                    if (!IsEqualTo(localToolTran.ITEMSETID, downloadedToolTran.ITEMSETID)) return true;
                    if (!IsEqualTo(localToolTran.ROTASSETNUM, downloadedToolTran.ROTASSETNUM)) return true;
                    if (!IsEqualTo(localToolTran.ROTASSETSITE, downloadedToolTran.ROTASSETSITE)) return true;
                    if (!IsEqualTo(localToolTran.PLUSCCOMMENT, downloadedToolTran.PLUSCCOMMENT)) return true;
                    if (!IsEqualTo(localToolTran.PLUSCDUEDATE, downloadedToolTran.PLUSCDUEDATE)) return true;
                    if (!IsEqualTo(localToolTran.PLUSCEXPIRYDATE, downloadedToolTran.PLUSCEXPIRYDATE)) return true;
                    if (!IsEqualTo(localToolTran.PLUSCLOTNUM, downloadedToolTran.PLUSCLOTNUM)) return true;
                    if (!IsEqualTo(localToolTran.PLUSCMANUFACTURER, downloadedToolTran.PLUSCMANUFACTURER)) return true;
                    if (!IsEqualTo(localToolTran.PLUSCTECHNICIAN, downloadedToolTran.PLUSCTECHNICIAN)) return true;
                    if (!IsEqualTo(localToolTran.PLUSCTOOLUSEDATE, downloadedToolTran.PLUSCTOOLUSEDATE)) return true;
                    if (!IsEqualTo(localToolTran.PLUSCTYPE, downloadedToolTran.PLUSCTYPE)) return true;
                    if (!IsEqualTo(localToolTran.HASLD, downloadedToolTran.HASLD)) return true;
                    if (!IsEqualTo(localToolTran.LANGCODE, downloadedToolTran.LANGCODE)) return true;
                    if (!IsEqualTo(localToolTran.AMCREW, downloadedToolTran.AMCREW)) return true;
                    if (!IsEqualTo(localToolTran.TOOLSQ, downloadedToolTran.TOOLSQ)) return true;

                }
            }

            return false;
        }

        public static bool NeedsUpdate(ICollection<DOCLINK> localDocLinks, DOCLINKSMboSetDOCLINKS[] downloadedDocLinks, DOCINFOMboSetDOCINFO[] downloadedDocInfos)
        {
            if (((localDocLinks == null) || (localDocLinks.Count == 0)) && ((downloadedDocLinks == null) || (downloadedDocLinks.Length == 0)))
                return false;

            if (((localDocLinks == null) || (localDocLinks.Count == 0)))
                return true;

            if (localDocLinks.Count() != downloadedDocLinks.Length)
                return true;
            foreach (var downloadedDocLink in downloadedDocLinks)
            {

                var downloadedDocInfo = (from d in downloadedDocInfos
                                         where d.DOCINFOID == downloadedDocLink.DOCINFOID
                                         select d).FirstOrDefault();
                if (downloadedDocInfo == null)
                {
                  throw new ApplicationException("Docinfo not found for Doclink"+downloadedDocLink.DOCLINKSID);    
                }

                var localDocLink = (from l in localDocLinks
                                     where l.DOCLINKSID == downloadedDocLink.DOCLINKSID
                                     select l).FirstOrDefault();
                if (localDocLink == null)
                    return true;
                else
                {
                    if (localDocLink.C_record_state_ != (long)LocalState.Original)
                        return true;
//                    if (!IsEqualTo(localDocLink.ROWSTAMP, downloadedDocLink.ROWSTAMP)) return true;
//                    if (!IsEqualTo(localDocLink.DOCLINKSID, downloadedDocLink.DOCLINKSID)) return true;
//                    if (!IsEqualTo(localDocLink.OWNERID, downloadedDocLink.OWNERID)) return true;
//                    if (!IsEqualTo(localDocLink.OWNERTABLE, downloadedDocLink.OWNERTABLE)) return true;
                    if (!IsEqualTo(localDocLink.DOCUMENT, downloadedDocLink.DOCUMENT)) return true;
                    if (!IsEqualTo(localDocLink.REFERENCE, downloadedDocLink.REFERENCE)) return true;
                    if (!IsEqualTo(localDocLink.DOCTYPE, downloadedDocLink.DOCTYPE)) return true;
                    if (!IsEqualTo(localDocLink.DOCVERSION, downloadedDocLink.DOCVERSION)) return true;
                    if (!IsEqualTo(localDocLink.GETLATESTVERSION, downloadedDocLink.GETLATESTVERSION)) return true;
                    if (!IsEqualTo(localDocLink.CREATEBY, downloadedDocLink.CREATEBY)) return true;
                    if (!IsEqualTo(localDocLink.CREATEDATE, downloadedDocLink.CREATEDATE)) return true;
                    if (!IsEqualTo(localDocLink.CHANGEBY, downloadedDocLink.CHANGEBY)) return true;
                    if (!IsEqualTo(localDocLink.CHANGEDATE, downloadedDocLink.CHANGEDATE)) return true;
                    if (!IsEqualTo(localDocLink.PRINTTHRULINK, downloadedDocLink.PRINTTHRULINK)) return true;
                    if (!IsEqualTo(localDocLink.COPYLINKTOWO, downloadedDocLink.COPYLINKTOWO)) return true;
                    if (!IsEqualTo(localDocLink.DOCINFOID, downloadedDocLink.DOCINFOID)) return true;
                    var localDocInfo = localDocLink.DocInfo;
//                    if (!IsEqualTo(localDocInfo.ROWSTAMP, downloadedDocInfo.ROWSTAMP)) return true;
//                    if (!IsEqualTo(localDocInfo.DOCINFOID, downloadedDocInfo.DOCINFOID)) return true;
                    if (!IsEqualTo(localDocInfo.DOCUMENT, downloadedDocInfo.DOCUMENT)) return true;
                    if (!IsEqualTo(localDocInfo.DESCRIPTION, downloadedDocInfo.DESCRIPTION)) return true;
                    if (!IsEqualTo(localDocInfo.APPLICATION, downloadedDocInfo.APPLICATION)) return true;
                    if (!IsEqualTo(localDocInfo.STATUS, downloadedDocInfo.STATUS)) return true;
                    if (!IsEqualTo(localDocInfo.STATUSDATE, downloadedDocInfo.STATUSDATE)) return true;
                    if (!IsEqualTo(localDocInfo.CREATEDATE, downloadedDocInfo.CREATEDATE)) return true;
                    if (!IsEqualTo(localDocInfo.REVISION, downloadedDocInfo.REVISION)) return true;
                    if (!IsEqualTo(localDocInfo.EXTRA1, downloadedDocInfo.EXTRA1)) return true;
                    if (!IsEqualTo(localDocInfo.CHANGEBY, downloadedDocInfo.CHANGEBY)) return true;
                    if (!IsEqualTo(localDocInfo.CHANGEDATE, downloadedDocInfo.CHANGEDATE)) return true;
                    if (!IsEqualTo(localDocInfo.DOCLOCATION, downloadedDocInfo.DOCLOCATION)) return true;
                    if (!IsEqualTo(localDocInfo.DOCTYPE, downloadedDocInfo.DOCTYPE)) return true;
                    if (!IsEqualTo(localDocInfo.CREATEBY, downloadedDocInfo.CREATEBY)) return true;
                    if (!IsEqualTo(localDocInfo.URLTYPE, downloadedDocInfo.URLTYPE)) return true;
                    if (!IsEqualTo(localDocInfo.DMSNAME, downloadedDocInfo.DMSNAME)) return true;
                    if (!IsEqualTo(localDocInfo.URLNAME, downloadedDocInfo.URLNAME)) return true;
                    if (!IsEqualTo(localDocInfo.URLPARAM1, downloadedDocInfo.URLPARAM1)) return true;
                    if (!IsEqualTo(localDocInfo.URLPARAM2, downloadedDocInfo.URLPARAM2)) return true;
                    if (!IsEqualTo(localDocInfo.URLPARAM3, downloadedDocInfo.URLPARAM3)) return true;
                    if (!IsEqualTo(localDocInfo.URLPARAM4, downloadedDocInfo.URLPARAM4)) return true;
                    if (!IsEqualTo(localDocInfo.URLPARAM5, downloadedDocInfo.URLPARAM5)) return true;
                    if (!IsEqualTo(localDocInfo.PRINTTHRULINKDFLT, downloadedDocInfo.PRINTTHRULINKDFLT)) return true;
                    if (!IsEqualTo(localDocInfo.USEDEFAULTFILEPATH, downloadedDocInfo.USEDEFAULTFILEPATH)) return true;
                    if (!IsEqualTo(localDocInfo.SHOW, downloadedDocInfo.SHOW)) return true;
                    if (!IsEqualTo(localDocInfo.HASLD, downloadedDocInfo.HASLD)) return true;
                    if (!IsEqualTo(localDocInfo.LANGCODE, downloadedDocInfo.LANGCODE)) return true;
                    if (!IsEqualTo(localDocInfo.CONTENTUID, downloadedDocInfo.CONTENTUID)) return true;
                }
            }

            return false;
        }

        public static bool NeedsUpdate(ICollection<FAILUREREPORT> localFailureReports, FAILUREREPORTMboSetFAILUREREPORT[] downloadedFailureReports)
        {
            if (((localFailureReports == null) || (localFailureReports.Count == 0)) && ((downloadedFailureReports == null) || (downloadedFailureReports.Length == 0)))
                return false;

            if (((localFailureReports == null) || (localFailureReports.Count == 0)))
                return true;

            if (localFailureReports.Count() != downloadedFailureReports.Length)
                return true;
            foreach (var downloadedFailureReport in downloadedFailureReports)
            {
                var localFailureReport = (from s in localFailureReports
                                          where s.FAILUREREPORTID == downloadedFailureReport.FAILUREREPORTID
                                          select s).FirstOrDefault();
                if (localFailureReport == null)
                    return true;
                else
                {
                    if (localFailureReport.C_record_state_ != (long)LocalState.Original)
                        return true;
//                    if (!IsEqualTo(localFailureReport.WONUM           , downloadedFailureReport.WONUM                       )) return true;
//                    if (!IsEqualTo(localFailureReport.ROWSTAMP        , downloadedFailureReport.ROWSTAMP                    )) return true;
//                    if (!IsEqualTo(localFailureReport.FAILUREREPORTID , downloadedFailureReport.FAILUREREPORTID             )) return true;
                    if (!IsEqualTo(localFailureReport.FAILURECODE, downloadedFailureReport.FAILURECODE)) return true;
                    if (!IsEqualTo(localFailureReport.LINENUM         , downloadedFailureReport.LINENUM                     )) return true;
                    if (!IsEqualTo(localFailureReport.TYPE            , downloadedFailureReport.TYPE                        )) return true;
                    if (!IsEqualTo(localFailureReport.ORGID           , downloadedFailureReport.ORGID                       )) return true;
                    if (!IsEqualTo(localFailureReport.SITEID          , downloadedFailureReport.SITEID                      )) return true;
                    if (!IsEqualTo(localFailureReport.ASSETNUM, downloadedFailureReport.ASSETNUM)) return true;
                    if (!IsEqualTo(localFailureReport.TICKETCLASS     , downloadedFailureReport.TICKETCLASS                 )) return true;
                    if (!IsEqualTo(localFailureReport.TICKETID        , downloadedFailureReport.TICKETID                    )) return true;
                }
            }

            return false;
        }
        public static bool NeedsUpdate(FAILUREREMARK localFailureRemark, FAILUREREMARKMboSetFAILUREREMARK[] downloadedFailureRemarks)
        {
            if ((localFailureRemark == null) && ((downloadedFailureRemarks == null) || (downloadedFailureRemarks.Length == 0)))
                return false;

            if (localFailureRemark == null)
                return true;
            var downloadedFailureRemark = downloadedFailureRemarks[0];
            if (localFailureRemark.C_record_state_ != (long)LocalState.Original)
               return true;

//            if (!IsEqualTo(localFailureRemark.WONUM           , downloadedFailureRemark.WONUM                       )) return true;
//            if (!IsEqualTo(localFailureRemark.ROWSTAMP        , downloadedFailureRemark.ROWSTAMP                    )) return true;
//            if (!IsEqualTo(localFailureRemark.FAILUREREMARKID , downloadedFailureRemark.FAILUREREMARKID             )) return true;
            if (!IsEqualTo(localFailureRemark.DESCRIPTION     , downloadedFailureRemark.DESCRIPTION                 )) return true;
            if (!IsEqualTo(localFailureRemark.ENTERDATE       , downloadedFailureRemark.ENTERDATE                   )) return true;
            if (!IsEqualTo(localFailureRemark.ORGID           , downloadedFailureRemark.ORGID                       )) return true;
            if (!IsEqualTo(localFailureRemark.SITEID          , downloadedFailureRemark.SITEID                      )) return true;
            if (!IsEqualTo(localFailureRemark.HASLD           , downloadedFailureRemark.HASLD                       )) return true;
            if (!IsEqualTo(localFailureRemark.LANGCODE        , downloadedFailureRemark.LANGCODE                    )) return true;
            if (!IsEqualTo(localFailureRemark.TICKETCLASS     , downloadedFailureRemark.TICKETCLASS                 )) return true;
            if (!IsEqualTo(localFailureRemark.TICKETID        , downloadedFailureRemark.TICKETID                    )) return true;

            return false;
        }

        public static bool NeedsUpdate(string localLocation, LOCATIONSMboSetLOCATIONS[] downloadedLocations)
        {
            if (string.IsNullOrEmpty(localLocation) && ((downloadedLocations == null) || (downloadedLocations.Length == 0) || string.IsNullOrEmpty(downloadedLocations[0].LOCATION)))
                return false;

            return false;

        }
        public static bool NeedsUpdate(LOCATION localLocation, LOCATIONSMboSetLOCATIONS[] downloadedLocations)
        {
            if (((localLocation == null) || string.IsNullOrEmpty(localLocation.LOCATION_)) && 
                ((downloadedLocations == null) || (downloadedLocations.Length == 0) || string.IsNullOrEmpty(downloadedLocations[0].LOCATION)))
                return false;

            if (localLocation == null)
                return true;
            var downloadedLocation = downloadedLocations[0];

            if (!IsEqualTo(localLocation.LOCATION_, downloadedLocation.LOCATION))
                return true;
            if (!IsEqualTo(localLocation.DESCRIPTION, downloadedLocation.DESCRIPTION))
                return true;
            if (!IsEqualTo(localLocation.TYPE, downloadedLocation.TYPE))
                return true;
            if (!IsEqualTo(localLocation.CONTROLACC, downloadedLocation.CONTROLACC))
                return true;
            if (!IsEqualTo(localLocation.GLACCOUNT, downloadedLocation.GLACCOUNT))
                return true;
            if (!IsEqualTo(localLocation.PURCHVARACC, downloadedLocation.PURCHVARACC))
                return true;
            if (!IsEqualTo(localLocation.INVOICEVARACC, downloadedLocation.INVOICEVARACC))
                return true;
            if (!IsEqualTo(localLocation.CURVARACC, downloadedLocation.CURVARACC))
                return true;
            if (!IsEqualTo(localLocation.SHRINKAGEACC, downloadedLocation.SHRINKAGEACC))
                return true;
            if (!IsEqualTo(localLocation.INVCOSTADJACC, downloadedLocation.INVCOSTADJACC))
                return true;
            if (!IsEqualTo(localLocation.RECEIPTVARACC, downloadedLocation.RECEIPTVARACC))
                return true;
            if (!IsEqualTo(localLocation.CHANGEBY, downloadedLocation.CHANGEBY))
                return true;
            if (!IsEqualTo(localLocation.CHANGEDATE, downloadedLocation.CHANGEDATE))
                return true;
            if (!IsEqualTo(localLocation.LO1, downloadedLocation.LO1))
                return true;
            if (!IsEqualTo(localLocation.LO2, downloadedLocation.LO2))
                return true;
            if (!IsEqualTo(localLocation.LO4, downloadedLocation.LO4))
                return true;
            if (!IsEqualTo(localLocation.LO5, downloadedLocation.LO5))
                return true;
            if (!IsEqualTo(localLocation.DISABLED, downloadedLocation.DISABLED))
                return true;
            if (!IsEqualTo(localLocation.OLDCONTROLACC, downloadedLocation.OLDCONTROLACC))
                return true;
            if (!IsEqualTo(localLocation.OLDSHRINKAGEACC, downloadedLocation.OLDSHRINKAGEACC))
                return true;
            if (!IsEqualTo(localLocation.OLDINVCOSTADJACC, downloadedLocation.OLDINVCOSTADJACC))
                return true;
            if (!IsEqualTo(localLocation.CLASSSTRUCTUREID, downloadedLocation.CLASSSTRUCTUREID))
                return true;
            if (!IsEqualTo(localLocation.GISPARAM1, downloadedLocation.GISPARAM1))
                return true;
            if (!IsEqualTo(localLocation.GISPARAM2, downloadedLocation.GISPARAM2))
                return true;
            if (!IsEqualTo(localLocation.GISPARAM3, downloadedLocation.GISPARAM3))
                return true;
            if (!IsEqualTo(localLocation.LO15, downloadedLocation.LO15))
                return true;
            if (!IsEqualTo(localLocation.SOURCESYSID, downloadedLocation.SOURCESYSID))
                return true;
            if (!IsEqualTo(localLocation.OWNERSYSID, downloadedLocation.OWNERSYSID))
                return true;
            if (!IsEqualTo(localLocation.EXTERNALREFID, downloadedLocation.EXTERNALREFID))
                return true;
            if (!IsEqualTo(localLocation.SENDERSYSID, downloadedLocation.SENDERSYSID))
                return true;
            if (!IsEqualTo(localLocation.SITEID, downloadedLocation.SITEID))
                return true;
            if (!IsEqualTo(localLocation.ORGID, downloadedLocation.ORGID))
                return true;
            if (!IsEqualTo(localLocation.INTLABREC, downloadedLocation.INTLABREC))
                return true;
            if (!IsEqualTo(localLocation.ISDEFAULT, downloadedLocation.ISDEFAULT))
                return true;
            if (!IsEqualTo(localLocation.SHIPTOADDRESSCODE, downloadedLocation.SHIPTOADDRESSCODE))
                return true;
            if (!IsEqualTo(localLocation.SHIPTOLABORCODE, downloadedLocation.SHIPTOLABORCODE))
                return true;
            if (!IsEqualTo(localLocation.BILLTOADDRESSCODE, downloadedLocation.BILLTOADDRESSCODE))
                return true;
            if (!IsEqualTo(localLocation.BILLTOLABORCODE, downloadedLocation.BILLTOLABORCODE))
                return true;
            if (!IsEqualTo(localLocation.PREMISESTATUS, downloadedLocation.PREMISESTATUS))
                return true;
            if (!IsEqualTo(localLocation.CUSTOMERNUM, downloadedLocation.CUSTOMERNUM))
                return true;
            if (!IsEqualTo(localLocation.ACCOUNTNUM, downloadedLocation.ACCOUNTNUM))
                return true;
            if (!IsEqualTo(localLocation.QUAD, downloadedLocation.QUAD))
                return true;
            if (!IsEqualTo(localLocation.AUTOWOGEN, downloadedLocation.AUTOWOGEN))
                return true;
            if (!IsEqualTo(localLocation.HASLD, downloadedLocation.HASLD))
                return true;
            if (!IsEqualTo(localLocation.LANGCODE, downloadedLocation.LANGCODE))
                return true;
            if (!IsEqualTo(localLocation.LOCATIONSID, downloadedLocation.LOCATIONSID))
                return true;
            if (!IsEqualTo(localLocation.SERVICEADDRESSCODE, downloadedLocation.SERVICEADDRESSCODE))
                return true;
            if (!IsEqualTo(localLocation.STATUS, downloadedLocation.STATUS))
                return true;
            if (!IsEqualTo(localLocation.TOOLCONTROLACC, downloadedLocation.TOOLCONTROLACC))
                return true;
            if (!IsEqualTo(localLocation.USEINPOPR, downloadedLocation.USEINPOPR))
                return true;
            if (!IsEqualTo(localLocation.STATUSDATE, downloadedLocation.STATUSDATE))
                return true;
            if (!IsEqualTo(localLocation.DCW_MATLMGMTCTRLD, downloadedLocation.DCW_MATLMGMTCTRLD))
                return true;
            if (!IsEqualTo(localLocation.INVOWNER, downloadedLocation.INVOWNER))
                return true;
            if (!IsEqualTo(localLocation.ISREPAIRFACILITY, downloadedLocation.ISREPAIRFACILITY))
                return true;
            if (!IsEqualTo(localLocation.PLUSCDUEDATE, downloadedLocation.PLUSCDUEDATE))
                return true;
            if (!IsEqualTo(localLocation.PLUSCLOOP, downloadedLocation.PLUSCLOOP))
                return true;
            if (!IsEqualTo(localLocation.PLUSCPMEXTDATE, downloadedLocation.PLUSCPMEXTDATE))
                return true;
            if (!IsEqualTo(localLocation.SADDRESSCODE, downloadedLocation.SADDRESSCODE))
                return true;
            if (!IsEqualTo(localLocation.PLUSSFEATURECLASS, downloadedLocation.PLUSSFEATURECLASS))
                return true;
            if (!IsEqualTo(localLocation.PLUSSISGIS, downloadedLocation.PLUSSISGIS))
                return true;
            if (!IsEqualTo(localLocation.PLUSSADDRESSCODE, downloadedLocation.PLUSSADDRESSCODE))
                return true;
            if (!IsEqualTo(localLocation.GEOWORXSYNCID, downloadedLocation.GEOWORXSYNCID))
                return true;


            return false;
        }
        public static bool NeedsUpdate(ASSET localAsset, CompositeAsset downloadedAsset)
        {
            if (localAsset == null && downloadedAsset == null)
                return false;

            if ((localAsset == null) || (downloadedAsset == null))
                return true;

            if (localAsset.C_record_state_ != (long) LocalState.Original)
                return true;

            if (!IsEqualTo(localAsset.ASSETID, downloadedAsset.ASSET.ASSETID))
                return true;
            if (!IsEqualTo(localAsset.ASSETUID, downloadedAsset.ASSET.ASSETUID))
                return true;
            if (!IsEqualTo(localAsset.ASSETNUM, downloadedAsset.ASSET.ASSETNUM))
                return true;
            if (!IsEqualTo(localAsset.ASSETTAG, downloadedAsset.ASSET.ASSETTAG))
                return true;
            if (!IsEqualTo(localAsset.CHANGEDATE, downloadedAsset.ASSET.CHANGEDATE))
                return true;

            if ((localAsset.CLASSSTRUCTUREID != null) || (downloadedAsset.ASSET.CLASSSTRUCTUREID != null))
            {

                if (!IsEqualTo(localAsset.CLASSSTRUCTUREID, downloadedAsset.ASSET.CLASSSTRUCTUREID))
                    return true;

                if ((localAsset.AssetSpecs == null) && (downloadedAsset.ASSETSPEC != null) ||
                    (localAsset.AssetSpecs != null) && (downloadedAsset.ASSETSPEC == null))
                    return true;
                if (localAsset.AssetSpecs == null)
                    return true;
                foreach (var localAssetSpec in localAsset.AssetSpecs)
                {
                    if (localAssetSpec.C_record_state_ != (long) LocalState.Original)
                        return true;
                    var assetAttribId = localAssetSpec.ASSETATTRID;
                    var downloadedAssetSpec = (from d in downloadedAsset.ASSETSPEC
                        where d.ASSETATTRID == assetAttribId
                        select d).FirstOrDefault();
                    if (downloadedAssetSpec == null)
                        return true;

                    if (!localAssetSpec.CHANGEDATE.Equals(downloadedAssetSpec.CHANGEDATE))
                        return true;

                    if (IsDirty(localAssetSpec, downloadedAssetSpec))
                        return true;
                }
            }

            // Check the other attributes
            if (!IsEqualTo(localAsset.ASSETTYPE, downloadedAsset.ASSET.ASSETTYPE))
                return true;
            if (!IsEqualTo(localAsset.ASSETTYPE, downloadedAsset.ASSET.ASSETTYPE))
                return true;
            if (!IsEqualTo(localAsset.AUTOWOGEN, downloadedAsset.ASSET.AUTOWOGEN))
                return true;
            if (!IsEqualTo(localAsset.BINNUM, downloadedAsset.ASSET.BINNUM))
                return true;
            if (!IsEqualTo(localAsset.BUDGETCOST, downloadedAsset.ASSET.BUDGETCOST))
                return true;
            if (!IsEqualTo(localAsset.CALNUM, downloadedAsset.ASSET.CALNUM))
                return true;
            if (!IsEqualTo(localAsset.CHANGEBY, downloadedAsset.ASSET.CHANGEBY))
                return true;
            if (!IsEqualTo(localAsset.CHANGEDATE, downloadedAsset.ASSET.CHANGEDATE))
                return true;
            if (!IsEqualTo(localAsset.CHILDREN, downloadedAsset.ASSET.CHILDREN))
                return true;
            if (!IsEqualTo(localAsset.CONDITIONCODE, downloadedAsset.ASSET.CONDITIONCODE))
                return true;
            if (!IsEqualTo(localAsset.DESCRIPTION, downloadedAsset.ASSET.DESCRIPTION))
                return true;
            if (!IsEqualTo(localAsset.DISABLED, downloadedAsset.ASSET.DISABLED))
                return true;
            if (!IsEqualTo(localAsset.EQ1, downloadedAsset.ASSET.EQ1))
                return true;
            if (!IsEqualTo(localAsset.EQ10, downloadedAsset.ASSET.EQ10))
                return true;
            if (!IsEqualTo(localAsset.EQ11, downloadedAsset.ASSET.EQ11))
                return true;
            if (!IsEqualTo(localAsset.EQ12, downloadedAsset.ASSET.EQ12))
                return true;
            if (!IsEqualTo(localAsset.EQ2, downloadedAsset.ASSET.EQ2))
                return true;
            if (!IsEqualTo(localAsset.EQ23, downloadedAsset.ASSET.EQ23))
                return true;
            if (!IsEqualTo(localAsset.EQ24, downloadedAsset.ASSET.EQ24))
                return true;
            if (!IsEqualTo(localAsset.EQ3, downloadedAsset.ASSET.EQ3))
                return true;
            if (!IsEqualTo(localAsset.EQ4, downloadedAsset.ASSET.EQ4))
                return true;
            if (!IsEqualTo(localAsset.EQ5, downloadedAsset.ASSET.EQ5))
                return true;
            if (!IsEqualTo(localAsset.EQ6, downloadedAsset.ASSET.EQ6))
                return true;
            if (!IsEqualTo(localAsset.EQ7, downloadedAsset.ASSET.EQ7))
                return true;
            if (!IsEqualTo(localAsset.EQ8, downloadedAsset.ASSET.EQ8))
                return true;
            if (!IsEqualTo(localAsset.EQ9, downloadedAsset.ASSET.EQ9))
                return true;
            if (!IsEqualTo(localAsset.EXTERNALREFID, downloadedAsset.ASSET.EXTERNALREFID))
                return true;
            if (!IsEqualTo(localAsset.FAILURECODE, downloadedAsset.ASSET.FAILURECODE))
                return true;
            if (!IsEqualTo(localAsset.GLACCOUNT, downloadedAsset.ASSET.GLACCOUNT))
                return true;
            if (!IsEqualTo(localAsset.GROUPNAME, downloadedAsset.ASSET.GROUPNAME))
                return true;
            if (!IsEqualTo(localAsset.HASLD, downloadedAsset.ASSET.HASLD))
                return true;
            if (!IsEqualTo(localAsset.INSTALLDATE, downloadedAsset.ASSET.INSTALLDATE))
                return true;
            if (!IsEqualTo(localAsset.INVCOST, downloadedAsset.ASSET.INVCOST))
                return true;
            if (!IsEqualTo(localAsset.ISRUNNING, downloadedAsset.ASSET.ISRUNNING))
                return true;
            if (!IsEqualTo(localAsset.ITEMNUM, downloadedAsset.ASSET.ITEMNUM))
                return true;
            if (!IsEqualTo(localAsset.ITEMSETID, downloadedAsset.ASSET.ITEMSETID))
                return true;
            if (!IsEqualTo(localAsset.ITEMTYPE, downloadedAsset.ASSET.ITEMTYPE))
                return true;
            if (!IsEqualTo(localAsset.LANGCODE, downloadedAsset.ASSET.LANGCODE))
                return true;
            if (!IsEqualTo(localAsset.LOCATION, downloadedAsset.ASSET.LOCATION))
                return true;
            if (!IsEqualTo(localAsset.MAINTHIERCHY, downloadedAsset.ASSET.MAINTHIERCHY))
                return true;
            if (!IsEqualTo(localAsset.MANUFACTURER, downloadedAsset.ASSET.MANUFACTURER))
                return true;
            if (!IsEqualTo(localAsset.MOVED, downloadedAsset.ASSET.MOVED))
                return true;
            if (!IsEqualTo(localAsset.ORGID, downloadedAsset.ASSET.ORGID))
                return true;
            if (!IsEqualTo(localAsset.OWNERSYSID, downloadedAsset.ASSET.OWNERSYSID))
                return true;
            if (!IsEqualTo(localAsset.PARENT, downloadedAsset.ASSET.PARENT))
                return true;
            if (!IsEqualTo(localAsset.PRIORITY, downloadedAsset.ASSET.PRIORITY))
                return true;
            if (!IsEqualTo(localAsset.PURCHASEPRICE, downloadedAsset.ASSET.PURCHASEPRICE))
                return true;
            if (!IsEqualTo(localAsset.REPLACECOST, downloadedAsset.ASSET.REPLACECOST))
                return true;
            if (!IsEqualTo(localAsset.ROTSUSPACCT, downloadedAsset.ASSET.ROTSUSPACCT))
                return true;
            if (!IsEqualTo(localAsset.SENDERSYSID, downloadedAsset.ASSET.SENDERSYSID))
                return true;
            if (!IsEqualTo(localAsset.SERIALNUM, downloadedAsset.ASSET.SERIALNUM))
                return true;
            if (!IsEqualTo(localAsset.SHIFTNUM, downloadedAsset.ASSET.SHIFTNUM))
                return true;
            if (!IsEqualTo(localAsset.SITEID, downloadedAsset.ASSET.SITEID))
                return true;
            if (!IsEqualTo(localAsset.SOURCESYSID, downloadedAsset.ASSET.SOURCESYSID))
                return true;
            if (!IsEqualTo(localAsset.STATUS, downloadedAsset.ASSET.STATUS))
                return true;
            if (!IsEqualTo(localAsset.STATUSDATE, downloadedAsset.ASSET.STATUSDATE))
                return true;
            if (!IsEqualTo(localAsset.TOOLCONTROLACCOUNT, downloadedAsset.ASSET.TOOLCONTROLACCOUNT))
                return true;
            if (!IsEqualTo(localAsset.TOOLRATE, downloadedAsset.ASSET.TOOLRATE))
                return true;
            if (!IsEqualTo(localAsset.TOTALCOST, downloadedAsset.ASSET.TOTALCOST))
                return true;
            if (!IsEqualTo(localAsset.TOTDOWNTIME, downloadedAsset.ASSET.TOTDOWNTIME))
                return true;
            if (!IsEqualTo(localAsset.TOTUNCHARGEDCOST, downloadedAsset.ASSET.TOTUNCHARGEDCOST))
                return true;
            if (!IsEqualTo(localAsset.UNCHARGEDCOST, downloadedAsset.ASSET.UNCHARGEDCOST))
                return true;
            if (!IsEqualTo(localAsset.USAGE, downloadedAsset.ASSET.USAGE))
                return true;
            if (!IsEqualTo(localAsset.VENDOR, downloadedAsset.ASSET.VENDOR))
                return true;
            if (!IsEqualTo(localAsset.WARRANTYEXPDATE, downloadedAsset.ASSET.WARRANTYEXPDATE))
                return true;
            if (!IsEqualTo(localAsset.YTDCOST, downloadedAsset.ASSET.YTDCOST))
                return true;
            if (!IsEqualTo(localAsset.EQ13, downloadedAsset.ASSET.EQ13))
                return true;
            if (!IsEqualTo(localAsset.EQ14, downloadedAsset.ASSET.EQ14))
                return true;
            if (!IsEqualTo(localAsset.EQ15, downloadedAsset.ASSET.EQ15))
                return true;
            if (!IsEqualTo(localAsset.EQ16, downloadedAsset.ASSET.EQ16))
                return true;
            if (!IsEqualTo(localAsset.EQ19, downloadedAsset.ASSET.EQ19))
                return true;
            if (!IsEqualTo(localAsset.EQ22, downloadedAsset.ASSET.EQ22))
                return true;
            if (!IsEqualTo(localAsset.MAPNUM, downloadedAsset.ASSET.MAPNUM))
                return true;
            if (!IsEqualTo(localAsset.FIXEDASSET, downloadedAsset.ASSET.FIXEDASSET))
                return true;
            if (!IsEqualTo(localAsset.X1, downloadedAsset.ASSET.X1))
                return true;
            if (!IsEqualTo(localAsset.X2, downloadedAsset.ASSET.X2))
                return true;
            if (!IsEqualTo(localAsset.Y1, downloadedAsset.ASSET.Y1))
                return true;
            if (!IsEqualTo(localAsset.Y2, downloadedAsset.ASSET.Y2))
                return true;
            if (!IsEqualTo(localAsset.GLOBALID, downloadedAsset.ASSET.GLOBALID))
                return true;
            if (!IsEqualTo(localAsset.DIRECTION, downloadedAsset.ASSET.DIRECTION))
                return true;
            if (!IsEqualTo(localAsset.ENDDESCRIPTION, downloadedAsset.ASSET.ENDDESCRIPTION))
                return true;
            if (!IsEqualTo(localAsset.ENDMEASURE, downloadedAsset.ASSET.ENDMEASURE))
                return true;
            if (!IsEqualTo(localAsset.ISLINEAR, downloadedAsset.ASSET.ISLINEAR))
                return true;
            if (!IsEqualTo(localAsset.STARTDESCRIPTION, downloadedAsset.ASSET.STARTDESCRIPTION))
                return true;
            if (!IsEqualTo(localAsset.STARTMEASURE, downloadedAsset.ASSET.STARTMEASURE))
                return true;
            if (!IsEqualTo(localAsset.LRM, downloadedAsset.ASSET.LRM))
                return true;

            if (!IsEqualTo(localAsset.DEFAULTREPFACSITEID, downloadedAsset.ASSET.DEFAULTREPFACSITEID))
                return true;
            if (!IsEqualTo(localAsset.DEFAULTREPFAC, downloadedAsset.ASSET.DEFAULTREPFAC))
                return true;
            if (!IsEqualTo(localAsset.RETURNEDTOVENDOR, downloadedAsset.ASSET.RETURNEDTOVENDOR))
                return true;
            if (!IsEqualTo(localAsset.TLOAMHASH, downloadedAsset.ASSET.TLOAMHASH))
                return true;
            if (!IsEqualTo(localAsset.TLOAMPARTITION, downloadedAsset.ASSET.TLOAMPARTITION))
                return true;
            if (!IsEqualTo(localAsset.PLUSCASSETDEPT, downloadedAsset.ASSET.PLUSCASSETDEPT))
                return true;
            if (!IsEqualTo(localAsset.PLUSCCLASS, downloadedAsset.ASSET.PLUSCCLASS))
                return true;
            if (!IsEqualTo(localAsset.PLUSCDUEDATE, downloadedAsset.ASSET.PLUSCDUEDATE))
                return true;
            if (!IsEqualTo(localAsset.PLUSCISCONDESC, downloadedAsset.ASSET.PLUSCISCONDESC))
                return true;
            if (!IsEqualTo(localAsset.PLUSCISCONTAM, downloadedAsset.ASSET.PLUSCISCONTAM))
                return true;
            if (!IsEqualTo(localAsset.PLUSCISINHOUSECAL, downloadedAsset.ASSET.PLUSCISINHOUSECAL))
                return true;
            if (!IsEqualTo(localAsset.PLUSCISMTE, downloadedAsset.ASSET.PLUSCISMTE))
                return true;
            if (!IsEqualTo(localAsset.PLUSCISMTECLASS, downloadedAsset.ASSET.PLUSCISMTECLASS))
                return true;
            if (!IsEqualTo(localAsset.PLUSCLOOPNUM, downloadedAsset.ASSET.PLUSCLOOPNUM))
                return true;
            if (!IsEqualTo(localAsset.PLUSCMODELNUM, downloadedAsset.ASSET.PLUSCMODELNUM))
                return true;
            if (!IsEqualTo(localAsset.PLUSCOPRGEEU, downloadedAsset.ASSET.PLUSCOPRGEEU))
                return true;
            if (!IsEqualTo(localAsset.PLUSCOPRGEFROM, downloadedAsset.ASSET.PLUSCOPRGEFROM))
                return true;
            if (!IsEqualTo(localAsset.PLUSCOPRGETO, downloadedAsset.ASSET.PLUSCOPRGETO))
                return true;
            if (!IsEqualTo(localAsset.PLUSCPHYLOC, downloadedAsset.ASSET.PLUSCPHYLOC))
                return true;
            if (!IsEqualTo(localAsset.PLUSCSOLUTION, downloadedAsset.ASSET.PLUSCSOLUTION))
                return true;
            if (!IsEqualTo(localAsset.PLUSCSUMDIR, downloadedAsset.ASSET.PLUSCSUMDIR))
                return true;
            if (!IsEqualTo(localAsset.PLUSCSUMEU, downloadedAsset.ASSET.PLUSCSUMEU))
                return true;
            if (!IsEqualTo(localAsset.PLUSCSUMREAD, downloadedAsset.ASSET.PLUSCSUMREAD))
                return true;
            if (!IsEqualTo(localAsset.PLUSCSUMSPAN, downloadedAsset.ASSET.PLUSCSUMSPAN))
                return true;
            if (!IsEqualTo(localAsset.PLUSCSUMURV, downloadedAsset.ASSET.PLUSCSUMURV))
                return true;
            if (!IsEqualTo(localAsset.PLUSCVENDOR, downloadedAsset.ASSET.PLUSCVENDOR))
                return true;
            if (!IsEqualTo(localAsset.ISCALIBRATION, downloadedAsset.ASSET.ISCALIBRATION))
                return true;
            if (!IsEqualTo(localAsset.TEMPLATEID, downloadedAsset.ASSET.TEMPLATEID))
                return true;
            if (!IsEqualTo(localAsset.PLUSCLPLOC, downloadedAsset.ASSET.PLUSCLPLOC))
                return true;
            if (!IsEqualTo(localAsset.SADDRESSCODE, downloadedAsset.ASSET.SADDRESSCODE))
                return true;
            
            if (!IsEqualTo(localAsset.PLUSSFEATURECLASS, downloadedAsset.ASSET.PLUSSFEATURECLASS))
                return true;
            if (!IsEqualTo(localAsset.PLUSSISGIS, downloadedAsset.ASSET.PLUSSISGIS))
                return true;
            if (!IsEqualTo(localAsset.PLUSSADDRESSCODE, downloadedAsset.ASSET.PLUSSADDRESSCODE))
                return true;
            if (!IsEqualTo(localAsset.GEOWORXSYNCID, downloadedAsset.ASSET.GEOWORXSYNCID))
                return true;

            return false;
        }

#region IsEqualTo
        private static bool IsEqualTo(string first, DOCINFOMboSetDOCINFOURLTYPE second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.Value)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.Value);
        }
        

        private static bool IsEqualTo(string first, LABTRANSMboSetLABTRANSPREMIUMPAYRATETYPE second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.Value)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.Value);
        }

        private static bool IsEqualTo(string first, LABTRANSMboSetLABTRANSGLDEBITACCT second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.VALUE)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.VALUE);
        }

        private static bool IsEqualTo(string first, LABTRANSMboSetLABTRANSTRANSTYPE second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.Value)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.Value);
        }
        private static bool IsEqualTo(string first, WORKORDERGLACCOUNT second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.VALUE)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.VALUE);
        }
        private static bool IsEqualTo(string first, WORKORDERSTATUS second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.Value)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.Value);
        }
        private static bool IsEqualTo(string first, WORKORDERWOCLASS second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.Value)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.Value);
        }

        private static bool IsEqualTo(string first, LOCATIONSMboSetLOCATIONSSTATUS second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.Value)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.Value);
        }

        private static bool IsEqualTo(string first, LOCATIONSMboSetLOCATIONSGLACCOUNT second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.VALUE)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.VALUE);
        }

        private static bool IsEqualTo(string first, LOCATIONSMboSetLOCATIONSTYPE second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.Value)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.Value);
        }
        private static bool IsEqualTo(string first, ASSETSTATUS second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || (second.Value == null)) || (string.IsNullOrEmpty(second.Value)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.Value);
        }

        private static bool IsEqualTo(string first, ASSETGLACCOUNT second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null)|| (second.VALUE == null)) || (string.IsNullOrEmpty(second.VALUE)))
              return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.VALUE);
        }
        private static bool IsEqualTo(string first, WOSTATUSGLACCOUNT second)
        {
            if (string.IsNullOrEmpty(first) && ((second == null) || string.IsNullOrEmpty(second.VALUE)))
                return true;

            if (string.IsNullOrEmpty(first))
                return true;

            return first.Equals(second.VALUE);
        }

        private static bool IsEqualTo(DateTime first, DateTime second)
        {
            return first.Equals(second);
        }

        private static bool IsDirty(ASSETSPEC localAssetSpec, ASSETSPECMboSetASSETSPEC downloadedAssetSpec)
        {
            if (!IsEqualTo(localAssetSpec.ASSETSPECID, downloadedAssetSpec.ASSETSPECID))
                return true;
            if (!IsEqualTo(localAssetSpec.CLASSSTRUCTUREID, downloadedAssetSpec.CLASSSTRUCTUREID))
                return true;
            if (!IsEqualTo(localAssetSpec.ASSETNUM, downloadedAssetSpec.ASSETNUM))
                return true;
            if (!IsEqualTo(localAssetSpec.CHANGEBY, downloadedAssetSpec.CHANGEBY))
                return true;
            if (!IsEqualTo(localAssetSpec.ALNVALUE, downloadedAssetSpec.ALNVALUE))
                return true;
            if (!IsEqualTo(localAssetSpec.NUMVALUE,downloadedAssetSpec.NUMVALUE))
                return true;
            if (!IsEqualTo(localAssetSpec.ES01, downloadedAssetSpec.ES01))
                return true;
            if (!IsEqualTo(localAssetSpec.ES02, downloadedAssetSpec.ES02))
                return true;
            if (!IsEqualTo(localAssetSpec.ES03, downloadedAssetSpec.ES03))
                return true;
            if (!IsEqualTo(localAssetSpec.ES04, downloadedAssetSpec.ES04))
                return true;
            if (!IsEqualTo(localAssetSpec.ES05, downloadedAssetSpec.ES05))
                return true;
            if (!IsEqualTo(localAssetSpec.INHERITEDFROMITEM, downloadedAssetSpec.INHERITEDFROMITEM))
                return true;
            if (!IsEqualTo(localAssetSpec.ITEMSPECVALCHANGED, downloadedAssetSpec.ITEMSPECVALCHANGED))
                return true;
            if (!IsEqualTo(localAssetSpec.MEASUREUNITID, downloadedAssetSpec.MEASUREUNITID))
                return true;
            if (!IsEqualTo(localAssetSpec.ORGID, downloadedAssetSpec.ORGID))
                return true;
            if (!IsEqualTo(localAssetSpec.SECTION, downloadedAssetSpec.SECTION))
                return true;
            if (!IsEqualTo(localAssetSpec.SITEID, downloadedAssetSpec.SITEID))
                return true;
            if (!IsEqualTo(localAssetSpec.CONTINUOUS, downloadedAssetSpec.CONTINUOUS))
                return true;
            if (!IsEqualTo(localAssetSpec.ENDMEASURE, downloadedAssetSpec.ENDMEASURE))
                return true;
            if (!IsEqualTo(localAssetSpec.ENDOFFSET, downloadedAssetSpec.ENDOFFSET))
                return true;
            if (!IsEqualTo(localAssetSpec.ENDYOFFSET, downloadedAssetSpec.ENDYOFFSET))
                return true;
            if (!IsEqualTo(localAssetSpec.ENDYOFFSETREF, downloadedAssetSpec.ENDYOFFSETREF))
                return true;
            if (!IsEqualTo(localAssetSpec.ENDZOFFSET, downloadedAssetSpec.ENDZOFFSET))
                return true;
            if (!IsEqualTo(localAssetSpec.ENDZOFFSETREF, downloadedAssetSpec.ENDZOFFSETREF))
                return true;
            if (!IsEqualTo(localAssetSpec.LINKEDTOATTRIBUTE, downloadedAssetSpec.LINKEDTOATTRIBUTE))
                return true;
            if (!IsEqualTo(localAssetSpec.LINKEDTOSECTION, downloadedAssetSpec.LINKEDTOSECTION))
                return true;
            if (!IsEqualTo(localAssetSpec.MANDATORY, downloadedAssetSpec.MANDATORY))
                return true;
            if (!IsEqualTo(localAssetSpec.STARTMEASURE, downloadedAssetSpec.STARTMEASURE))
                return true;
            if (!IsEqualTo(localAssetSpec.STARTOFFSET, downloadedAssetSpec.STARTOFFSET))
                return true;
            if (!IsEqualTo(localAssetSpec.STARTYOFFSET, downloadedAssetSpec.STARTYOFFSET))
                return true;
            if (!IsEqualTo(localAssetSpec.STARTYOFFSETREF, downloadedAssetSpec.STARTYOFFSETREF))
                return true;
            if (!IsEqualTo(localAssetSpec.STARTZOFFSET, downloadedAssetSpec.STARTZOFFSET))
                return true;
            if (!IsEqualTo(localAssetSpec.STARTZOFFSETREF, downloadedAssetSpec.STARTZOFFSETREF))
                return true;
            if (!IsEqualTo(localAssetSpec.TABLEVALUE, downloadedAssetSpec.TABLEVALUE))
                return true;
            if (!IsEqualTo(localAssetSpec.BASEMEASUREUNITID, downloadedAssetSpec.BASEMEASUREUNITID))
                return true;
            if (!IsEqualTo(localAssetSpec.STARTBASEMEASURE, downloadedAssetSpec.STARTBASEMEASURE))
                return true;
            if (!IsEqualTo(localAssetSpec.ENDBASEMEASURE, downloadedAssetSpec.ENDBASEMEASURE))
                return true;
            if (!IsEqualTo(localAssetSpec.STARTMEASUREUNITID, downloadedAssetSpec.STARTMEASUREUNITID))
                return true;
            if (!IsEqualTo(localAssetSpec.ENDMEASUREUNITID, downloadedAssetSpec.ENDMEASUREUNITID))
                return true;
            if (!IsEqualTo(localAssetSpec.STARTASSETFEATUREID, downloadedAssetSpec.STARTASSETFEATUREID))
                return true;
            if (!IsEqualTo(localAssetSpec.ENDASSETFEATUREID, downloadedAssetSpec.ENDASSETFEATUREID))
                return true;
            if (!IsEqualTo(localAssetSpec.STARTOFFSETUNITID, downloadedAssetSpec.STARTOFFSETUNITID))
                return true;
            if (!IsEqualTo(localAssetSpec.ENDOFFSETUNITID, downloadedAssetSpec.ENDOFFSETUNITID))
                return true;
            if (!IsEqualTo(localAssetSpec.LINEARASSETSPECID, downloadedAssetSpec.LINEARASSETSPECID))
                return true;

            return false;
        }

        private static bool IsEqualTo(double first, int second)
        {
            return first.Equals(second);
        }

        private static bool IsEqualTo(string first, string second)
        {
            if (string.IsNullOrEmpty(first) == string.IsNullOrEmpty(second))
                return true;
            if (string.IsNullOrEmpty(first) != string.IsNullOrEmpty(second))
                return false;
            if (string.IsNullOrEmpty(first))
                return false;
            return first.Equals(second);
        }

        private static bool IsEqualTo(double? first, int second)
        {
            return first.HasValue && first.Value.Equals(second);
        }

        private static bool IsEqualTo(double? first, int? second)
        {
            if (first.HasValue != second.HasValue)
                return false;
            if (first.HasValue == false)
                return true;
            return first.Value.Equals(second.Value);
        }
        private static bool IsEqualTo<T>(T? first, T? second) where T : struct, IEquatable<T>
        {
            if (first.HasValue != second.HasValue)
                return false;
            if (first.HasValue == false)
                return true;
            return first.Value.Equals(second);
        }

        public static bool IsEqualTo<T>(T? first, T second)
           where T : struct, IEquatable<T>
        {
            return first.HasValue && first.Value.Equals(second);
        }

        public static bool IsEqualTo<T>(T first, T? second)
           where T : struct, IEquatable<T>
        {
            return second.HasValue && second.Value.Equals(first);
        }

        public static bool IsEqualTo(Double? first, Decimal? second)
        {
            if (first.HasValue != second.HasValue)
                return false;
            if (first.HasValue == false)
                return true;
            return first.Value.Equals(Convert.ToDouble(second));
        }

        public static bool IsEqualTo(long? first, int? second)
        {
            if (first.HasValue != second.HasValue)
                return false;
            if (first.HasValue == false)
                return true;
            return first.Value.Equals(Convert.ToInt64(second.Value));
        }


        public static bool IsEqualTo(long first, byte second)
        {
            return first.Equals(second);
        }

        public static bool IsEqualTo<T> (T first, T second)
        {
            return first.Equals(second);
        }

#endregion
    }
}
