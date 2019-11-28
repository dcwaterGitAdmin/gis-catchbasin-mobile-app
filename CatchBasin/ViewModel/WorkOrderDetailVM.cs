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
    class WorkOrderDetailVM : BaseVM
    {
        private MapVM mapVM;

        public MapVM MapVM
        {
            get { return mapVM; }
            set { mapVM = value; OnPropertyChanged("MapVM"); }
        }

        private bool workorderIsVisible;

        public bool WorkorderIsVisible
        {
            get { return workorderIsVisible; }
            set { workorderIsVisible = value; OnPropertyChanged("WorkorderIsVisible"); }
        }


        private string workorder;

        public string WorkOrder
        {
            get { return workorder; }
            set { workorder = value; OnPropertyChanged("WorkOrder"); }
        }


        private bool descriptionIsVisible;

        public bool DescriptionIsVisible
        {
            get { return descriptionIsVisible; }
            set { descriptionIsVisible = value; OnPropertyChanged("DescriptionIsVisible"); }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private bool dumpEstIsVisible;

        public bool DumpEstIsVisible
        {
            get { return dumpEstIsVisible; }
            set { dumpEstIsVisible = value; OnPropertyChanged("DumpEstIsVisible"); }
        }

        private double dumpEst;

        public double DumpEst
        {
            get { return dumpEst; }
            set { dumpEst = value; OnPropertyChanged("DumpEst"); }
        }
        
        private bool locationIsVisible;

        public bool LocationIsVisible
        {
            get { return locationIsVisible; }
            set { locationIsVisible = value; OnPropertyChanged("LocationIsVisible"); }
        }
        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; OnPropertyChanged("Location"); }
        }

        private bool contactIsVisible;

        public bool ContactIsVisible
        {
            get { return contactIsVisible; }
            set { contactIsVisible = value; OnPropertyChanged("ContactIsVisible"); }
        }

        private string contact;

        public string Contact
        {
            get { return contact; }
            set { contact = value; OnPropertyChanged("Contact"); }
        }
        
        private bool phoneIsVisible;

        public bool PhoneIsVisible
        {
            get { return phoneIsVisible; }
            set { phoneIsVisible = value; OnPropertyChanged("PhoneIsVisible"); }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged("Phone"); }
        }

        private bool assetTagIsVisible;

        public bool AssetTagIsVisible
        {
            get { return assetTagIsVisible; }
            set { assetTagIsVisible = value; OnPropertyChanged("assetTagIsVisible"); }
        }

        private bool needAssetHelper;

        public bool NeedAssetHelper
        {
            get { return needAssetHelper; }
            set { needAssetHelper = value; OnPropertyChanged("NeedAssetHelper"); }
        }


        private string assetTag;

        public string AssetTag
        {
            get { return assetTag; }
            set { assetTag = value; OnPropertyChanged("AssetTag"); }
        }

       
        private bool problemIsVisible;

        public bool ProblemIsVisible
        {
            get { return problemIsVisible; }
            set { problemIsVisible = value; OnPropertyChanged("ProblemIsVisible"); }
        }

        private string problem;

        public string Problem
        {
            get { return problem; }
            set { problem = value; OnPropertyChanged("Problem"); SetCauseList(); }
        }
        private bool causeIsVisible;

        public bool CauseIsVisible
        {
            get { return causeIsVisible; }
            set { causeIsVisible = value; OnPropertyChanged("CauseIsVisible"); SetRemedyList(); }
        }


        private string cause;

        public string Cause
        {
            get { return cause; }
            set { cause = value; OnPropertyChanged("Cause"); }
        }
        private bool remedyIsVisible;

        public bool RemedyIsVisible
        {
            get { return remedyIsVisible; }
            set { remedyIsVisible = value; OnPropertyChanged("RemedyIsVisible"); }
        }
        private string remedy;

        public string Remedy
        {
            get { return remedy; }
            set { remedy = value; OnPropertyChanged("Remedy"); }
        }
        private bool statusIsVisible;

        public bool StatusIsVisible
        {
            get { return statusIsVisible; }
            set { statusIsVisible = value; OnPropertyChanged("StatusIsVisible"); }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }
        private bool brokenTopIsVisible;

        public bool BrokenTopIsVisible
        {
            get { return brokenTopIsVisible; }
            set { brokenTopIsVisible = value; OnPropertyChanged("BrokenTopIsVisible"); }
        }
        private bool brokenTop;

        public bool BrokenTop
        {
            get { return brokenTop; }
            set { brokenTop = value; OnPropertyChanged("BrokenTop"); }
        }
        private bool cctvIsVisible;

        public bool CCTVIsVisible
        {
            get { return cctvIsVisible; }
            set { cctvIsVisible = value; OnPropertyChanged("CCTVIsVisible"); }
        }
        private bool cctv;

        public bool CCTV
        {
            get { return cctv; }
            set { cctv = value; OnPropertyChanged("CCTV"); }
        }
        private bool flushAlleyGrateIsVisible;

        public bool FlushAlleyGrateIsVisible
        {
            get { return flushAlleyGrateIsVisible; }
            set { flushAlleyGrateIsVisible = value; OnPropertyChanged("FlushAlleyGrateIsVisible"); }
        }
        private bool flushAlleyGrate;

        public bool FlushAlleyGrate
        {
            get { return flushAlleyGrate; }
            set { flushAlleyGrate = value; OnPropertyChanged("FlushAlleyGrate"); }
        }
        private bool jettingBlownIsVisible;

        public bool JettingBlownIsVisible
        {
            get { return jettingBlownIsVisible; }
            set { jettingBlownIsVisible = value; OnPropertyChanged("JettingBlownIsVisible"); }
        }
        private bool jettingBlown;

        public bool JettingBlown
        {
            get { return jettingBlown; }
            set { jettingBlown = value; OnPropertyChanged("JettingBlown"); }
        }
        private bool manualCleaningIsVisible;

        public bool ManualCleaningIsVisible
        {
            get { return manualCleaningIsVisible; }
            set { manualCleaningIsVisible = value; OnPropertyChanged("ManualCleaningIsVisible"); }
        }
        private bool manualCleaning;

        public bool ManualCleaning
        {
            get { return manualCleaning; }
            set { manualCleaning = value; OnPropertyChanged("ManualCleaning"); }
        }
        private bool missingLidIsVisible;

        public bool MissingLidIsVisible
        {
            get { return missingLidIsVisible; }
            set { missingLidIsVisible = value; OnPropertyChanged("MissingLidIsVisible"); }
        }
        private bool missingLid;

        public bool MissingLid
        {
            get { return missingLid; }
            set { missingLid = value; OnPropertyChanged("MissingLid"); }
        }
        private bool needsCheckBlockIsVisible;

        public bool NeedsCheckBlockIsVisible
        {
            get { return needsCheckBlockIsVisible; }
            set { needsCheckBlockIsVisible = value; OnPropertyChanged("NeedsCheckBlockIsVisible"); }
        }
        private bool needsCheckBlock;

        public bool NeedsCheckBlock
        {
            get { return needsCheckBlock; }
            set { needsCheckBlock = value; OnPropertyChanged("NeedsCheckBlock"); }
        }
        private bool needsMasonryIsVisible;

        public bool NeedsMasonryIsVisible
        {
            get { return needsMasonryIsVisible; }
            set { needsMasonryIsVisible = value; OnPropertyChanged("NeedsMasonryIsVisible"); }
        }
        private bool needsMasonry;

        public bool NeedsMasonry
        {
            get { return needsMasonry; }
            set { needsMasonry = value; OnPropertyChanged("NeedsMasonry"); }
        }
        private bool oilSpillIsVisible;

        public bool OilSpillIsVisible
        {
            get { return oilSpillIsVisible; }
            set { oilSpillIsVisible = value; OnPropertyChanged("OilSpillIsVisible"); }
        }
        private bool oilSpill;

        public bool OilSpill
        {
            get { return oilSpill; }
            set { oilSpill = value; OnPropertyChanged("OilSpill"); }
        }
        private bool topNeedsResetIsVisible;

        public bool TopNeedsResetIsVisible
        {
            get { return topNeedsResetIsVisible; }
            set { topNeedsResetIsVisible = value; OnPropertyChanged("TopNeedsResetIsVisible"); }
        }
        private bool topNeedsReset;

        public bool TopNeedsReset
        {
            get { return topNeedsReset; }
            set { topNeedsReset = value; OnPropertyChanged("TopNeedsReset"); }
        }
        private bool treeRootsIsVisible;

        public bool TreeRootsIsVisible
        {
            get { return treeRootsIsVisible; }
            set { treeRootsIsVisible = value; OnPropertyChanged("TreeRootsIsVisible"); }
        }
        private bool treeRoots;

        public bool TreeRoots
        {
            get { return treeRoots; }
            set { treeRoots = value; OnPropertyChanged("TreeRoots"); }
        }
        private bool vacuumingIsVisible;

        public bool VacuumingIsVisible
        {
            get { return vacuumingIsVisible; }
            set { vacuumingIsVisible = value; OnPropertyChanged("VacuumingIsVisible"); }
        }
        private bool vacuuming;

        public bool Vacuuming
        {
            get { return vacuuming; }
            set { vacuuming = value; OnPropertyChanged("Vacuuming"); }
        }
        private bool wallsNeedRepairIsVisible;

        public bool WallsNeedRepairIsVisible
        {
            get { return wallsNeedRepairIsVisible; }
            set { wallsNeedRepairIsVisible = value; OnPropertyChanged("WallsNeedRepairIsVisible"); }
        }
        private bool wallsNeedRepair;

        public bool WallsNeedRepair
        {
            get { return wallsNeedRepair; }
            set { wallsNeedRepair = value; OnPropertyChanged("WallsNeedRepair"); }
        }
        private bool remarksIsVisible;

        public bool RemarksIsVisible
        {
            get { return remarksIsVisible; }
            set { remarksIsVisible = value; OnPropertyChanged("RemarksIsVisible"); }
        }
        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; OnPropertyChanged("Remarks"); }
        }


        private bool attachmentsIsVisible;

        public bool AttachmentsIsVisible
        {
            get { return attachmentsIsVisible; }
            set { attachmentsIsVisible = value; OnPropertyChanged("AttachmentsIsVisible"); }
        }

        // todo: object to doclinks or docinfo
        private List<object> attachments;

        public List<object> Attachments
        {
            get { return attachments; }
            set { attachments = value; OnPropertyChanged("Attachments"); }
        }


        private bool actualsIsVisible;

        public bool ActualsIsVisible
        {
            get { return actualsIsVisible; }
            set { actualsIsVisible = value; OnPropertyChanged("ActualsIsVisible"); }
        }

        // todo: object to doclinks or docinfo
        private List<object> actuals;

        public List<object> Actuals
        {
            get { return actuals; }
            set { actuals = value; OnPropertyChanged("Actuals"); }
        }

        private Command.ShowAssetCommand showAssetCommand;

        public Command.ShowAssetCommand ShowAssetCommand
        {
            get { return showAssetCommand; }
            set { showAssetCommand = value; }
        }

        private Command.CreateAssetOnMapCommand createAssetOnMapCommand;

        public Command.CreateAssetOnMapCommand CreateAssetOnMapCommand
        {
            get { return createAssetOnMapCommand; }
            set { createAssetOnMapCommand = value; }
        }


        private Command.SelectAssetOnMapCommand selectAssetOnMapCommand;

        public Command.SelectAssetOnMapCommand SelectAssetOnMapCommand
        {
            get { return selectAssetOnMapCommand; }
            set { selectAssetOnMapCommand = value; }
        }
        private Command.CancelWorkOrderCommand cancelWorkOrderCommand;

        public Command.CancelWorkOrderCommand CancelWorkOrderCommand
        {
            get { return cancelWorkOrderCommand; }
            set { cancelWorkOrderCommand = value; }
        }
        private Command.SaveWorkOrderCommand saveWorkOrderCommand;

        public Command.SaveWorkOrderCommand SaveWorkOrderCommand
        {
            get { return saveWorkOrderCommand; }
            set { saveWorkOrderCommand = value; }
        }

        private List<FailureCode> problemList;

        public List<FailureCode> ProblemList
        {
            get { return problemList; }
            set { problemList = value; OnPropertyChanged("ProblemList"); }
        }
        private List<FailureCode> causeList;

        public List<FailureCode> CauseList
        {
            get { return causeList; }
            set { causeList = value; OnPropertyChanged("CauseList"); }
        }
        private List<FailureCode> remedyList;

        public List<FailureCode> RemedyList
        {
            get { return remedyList; }
            set { remedyList = value; OnPropertyChanged("RemedyList"); }
        }

        private List<SYNONYMDOMAIN> statusList;

        public List<SYNONYMDOMAIN> StatusList
        {
            get { return statusList; }
            set { statusList = value; OnPropertyChanged("StatusList"); }
        }


        public MaximoWorkOrder MaximoWorkOrder;

        public bool isDirty;
        public MaximoServiceLibraryBeanConfiguration MaximoServiceLibraryBeanConfiguration;

        public WorkOrderDetailVM(MapVM _mapVM)
        {
            PropertyChanged += WorkOrderDetailVM_PropertyChanged;
            MaximoServiceLibraryBeanConfiguration = new MaximoServiceLibraryBeanConfiguration();
            MapVM = _mapVM;
            ShowAssetCommand = new Command.ShowAssetCommand(this);
            SelectAssetOnMapCommand = new Command.SelectAssetOnMapCommand(this);
            CreateAssetOnMapCommand = new Command.CreateAssetOnMapCommand(this);
            CancelWorkOrderCommand = new Command.CancelWorkOrderCommand(this);
            SaveWorkOrderCommand = new Command.SaveWorkOrderCommand(this);

            ProblemList = MaximoServiceLibraryBeanConfiguration.failureListRepository.Find("type", "PROBLEM").Select(x => x.failurecode[0]).ToList<FailureCode>();



            StatusList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("WOSTATUS").synonymdomain;
            // Status
        }

        private void WorkOrderDetailVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            isDirty = true;
        }

        public void Update(MaximoWorkOrder wo)
        {
            Clear();
            if (wo == null)
            {
                return;
            }

            MaximoWorkOrder = wo;
            //todo : find actuals
            //todo : find attachments

            WorkOrder = MaximoWorkOrder.wonum;
            Description = MaximoWorkOrder.description;
            Location = MaximoWorkOrder.location;
            Contact = MaximoWorkOrder.wolo4;
            Phone = MaximoWorkOrder.wolo2;
            AssetTag = MaximoWorkOrder.asset?.assettag;
            Remarks = MaximoWorkOrder.failureRemark?.description;
            
            Status = MaximoWorkOrder.status;

            // todo : make test!
            Problem = MaximoWorkOrder.problemcode;
            if (MaximoWorkOrder.failureReportList.Count > 1)
            {
                Cause = MaximoWorkOrder.failureReportList[1].failurecode;
            }
            if (MaximoWorkOrder.failureReportList.Count > 2)
            {
                Remedy = MaximoWorkOrder.failureReportList[2].failurecode;
            }
           

            foreach (var workOrderSpec in MaximoWorkOrder.workorderspecList ?? new List<MaximoWorkOrderSpec>())
            {
                switch (workOrderSpec.assetattrid)
                {
                    case "CBDUMPEST":
                        DumpEst = Convert.ToDouble(workOrderSpec.numvalue) ;
                        break;
                    case "CBFUBT":
                        BrokenTop = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUCCTV":
                        CCTV = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUFAG":
                        FlushAlleyGrate = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUJB":
                        JettingBlown = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUMC":
                        ManualCleaning = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUML":
                        MissingLid = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUNCB":
                        NeedsCheckBlock = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUNM":
                        NeedsMasonry = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUOSID":
                        OilSpill = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUTNR":
                        TopNeedsReset = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUTR":
                        TreeRoots = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUVAC":
                        Vacuuming = workOrderSpec.alnvalue == "Y";
                        break;
                    case "CBFUWNR":
                        WallsNeedRepair = workOrderSpec.alnvalue == "Y";
                        break;
                    
          
                }
            }
           

            // todo:
            // Remarks
            // Cause
            // Remedy



            Show();
            isDirty = false;
        }

        public void Save()
        {
            isDirty = false;
            MapVM.HideWorkOrderDetail();
        }

        public void Cancel()
        {
            if (isDirty)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Workorder was modified. Discard Changes?", "Workorder :" + MaximoWorkOrder.wonum, MessageBoxButton.YesNo,MessageBoxImage.Warning);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    MapVM.HideWorkOrderDetail();
                }
                else if (messageBoxResult == MessageBoxResult.No)
                {
                    Save();
                   
                }
            }
        }

        public void Clear()
        {
            MaximoWorkOrder = null;
            Attachments = null;
            Actuals = null;
            Hide();

        }

        private void Hide()
        {
            WorkorderIsVisible = false;
            DescriptionIsVisible = false;
            DumpEstIsVisible = false;
            LocationIsVisible = false;
            ContactIsVisible = false;
            PhoneIsVisible = false;
            NeedAssetHelper = false;
            AssetTagIsVisible = false;
            ProblemIsVisible = false;
            CauseIsVisible = false;
            RemedyIsVisible = false;
            StatusIsVisible = false;
            ActualsIsVisible = false;
            AttachmentsIsVisible = false;
            BrokenTopIsVisible = false;
            CCTVIsVisible = false;
            FlushAlleyGrateIsVisible = false;
            JettingBlownIsVisible = false;
            ManualCleaningIsVisible = false;
            MissingLidIsVisible = false;
            NeedsCheckBlockIsVisible = false;
            NeedsMasonryIsVisible = false;
            OilSpillIsVisible = false;
            TopNeedsResetIsVisible = false;
            TreeRootsIsVisible = false;
            VacuumingIsVisible = false;
            WallsNeedRepairIsVisible = false;
            RemarksIsVisible = false;
        }

        private void Show()
        {

            Hide();
            
            WorkorderIsVisible = true;
            DescriptionIsVisible = true;
            ProblemIsVisible = true;
            CauseIsVisible = true;
            RemedyIsVisible = true;
            StatusIsVisible = true;
            ActualsIsVisible = true;
            AttachmentsIsVisible = true;
            RemarksIsVisible = true;

            switch (MaximoWorkOrder.worktype)
            {
                case "CM":
                    DumpEstIsVisible = true;
                    break;
                case "EMERG":
                case "INV" :
                    LocationIsVisible = true;
                    ContactIsVisible = true;
                    PhoneIsVisible = true;
                    
                    AssetTagIsVisible = true;
                    NeedAssetHelper = true;
                    BrokenTopIsVisible = true;
                    CCTVIsVisible = true;
                    FlushAlleyGrateIsVisible = true;
                    JettingBlownIsVisible = true;
                    ManualCleaningIsVisible = true;
                    MissingLidIsVisible = true;
                    NeedsCheckBlockIsVisible = true;
                    NeedsMasonryIsVisible = true;
                    OilSpillIsVisible = true;
                    TopNeedsResetIsVisible = true;
                    TreeRootsIsVisible = true;
                    VacuumingIsVisible = true;
                    WallsNeedRepairIsVisible = true;
                    break;
                case "PM":
                    AssetTagIsVisible = true;
                    BrokenTopIsVisible = true;
                    CCTVIsVisible = true;
                    FlushAlleyGrateIsVisible = true;
                    JettingBlownIsVisible = true;
                    ManualCleaningIsVisible = true;
                    MissingLidIsVisible = true;
                    NeedsCheckBlockIsVisible = true;
                    NeedsMasonryIsVisible = true;
                    OilSpillIsVisible = true;
                    TopNeedsResetIsVisible = true;
                    TreeRootsIsVisible = true;
                    VacuumingIsVisible = true;
                    WallsNeedRepairIsVisible = true;
                    break;
                
               
            }
            
        }

        public void ShowAssetDetail()
        {
            MapVM.ShowAssetDetail(MaximoWorkOrder);
        }

        public void SetCauseList()
        {
            if(Problem != null)
            {
                RemedyList = null;
                var selectedProblem = MaximoServiceLibraryBeanConfiguration.failureListRepository.Find("failurecode[0].failurecode", Problem).ToArray()[0];

                CauseList = MaximoServiceLibraryBeanConfiguration.failureListRepository.Find("parent", selectedProblem.failurelist).Select(x => x.failurecode[0]).ToList<FailureCode>();

            }

        }

        public void SetRemedyList()
        {
            if(Cause != null)
            {
                var selectedCause = MaximoServiceLibraryBeanConfiguration.failureListRepository.Find("failurecode[0].failurecode", Cause).ToArray()[0];

                RemedyList = MaximoServiceLibraryBeanConfiguration.failureListRepository.Find("parent", selectedCause.failurelist).Select(x => x.failurecode[0]).ToList<FailureCode>();

            }

        }
    }
}
