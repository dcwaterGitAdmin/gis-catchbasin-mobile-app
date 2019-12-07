using System.Collections.Generic;
using DCWaterMobile.MaximoService.MaxRest;

namespace DCWaterMobile.MaximoService
{
    public interface IMaximoService
    {
        bool IsAuthenticated();
        string LoginId { get; }
        string Login(string userName, string password);
        string VerifyAccess();
        string GetLoginPersonId();
        string GetCrewId(string loginPersonId, string laborFilter);
        string GetVehicleId(string crewId);
        string[] GetCrewMembers(string crewId);
        PERSONMboSetPERSON GetPerson(string personId);

        ALNDOMAINMboSet GetAlnDomainMboSet();
        DOCTYPESMboSet GetDoctypesMboSet();
        FAILURECODEMboSet GetFailureCodeMboSet();
        FAILURELISTMboSet GetFailureListMboSet();
        FAILUREREMARKMboSet GetFailureRemarkMboSet(string wonum);
        FAILUREREPORTMboSet GetFailureReportMboSet(string wonum);
        DOCINFOMboSet GetDocInfoMboSet(long docinfoid);
        DOCLINKSMboSet GetDocLinksMboSet(long workorderid);
        LABORCRAFTRATEMboSet GetLaborCraftRateMboSet();
        LABTRANSMboSet GetLabTransMboSet(string refwo);
        MAXDOMAINMboSet GetMaxDomainMboSet();
        PERSONMboSet GetPersonMboSet();
        PERSONGROUPMboSet GetPersonGroupMboSet();
        PERSONGROUPTEAMMboSet GetPersonGroupTeamMboSet();
        SYNONYMDOMAINMboSet GetSynonymDomainMboSet();
        TOOLTRANSMboSet GetToolTransMboSet(string refwo);
        WORKTYPEMboSet GetWorkTypeMboSet();
        WOSTATUSMboSet GetWoStatusMboSet(string wonum);

        CompositeAsset GetCompositeAsset(string assetnum);
        CompositeWorkorderSet GetCompositeWorkorderSet(List<QueryParameter> queryParameters);
        WORKORDERMboSet GetWorkorderMboSet(List<QueryParameter> queryParameters);
        WORKORDERSPECMboSet GetWorkorderSpecMboSet(long workorderid);

        ASSETMboSet GetAssetMboSet(string assetnum);
        ASSETSPECMboSet GetAssetSpecMboSet(string assetnum);
        LOCATIONSMboSet GetLocationMboSet(string location);
        INVENTORYMboSet GetInventoryMboSet(string location);
        string CreateWorkorder(CompositeWorkorder compositeWorkorder, List<string> attributes, List<string> specAttributes,
            List<AssetSpecType> attrTypes);
        CompositeAsset CreateAsset(CompositeAsset compositeAsset, List<string> attributes, List<string> specAttributes, List<AssetSpecType> assetSpecTypes);

        void UpdateAsset(CompositeAsset compositeAsset, List<string> attributes, List<string> specAttributes,
            List<AssetSpecType> attrTypes);

        void UpdateWorkorder(CompositeWorkorder compositeWorkorder, List<string> attributes, List<string> specAttributes,
            List<AssetSpecType> attrTypes, bool problemChanged);
    }
}
