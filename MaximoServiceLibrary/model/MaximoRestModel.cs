using System;
using System.Collections.Generic;

namespace MaximoServiceLibrary.model
{

    public class MaximoRestPageRef
    {
        public string href { get; set; }
    }

    public class MaximoRestResponseInfo
    {
        public int totalCount { get; set; }
        public string href { get; set; }
        public MaximoRestPageRef nextPage { get; set; }
        public MaximoRestPageRef previousPage { get; set; }
    }
    
    public class MaximoBaseRestResponse<T>
    {
        public List<T> member { get; set; }
    }

    public class MaximoBasePageableRestResponse<T> : MaximoBaseRestResponse<T>
    {
        public MaximoRestResponseInfo responseInfo { get; set; }
        public string href { get; set; }
    }
    
    public class MaximoWorkOrderPageableRestResponse : MaximoBasePageableRestResponse<MaximoWorkOrder>
    {
    }

    public class MaximoAssetRestResponse : MaximoBaseRestResponse<MaximoAsset>
    {
    }
    
}