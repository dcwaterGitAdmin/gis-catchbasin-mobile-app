using CatchBasin.ViewModel.Helper;
using Esri.ArcGISRuntime.Data;
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
        private double? topThickness;

        public double? TopThickness
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

	


		private bool isDirty;
        MaximoAsset Asset;
        MaximoWorkOrder WorkOrder;
        public AssetDetailVM(WorkOrderDetailVM _workOrderDetailVM)
        {
            PropertyChanged += AssetDetailVM_PropertyChanged;
            WorkOrderDetailVM = _workOrderDetailVM;

            
            TypeList = MaximoServiceLibrary.AppContext.domainRepository.findOne("CB_SUBT").alndomain;
            TopMaterialList = MaximoServiceLibrary.AppContext.domainRepository.findOne("CBTOPMATRL").alndomain;
            TopThicknessList = MaximoServiceLibrary.AppContext.domainRepository.findOne("CBTOPTHICK").numericdomain;
            GrateTypeList = MaximoServiceLibrary.AppContext.domainRepository.findOne("CBGRATETYPE").alndomain;
            OwnerList = MaximoServiceLibrary.AppContext.domainRepository.findOne("OWNER").alndomain;
            CleaningResponsibilityList = MaximoServiceLibrary.AppContext.domainRepository.findOne("CLNRESP").alndomain;

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

        public void Update(MaximoWorkOrder wo)
        {
            WorkOrder = wo;
            Asset = wo.asset;
			

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

        public async void Save()
        {
            Asset.eq3 = LocationDetail;

            for (int i = 0; i < Asset.assetspec.Count; i++)
            {
                switch (Asset.assetspec[i].assetattrid)
                {
                    case "CB_SUBT":
						if (Asset.assetspec[i].alnvalue != Type)
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = Type;
                        break;
                    case "TOPMATRL":
						if (Asset.assetspec[i].alnvalue != TopMaterial)
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = TopMaterial;
                        break;
                    case "TOPTHICK":
						if (Asset.assetspec[i].numvalue != TopThickness)
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].numvalue = TopThickness;
                        break;
                    case "GRATETY":
						if (Asset.assetspec[i].alnvalue != GrateType)
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = GrateType;
                        break;
                    case "NUMCHAMB":
						if (Asset.assetspec[i].numvalue != NumberOfChambers)
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].numvalue = NumberOfChambers;
                        break;
                    case "NUMTHROAT":
						if (Asset.assetspec[i].numvalue != NumberOfThroats)
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].numvalue = NumberOfThroats;
                        break;
                    case "OWNER":
						if (Asset.assetspec[i].alnvalue != Owner)
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = Owner;
                        break;
                    case "CLN_RESP":
						if (Asset.assetspec[i].alnvalue != CleaningResponsibility)
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = CleaningResponsibility;
                        break;
                    case "WQ":
						if (Asset.assetspec[i].alnvalue != (WaterQuality == true ? "Y" : "N"))
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = WaterQuality == true ? "Y" : "N";
                        break;
                    case "INMS4":
						if (Asset.assetspec[i].alnvalue != (InMS4 == true ? "Y" : "N"))
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = InMS4 == true ? "Y" : "N";
                        break;
                    case "ISCORNRCB":
						if (Asset.assetspec[i].alnvalue != (CornerCB == true ? "Y" : "N"))
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = CornerCB == true ? "Y" : "N";
                        break;
                    case "BIOFLTR":
						if (Asset.assetspec[i].alnvalue != (Biofilter == true ? "Y" : "N"))
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = Biofilter == true ? "Y" : "N";
                        break;
                    case "FLORESTY":
						if (Asset.assetspec[i].alnvalue != FlowRestrictorType)
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = FlowRestrictorType;
                        break;
                    case "HASSUMP":
						if (Asset.assetspec[i].alnvalue != (Sump == true ? "Y" : "N"))
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = Sump == true ? "Y" : "N";
                        break;
                    case "HASWATERSEAL":
						if (Asset.assetspec[i].alnvalue != (WaterSeal == true ? "Y" : "N"))
						{
							Asset.assetspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
						}
						Asset.assetspec[i].alnvalue = WaterSeal == true ? "Y" : "N";
                        break;

                }
            }

			Asset.changedate = DateTime.Now;
			Asset.changeby = MaximoServiceLibrary.AppContext.synchronizationService?.mxuser.personId;
            // asset maybe choosed or created on map!

            if (!String.IsNullOrEmpty(Asset.assetnum))
            {
                Asset.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
            }
            else
            {
                Asset.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
            }
            WorkOrder.asset = Asset;

            if(Asset.assettag.First() == 'N')
            {
                var layer = workOrderDetailVM.MapVM.assetLayer;
                QueryParameters queryParameters = new QueryParameters();
                queryParameters.WhereClause = $"ASSETTAG = '{Asset.assettag}'";

                var result =await layer.FeatureTable.QueryFeaturesAsync(queryParameters);
                var feature = result.FirstOrDefault();
                if(feature != null)
                {

                    switch (Type)
                    {
                        case "UNKNOWN":
                            feature.SetAttributeValue("SUBTYPE", 0);
                            break;
                        case "SINGLE":
                            
                            feature.SetAttributeValue("SUBTYPE", 1);
                            break;
                        case "DOUBLE":
                           
                            feature.SetAttributeValue("SUBTYPE", 2);
                            break;
                        case "TRIPLE":
                            
                            feature.SetAttributeValue("SUBTYPE", 3);
                            break;
                        case "GRATE":
                           
                            feature.SetAttributeValue("SUBTYPE", 4);
                            break;
                        case "QUADRUPLE":
                            
                            feature.SetAttributeValue("SUBTYPE", 5);
                            break;
                        case "ELONGATE":
                            
                            feature.SetAttributeValue("SUBTYPE", 6);
                            break;
                        case "DOUBLE GRATE":
                            
                            feature.SetAttributeValue("SUBTYPE", 7);
                            break;
                        case "FIELD DRAIN":
                           
                            feature.SetAttributeValue("SUBTYPE", 8);
                            break;
                        case "TRENCH DRAIN":
                           
                            feature.SetAttributeValue("SUBTYPE", 9);
                            break;

                        default:
                            feature.SetAttributeValue("SUBTYPE", 0);
                            break;
                    }
                    feature.SetAttributeValue("ASSETTAG", Asset.assettag);
                   
                    feature.SetAttributeValue("TOPMATRL", TopMaterial);
                    feature.SetAttributeValue("TOPTHICK", (int)TopThickness); 
                    feature.SetAttributeValue("GRATETY", GrateType);
                    feature.SetAttributeValue("NUMCHAMB", (int?)NumberOfChambers);
                    feature.SetAttributeValue("NUMTHROAT", (int?)NumberOfThroats);
                    feature.SetAttributeValue("LOCATIONDETAIL", LocationDetail);
                    feature.SetAttributeValue("OWNER", Owner);
                    feature.SetAttributeValue("CLNRESP",CleaningResponsibility);
                    feature.SetAttributeValue("ISWQI", (WaterQuality == true ? "Y" : "N"));
                    feature.SetAttributeValue("INMS4", (InMS4 == true ? "Y" : "N"));
                    feature.SetAttributeValue("ISCORNRCB", (CornerCB == true ? "Y" : "N"));
                    feature.SetAttributeValue("BIOFLTR", (Biofilter == true ? "Y" : "N"));
                    feature.SetAttributeValue("FLORESTY", FlowRestrictorType);
                    feature.SetAttributeValue("HASSUMP", (Sump == true ? "Y" : "N"));
                    feature.SetAttributeValue("HASWATERSEAL", (WaterSeal == true ? "Y" : "N"));
                    await layer.FeatureTable.UpdateFeatureAsync(feature);
                    feature.Refresh();
                }
                
                
                
               
                


            }
           
            workOrderDetailVM.MaximoWorkOrder.asset = Asset;
            if (WorkOrder.Id > 0){
                MaximoServiceLibrary.AppContext.workOrderRepository.update(WorkOrder);
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
