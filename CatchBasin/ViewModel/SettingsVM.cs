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

			CrewList = MaximoServiceLibrary.AppContext.personGroupRepository.findNot("persongroup", "CB00").ToList();

		   MaximoPersonGroup = MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.setting;

			Crew = MaximoPersonGroup.persongroup;
			LeadMan = MaximoPersonGroup.leadMan;
			if(AppType == "PM")
			{
				SecondMan = MaximoPersonGroup.secondMan;
			}
			
			DriverMan = MaximoPersonGroup.driverMan;
			Vehicle = MaximoPersonGroup.vehiclenum;

			PropertyChanged += SettingsVM_PropertyChanged;

		}

		private void SettingsVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if(e.PropertyName == "Crew")
			{
				

				MaximoPersonGroup = MaximoServiceLibrary.AppContext.personGroupRepository.findOne(Crew);

				LeadMan = MaximoPersonGroup.leadMan;
				if (AppType == "PM")
				{
					SecondMan = MaximoPersonGroup.secondMan;
				}
				
				DriverMan = MaximoPersonGroup.driverMan;
				Vehicle = MaximoPersonGroup.vehiclenum;
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
