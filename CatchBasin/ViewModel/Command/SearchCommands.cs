using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CatchBasin.ViewModel.Commands
{

    class BaseSearchCommand : ICommand
    {
        public SearchVM SearchVM;

        public BaseSearchCommand(SearchVM searchVM)
        {
            SearchVM = searchVM;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual void Execute(object parameter)
        {

        }
    }


    class GeoCodeCommand : BaseSearchCommand
    {
        public GeoCodeCommand(SearchVM searchVM) : base(searchVM)
        {

        }

        public override void Execute(object parameter)
        {

            SearchVM.Geocode();

        }

    }

    class SearchInLayerCommand : BaseSearchCommand
    {
        public SearchInLayerCommand(SearchVM searchVM) : base(searchVM)
        {

        }

        public override void Execute(object parameter)
        {
            SearchVM.SearchInLayer();



        }

    }

    class SearchFlashCommand : BaseSearchCommand
    {
        public SearchFlashCommand(SearchVM searchVM) : base(searchVM)
        {

        }

        public override void Execute(object parameter)
        {
            SearchVM.Flash();



        }

    }

    class SearchZoomToCommand : BaseSearchCommand
    {
        public SearchZoomToCommand(SearchVM searchVM) : base(searchVM)
        {

        }

        public override void Execute(object parameter)
        {
            SearchVM.ZoomTo();



        }

    }



    class GeoCodeFlashCommand : BaseSearchCommand
    {
        public GeoCodeFlashCommand(SearchVM searchVM) : base(searchVM)
        {

        }

        public override void Execute(object parameter)
        {
            SearchVM.GeoCodeFlash();



        }

    }

    class GeoCodeZoomToCommand : BaseSearchCommand
    {
        public GeoCodeZoomToCommand(SearchVM searchVM) : base(searchVM)
        {

        }

        public override void Execute(object parameter)
        {
            SearchVM.GeoCodeZoomTo();



        }

    }


    class ZoomToStreetCoomand : BaseSearchCommand
    {
        public ZoomToStreetCoomand(SearchVM searchVM) : base(searchVM)
        {

        }

        public override void Execute(object parameter)
        {
            SearchVM.ZoomToStreet();



        }

    }

    class FlashStreetCoomand : BaseSearchCommand
    {
        public FlashStreetCoomand(SearchVM searchVM) : base(searchVM)
        {

        }

        public override void Execute(object parameter)
        {
            SearchVM.FlashStreet();



        }

    }

    class ReLoadStreetCoomand : BaseSearchCommand
    {
        public ReLoadStreetCoomand(SearchVM searchVM) : base(searchVM)
        {

        }

        public override void Execute(object parameter)
        {
            SearchVM.FillOtherStreetData();



        }

    }
}
