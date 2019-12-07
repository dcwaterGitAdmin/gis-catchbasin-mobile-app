using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Net.Cache;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using DCWaterMobile.LocalData.Models;
using DCWaterMobile.MaximoService;
using DCWaterMobile.MaximoService.MaxRest;
using GalaSoft.MvvmLight.Messaging;
using DCWaterMobile.Utilities;

namespace DCWaterMobile.LocalData
{

    public class LocalDataService : ILocalDataService
    {
        //TODO: Must ensure that we do a deep compare before the dirty WOs are sent to Maximo.
        //      Get current version from Maximo (deep)
        //      Compare All Attributes that can be modified by App
        //      If there is a difference, inform user
        //      Save Dirty to local xml file
        //      replace dirty by maximo version.

        private IMaximoService _maximoService;
        private string _attachmentPath = "C:\\TEMP";
        private string _workFilter;
        public LocalDataService(IMaximoService maximoService)
        {
            _maximoService = maximoService;
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings.Get("ATTACHMENTPATH")))
                _attachmentPath = System.Configuration.ConfigurationManager.AppSettings.Get("ATTACHMENTPATH");
        }

        public List<PERSON> GetPersons(string laborCraftRate)
        {
            var laborsToFind = laborCraftRate.Split(',').ToList();

            List<PERSON> result = null;
            using (var context = new MxLocalReferenceDataContext())
            {
                var laborCodes = context.LABORCRAFTRATEs.Where(p => laborsToFind.Contains(p.CRAFT));
                if (!laborCodes.Any())
                    return null;
                
                result = new List<PERSON>();
                foreach (var laborCode in laborCodes)
                {
                    var person = GetPerson(laborCode.LABORCODE);
                    //Only Active Persons are allowed
                    if (person != null)
                        result.Add(person); 
                }
            }
            return result;
        }

        public List<INVENTORY> GetVehicles(string toolLocation, string toolBin)
        {
            var bins = toolBin.Split(',').ToList();

            List<INVENTORY> result = null;
            using (var context = new MxLocalReferenceDataContext())
            {
                var inventory = context.INVENTORies.Where(i => bins.Contains(i.BINNUM) && i.LOCATION==toolLocation);
                if (!inventory.Any())
                    return null;
                result = inventory.ToList();
            }
            return result;

        }

        public List<PERSONGROUP> GetCrews(string whereClause)
        {
            List<PERSONGROUP> result = null;
            using (var context = new MxLocalReferenceDataContext())
            {
                var personGroups = context.PERSONGROUPs.Where(p =>p.DESCRIPTION.Contains(whereClause));
                if (!personGroups.Any())
                    return null;
                result = personGroups.ToList();
            }
            return result;
            
        }

        public LABORCRAFTRATE GetLaborCraftRate(string laborCode)
        {
            using (var context = new MxLocalReferenceDataContext())
            {
                var loborCraftRate = context.LABORCRAFTRATEs.FirstOrDefault(l => l.LABORCODE == laborCode);
                return loborCraftRate;
            }

        }

        public List<WORKORDER> GetWorkorders()
        {
            List<WORKORDER> result = null;
            using (var context = new MxLocalCacheContext())
            {
                 var workorders = context.WORKORDERs;
                if (!workorders.Any())
                    return null;
                result = workorders
                          .Include("WorkorderSpecs")
                          .Include("Asset")
                          .Include("Asset.AssetSpecs")
                          .Include("FailureRemark")
                          .Include("FailureReports")
                          .Include("LabTrans")
                          .Include("ToolTrans")
                          .Include("WoStatuses")
                          .Include("DocLinks")
                          .Include("DocLinks.DocInfo")
                          .ToList();
            }
            return result;
            
        }

        public List<WORKORDER> GetWorkorders(string filter)
        {
            List<WORKORDER> result = null;
            using (var context = new MxLocalCacheContext())
            {

                var workorders = context.WORKORDERs;
                if (!workorders.Any())
                    return null;
                result = workorders
                          .Include("WorkorderSpecs")
                          .Include("Asset")
                          .Include("Asset.AssetSpecs")
                          .Include("FailureRemark")
                          .Include("FailureReports")
                          .Include("LabTrans")
                          .Include("ToolTrans")
                          .Include("WoStatuses")
                          .Include("DocLinks")
                          .Include("DocLinks.DocInfo")
                          .Where(filter)
                          .ToList();
            }
            return result;
                   
        }


        public WORKORDER GetWorkorder(string wonum)
        {
            WORKORDER result= null;
            using (var context = new MxLocalCacheContext())
            {
                var workorders = context.WORKORDERs;
                if (!workorders.Any())
                    return null;
                result = workorders
                          .Include("WorkorderSpecs")
                          .Include("Asset")
                          .Include("Asset.AssetSpecs")
                          .Include("FailureRemark")
                          .Include("FailureReports")
                          .Include("LabTrans")
                          .Include("ToolTrans")
                          .Include("WoStatuses")
                          .Include("DocLinks")
                          .Include("DocLinks.DocInfo")
                          .FirstOrDefault(w => w.WONUM == wonum);
            }

            return result;
        }

        public void SaveWorkorder(WORKORDER workorder)
        {
            try
            {

                var woState = EntityState.Modified;
                if ((LocalState) workorder.C_record_state_ == LocalState.Added ||
                    (workorder.WorkorderSpecs != null && workorder.WorkorderSpecs.Any(s => (LocalState) s.C_record_state_ == LocalState.Added)) ||
                    (workorder.WoStatuses != null && workorder.WoStatuses.Any(s => (LocalState) s.C_record_state_ == LocalState.Added)) ||
                    (workorder.Doclinks != null && workorder.Doclinks.Any(s => (LocalState) s.C_record_state_ == LocalState.Added)) ||
                    (workorder.LabTrans != null && workorder.LabTrans.Any(s => (LocalState) s.C_record_state_ == LocalState.Added)) ||
                    (workorder.ToolTrans != null &&  workorder.ToolTrans.Any(s => (LocalState) s.C_record_state_ == LocalState.Added)) ||
                    (workorder.Asset != null && ((LocalState) workorder.Asset.C_record_state_ == LocalState.Added))  ||
                    (workorder.Asset != null && workorder.Asset.AssetSpecs != null && workorder.Asset.AssetSpecs.Any(s => (LocalState) s.C_record_state_ == LocalState.Added))
                    )
                    woState = EntityState.Added;

                using (var context = new MxLocalCacheContext())
                {
                     using (var tx = context.Database.BeginTransaction())
                    {
                        try
                        {
                           // First mark all the new records as added
                            if (workorder.Asset != null)
                            {
                                if (workorder.Asset.C_ASSETNUM_LOCAL_ == 0)
                                {
                                    context.Entry(workorder.Asset).State = EntityState.Added;
                                }
                                if (workorder.Asset.AssetSpecs != null)
                                {
                                    foreach (var assetSpec in workorder.Asset.AssetSpecs)
                                    {
                                        if (assetSpec.C_ASSETSPECID_LOCAL_ == 0)
                                        {
                                            context.Entry(assetSpec).State = EntityState.Added;
                                        }
                                    }
                                }
                            }

                            if (workorder.WorkorderSpecs != null)
                            {
                                foreach (var workorderSpec in workorder.WorkorderSpecs)
                                {
                                    if (workorderSpec.C_WORKORDERSPECID_LOCAL_ == 0)
                                    {
                                        context.Entry(workorderSpec).State = EntityState.Added;
                                    }
                                }
                            }

                            if (workorder.FailureReports != null)
                            {

                                foreach (var failureReport in workorder.FailureReports)
                                {
                                    if (failureReport.C_FAILUREREPORTID_LOCAL_ == 0)
                                    {
                                        context.Entry(failureReport).State = EntityState.Added;
                                    }
                                }
                            }

                            if (workorder.FailureRemark != null)
                            {
                                if (workorder.FailureRemark.C_FAILUREREMARKID_LOCAL_ == 0)
                                {
                                    context.Entry(workorder.FailureRemark).State = EntityState.Added;
                                }
                            }

                            if (workorder.LabTrans != null)
                            {
                                foreach (var labTrans in workorder.LabTrans)
                                {
                                    if (labTrans.C_LABTRANSID_LOCAL_ == 0)
                                    {
                                        context.Entry(labTrans).State = EntityState.Added;
                                    }
                                }
                        
                            }

                            if (workorder.ToolTrans != null)
                            {
                                foreach (var toolTrans in workorder.ToolTrans)
                                {
                                    if (toolTrans.C_TOOLTRANSID_LOCAL_ == 0)
                                    {
                                        context.Entry(toolTrans).State = EntityState.Added;
                                    }
                                }
                            }
                            if (workorder.WoStatuses != null)
                            {
                                foreach (var woStatus in workorder.WoStatuses)
                                {
                                    if (woStatus.C_WOSTATUSID_LOCAL_ == 0)
                                    {
                                        context.Entry(woStatus).State = EntityState.Added;
                                    }
                                }
                            }

                            if (workorder.Doclinks != null)
                            {
                                foreach (var doclinks in workorder.Doclinks)
                                {
                                    if (doclinks.C_DOCLINKSID_LOCAL_ == 0)
                                    {
                                        context.Entry(doclinks).State = EntityState.Added;
                                        context.Entry(doclinks.DocInfo).State = EntityState.Added;
                                    }
                                }
                            }

                            context.Entry(workorder).State = workorder.C_WORKORDERID_LOCAL_ == 0
                                ? EntityState.Added
                                : EntityState.Modified;

                            context.SaveChanges();

                            //Process the rest
                            if (workorder.Asset != null)
                                 {
                                if (workorder.Asset.C_record_state_ == (int) LocalState.Original)
                                {
                                  context.Entry(workorder.Asset).State = EntityState.Unchanged;
                                }
                                else
                                {
                                    context.Entry(workorder.Asset).State = workorder.Asset.C_ASSETNUM_LOCAL_ == 0
                                       ? EntityState.Added
                                       : EntityState.Modified;
                                }


                                if (workorder.Asset.AssetSpecs != null)
                                {
                                    foreach (var assetSpec in workorder.Asset.AssetSpecs)
                                    {
                                        if (assetSpec.C_record_state_ == (int) LocalState.Original)
                                        {
                                            context.Entry(assetSpec).State = EntityState.Unchanged;
                                        }
                                        else
                                        {
                                            context.Entry(assetSpec).State = assetSpec.C_ASSETSPECID_LOCAL_ == 0
                                                ? EntityState.Added
                                                : EntityState.Modified;
                                        }
                                    }
                                }
                            }

                            if (workorder.C_ASSETNUM_LOCAL == null && workorder.Asset != null)
                                workorder.C_ASSETNUM_LOCAL = workorder.Asset.C_ASSETNUM_LOCAL_;

                            if (workorder.WorkorderSpecs != null)
                            {
                                foreach (var workorderSpec in workorder.WorkorderSpecs)
                                {
                                    if (workorderSpec.C_record_state_ == (int)LocalState.Original)
                                    {
                                        context.Entry(workorderSpec).State = EntityState.Unchanged;
                                    }
                                    else
                                    {
                                        context.Entry(workorderSpec).State = workorderSpec.C_WORKORDERSPECID_LOCAL_ == 0
                                            ? EntityState.Added
                                            : EntityState.Modified;
                                    }
                                }
                            }

                            if (workorder.FailureReports != null)
                            {

                                foreach (var failureReport in workorder.FailureReports)
                                {
                                    if (failureReport.C_record_state_ == (int) LocalState.Original)
                                    {
                                        context.Entry(failureReport).State = EntityState.Unchanged;
                                    }
                                    else
                                    {

                                        context.Entry(failureReport).State = failureReport.C_FAILUREREPORTID_LOCAL_ == 0
                                            ? EntityState.Added
                                            : EntityState.Modified;
                                        //if (context.Entry(failureReport).State == EntityState.Added)
                                        //    context.Entry(workorder).State = EntityState.Added;
                                    }
                                }
                            }
                       if (workorder.FailureRemark != null)
                       {
                           if (workorder.FailureRemark.C_record_state_ != (int) LocalState.Original)
                           {
                               context.Entry(workorder.FailureRemark).State =
                                   workorder.FailureRemark.C_FAILUREREMARKID_LOCAL_ == 0
                                       ? EntityState.Added
                                       : EntityState.Modified;
                               //if (context.Entry(workorder.FailureRemark).State == EntityState.Added)
                               //    context.Entry(workorder).State = EntityState.Added;
                           }
                           else
                           {
                               context.Entry(workorder.FailureRemark).State =EntityState.Unchanged;
                           }
                       }

                        if (workorder.LabTrans != null)
                        {
                            foreach (var labTrans in workorder.LabTrans)
                            {
                                if (labTrans.C_record_state_ == (int) LocalState.Original)
                                {
                                    context.Entry(labTrans).State = EntityState.Unchanged;
                                }
                                else
                                {
                                    context.Entry(labTrans).State = labTrans.C_LABTRANSID_LOCAL_ == 0
                                        ? EntityState.Added
                                        : EntityState.Modified;
                                }
                            }
                        
                        }


                        if (workorder.ToolTrans != null)
                        {
                            foreach (var toolTrans in workorder.ToolTrans)
                            {
                                if (toolTrans.C_record_state_ == (int) LocalState.Original)
                                {
                                    context.Entry(toolTrans).State = EntityState.Unchanged;
                                }
                                else
                                {

                                    context.Entry(toolTrans).State = toolTrans.C_TOOLTRANSID_LOCAL_ == 0
                                        ? EntityState.Added
                                        : EntityState.Modified;
                                }
                            }
                        }
                        context.SaveChanges();
                        if (workorder.WoStatuses != null)
                        {
                            foreach (var woStatus in workorder.WoStatuses)
                            {
                                context.Entry(woStatus).State = woStatus.C_WOSTATUSID_LOCAL_ == 0
                                    ? EntityState.Added
                                    : EntityState.Unchanged;
                            }
                        }

                        if (workorder.Doclinks != null)
                        {
                            foreach (var doclinks in workorder.Doclinks)
                            {
                                if (doclinks.C_record_state_ == (int) LocalState.Original)
                                {
                                    context.Entry(doclinks).State = EntityState.Unchanged;
                                    context.Entry(doclinks.DocInfo).State = EntityState.Unchanged;
                                }
                                else
                                {
                                    context.Entry(doclinks).State = doclinks.C_DOCLINKSID_LOCAL_ == 0
                                        ? EntityState.Added
                                        : EntityState.Modified;
                                    context.Entry(doclinks.DocInfo).State = doclinks.DocInfo.C_DOCINFOID_LOCAL_ == 0
                                        ? EntityState.Added
                                        : EntityState.Modified;
                                }
                            }
                        }
                        context.Entry(workorder).State = workorder.C_WORKORDERID_LOCAL_ == 0
                            ? EntityState.Added
                            : EntityState.Modified;


                        context.SaveChanges();

                        }
                        catch (DbEntityValidationException ex)
                        {
                            DumpValidationErrors(ex);
                            throw new ApplicationException("Failed to save");
                        }
                        catch (Exception)
                        {
                            tx.Rollback();
                            throw;
                        }
                        tx.Commit();
                    }
                }

            }
            catch (DbEntityValidationException ex)
            {
                DumpValidationErrors(ex);
            }
        }


        public WORKORDER GetWorkorder(long workorderidLocal)
        {
            WORKORDER result = null;
            using (var context = new MxLocalCacheContext())
            {
                var workorders = context.WORKORDERs;
                if (!workorders.Any())
                    return null;
                result = workorders
                          .Include("WorkorderSpecs")
                          .Include("Asset")
                          .Include("Asset.AssetSpecs")
                          .Include("FailureRemark")
                          .Include("FailureReports")
                          .Include("LabTrans")
                          .Include("ToolTrans")
                          .Include("WoStatuses")
                          .Include("DocLinks")
                          .Include("DocLinks.DocInfo")
                          .FirstOrDefault(w => w.C_WORKORDERID_LOCAL_ == workorderidLocal);
            }
            return result;
          
        }

        public ASSET GetAsset(string assetnum, string siteid)
        {
            ASSET result = null;
            using (var context = new MxLocalCacheContext())
            {
                var assets = context.ASSETs;
                if (!assets.Any())
                    return null;
                result = assets
                    .Include("AssetSpecs")
                    .FirstOrDefault(a => a.ASSETNUM == assetnum && a.SITEID == siteid);
            }
            return result;
        }

        public ASSET GetAsset(long assetidLocal)
        {
            ASSET result = null;
            using (var context = new MxLocalCacheContext())
            {
                var assets = context.ASSETs;
                if (!assets.Any())
                    return null;
                result = assets
                    .Include("AssetSpecs")
                    .FirstOrDefault(a => a.C_ASSETNUM_LOCAL_ == assetidLocal);
            }
            return result;
        }

        public ASSET GetAssetByTag(string assetTag, string siteid)
        {
            ASSET result = null;
            using (var context = new MxLocalCacheContext())
            {
                var assets = context.ASSETs;
                if (!assets.Any())
                    return null;
                result = assets
                    .Include("AssetSpecs")
                    .FirstOrDefault(a => a.ASSETTAG == assetTag && a.SITEID == siteid);
            }
            return result;
        }

        public LOCATION GetLocation(string location)
        {
            using (var context = new MxLocalCacheContext())
            {
                return context.LOCATIONS.FirstOrDefault(l => l.LOCATION_ == location);
            }
        }

        public List<ALNDOMAIN> GetAlnDomain(string domainName)
        {
            List<ALNDOMAIN> result = null;
            using (var context = new MxLocalReferenceDataContext())
            {
                var domainValues = context.ALNDOMAINs.Where(d => d.DOMAINID == domainName);
                if (!domainValues.Any())
                    return null;
                result = domainValues.ToList();
            }
            return result;
            
        }

        public List<FAILURECODE> GetProblems(string orgid, string failureCode)
        {
            List<FAILURECODE> result = null;
            using (var context = new MxLocalReferenceDataContext())
            {
                     
                var parent = context.FAILURELISTs.FirstOrDefault(f => f.FAILURECODE == failureCode && f.ORGID == orgid && f.PARENT == null);
                if (parent == null)
                    return null;

                var query = from failureCode_ in context.FAILURECODEs
                    join faillureList in context.FAILURELISTs
                        on failureCode_.FAILURECODE_ equals faillureList.FAILURECODE
                    where faillureList.PARENT == parent.FAILURELIST_ && faillureList.TYPE == "PROBLEM"
                    select failureCode_;

                if (!query.Any())
                    return null;
                result = query.ToList();
            }
            return result;
        }

        public List<FAILURECODE> GetCauses(string orgid, string failureCode, string problem)
        {
            List<FAILURECODE> result = null;
            using (var context = new MxLocalReferenceDataContext())
            {
                var parent = context.FAILURELISTs.FirstOrDefault(f => f.FAILURECODE == failureCode && f.ORGID == orgid && f.PARENT == null);
                if (parent == null)
                    return null;

                var problemRow = context.FAILURELISTs.FirstOrDefault(f => f.FAILURECODE == problem && f.TYPE == "PROBLEM" && f.PARENT == parent.FAILURELIST_ && f.ORGID == orgid);
                if (problemRow == null)
                    return null;

                var causes = from failureCode_ in context.FAILURECODEs
                            join faillureList in context.FAILURELISTs
                                on failureCode_.FAILURECODE_ equals faillureList.FAILURECODE
                            where faillureList.PARENT == problemRow.FAILURELIST_ && faillureList.TYPE == "CAUSE"
                            select failureCode_;

                if (!causes.Any())
                    return null;
                result = causes.ToList();
            }
            return result;
        }

        public List<FAILURECODE> GetRemedies(string orgid, string failureCode, string problem, string cause)
        {
            List<FAILURECODE> result = null;
            using (var context = new MxLocalReferenceDataContext())
            {
                var parent = context.FAILURELISTs.FirstOrDefault(f => f.FAILURECODE == failureCode && f.ORGID == orgid && f.PARENT == null);
                if (parent == null)
                    return null;

                var problemRow = context.FAILURELISTs.FirstOrDefault(f => f.FAILURECODE == problem && f.TYPE == "PROBLEM" && f.PARENT == parent.FAILURELIST_ && f.ORGID == orgid);
                if (problemRow == null)
                    return null;


                var causeRow = context.FAILURELISTs.FirstOrDefault(f => f.FAILURECODE == cause && f.TYPE == "CAUSE" && f.PARENT == problemRow.FAILURELIST_ && f.ORGID == orgid);
                if (causeRow == null)
                    return null;

                var remedy = from failureCode_ in context.FAILURECODEs
                             join faillureList in context.FAILURELISTs
                                 on failureCode_.FAILURECODE_ equals faillureList.FAILURECODE
                             where faillureList.PARENT == causeRow.FAILURELIST_ && faillureList.TYPE == "REMEDY"
                             select failureCode_;


                if (!remedy.Any())
                    return null;
                result = remedy.ToList();
            }
            return result;
        }

        public long? GetFailureListLineNumber(string orgid, string failureCode, string problem)
        {
            using (var context = new MxLocalReferenceDataContext())
            {
                var parent =
                    context.FAILURELISTs.FirstOrDefault(
                        f => f.FAILURECODE == failureCode && f.ORGID == orgid && f.PARENT == null);
                if (parent == null)
                    return null;

                var problemRow =
                    context.FAILURELISTs.FirstOrDefault(
                        f =>
                            f.FAILURECODE == problem && f.TYPE == "PROBLEM" && f.PARENT == parent.FAILURELIST_ &&
                            f.ORGID == orgid);
                if (problemRow == null)
                    return null;
                return problemRow.FAILURELIST_;
            }
            return null;
        }

        public long? GetFailureListLineNumber(string orgid, string failureCode, string problem, string cause)
        {
            using (var context = new MxLocalReferenceDataContext())
            {
                var parent =
                    context.FAILURELISTs.FirstOrDefault(
                        f => f.FAILURECODE == failureCode && f.ORGID == orgid && f.PARENT == null);
                if (parent == null)
                    return null;

                var problemRow =
                    context.FAILURELISTs.FirstOrDefault(
                        f =>
                            f.FAILURECODE == problem && f.TYPE == "PROBLEM" && f.PARENT == parent.FAILURELIST_ &&
                            f.ORGID == orgid);
                if (problemRow == null)
                    return null;


                var causeRow =
                    context.FAILURELISTs.FirstOrDefault(
                        f =>
                            f.FAILURECODE == cause && f.TYPE == "CAUSE" && f.PARENT == problemRow.FAILURELIST_ &&
                            f.ORGID == orgid);
                if (causeRow == null)
                    return null;

                return causeRow.FAILURELIST_;
            }

            return null;
        }

        public long? GetFailureListLineNumber(string orgid, string failureCode, string problem, string cause, string remedy)
        {
            using (var context = new MxLocalReferenceDataContext())
            {
                var parent =
                    context.FAILURELISTs.FirstOrDefault(
                        f => f.FAILURECODE == failureCode && f.ORGID == orgid && f.PARENT == null);
                if (parent == null)
                    return null;

                var problemRow =
                    context.FAILURELISTs.FirstOrDefault(
                        f =>
                            f.FAILURECODE == problem && f.TYPE == "PROBLEM" && f.PARENT == parent.FAILURELIST_ &&
                            f.ORGID == orgid);
                if (problemRow == null)
                    return null;


                var causeRow =
                    context.FAILURELISTs.FirstOrDefault(
                        f =>
                            f.FAILURECODE == cause && f.TYPE == "CAUSE" && f.PARENT == problemRow.FAILURELIST_ &&
                            f.ORGID == orgid);
                if (causeRow == null)
                    return null;

                var remedyRow =
                    context.FAILURELISTs.FirstOrDefault(
                        f =>
                            f.FAILURECODE == remedy && f.TYPE == "REMEDY" && f.PARENT == causeRow.FAILURELIST_ &&
                            f.ORGID == orgid);
                if (remedyRow == null)
                    return null;
                return remedyRow.FAILURELIST_;
            }
            return null;
        }

        public List<CLASSSPEC> GetClassSpecs(string classStructureId)
        {
            List<CLASSSPEC> result = null;
            using (var context = new MxLocalReferenceDataContext())
            {
                var classSpecValues = context.CLASSSPECs.Where(c => c.CLASSSTRUCTUREID == classStructureId);
                if (!classSpecValues.Any())
                    return null;
                result = classSpecValues.ToList();
            }
            return result;
        }

        public CREWINFO GetCrewInfo(string loginId, string laborFilter)
        {
            CREWINFO crewInfo;
            if (loginId == null)
                return GetCrewInfo();
            else
            {
                crewInfo = new CREWINFO();
                crewInfo.LOGINID = loginId;
                //crewInfo.LOGINPERSONID = _maximoService.GetLoginPersonId();
                crewInfo.LOGINPERSONID = "hlegesse";
                if (crewInfo.LOGINPERSONID == null)
                {
                    crewInfo = null;
                    goto Reset;
                }
                crewInfo.CREWID = _maximoService.GetCrewId(crewInfo.LOGINPERSONID, laborFilter);

                if (crewInfo.CREWID == null)
                {
                    crewInfo = null;
                    goto Reset;
                }

                crewInfo.VEHICLEID = _maximoService.GetVehicleId(crewInfo.CREWID);

                var crewMembers = _maximoService.GetCrewMembers(crewInfo.CREWID);
                if (crewMembers.Length > 1)
                {
                    if (!String.IsNullOrEmpty(crewMembers[0]))
                    {
                        var leadMan = _maximoService.GetPerson(crewMembers[0]);
                        crewInfo.LEADMAN = (leadMan != null) ? leadMan.PERSONID : null;
                    }

                    if (crewMembers.Length > 1 && !String.IsNullOrEmpty(crewMembers[1]))
                    {
                        var secondMan = _maximoService.GetPerson(crewMembers[1]);
                        crewInfo.SECONDMAN = (secondMan != null) ? secondMan.PERSONID : null;
                    }

                    if (crewMembers.Length > 2 && !String.IsNullOrEmpty(crewMembers[2]))
                    {
                        var driver = _maximoService.GetPerson(crewMembers[2]);
                        crewInfo.DRIVERID = (driver != null) ? driver.PERSONID : null; 
                    }
                }
                SetCrewInfo(crewInfo);
                return crewInfo;
            }
            Reset:
                SetCrewInfo(crewInfo);
            return crewInfo;
        }
        public CREWINFO GetCrewInfo()
        {
            using (var context = new MxLocalReferenceDataContext())
            {
                return context.CREWINFOs.FirstOrDefault();
            }
        }

        public bool SetCrewInfo(CREWINFO crewInfo)
        {
            using (var context = new MxLocalReferenceDataContext())
            {
                try
                {
                    var curRow = context.CREWINFOs.FirstOrDefault();
                    if (curRow != null)
                        context.CREWINFOs.Remove(curRow);
                    if (crewInfo != null)
                        context.CREWINFOs.Add(crewInfo);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    DumpValidationErrors(e);
                    throw;
                }
                return true;
            }
            return false;
        }

        public PERSON GetPerson(string personId)
        {
            using (var context = new MxLocalReferenceDataContext())
            {
                return context.PERSONs.FirstOrDefault(p => p.PERSONID == personId);
            }

        }

        public void ReInitializeWorkData()
        {
            Log.Write(LogLevel.Info, "ReInitializeWorkData for new login");
            using (var context = new MxLocalCacheContext())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Database.ExecuteSqlCommand("DELETE FROM ASSET");
                        context.Database.ExecuteSqlCommand("DELETE FROM ASSETSPEC");
                        context.Database.ExecuteSqlCommand("DELETE FROM LOCATIONS");
                        context.Database.ExecuteSqlCommand("DELETE FROM WORKORDER");
                        context.Database.ExecuteSqlCommand("DELETE FROM WORKORDERSPEC");
                        context.Database.ExecuteSqlCommand("DELETE FROM LABTRANS");
                        context.Database.ExecuteSqlCommand("DELETE FROM TOOLTRANS");
                        context.Database.ExecuteSqlCommand("DELETE FROM DOCLINKS");
                        context.Database.ExecuteSqlCommand("DELETE FROM DOCINFO");
                        context.Database.ExecuteSqlCommand("DELETE FROM WORKLOG");
                        context.Database.ExecuteSqlCommand("DELETE FROM WOSTATUS");
                        context.Database.ExecuteSqlCommand("DELETE FROM FAILUREREMARK");
                        context.Database.ExecuteSqlCommand("DELETE FROM FAILUREREPORT");
                        tx.Commit();
                    }
                    catch (Exception)
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
        //TODO: Fix to use maxinfo/database data.

        public void UploadWorkData(Dictionary<string, MobileTypeAttributeMap> workAttributeMap)
        {
            using (MxLocalCacheContext mxLocalCacheContext = new MxLocalCacheContext())
            {
                var updatedWos = (from wo in mxLocalCacheContext.WORKORDERs
                                  where wo.C_record_state_ == (long) LocalState.Modified 
                                  select wo);
                if (!updatedWos.Any())
                    return;
                var woList = updatedWos
                    .Include("WorkorderSpecs")
                    .Include("Asset")
                    .Include("Asset.AssetSpecs")
                    .Include("FailureRemark")
                    .Include("FailureReports")
                    .Include("LabTrans")
                    .Include("ToolTrans")
                    .Include("WoStatuses")
                    .Include("DocLinks")
                    .Include("DocLinks.DocInfo").ToList();
                 foreach (var updatedWo in woList)
                {
                    var map = workAttributeMap[updatedWo.C_mobile_work_type_];
                    var compositeWorkorder = new CompositeWorkorder();
                    var classSpec = updatedWo.CLASSSTRUCTUREID;
                    List<AssetSpecType> specAttributesDef = (from a in mxLocalCacheContext.ASSETATTRIBUTEs
                                                          join cs in mxLocalCacheContext.CLASSSPECs
                                                          on a.ASSETATTRID equals cs.ASSETATTRID
                                                          where cs.CLASSSTRUCTUREID == classSpec
                                                          select new AssetSpecType { ASSETATTRID = cs.ASSETATTRID, DATATYPE = a.DATATYPE }).ToList();

                    compositeWorkorder.WORKORDER = new WORKORDERMbo();
                    if (updatedWo.WorkorderSpecs != null && updatedWo.WorkorderSpecs.Count > 0)
                    {
                        compositeWorkorder.WORKORDERSPEC = new WORKORDERSPECMboSetWORKORDERSPEC[updatedWo.WorkorderSpecs.Count];
                        for (int i = 0; i < specAttributesDef.Count; i++)
                        {
                            compositeWorkorder.WORKORDERSPEC[i] = new WORKORDERSPECMboSetWORKORDERSPEC();
                        }
                    }
                    var changedSpecs = new List<string>();
                    foreach (var specAttribute in map.SpecAttributes)
                    {
                        var spec = updatedWo.WorkorderSpecs.FirstOrDefault(s => s.ASSETATTRID == specAttribute);
                        if (spec != null && spec.C_record_state_ != (long)LocalState.Original)
                            changedSpecs.Add(specAttribute);
                    }

                    if (updatedWo.Doclinks != null )
                    {
                        var docLinks =
                            updatedWo.Doclinks.Where(d => d.C_record_state_ == (long) LocalState.Added).ToList();
                        if (docLinks.Count > 0)
                        {
                            compositeWorkorder.DOCLINKS = new DOCLINKSMboSetDOCLINKS[docLinks.Count];
                            compositeWorkorder.DOCINFO = new DOCINFOMboSetDOCINFO[docLinks.Count];
                            for (int i = 0; i < docLinks.Count; i++)
                            {
                                compositeWorkorder.DOCLINKS[i] = new DOCLINKSMboSetDOCLINKS();
                                compositeWorkorder.DOCINFO[i] = new DOCINFOMboSetDOCINFO();

                            }
                        }
                    }
                    if (updatedWo.LabTrans != null )
                    {
                        var labTrans =
                            updatedWo.LabTrans.Where(l => l.C_record_state_ == (long) LocalState.Added).ToList();
                        if (labTrans.Count > 0)
                        {
                            compositeWorkorder.LABTRANS = new LABTRANSMboSetLABTRANS[updatedWo.LabTrans.Count];
                            for (int i = 0; i < updatedWo.LabTrans.Count; i++)
                            {
                                compositeWorkorder.LABTRANS[i] = new LABTRANSMboSetLABTRANS();
                            }
                        }
                    }
                    if (updatedWo.ToolTrans != null && updatedWo.ToolTrans.Count > 0)
                    {
                        var toolTrans =
                            updatedWo.ToolTrans.Where(t => t.C_record_state_ == (long) LocalState.Added).ToList();
                        if (toolTrans.Count > 0)
                        {
                            compositeWorkorder.TOOLTRANS = new TOOLTRANSMboSetTOOLTRANS[updatedWo.ToolTrans.Count];
                            for (int i = 0; i < updatedWo.ToolTrans.Count; i++)
                            {
                                compositeWorkorder.TOOLTRANS[i] = new TOOLTRANSMboSetTOOLTRANS();
                            }
                        }
                    }
                    if (updatedWo.WoStatuses != null)
                    {
                        var woStatuses =
                            updatedWo.WoStatuses.Where(s => s.C_record_state_ != (long) LocalState.Original).ToList();
                        if (woStatuses.Count > 0)
                        {
                            compositeWorkorder.WOSTATUS = new WOSTATUSMboSetWOSTATUS[woStatuses.Count];
                            for (int i = 0; i < woStatuses.Count; i++)
                            {
                                compositeWorkorder.WOSTATUS[i] = new WOSTATUSMboSetWOSTATUS();
                            }
                        }
                    }
                    if (updatedWo.FailureRemark != null && updatedWo.FailureRemark.C_record_state_ != (long) LocalState.Original)
                    {
                        compositeWorkorder.FAILUREREMARK = new FAILUREREMARKMboSetFAILUREREMARK[1];
                        compositeWorkorder.FAILUREREMARK[0] = new FAILUREREMARKMboSetFAILUREREMARK();
                    }
                    bool problemChanged = false;
                    if (updatedWo.FailureReports != null && updatedWo.FailureReports.Count > 0)
                    {
                        compositeWorkorder.FAILUREREPORT = new FAILUREREPORTMboSetFAILUREREPORT[updatedWo.FailureReports.Count];
                        for (int i = 0; i < updatedWo.FailureReports.Count; i++)
                        {
                            compositeWorkorder.FAILUREREPORT[i] = new FAILUREREPORTMboSetFAILUREREPORT();
                        }
                        var problem = updatedWo.FailureReports.FirstOrDefault(fr => fr.TYPE == "PROBLEM");
                        if (problem == null)
                            throw new ApplicationException("Problem Not found");
                        if (problem.C_record_state_ != (long) LocalState.Original)
                            problemChanged = true;
                    }

                    ReverseMapper.PopulateWorkorder(compositeWorkorder, updatedWo);
                    if (compositeWorkorder.DOCLINKS != null)
                    {
                        foreach (var doclinks in compositeWorkorder.DOCLINKS)
                        {
                            doclinks.DOCUMENTDATA = DocumentUpload(doclinks.URLNAME);
                        }
                    }

                    try
                    {
                        _maximoService.UpdateWorkorder(compositeWorkorder, map.Attributes, changedSpecs,
                            specAttributesDef, problemChanged);
                        updatedWo.C_record_state_ = (long) LocalState.Original;
                        foreach (var woSpec in updatedWo.WorkorderSpecs)
                        {
                            woSpec.C_record_state_ = (long) LocalState.Original;
                        }
                        foreach (var woStatus in updatedWo.WoStatuses)
                        {
                            woStatus.C_record_state_ = (long) LocalState.Original;
                        }
                        foreach (var failureReport in updatedWo.FailureReports)
                        {
                            failureReport.C_record_state_ = (long) LocalState.Original;
                        }
                        foreach (var doclink in updatedWo.Doclinks)
                        {
                            doclink.C_record_state_ = (long) LocalState.Original;
                            doclink.DocInfo.C_record_state_ = (long) LocalState.Original;
                        }
                        foreach (var labTran in updatedWo.LabTrans)
                        {
                            labTran.C_record_state_ = (long) LocalState.Original;
                        }
                        foreach (var toolTran in updatedWo.ToolTrans)
                        {
                            toolTran.C_record_state_ = (long) LocalState.Original;
                        }

                        if (updatedWo.FailureRemark != null)
                            updatedWo.FailureRemark.C_record_state_ = (long) LocalState.Original;
                        mxLocalCacheContext.SaveChanges();

                    }
                    catch (DbEntityValidationException e)
                    {
                        DumpValidationErrors(e);
                        throw new ApplicationException("Failed to reset local row status");
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }

            }
        }

        public void UploadNewWorkData(Dictionary<string, MobileTypeAttributeMap> workAttributeMap)
        {
            using (MxLocalCacheContext mxLocalCacheContext = new MxLocalCacheContext())
            {
                var addedWos = (from wo in mxLocalCacheContext.WORKORDERs
                                  where wo.C_record_state_ == (long)LocalState.Added
                                  orderby wo.C_WORKORDERID_LOCAL_
                                  select wo);
                if (!addedWos.Any())
                    return;
                var woList = addedWos
                    .Include("WorkorderSpecs")
                    .Include("Asset")
                    .Include("Asset.AssetSpecs")
                    .Include("FailureRemark")
                    .Include("FailureReports")
                    .Include("LabTrans")
                    .Include("ToolTrans")
                    .Include("WoStatuses")
                    .Include("DocLinks")
                    .Include("DocLinks.DocInfo").ToList();
                foreach (var addedWo in woList)
                {
                    var map = workAttributeMap[addedWo.C_mobile_work_type_];
                    var compositeWorkorder = new CompositeWorkorder();
                    var classSpec = addedWo.CLASSSTRUCTUREID;
                    List<AssetSpecType> specAttributesDef = (from a in mxLocalCacheContext.ASSETATTRIBUTEs
                                                             join cs in mxLocalCacheContext.CLASSSPECs
                                                             on a.ASSETATTRID equals cs.ASSETATTRID
                                                             where cs.CLASSSTRUCTUREID == classSpec
                                                             select new AssetSpecType { ASSETATTRID = cs.ASSETATTRID, DATATYPE = a.DATATYPE }).ToList();

                    compositeWorkorder.WORKORDER = new WORKORDERMbo();
                    if (addedWo.WorkorderSpecs != null && addedWo.WorkorderSpecs.Count > 0)
                    {
                        compositeWorkorder.WORKORDERSPEC = new WORKORDERSPECMboSetWORKORDERSPEC[addedWo.WorkorderSpecs.Count];
                        for (int i = 0; i < specAttributesDef.Count; i++)
                        {
                            compositeWorkorder.WORKORDERSPEC[i] = new WORKORDERSPECMboSetWORKORDERSPEC();
                        }
                    }
                    var changedSpecs = new List<string>();
                    foreach (var specAttribute in map.SpecAttributes)
                    {
                        var spec = addedWo.WorkorderSpecs.FirstOrDefault(s => s.ASSETATTRID == specAttribute);
                        if (spec != null && spec.C_record_state_ != (long)LocalState.Original)
                            changedSpecs.Add(specAttribute);
                    }

                    if (addedWo.Doclinks != null)
                    {
                        var docLinks =
                            addedWo.Doclinks.Where(d => d.C_record_state_ == (long)LocalState.Added).ToList();
                        if (docLinks.Count > 0)
                        {
                            compositeWorkorder.DOCLINKS = new DOCLINKSMboSetDOCLINKS[docLinks.Count];
                            compositeWorkorder.DOCINFO = new DOCINFOMboSetDOCINFO[docLinks.Count];
                            for (int i = 0; i < docLinks.Count; i++)
                            {
                                compositeWorkorder.DOCLINKS[i] = new DOCLINKSMboSetDOCLINKS();
                                compositeWorkorder.DOCINFO[i] = new DOCINFOMboSetDOCINFO();

                            }
                        }
                    }
                    if (addedWo.LabTrans != null)
                    {
                        var labTrans =
                            addedWo.LabTrans.Where(l => l.C_record_state_ == (long)LocalState.Added).ToList();
                        if (labTrans.Count > 0)
                        {
                            compositeWorkorder.LABTRANS = new LABTRANSMboSetLABTRANS[addedWo.LabTrans.Count];
                            for (int i = 0; i < addedWo.LabTrans.Count; i++)
                            {
                                compositeWorkorder.LABTRANS[i] = new LABTRANSMboSetLABTRANS();
                            }
                        }
                    }
                    if (addedWo.ToolTrans != null && addedWo.ToolTrans.Count > 0)
                    {
                        var toolTrans =
                            addedWo.ToolTrans.Where(t => t.C_record_state_ == (long)LocalState.Added).ToList();
                        if (toolTrans.Count > 0)
                        {
                            compositeWorkorder.TOOLTRANS = new TOOLTRANSMboSetTOOLTRANS[addedWo.ToolTrans.Count];
                            for (int i = 0; i < addedWo.ToolTrans.Count; i++)
                            {
                                compositeWorkorder.TOOLTRANS[i] = new TOOLTRANSMboSetTOOLTRANS();
                            }
                        }
                    }
                    if (addedWo.WoStatuses != null)
                    {
                        var woStatuses =
                            addedWo.WoStatuses.Where(s => s.C_record_state_ != (long)LocalState.Original).ToList();
                        if (woStatuses.Count > 0)
                        {
                            compositeWorkorder.WOSTATUS = new WOSTATUSMboSetWOSTATUS[woStatuses.Count];
                            for (int i = 0; i < woStatuses.Count; i++)
                            {
                                compositeWorkorder.WOSTATUS[i] = new WOSTATUSMboSetWOSTATUS();
                            }
                        }
                    }
                    if (addedWo.FailureRemark != null && addedWo.FailureRemark.C_record_state_ != (long)LocalState.Original)
                    {
                        compositeWorkorder.FAILUREREMARK = new FAILUREREMARKMboSetFAILUREREMARK[1];
                        compositeWorkorder.FAILUREREMARK[0] = new FAILUREREMARKMboSetFAILUREREMARK();
                    }
                    bool problemChanged = false;
                    if (addedWo.FailureReports != null && addedWo.FailureReports.Count > 0)
                    {
                        compositeWorkorder.FAILUREREPORT = new FAILUREREPORTMboSetFAILUREREPORT[addedWo.FailureReports.Count];
                        for (int i = 0; i < addedWo.FailureReports.Count; i++)
                        {
                            compositeWorkorder.FAILUREREPORT[i] = new FAILUREREPORTMboSetFAILUREREPORT();
                        }
                        var problem = addedWo.FailureReports.FirstOrDefault(fr => fr.TYPE == "PROBLEM");
                        if (problem == null)
                            throw new ApplicationException("Problem Not found");
                        if (problem.C_record_state_ != (long)LocalState.Original)
                            problemChanged = true;
                    }

                    ReverseMapper.PopulateWorkorder(compositeWorkorder, addedWo);
                    if (addedWo.C_ORIGRECORDID_LOCAL_.HasValue &&
                        String.IsNullOrEmpty(compositeWorkorder.WORKORDER.ORIGRECORDID))
                    {
                        var wo = GetWorkorder(addedWo.C_ORIGRECORDID_LOCAL_.Value);
                        if (wo != null)
                        {
                            compositeWorkorder.WORKORDER.ORIGRECORDID = wo.WONUM;
                            compositeWorkorder.WORKORDER.ORIGRECORDCLASS = "WORKORDER";
                        }
 
                    }

                    if (compositeWorkorder.DOCLINKS != null)
                    {
                        foreach (var doclinks in compositeWorkorder.DOCLINKS)
                        {
                            doclinks.DOCUMENTDATA = DocumentUpload(doclinks.URLNAME);
                        }
                    }

                    try
                    {
                        var wonum = _maximoService.CreateWorkorder(compositeWorkorder, map.Attributes, changedSpecs,
                            specAttributesDef);
                        addedWo.WONUM = wonum;
                        addedWo.WORKORDERID = compositeWorkorder.WORKORDER.WORKORDERID;

                        addedWo.C_record_state_ = (long)LocalState.Original;
                        foreach (var woSpec in addedWo.WorkorderSpecs)
                        {
                            woSpec.C_record_state_ = (long)LocalState.Original;
                        }
                        foreach (var woStatus in addedWo.WoStatuses)
                        {
                            woStatus.C_record_state_ = (long)LocalState.Original;
                        }
                        foreach (var failureReport in addedWo.FailureReports)
                        {
                            failureReport.C_record_state_ = (long)LocalState.Original;
                        }
                        foreach (var doclink in addedWo.Doclinks)
                        {
                            doclink.C_record_state_ = (long)LocalState.Original;
                            doclink.DocInfo.C_record_state_ = (long)LocalState.Original;
                        }
                        foreach (var labTran in addedWo.LabTrans)
                        {
                            labTran.C_record_state_ = (long)LocalState.Original;
                        }
                        foreach (var toolTran in addedWo.ToolTrans)
                        {
                            toolTran.C_record_state_ = (long)LocalState.Original;
                        }

                        if (addedWo.FailureRemark != null)
                            addedWo.FailureRemark.C_record_state_ = (long)LocalState.Original;
                        mxLocalCacheContext.SaveChanges();

                    }
                    catch (DbEntityValidationException e)
                    {
                        DumpValidationErrors(e);
                        throw new ApplicationException("Failed to reset local row status");
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }

            }
        }


        public void UploadAsset(Dictionary<string, MobileTypeAttributeMap> assetAttributeMap )
        {
            using (MxLocalCacheContext mxLocalCacheContext = new MxLocalCacheContext())
            {
                var newAsset = (from a in mxLocalCacheContext.ASSETs
                                where a.C_record_state_ == (long)LocalState.Modified
                                select a);
                var assetList = newAsset.Include("AssetSpecs").ToList();
                foreach (var asset in assetList)
                {
                    var classSpec = asset.CLASSSTRUCTUREID;
                    List<AssetSpecType> specAttributesDef = (from a in mxLocalCacheContext.ASSETATTRIBUTEs
                                                          join cs in mxLocalCacheContext.CLASSSPECs
                                                          on a.ASSETATTRID equals cs.ASSETATTRID
                                                          where cs.CLASSSTRUCTUREID == classSpec
                                                          select new AssetSpecType { ASSETATTRID = cs.ASSETATTRID, DATATYPE = a.DATATYPE }).ToList();
                    var map = assetAttributeMap[asset.C_mobile_asset_type_];

                    var compositeAsset = new CompositeAsset();
                    compositeAsset.ASSET = new ASSETMbo();
                    if (specAttributesDef.Count > 0)
                    {
                        compositeAsset.ASSETSPEC = new ASSETSPECMboSetASSETSPEC[specAttributesDef.Count];
                        for (int i = 0; i < specAttributesDef.Count; i++)
                        {
                         compositeAsset.ASSETSPEC[i] = new ASSETSPECMboSetASSETSPEC();
                        }
                    }
                    var changedSpecs = new List<string>();
                    foreach (var specAttribute in map.SpecAttributes)
                    {
                        var spec = asset.AssetSpecs.FirstOrDefault(s => s.ASSETATTRID == specAttribute);
                        if (spec != null && spec.C_record_state_ != (long) LocalState.Original)
                            changedSpecs.Add(specAttribute);
                    }
                    ReverseMapper.PopulateAsset(compositeAsset, asset);
                    try
                    {
                        _maximoService.UpdateAsset(compositeAsset, map.Attributes, changedSpecs, specAttributesDef);
                        asset.C_record_state_ = (long) LocalState.Original;
                        foreach (var assetSpec in asset.AssetSpecs)
                        {
                            assetSpec.C_record_state_ = (long) LocalState.Original;
                        }
                        mxLocalCacheContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }

                }
            }
        }

        public void UploadNewAsset(Dictionary<string, MobileTypeAttributeMap> assetAttributeMap)
        {
            using (MxLocalCacheContext mxLocalCacheContext = new MxLocalCacheContext())
            {
                var newAsset = (from a in mxLocalCacheContext.ASSETs
                                     where a.C_record_state_ == (long)LocalState.Added 
                                     select a);
                var assetList = newAsset.Include("AssetSpecs").ToList();
                foreach (var asset in assetList)
                {
                    var classSpec = asset.CLASSSTRUCTUREID;
                    List<AssetSpecType> specAttributes = (from a in mxLocalCacheContext.ASSETATTRIBUTEs
                                    join cs in mxLocalCacheContext.CLASSSPECs
                                    on a.ASSETATTRID equals cs.ASSETATTRID 
                                    where cs.CLASSSTRUCTUREID == classSpec
                                    select new AssetSpecType{ASSETATTRID = cs.ASSETATTRID,DATATYPE = a.DATATYPE}).ToList();
                    var map = assetAttributeMap[asset.C_mobile_asset_type_];
                    var compositeAsset = new CompositeAsset();
                    compositeAsset.ASSET = new ASSETMbo();
                    if (specAttributes.Count > 0)
                    {
                        compositeAsset.ASSETSPEC = new ASSETSPECMboSetASSETSPEC[specAttributes.Count];
                        for (int i = 0; i < specAttributes.Count; i++)
                        {
                            compositeAsset.ASSETSPEC[i] = new ASSETSPECMboSetASSETSPEC();
                        }
                    }
                    ReverseMapper.PopulateAsset(compositeAsset, asset);

                    try
                    {
                        var newCompositeAsset = _maximoService.CreateAsset(compositeAsset, map.Attributes, map.SpecAttributes, specAttributes);

                        asset.ASSETNUM = newCompositeAsset.ASSET.ASSETNUM;
                        asset.ASSETID = newCompositeAsset.ASSET.ASSETID;
                        asset.ASSETUID = newCompositeAsset.ASSET.ASSETUID;
                        asset.C_record_state_ = (long)LocalState.Original;
                        foreach (var assetSpec in asset.AssetSpecs)
                        {
                            assetSpec.ASSETNUM = asset.ASSETNUM;
                            assetSpec.C_record_state_ = (long)LocalState.Original;
                        }
                        mxLocalCacheContext.SaveChanges();
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
              
            }
        }

        public void CopyReferenceData()
        {
            using (var updater = new MaximoReferenceDataUpdater())
            {
                try
                {
                    updater.Execute();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
            
        }

        public void DownloadReferenceData()
        {
            using (MxLocalCacheContext mxLocalCacheContext = new MxLocalCacheContext())
            {
                using (var tx = mxLocalCacheContext.Database.BeginTransaction())
                {
                    try
                    {
                        Messenger.Default.Send(new NotificationMessage("Downloading MaxDomain"));
                        DownloadMaxDomain(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading AlnDomain"));
                        DownloadAlnDomain(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading SynonymDomain"));
                        DownloadSynonymDomain(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading DocTypes"));
                        DownloadDocTypes(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading LaborCraftRate"));
                        DownloadLaborCraftRate(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading Person"));
                        DownloadPerson(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading PersonGroup"));
                        DownloadPersonGroup(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading PersonGroupTeam"));
                        DownloadPersonGroupTeam(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading FailureList"));
                        //DownloadFailureList(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading FailureCode"));
                        DownloadFailureCode(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading WorkType"));
                        DownloadWorkType(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading AssetAttribute"));
                        DownloadAssetAttribute(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading ClassSpec"));
                        DownloadClassSpec(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Downloading TruckInventory"));
                        DownloadTruckInventory(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Maximo Reference Data Downloaded"));
                        tx.Commit();
                    }
                    catch (Exception)
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }

        }

        public void DownloadWorkData(string workFilter)
        {
            _workFilter = workFilter;
            using (MxLocalCacheContext mxLocalCacheContext = new MxLocalCacheContext())
            {
#if false
                mxLocalCacheContext.Database.Log = Console.Write;
#endif
                using (var tx = mxLocalCacheContext.Database.BeginTransaction())
                {
                    try
                    {
                        Messenger.Default.Send(new NotificationMessage("Downloading Workorders"));
                        DownloadWorkorders(mxLocalCacheContext);
                        Messenger.Default.Send(new NotificationMessage("Workorders downloaded"));
                        tx.Commit();
                    }
                    catch (Exception)
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        private CompositeWorkorderSet DownloadWorkorders()
        {
            Log.Write(LogLevel.Info, "Fetching Data From Maximo...");
            Messenger.Default.Send(new NotificationMessage("Fetching Data From Maximo..."));
            try
            {
                var query = new List<QueryParameter>();
                
                if(!String.IsNullOrEmpty(_workFilter))
                    query.Add(new QueryParameter { Name = "_uw", Value = _workFilter });
                Log.Write(LogLevel.Info, string.Format("Maximo Work Filter: |{0}|",_workFilter));
                CompositeWorkorderSet compositeWorkorderSet = _maximoService.GetCompositeWorkorderSet(query);

                if (compositeWorkorderSet.CompositeWorkorders == null)
                {
                    Log.Write(LogLevel.Debug, "compositeWorkorderSet.CompositeWorkorders is null"); 
                    return null;
                }
                return compositeWorkorderSet;
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }

        private void DownloadWorkorders(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                //Get the list of WOs
                CompositeWorkorderSet compositeWorkorderSet = DownloadWorkorders();
                if (compositeWorkorderSet == null)
                    return;
                if (compositeWorkorderSet.CompositeWorkorders == null)
                    return;
                Messenger.Default.Send(new NotificationMessage("Saving Locally..."));

                //Delete Wos that are not there anymore
                var localWos = from w in mxLocalCacheContext.WORKORDERs
                               select w ;
                foreach (var localWo in localWos.ToList())
                {
                    var wonum = localWo.WONUM;
                    var inDownload = (from w in compositeWorkorderSet.CompositeWorkorders
                                      where w.WORKORDER.WONUM == wonum
                                        select w).FirstOrDefault();
                    if (inDownload == null)
                    {
                        mxLocalCacheContext.Entry(localWo).Collection(t =>t.Doclinks).Load();
                        mxLocalCacheContext.Entry(localWo).Collection(t => t.LabTrans).Load();
                        mxLocalCacheContext.Entry(localWo).Collection(t => t.ToolTrans).Load();
                        mxLocalCacheContext.Entry(localWo).Collection(t => t.WorkorderSpecs).Load();
                        mxLocalCacheContext.Entry(localWo).Collection(t => t.FailureReports).Load();
                        mxLocalCacheContext.Entry(localWo).Collection(t => t.WoStatuses).Load();

                        if (localWo.Doclinks.Count > 0)
                        {
                            var docInfos = new List<DOCINFO>();

                            foreach (var doclink in localWo.Doclinks)
                            {
                                docInfos.Add(doclink.DocInfo);
                            }
                            mxLocalCacheContext.DOCLINKS.RemoveRange(localWo.Doclinks);
                            mxLocalCacheContext.DOCINFOes.RemoveRange(docInfos);
                        }
                        mxLocalCacheContext.LABTRANS.RemoveRange(localWo.LabTrans);
                        mxLocalCacheContext.TOOLTRANS.RemoveRange(localWo.ToolTrans);
                        mxLocalCacheContext.WORKORDERSPECs.RemoveRange(localWo.WorkorderSpecs);
                        if (localWo.FailureRemark != null)
                            mxLocalCacheContext.FAILUREREMARKs.Remove(localWo.FailureRemark);
                        mxLocalCacheContext.FAILUREREPORTs.RemoveRange(localWo.FailureReports);
                        mxLocalCacheContext.WOSTATUSes.RemoveRange(localWo.WoStatuses);
                        mxLocalCacheContext.WORKORDERs.Remove(localWo);
                    }

                }

                //Save the rest.
                foreach (var compositeWorkorder in compositeWorkorderSet.CompositeWorkorders)
                {
                    var workorderSrc = compositeWorkorder.WORKORDER;
                    Log.Write(LogLevel.Info, string.Format("Saving locally {0}", compositeWorkorder.WORKORDER.WONUM));

                    var workorder = mxLocalCacheContext.WORKORDERs.FirstOrDefault(w => w.WONUM == workorderSrc.WONUM);
                    //add new.
                    if (workorder == null)
                    {
                        WorkorderAdd(mxLocalCacheContext, compositeWorkorder);
                    }
                    else
                    {
                        //update existing
                        if (Comparer.IsDirty(workorder))
                        {
                            throw new ApplicationException("Workorder has local updates" + workorder.WONUM);
                        }

                        //Location Updated?
                        if (Comparer.NeedsUpdate(workorder.LOCATION, compositeWorkorder.LOCATIONS))
                        {
                            if (!((compositeWorkorder.LOCATIONS == null) || (compositeWorkorder.LOCATIONS[0] == null) ||
                                  string.IsNullOrEmpty(compositeWorkorder.LOCATIONS[0].LOCATION)))
                            {
                                var downloadedLocation = compositeWorkorder.LOCATIONS[0].LOCATION;
                                var location = (from l in mxLocalCacheContext.LOCATIONS
                                                where l.LOCATION_ == downloadedLocation
                                                select l).FirstOrDefault();
                                if (location == null)
                                    LocationAdd(mxLocalCacheContext, compositeWorkorder.LOCATIONS[0]);
                                else
                                {
                                    if (Comparer.NeedsUpdate(location, compositeWorkorder.LOCATIONS))
                                        LocationUpdate(mxLocalCacheContext, location, compositeWorkorder.LOCATIONS[0]);
                                }
                            }
                        }

                        var asset = workorder.Asset;
                        if (Comparer.IsDirty(asset))
                        {
                            throw new ApplicationException("Asset has local updates" + workorder.ASSETNUM);
                        }
                        //Asset Updated?
                        if (Comparer.NeedsUpdate(asset, compositeWorkorder.compositeAsset))
                        {
                            if (!string.IsNullOrEmpty(compositeWorkorder.WORKORDER.ASSETNUM))
                            {
                                    asset = (from a in mxLocalCacheContext.ASSETs
                                    where a.ASSETNUM == compositeWorkorder.WORKORDER.ASSETNUM
                                    select a).FirstOrDefault();

                                if (asset == null)
                                {
                                    asset = AssetAdd(mxLocalCacheContext, compositeWorkorder.compositeAsset);
                                }
                                else
                                {
                                    if (Comparer.NeedsUpdate(asset, compositeWorkorder.compositeAsset))
                                        AssetUpdate(mxLocalCacheContext, asset, compositeWorkorder.compositeAsset);
                                }
                            }
                        }
                        workorder.Asset = asset;

                        if (Comparer.NeedsUpdate(workorder, compositeWorkorder))
                        {
                            WorkorderUpdate(mxLocalCacheContext, workorder, compositeWorkorder);
                        }
                    }
                }

                mxLocalCacheContext.SaveChanges();

                //Cleanup Locations and Assets that are not associated with WOs anymore
                var orphanLocs = from l in mxLocalCacheContext.LOCATIONS
                    where !mxLocalCacheContext.WORKORDERs.Any(w => w.LOCATION == l.LOCATION_)
                    select l;
                if(orphanLocs.Any())
                  mxLocalCacheContext.LOCATIONS.RemoveRange(orphanLocs);

                var orphanAssets = from a in mxLocalCacheContext.ASSETs
                                where !mxLocalCacheContext.WORKORDERs.Any(w => w.ASSETNUM == a.ASSETNUM)
                                select a;

                foreach (var orphanAsset in orphanAssets.ToList())
                {
                    mxLocalCacheContext.ASSETSPECs.RemoveRange(orphanAsset.AssetSpecs);
                    mxLocalCacheContext.ASSETs.Remove(orphanAsset);
                }
                
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
        }

        public int HasPendingUpdates()
        {
            var db = new MxLocalCacheContext();
            var modifiedWos = (from w in db.WORKORDERs
                                where w.C_record_state_ != (long) LocalState.Original
                                select w).Count();
            
            var modifiedWoSpecs = (from w in db.WORKORDERSPECs
                                   where w.C_record_state_ != (long)LocalState.Original
                                   select w).Count();

            var modifiedWoStatuses = (from w in db.WOSTATUSes
                                   where w.C_record_state_ != (long)LocalState.Original
                                   select w).Count();

            var modifiedAsset = (from a in db.ASSETs
                                   where a.C_record_state_ != (long)LocalState.Original
                                   select a).Count();

            var modifiedAssetSpec = (from a in db.ASSETSPECs
                                     where a.C_record_state_ != (long)LocalState.Original
                                     select a).Count();

            var modifiedDocLinks = (from a in db.DOCLINKS
                                   where a.C_record_state_ != (long)LocalState.Original
                                   select a).Count();
            var modifiedLabTrans = (from a in db.LABTRANS
                                    where a.C_record_state_ != (long)LocalState.Original
                                    select a).Count();
            var modifiedToolTrans = (from a in db.TOOLTRANS
                                    where a.C_record_state_ != (long)LocalState.Original
                                    select a).Count();
            var modifiedFailureReports = (from a in db.FAILUREREPORTs
                                     where a.C_record_state_ != (long)LocalState.Original
                                     select a).Count();
            var modifiedFailureRemarks = (from a in db.FAILUREREMARKs
                                          where a.C_record_state_ != (long)LocalState.Original
                                          select a).Count();
            return modifiedWos + modifiedWoSpecs + modifiedWoStatuses + modifiedAsset + modifiedAssetSpec
                + modifiedDocLinks + modifiedLabTrans + modifiedToolTrans + modifiedFailureReports + modifiedFailureRemarks;
        }

        private ASSET AssetAdd(MxLocalCacheContext db, CompositeAsset compositeAsset)
        {
            var newAsset = new ASSET();
            Mapper.PopulateAsset(newAsset, compositeAsset);
            db.ASSETs.Add(newAsset);
            if (compositeAsset.ASSETSPEC != null)
            {
                foreach (var assetSpec in compositeAsset.ASSETSPEC)
                {
                    var newAssetSpec = new ASSETSPEC();
                    Mapper.PopulateAssetSpec(newAssetSpec, assetSpec);
                    db.ASSETSPECs.Add(newAssetSpec);
                }
            }
            return newAsset;

        }

        private ASSET AssetUpdate(MxLocalCacheContext db, ASSET curAsset, CompositeAsset compositeAsset)
        {
            Mapper.PopulateAsset(curAsset, compositeAsset);
            db.Entry(curAsset).State = EntityState.Modified;

            if ((curAsset.AssetSpecs != null) && (curAsset.AssetSpecs.Count > 0))
            {
                foreach (var localAssetSpec in curAsset.AssetSpecs.ToList())
                {
                    var assetAttrId = localAssetSpec.ASSETATTRID;
                    bool deleteAttr = true;
                    if ((compositeAsset.ASSETSPEC != null) && (compositeAsset.ASSETSPEC.Length > 0))
                    {
                        var downloadedAssetSpec = (from a in compositeAsset.ASSETSPEC
                                                    where a.ASSETATTRID == assetAttrId
                                                    select a).FirstOrDefault();
                        deleteAttr = downloadedAssetSpec == null;
                    }
                    if (deleteAttr) 
                        db.ASSETSPECs.Remove(localAssetSpec);
                }
            }

            if (compositeAsset.ASSETSPEC != null)
            {
                foreach (var assetSpec in compositeAsset.ASSETSPEC)
                {
                    var assetAttrId = assetSpec.ASSETATTRID;
                    var curAssetSpec = (from a in curAsset.AssetSpecs
                        where a.ASSETATTRID == assetAttrId
                        select a).FirstOrDefault();
                    if (curAssetSpec != null)
                    {
                        Mapper.PopulateAssetSpec(curAssetSpec, assetSpec);
                        db.Entry(curAssetSpec).State = EntityState.Modified;
                    }
                    else
                    {
                        var newAssetSpec = new ASSETSPEC();
                        Mapper.PopulateAssetSpec(newAssetSpec, assetSpec);
                        db.ASSETSPECs.Add(newAssetSpec);
                    }
                }
            }
            return curAsset;

        }
        private LOCATION LocationAdd(MxLocalCacheContext db, LOCATIONSMboSetLOCATIONS location)
        {
            var newLocation = new LOCATION();
            Mapper.PopulateLocation(newLocation, location);
            return db.LOCATIONS.Add(newLocation);
        }

        private LOCATION LocationUpdate(MxLocalCacheContext db, LOCATION curLocation, LOCATIONSMboSetLOCATIONS woLocation)
        {
            Mapper.PopulateLocation(curLocation, woLocation);
            db.Entry(curLocation).State = EntityState.Modified;
            return curLocation;
        }
        private void WorkorderUpdate(MxLocalCacheContext db, WORKORDER curWorkorder, CompositeWorkorder workorderSrc)
        {
            Mapper.PopulateWorkorder(curWorkorder, workorderSrc.WORKORDER);
            db.Entry(curWorkorder).State = EntityState.Modified;
            if (Comparer.NeedsUpdate(curWorkorder.WorkorderSpecs, workorderSrc.WORKORDERSPEC))
            {
                var deletedSpecs = from l in curWorkorder.WorkorderSpecs
                                   where !workorderSrc.WORKORDERSPEC.Any(d => d.WORKORDERSPECID == l.WORKORDERSPECID)
                                   select l;
                if (deletedSpecs.Any())
                    db.WORKORDERSPECs.RemoveRange(deletedSpecs);

                foreach (var downloadedWorkorderSpec in workorderSrc.WORKORDERSPEC)
                {
                    var localWorkorderSpec = (from w in curWorkorder.WorkorderSpecs
                        where w.WORKORDERSPECID == downloadedWorkorderSpec.WORKORDERSPECID
                        select w).FirstOrDefault();
                    if (localWorkorderSpec == null)
                    {
                        WorkorderSpecAdd(db, curWorkorder, downloadedWorkorderSpec);
                    }
                    else
                    {
                        Mapper.PopulateWorkorderSpec(localWorkorderSpec, downloadedWorkorderSpec);
                        db.Entry(localWorkorderSpec).State = EntityState.Modified;
                    }
                }
                
            }
            if (Comparer.NeedsUpdate(curWorkorder.WoStatuses, workorderSrc.WOSTATUS))
            {
                var deletedStatuses = from l in curWorkorder.WoStatuses
                                   where !workorderSrc.WOSTATUS.Any(d => d.WOSTATUSID == l.WOSTATUSID)
                                   select l;
                if (deletedStatuses.Any())
                    db.WOSTATUSes.RemoveRange(deletedStatuses);

                foreach (var downloadedWorkorderStatus in workorderSrc.WOSTATUS)
                {
                    var localWorkorderStatus = (from w in curWorkorder.WoStatuses
                                                where w.WOSTATUSID == downloadedWorkorderStatus.WOSTATUSID
                                                select w).FirstOrDefault();
                    if (localWorkorderStatus == null)
                    {
                        WorkorderStatusAdd(db, curWorkorder, downloadedWorkorderStatus);
                    }
                    else
                    {
                        Mapper.PopulateWoStatus(localWorkorderStatus, downloadedWorkorderStatus);
                        db.Entry(localWorkorderStatus).State = EntityState.Modified;
                    }
                }
            }
            
            if (Comparer.NeedsUpdate(curWorkorder.FailureRemark, workorderSrc.FAILUREREMARK))
            {
                if ((workorderSrc.FAILUREREMARK == null) || (workorderSrc.FAILUREREMARK.Length == 0))
                {
                    if (curWorkorder.FailureRemark != null)
                        db.FAILUREREMARKs.Remove(curWorkorder.FailureRemark);
                }
                else
                {
                    if (curWorkorder.FailureRemark == null)
                    {
                        WorkorderFailureRemarkAdd(db, curWorkorder, workorderSrc.FAILUREREMARK[0]);
                    }
                    else
                    {
                        Mapper.PopulateFailureRemark(curWorkorder.FailureRemark, workorderSrc.FAILUREREMARK[0]);
                        db.Entry(curWorkorder.FailureRemark).State = EntityState.Modified;
                    }
                }
            }

            if (Comparer.NeedsUpdate(curWorkorder.FailureReports, workorderSrc.FAILUREREPORT))
            {
                var deletedFailureReports = from l in curWorkorder.FailureReports
                                            where !workorderSrc.FAILUREREPORT.Any(d => d.FAILUREREPORTID == l.FAILUREREPORTID)
                                            select l;
                if (deletedFailureReports.Any())
                    db.FAILUREREPORTs.RemoveRange(deletedFailureReports);

                foreach (var downloadedFailureReport in workorderSrc.FAILUREREPORT)
                {
                    var localFailureReport = (from w in curWorkorder.FailureReports
                                               where w.FAILUREREPORTID == downloadedFailureReport.FAILUREREPORTID
                                               select w).FirstOrDefault();
                    if (localFailureReport == null)
                    {
                        WorkorderFailureReportAdd(db, curWorkorder, downloadedFailureReport);
                    }
                    else
                    {
                        Mapper.PopulateFailureReport(localFailureReport, downloadedFailureReport);
                        db.Entry(localFailureReport).State = EntityState.Modified;
                    }
                }

            }

            if (Comparer.NeedsUpdate(curWorkorder.Doclinks, workorderSrc.DOCLINKS, workorderSrc.DOCINFO))
            {
                var deletedDocLinks = from l in curWorkorder.Doclinks
                                      where !workorderSrc.DOCLINKS.Any(d => d.DOCLINKSID == l.DOCLINKSID)
                                      select l;
                if (deletedDocLinks.Any())
                {
                    foreach (var deletedDocLink in deletedDocLinks)
                    {
                        var docInfo = deletedDocLink.DocInfo;
                        db.DOCINFOes.Remove(docInfo);
                        db.DOCLINKS.Remove(deletedDocLink);
                    }
                }

                foreach (var downloadedDocLink in workorderSrc.DOCLINKS)
                {
                    var downloadedDocInfo = (from d in workorderSrc.DOCINFO
                                             where d.DOCINFOID == downloadedDocLink.DOCINFOID
                                             select d).FirstOrDefault();

                    var localDocLink = (from w in curWorkorder.Doclinks
                                        where w.DOCLINKSID == downloadedDocLink.DOCLINKSID
                                        select w).FirstOrDefault();

                    if (localDocLink == null)
                    {
                        WorkorderDocLinkAdd(db, curWorkorder, downloadedDocLink, downloadedDocInfo);
                    }
                    else
                    {
                        var localDocInfo = localDocLink.DocInfo;
                        Mapper.PopulateDocLink(localDocLink, downloadedDocLink);
                        Mapper.PopulateDocInfo(localDocInfo, downloadedDocInfo);
                        if (!string.IsNullOrEmpty(downloadedDocLink.DOCUMENTDATA))
                        {
                            DocumentSave(_attachmentPath, downloadedDocLink, downloadedDocInfo);
                        }

                        db.Entry(localDocLink).State = EntityState.Modified;
                        db.Entry(localDocInfo).State = EntityState.Modified;
                    }
                }

            }
            if (Comparer.NeedsUpdate(curWorkorder.LabTrans, workorderSrc.LABTRANS))
            {
                var deletedLabTrans = from l in curWorkorder.LabTrans
                                      where !workorderSrc.LABTRANS.Any(d => d.LABTRANSID == l.LABTRANSID)
                                      select l;
                if (deletedLabTrans.Any())
                    db.LABTRANS.RemoveRange(deletedLabTrans);

                foreach (var downloadedLabTran in workorderSrc.LABTRANS)
                {
                    var localLabTran = (from w in curWorkorder.LabTrans
                                        where w.LABTRANSID == downloadedLabTran.LABTRANSID
                                        select w).FirstOrDefault();
                    if (localLabTran == null)
                    {
                        WorkorderLabTranAdd(db, curWorkorder, downloadedLabTran);
                    }
                    else
                    {
                        Mapper.PopulateLabTran(localLabTran, downloadedLabTran);
                        db.Entry(localLabTran).State = EntityState.Modified;
                    }
                }

            }

            if (Comparer.NeedsUpdate(curWorkorder.ToolTrans, workorderSrc.TOOLTRANS))
            {
                var deletedToolTrans = from l in curWorkorder.ToolTrans
                                      where !workorderSrc.TOOLTRANS.Any(d => d.TOOLTRANSID == l.TOOLTRANSID)
                                      select l;
                if (deletedToolTrans.Any())
                    db.TOOLTRANS.RemoveRange(deletedToolTrans);

                foreach (var downloadedToolTran in workorderSrc.TOOLTRANS)
                {
                    var localToolTran = (from w in curWorkorder.ToolTrans
                                         where w.TOOLTRANSID == downloadedToolTran.TOOLTRANSID
                                        select w).FirstOrDefault();
                    if (localToolTran == null)
                    {
                        WorkorderToolTranAdd(db, curWorkorder, downloadedToolTran);
                    }
                    else
                    {
                        Mapper.PopulateToolTran(localToolTran, downloadedToolTran);
                        db.Entry(localToolTran).State = EntityState.Modified;
                    }
                }

            }

        }

        private WORKORDER WorkorderAdd(MxLocalCacheContext db, CompositeWorkorder workorderSrc)
        {
            var compositeAsset = workorderSrc.compositeAsset;
            
            ASSET asset = null;
            if (compositeAsset != null)
            {
                asset = db.ASSETs.FirstOrDefault(w => string.Equals(w.ASSETNUM, compositeAsset.ASSET.ASSETNUM));
                if (asset == null)
                {
                    asset = AssetAdd(db, compositeAsset);
                }
                else
                {
                    if (Comparer.IsDirty(asset))
                    {
                        //Record was modified locally...
                        throw new ApplicationException("Asset has local updates" + asset.ASSETTAG);
                    }
                    else
                    {
                        if (Comparer.NeedsUpdate(asset, compositeAsset))
                           AssetUpdate(db, asset, compositeAsset);
                    }
                }
                db.SaveChanges();
            }

            LOCATION location = null;
            if ((workorderSrc.LOCATIONS != null) && (workorderSrc.LOCATIONS.Length > 0))
            {
                var woLocation = workorderSrc.LOCATIONS[0];
                location = db.LOCATIONS.FirstOrDefault(l => l.LOCATION_ == woLocation.LOCATION);
                if (location == null)
                {
                    location = LocationAdd(db, woLocation);
                }
                else
                {
                    if (Comparer.NeedsUpdate(location, workorderSrc.LOCATIONS))
                    {
                        location = LocationUpdate(db, location, woLocation);
                    }
                }
                db.SaveChanges();
            }

            var workorder = new WORKORDER();
            try
            {
                Mapper.PopulateWorkorder(workorder, workorderSrc.WORKORDER);
                workorder.Asset = asset;
                WorkorderSpecsAdd(db, workorder, workorderSrc.WORKORDERSPEC);
                WorkorderLabTransAdd(db, workorder, workorderSrc.LABTRANS);
                WorkorderToolTransAdd(db, workorder, workorderSrc.TOOLTRANS);
                WorkorderDocLinksAdd(db, workorder, workorderSrc.DOCLINKS, workorderSrc.DOCINFO);
                WorkorderStatusesAdd(db, workorder, workorderSrc.WOSTATUS);
                WorkorderFailureRemarksAdd(db, workorder, workorderSrc.FAILUREREMARK);
                WorkorderFailureReportsAdd(db, workorder, workorderSrc.FAILUREREPORT);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return db.WORKORDERs.Add(workorder);
        }

        private void WorkorderFailureReportAdd(MxLocalCacheContext db, WORKORDER workorder, FAILUREREPORTMboSetFAILUREREPORT downloadedFailureReport)
        {
            var failureReport = new FAILUREREPORT();
            Mapper.PopulateFailureReport(failureReport, downloadedFailureReport);
            failureReport.Workorder = workorder;
            db.FAILUREREPORTs.Add(failureReport);
        }
        private void WorkorderFailureReportsAdd(MxLocalCacheContext db, WORKORDER workorder, FAILUREREPORTMboSetFAILUREREPORT[] failureReports)
        {
            if ((failureReports == null) || (failureReports.Length == 0))
                return;

            foreach (var downloadedFailureReport in failureReports)
            {
                WorkorderFailureReportAdd(db,workorder,downloadedFailureReport);
            }
        }

        private void WorkorderFailureRemarkAdd(MxLocalCacheContext db, WORKORDER workorder,
            FAILUREREMARKMboSetFAILUREREMARK downloadedFailureRemark)
        {
            var failureRemark = new FAILUREREMARK();
            Mapper.PopulateFailureRemark(failureRemark, downloadedFailureRemark);
            failureRemark.Workorder = workorder;
            db.FAILUREREMARKs.Add(failureRemark);
        }
        private void WorkorderFailureRemarksAdd(MxLocalCacheContext db, WORKORDER workorder, FAILUREREMARKMboSetFAILUREREMARK[] failureRemarks)
        {
            if ((failureRemarks == null) || (failureRemarks.Length == 0))
                return;

            var downloadedFailureRemark = failureRemarks[0];
            WorkorderFailureRemarkAdd(db,workorder,downloadedFailureRemark);
        }

        private void WorkorderStatusAdd(MxLocalCacheContext db, WORKORDER workorder, WOSTATUSMboSetWOSTATUS downloadedWoStatus)
        {
                var woStatus = new WOSTATUS();
                Mapper.PopulateWoStatus(woStatus, downloadedWoStatus);
                woStatus.Workorder = workorder;
                db.WOSTATUSes.Add(woStatus);
        }
        private void WorkorderStatusesAdd(MxLocalCacheContext db, WORKORDER workorder, WOSTATUSMboSetWOSTATUS[] woStatuses)
        {
            if ((woStatuses == null) || (woStatuses.Length == 0))
                return;

            foreach (var downloadedWoStatus in woStatuses)
            {
               WorkorderStatusAdd(db, workorder, downloadedWoStatus);
            }
        }

        private void WorkorderDocLinkAdd(MxLocalCacheContext db, WORKORDER workorder, DOCLINKSMboSetDOCLINKS downloadedDocLink, DOCINFOMboSetDOCINFO downloadedDocInfo)
        {
            var docLink = new DOCLINK();
            Mapper.PopulateDocLink(docLink, downloadedDocLink);
            docLink.Workorder = workorder;

            var docInfo = new DOCINFO();
            Mapper.PopulateDocInfo(docInfo, downloadedDocInfo);
            docLink.DocInfo = docInfo;
            
            db.DOCINFOes.Add(docInfo);
            db.DOCLINKS.Add(docLink);

            if (!string.IsNullOrEmpty(downloadedDocLink.DOCUMENTDATA))
            {
                DocumentSave(_attachmentPath, downloadedDocLink, downloadedDocInfo);
                docInfo.C_URLNAME_LOCAL_ = Path.Combine(_attachmentPath, Path.GetFileName(downloadedDocInfo.URLNAME));
            }

        }
        private void WorkorderDocLinksAdd(MxLocalCacheContext db, WORKORDER workorder, DOCLINKSMboSetDOCLINKS[] docLinks, DOCINFOMboSetDOCINFO[] docInfos)
        {
            if ((docLinks == null) || (docLinks.Length == 0))
                return;

            foreach (var downloadedDocLink in docLinks)
            {
                var downloadedDocInfo = (from d in docInfos
                    where d.DOCINFOID == downloadedDocLink.DOCINFOID
                    select d).FirstOrDefault();
                WorkorderDocLinkAdd(db, workorder, downloadedDocLink, downloadedDocInfo);
            }
        }

        private void WorkorderToolTranAdd(MxLocalCacheContext db, WORKORDER workorder, TOOLTRANSMboSetTOOLTRANS downloadedToolTran)
        {
            var toolTran = new TOOLTRAN();
            Mapper.PopulateToolTran(toolTran, downloadedToolTran);
            toolTran.Workorder = workorder;
            db.TOOLTRANS.Add(toolTran);

        }
        private void WorkorderToolTransAdd(MxLocalCacheContext db, WORKORDER workorder, TOOLTRANSMboSetTOOLTRANS[] toolTrans)
        {
            if ((toolTrans == null) || (toolTrans.Length == 0))
                return;

            foreach (var downloadedToolTran in toolTrans)
            {
                WorkorderToolTranAdd(db, workorder, downloadedToolTran);
            }
        }

        private void WorkorderLabTranAdd(MxLocalCacheContext db, WORKORDER workorder, LABTRANSMboSetLABTRANS downloadedLabTran)
        {
            var labTran = new LABTRAN();
            Mapper.PopulateLabTran(labTran, downloadedLabTran);
            labTran.Workorder = workorder;
            db.LABTRANS.Add(labTran);
        }
        private void WorkorderLabTransAdd(MxLocalCacheContext db, WORKORDER workorder, LABTRANSMboSetLABTRANS[] labTrans)
        {
            if ((labTrans == null) || (labTrans.Length == 0))
                return;

            foreach (var downloadedLabTran in labTrans)
            {
                WorkorderLabTranAdd(db,workorder,downloadedLabTran);
            }
        }

        private void WorkorderSpecAdd(MxLocalCacheContext db, WORKORDER workorder, WORKORDERSPECMboSetWORKORDERSPEC downloadedWorkorderSpec)
        {
            var workorderSpec = new WORKORDERSPEC();
            Mapper.PopulateWorkorderSpec(workorderSpec, downloadedWorkorderSpec);
            workorderSpec.Workorder = workorder;
            db.WORKORDERSPECs.Add(workorderSpec);
        }
        private void WorkorderSpecsAdd(MxLocalCacheContext db, WORKORDER workorder, WORKORDERSPECMboSetWORKORDERSPEC[] workorderSpecs)
        {
            if ((workorderSpecs == null) || (workorderSpecs.Length == 0))
                return;

            foreach (var downloadedWorkorderSpec in workorderSpecs)
            {
                WorkorderSpecAdd(db,workorder,downloadedWorkorderSpec);
            }
        }
        private void DocumentSave(string attachmentPath, DOCLINKSMboSetDOCLINKS downloadedDocLink, DOCINFOMboSetDOCINFO downloadedDocInfo)  
        {
            byte[] data = Convert.FromBase64String(downloadedDocLink.DOCUMENTDATA);
            string path = Path.Combine(attachmentPath, Path.GetFileName(downloadedDocInfo.URLNAME));
            try
            {
                File.WriteAllBytes(path, data);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private string DocumentUpload(string path)
        {
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
        
        private void DownloadAssetAttribute(MxLocalCacheContext mxLocalCacheContext)
        {
         try
            {
                mxLocalCacheContext.SaveChanges();
            }
         catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
        }

        private void DownloadClassSpec(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
        }
        private void DownloadLaborCraftRate(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                LABORCRAFTRATEMboSet laborCraftRates = _maximoService.GetLaborCraftRateMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM LABORCRAFTRATE");
                foreach (var laborCraftRateSrc in laborCraftRates.LABORCRAFTRATE)
                {
                    LABORCRAFTRATE laborCraftRate = new LABORCRAFTRATE();
                    laborCraftRate.LABORCRAFTRATEID = laborCraftRateSrc.LABORCRAFTRATEID;
                    laborCraftRate.CONTRACTNUM = (laborCraftRateSrc.CONTRACTNUM != null)
                        ? laborCraftRateSrc.CONTRACTNUM.ToString()
                        : null;
                    laborCraftRate.CONTROLACCOUNT = (laborCraftRateSrc.CONTROLACCOUNT != null)
                        ? laborCraftRateSrc.CONTROLACCOUNT.ToString()
                        : null;
                    laborCraftRate.CRAFT = laborCraftRateSrc.CRAFT;
                    laborCraftRate.DEFAULTCRAFT = laborCraftRateSrc.DEFAULTCRAFT;
                    laborCraftRate.DEFAULTTICKETGLACC = (laborCraftRateSrc.DEFAULTTICKETGLACC != null)
                        ? laborCraftRateSrc.DEFAULTTICKETGLACC.ToString()
                        : null;
                    laborCraftRate.GLACCOUNT = (laborCraftRateSrc.GLACCOUNT != null)
                        ? laborCraftRateSrc.GLACCOUNT.VALUE
                        : null;
                    laborCraftRate.INHERIT = laborCraftRateSrc.INHERIT;
                    laborCraftRate.LABORCODE = laborCraftRateSrc.LABORCODE.ToString();
                    laborCraftRate.ORGID = laborCraftRateSrc.ORGID;
                    laborCraftRate.RATE = Decimal.ToDouble(laborCraftRateSrc.RATE);
                    laborCraftRate.SKILLLEVEL = (laborCraftRateSrc.SKILLLEVEL != null)
                        ? laborCraftRateSrc.SKILLLEVEL.ToString()
                        : null;
                    ;
                    laborCraftRate.VENDOR = (laborCraftRateSrc.VENDOR != null)
                        ? laborCraftRateSrc.VENDOR.ToString()
                        : null;
                    mxLocalCacheContext.LABORCRAFTRATEs.Add(laborCraftRate);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
        }
        private void DownloadAlnDomain(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                ALNDOMAINMboSet alnDomains = _maximoService.GetAlnDomainMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM ALNDOMAIN");
                foreach (var alnDomainSrc in alnDomains.ALNDOMAIN)
                {
                    ALNDOMAIN alnDomain = new ALNDOMAIN();
                    alnDomain.DOMAINID = alnDomainSrc.DOMAINID;
                    alnDomain.VALUE = alnDomainSrc.VALUE;
                    alnDomain.ALNDOMAINID = alnDomainSrc.ALNDOMAINID;
                    alnDomain.DESCRIPTION = alnDomainSrc.DESCRIPTION;
                    alnDomain.ORGID = alnDomainSrc.ORGID;
                    alnDomain.SITEID = alnDomainSrc.SITEID;
                    alnDomain.VALUEID = alnDomainSrc.VALUEID;
                    mxLocalCacheContext.ALNDOMAINs.Add(alnDomain);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
        }
        private void DownloadDocTypes(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                DOCTYPESMboSet docTypes = _maximoService.GetDoctypesMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM DOCTYPES");
                foreach (var docTypeSrc in docTypes.DOCTYPES)
                {
                    DOCTYPE docType = new DOCTYPE();
                    docType.DOCTYPE_ = docTypeSrc.DOCTYPE;
                    docType.DOCTYPESID = docTypeSrc.DOCTYPESID;
                    docType.DESCRIPTION = docTypeSrc.DESCRIPTION;
                    docType.DEFAULTFILEPATH = docTypeSrc.DEFAULTFILEPATH;
                    mxLocalCacheContext.DOCTYPES.Add(docType);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }

        }
        private void DownloadMaxDomain(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                MAXDOMAINMboSet maxDomains = _maximoService.GetMaxDomainMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM MAXDOMAIN");
                foreach (var maxDomainSrc in maxDomains.MAXDOMAIN)
                {
                    MAXDOMAIN maxDomain = new MAXDOMAIN();
                    maxDomain.MAXDOMAINID = maxDomainSrc.MAXDOMAINID;
                    maxDomain.DESCRIPTION = maxDomainSrc.DESCRIPTION;
                    maxDomain.DOMAINID = maxDomainSrc.DOMAINID;
                    maxDomain.DOMAINTYPE = maxDomainSrc.DOMAINTYPE.Value;
                    maxDomain.INTERNAL = maxDomainSrc.INTERNAL;
                    if (maxDomainSrc.LENGTH != null)
                        maxDomain.LENGTH = Convert.ToInt64(maxDomainSrc.LENGTH);
                    else
                        maxDomain.LENGTH = null;
                    maxDomain.MAXTYPE = maxDomainSrc.MAXTYPE;
                    if (maxDomainSrc.SCALE != null)
                        maxDomain.SCALE = Convert.ToInt64(maxDomainSrc.SCALE);
                    else
                        maxDomain.SCALE = null;
                    maxDomain.NEVERCACHE = maxDomainSrc.NEVERCACHE;

                    mxLocalCacheContext.MAXDOMAINs.Add(maxDomain);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
        }
        private void DownloadSynonymDomain(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                SYNONYMDOMAINMboSet synonymDomains = _maximoService.GetSynonymDomainMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM SYNONYMDOMAIN");
                foreach (var synonymDomainSrc in synonymDomains.SYNONYMDOMAIN)
                {
                    SYNONYMDOMAIN synonymDomain = new SYNONYMDOMAIN();
                    synonymDomain.SYNONYMDOMAINID = synonymDomainSrc.SYNONYMDOMAINID;
                    synonymDomain.DOMAINID = synonymDomainSrc.DOMAINID;
                    synonymDomain.DEFAULTS = synonymDomainSrc.DEFAULTS;
                    synonymDomain.DESCRIPTION = synonymDomainSrc.DESCRIPTION;
                    synonymDomain.MAXVALUE = synonymDomainSrc.MAXVALUE;
                    synonymDomain.ORGID = synonymDomainSrc.ORGID;
                    synonymDomain.SITEID = synonymDomainSrc.SITEID;
                    synonymDomain.VALUE = synonymDomainSrc.VALUE;
                    synonymDomain.VALUEID = synonymDomainSrc.VALUEID;

                    mxLocalCacheContext.SYNONYMDOMAINs.Add(synonymDomain);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        private void DownloadPerson(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                PERSONMboSet persons = _maximoService.GetPersonMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM PERSON");
                foreach (var personSrc in persons.PERSON)
                {
                    PERSON person = new PERSON();
                    person.PERSONUID = personSrc.PERSONUID;
                    person.ACCEPTINGWFMAIL = personSrc.ACCEPTINGWFMAIL;
                    person.ADDRESSLINE1 = personSrc.ADDRESSLINE1;
                    person.ADDRESSLINE2 = personSrc.ADDRESSLINE2;
                    person.ADDRESSLINE3 = personSrc.ADDRESSLINE3;
                    person.BILLTOADDRESS = personSrc.BILLTOADDRESS;
                    person.BIRTHDATE = personSrc.BIRTHDATE;
                    person.CALTYPE = personSrc.CALTYPE;
                    person.CITY = personSrc.CITY;
                    person.COUNTRY = personSrc.COUNTRY;
                    person.COUNTY = personSrc.COUNTY;
                    person.DELEGATE = personSrc.DELEGATE;
                    person.DELEGATEFROMDATE = personSrc.DELEGATEFROMDATE;
                    person.DELEGATETODATE = personSrc.DELEGATETODATE;
                    person.DEPARTMENT = personSrc.DEPARTMENT;
                    person.DISPLAYNAME = personSrc.DISPLAYNAME;
                    person.DROPPOINT = personSrc.DROPPOINT;
                    person.EMPLOYEETYPE = personSrc.EMPLOYEETYPE;
                    person.EXTERNALREFID = personSrc.EXTERNALREFID;
                    person.FIRSTNAME = personSrc.FIRSTNAME;
                    person.HASLD     = personSrc.HASLD;
                    person.HIREDATE = personSrc.HIREDATE;
                    person.IM_ID = personSrc.IM_ID;
                    person.JOBCODE = personSrc.JOBCODE;
                    person.LANGCODE   = personSrc.LANGCODE;
                    person.LANGUAGE = personSrc.LANGUAGE;
                    person.LASTEVALDATE = personSrc.LASTEVALDATE;
                    person.LASTNAME = personSrc.LASTNAME;
                    person.LOCALE = personSrc.LOCALE;
                    person.LOCATION = personSrc.LOCATION;
                    person.LOCATIONORG = personSrc.LOCATIONORG;
                    person.LOCATIONSITE = personSrc.LOCATIONSITE;
                    person.LOCTOSERVREQ = personSrc.LOCTOSERVREQ;
                    person.NEXTEVALDATE = personSrc.NEXTEVALDATE;
                    person.OWNERGROUP = personSrc.OWNERGROUP;
                    person.OWNERSYSID = personSrc.OWNERSYSID;
                    person.PCARDEXPDATE = personSrc.PCARDEXPDATE;
                    person.PCARDNUM = personSrc.PCARDNUM;
                    person.PCARDTYPE = personSrc.PCARDTYPE;
                    person.PCARDVERIFICATION = personSrc.PCARDVERIFICATION;
                    person.PERSONID = personSrc.PERSONID;
                    person.POSTALCODE = personSrc.POSTALCODE;
                    person.PRIMARYSMS = personSrc.PRIMARYSMS;
                    person.REGIONDISTRICT = personSrc.REGIONDISTRICT;
                    person.SENDERSYSID = personSrc.SENDERSYSID;
                    person.SHIPTOADDRESS = personSrc.SHIPTOADDRESS;
                    person.SOURCESYSID = personSrc.SOURCESYSID;
                    person.STATEPROVINCE = personSrc.STATEPROVINCE;
                    person.STATUS = personSrc.STATUS.Value;
                    if (personSrc.STATUSDATE.HasValue)
                        person.STATUSDATE  = personSrc.STATUSDATE.Value;
                    person.SUPERVISOR = personSrc.SUPERVISOR;
                    person.TERMINATIONDATE = personSrc.TERMINATIONDATE;
                    if (personSrc.TIMEZONE != null)
                        person.TIMEZONE = personSrc.TIMEZONE.Value;
                    person.TITLE = personSrc.TITLE;
                    if (personSrc.TRANSEMAILELECTION != null)
                        person.TRANSEMAILELECTION = personSrc.TRANSEMAILELECTION.Value;
                    person.VIP = personSrc.VIP;
                    if (personSrc.WFMAILELECTION != null)
                        person.WFMAILELECTION = personSrc.WFMAILELECTION.Value;
                    person.WOPRIORITY = personSrc.WOPRIORITY;
                    person.PRIMARYSMS = personSrc.PRIMARYSMS;
                    person.OWNERGROUP = personSrc.OWNERGROUP;
                    person.IM_ID = personSrc.IM_ID;
                    person.CALTYPE = personSrc.CALTYPE;
                    person.DFLTAPP = personSrc.DFLTAPP;
                    person.DEVICECLASS = personSrc.DEVICECLASS;

                    mxLocalCacheContext.PERSONs.Add(person);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private void DownloadPersonGroup(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                PERSONGROUPMboSet personGroups = _maximoService.GetPersonGroupMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM PERSONGROUP");
                foreach (var personGroupSrc in personGroups.PERSONGROUP)
                {
                    PERSONGROUP personGroup = new PERSONGROUP();
                    personGroup.PERSONGROUPID = personGroupSrc.PERSONGROUPID;
                    personGroup.PERSONGROUP_ = personGroupSrc.PERSONGROUP;
                    personGroup.DESCRIPTION = personGroupSrc.DESCRIPTION;
                    personGroup.HASLD = personGroupSrc.HASLD;
                    personGroup.LANGCODE = personGroupSrc.LANGCODE;
                    personGroup.VEHICLENUM = personGroupSrc.VEHICLENUM;
                    personGroup.ISCREWWORKGROUP = personGroupSrc.ISCREWWORKGROUP;

                    mxLocalCacheContext.PERSONGROUPs.Add(personGroup);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
        }
        private void DownloadPersonGroupTeam(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                PERSONGROUPTEAMMboSet personGroupTeams = _maximoService.GetPersonGroupTeamMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM PERSONGROUPTEAM");
                foreach (var personGroupTeamSrc in personGroupTeams.PERSONGROUPTEAM)
                {
                    PERSONGROUPTEAM personGroupTeam = new PERSONGROUPTEAM();
                    personGroupTeam.PERSONGROUPTEAMID = personGroupTeamSrc.PERSONGROUPTEAMID;
                    personGroupTeam.GROUPDEFAULT = personGroupTeamSrc.GROUPDEFAULT;
                    personGroupTeam.ORGDEFAULT = personGroupTeamSrc.ORGDEFAULT;
                    personGroupTeam.PERSONGROUP = personGroupTeamSrc.PERSONGROUP;
                    personGroupTeam.RESPPARTY = personGroupTeamSrc.RESPPARTY;
                    personGroupTeam.RESPPARTYGROUP = personGroupTeamSrc.RESPPARTYGROUP;
                    personGroupTeam.RESPPARTYGROUPSEQ = personGroupTeamSrc.RESPPARTYGROUPSEQ;
                    personGroupTeam.RESPPARTYSEQ = personGroupTeamSrc.RESPPARTYSEQ;
                    personGroupTeam.SITEDEFAULT = personGroupTeamSrc.SITEDEFAULT;
                    personGroupTeam.USEFORSITE = personGroupTeamSrc.USEFORSITE;
                    personGroupTeam.USEFORORG = personGroupTeamSrc.USEFORORG;
                    personGroupTeam.DCW_DESIGNATION = personGroupTeamSrc.DCW_DESIGNATION;

                    mxLocalCacheContext.PERSONGROUPTEAMs.Add(personGroupTeam);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
            catch (Exception e)
            {
                throw;
            }

        }
        private void DownloadFailureCode(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                FAILURECODEMboSet failureCodes = _maximoService.GetFailureCodeMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM FAILURECODE");
                foreach (var failureCodeSrc in failureCodes.FAILURECODE)
                {
                    FAILURECODE failureCode = new FAILURECODE();
                    failureCode.FAILURECODEID = failureCodeSrc.FAILURECODEID;
                    failureCode.FAILURECODE_ = failureCodeSrc.FAILURECODE;
                    failureCode.DESCRIPTION = failureCodeSrc.DESCRIPTION;
                    failureCode.HASLD = failureCodeSrc.HASLD;
                    failureCode.LANGCODE = failureCodeSrc.LANGCODE;
                    failureCode.ORGID = failureCodeSrc.ORGID;

                    mxLocalCacheContext.FAILURECODEs.Add(failureCode);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void DownloadWorkType(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                WORKTYPEMboSet workTypes = _maximoService.GetWorkTypeMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM WORKTYPE");
                foreach (var workTypeSrc in workTypes.WORKTYPE)
                {
                    WORKTYPE workType = new WORKTYPE();
                    workType.WORKTYPEID = workTypeSrc.WORKTYPEID;
                    workType.WORKTYPE_ = workTypeSrc.WORKTYPE;
                    if (workTypeSrc.COMPLETESTATUS != null)
                        workType.COMPLETESTATUS = workTypeSrc.COMPLETESTATUS.Value;
                    workType.KEEPTASKSTATUSHIST = workTypeSrc.KEEPTASKSTATUSHIST;
                    workType.ORGID = workTypeSrc.ORGID;
                    workType.PROMPTDOWN = workTypeSrc.PROMPTDOWN;
                    workType.PROMPTFAIL = workTypeSrc.PROMPTFAIL;
                    if (workTypeSrc.STARTSTATUS != null)
                      workType.STARTSTATUS = workTypeSrc.STARTSTATUS.Value;
                    workType.TYPE = workTypeSrc.TYPE.Value;
                    if (workTypeSrc.WOCLASS != null)
                        workType.WOCLASS = workTypeSrc.WOCLASS.Value;
                    workType.WTYPEDESC = workTypeSrc.WTYPEDESC;

                    mxLocalCacheContext.WORKTYPEs.Add(workType);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        private void DownloadTruckInventory(MxLocalCacheContext mxLocalCacheContext)
        {
            try
            {
                INVENTORYMboSet trucks = _maximoService.GetInventoryMboSet("OSTFLEET");
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM INVENTORY");
                foreach (var truckSrc in trucks.INVENTORY)
                {
                    INVENTORY truck = new INVENTORY();
                    truck.ITEMNUM = truckSrc.ITEMNUM;
                    truck.LOCATION = truckSrc.LOCATION;
                    truck.BINNUM = truckSrc.BINNUM;
                    truck.VENDOR = truckSrc.VENDOR;
                    truck.MANUFACTURER = truckSrc.MANUFACTURER;
                    truck.MODELNUM = truckSrc.MODELNUM;
                    truck.CATALOGCODE = truckSrc.CATALOGCODE;
                    truck.MINLEVEL = Convert.ToDouble(truckSrc.MINLEVEL);
                    truck.MAXLEVEL = Convert.ToDouble(truckSrc.MAXLEVEL);
                    if (truckSrc.CATEGORY != null)
                        truck.CATEGORY = truckSrc.CATEGORY.Value;
                    truck.ORDERUNIT = truckSrc.ORDERUNIT;
                    truck.ISSUEUNIT = truckSrc.ISSUEUNIT;
                    truck.ORDERQTY = Convert.ToDouble(truckSrc.ORDERQTY);
                    if (truckSrc.LASTISSUEDATE.HasValue)
                        truck.LASTISSUEDATE = truckSrc.LASTISSUEDATE;
                    truck.ISSUEYTD = Convert.ToDouble(truckSrc.ISSUEYTD);
                    truck.ISSUE1YRAGO = Convert.ToDouble(truckSrc.ISSUE1YRAGO);
                    truck.ISSUE2YRAGO = Convert.ToDouble(truckSrc.ISSUE2YRAGO);
                    truck.ISSUE3YRAGO = Convert.ToDouble(truckSrc.ISSUE3YRAGO);
                    truck.ABCTYPE = truckSrc.ABCTYPE;
                    truck.CCF = truckSrc.CCF;
                    if (truckSrc.SSTOCK.HasValue)
                        truck.SSTOCK = Convert.ToDouble(truckSrc.SSTOCK);
                    truck.DELIVERYTIME = truckSrc.DELIVERYTIME;
                    truck.IL1 = truckSrc.IL1;
                    truck.IL2 = truckSrc.IL2;
                    truck.IL3 = truckSrc.IL3;
                    if (truckSrc.GLACCOUNT != null)
                        truck.GLACCOUNT = truckSrc.GLACCOUNT.VALUE;
                    if (truckSrc.CONTROLACC != null)
                        truck.CONTROLACC = truckSrc.CONTROLACC.VALUE;
                    if (truckSrc.SHRINKAGEACC != null)
                        truck.SHRINKAGEACC = truckSrc.SHRINKAGEACC.VALUE;
                    if (truckSrc.INVCOSTADJACC != null)
                        truck.INVCOSTADJACC = truckSrc.INVCOSTADJACC.VALUE;
                    truck.SOURCESYSID = truckSrc.SOURCESYSID;
                    truck.OWNERSYSID = truckSrc.OWNERSYSID;
                    truck.EXTERNALREFID = truckSrc.EXTERNALREFID;
                    truck.SENDERSYSID = truckSrc.SENDERSYSID;
                    truck.ORGID = truckSrc.ORGID;
                    truck.SITEID = truckSrc.SITEID;
                    truck.INTERNAL = truckSrc.INTERNAL;
                    truck.INVENTORYID = truckSrc.INVENTORYID;
                    truck.ITEMSETID = truckSrc.ITEMSETID; ;
                    truck.STORELOC = truckSrc.STORELOC;
                    truck.STORELOCSITEID = truckSrc.STORELOCSITEID;
                    truck.STATUS = truckSrc.STATUS;
                    truck.STATUSDATE = truckSrc.STATUSDATE;
                    mxLocalCacheContext.INVENTORies.Add(truck);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        private void DownloadFailureList(MxLocalCacheContext mxLocalCacheContext)
        {
            //TODO: Verify IBM HotFix
            return;
            try
            {
                FAILURELISTMboSet failureLists = _maximoService.GetFailureListMboSet();
                mxLocalCacheContext.Database.ExecuteSqlCommand("DELETE FROM FAILURELIST");
                foreach (var failureListSrc in failureLists.FAILURELIST)
                {
                    FAILURELIST failureList = new FAILURELIST();
                    failureList.FAILURELIST_ = failureListSrc.FAILURELIST;
                    failureList.FAILURECODE = failureListSrc.FAILURECODE;
                    failureList.ORGID = failureListSrc.ORGID;
                    failureList.PARENT = failureListSrc.PARENT;
                    if (failureListSrc.TYPE != null)
                        failureList.TYPE = failureListSrc.TYPE.Value;

                    mxLocalCacheContext.FAILURELISTs.Add(failureList);
                }
                mxLocalCacheContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                DumpValidationErrors(e);
                throw;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        private static void DumpValidationErrors(DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                Log.Write(LogLevel.Error, string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State));
                foreach (var validationError in eve.ValidationErrors)
                {
                     Log.Write(LogLevel.Error, string.Format("- Property: \"{0}\", Error \"{1}\"",
                        validationError.PropertyName, validationError.ErrorMessage));
                }
            }
        }

        
    }
}
