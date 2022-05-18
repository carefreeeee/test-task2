using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testZad
{
    internal class SaveData
    {
        public int type { get; set; }   
        public int salt { get; set; }
        public double? degree { get; set; }    
        public double? iciness { get; set; }
        public double? totalHumidity { get; set; }
        public double? humidityFrozen { get; set; }
    }
}
