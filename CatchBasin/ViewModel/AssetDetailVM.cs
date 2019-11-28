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
    class AssetDetailVM :BaseVM
    {
        private MapVM mapVM;

        public MapVM MapVM
        {
            get { return mapVM; }
            set { mapVM = value;  OnPropertyChanged("MapVM");}
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


        private bool isDirty;
        MaximoAsset Asset;
        public MaximoServiceLibraryBeanConfiguration MaximoServiceLibraryBeanConfiguration;

        public AssetDetailVM(MapVM _mapVM)
        {
            PropertyChanged += AssetDetailVM_PropertyChanged;
            MapVM = _mapVM;
            
            MaximoServiceLibraryBeanConfiguration = new MaximoServiceLibraryBeanConfiguration();

            
            TypeList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("CB_SUBT").alndomain;
            TopMaterialList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("CBTOPMATRL").alndomain;
            TopThicknessList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("CBTOPTHICK").numericdomain;
            GrateTypeList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("CBGRATETYPE").alndomain;
            OwnerList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("OWNER").alndomain;
            CleaningResponsibilityList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("CLNRESP").alndomain;

           
            FlowRestrictorTypeList.Add(new StaticDomain("ORIFICE", "Orifice"));
            FlowRestrictorTypeList.Add(new StaticDomain("BAFFLE", "Baffle"));
            FlowRestrictorTypeList.Add(new StaticDomain("WEIR", "Weir"));
            FlowRestrictorTypeList.Add(new StaticDomain("OTHER", "Other"));

        }

        private void AssetDetailVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            isDirty = true;
        }

        public void Update(MaximoAsset asset)
        {
            Asset = asset;

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

            foreach (MaximoAssetSpec assetSpec in Asset.assetspec)
            {
                switch (assetSpec.assetattrid)
                {
                    case "CB_SUBT":
                        assetSpec.alnvalue = Type;
                        break;
                    case "TOPMATRL":
                        assetSpec.alnvalue = TopMaterial;
                        break;
                    case "TOPTHICK":
                        assetSpec.numvalue = TopThickness;
                        break;
                    case "GRATETY":
                        assetSpec.alnvalue = GrateType;
                        break;
                    case "NUMCHAMB":
                        assetSpec.numvalue = NumberOfChambers;
                        break;
                    case "NUMTHROAT":
                        assetSpec.numvalue = NumberOfThroats;
                        break;
                    case "OWNER":
                        assetSpec.alnvalue = Owner;
                        break;
                    case "CLN_RESP":
                        assetSpec.alnvalue = CleaningResponsibility;
                        break;
                    case "WQ":
                        assetSpec.alnvalue = WaterQuality == true ? "Y" : "N" ;
                        break;
                    case "INMS4":
                        assetSpec.alnvalue = InMS4 == true ? "Y" : "N";
                        break;
                    case "ISCORNRCB":
                        assetSpec.alnvalue = CornerCB == true ? "Y" : "N";
                        break;
                    case "BIOFLTR":
                        assetSpec.alnvalue = Biofilter == true ? "Y" : "N";
                        break;
                    case "FLORESTY":
                        assetSpec.alnvalue = FlowRestrictorType;
                        break;
                    case "HASSUMP":
                        assetSpec.alnvalue = Sump == true ? "Y" : "N";
                        break;
                    case "HASWATERSEAL":
                        assetSpec.alnvalue = WaterSeal == true ? "Y" : "N";
                        break;

                }
            }
            // asset maybe choosed or created on map!
            if (Asset.Id > 0){
                MaximoServiceLibraryBeanConfiguration.assetRepository.update(Asset);
            }
            else
            {
                Asset.editedFromApp = true;
                MaximoServiceLibraryBeanConfiguration.assetRepository.insert(Asset);
            }

            MapVM.HideAssetDetail();
        }

        public void Cancel()
        {
            if (isDirty)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Asset was modified. Discard Changes?", "Asset :" + Asset.assetnum, MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    MapVM.HideAssetDetail();
                }
                else if (messageBoxResult == MessageBoxResult.No)
                {
                    Save();

                }
            }
        }
    }

    class StaticDomain
    {
        public StaticDomain(string _code, string _desc)
        {
            code = _code;
            description = _desc;
        }
        string code { get; set; }
        string description { get; set; }
    }
}
