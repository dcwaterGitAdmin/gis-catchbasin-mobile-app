﻿using MaximoServiceLibrary;
using MaximoServiceLibrary.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CatchBasin.ViewModel
{
	class WorkOrderDetailVM : BaseVM, Helper.IDetailVM
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
			set { causeIsVisible = value; OnPropertyChanged("CauseIsVisible");}
		}


		private string cause;

		public string Cause
		{
			get { return cause; }
			set { cause = value; OnPropertyChanged("Cause"); SetRemedyList(); }
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
		private ObservableCollection<MaximoDocument> attachments;

		public ObservableCollection<MaximoDocument> Attachments
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
		private ObservableCollection<object> actuals;

		public ObservableCollection<object> Actuals
		{
			get { return actuals; }
			set { actuals = value; OnPropertyChanged("Actuals"); }
		}

		private ObservableCollection<MaximoLabTrans> labTrans;

		public ObservableCollection<MaximoLabTrans> LabTrans
		{
			get { return labTrans; }
			set { labTrans = value; }
		}
		private ObservableCollection<MaximoToolTrans> toolTrans;

		public ObservableCollection<MaximoToolTrans> ToolTrans
		{
			get { return toolTrans; }
			set { toolTrans = value; }
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
		private Command.CancelCommand<WorkOrderDetailVM> cancelCommand;

		public Command.CancelCommand<WorkOrderDetailVM> CancelCommand
		{
			get { return cancelCommand; }
			set { cancelCommand = value; }
		}
		private Command.SaveCommand<WorkOrderDetailVM> saveCommand;

		public Command.SaveCommand<WorkOrderDetailVM> SaveCommand
		{
			get { return saveCommand; }
			set { saveCommand = value; }
		}

		private Command.LaborCommand laborCommand;

		public Command.LaborCommand LaborCommand
		{
			get { return laborCommand; }
			set { laborCommand = value; OnPropertyChanged("LaborCommand"); }
		}

		private Command.ToolCommand toolCommand;

		public Command.ToolCommand ToolCommand
		{
			get { return toolCommand; }
			set { toolCommand = value; OnPropertyChanged("ToolCommand"); }
		}
		private Command.AttachCommand attachCommand;

		public Command.AttachCommand AttachCommand
		{
			get { return attachCommand; }
			set { attachCommand = value; OnPropertyChanged("AttachCommand"); }
		}

		private Command.ShowToolCommand showToolCommand;

		public Command.ShowToolCommand ShowToolCommand
		{
			get { return showToolCommand; }
			set { showToolCommand = value; OnPropertyChanged("ShowToolCommand"); }
		}


		private Command.DeleteToolCommand deleteToolCommand;

		public Command.DeleteToolCommand DeleteToolCommand
		{
			get { return deleteToolCommand; }
			set { deleteToolCommand = value; OnPropertyChanged("DeleteToolCommand"); }
		}


		private Command.ShowLaborCommand showLaborCommand;

		public Command.ShowLaborCommand ShowLaborCommand
		{
			get { return showLaborCommand; }
			set { showLaborCommand = value; OnPropertyChanged("ShowLaborCommand"); }
		}


		private Command.DeleteLaborCommand deleteLaborCommand;

		public Command.DeleteLaborCommand DeleteLaborCommand
		{
			get { return deleteLaborCommand; }
			set { deleteLaborCommand = value; OnPropertyChanged("DeleteLaborCommand"); }
		}


		private Command.ShowAttachmentCommand showAttachmentCommand;

		public Command.ShowAttachmentCommand ShowAttachmentCommand
		{
			get { return showAttachmentCommand; }
			set { showAttachmentCommand = value; OnPropertyChanged("ShowAttachmentCommand"); }
		}


		private Command.DeleteAttachmentCommand deleteAttachmentCommand;

		public Command.DeleteAttachmentCommand DeleteAttachmentCommand
		{
			get { return deleteAttachmentCommand; }
			set { deleteAttachmentCommand = value; OnPropertyChanged("DeleteAttachmentCommand"); }
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
			CancelCommand = new Command.CancelCommand<WorkOrderDetailVM>(this);
			SaveCommand = new Command.SaveCommand<WorkOrderDetailVM>(this);
			LaborCommand = new Command.LaborCommand(this);
			ToolCommand = new Command.ToolCommand(this);
			AttachCommand = new Command.AttachCommand(this);
			ShowToolCommand = new Command.ShowToolCommand(this);
			DeleteToolCommand = new Command.DeleteToolCommand(this);
			ShowLaborCommand = new Command.ShowLaborCommand(this);
			DeleteLaborCommand = new Command.DeleteLaborCommand(this);
			ShowAttachmentCommand = new Command.ShowAttachmentCommand(this);
			DeleteAttachmentCommand = new Command.DeleteAttachmentCommand(this);
			Actuals = new ObservableCollection<object>();
			LabTrans = new ObservableCollection<MaximoLabTrans>();
			ToolTrans = new ObservableCollection<MaximoToolTrans>();
			Attachments = new ObservableCollection<MaximoDocument>();
			LabTrans.CollectionChanged += LabTrans_CollectionChanged;
			ToolTrans.CollectionChanged += ToolTrans_CollectionChanged;
			ProblemList = MaximoServiceLibraryBeanConfiguration.failureListRepository.Find("type", "PROBLEM").Select(x => x.failurecode[0]).ToList<FailureCode>();
			StatusList = MaximoServiceLibraryBeanConfiguration.domainRepository.findOne("WOSTATUS").synonymdomain;
		}

		private void ToolTrans_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Actuals.Clear();
			foreach (var _labtrans in LabTrans.ToList())
			{
				Actuals.Add(_labtrans);
			}
			foreach (var _tooltrans in ToolTrans.ToList())
			{
				Actuals.Add(_tooltrans);
			}
		}

		private void LabTrans_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Actuals.Clear();
			foreach (var _labtrans in LabTrans.ToList())
			{
				Actuals.Add(_labtrans);
			}
			foreach (var _tooltrans in ToolTrans.ToList())
			{
				Actuals.Add(_tooltrans);
			}
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

			foreach (var _labtrans in wo.labtrans ?? new List<MaximoLabTrans>())
			{
				LabTrans.Add(_labtrans);
			}
			foreach (var _tooltrans in wo.tooltrans ?? new List<MaximoToolTrans>())
			{
				ToolTrans.Add(_tooltrans);
			}
			foreach (var _doc in wo.docs ?? new List<MaximoDocument>())
			{
				Attachments.Add(_doc);
			}



			WorkOrder = MaximoWorkOrder.wonum;
			Description = MaximoWorkOrder.description;
			Location = MaximoWorkOrder.location;
			Contact = MaximoWorkOrder.wolo4;
			Phone = MaximoWorkOrder.wolo2;
			AssetTag = MaximoWorkOrder.asset?.assettag;
			Remarks = MaximoWorkOrder.remarkdesc;

			Status = MaximoWorkOrder.status;


			Problem = MaximoWorkOrder.problemcode;
			if (MaximoWorkOrder.failurereport != null)
			{
				if (MaximoWorkOrder.failurereport.Count > 1)
				{
					Cause = MaximoWorkOrder.failurereport[1].failurecode;
				}
				if (MaximoWorkOrder.failurereport.Count > 2)
				{
					Remedy = MaximoWorkOrder.failurereport[2].failurecode;
				}
			}


			foreach (var workOrderSpec in MaximoWorkOrder.workorderspec ?? new List<MaximoWorkOrderSpec>())
			{
				switch (workOrderSpec.assetattrid)
				{
					case "CBDUMPEST":
						DumpEst = Convert.ToDouble(workOrderSpec.numvalue);
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




			Show();
			isDirty = false;
		}

		private void Attachments_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged("Attachments");
		}

		private void Actuals_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged("Actuals");
		}

		public void Save()
		{


			MaximoWorkOrder.wonum = WorkOrder;
			MaximoWorkOrder.description = Description;
			MaximoWorkOrder.location = Location;
			MaximoWorkOrder.wolo4 = Contact;
			MaximoWorkOrder.wolo2 = Phone;
			MaximoWorkOrder.status = Status;

			MaximoWorkOrder.labtrans = LabTrans.ToList();
			MaximoWorkOrder.tooltrans = ToolTrans.ToList();
			MaximoWorkOrder.docs = Attachments.ToList();

			if (MaximoWorkOrder.workorderspec != null && MaximoWorkOrder.workorderspec?.Count > 0)
			{

				for (int i = 0; i < MaximoWorkOrder.workorderspec.Count; i++)
				{
					switch (MaximoWorkOrder.workorderspec[i].assetattrid)
					{
						case "CBDUMPEST":
							if(MaximoWorkOrder.workorderspec[i].numvalue != DumpEst)
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].numvalue = DumpEst;
							break;
						case "CBFUBT":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (BrokenTop ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = BrokenTop ? "Y" : "N";

							break;
						case "CBFUCCTV":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (CCTV ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = CCTV ? "Y" : "N";

							break;
						case "CBFUFAG":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (FlushAlleyGrate ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = FlushAlleyGrate ? "Y" : "N";

							break;
						case "CBFUJB":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (JettingBlown ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = JettingBlown ? "Y" : "N";

							break;
						case "CBFUMC":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (ManualCleaning ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = ManualCleaning ? "Y" : "N";

							break;
						case "CBFUML":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (MissingLid ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = MissingLid ? "Y" : "N";

							break;
						case "CBFUNCB":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (NeedsCheckBlock ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = NeedsCheckBlock ? "Y" : "N";

							break;
						case "CBFUNM":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (NeedsMasonry ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = NeedsMasonry ? "Y" : "N";

							break;
						case "CBFUOSID":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (OilSpill ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = OilSpill ? "Y" : "N";

							break;
						case "CBFUTNR":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (TopNeedsReset ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = TopNeedsReset ? "Y" : "N";

							break;
						case "CBFUTR":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (TreeRoots ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = TreeRoots ? "Y" : "N";

							break;
						case "CBFUVAC":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (Vacuuming ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = Vacuuming ? "Y" : "N";

							break;
						case "CBFUWNR":
							if (MaximoWorkOrder.workorderspec[i].alnvalue != (WallsNeedRepair ? "Y" : "N"))
							{
								MaximoWorkOrder.workorderspec[i].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
							}
							MaximoWorkOrder.workorderspec[i].alnvalue = WallsNeedRepair ? "Y" : "N";

							break;


					}
				}
			}
			else
			{
				MaximoWorkOrder.workorderspec = new List<MaximoWorkOrderSpec>();

				var CBDUMPEST = new MaximoWorkOrderSpec();
				CBDUMPEST.assetattrid = "CBDUMPEST";
				CBDUMPEST.numvalue = DumpEst;
				CBDUMPEST.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBDUMPEST);

				var CBFUBT = new MaximoWorkOrderSpec();
				CBFUBT.assetattrid = "CBFUBT";
				CBFUBT.alnvalue = BrokenTop ? "Y" : "N";
				CBFUBT.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUBT);

				var CBFUCCTV = new MaximoWorkOrderSpec();
				CBFUCCTV.assetattrid = "CBFUCCTV";
				CBFUCCTV.alnvalue = CCTV ? "Y" : "N";
				CBFUCCTV.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUCCTV);

				var CBFUFAG = new MaximoWorkOrderSpec();
				CBFUFAG.assetattrid = "CBFUFAG";
				CBFUFAG.alnvalue = FlushAlleyGrate ? "Y" : "N";
				CBFUFAG.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUFAG);

				var CBFUJB = new MaximoWorkOrderSpec();
				CBFUJB.assetattrid = "CBFUJB";
				CBFUJB.alnvalue = JettingBlown ? "Y" : "N";
				CBFUJB.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUJB);

				var CBFUMC = new MaximoWorkOrderSpec();
				CBFUMC.assetattrid = "CBFUMC";
				CBFUMC.alnvalue = ManualCleaning ? "Y" : "N";
				CBFUMC.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUMC);

				var CBFUML = new MaximoWorkOrderSpec();
				CBFUML.assetattrid = "CBFUML";
				CBFUML.alnvalue = MissingLid ? "Y" : "N";
				CBFUML.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUML);

				var CBFUNCB = new MaximoWorkOrderSpec();
				CBFUNCB.assetattrid = "CBFUNCB";
				CBFUNCB.alnvalue = NeedsCheckBlock ? "Y" : "N";
				CBFUNCB.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUNCB);

				var CBFUNM = new MaximoWorkOrderSpec();
				CBFUNM.assetattrid = "CBFUNM";
				CBFUNM.alnvalue = NeedsMasonry ? "Y" : "N";
				CBFUNM.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUNM);

				var CBFUOSID = new MaximoWorkOrderSpec();
				CBFUOSID.assetattrid = "CBFUOSID";
				CBFUOSID.alnvalue = OilSpill ? "Y" : "N";
				CBFUOSID.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUOSID);

				var CBFUTNR = new MaximoWorkOrderSpec();
				CBFUTNR.assetattrid = "CBFUTNR";
				CBFUTNR.alnvalue = TopNeedsReset ? "Y" : "N";
				CBFUTNR.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUTNR);

				var CBFUTR = new MaximoWorkOrderSpec();
				CBFUTR.assetattrid = "CBFUTR";
				CBFUTR.alnvalue = TreeRoots ? "Y" : "N";
				CBFUTR.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUTR);

				var CBFUVAC = new MaximoWorkOrderSpec();
				CBFUVAC.assetattrid = "CBFUVAC";
				CBFUVAC.alnvalue = Vacuuming ? "Y" : "N";
				CBFUVAC.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUVAC);

				var CBFUWNR = new MaximoWorkOrderSpec();
				CBFUWNR.assetattrid = "CBFUNM";
				CBFUWNR.alnvalue = WallsNeedRepair ? "Y" : "N";
				CBFUWNR.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.workorderspec.Add(CBFUWNR);
			}

			MaximoWorkOrder.remarkdesc = Remarks;

		
			MaximoWorkOrder.problemcode = Problem;

			if (MaximoWorkOrder.failurereport == null)
			{
				MaximoWorkOrder.failurereport = new List<MaximoWorkOrderFailureReport>();
			}
			var count = MaximoWorkOrder.failurereport.Count;
			if (count > 0)
			{
				if (MaximoWorkOrder.failurereport[0].failurecode != Problem)
				{
					MaximoWorkOrder.failurereport[0].failurecode = Problem;
					MaximoWorkOrder.failurereport[0].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
				}

			}
			else
			{
				var failureProblemCode = new MaximoWorkOrderFailureReport();
				failureProblemCode.failurecode = Problem;
				failureProblemCode.wonum = MaximoWorkOrder.wonum;
				failureProblemCode.type = "PROBLEMCODE";
				failureProblemCode.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.failurereport.Add(failureProblemCode);
			}

			if (count > 1)
			{
				if (MaximoWorkOrder.failurereport[1].failurecode != Cause)
				{
					MaximoWorkOrder.failurereport[1].failurecode = Cause;
					MaximoWorkOrder.failurereport[1].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
				}
			}
			else
			{
				var failureCause = new MaximoWorkOrderFailureReport();
				failureCause.failurecode = Cause;
				failureCause.wonum = MaximoWorkOrder.wonum;
				failureCause.type = "CAUSE";
				failureCause.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.failurereport.Add(failureCause);
			}

			if (count > 2)
			{
				if (MaximoWorkOrder.failurereport[2].failurecode != Remedy)
				{
					MaximoWorkOrder.failurereport[2].failurecode = Remedy;
					MaximoWorkOrder.failurereport[2].syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.MODIFIED;
				}
			}
			else
			{
				var failureRemedy = new MaximoWorkOrderFailureReport();
				failureRemedy.failurecode = Remedy;
				failureRemedy.type = "REMEDY";
				failureRemedy.wonum = MaximoWorkOrder.wonum;
				failureRemedy.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoWorkOrder.failurereport.Add(failureRemedy);
			}


			if (MaximoWorkOrder.Id > 0)
			{

				MaximoServiceLibraryBeanConfiguration.workOrderRepository.update(MaximoWorkOrder);
			}
			else
			{
				MaximoWorkOrder.syncronizationStatus = LocalDBLibrary.model.SyncronizationStatus.CREATED;
				MaximoServiceLibraryBeanConfiguration.workOrderRepository.upsert(MaximoWorkOrder);
			}


			isDirty = false;
			MapVM.HideWorkOrderDetail();
		}

		public void Cancel()
		{
			if (isDirty)
			{
				MessageBoxResult messageBoxResult = MessageBox.Show("Workorder was modified. Save Changes?", "Workorder :" + MaximoWorkOrder.wonum, MessageBoxButton.YesNo, MessageBoxImage.Warning);

				if (messageBoxResult == MessageBoxResult.Yes)
				{
					Save();
				}
				else if (messageBoxResult == MessageBoxResult.No)
				{

					MapVM.HideWorkOrderDetail();
				}
			}
			else
			{
				MapVM.HideWorkOrderDetail();
			}
		}

		public void Clear()
		{
			MaximoWorkOrder = null;
			Attachments.Clear();
			LabTrans.Clear();
			ToolTrans.Clear();
			Actuals.Clear();
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
				case "INV":
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
			if (MaximoWorkOrder != null && MaximoWorkOrder.asset != null)
			{

				MaximoAsset asset = MaximoServiceLibraryBeanConfiguration.assetRepository.findOne(MaximoWorkOrder.asset.assetnum);
				MapVM.ShowAssetDetail(asset);
			}
			else
			{
				// todo message
			}

		}

		public void HideAssetDetail()
		{
			MapVM.HideAssetDetail();
		}

		public void SetCauseList()
		{
			if (Problem != null)
			{
				RemedyList = null;
				var selectedProblem = MaximoServiceLibraryBeanConfiguration.failureListRepository.Find("failurecode[0].failurecode", Problem).ToArray()[0];

				CauseList = MaximoServiceLibraryBeanConfiguration.failureListRepository.Find("parent", selectedProblem?.failurelist).Select(x => x.failurecode[0]).ToList<FailureCode>();

			}

		}

		public void SetRemedyList()
		{
			if (Cause != null)
			{
				var selectedCause = MaximoServiceLibraryBeanConfiguration.failureListRepository.Find("failurecode[0].failurecode", Cause).ToArray()[0];

				RemedyList = MaximoServiceLibraryBeanConfiguration.failureListRepository.Find("parent", selectedCause?.failurelist).Select(x => x.failurecode[0]).ToList<FailureCode>();

			}

		}
	}
}
