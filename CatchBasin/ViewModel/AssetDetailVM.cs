using CatchBasin.ViewModel.Helper;
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
    class AssetDetailVM :BaseVM, Helper.IDetailVM
    {
        private WorkOrderDetailVM workOrderDetailVM;

        public WorkOrderDetailVM WorkOrderDetailVM
        {
            get { return workOrderDetailVM; }
            set { workOrderDetailVM = value;  OnPropertyChanged("WorkOrderDetailVM");}
        }

        private string assetTag;

        public string AssetTag
        {
            get { return assetTag; }
            set { assetTag = value;  OnPropertyChanged("AssetTag");}
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value;  OnPropertyChanged("Type");}
        }
        private string topMaterial;

        public string TopMaterial
        {
            get { return topMaterial; }
            set { topMaterial = value;  OnPropertyChanged("TopMaterial");}
        }
        private int? topThickness;

        public int? TopThickness
        {
            get { return topThickness; }
            set { topThickness = value;  OnPropertyChanged("TopThickness");}
        }
        private string grateType;

        public string GrateType
        {
            get { return grateType; }
            set { grateType = value;  OnPropertyChanged("GrateType");}
        }
        private int? numberOfChambers;

        public int? NumberOfChambers
        {
            get { return numberOfChambers; }
            set { numberOfChambers = value;  OnPropertyChanged("NumberOfChambers");}
        }
        private int? numberOfThroats;

        public int? NumberOfThroats
        {
            get { return numberOfThroats; }
            set { numberOfThroats = value;  OnPropertyChanged("NumberOfThroats");}
        }
        private string locationDetail;

        public string LocationDetail
        {
            get { return locationDetail; }
            set { locationDetail = value;  OnPropertyChanged("LocationDetail");}
        }

        private string owner;

        public string Owner
        {
            get { return owner; }
            set { owner = value;  OnPropertyChanged("Owner");}
        }
        private string cleaningResponsibility;

        public string CleaningResponsibility
        {
            get { return cleaningResponsibility; }
            set { cleaningResponsibility = value;  OnPropertyChanged("CleaningResponsibility");}
        }
        private bool? waterQuality;

        public bool? WaterQuality
        {
            get { return waterQuality; }
            set { waterQuality = value;  OnPropertyChanged("WaterQuality");}
        }
        private bool? inMS4;

        public bool? InMS4
        {
            get { return inMS4; }
            set { inMS4 = value;  OnPropertyChanged("InMS4");}
        }

        private bool? cornerCB;

        public bool? CornerCB
        {
            get { return cornerCB; }
            set { cornerCB = value;  OnPropertyChanged("CornerCB");}
        }
        private bool? biofilter;

        public bool? Biofilter
        {
            get { return biofilter; }
            set { biofilter = value;  OnPropertyChanged("Biofilter");}
        }
        private string flowRestrictorType;

        public string FlowRestrictorType
        {
            get { return flowRestrictorType; }
            set { flowRestrictorType = value;  OnPropertyChanged("FlowRestrictorType");}
        }
        private bool? sump;

        public bool? Sump
        {
            get { return sump; }
            set { sump = value;  OnPropertyChanged("Sump");}
        }
        private bool? waterSeal;

        public bool? WaterSeal
        {
            get { return waterSeal; }
            set { waterSeal = value;  OnPropertyChanged("WaterSeal");}
        }

        private List<ALNDOMAINVALUE> typeList;

        public List<ALNDOMAINVALUE> TypeList
        {
            get { return typeList; }
            set { typeList = value;  OnPropertyChanged("TypeList");}
        }

        private List<ALNDOMAINVALUE> topMaterialList;

        public List<ALNDOMAINVALUE> TopMaterialList
        {
            get { return topMaterialList; }
            set { topMaterialList = value;  OnPropertyChanged("TopMaterialList");}
        }

        private List<NUMDOMAINVALUE> topThicknessList;

        public List<NUMDOMAINVALUE> TopThicknessList
        {
            get { return topThicknessList; }
            set { topThicknessList = value;  OnPropertyChanged("TopThicknessList");}
        }

        private List<ALNDOMAINVALUE> grateTypeList;

        public List<ALNDOMAINVALUE> GrateTypeList
        {
            get { return grateTypeList; }
            set { grateTypeList = value;  OnPropertyChanged("GrateTypeList");}
        }

        private List<ALNDOMAINVALUE> ownerList;

        public List<ALNDOMAINVALUE> OwnerList
        {
            get { return ownerList; }
            set { ownerList = value;  OnPropertyChanged("OwnerList");}
        }

        private List<ALNDOMAINVALUE> cleaningResponsibilityList;

        public List<ALNDOMAINVALUE> CleaningResponsibilityList
        {
            get { return cleaningResponsibilityList; }
            set { cleaningResponsibilityList = value;  OnPropertyChanged("CleaningResponsibilityList");}
        }

        private List<StaticDomain> flowRestrictorTypeList;

        public List<StaticDomain> FlowRestrictorTypeList
        {
            get { return flowRestrictorTypeList; }
            set { flowRestrictorTypeList = value;  OnPropertyChanged("FlowRestrictorTypeList");}
        }

        private Command.CancelCommand<AssetDetailVM> cancelCommand;

        public Command.CancelCommand<AssetDetailVM> CancelCommand
        {
            get { return cancelCommand; }
            set { cancelCommand = value; OnPropertyChanged("CancelCommand"); }
        }
        private Command.SaveCommand<AssetDetailVM> saveCommand;

        public Command.SaveCommand<AssetDetailVM> SaveCommand
        {
            get { return saveCommand; }
            set { saveCommand = value; OnPropertyChanged("SaveCommand"); }
        }

		private string syncStatus;

		public string SyncStatus
		{
			get { return syncStatus; }
			set { syncStatus = value; OnPropertyChanged("SyncStatus"); }
		}


		private bool isDirty;
        MaximoAsset Asset;
        public MaximoServiceLibraryBeanConfiguration MaximoServiceLibraryBeanConfiguration;

        public AssetDetailVM(WorkOrderDetailVM _workOrderDetailVM)
        {
            PropertyChanged += AssetDetailVM_PropertyChanged;
            WorkOrderDetailVM = _workOrderDetailVM;
            
            MaximoServiceLibraryBeanConfiguration = new MaximoServiceLibraryBeanConfiguration();

            
            TypeList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("CB_SUBT").alndomain;
            TopMaterialList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("CBTOPMATRL").alndomain;
            TopThicknessList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("CBTOPTHICK").numericdomain;
            GrateTypeList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("CBGRATETYPE").alndomain;
            OwnerList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("OWNER").alndomain;
            CleaningResponsibilityList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("CLNRESP").alndomain;

            FlowRestrictorTypeList = new List<StaticDomain>();
            FlowRestrictorTypeList.Add(new StaticDomain("ORIFICE", "Orifice"));
            FlowRestrictorTypeList.Add(new StaticDomain("BAFFLE", "Baffle"));
            FlowRestrictorTypeList.Add(new StaticDomain("WEIR", "Weir"));
            FlowRestrictorTypeList.Add(new StaticDomain("OTHER", "Other"));

            SaveCommand = new Command.SaveCommand<AssetDetailVM>(this);
            CancelCommand = new Command.CancelCommand<AssetDetailVM>(this);
        }

        private void AssetDetailVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            isDirty = true;
        }

        public void Update(MaximoAsset asset)
        {
            Asset = asset;

			SyncStatus = Asset.syncronizationStatus.ToString();

			AssetTag = Asset.assettag;
            LocationDetail = Asset.eq3;

            foreach (MaximoAssetSpec assetSpec in Asset.assetspec)
            {
                switch (assetSpec.assetattrid)
                {
                    case "CB_SUBT":
                        Type = assetSpec.alnvalue;
                        break;
                    case "TOPMATRL":
                        TopMaterial = assetSpec.alnvalue;
                        break;
                    case "TOPTHICK":
                        TopThickness = Convert.ToInt32(assetSpec.numvalue);
                        break;
                    case "GRATETY":
                        GrateType = assetSpec.alnvalue;
                        break;
                    case "NUMCHAMB":
                        NumberOfChambers = Convert.ToInt32(assetSpec.numvalue);
                        break;
                    case "NUMTHROAT":
                        NumberOfThroats = Convert.ToInt32(assetSpec.numvalue);
                        break;
                    case "OWNER":
                        Owner = assetSpec.alnvalue;
                        break;
                    case "CLN_RESP":
                        CleaningResponsibility = assetSpec.alnvalue;
                        break;
                    case "WQ":
                        WaterQuality = assetSpec.alnvalue == "Y"; ;
                        break;
                    case "INMS4":
                        InMS4 = assetSpec.alnvalue == "Y"; ;
                        break;
                    case "ISCORNRCB":
                        CornerCB = assetSpec.alnvalue == "Y"; ;
                        break;
                    case "BIOFLTR":
                        Biofilter = assetSpec.alnvalue == "Y"; ;
                        break;
                    case "FLORESTY":
                        FlowRestrictorType = assetSpec.alnvalue;
                        break;
                    case "HASSUMP":
                        Sump = assetSpec.alnvalue == "Y"; ;
                        break;
                    case "HASWATERSEAL":
                        WaterSeal = assetSpec.alnvalue == "Y"; ;
                        break;
                       
                }
            }

            isDirty = false;
        }

        public void Clear()
        {
            Asset = null;
            AssetTag = null;
            LocationDetail = null;
            Type = null;
            TopMaterial = null;
            TopThickness = null;
            GrateType = null;
            NumberOfChambers = null;
            NumberOfThroats = null;
            Owner = null;
            CleaningResponsibility = null;
            WaterQuality = null;
            InMS4 = null;
            CornerCB = null;
            Biofilter = null;
            FlowRestrictorType = null;
            Sump = null;
            WaterSeal = null;

            isDirty = false;
        }

        public void Save()
        {
            Asset.eq3 = LocationDetail;

            for (int i = 0; i < Asset.assetspec.Count; i++)
            {
                switch (Asset.assetspec[i].assetattrid)
                {
                    case "CB_SUBT":
                        Asset.assetspec[i].alnvalue = Type;
                        break;
                    case "TOPMATRL":
                        Asset.assetspec[i].alnvalue = TopMaterial;
                        break;
                    case "TOPTHICK":
                        Asset.assetspec[i].numvalue = TopThickness;
                        break;
                    case "GRATETY":
                        Asset.assetspec[i].alnvalue = GrateType;
                        break;
                    case "NUMCHAMB":
                        Asset.assetspec[i].numvalue = NumberOfChambers;
                        break;
                    case "NUMTHROAT":
                        Asset.assetspec[i].numvalue = NumberOfThroats;
                        break;
                    case "OWNER":
                        Asset.assetspec[i].alnvalue = Owner;
                        break;
                    case "CLN_RESP":
                        Asset.assetspec[i].alnvalue = CleaningResponsibility;
                        break;
                    case "WQ":
                        Asset.assetspec[i].alnvalue = WaterQuality == true ? "Y" : "N";
                        break;
                    case "INMS4":
                        Asset.assetspec[i].alnvalue = InMS4 == true ? "Y" : "N";
                        break;
                    case "ISCORNRCB":
                        Asset.assetspec[i].alnvalue = CornerCB == true ? "Y" : "N";
                        break;
                    case "BIOFLTR":
                        Asset.assetspec[i].alnvalue = Biofilter == true ? "Y" : "N";
                        break;
                    case "FLORESTY":
                        Asset.assetspec[i].alnvalue = FlowRestrictorType;
                        break;
                    case "HASSUMP":
                        Asset.assetspec[i].alnvalue = Sump == true ? "Y" : "N";
                        break;
                    case "HASWATERSEAL":
                        Asset.assetspec[i].alnvalue = WaterSeal == true ? "Y" : "N";
                        break;

                }
            }

			Asset.changedate = DateTime.Now;
			Asset.changeby = ((App)Application.Current).MaximoServiceLibraryBeanConfiguration.maximoService.mxuser.personId;
			// asset maybe choosed or created on map!
            if (Asset.Id > 0){
                var asset =MaximoServiceLibraryBeanConfiguration.assetRepository.update(Asset);
                Asset = asset;
            }
            else
            {
				if(Asset.assetnum != null)
				{
					Asset.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
				}
				else
				{
					Asset.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				}
               
                MaximoServiceLibraryBeanConfiguration.assetRepository.insert(Asset);
            }
            isDirty = false;
            WorkOrderDetailVM.HideAssetDetail();
        }

        public void Cancel()
        {
            if (isDirty)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Asset was modified. Save Changes?", "Asset :" + Asset.assetnum, MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Save();
                }
                else if (messageBoxResult == MessageBoxResult.No)
                {
                    WorkOrderDetailVM.HideAssetDetail();

                }
            }
            else
            {
                WorkOrderDetailVM.HideAssetDetail();
            }
        }
    }


}
