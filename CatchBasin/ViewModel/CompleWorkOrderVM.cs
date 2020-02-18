﻿using Esri.ArcGISRuntime.Data;
using MaximoServiceLibrary;
using MaximoServiceLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CatchBasin.ViewModel
{
    class CompleteWorkorderVM : BaseVM, Helper.IDetailVM
    {
        private DateTime statusDate;

        public DateTime StatusDate
        {
            get { return statusDate; }
            set { statusDate = value; OnPropertyChanged("StatusDate"); }
        }

        private string newStatus;

        public string NewStatus
        {
            get { return newStatus; }
            set { newStatus = value; OnPropertyChanged("NewStatus"); }
        }

        private string memo;

        public string Memo
        {
            get { return memo; }
            set { memo = value; OnPropertyChanged("Memo"); }
        }

        private Command.SaveCommand<CompleteWorkorderVM> saveCommand;

        public Command.SaveCommand<CompleteWorkorderVM> SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; OnPropertyChanged("SaveCommand"); }
        }

        private Command.CancelCommand<CompleteWorkorderVM> cancelCommand;

        public Command.CancelCommand<CompleteWorkorderVM> CancelCommand
        {
            get { return cancelCommand; }
            set { cancelCommand = value; OnPropertyChanged("CancelCommand"); }
        }

        private bool holdIsEnabled;

        public bool HoldIsEnabled
        {
            get { return holdIsEnabled; }
            set { holdIsEnabled = value; OnPropertyChanged("HoldIsEnabled"); }
        }

        private bool cancelIsEnabled;

        public bool CancelIsEnabled
        {
            get { return cancelIsEnabled; }
            set { cancelIsEnabled = value; OnPropertyChanged("CancelIsEnabled"); }
        }


        WorkOrderDetailVM WorkOrderDetailVM;

        public CompleteWorkorderVM(WorkOrderDetailVM workOrderDetailVM)
        {
            WorkOrderDetailVM = workOrderDetailVM;
            SaveCommand = new Command.SaveCommand<CompleteWorkorderVM>(this);
            CancelCommand = new Command.CancelCommand<CompleteWorkorderVM>(this);

            StatusDate = DateTime.Now;
            NewStatus = "COMP";
            HoldIsEnabled = true;
            CancelIsEnabled = true;
            WorkOrderDetailVM.SaveWithoutHideAsync();
            var wo = WorkOrderDetailVM.MaximoWorkOrder;
            if (wo.worktype == "CM")
            {
                HoldIsEnabled = false;
                CancelIsEnabled = false;
            }
            else if (wo.description == "Newly Discovered Asset cleaned by CB Cleaning Crew")
            {
                HoldIsEnabled = false;
                CancelIsEnabled = false;
            }
            else if (wo.description == "New Asset cleaned by CB Cleaning Crew")
            {
                HoldIsEnabled = false;
                CancelIsEnabled = false;
            }
            else if (wo.description == "CB cleaned by CB Cleaning Crew")
            {
                HoldIsEnabled = false;
                CancelIsEnabled = false;
            }
            else if (wo.description == "Newly Discovered Asset Inspected by DSS")
            {
                HoldIsEnabled = false;
                CancelIsEnabled = false;

            }
            else if (wo.worktype == "INSP")
            {

            }
            else
            {
                CancelIsEnabled = false;
            }


        }

        public async void Save()
        {
            if (NewStatus != "COMP" && (Memo == "" || Memo == null))
            {

                MessageBox.Show("Memo is required", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            WorkOrderDetailVM.SaveWithoutHideAsync();
            MaximoWorkOrder wo = WorkOrderDetailVM.MaximoWorkOrder;

            if (((App)Application.Current).AppType == "PM")
            {
                if (wo.description == "Newly Discovered Asset cleaned by CB Cleaning Crew"
                || wo.description == "New Asset cleaned by CB Cleaning Crew"
                || wo.description == "CB cleaned by CB Cleaning Crew")
                {
                    if (wo.asset == null)
                    {
                        MessageBox.Show("Asset must be specified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                if (NewStatus != "HOLD" && (!string.IsNullOrEmpty(wo.problemcode) && wo.problemcode != "NOTFOUND") && wo.asset != null)
                {
                    if (wo.asset.assetspec == null || wo.asset.assetspec.Count == 0)
                    {
                        MessageBox.Show("Asset was not classified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                        return;
                    }
                    else
                    {
                        MaximoAssetSpec maximoAssetSpec = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "CB_SUBT");

                        if (maximoAssetSpec == null || string.IsNullOrEmpty(maximoAssetSpec.alnvalue) || maximoAssetSpec.alnvalue == "UNKNOWN")
                        {
                            MessageBox.Show("Asset subtype is null or unknown", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        else
                        {
                            switch (maximoAssetSpec.alnvalue)
                            {
                                case "DOUBLE":
                                case "ELONGATE":
                                case "QUADRUPLE":
                                case "QUINTUPLE":
                                case "SINGLE":
                                case "TRIPLE":

                                    MaximoAssetSpec TOPMATRL = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "TOPMATRL");

                                    if (TOPMATRL == null || string.IsNullOrEmpty(TOPMATRL.alnvalue))
                                    {
                                        MessageBox.Show("Top Material type is null", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        return;

                                    }
                                    MaximoAssetSpec TOPTHICK = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "TOPTHICK");

                                    if (TOPTHICK == null || !TOPTHICK.numvalue.HasValue || TOPTHICK.numvalue.Value <= 0.0)
                                    {
                                        MessageBox.Show("Top Thickness is not specified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        return;

                                    }
                                    MaximoAssetSpec NUMCHAMB = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "NUMCHAMB");

                                    if (NUMCHAMB == null || !NUMCHAMB.numvalue.HasValue || NUMCHAMB.numvalue.Value <= 0.0)
                                    {
                                        MessageBox.Show("Number of Chambers is not specified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        return;

                                    }
                                    MaximoAssetSpec NUMTHROAT = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "NUMTHROAT");

                                    if (NUMTHROAT == null || !NUMTHROAT.numvalue.HasValue || NUMTHROAT.numvalue.Value <= 0.0)
                                    {
                                        MessageBox.Show("Number of Throats is not specified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        return;

                                    }
                                    break;
                                case "DOUBLE GRATE":
                                case "FIELD DRAIN":
                                case "GRATE":
                                case "TRENCH DRAIN":
                                case "TRIPLE GRATE":

                                    MaximoAssetSpec GRATETY = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "GRATETY");

                                    if (GRATETY == null || string.IsNullOrEmpty(GRATETY.alnvalue))
                                    {
                                        MessageBox.Show("Grate type is nulld", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        return;

                                    }
                                    break;

                            }
                        }
                    }


                }
                if (NewStatus != "HOLD")
                {
                    if (wo.failurereport == null || string.IsNullOrEmpty(wo.problemcode))
                    {
                        MessageBox.Show("Missing Problem/Cause/Remedy", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;

                    }
                    else
                    {

                        var cause = wo.failurereport.FirstOrDefault(f => f.type == "CAUSE");
                        var remedy = wo.failurereport.FirstOrDefault(f => f.type == "REMEDY");
                        if (cause == null)
                        {
                            MessageBox.Show("Missing Problem/Cause/Remedy", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        else if (remedy == null && wo.problemcode != "NOTFOUND")
                        {
                            try
                            {
                                var selectedProblem = MaximoServiceLibrary.AppContext.failureListRepository.Find("failurecode[0].failurecode", wo.problemcode).ToArray()[0];

                                var selectedCause = MaximoServiceLibrary.AppContext.failureListRepository.Find("failurecode[0].failurecode", cause.failurecode).Where(failurelist => failurelist.parent == selectedProblem.failurelist).ToArray()[0];

                                var RemedyList = MaximoServiceLibrary.AppContext.failureListRepository
                                    .Find("parent", selectedCause?.failurelist).Select(x => x.failurecode[0]).ToList<FailureCode>();

                                if (RemedyList != null && RemedyList.Count > 0)
                                {
                                    MessageBox.Show("Missing Problem/Cause/Remedy", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Missing Problem/Cause/Remedy", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                        }
                    }
                    if (wo.problemcode != null && wo.problemcode != "NOTFOUND")
                    {

                        if (wo.workorderspec == null && wo.workorderspec.Count == 0)
                        {
                            MessageBox.Show("Workorder was not classified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;

                        }

                        if (wo.worktype == "PM")
                        {
                            var CBBCSTATUS = wo.workorderspec.FirstOrDefault(s => s.assetattrid == "CBBCSTATUS");
                            var CBACSTATUS = wo.workorderspec.FirstOrDefault(s => s.assetattrid == "CBACSTATUS");

                            if (CBBCSTATUS == null || string.IsNullOrEmpty(CBBCSTATUS.alnvalue))
                            {
                                MessageBox.Show("Debris Condition prior to cleaning is misssing", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                            if (CBACSTATUS == null || string.IsNullOrEmpty(CBACSTATUS.alnvalue))
                            {
                                MessageBox.Show("Debris Condition after cleaning is missing", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                        }
                        

                        if (wo.tooltrans.Count == 0)
                        {
                            MessageBox.Show("Tools not entered", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        if (wo.tooltrans.Any(t => string.IsNullOrEmpty(t.itemnum)))
                        {
                            MessageBox.Show("Tool record with no Item selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        if (wo.labtrans.Count == 0)
                        {
                            MessageBox.Show("Labor not entered", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        else
                        {
                            if (wo.labtrans.Any(l => string.IsNullOrEmpty(l.laborcode)))
                            {
                                MessageBox.Show("Labor record with no Person selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                            if (wo.labtrans.Any(l => l.startDate > DateTime.Now))
                            {
                                MessageBox.Show("Labor record start in the future", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                            if (wo.labtrans.Any(l => l.finishDate > DateTime.Now))
                            {
                                MessageBox.Show("Labor record finish in the future", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                if(wo.description == "Newly Discovered Asset Inspected by DSS")
                {
                    if (wo.asset == null)
                    {
                        MessageBox.Show("Asset must be specified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                if(NewStatus != "CAN" && (!string.IsNullOrEmpty(wo.problemcode) && wo.problemcode != "NOTFOUND") && (wo.problemcode == "NOACCESS" && wo.asset != null))
                {
                    if ((wo.asset.assetspec == null || wo.asset.assetspec.Count == 0))
                    {
                        MessageBox.Show("Asset was not classified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                        return;
                    }
                    else
                    {
                        MaximoAssetSpec maximoAssetSpec = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "CB_SUBT");

                        if (maximoAssetSpec == null || string.IsNullOrEmpty(maximoAssetSpec.alnvalue) || maximoAssetSpec.alnvalue == "UNKNOWN")
                        {
                            MessageBox.Show("Asset subtype is null or unknown", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        else
                        {
                            switch (maximoAssetSpec.alnvalue)
                            {
                                case "DOUBLE":
                                case "ELONGATE":
                                case "QUADRUPLE":
                                case "QUINTUPLE":
                                case "SINGLE":
                                case "TRIPLE":

                                    MaximoAssetSpec TOPMATRL = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "TOPMATRL");

                                    if (TOPMATRL == null || string.IsNullOrEmpty(TOPMATRL.alnvalue))
                                    {
                                        MessageBox.Show("Top Material type is null", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        return;

                                    }
                                    MaximoAssetSpec TOPTHICK = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "TOPTHICK");

                                    if (TOPTHICK == null || !TOPTHICK.numvalue.HasValue || TOPTHICK.numvalue.Value <= 0.0)
                                    {
                                        MessageBox.Show("Top Thickness is not specified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        return;

                                    }
                                    MaximoAssetSpec NUMCHAMB = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "NUMCHAMB");

                                    if (NUMCHAMB == null || !NUMCHAMB.numvalue.HasValue || NUMCHAMB.numvalue.Value <= 0.0)
                                    {
                                        MessageBox.Show("Number of Chambers is not specified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        return;

                                    }
                                    MaximoAssetSpec NUMTHROAT = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "NUMTHROAT");

                                    if (NUMTHROAT == null || !NUMTHROAT.numvalue.HasValue || NUMTHROAT.numvalue.Value <= 0.0)
                                    {
                                        MessageBox.Show("Number of Throats is not specified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        return;

                                    }
                                    break;
                                case "DOUBLE GRATE":
                                case "FIELD DRAIN":
                                case "GRATE":
                                case "TRENCH DRAIN":
                                case "TRIPLE GRATE":

                                    MaximoAssetSpec GRATETY = wo.asset.assetspec.FirstOrDefault(s => s.assetattrid == "GRATETY");

                                    if (GRATETY == null || string.IsNullOrEmpty(GRATETY.alnvalue))
                                    {
                                        MessageBox.Show("Grate type is nulld", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        return;

                                    }
                                    break;

                            }
                        }
                    }

                }
                if (NewStatus != "CAN") {

                    if (wo.failurereport == null || string.IsNullOrEmpty(wo.problemcode))
                    {
                        MessageBox.Show("Missing Problem/Cause/Remedy", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;

                    }
                    else
                    {

                        var cause = wo.failurereport.FirstOrDefault(f => f.type == "CAUSE");
                        var remedy = wo.failurereport.FirstOrDefault(f => f.type == "REMEDY");
                        if (cause == null)
                        {
                            MessageBox.Show("Missing Problem/Cause/Remedy", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        else if (remedy == null && wo.problemcode != "NOTFOUND")
                        {
                            try
                            {
                                var selectedProblem = MaximoServiceLibrary.AppContext.failureListRepository.Find("failurecode[0].failurecode", wo.problemcode).ToArray()[0];

                                var selectedCause = MaximoServiceLibrary.AppContext.failureListRepository.Find("failurecode[0].failurecode", cause.failurecode).Where(failurelist => failurelist.parent == selectedProblem.failurelist).ToArray()[0];

                                var RemedyList = MaximoServiceLibrary.AppContext.failureListRepository
                                    .Find("parent", selectedCause?.failurelist).Select(x => x.failurecode[0]).ToList<FailureCode>();

                                if (RemedyList != null && RemedyList.Count > 0)
                                {
                                    MessageBox.Show("Missing Problem/Cause/Remedy", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    return;
                                }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Missing Problem/Cause/Remedy", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                        }
                    }
                    if (wo.problemcode != null && wo.problemcode != "NOTFOUND" && wo.problemcode != "NOACCESS")
                    {

                        if (wo.workorderspec != null && wo.workorderspec.Count > 0)
                        {
                            var CBBCSTATUS = wo.workorderspec.FirstOrDefault(s => s.assetattrid == "CBBCSTATUS");
                           

                            if (CBBCSTATUS == null || string.IsNullOrEmpty(CBBCSTATUS.alnvalue))
                            {
                                MessageBox.Show("Debris Condition prior to cleaning is misssing", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                           
                        }
                        else
                        {
                            MessageBox.Show("Workorder was not classified", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;

                        }

                        if (wo.tooltrans.Count == 0)
                        {
                            MessageBox.Show("Tools not entered", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }

                        if (wo.tooltrans.Any(t => string.IsNullOrEmpty(t.itemnum)))
                        {
                            MessageBox.Show("Tool record with no Item selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        if (wo.labtrans.Count == 0)
                        {
                            MessageBox.Show("Labor not entered", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        else
                        {
                            if (wo.labtrans.Any(l => string.IsNullOrEmpty(l.laborcode)))
                            {
                                MessageBox.Show("Labor record with no Person selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                            if (wo.labtrans.Any(l => l.startDate > DateTime.Now))
                            {
                                MessageBox.Show("Labor record start in the future", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                            if (wo.labtrans.Any(l => l.finishDate > DateTime.Now))
                            {
                                MessageBox.Show("Labor record finish in the future", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return;
                            }
                        }
                    }

                }

            }

            // Check time 

            var labors = wo.labtrans.Select(lab => lab.laborcode).Distinct();
            foreach (var labor in labors)
            {
                var labortrans =wo.labtrans.Where(lab => lab.laborcode == labor).OrderBy(lab => lab.startDate).ToList();

                if (labortrans.Count > 1)
                {
                    for (int i = 0; i < labortrans.Count-1; i++)
                    {
                       if(labortrans[i + 1].startDate < labortrans[i].finishDate)
                        {
                            System.Windows.MessageBox.Show($"Detect overlapping periods for {labor}\nPlease Check {labor}'s Labor Duration", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }
            }






           

            wo.status = NewStatus;


            wo.statusdate = StatusDate;
            wo.np_statusmemo = Memo;
            wo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;

            wo.followups = generateFollowUps(wo);

            var layer = WorkOrderDetailVM.MapVM.GetWorkorderLayer();
            var featureTable = WorkOrderDetailVM.MapVM.woFeatureTable;
            QueryParameters queryParameters = new QueryParameters();
            if(wo.syncronizationStatus == LocalDBLibrary.model.SyncronizationStatus.CREATED)
            {
                queryParameters.WhereClause = $"wonum='{wo.Id}'";

            }
            else
            {
                queryParameters.WhereClause = $"wonum='{wo.wonum}'";
            }
           
            if(layer != null)
            {
                FeatureQueryResult features = await featureTable.QueryFeaturesAsync(queryParameters);

                foreach (var feature in features)
                {
                    feature.Attributes["STATUS"] = NewStatus;
                    featureTable.UpdateFeatureAsync(feature);
                }
            }
            

            wo.completed = true;

            MaximoServiceLibrary.AppContext.workOrderRepository.upsert(wo);

            Close();
            WorkOrderDetailVM.Cancel();
            WorkOrderDetailVM.MapVM.WorkOrderListVM.Update();

        }

        public void Cancel()
        {
            Close();
        }

        public void Close()
        {
            foreach (var window in ((App)Application.Current).Windows)
            {
                if (window is View.CompleteWorkOrder)
                {
                    ((View.CompleteWorkOrder)window).Close();
                }
            }
        }

        public List<MaximoWorkOrder> generateFollowUps(MaximoWorkOrder wo)
        {
            List<MaximoWorkOrder> followups = new List<MaximoWorkOrder>();
            if (wo.workorderspec == null || wo.workorderspec.Count == 0)
            {
                return followups;
            }


            switch (wo.worktype)
            {
                case "CM":
                    // no follow up
                    break;
                case "PM":

                    if (wo.status == "HOLD" && wo.problemcode == "NOTFOUND" && (wo.assetnum != null && wo.assetnum != ""))
                    {
                        if (wo.description != "Newly Discovered Asset cleaned by CB Cleaning Crew" ||
                            wo.description != "CB cleaned by CB Cleaning Crew" ||
                            wo.description != "New Asset cleaned by CB Cleaning Crew")
                        {
                            followups.Add(CBINVCNL(wo));
                        }

                    }

                    if (wo.status == "COMP")
                    {
                        if ((wo.asset != null && wo.asset.assettag.First() == 'N') && (wo.description == "Newly Discovered Asset cleaned by CB Cleaning Crew" || wo.description == "New Asset cleaned by CB Cleaning Crew"))
                        {
                            followups.Add(CBINVNOID(wo));
                        }

                        foreach (MaximoWorkOrderSpec spec in wo.workorderspec)
                        {
                            if (spec.alnvalue == "Y")
                            {
                                switch (spec.assetattrid)
                                {

                                    case "CBFUBT":
                                        followups.Add(CBEMFUBT(wo));
                                        break;
                                    case "CBFUCCTV":
                                        followups.Add(CBCMFUCCTV(wo));
                                        break;
                                    case "CBFUFAG":
                                        followups.Add(CBCMFUFAG(wo));
                                        break;
                                    case "CBFUJB":
                                        followups.Add(CBCMFUJB(wo));
                                        break;
                                    case "CBFUMC":
                                        followups.Add(CBCMFUMC(wo));
                                        break;
                                    case "CBFUML":
                                        followups.Add(CBEMFUML(wo));
                                        break;
                                    case "CBFUNCB":
                                        followups.Add(CBCMFUNCB(wo));
                                        break;
                                    case "CBFUNM":
                                        followups.Add(CBCMFUNM(wo));
                                        break;
                                    case "CBFUOSID":
                                        followups.Add(CBEMFUOSID(wo));
                                        break;
                                    case "CBFUTNR":
                                        followups.Add(CBEMFUTNR(wo));
                                        break;
                                    case "CBFUTR":
                                        followups.Add(CBCMFUTR(wo));
                                        break;
                                    case "CBFUVAC":
                                        followups.Add(CBPMFUVAC(wo));
                                        break;
                                    case "CBFUWNR":
                                        followups.Add(CBCMFUWNR(wo));
                                        break;
                                }
                            }
                        }
                    }


                    break;
                case "INV":
                case "EMERG":
                    if (wo.status == "HOLD" && wo.problemcode == "NOTFOUND" && (wo.assetnum != null && wo.assetnum != ""))
                    {

                        followups.Add(CBINVCNL(wo));

                    }

                    if (wo.status == "COMP")
                    {
                        if ((wo.asset != null && wo.asset.assettag.First() == 'N'))
                        {

                            followups.Add(CBINVNOID(wo));
                        }

                        foreach (MaximoWorkOrderSpec spec in wo.workorderspec)
                        {
                            if (spec.alnvalue == "Y")
                            {
                                switch (spec.assetattrid)
                                {

                                    case "CBFUBT":
                                        followups.Add(CBEMFUBT(wo));
                                        break;
                                    case "CBFUCCTV":
                                        followups.Add(CBCMFUCCTV(wo));
                                        break;
                                    case "CBFUFAG":
                                        followups.Add(CBCMFUFAG(wo));
                                        break;
                                    case "CBFUJB":
                                        followups.Add(CBCMFUJB(wo));
                                        break;
                                    case "CBFUMC":
                                        followups.Add(CBCMFUMC(wo));
                                        break;
                                    case "CBFUML":
                                        followups.Add(CBEMFUML(wo));
                                        break;
                                    case "CBFUNCB":
                                        followups.Add(CBCMFUNCB(wo));
                                        break;
                                    case "CBFUNM":
                                        followups.Add(CBCMFUNM(wo));
                                        break;
                                    case "CBFUOSID":
                                        followups.Add(CBEMFUOSID(wo));
                                        break;
                                    case "CBFUTNR":
                                        followups.Add(CBEMFUTNR(wo));
                                        break;
                                    case "CBFUTR":
                                        followups.Add(CBCMFUTR(wo));
                                        break;
                                    case "CBFUVAC":
                                        followups.Add(CBPMFUVAC(wo));
                                        break;
                                    case "CBFUWNR":
                                        followups.Add(CBCMFUWNR(wo));
                                        break;
                                }
                            }
                        }
                    }

                    break;

                case "INSP":
                    switch (wo.description)
                    {
                        case "Newly Discovered Asset Inspected by DSS":

                            if (wo.asset == null)
                            {

                                followups.Add(CBINVNOID(wo));
                            }
                            break;
                        default:
                            if (wo.status == "CAN" && wo.problemcode == "NOTFOUND" && (wo.assetnum != null && wo.assetnum != ""))
                            {
                                followups.Add(CBINVCNL(wo));
                            }
                            break;
                    }



                    if (wo.status == "COMP")
                    {

                        foreach (MaximoWorkOrderSpec spec in wo.workorderspec)
                        {
                            if (spec.alnvalue == "Y")
                            {
                                switch (spec.assetattrid)
                                {



                                    case "CBFUBT":
                                        followups.Add(CBEMFUBT(wo));
                                        break;
                                    case "CBFUCCTV":
                                        followups.Add(CBCMFUCCTV(wo));
                                        break;
                                    case "CBFUFAG":
                                        followups.Add(CBCMFUFAG(wo));
                                        break;
                                    case "CBFUJB":
                                        followups.Add(CBCMFUJB(wo));
                                        break;
                                    case "CBFUMC":
                                        followups.Add(CBCMFUMC(wo));
                                        break;
                                    case "CBFUML":
                                        followups.Add(CBEMFUML(wo));
                                        break;
                                    case "CBFUNCB":
                                        followups.Add(CBCMFUNCB(wo));
                                        break;
                                    case "CBFUNM":
                                        followups.Add(CBCMFUNM(wo));
                                        break;
                                    case "CBFUOSID":
                                        followups.Add(CBEMFUOSID(wo));
                                        break;
                                    case "CBFUTNR":
                                        followups.Add(CBEMFUTNR(wo));
                                        break;
                                    case "CBFUTR":
                                        followups.Add(CBCMFUTR(wo));
                                        break;
                                    case "CBFUVAC":
                                        followups.Add(CBPMFUVAC(wo));
                                        break;
                                    case "CBFUWNR":
                                        followups.Add(CBCMFUWNR(wo));
                                        break;
                                }
                            }

                            if (spec.alnvalue == "100" || spec.alnvalue == "75" || spec.alnvalue == "50")
                            {
                                if (spec.assetattrid == "CBBCSTATUS")
                                {
                                    followups.Add(CBPM(wo));
                                }
                            }
                        }
                    }


                    break;




            }


            return followups;
        }


        public MaximoWorkOrder CBINVNOID(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "New Asset Discovered by CB Cleaning Crew";
            fwo.status = "WAPPR";
            fwo.worktype = "INV";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "NEWASSET";
            fwo.persongroup = "DETS_INV";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBINVNOID";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBINVCNL(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "CB could not be located by Cleaning Crew";
            fwo.status = "WAPPR";
            fwo.worktype = "INV";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "NOTFOUND";
            fwo.persongroup = "DETS_INV";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBINVCNL";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBEMFUBT(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Broken Top";
            fwo.status = "WAPPR";
            fwo.worktype = "EM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "BROKEN";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SX";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBEMFUBT";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBCMFUCCTV(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - CCTV";
            fwo.status = "WAPPR";
            fwo.worktype = "CM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";
            fwo.origproblemtype = "SY";

            fwo.problemcode = "CLOG";
            fwo.persongroup = "S_CCTV";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SY";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBCMFUCCTV";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBCMFUFAG(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Flush Alley Grate";
            fwo.status = "WAPPR";
            fwo.worktype = "CM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "CLOG";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SY";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBCMFUFAG";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBCMFUJB(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Jetting/Blown";
            fwo.status = "WAPPR";
            fwo.worktype = "CM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "CLOG";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SY";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBCMFUJB";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }


        public MaximoWorkOrder CBCMFUMC(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Manual Cleaning";
            fwo.status = "WAPPR";
            fwo.worktype = "CM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "CLOG";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SY";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBCMFUMC";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBPMFUVAC(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Vacuuming";
            fwo.status = "WAPPR";
            fwo.worktype = "PM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "BROKEN";
            fwo.persongroup = "SS_CBF";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SY";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBPMFUVAC";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBEMFUML(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Missing Lid";
            fwo.status = "WAPPR";
            fwo.worktype = "EM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "BROKEN";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SX";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBEMFUML";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBCMFUNCB(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Needs Cheek Block";
            fwo.status = "WAPPR";
            fwo.worktype = "CM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "BROKEN";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SX";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBCMFUNCB";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBCMFUNM(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Needs Masonry";
            fwo.status = "WAPPR";
            fwo.worktype = "CM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "BROKEN";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SX";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBCMFUNM";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBEMFUOSID(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Oil Spill/Illegal Dumping";
            fwo.status = "WAPPR";
            fwo.worktype = "EM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "DUMPING";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SY";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBEMFUOSID";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBEMFUTNR(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Top Needs Reset";
            fwo.status = "WAPPR";
            fwo.worktype = "EM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "BROKEN";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "CG";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBEMFUTNR";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBCMFUTR(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Tree Roots";
            fwo.status = "WAPPR";
            fwo.worktype = "CM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "CLOG";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SY";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBCMFUTR";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBCMFUWNR(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - Walls Need Repaired";
            fwo.status = "WAPPR";
            fwo.worktype = "CM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";


            fwo.problemcode = "BROKEN";
            fwo.persongroup = "S_PS";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SX";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBCMFUWNR";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        public MaximoWorkOrder CBPM(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Inspection Follow Up - Clean";
            fwo.status = "WAPPR";
            fwo.worktype = "PM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";
            fwo.classstructureid = "1356";

            fwo.problemcode = "PM";

            fwo.failurereport = new List<MaximoWorkOrderFailureReport>();
            var pc = new MaximoWorkOrderFailureReport();
            pc.failurecode = "PM";
            pc.type = "PROBLEMCODE";
            pc.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;

            var c = new MaximoWorkOrderFailureReport();
            c.failurecode = "SCHD";
            c.type = "CAUSE";
            c.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;

            fwo.failurereport.Add(pc);
            fwo.failurereport.Add(c);

            fwo.persongroup = "SS_CBF";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SY";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBPM";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";

            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }

        // deprecated
        public MaximoWorkOrder CBPMWQJVAC(MaximoWorkOrder wo)
        {
            MaximoWorkOrder fwo = new MaximoWorkOrder();

            fwo.origrecordid = wo.wonum;


            fwo.description = "Catch Basin Follow Up - WQ CB JetVac Clean";
            fwo.status = "WAPPR";
            fwo.worktype = "PM";
            fwo.siteid = "DWS_DSS";
            fwo.service = "DSS";
            fwo.classstructureid = "1356";

            fwo.problemcode = "PM";

            fwo.failurereport = new List<MaximoWorkOrderFailureReport>();
            var pc = new MaximoWorkOrderFailureReport();
            pc.failurecode = "PM";
            pc.failurecode = "PM";
            pc.type = "PROBLEMCODE";
            pc.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;

            var c = new MaximoWorkOrderFailureReport();
            c.failurecode = "SCHD";
            c.type = "CAUSE";
            c.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;

            fwo.failurereport.Add(pc);
            fwo.failurereport.Add(c);
            // todo: ask end user (remedy)

            fwo.persongroup = "SS_CBF";
            fwo.assetnum = wo.assetnum;
            fwo.origrecordclass = "WORKORDER";
            fwo.origrecordid = wo.wonum;

            fwo.failurecode = "CATCHBASIN";
            fwo.origproblemtype = "SY";
            fwo.receivedvia = "F";
            fwo.wo1 = "CBPMWQJVAC";
            fwo.woclass = "WORKORDER";
            fwo.orgid = "DC_WASA";
            fwo.newchildclass = "WORKORDER";
            fwo.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            return fwo;
        }


    }

}
