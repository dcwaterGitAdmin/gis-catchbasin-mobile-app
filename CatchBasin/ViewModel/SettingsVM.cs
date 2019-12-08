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

		public SettingsVM(MapVM mapVM)
		{
			MapVM = mapVM;

			VehicleList = MaximoServiceLibrary.AppContext.inventoryRepository.findAll().ToList();
			var labors = MaximoServiceLibrary.AppContext.laborRepository.findAll();
			LaborList = new List<MaximoPerson>();
			foreach (var labor in labors)
			{
				LaborList.AddRange(labor.person);
			}

			CrewList = MaximoServiceLibrary.AppContext.personGroupRepository.findNot("persongroup", "CB00").ToList();

		   MaximoPersonGroup = MaximoServiceLibrary.AppContext.synchronizationService.mxuser?.userPreferences?.setting;

			Crew = MaximoPersonGroup.persongroup;
			LeadMan = MaximoPersonGroup.leadMan;
			SecondMan = MaximoPersonGroup.secondMan;
			DriverMan = MaximoPersonGroup.driverMan;
			Vehicle = MaximoPersonGroup.vehiclenum;

			

		}

		public void Save()
		{
			MaximoPersonGroup.persongroup = Crew;
			MaximoPersonGroup.leadMan = LeadMan;
			MaximoPersonGroup.secondMan =SecondMan;
			MaximoPersonGroup.driverMan = DriverMan ;
			MaximoPersonGroup.vehiclenum =Vehicle ;

			MaximoServiceLibrary.AppContext.personGroupRepository.upsert(MaximoPersonGroup);
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
