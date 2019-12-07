using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCWaterMobile.MaximoService.MaxRest;

namespace DCWaterMobile.MaximoService
{
    public class CompositeWorkorderSet
    {
        public CompositeWorkorder[] CompositeWorkorders { get; set; }

    }

    public class CompositeWorkorder
    {
        public WORKORDERMbo WORKORDER { get; set; }
        public WORKORDERSPECMboSetWORKORDERSPEC[] WORKORDERSPEC { get; set; }
        public CompositeAsset compositeAsset { get; set; }
        public LOCATIONSMboSetLOCATIONS[] LOCATIONS { get; set; }
        public DOCLINKSMboSetDOCLINKS[] DOCLINKS  { get; set; }
        public DOCINFOMboSetDOCINFO[] DOCINFO  { get; set; }
        public LABTRANSMboSetLABTRANS[] LABTRANS  { get; set; }
        public TOOLTRANSMboSetTOOLTRANS[] TOOLTRANS  { get; set; }
        public FAILUREREMARKMboSetFAILUREREMARK[] FAILUREREMARK  { get; set; }
        public FAILUREREPORTMboSetFAILUREREPORT[] FAILUREREPORT  { get; set; }
        public WOSTATUSMboSetWOSTATUS[] WOSTATUS { get; set; }

    }
}
