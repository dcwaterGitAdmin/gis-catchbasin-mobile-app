#define INCLUDE_INACTIVE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DCWaterMobile.MaximoService.MaxRest;
using RestSharp;
using RestSharp.Deserializers;
using DCWaterMobile.Utilities;

namespace DCWaterMobile.MaximoService
{

    public class MaximoService : IMaximoService
    {
        ////private string _maximoURL = "http://bpl-maxcb-dev/maxrest/rest";
        private string _maximoURL = "http://bpl-max-test/maxrest/rest";
        RestClient _restClient;
        private MaximoCreds _maxCreds = null;
        private bool _isAuthenticated = false;

        public bool IsAuthenticated()
        {
          return _isAuthenticated;
        }

        public string LoginId
        {
           get
           {
               return (_isAuthenticated) ? _maxCreds.LoginID : null;
           }
        }

        public MaximoService()
        {
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings.Get("maximoRestURL")))
                _maximoURL = System.Configuration.ConfigurationManager.AppSettings.Get("maximoRestURL");
            _restClient = new RestClient(_maximoURL);
            _restClient.AddHandler("application/xml", new DotNetXmlDeserializer());
        }

        public string VerifyAccess()
        {
            if (_maxCreds != null)
            {
                var request = new RestRequest("login");
                try
                {
                    var response = DoGet(request);
                    if (response is string)
                    {
                        if (String.IsNullOrEmpty(response as string))
                        {
                            return "Success";
                        }
                        else
                        {
                            return "No Access";
                        }
                    }
                    return "No Access";

                }
                catch (Exception e)
                {
                    return "No Access";
                }
            }
            return "No Access";
        }
        public string Login(string userName, string password)
        {
            _maxCreds = new MaximoCreds(userName, password);

            var request = new RestRequest("login");
            try 
	        {	        
                var response = DoGet(request);
                if (response is string)
                {
                    if (String.IsNullOrEmpty(response as string))
                    {
                        _isAuthenticated = true;
                        return "Success";
                    }
                    else
                    {
                        _isAuthenticated = false;
                        return response;
                    }
                }
                _isAuthenticated = false;
                return response.ToString();

	        }
	        catch (Exception e)
	        {
                _isAuthenticated = false;
                _maxCreds = null;
                if (e.Message.Contains("Check inner details"))
	                return e.InnerException.Message;
                else
                     return e.Message;
            }
        }

        public string GetLoginPersonId()
        {
            RestRequest request = new RestRequest("mbo/maxuser?_format=xml&loginid=~eq~" + this._maxCreds.LoginID);
            //RestRequest request = new RestRequest("mbo/maxuser?_format=xml&loginid=~eq~" + "LDesjardins");

            MAXUSERMboSet maxUser;

            
            //MAXUSERMboSet maxuserMboSet;
            try
            {
                maxUser = Execute<MAXUSERMboSet>(request);
            }
            catch (Exception e)
            {
                return null;
            }
            var loginPersonId = maxUser.MAXUSER[0].PERSONID;
            Log.Write(LogLevel.Debug, string.Format("LoginPersonId: {0}",loginPersonId));
            return loginPersonId;
        }

        public string GetCrewId(string loginPersonId, string laborFilter)
        {

            var request = new RestRequest("mbo/persongroupteam?_format=xml&resppartygroup=" + loginPersonId+"&persongroup=~neq~"+laborFilter);
            PERSONGROUPTEAMMboSet personGroupTeam;
            try
            {
                personGroupTeam = Execute<PERSONGROUPTEAMMboSet>(request);
            }
            catch (Exception e)
            {
                return null;
            }
            if (personGroupTeam.PERSONGROUPTEAM != null && personGroupTeam.PERSONGROUPTEAM.Any())
            {
                Log.Write(LogLevel.Debug, string.Format("CrewId: {0}", personGroupTeam.PERSONGROUPTEAM[0].PERSONGROUP));

                return personGroupTeam.PERSONGROUPTEAM[0].PERSONGROUP;
            }
            else
            {
                Log.Write(LogLevel.Debug, string.Format("CrewId not found for {0}",loginPersonId));
                return null;
            }
        }

        public string GetVehicleId(string crewId)
        {
            var request = new RestRequest("mbo/persongroup?_format=xml&persongroup=" + crewId);
            PERSONGROUPMboSet personGroup;
            try
            {
                personGroup = Execute<PERSONGROUPMboSet>(request);
            }
            catch (Exception e)
            {
                return null;
            }
            Log.Write(LogLevel.Debug, string.Format("VehicleId: {0}", personGroup.PERSONGROUP[0].VEHICLENUM));

            return personGroup.PERSONGROUP[0].VEHICLENUM;
        }

        public string[] GetCrewMembers(string crewId)
        {
            var request = new RestRequest("mbo/persongroupteam?_format=xml&persongroup=" + crewId);
            PERSONGROUPTEAMMboSet personGroupTeam;
            try
            {
                personGroupTeam = Execute<PERSONGROUPTEAMMboSet>(request);
            }
            catch (Exception e)
            {
                return null;
            }
            var member = personGroupTeam.PERSONGROUPTEAM.FirstOrDefault(x => x.DCW_DESIGNATION == "P" || x.DCW_DESIGNATION == "DP");
            
            if (member == null)
            {
                member = personGroupTeam.PERSONGROUPTEAM.FirstOrDefault(x => x.GROUPDEFAULT == 1);
            }
            if (member == null)
            {
                member = personGroupTeam.PERSONGROUPTEAM.OrderBy(x => x.RESPPARTYGROUPSEQ).FirstOrDefault();
            }
            
            var leadMan = (member == null) ? null : member.RESPPARTY;
            Log.Write(LogLevel.Debug, string.Format("leadMan: {0}", leadMan));

            member = personGroupTeam.PERSONGROUPTEAM.FirstOrDefault(x => x.DCW_DESIGNATION == "S" || x.DCW_DESIGNATION == "DS");

            if (member == null)
            {
                member = personGroupTeam.PERSONGROUPTEAM.FirstOrDefault(x => x.GROUPDEFAULT == 2);
            }

            if (member == null)
            {
                member = personGroupTeam.PERSONGROUPTEAM.OrderBy(x => x.RESPPARTYGROUPSEQ).Skip(1).FirstOrDefault();
            }

            var secondMan = (member == null) ? null : member.RESPPARTY;
            Log.Write(LogLevel.Debug, string.Format("secondMan: {0}", secondMan));

            member = personGroupTeam.PERSONGROUPTEAM.FirstOrDefault(x => x.DCW_DESIGNATION == "D" || x.DCW_DESIGNATION == "DP" || x.DCW_DESIGNATION == "DS");
            
            var driver = (member == null) ? null : member.RESPPARTY;
            Log.Write(LogLevel.Debug, string.Format("driver: {0}", driver));
            if (driver == null)
                driver = leadMan;
            Log.Write(LogLevel.Debug, string.Format("driver: {0}", driver));
            return new string[] { leadMan, secondMan, driver };
        }

        public PERSONMboSetPERSON GetPerson(string personId)
        {
            var request = new RestRequest("mbo/person?_format=xml&personid=" + personId);
            PERSONMboSet person;
            try
            {
                person = Execute<PERSONMboSet>(request);
            }
            catch (Exception e)
            {
                return null;
            }
            Log.Write(LogLevel.Debug, string.Format("Person: {0}", person.PERSON[0].DISPLAYNAME));
            return person.PERSON[0];
        }

        public ALNDOMAINMboSet GetAlnDomainMboSet()
        {
            const int maxItems = 100;
            int rsStart = 0;

            ALNDOMAINMboSet alnDomains = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/alndomain?_format=xml&_maxItems={0}&_rsStart={1}", maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var alnDomainsSegment = Execute<ALNDOMAINMboSet>(request);
                    if (alnDomains == null)
                        alnDomains = alnDomainsSegment;
                    else
                    {
                        if (alnDomainsSegment.ALNDOMAIN != null)
                        {
                            ALNDOMAINMboSetALNDOMAIN[] curSetAlnDomain = alnDomains.ALNDOMAIN;
                            Array.Resize(ref curSetAlnDomain, rsStart + alnDomainsSegment.ALNDOMAIN.Length);
                            Array.Copy(alnDomainsSegment.ALNDOMAIN, 0, curSetAlnDomain, rsStart,
                                alnDomainsSegment.ALNDOMAIN.Length);
                            alnDomains.ALNDOMAIN = curSetAlnDomain;
                        }
                    }
                    done = (alnDomainsSegment.ALNDOMAIN == null) || (alnDomainsSegment.ALNDOMAIN.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return alnDomains;
        }

        public ASSETMboSet GetAssetMboSet(string assetnum)
        {
            const int maxItems = 10;
            int rsStart = 0;

            ASSETMboSet assets = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/asset?_format=xml&assetnum=~eq~{0}&_maxItems={1}&_rsStart={2}", assetnum, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var assetsSegment = Execute<ASSETMboSet>(request);
                    if (assets == null)
                        assets = assetsSegment;
                    else
                    {
                        if(assetsSegment.Assets != null)
                        {
                        ASSETMbo[] curSetAsset = assets.Assets;
                        Array.Resize(ref curSetAsset, rsStart + assetsSegment.Assets.Length);
                        Array.Copy(assetsSegment.Assets, 0, curSetAsset, rsStart, assetsSegment.Assets.Length);
                        assets.Assets = curSetAsset;
                        }
                    }
                    done = (assetsSegment.Assets == null) || ( assetsSegment.Assets.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {
                throw;
            }

            return assets;
        }

        public ASSETSPECMboSet GetAssetSpecMboSet(string assetnum)
        {
            const int maxItems = 10;
            int rsStart = 0;

            ASSETSPECMboSet assetSpecs = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/assetspec?_format=xml&assetnum=~eq~{0}&_maxItems={1}&_rsStart={2}", assetnum, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var assetSpecsSegment = Execute<ASSETSPECMboSet>(request);
                    if (assetSpecs == null)
                        assetSpecs = assetSpecsSegment;
                    else
                    {
                        if(assetSpecsSegment.ASSETSPEC != null)
                        {
                            ASSETSPECMboSetASSETSPEC[] curSetAssetSpecs = assetSpecs.ASSETSPEC;
                            Array.Resize(ref curSetAssetSpecs, rsStart + assetSpecsSegment.ASSETSPEC.Length);
                            Array.Copy(assetSpecsSegment.ASSETSPEC, 0, curSetAssetSpecs, rsStart, assetSpecsSegment.ASSETSPEC.Length);
                            assetSpecs.ASSETSPEC = curSetAssetSpecs;
                        }
                    }
                    done = (assetSpecsSegment.ASSETSPEC == null) || ( assetSpecsSegment.ASSETSPEC.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {

                throw;
            }
            return assetSpecs;
        }

        public CompositeAsset GetCompositeAsset(string assetnum)
        {
            CompositeAsset compositeAsset = new CompositeAsset();
            try
            {
                ASSETMboSet assets = this.GetAssetMboSet(assetnum);
//                compositeAsset.ASSET = assets.ASSET[0];
                compositeAsset.ASSET = assets.Assets[0];

                ASSETSPECMboSet assetSpecs = this.GetAssetSpecMboSet(assetnum);
                compositeAsset.ASSETSPEC = assetSpecs.ASSETSPEC;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return compositeAsset;
        }
        public DOCTYPESMboSet GetDoctypesMboSet()
        {
            const int maxItems = 100;
            int rsStart = 0;

            DOCTYPESMboSet docTypes = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/doctypes?_format=xml&_maxItems={0}&_rsStart={1}", maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var docTypesSegment = Execute<DOCTYPESMboSet>(request);
                    if (docTypes == null)
                        docTypes = docTypesSegment;
                    else
                    {
                        if (docTypesSegment.DOCTYPES != null)
                        {
                            DOCTYPESMboSetDOCTYPES[] curSetDocTypes = docTypes.DOCTYPES;
                            Array.Resize(ref curSetDocTypes, rsStart + docTypesSegment.DOCTYPES.Length);
                            Array.Copy(docTypesSegment.DOCTYPES, 0, curSetDocTypes, rsStart,
                                docTypesSegment.DOCTYPES.Length);
                            docTypes.DOCTYPES = curSetDocTypes;
                        }
                    }
                    done = (docTypesSegment.DOCTYPES == null) || (docTypesSegment.DOCTYPES.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return docTypes;
        }

        public FAILURECODEMboSet GetFailureCodeMboSet()
        {
            const int maxItems = 10;
            int rsStart = 0;

            FAILURECODEMboSet failureCodes = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/failurecode?_format=xml&_maxItems={0}&_rsStart={1}", maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var failureCodesSegment = Execute<FAILURECODEMboSet>(request);
                    if (failureCodes == null)
                        failureCodes = failureCodesSegment;
                    else
                    {
                        if (failureCodesSegment.FAILURECODE != null)
                        {
                            FAILURECODEMboSetFAILURECODE[] curSetFailureCodes = failureCodes.FAILURECODE;
                            Array.Resize(ref curSetFailureCodes, rsStart + failureCodesSegment.FAILURECODE.Length);
                            Array.Copy(failureCodesSegment.FAILURECODE, 0, curSetFailureCodes, rsStart,
                                failureCodesSegment.FAILURECODE.Length);
                            failureCodes.FAILURECODE = curSetFailureCodes;
                        }
                    }
                    done = (failureCodesSegment.FAILURECODE == null) || (failureCodesSegment.FAILURECODE.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return failureCodes;
        }

        public FAILURELISTMboSet GetFailureListMboSet()
        {
            //TODO: reset to a reasonable number
            const int maxItems = 1;
            int rsStart = 0;

            FAILURELISTMboSet failureLists = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/failurelist?_format=xml&_maxItems={0}&_rsStart={1}&_format=xml", maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var failureListsSegment = Execute<FAILURELISTMboSet>(request);
                    if (failureLists == null)
                        failureLists = failureListsSegment;
                    else
                    {
                        if (failureListsSegment.FAILURELIST != null)
                        {
                            FAILURELISTMboSetFAILURELIST[] curSetFailureLists = failureLists.FAILURELIST;
                            Array.Resize(ref curSetFailureLists, rsStart + failureListsSegment.FAILURELIST.Length);
                            Array.Copy(failureListsSegment.FAILURELIST, 0, curSetFailureLists, rsStart,
                                failureListsSegment.FAILURELIST.Length);
                            failureLists.FAILURELIST = curSetFailureLists;
                        }

                    }
                    done = (failureListsSegment.FAILURELIST == null) ||  (failureListsSegment.FAILURELIST.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return failureLists;
        }

        public FAILUREREMARKMboSet GetFailureRemarkMboSet(string wonum)
        {
            const int maxItems = 100;
            int rsStart = 0;

            FAILUREREMARKMboSet failureRemarks = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/failureremark?_format=xml&wonum={0}&_maxItems={1}&_rsStart={2}", wonum, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var failureRemarksSegment = Execute<FAILUREREMARKMboSet>(request);
                    if (failureRemarks == null)
                        failureRemarks = failureRemarksSegment;
                    else
                    {
                        if (failureRemarksSegment.FAILUREREMARK != null)
                        {
                            FAILUREREMARKMboSetFAILUREREMARK[] curSetfailureRemarks = failureRemarks.FAILUREREMARK;
                            Array.Resize(ref curSetfailureRemarks, rsStart + failureRemarksSegment.FAILUREREMARK.Length);
                            Array.Copy(failureRemarksSegment.FAILUREREMARK, 0, curSetfailureRemarks, rsStart,
                                failureRemarksSegment.FAILUREREMARK.Length);
                            failureRemarks.FAILUREREMARK = curSetfailureRemarks;
                        }
                    }
                    done = (failureRemarksSegment.FAILUREREMARK == null)||(failureRemarksSegment.FAILUREREMARK.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return failureRemarks;
        }

        public FAILUREREPORTMboSet GetFailureReportMboSet(string wonum)
        {
            const int maxItems = 50;
            int rsStart = 0;

            FAILUREREPORTMboSet failureReports = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/failurereport?_format=xml&wonum={0}&_maxItems={1}&_rsStart={2}", wonum, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var failureReportsSegment = Execute<FAILUREREPORTMboSet>(request);
                    if (failureReports == null)
                        failureReports = failureReportsSegment;
                    else
                    {
                        if (failureReportsSegment.FAILUREREPORT != null)
                        {
                            FAILUREREPORTMboSetFAILUREREPORT[] curSetfailureReports = failureReports.FAILUREREPORT;
                            Array.Resize(ref curSetfailureReports, rsStart + failureReportsSegment.FAILUREREPORT.Length);
                            Array.Copy(failureReportsSegment.FAILUREREPORT, 0, curSetfailureReports, rsStart,
                                failureReportsSegment.FAILUREREPORT.Length);
                            failureReports.FAILUREREPORT = curSetfailureReports;
                        }
                    }
                    done = (failureReportsSegment.FAILUREREPORT == null)||(failureReportsSegment.FAILUREREPORT.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return failureReports;
        }

        public DOCINFOMboSet GetDocInfoMboSet(long docinfoid)
        {
            //This returns a single record in the mboset
            DOCINFOMboSet docInfos = null;
            try
            {
                var resource = string.Format("mbo/docinfo?_format=xml&docinfoid={0}", docinfoid);
              var request = new RestRequest(resource);
              docInfos = Execute<DOCINFOMboSet>(request);
            }
            catch (Exception e)
            {

                throw;
            }

            return docInfos;
        }

        public DOCLINKSMboSet GetDocLinksMboSet(long workorderid)
        {
            const int maxItems = 50;
            int rsStart = 0;

            DOCLINKSMboSet docLinks = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/doclinks?_format=xml&ownerid=~eq~{0}&ownertable=~eq~WORKORDER&_maxItems={1}&_rsStart={2}", workorderid, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var docLinksSegment = Execute<DOCLINKSMboSet>(request);
                    if (docLinks == null)
                        docLinks = docLinksSegment;
                    else
                    {
                        if (docLinksSegment.DOCLINKS != null)
                        {
                            DOCLINKSMboSetDOCLINKS[] curSetDocLinks = docLinks.DOCLINKS;
                            Array.Resize(ref curSetDocLinks, rsStart + docLinksSegment.DOCLINKS.Length);
                            Array.Copy(docLinksSegment.DOCLINKS, 0, curSetDocLinks, rsStart,
                                docLinksSegment.DOCLINKS.Length);
                            docLinks.DOCLINKS = curSetDocLinks;
                        }
                    }
                    done = (docLinksSegment.DOCLINKS == null) || (docLinksSegment.DOCLINKS.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {

                throw;
            }
            return docLinks;
        }

        public INVENTORYMboSet GetInventoryMboSet(string location)
        {
            const int maxItems = 25;
            int rsStart = 0;

            INVENTORYMboSet inventorySet = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/inventory?_format=xml&location=~eq~{0}&_maxItems={1}&_rsStart={2}", location, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var inventorySetSegment = Execute<INVENTORYMboSet>(request);
                    if (inventorySet == null)
                        inventorySet = inventorySetSegment;
                    else
                    {
                        if (inventorySetSegment.INVENTORY != null)
                        {
                            INVENTORYMboSetINVENTORY[] curSetInventory = inventorySet.INVENTORY;
                            Array.Resize(ref curSetInventory, rsStart + inventorySetSegment.INVENTORY.Length);
                            Array.Copy(inventorySetSegment.INVENTORY, 0, curSetInventory, rsStart,
                                inventorySetSegment.INVENTORY.Length);
                            inventorySet.INVENTORY = curSetInventory;
                        }
                    }
                    done = (inventorySetSegment.INVENTORY == null) || (inventorySetSegment.INVENTORY.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {
                throw;
            }


            return inventorySet;
        }

        public LABORCRAFTRATEMboSet GetLaborCraftRateMboSet()
        {
            int maxItems = 500;
            int rsStart = 0;

            LABORCRAFTRATEMboSet laborCraftRates = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/laborcraftrate?_format=xml&_maxItems={0}&_rsStart={1}&_format=xml", maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var laborCraftRatesSegment = Execute<LABORCRAFTRATEMboSet>(request);
//                    var laborCraftRatesSegment = DoGet<LABORCRAFTRATEMboSet>(request, "LABORCRAFTRATEMboSet");
                    if (laborCraftRates == null)
                        laborCraftRates = laborCraftRatesSegment;
                    else
                    {
                        if (laborCraftRatesSegment.LABORCRAFTRATE != null)
                        {
                            LABORCRAFTRATEMboSetLABORCRAFTRATE[] curSetLaborcraftrates = laborCraftRates.LABORCRAFTRATE;
                            Array.Resize(ref curSetLaborcraftrates,
                                rsStart + laborCraftRatesSegment.LABORCRAFTRATE.Length);
                            Array.Copy(laborCraftRatesSegment.LABORCRAFTRATE, 0, curSetLaborcraftrates, rsStart,
                                laborCraftRatesSegment.LABORCRAFTRATE.Length);
                            laborCraftRates.LABORCRAFTRATE = curSetLaborcraftrates;
                        }
                    }
                    done = (laborCraftRatesSegment.LABORCRAFTRATE == null) || (laborCraftRatesSegment.LABORCRAFTRATE.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {
                throw;
            }

            return laborCraftRates;
        }

        public LABTRANSMboSet GetLabTransMboSet(string refwo)
        {
            int maxItems = 25;
            int rsStart = 0;

            LABTRANSMboSet labTrans = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/labtrans?_format=xml&refwo=~eq~{0}&_maxItems={1}&_rsStart={2}", refwo, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var labTransSegment = Execute<LABTRANSMboSet>(request);
                    if (labTrans == null)
                        labTrans = labTransSegment;
                    else
                    {
                        if (labTransSegment.LABTRANS != null)
                        {
                            LABTRANSMboSetLABTRANS[] curSetLabTrans = labTrans.LABTRANS;
                            Array.Resize(ref curSetLabTrans, rsStart + labTransSegment.LABTRANS.Length);
                            Array.Copy(labTransSegment.LABTRANS, 0, curSetLabTrans, rsStart,
                                labTransSegment.LABTRANS.Length);
                            labTrans.LABTRANS = curSetLabTrans;
                        }
                    }
                    done = (labTransSegment.LABTRANS == null)||(labTransSegment.LABTRANS.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {
                throw;
            }

            return labTrans;
        }

        public LOCATIONSMboSet GetLocationMboSet(string location)
        {
            int maxItems = 25;
            int rsStart = 0;

            LOCATIONSMboSet locations = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/locations?_format=xml&location=~eq~{0}&_maxItems={1}&_rsStart={2}", location, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var locationSegment = Execute<LOCATIONSMboSet>(request);
                    if (locations == null)
                        locations = locationSegment;
                    else
                    {
                        if (locationSegment.LOCATIONS != null)
                        {
                            LOCATIONSMboSetLOCATIONS[] curSetLocations = locations.LOCATIONS;
                            Array.Resize(ref curSetLocations, rsStart + locationSegment.LOCATIONS.Length);
                            Array.Copy(locationSegment.LOCATIONS, 0, curSetLocations, rsStart,
                                locationSegment.LOCATIONS.Length);
                            locations.LOCATIONS = curSetLocations;
                        }
                    }
                    done = (locationSegment.LOCATIONS == null) || (locationSegment.LOCATIONS.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {
                throw;
            }

            return locations;
        }

        public MAXDOMAINMboSet GetMaxDomainMboSet()
        {
            const int maxItems = 50;
            int rsStart = 0;

            MAXDOMAINMboSet maxDomains = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/maxdomain?_format=xml&_maxItems={0}&_rsStart={1}", maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var maxDomainsSegment = Execute<MAXDOMAINMboSet>(request);
                    if (maxDomains == null)
                        maxDomains = maxDomainsSegment;
                    else
                    {
                        if (maxDomainsSegment.MAXDOMAIN != null)
                        {
                            MAXDOMAINMboSetMAXDOMAIN[] curSetMaxDomain = maxDomains.MAXDOMAIN;
                            Array.Resize(ref curSetMaxDomain, rsStart + maxDomainsSegment.MAXDOMAIN.Length);
                            Array.Copy(maxDomainsSegment.MAXDOMAIN, 0, curSetMaxDomain, rsStart,
                                maxDomainsSegment.MAXDOMAIN.Length);
                            maxDomains.MAXDOMAIN = curSetMaxDomain;
                        }
                    }
                    done = (maxDomainsSegment.MAXDOMAIN == null) || (maxDomainsSegment.MAXDOMAIN.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return maxDomains;
        }

        public PERSONMboSet GetPersonMboSet()
        {
            const int maxItems = 100;
            int rsStart = 0;

            PERSONMboSet persons = null;
            try
            {
                bool done = false;
                do
                {
#if INCLUDE_INACTIVE
                    var resource = string.Format("mbo/person?_format=xml&_maxItems={0}&_rsStart={1}", maxItems, rsStart);
#else
                    var resource = string.Format("mbo/person?status=~eq~ACTIVE&_maxItems={0}&_rsStart={1}", maxItems, rsStart);
#endif
                    var request = new RestRequest(resource);
                    var personsSegment = Execute<PERSONMboSet>(request);
                    if (persons == null)
                        persons = personsSegment;
                    else
                    {
                        if (personsSegment.PERSON != null)
                        {
                            PERSONMboSetPERSON[] curSetPersons = persons.PERSON;
                            Array.Resize(ref curSetPersons, rsStart + personsSegment.PERSON.Length);
                            Array.Copy(personsSegment.PERSON, 0, curSetPersons, rsStart, personsSegment.PERSON.Length);
                            persons.PERSON = curSetPersons;
                        }
                    }
                    done = (personsSegment.PERSON == null) || (personsSegment.PERSON.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return persons;
        }

        public PERSONGROUPMboSet GetPersonGroupMboSet()
        {
            const int maxItems = 50;
            int rsStart = 0;

            PERSONGROUPMboSet personGroups = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/persongroup?_format=xml&_maxItems={0}&_rsStart={1}", maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var personGroupsSegment = Execute<PERSONGROUPMboSet>(request);
                    if (personGroups == null)
                        personGroups = personGroupsSegment;
                    else
                    {
                        if (personGroupsSegment.PERSONGROUP != null)
                        {
                            PERSONGROUPMboSetPERSONGROUP[] curSetPersonGroups = personGroups.PERSONGROUP;
                            Array.Resize(ref curSetPersonGroups, rsStart + personGroupsSegment.PERSONGROUP.Length);
                            Array.Copy(personGroupsSegment.PERSONGROUP, 0, curSetPersonGroups, rsStart,
                                personGroupsSegment.PERSONGROUP.Length);
                            personGroups.PERSONGROUP = curSetPersonGroups;
                        }
                    }
                    done = (personGroupsSegment.PERSONGROUP == null) || (personGroupsSegment.PERSONGROUP.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return personGroups;
        }

        public PERSONGROUPTEAMMboSet GetPersonGroupTeamMboSet()
        {
            const int maxItems = 50;
            int rsStart = 0;

            PERSONGROUPTEAMMboSet personGroupTeams = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/persongroupteam?_format=xml&_maxItems={0}&_rsStart={1}", maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var personGroupTeamsSegment = Execute<PERSONGROUPTEAMMboSet>(request);
                    if (personGroupTeams == null)
                        personGroupTeams = personGroupTeamsSegment;
                    else
                    {
                        if (personGroupTeamsSegment.PERSONGROUPTEAM != null)
                        {
                            PERSONGROUPTEAMMboSetPERSONGROUPTEAM[] curSetPersonGroupTeams =
                                personGroupTeams.PERSONGROUPTEAM;
                            Array.Resize(ref curSetPersonGroupTeams,
                                rsStart + personGroupTeamsSegment.PERSONGROUPTEAM.Length);
                            Array.Copy(personGroupTeamsSegment.PERSONGROUPTEAM, 0, curSetPersonGroupTeams, rsStart,
                                personGroupTeamsSegment.PERSONGROUPTEAM.Length);
                            personGroupTeams.PERSONGROUPTEAM = curSetPersonGroupTeams;
                        }

                    }
                    done = (personGroupTeamsSegment.PERSONGROUPTEAM == null) || (personGroupTeamsSegment.PERSONGROUPTEAM.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return personGroupTeams;
        }

        public SYNONYMDOMAINMboSet GetSynonymDomainMboSet()
        {
            const int maxItems = 50;
            int rsStart = 0;

            SYNONYMDOMAINMboSet synonymDomains = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/synonymdomain?_format=xml&_maxItems={0}&_rsStart={1}", maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var synonymDomainsSegment = Execute<SYNONYMDOMAINMboSet>(request);
                    if (synonymDomains == null)
                        synonymDomains = synonymDomainsSegment;
                    else
                    {
                        if (synonymDomainsSegment.SYNONYMDOMAIN != null)
                        {
                            SYNONYMDOMAINMboSetSYNONYMDOMAIN[] curSetSynonymDomain = synonymDomains.SYNONYMDOMAIN;
                            Array.Resize(ref curSetSynonymDomain, rsStart + synonymDomainsSegment.SYNONYMDOMAIN.Length);
                            Array.Copy(synonymDomainsSegment.SYNONYMDOMAIN, 0, curSetSynonymDomain, rsStart,
                                synonymDomainsSegment.SYNONYMDOMAIN.Length);
                            synonymDomains.SYNONYMDOMAIN = curSetSynonymDomain;
                        }
                    }
                    done = (synonymDomainsSegment.SYNONYMDOMAIN != null) || (synonymDomainsSegment.SYNONYMDOMAIN.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return synonymDomains;
        }

        public TOOLTRANSMboSet GetToolTransMboSet(string refwo)
        {
            int maxItems = 25;
            int rsStart = 0;

            TOOLTRANSMboSet toolTrans = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/tooltrans?_format=xml&refwo=~eq~{0}&_maxItems={1}&_rsStart={2}", refwo, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var toolTransSegment = Execute<TOOLTRANSMboSet>(request);
                    if (toolTrans == null)
                        toolTrans = toolTransSegment;
                    else
                    {
                        if (toolTransSegment.TOOLTRANS != null)
                        {
                            TOOLTRANSMboSetTOOLTRANS[] curSetToolTrans = toolTrans.TOOLTRANS;
                            Array.Resize(ref curSetToolTrans, rsStart + toolTransSegment.TOOLTRANS.Length);
                            Array.Copy(toolTransSegment.TOOLTRANS, 0, curSetToolTrans, rsStart,
                                toolTransSegment.TOOLTRANS.Length);
                            toolTrans.TOOLTRANS = curSetToolTrans;
                        }
                    }
                    done = (toolTransSegment.TOOLTRANS == null)||(toolTransSegment.TOOLTRANS.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {
                throw;
            }

            return toolTrans;
        }

        public WORKTYPEMboSet GetWorkTypeMboSet()
        {
            const int maxItems = 100;
            int rsStart = 0;

            WORKTYPEMboSet workTypes = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/worktype?_format=xml&_maxItems={0}&_rsStart={1}", maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var workTypesSegment = Execute<WORKTYPEMboSet>(request);
                    if (workTypes == null)
                        workTypes = workTypesSegment;
                    else
                    {
                        if (workTypesSegment.WORKTYPE != null)
                        {
                            WORKTYPEMboSetWORKTYPE[] curSetWorkTypes = workTypes.WORKTYPE;
                            Array.Resize(ref curSetWorkTypes, rsStart + workTypesSegment.WORKTYPE.Length);
                            Array.Copy(workTypesSegment.WORKTYPE, 0, curSetWorkTypes, rsStart,
                                workTypesSegment.WORKTYPE.Length);
                            workTypes.WORKTYPE = curSetWorkTypes;
                        }
                    }
                    done = (workTypesSegment.WORKTYPE == null) || (workTypesSegment.WORKTYPE.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);
            }
            catch (Exception e)
            {

                throw;
            }
            return workTypes;
        }

        public WOSTATUSMboSet GetWoStatusMboSet(string wonum)
        {
            int maxItems = 25;
            int rsStart = 0;

            WOSTATUSMboSet woStatus = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/wostatus?_format=xml&wonum=~eq~{0}&_maxItems={1}&_rsStart={2}", wonum, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var woStatusSegment = Execute<WOSTATUSMboSet>(request);
                    if (woStatus == null)
                        woStatus = woStatusSegment;
                    else
                    {
                        if (woStatusSegment.WOSTATUS != null)
                        {
                            WOSTATUSMboSetWOSTATUS[] curSetWoStatus = woStatus.WOSTATUS;
                            Array.Resize(ref curSetWoStatus, rsStart + woStatusSegment.WOSTATUS.Length);
                            Array.Copy(woStatusSegment.WOSTATUS, 0, curSetWoStatus, rsStart,
                                woStatusSegment.WOSTATUS.Length);
                            woStatus.WOSTATUS = curSetWoStatus;
                        }
                    }
                    done = (woStatusSegment.WOSTATUS == null) || (woStatusSegment.WOSTATUS.Count() < maxItems);
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {
                throw;
            }

            return woStatus;
        }

        public WORKORDERSPECMboSet GetWorkorderSpecMboSet(long workorderid)
        {
            const int maxItems = 25;
            int rsStart = 0;

            WORKORDERSPECMboSet workorderSpecs = null;
            try
            {
                bool done = false;
                do
                {
                    var resource = string.Format("mbo/workorderspec?_format=xml&refobjectid=~eq~{0}&_maxItems={1}&_rsStart={2}", workorderid, maxItems, rsStart);
                    var request = new RestRequest(resource);
                    var workorderSpecsSegment = Execute<WORKORDERSPECMboSet>(request);
                    if (workorderSpecs == null)
                        workorderSpecs = workorderSpecsSegment;
                    else
                    {
                        if (workorderSpecsSegment.WORKORDERSPEC != null)
                        {
                            WORKORDERSPECMboSetWORKORDERSPEC[] curSetWorkorderSpec = workorderSpecs.WORKORDERSPEC;
                            Array.Resize(ref curSetWorkorderSpec, rsStart + workorderSpecsSegment.WORKORDERSPEC.Length);
                            Array.Copy(workorderSpecsSegment.WORKORDERSPEC, 0, curSetWorkorderSpec, rsStart,
                                workorderSpecsSegment.WORKORDERSPEC.Length);
                            workorderSpecs.WORKORDERSPEC = curSetWorkorderSpec;
                        }
                    }
                    done = (workorderSpecsSegment.WORKORDERSPEC == null) || workorderSpecsSegment.WORKORDERSPEC.Count() < maxItems;
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {
                throw;
            }

            return workorderSpecs;
        }

#region Workorder
        public WORKORDERMboSet GetWorkorderMboSet(List<QueryParameter> queryParameters)
        {
            int maxItems = 10;
            int rsStart = 0;

            WORKORDERMboSet workorders = null;
            try
            {
                bool done = false;
                do
                {
                    const string resource = "mbo/workorder";
                    var request = new RestRequest(resource);
                    foreach (var queryParameter in queryParameters)
                    {
                        request.AddParameter(queryParameter.Name,queryParameter.Value);
                        
                    }
                    request.AddParameter("_urs", "true"); // not implemented
                    request.AddParameter("_maxItems", String.Format("{0}", maxItems));
                    request.AddParameter("_rsStart", String.Format("{0}", rsStart));
                    var workordersSegment = Execute<WORKORDERMboSet>(request);
                    if (workorders == null)
                        workorders = workordersSegment;
                    else
                    {
                        if (workordersSegment.Workorders != null)
                        {                      
                            WORKORDERMbo[] curSetWorkorders = workorders.Workorders;
                            Array.Resize(ref curSetWorkorders, rsStart + workordersSegment.Workorders.Length);
                            Array.Copy(workordersSegment.Workorders, 0, curSetWorkorders, rsStart,
                            workordersSegment.Workorders.Length);
                            workorders.Workorders = curSetWorkorders;
                        }
                }
                    done = (workordersSegment.Workorders == null) || workordersSegment.Workorders.Count() < maxItems;
                    rsStart += maxItems;
                } while (!done);

            }
            catch (Exception e)
            {
                throw;
            }

            return workorders;
        }

        public CompositeWorkorderSet GetCompositeWorkorderSet(List<QueryParameter> queryParameters)
        {
          var compositeWorkorderSet = new CompositeWorkorderSet();
          try
            {
                var timerAll = Stopwatch.StartNew();

                var timerOp = Stopwatch.StartNew();
                WORKORDERMboSet workorders = this.GetWorkorderMboSet(queryParameters);
                timerOp.Stop();
                var nbWO = (workorders.Workorders == null) ? 0 : workorders.Workorders.Length;

                Log.Write(LogLevel.Info, string.Format("Fetched Workorders: {0} Elapsed:{1}", nbWO, timerOp.ElapsedMilliseconds));

                if (nbWO == 0)
                    return compositeWorkorderSet;

               var compositeWorkorderSetData = new List<CompositeWorkorder>();

                foreach (var workorderSrc in workorders.Workorders)
                {
                    Log.Write(LogLevel.Info, string.Format("Starting WONUM:" + workorderSrc.WONUM));
                    timerOp = Stopwatch.StartNew();
                    var compositeWorkorder = new CompositeWorkorder();
                    compositeWorkorder.WORKORDER = workorderSrc;

                    WORKORDERSPECMboSet workorderSpecs = this.GetWorkorderSpecMboSet(workorderSrc.WORKORDERID);
                    compositeWorkorder.WORKORDERSPEC = workorderSpecs.WORKORDERSPEC;


                    if (!String.IsNullOrEmpty(workorderSrc.ASSETNUM))
                    {
                        compositeWorkorder.compositeAsset = GetCompositeAsset(workorderSrc.ASSETNUM);
                    }

                    if (!String.IsNullOrEmpty(workorderSrc.LOCATION))
                    {
                        LOCATIONSMboSet locations = this.GetLocationMboSet(workorderSrc.LOCATION);
                        compositeWorkorder.LOCATIONS = locations.LOCATIONS;
                    }

                    var id = workorderSrc.WORKORDERID;
                    DOCLINKSMboSet docLinks = this.GetDocLinksMboSet(id);
                    compositeWorkorder.DOCLINKS = docLinks.DOCLINKS;
                    if (docLinks.DOCLINKS != null && docLinks.DOCLINKS.Length > 0)
                    {
                        compositeWorkorder.DOCINFO = new DOCINFOMboSetDOCINFO[docLinks.DOCLINKS.Length];
                        for (int i = 0; i < docLinks.DOCLINKS.Length; i++)
                        {
                            var docInfo = this.GetDocInfoMboSet(docLinks.DOCLINKS[i].DOCINFOID);
                            if ((docInfo != null) && (docInfo.DOCINFO.Length == 1))
                                compositeWorkorder.DOCINFO[i] = docInfo.DOCINFO[0];
                        }
                    }
                    WOSTATUSMboSet statuses = this.GetWoStatusMboSet(workorderSrc.WONUM);
                    compositeWorkorder.WOSTATUS = statuses.WOSTATUS;

                    FAILUREREMARKMboSet failureRemarks = this.GetFailureRemarkMboSet(workorderSrc.WONUM);
                    compositeWorkorder.FAILUREREMARK = failureRemarks.FAILUREREMARK;
                    FAILUREREPORTMboSet failureReports = this.GetFailureReportMboSet(workorderSrc.WONUM);
                    compositeWorkorder.FAILUREREPORT = failureReports.FAILUREREPORT;

                    LABTRANSMboSet labTrans = this.GetLabTransMboSet(workorderSrc.WONUM);
                    compositeWorkorder.LABTRANS = labTrans.LABTRANS;
                    TOOLTRANSMboSet toolTrans = this.GetToolTransMboSet(workorderSrc.WONUM);
                    compositeWorkorder.TOOLTRANS = toolTrans.TOOLTRANS;
                    compositeWorkorderSetData.Add(compositeWorkorder);
                    timerOp.Stop();
                    Log.Write(LogLevel.Info, string.Format("End WONUM: {0} Elapsed:{1}", workorderSrc.WONUM, timerOp.ElapsedMilliseconds));
                }

                if (compositeWorkorderSetData.Any())
                    compositeWorkorderSet.CompositeWorkorders = compositeWorkorderSetData.ToArray();

                timerAll.Stop();
                Log.Write(LogLevel.Info, string.Format("Maximo Download Total Time: {0}",timerAll.ElapsedMilliseconds));
            }
            catch (Exception e)
            {
                throw;
            }
            return compositeWorkorderSet;
        }

        public void UpdateWorkorder(CompositeWorkorder compositeWorkorder, List<string> attributes, List<string> specAttributes,
            List<AssetSpecType> attrTypes, bool problemChanged)
        {
            Log.Write(LogLevel.Debug, string.Format("Updating Workorder {0}...",compositeWorkorder.WORKORDER.WONUM));
            var wo = compositeWorkorder.WORKORDER;
            string resource = String.Format("os/dcw_cbwo/{0}?_format=xml", wo.WORKORDERID);
            var request = new RestRequest(resource);
            if (problemChanged)
            {
                Log.Write(LogLevel.Debug, "Clearing Problem Code");
                request.AddParameter("PROBLEMCODE", "");
                try
                {
                    var woResponse = DoPost<SyncDCW_CBWOResponse>(request);
                }
                catch (Exception)
                {
                    
                    throw new  ApplicationException("Failed to clear Problem");
                }
                request = new RestRequest(resource);
            }

            var woType = wo.GetType();
            foreach (var attribute in attributes)
            {
                if (attribute == "STATUS" ||  attribute == "STATUSDATE" || attribute =="PROBLEMCODE")
                    continue;
                var prop = woType.GetProperty(attribute);
                if (prop == null)
                {
                    throw new ApplicationException("Property not found:" + attribute);
                }
                object value;
                value = prop.GetValue(wo, null);
                if (value == null)
                {
                    value = "";
                    if (prop.PropertyType.BaseType == typeof (DateTime))
                        value = "~NULL~";
                    //else if (IsNumericType(prop.PropertyType))
                    //    value = "~NULL~";
                }
                else
                {
                    if (IsNumericType(value.GetType()))
                        value = value.ToString();
                    else if (value is DateTime)
                        value = ((DateTime) value).ToString("yyyy-MM-ddTHH:mm:sszzz");
                }

                request.AddParameter(attribute, value);
            }
            if (compositeWorkorder.WOSTATUS != null && compositeWorkorder.WOSTATUS.Count() > 0)
            {
                var woStatus = compositeWorkorder.WOSTATUS.OrderBy(s => s.CHANGEDATE).FirstOrDefault();
                if (woStatus == null)
                    throw new ApplicationException("unable to get status"); 
                request.AddParameter("STATUSIFACE", "1");
                request.AddParameter("STATUS", woStatus.STATUS);
                request.AddParameter("NP_STATUSMEMO",woStatus.MEMO);
            }
            try
            {
                Log.Write(LogLevel.Debug, "Updating Status ...");
                var woResponse = DoPost<SyncDCW_CBWOResponse>(request);
            }
            catch (Exception)
            {
                throw;
            } 

            request = new RestRequest(resource);
            if (compositeWorkorder.FAILUREREPORT != null)
            {
                request.AddParameter("_keys", "True");
                var problem = compositeWorkorder.FAILUREREPORT.FirstOrDefault(fr => fr.TYPE == "PROBLEM");
                if(problem != null && !string.IsNullOrEmpty(problem.FAILURECODE))
                    request.AddParameter("PROBLEMCODE", problem.FAILURECODE);
                var cause = compositeWorkorder.FAILUREREPORT.FirstOrDefault(fr => fr.TYPE == "CAUSE");
                var remedy = compositeWorkorder.FAILUREREPORT.FirstOrDefault(fr => fr.TYPE == "REMEDY");
                if (cause != null && !string.IsNullOrEmpty(cause.FAILURECODE))
                    request.AddParameter("FR1CODE", cause.FAILURECODE);
                if (remedy != null && !string.IsNullOrEmpty(remedy.FAILURECODE))
                    request.AddParameter("FR2CODE", remedy.FAILURECODE);
            }
            try
            {
                Log.Write(LogLevel.Debug, "Updating FailureReport ...");
                var woResponse = DoPost<SyncDCW_CBWOResponse>(request);
            }
            catch (Exception)
            {
                throw;
            }
            request = new RestRequest(resource); if (compositeWorkorder.FAILUREREMARK != null)
            {
                request.AddParameter("REMARKDESC", compositeWorkorder.FAILUREREMARK[0].DESCRIPTION); //254
                request.AddParameter("REMARKDESC_LONGDESCRIPTION", compositeWorkorder.FAILUREREMARK[0].DESCRIPTION_LONGDESCRIPTION); //clob

                var value = (compositeWorkorder.FAILUREREMARK[0].ENTERDATE.HasValue)
                            ? compositeWorkorder.FAILUREREMARK[0].ENTERDATE.Value.ToString("yyyy-MM-ddTHH:mm:sszzz")
                            : DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");

                request.AddParameter("REMARKENTERDATE", value);
            }
            try
            {
                Log.Write(LogLevel.Debug, "Updating FailureRemark ...");
                var woResponse = DoPost<SyncDCW_CBWOResponse>(request);
            }
            catch (Exception)
            {
                throw;
            }
            if (wo.CLASSSTRUCTUREID != null && specAttributes.Any())
            {
                request = new RestRequest(String.Format("mbo/workorder/{0}?_format=xml&_keys=True", wo.WORKORDERID));
                request.AddParameter("CLASSSTRUCTUREID", wo.CLASSSTRUCTUREID);
                try
                {
                    Log.Write(LogLevel.Debug, "Updating ClassStructureID ...");
                    var woResponse = DoPost(request);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            request = new RestRequest(resource);
            var i = 1;
            foreach (var specAttr in specAttributes)
            {
                var dataType = attrTypes.First(w => w.ASSETATTRID == specAttr).DATATYPE;
                var newWoSpec = compositeWorkorder.WORKORDERSPEC.First(a => a.ASSETATTRID == specAttr);
                request.AddParameter("WORKORDERSPEC." + i + ".ASSETATTRID", specAttr);
                if (dataType == "NUMERIC")
                {

                    if (!newWoSpec.NUMVALUE.HasValue)
                    {
                        request.AddParameter("WORKORDERSPEC." + i + ".NUMVALUE", "");
                    }
                    else
                    {
                        request.AddParameter("WORKORDERSPEC." + i + ".NUMVALUE", newWoSpec.NUMVALUE.ToString());
                    }
                    if (!string.IsNullOrEmpty(newWoSpec.MEASUREUNITID))
                        request.AddParameter("WORKORDERSPEC." + i + ".MEASUREUNITID", newWoSpec.MEASUREUNITID);
                }
                else
                {

                    if (String.IsNullOrEmpty(newWoSpec.ALNVALUE))
                    {
                        request.AddParameter("WORKORDERSPEC." + i + ".ALNVALUE", "");
                    }
                    else
                    {
                        request.AddParameter("WORKORDERSPEC." + i + ".ALNVALUE", newWoSpec.ALNVALUE);
                    }
                }
                if (!String.IsNullOrEmpty(newWoSpec.SECTION))
                    request.AddParameter("WORKORDERSPEC." + i + ".SECTION", newWoSpec.SECTION);
                else
                    request.AddParameter("WORKORDERSPEC." + i + ".SECTION", "");
                i++;
            }

            try
            {
                Log.Write(LogLevel.Debug, "Updating SpecAttributes ...");
                var woResponse = DoPost<SyncDCW_CBWOResponse>(request);
            }
            catch (Exception)
            {
                throw;
            }

            if (compositeWorkorder.WOSTATUS != null && compositeWorkorder.WOSTATUS.Count() > 1)
            {
                var woStatuses = compositeWorkorder.WOSTATUS.OrderBy(s => s.CHANGEDATE).ToArray();
                for (int j = 1; j < woStatuses.Count(); j++)
                {
                    resource = String.Format("os/dcw_cbwo/{0}?_format=xml&_keys=True", wo.WORKORDERID);
                    request = new RestRequest(resource);
                    request.AddParameter("STATUSIFACE", "1");
                    request.AddParameter("STATUS", woStatuses[j].STATUS);
                    request.AddParameter("NP_STATUSMEMO", woStatuses[j].MEMO);
                    try
                     {
                         Log.Write(LogLevel.Debug, "Updating Status ...");
                         var woResponse = DoPost<SyncDCW_CBWOResponse>(request);
                     }
                     catch (Exception)
                     {
                         throw;
                     }
   
                }
            }

            if (compositeWorkorder.LABTRANS != null)
            {
                foreach (var labTrans in compositeWorkorder.LABTRANS)
                {
                    request = new RestRequest("mbo/labtrans");
                    request.AddParameter("_format", "xml");
                    request.AddParameter("LABORCODE", labTrans.LABORCODE);
                    request.AddParameter("CRAFT", labTrans.CRAFT);
                    request.AddParameter("STARTDATE", labTrans.STARTDATE.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                    if(labTrans.STARTTIME.HasValue)
                      request.AddParameter("STARTTIME", labTrans.STARTTIME.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                    if (labTrans.FINISHDATE.HasValue)
                        request.AddParameter("FINISHDATE", labTrans.FINISHDATE.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                    if (labTrans.FINISHTIME.HasValue)
                        request.AddParameter("FINISHTIME", labTrans.FINISHTIME.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                    request.AddParameter("TRANSTYPE", labTrans.TRANSTYPE.Value);
                    request.AddParameter("REFWO", compositeWorkorder.WORKORDER.WONUM);
                    request.AddParameter("SITEID", compositeWorkorder.WORKORDER.SITEID);
                    request.AddParameter("PAYRATE", labTrans.PAYRATE);
                    try
                    {
                        Log.Write(LogLevel.Debug, "Updating LabTrans ...");
                        var labTransResponse = DoPost(request);
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }

                if (compositeWorkorder.TOOLTRANS != null)
                {
                    foreach (var toolTrans in compositeWorkorder.TOOLTRANS)
                    {
                        request = new RestRequest("mbo/tooltrans");
                        request.AddParameter("_format", "xml");
                        request.AddParameter("ITEMNUM", toolTrans.ITEMNUM);
                        request.AddParameter("TOOLQTY", toolTrans.TOOLQTY);
                        request.AddParameter("TOOLHRS", toolTrans.TOOLHRS);
                        request.AddParameter("TRANSDATE", toolTrans.TRANSDATE.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                        request.AddParameter("REFWO", compositeWorkorder.WORKORDER.WONUM);
                        request.AddParameter("SITEID", compositeWorkorder.WORKORDER.SITEID);
                        try
                        {
                            Log.Write(LogLevel.Debug, "Updating ToolTrans ...");
                            var toolTransResponse = DoPost(request);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }

                if (compositeWorkorder.DOCLINKS != null)
                {
                    resource = String.Format("os/dcw_cbwo/{0}?_format=xml", compositeWorkorder.WORKORDER.WORKORDERID);
                    request = new RestRequest(resource);
                    for (int j = 0; j < compositeWorkorder.DOCLINKS.Count(); j++)
                    {
                        request.AddParameter("DOCLINKS." + j + ".DOCTYPE", compositeWorkorder.DOCLINKS[j].DOCTYPE);
                        request.AddParameter("DOCLINKS." + j + ".URLTYPE", compositeWorkorder.DOCLINKS[j].URLTYPE);
                        request.AddParameter("DOCLINKS." + j + ".URLNAME", compositeWorkorder.DOCLINKS[j].URLNAME);
                        request.AddParameter("DOCLINKS." + j + ".ADDINFO", "1");
                        request.AddParameter("DOCLINKS." + j + ".UPLOAD", "1");
                        request.AddParameter("DOCLINKS." + j + ".DESCRIPTION", compositeWorkorder.DOCLINKS[j].DESCRIPTION);
                        request.AddParameter("DOCLINKS." + j + ".DOCUMENTDATA", compositeWorkorder.DOCLINKS[j].DOCUMENTDATA);
                    }
                        try
                        {
                            Log.Write(LogLevel.Debug, "Updating DocLink ...");
                            var response = DoPost<SyncDCW_CBWOResponse>(request);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    
                }

            }
            
        }
        public string CreateWorkorder(CompositeWorkorder compositeWorkorder, List<string> attributes, List<string> specAttributes,
            List<AssetSpecType> attrTypes)
        {
            Log.Write(LogLevel.Info, string.Format("Creating Workorder type {0}...", compositeWorkorder.WORKORDER.WORKTYPE));
            var wo = compositeWorkorder.WORKORDER;
            string wonum;
            string resource = String.Format("os/dcw_cbwo?_format=xml");
            var request = new RestRequest(resource);
            var woType = wo.GetType();
            foreach (var attribute in attributes)
            {
                if (attribute == "STATUS" || attribute == "PROBLEMCODE" || attribute== "PARENT" || attribute=="ORIGRECORDID" || attribute=="ORIGRECORDCLASS" || attribute == "STATUSDATE" )
                    continue;
                var prop = woType.GetProperty(attribute);
                if (prop == null)
                {
                    throw new ApplicationException("Property not found:" + attribute);
                }
                object value;
                value = prop.GetValue(wo, null);
                if (value == null)
                    value = "";
                else
                {
                    if (IsNumericType(value.GetType()))
                        value = value.ToString();
                    else if (value is DateTime)
                        value = ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:sszzz");
                }

                request.AddParameter(attribute, value);
            }

            //Establish hierarchy
            if (!string.IsNullOrEmpty(compositeWorkorder.WORKORDER.ORIGRECORDID))
            {
                request.AddParameter("ORIGRECORDID", compositeWorkorder.WORKORDER.ORIGRECORDID);
                request.AddParameter("ORIGRECORDCLASS", compositeWorkorder.WORKORDER.ORIGRECORDCLASS);
            }
            if (!string.IsNullOrEmpty(compositeWorkorder.WORKORDER.PARENT))
            {
                request.AddParameter("PARENT", compositeWorkorder.WORKORDER.PARENT);
            }

            if (compositeWorkorder.WOSTATUS != null && compositeWorkorder.WOSTATUS.Count() > 0)
            {
                var woStatus = compositeWorkorder.WOSTATUS.OrderBy(s => s.CHANGEDATE).FirstOrDefault();
                if(woStatus == null)
                 throw new ApplicationException("unable to get status");
                request.AddParameter("STATUSIFACE", "1");
                request.AddParameter("STATUS", woStatus.STATUS);
                request.AddParameter("NP_STATUSMEMO", woStatus.MEMO);
            }
            try
            {
                var woResponse = DoPost<CreateDCW_CBWOResponse>(request);
                compositeWorkorder.WORKORDER.WONUM = woResponse.DCW_CBWOSet.WORKORDER[0].WONUM;
                wonum = compositeWorkorder.WORKORDER.WONUM;
                Log.Write(LogLevel.Info, string.Format("Workorder Created {0}", wonum));
                compositeWorkorder.WORKORDER.WORKORDERID = woResponse.DCW_CBWOSet.WORKORDER[0].WORKORDERID;
            }
            catch (Exception)
            {
                throw;
            }
            wo = compositeWorkorder.WORKORDER;
            resource = String.Format("os/dcw_cbwo/{0}?_format=xml", wo.WORKORDERID);
            request = new RestRequest(resource);
            if (compositeWorkorder.FAILUREREPORT != null)
            {
                request.AddParameter("_keys", "True");
                var problem = compositeWorkorder.FAILUREREPORT.FirstOrDefault(fr => fr.TYPE == "PROBLEM");
                if (problem != null && !string.IsNullOrEmpty(problem.FAILURECODE))
                    request.AddParameter("PROBLEMCODE", problem.FAILURECODE);
                var cause = compositeWorkorder.FAILUREREPORT.FirstOrDefault(fr => fr.TYPE == "CAUSE");
                var remedy = compositeWorkorder.FAILUREREPORT.FirstOrDefault(fr => fr.TYPE == "REMEDY");
                if (cause != null && !string.IsNullOrEmpty(cause.FAILURECODE))
                    request.AddParameter("FR1CODE", cause.FAILURECODE);
                if (remedy != null && !string.IsNullOrEmpty(remedy.FAILURECODE))
                    request.AddParameter("FR2CODE", remedy.FAILURECODE);
            }
            try
            {
                Log.Write(LogLevel.Debug, "Adding FailureReport ...");
                var woResponse = DoPost<SyncDCW_CBWOResponse>(request);
            }
            catch (Exception)
            {
                throw;
            }
            request = new RestRequest(resource); if (compositeWorkorder.FAILUREREMARK != null)
            {
                request.AddParameter("REMARKDESC", compositeWorkorder.FAILUREREMARK[0].DESCRIPTION); //254
                request.AddParameter("REMARKDESC_LONGDESCRIPTION", compositeWorkorder.FAILUREREMARK[0].DESCRIPTION_LONGDESCRIPTION); //clob

                var value = (compositeWorkorder.FAILUREREMARK[0].ENTERDATE.HasValue)
                            ? compositeWorkorder.FAILUREREMARK[0].ENTERDATE.Value.ToString("yyyy-MM-ddTHH:mm:sszzz")
                            : DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");

                request.AddParameter("REMARKENTERDATE", value);
            }
            try
            {
                Log.Write(LogLevel.Debug, "Adding FailureRemark ...");
                var woResponse = DoPost<SyncDCW_CBWOResponse>(request);
            }
            catch (Exception)
            {
                throw;
            }
            if (specAttributes.Count > 0)
            {
                request = new RestRequest(resource);
                var i = 1;
                foreach (var specAttr in specAttributes)
                {
                    var dataType = attrTypes.First(w => w.ASSETATTRID == specAttr).DATATYPE;
                    var newWoSpec = compositeWorkorder.WORKORDERSPEC.First(a => a.ASSETATTRID == specAttr);
                    request.AddParameter("WORKORDERSPEC." + i + ".ASSETATTRID", specAttr);
                    if (dataType == "NUMERIC")
                    {

                        if (!newWoSpec.NUMVALUE.HasValue)
                        {
                            request.AddParameter("WORKORDERSPEC." + i + ".NUMVALUE", "");
                        }
                        else
                        {
                            request.AddParameter("WORKORDERSPEC." + i + ".NUMVALUE", newWoSpec.NUMVALUE.ToString());
                        }
                        if (!string.IsNullOrEmpty(newWoSpec.MEASUREUNITID))
                            request.AddParameter("WORKORDERSPEC." + i + ".MEASUREUNITID", newWoSpec.MEASUREUNITID);
                    }
                    else
                    {

                        if (String.IsNullOrEmpty(newWoSpec.ALNVALUE))
                        {
                            request.AddParameter("WORKORDERSPEC." + i + ".ALNVALUE", "");
                        }
                        else
                        {
                            request.AddParameter("WORKORDERSPEC." + i + ".ALNVALUE", newWoSpec.ALNVALUE);
                        }
                    }
                    if (!String.IsNullOrEmpty(newWoSpec.SECTION))
                        request.AddParameter("WORKORDERSPEC." + i + ".SECTION", newWoSpec.SECTION);
                    else
                        request.AddParameter("WORKORDERSPEC." + i + ".SECTION", "");
                    i++;
                }

                try
                {
                    Log.Write(LogLevel.Debug, "Adding WorkorderSPecs ...");
                    var woResponse = DoPost<SyncDCW_CBWOResponse>(request);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (compositeWorkorder.WOSTATUS != null && compositeWorkorder.WOSTATUS.Count() > 1)
            {
                var woStatuses = compositeWorkorder.WOSTATUS.OrderBy(s => s.CHANGEDATE).ToArray();
                for (int j = 1; j < woStatuses.Count(); j++)
                {
                    resource = String.Format("os/dcw_cbwo/{0}?_format=xml&_keys=True", wo.WORKORDERID);
                    request = new RestRequest(resource);
                    request.AddParameter("STATUSIFACE", "1");
                    request.AddParameter("STATUS", woStatuses[j].STATUS);
                    request.AddParameter("NP_STATUSMEMO", woStatuses[j].MEMO);
                    try
                    {
                        Log.Write(LogLevel.Debug, "Adding Status ...");
                        var woResponse = DoPost<SyncDCW_CBWOResponse>(request);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }

            if (compositeWorkorder.LABTRANS != null)
            {
                foreach (var labTrans in compositeWorkorder.LABTRANS)
                {
                    request = new RestRequest("mbo/labtrans");
                    request.AddParameter("_format", "xml");
                    request.AddParameter("LABORCODE", labTrans.LABORCODE);
                    request.AddParameter("CRAFT", labTrans.CRAFT);
                    request.AddParameter("STARTDATE", labTrans.STARTDATE.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                    if (labTrans.STARTTIME.HasValue)
                        request.AddParameter("STARTTIME", labTrans.STARTTIME.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                    if (labTrans.FINISHDATE.HasValue)
                        request.AddParameter("FINISHDATE", labTrans.FINISHDATE.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                    if (labTrans.FINISHTIME.HasValue)
                        request.AddParameter("FINISHTIME", labTrans.FINISHTIME.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                    request.AddParameter("TRANSTYPE", labTrans.TRANSTYPE.Value);
                    request.AddParameter("REFWO", compositeWorkorder.WORKORDER.WONUM);
                    request.AddParameter("SITEID", compositeWorkorder.WORKORDER.SITEID);
                    request.AddParameter("PAYRATE", labTrans.PAYRATE);
                    try
                    {
                        Log.Write(LogLevel.Debug, "Adding LabTrans ...");
                        var labTransResponse = DoPost(request);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                if (compositeWorkorder.TOOLTRANS != null)
                {
                    foreach (var toolTrans in compositeWorkorder.TOOLTRANS)
                    {
                        request = new RestRequest("mbo/tooltrans");
                        request.AddParameter("_format", "xml");
                        request.AddParameter("ITEMNUM", toolTrans.ITEMNUM);
                        request.AddParameter("TOOLQTY", toolTrans.TOOLQTY);
                        request.AddParameter("TOOLHRS", toolTrans.TOOLHRS);
                        request.AddParameter("TRANSDATE", toolTrans.TRANSDATE.ToString("yyyy-MM-ddTHH:mm:sszzz"));
                        request.AddParameter("REFWO", compositeWorkorder.WORKORDER.WONUM);
                        request.AddParameter("SITEID", compositeWorkorder.WORKORDER.SITEID);
                        try
                        {
                            Log.Write(LogLevel.Debug, "Adding ToolTrans ...");
                            var toolTransResponse = DoPost(request);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }

                if (compositeWorkorder.DOCLINKS != null)
                {
                    resource = String.Format("os/dcw_cbwo/{0}?_format=xml", compositeWorkorder.WORKORDER.WORKORDERID);
                    request = new RestRequest(resource);
                    for (int j = 0; j < compositeWorkorder.DOCLINKS.Count(); j++)
                    {
                        request.AddParameter("DOCLINKS." + j + ".DOCTYPE", compositeWorkorder.DOCLINKS[j].DOCTYPE);
                        request.AddParameter("DOCLINKS." + j + ".URLTYPE", compositeWorkorder.DOCLINKS[j].URLTYPE);
                        request.AddParameter("DOCLINKS." + j + ".URLNAME", compositeWorkorder.DOCLINKS[j].URLNAME);
                        request.AddParameter("DOCLINKS." + j + ".ADDINFO", "1");
                        request.AddParameter("DOCLINKS." + j + ".UPLOAD", "1");
                        request.AddParameter("DOCLINKS." + j + ".DESCRIPTION", compositeWorkorder.DOCLINKS[j].DESCRIPTION);
                        request.AddParameter("DOCLINKS." + j + ".DOCUMENTDATA", compositeWorkorder.DOCLINKS[j].DOCUMENTDATA);
                    }
                    try
                    {
                        Log.Write(LogLevel.Debug, "Adding Doclinks ...");
                        var response = DoPost<SyncDCW_CBWOResponse>(request);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }

            }
            return wonum;
        }

        public void UpdateAsset(CompositeAsset compositeAsset, List<string> attributes, List<string> specAttributes, List<AssetSpecType> attrTypes)
        {
            var asset = compositeAsset.ASSET;
            var assetType = asset.GetType();
            string resource = String.Format("os/dcw_cbasset/{0}?_format=xml", compositeAsset.ASSET.ASSETUID);
            var request = new RestRequest(resource);
            foreach (var attribute in attributes)
            {
                var prop = assetType.GetProperty(attribute);
                if (prop == null)
                {
                    throw new ApplicationException("Property not found:"+attribute);
                }
                object value;
                value = prop.GetValue(asset, null);
                if (value == null)
                    value = "";
                else
                {
                    if (IsNumericType(value.GetType()))
                        value = value.ToString();
                    else if (value is DateTime)
                        value = ((DateTime)value).ToString("yyyy-MM-ddTHH:mm:sszzz");
                }

                request.AddParameter(attribute, value);
            }
            var i = 0;
            foreach (var specAttr in specAttributes)
            {
                var dataType = attrTypes.First(a => a.ASSETATTRID == specAttr).DATATYPE;
                var newAssetSpec = compositeAsset.ASSETSPEC.First(a => a.ASSETATTRID == specAttr);
                request.AddParameter("assetspec.id"+i+".ASSETATTRID", specAttr);
                if (dataType == "NUMERIC")
                {

                    if (!newAssetSpec.NUMVALUE.HasValue)
                    {
                        request.AddParameter("assetspec.id" + i + ".NUMVALUE", "");
                    }
                    else
                    {
                        request.AddParameter("assetspec.id" + i + ".NUMVALUE", newAssetSpec.NUMVALUE.ToString());
                    }
                    if (!string.IsNullOrEmpty(newAssetSpec.MEASUREUNITID))
                        request.AddParameter("assetspec.id" + i + ".MEASUREUNITID", newAssetSpec.MEASUREUNITID);
                }
                else
                {
 
                    if (String.IsNullOrEmpty(newAssetSpec.ALNVALUE))
                    {
                        request.AddParameter("assetspec.id" + i + ".ALNVALUE", "");
                    }
                    else
                    {
                        request.AddParameter("assetspec.id" + i + ".ALNVALUE", newAssetSpec.ALNVALUE);
                    }
                }
                if(!String.IsNullOrEmpty(newAssetSpec.SECTION))
                  request.AddParameter("assetspec.id"+i+".SECTION", newAssetSpec.SECTION);
                else
                  request.AddParameter("assetspec.id" + i + ".SECTION", "");

				request.AddParameter("assetspec.id"+i+".LINEARASSETSPECID", newAssetSpec.LINEARASSETSPECID);
                i++;
            }

            try
            {
                Log.Write(LogLevel.Debug, "Updating Asset ...");
                var newAssetResponse = DoPost<SyncDCW_CBASSETResponse>(request);
            }
            catch (Exception)
            {                
                throw;
            }
        
        }

        public void UpdateAssetSpecs(CompositeAsset compositeAsset, List<string> specAttributes, List<AssetSpecType> attrTypes)
        {

            string resource = String.Format("os/dcw_cbasset/{0}?_format=xml", compositeAsset.ASSET.ASSETUID);
            var request = new RestRequest(resource);
            var i = 0;
            foreach (var specAttr in specAttributes)
            {
                var dataType = attrTypes.First(a => a.ASSETATTRID == specAttr).DATATYPE;
                var newAssetSpec = compositeAsset.ASSETSPEC.First(a => a.ASSETATTRID == specAttr);
                request.AddParameter("assetspec.id" + i + ".ASSETATTRID", specAttr);
                if (dataType == "NUMERIC")
                {

                    if (!newAssetSpec.NUMVALUE.HasValue)
                    {
                        request.AddParameter("assetspec.id" + i + ".NUMVALUE", "");
                    }
                    else
                    {
                        request.AddParameter("assetspec.id" + i + ".NUMVALUE", newAssetSpec.NUMVALUE.ToString());
                    }
                    if (!string.IsNullOrEmpty(newAssetSpec.MEASUREUNITID))
                        request.AddParameter("assetspec.id" + i + ".MEASUREUNITID", newAssetSpec.MEASUREUNITID);
                }
                else
                {

                    if (String.IsNullOrEmpty(newAssetSpec.ALNVALUE))
                    {
                        request.AddParameter("assetspec.id" + i + ".ALNVALUE", "");
                    }
                    else
                    {
                        request.AddParameter("assetspec.id" + i + ".ALNVALUE", newAssetSpec.ALNVALUE);
                    }
                }
                if (!String.IsNullOrEmpty(newAssetSpec.SECTION))
                    request.AddParameter("assetspec.id" + i + ".SECTION", newAssetSpec.SECTION);
                else
                    request.AddParameter("assetspec.id" + i + ".SECTION", "");

                request.AddParameter("assetspec.id" + i + ".LINEARASSETSPECID", newAssetSpec.LINEARASSETSPECID);
                i++;
            }

            try
            {
                Log.Write(LogLevel.Debug, "Updating AssetSpec ...");
                var newAssetResponse = DoPost<SyncDCW_CBASSETResponse>(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CompositeAsset CreateAsset(CompositeAsset compositeAsset, List<string> attributes, List<string> specAttributes,  List<AssetSpecType> attrTypes)
        {
            Log.Write(LogLevel.Info, string.Format("Creating asset {0} in Maximo...",compositeAsset.ASSET.ASSETTAG));
            //Create record in Maximo. Return new ASSETNUM
            ASSETMbo asset = compositeAsset.ASSET;
            ASSETSPECMboSetASSETSPEC[] assetSpecs = compositeAsset.ASSETSPEC;
            CreateDCW_CBASSETResponse newAssetResponse;
            try
            {

                const string resource = "os/dcw_cbasset";
                var request = new RestRequest(resource);
                request.AddParameter("_format", "xml");

 //               var createAttr = ASSETMbo.GetCreateAttributeNames();

                var objType = asset.GetType();
                foreach (var attrName in attributes)
                {
                    var prop = objType.GetProperty(attrName);
                    var rawValue = prop.GetValue(asset, null);
                    if (rawValue == null)
                        continue;
                    var propType = prop.PropertyType;
                    if (propType.IsPrimitive || propType.IsValueType || propType == typeof(string))
                    {
                        request.AddParameter(prop.Name, rawValue.ToString());
                    }
                    else
                    {
                        if (prop.PropertyType == typeof (ASSETSTATUS))
                            request.AddParameter(prop.Name, ((ASSETSTATUS) rawValue).Value);
                    }

                }
                newAssetResponse = DoPost<CreateDCW_CBASSETResponse>(request);
            }
            catch (Exception e)
            {
                Log.Write(LogLevel.Fatal, string.Format("Exception when creating asset {0}",e));
                throw;
            }
            if (newAssetResponse.DCW_CBASSETSet == null)
            {
                Log.Write(LogLevel.Fatal, "Failed to create asset");
                return null;
            }

            var assetNum = newAssetResponse.DCW_CBASSETSet.ASSET[0].ASSETNUM;
            Log.Write(LogLevel.Info, string.Format("Asset {0} created Maximo...", assetNum));
            compositeAsset.ASSET.ASSETNUM = assetNum;
            compositeAsset.ASSET.ASSETUID = newAssetResponse.DCW_CBASSETSet.ASSET[0].ASSETUID;

                try
                {
                    UpdateAssetSpecs(compositeAsset, specAttributes, attrTypes);
                }
                catch (Exception)
                {
                    
                    throw;
                }            
            
            var newCompositeAsset = GetCompositeAsset(assetNum);
            Log.Write(LogLevel.Info, "Asset Created.");
            return newCompositeAsset;
        }

 #endregion
        
        
        private T Execute<T>(RestRequest request) where T : new()
        {

            request.AddHeader("MAXAUTH", _maxCreds.getMaxAuthHeader());
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/xml,text/xml");
            Log.Write(LogLevel.Debug, string.Format("Executing request {0}",request.Resource));
            foreach (var parameter in request.Parameters)
            {
                Log.Write(LogLevel.Debug, parameter.ToString());
            }
            var response = _restClient.Execute<T>(request);
#if DEBUG
            Log.Write(LogLevel.Debug, response.Content);
#endif
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                Log.Write(LogLevel.Error, string.Format("Bad request Status: {0} {1}",response.Content,response.ErrorException));
                var badRequestException = new ApplicationException(response.Content, response.ErrorException);
                throw badRequestException;
            }

            if (response.ErrorException != null)
            {
                Log.Write(LogLevel.Error, string.Format("Maximo Exception:{0}", response.ErrorException));
                const string message = "Error retrieving response. Check inner details for more info.";
                var maximoException = new ApplicationException(message, response.ErrorException);
                throw maximoException;
            }
            return response.Data;
        }

        private string DoGet (RestRequest request)
        {

            request.AddHeader("MAXAUTH", _maxCreds.getMaxAuthHeader());
            request.Method = Method.GET;
            request.AddHeader("Accept", "application/xml,text/xml");
            Log.Write(LogLevel.Debug, string.Format("Executing request {0}", request.Resource));
            foreach (var parameter in request.Parameters)
            {
                Log.Write(LogLevel.Debug, parameter.ToString());
            }
            var response = _restClient.Execute(request);
#if DEBUG
            Log.Write(LogLevel.Debug, response.Content);
#endif
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                Log.Write(LogLevel.Error, string.Format("Bad request Status: {0} {1}", response.Content, response.ErrorException));
                var badRequestException = new ApplicationException(response.Content, response.ErrorException);
                throw badRequestException;
            }

            if (response.ErrorException != null)
            {
                Log.Write(LogLevel.Error, string.Format("Maximo Exception:{0}", response.ErrorException));
                const string message = "Error retrieving response. Check inner details for more info.";
                var maximoException = new ApplicationException(message, response.ErrorException);
                throw maximoException;
            }
            return response.Content;
        }
        private T DoGet<T>(RestRequest request, string elementName) where T : new()
        {

            request.AddHeader("MAXAUTH", _maxCreds.getMaxAuthHeader());
            request.AddHeader("Accept", "application/xml,text/xml");           
            request.Method = Method.GET;
            Log.Write(LogLevel.Debug, string.Format("Executing request {0}", request.Resource));
            foreach (var parameter in request.Parameters)
            {
                Log.Write(LogLevel.Debug, parameter.ToString());
            }
            var response = _restClient.Execute(request);
#if DEBUG
            Log.Write(LogLevel.Debug, response.Content);
#endif
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                Log.Write(LogLevel.Error, string.Format("Bad request Status: {0} {1}", response.Content, response.ErrorException));
                var badRequestException = new ApplicationException(response.Content, response.ErrorException);
                throw badRequestException;
            }

            if (response.ErrorException != null)
            {
                Log.Write(LogLevel.Error, string.Format("Maximo Exception:{0}", response.ErrorException));
                const string message = "Error retrieving response. Check inner details for more info.";
                var maximoException = new ApplicationException(message, response.ErrorException);
                throw maximoException;
            }
            var rootAttribute = new XmlRootAttribute();
            rootAttribute.ElementName = elementName;
            rootAttribute.Namespace = "http://www.ibm.com/maximo";
            rootAttribute.IsNullable = true;
            T data = default(T);
            try
            {
                data = Deserialize<T>(response, rootAttribute);

            }
            catch (Exception e)
            {
                Log.Write(LogLevel.Error, string.Format("Deserialize Exception:{0}", e));
                const string message = "Error retrieving response. Check inner details for more info.";
                var maximoException = new ApplicationException(message, e);
                throw maximoException;
            }

            return data;
        }
        public T Deserialize<T>(IRestResponse response, XmlRootAttribute root)
        {
            if (string.IsNullOrEmpty(response.Content))
            {
                return default(T);
            }

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(response.Content)))
            {
                XmlSerializer serializer;
                serializer = root != null ? 
                    new XmlSerializer(typeof(T),root) :
                    new System.Xml.Serialization.XmlSerializer(typeof(T));
                
                return (T)serializer.Deserialize(stream);
            }
        }

        private T DoPost<T> (RestRequest request) where T : new ()
        {

            request.AddHeader("MAXAUTH", _maxCreds.getMaxAuthHeader());
            request.AddHeader("Accept", "application/xml,text/xml");
            request.Method = Method.POST;
            Log.Write(LogLevel.Debug, string.Format("Executing request {0}", request.Resource));
            foreach (var parameter in request.Parameters)
            {
                Log.Write(LogLevel.Debug, parameter.ToString());
            }
            var response = _restClient.Execute<T>(request);
#if DEBUG
            Log.Write(LogLevel.Debug, response.Content);
#endif
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                Log.Write(LogLevel.Error, string.Format("Bad request Status: {0} {1}", response.Content, response.ErrorException));
                var badRequestException = new ApplicationException(response.Content, response.ErrorException);
                throw badRequestException;
            }

            if (response.ErrorException != null)
            {
                Log.Write(LogLevel.Error, string.Format("Maximo Exception:{0}", response.ErrorException));
                const string message = "Error retrieving response. Check inner details for more info.";
                var maximoException = new ApplicationException(message, response.ErrorException);
                throw maximoException;
            }
            return response.Data;
        }

        private T DoPost<T>(RestRequest request, string elementName) where T : new()
        {

            request.AddHeader("MAXAUTH", _maxCreds.getMaxAuthHeader());
            request.Method = Method.POST;
            request.AddHeader("Accept", "application/xml,text/xml");

            Log.Write(LogLevel.Debug, string.Format("Executing request {0}", request.Resource));
            foreach (var parameter in request.Parameters)
            {
                Log.Write(LogLevel.Debug, parameter.ToString());
            }
            var response = _restClient.Execute(request);
#if DEBUG
            Log.Write(LogLevel.Debug, response.Content);
#endif

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                Log.Write(LogLevel.Error, string.Format("Bad request Status: {0} {1}", response.Content, response.ErrorException));
                var badRequestException = new ApplicationException(response.Content, response.ErrorException);
                throw badRequestException;
            }

            var rootAttribute = new XmlRootAttribute();
            rootAttribute.ElementName = elementName;
            rootAttribute.Namespace = "http://www.ibm.com/maximo";
            rootAttribute.IsNullable = true;
            T data = default(T);
            try
            {
                 data = Deserialize<T>(response, rootAttribute);

            }
            catch (Exception e)
            {
                Log.Write(LogLevel.Error, string.Format("Deserialize Exception:{0}", e));
                const string message = "Error retrieving response. Check inner details for more info.";
                var maximoException = new ApplicationException(message, e);
                throw maximoException;
            }

            return data;
        }

        private string DoPost(RestRequest request)
        {

            request.AddHeader("MAXAUTH", _maxCreds.getMaxAuthHeader());
            request.Method = Method.POST;
            request.AddHeader("Accept", "application/xml,text/xml");

            Log.Write(LogLevel.Debug, string.Format("Executing request {0}", request.Resource));
            foreach (var parameter in request.Parameters)
            {
                Log.Write(LogLevel.Debug,parameter.ToString());
            }
            var response = _restClient.Execute(request);
#if DEBUG
            Log.Write(LogLevel.Debug, response.Content);
#endif
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                Log.Write(LogLevel.Error, string.Format("Bad request Status: {0} {1}", response.Content, response.ErrorException));
                var badRequestException = new ApplicationException(response.Content, response.ErrorException);
                throw badRequestException;
            }

            if (response.ErrorException != null)
            {
                Log.Write(LogLevel.Error, string.Format("Maximo Exception:{0}", response.ErrorException));
                const string message = "Error retrieving response. Check inner details for more info.";
                var maximoException = new ApplicationException(message, response.ErrorException);
                throw maximoException;
            }
            return response.Content;
        }

        //

        private string DocumentUpload()
        {
            string path = Path.Combine("C:\\TEMP", Path.GetFileName("DSCN0074.JPG"));
            string base64Data;
            try
            {
                byte[] data = File.ReadAllBytes(path);
                base64Data = Convert.ToBase64String(data);
            }
            catch (Exception)
            {

                throw;
            }
            return base64Data;
        }
        private static bool IsNumericType(Type type)
        {
            if (type == null)
            {
                return false;
            }

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(type));
                    }
                    return false;
            }
            return false;
        }


    }
}
