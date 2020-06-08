using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoServiceLibrary.model
{
    public class GeoEventData
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double velocity { get; set; }
        public double accuracy { get; set; }
        public double course { get; set; }
        public DateTimeOffset? time { get; set; }
        public string userid { get; set; }
        public double haccuracy { get; set; }
    }
}
