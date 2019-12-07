using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCWaterMobile.LocalData.Models;

namespace DCWaterMobile.LocalData
{
    public interface ILocalDataService
    {
        void UploadNewAsset(Dictionary<string, MobileTypeAttributeMap> assetAttributeMap);
        void UploadAsset(Dictionary<string, MobileTypeAttributeMap> assetAttributeMap);
        void UploadWorkData(Dictionary<string, MobileTypeAttributeMap> workAttributeMap);
        void UploadNewWorkData(Dictionary<string, MobileTypeAttributeMap> workAttributeMap);
        void DownloadReferenceData();
        void CopyReferenceData();
        void DownloadWorkData(string workFilter);
        void ReInitializeWorkData();
        int HasPendingUpdates();

        CREWINFO GetCrewInfo();
        CREWINFO GetCrewInfo(string loginId, string laborFilter);
        bool SetCrewInfo(CREWINFO crewInfo);
        PERSON GetPerson(string personId);
        List<PERSON> GetPersons(string laborCraftRate);
        List<INVENTORY> GetVehicles(string toolLocation, string toolBin);
        List<PERSONGROUP> GetCrews(string whereClause);
        LABORCRAFTRATE GetLaborCraftRate(string laborCode);

        void SaveWorkorder(WORKORDER workorder);
        List<WORKORDER> GetWorkorders();
        List<WORKORDER> GetWorkorders(string filter);
        WORKORDER GetWorkorder(string wonum);
        WORKORDER GetWorkorder(long workorderidLocal);
        ASSET GetAsset(string assetnum, string siteid);
        ASSET GetAsset(long assetidLocal);
        ASSET GetAssetByTag(string assetTag, string siteid);
        LOCATION GetLocation(string location);
        List<ALNDOMAIN> GetAlnDomain(string domainName);
        List<FAILURECODE> GetProblems(string orgid, string failureCode);
        List<FAILURECODE> GetCauses(string orgid, string failureCode, string problem);
        List<FAILURECODE> GetRemedies(string orgid, string failureCode, string problem, string cause);
        long? GetFailureListLineNumber(string orgid, string failureCode, string problem);
        long? GetFailureListLineNumber(string orgid, string failureCode, string problem, string cause);
        long? GetFailureListLineNumber(string orgid, string failureCode, string problem, string cause, string remedy);
        List<CLASSSPEC> GetClassSpecs(string classStructureId);
    }
}
