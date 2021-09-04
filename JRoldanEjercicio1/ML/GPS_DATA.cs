using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
   public class GPS_DATA
    {
        public int Id { get; set; }
        public string DateSystem { get; set; }
        public string DateEvent { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Battery { get; set; }
        public int Source { get; set; }
        public int Type { get; set; }
    }
}
