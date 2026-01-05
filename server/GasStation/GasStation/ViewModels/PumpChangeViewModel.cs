using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class PumpChangeViewModel : PumpViewModel
    {
        public int PumpId { get; set; }

        public new Pump ToModel()
        {
            return new Pump()
            {
                GasCount = GasCount,
                Number = Number,
                StationId = StationId,
                GasTypeId = GasTypeId,
                Cost = Cost,
                PumpId = PumpId
            };
        }
    }
}
