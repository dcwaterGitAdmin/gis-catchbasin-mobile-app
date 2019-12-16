using MaximoServiceLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CatchBasin.ViewModel
{
	class SettingsVM:BaseVM,Helper.IDetailVM
	{

		private string crew;

		public string Crew
		{
			get { return crew; }
			set { crew = value; OnPropertyChanged("Crew"); }
		}


		private List<MaximoPersonGroup> crewList;

		public List<MaximoPersonGroup> CrewList
		{
			get { return crewList; }
			set { crewList = value; OnPropertyChanged("CrewList"); }
		}

		private string leadMan;

		public string LeadMan
		{
			get { return leadMan; }
			set { leadMan = value; OnPropertyChanged("LeadMan"); }
		}

		private string secondMan;

		public string SecondMan
		{
			get { return secondMan; }
			set { secondMan = value; OnPropertyChanged("SecondMan"); }
		}

		private bool secondManIsVisible;

		public bool SecondManIsVisible
		{
			get { return secondManIsVisible; }
			set { secondManIsVisible = value; OnPropertyChanged("SecondManIsVisible"); }
		}


		private string driverMan;

		public string DriverMan
		{
			get { return driverMan; }
			set { driverMan = value; OnPropertyChanged("DriverMan"); }
		}


		private List<MaximoPerson> driverList;

		public List<MaximoPerson> DriverList
		{
			get { return driverList; }
			set { driverList = value; OnPropertyChanged("DriverList"); }
		}


		private List<MaximoPerson> laborList;

		public List<MaximoPerson> LaborList
		{
			get { return laborList; }
			set { laborList = value; OnPropertyChanged("LaborList"); }
		}

		private string vehicle;

		public string Vehicle
		{
			get { return vehicle; }
			set { vehicle = value; OnPropertyChanged("Vehicle"); }
		}


		private List<MaximoInventory> vehicleList;

		public List<MaximoInventory> VehicleList
		{
			get { return vehicleList; }
			set { vehicleList = value; OnPropertyChanged("VehicleList"); }
		}

        private bool leadManIsEnabled;

        public bool LeadManIsEnabled
        {
            get { return leadManIsEnabled; }
            set { leadManIsEnabled = value; OnPropertyChanged("LeadManIsEnabled"); }
        }

        private bool secondManIsEnabled;

        public bool SecondManIsEnabled
        {
            get { return secondManIsEnabled; }
            set { secondManIsEnabled = value; OnPropertyChanged("SecondManIsEnabled"); }
        }



        private Command.SaveCommand<SettingsVM> saveCommand;

		public Command.SaveCommand<SettingsVM> SaveCommand
		{
			get { return saveCommand; }
			set { saveCommand = value; OnPropertyChanged("SaveCommand"); }
		}

		private Command.CancelCommand<SettingsVM> cancelCommand;

		public Command.CancelCommand<SettingsVM> CancelCommand
		{
			get { return cancelCommand; }
			set { cancelCommand = value;OnPropertyChanged("CancelCommand"); }
		}

		public MaximoPersonGroup MaximoPersonGroup { get; set; }

		MapVM MapVM;
		public string AppType = ((App)Application.Current).AppType;

		public SettingsVM(MapVM mapVM)
		{
			MapVM = mapVM;

			CancelCommand = new Command.CancelCommand<SettingsVM>(this);
			SaveCommand = new Command.SaveCommand<SettingsVM>(this);
			DriverList = new List<MaximoPerson>();

       
			if(AppType == "PM")
			{
				secondManIsVisible = true;
			}
			else
			{
				secondManIsVisible = false;
			}

			VehicleList = MaximoServiceLibrary.AppContext.inventoryRepository.findAll().ToList();
			List<string> craftrate;
			if (AppType == "PM")
			{
				craftrate = new string[] { "SSWR", "SSLR", "SSWL" }.ToList();
			}
			else
			{
				craftrate = new string[] { "SSWR", "SSLR", "SSWL", "SCRW", "CNRW" }.ToList();
			}

			var labors = MaximoServiceLibrary.AppContext.laborRepository.findAll().Where(labor =>labor.laborcraftrate.Where(laborcraftrate => craftrate.Contains(laborcraftrate.craft)).Count()>0);
			LaborList = new List<MaximoPerson>();
			foreach (var labor in labors)
			{
				LaborList.AddRange(labor.person.Where(per => per.status == "ACTIVE").ToList());
			}
            MaximoPersonGroup = MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.setting;
            // find leadMan
            var leadList=LaborList.Where(person => person.personid == MaximoPersonGroup.leadMan).ToList();
            if (leadList.Count > 0)
            {
                DriverList.Add(leadList[0]);
            }
           
            if(AppType == "PM")
            {
                var secondList = LaborList.Where(person => person.personid == MaximoPersonGroup.secondMan).ToList();
                if (secondList.Count > 0)
                {
                    DriverList.Add(secondList[0]);
                }
            }


         

			Crew = MaximoPersonGroup.persongroup;
			LeadMan = MaximoPersonGroup.leadMan;
			if(AppType == "PM")
			{
				SecondMan = MaximoPersonGroup.secondMan;
			}
			
			DriverMan = MaximoPersonGroup.driverMan;
			Vehicle = MaximoPersonGroup.vehiclenum;



            if(LeadMan.ToUpper() == MaximoServiceLibrary.AppContext.synchronizationService.mxuser.personId.ToUpper())
            {
                LeadManIsEnabled = false;
                SecondManIsEnabled = true;
            }else if(SecondMan.ToUpper() == MaximoServiceLibrary.AppContext.synchronizationService.mxuser.personId.ToUpper())
            {
                LeadManIsEnabled = true;
                SecondManIsEnabled = false;
            }
            else
            {
                // todo for test
                LeadManIsEnabled = true;
                SecondManIsEnabled = true;
            }

			// todo generate driverlist
			PropertyChanged += SettingsVM_PropertyChanged;

		}

		private void SettingsVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{

			switch (e.PropertyName)
			{
				case "LeadMan":
				case "SecondMan":

					MaximoPerson leadPerson = null ;
					MaximoPerson secondPerson = null;
					var l = LaborList.Where(person => person.personid == LeadMan).ToList();
					if (l.Count > 0)
					{
						leadPerson =l[0];
					}
					
					
					if (AppType == "PM")
					{
						var list = LaborList.Where(person => person.personid == SecondMan).ToList();
						if (list.Count > 0)
						{
							secondPerson = list[0];
						}
						
					}

					var tempList = new List<MaximoPerson>();
					if(leadPerson != null)
					{
						tempList.Add(leadPerson);
					}
					if (secondPerson != null)
					{
						tempList.Add(secondPerson);
					}
					DriverList = tempList;
					if (DriverMan != LeadMan && DriverMan != SecondMan)
					{
						   DriverMan = e.PropertyName == "LeadMan" ? LeadMan : SecondMan;
					}
					
					break;
			}

		

			
		}

		public void Save()
		{


			MaximoPersonGroup.persongroup = Crew;
			MaximoPersonGroup.leadMan = LeadMan;
			if(AppType == "PM")
			{
				MaximoPersonGroup.secondMan = SecondMan;
			}
			
			MaximoPersonGroup.driverMan = DriverMan ;
			MaximoPersonGroup.vehiclenum =Vehicle ;

			MaximoServiceLibrary.AppContext.synchronizationService.mxuser.userPreferences.selectedPersonGroup = Crew;
			MaximoServiceLibrary.AppContext.personGroupRepository.upsert(MaximoPersonGroup);
			MaximoServiceLibrary.AppContext.userRepository.upsert(MaximoServiceLibrary.AppContext.synchronizationService.mxuser);

			MapVM.updateDefinitionQuery();
			MapVM.WorkOrderListVM.Update();
			MapVM.UpdateUserInfo();
			Close();
		}

		public void Cancel()
		{
			Close();
		}

		public void Close()
		{
			foreach (var window in ((App)Application.Current).Windows)
			{
				if (window is View.Settings)
				{
					((View.Settings)window).Close();
				}
			}
		}
	}
}
