using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class GasTypeChangeViewModel : GasTypeViewModel
    {
        public int GasTypeId { get; set; }

        public new GasType ToModel()
        {
            return new GasType()
            {
                Name = Name,
                GasTypeId = GasTypeId
            };
        }
    }
}
