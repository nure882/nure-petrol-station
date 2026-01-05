using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class GasTypeViewModel
    {
        public string Name { get; set; }

        public GasType ToModel()
        {
            return new GasType()
            {
                Name = Name
            };
        }
    }
}
