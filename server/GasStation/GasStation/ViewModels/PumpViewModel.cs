using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class PumpViewModel
    {
        public double GasCount { get; set; }
        public int Number { get; set; }
        public int StationId { get; set; }
        public int GasTypeId { get; set; }
        public double Cost { get; set; }

        public Pump ToModel()
        {
            return new Pump()
            {
                GasCount = GasCount,
                Number = Number,
                StationId = StationId,
                GasTypeId = GasTypeId,
                Cost = Cost
            };
        }
    }
}
