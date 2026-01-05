using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class Pump
    {
        public int PumpId { get; set; }
        public double GasCount { get; set; }
        public int Number { get; set; }
        public Station Station { get; set; }
        public int StationId { get; set; }
        public GasType GasType { get; set; }
        public int GasTypeId { get; set; }
        public double Cost { get; set; }
    }
}
