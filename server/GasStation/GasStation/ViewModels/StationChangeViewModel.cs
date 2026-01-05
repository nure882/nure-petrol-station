using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class StationChangeViewModel : StationViewModel
    {
        public int StationId { get; set; }
        public new Station ToModel()
        {
            return new Station()
            {
                StationId = StationId,
                City = City,
                Address = Address,
                WorkTime = WorkTime,
                Description = Description,
                EquipmentList = EquipmentList
            };
        }
    }
}
