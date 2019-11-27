using MaximoServiceLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchBasin.ViewModel
{
    class AssetDetailVM
    {
        private MapVM mapVM;

        public MapVM MapVM
        {
            get { return mapVM; }
            set { mapVM = value; }
        }
        public AssetDetailVM(MapVM _mapVM)
        {
            MapVM = _mapVM;
        }

        public void Update(MaximoWorkOrder wo)
        {

        }

        public void Clear()
        {

        }
    }
}
