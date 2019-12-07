using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCWaterMobile.MaximoService.MaxRest;

namespace DCWaterMobile.MaximoService
{
    public class CompositeAssetSet
    {
        public CompositeAsset[] CompositeAssets { get; set; }

    }

    public class CompositeAsset
    {
//        public ASSETMboSetASSET ASSET { get; set; }
        public ASSETMbo ASSET { get; set; }
        public ASSETSPECMboSetASSETSPEC[] ASSETSPEC { get; set; }
    }
}
