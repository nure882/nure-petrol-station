using Repositories.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class StationViewModel
    {
        [Required(ErrorMessage = "Should be not required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Should be not required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Should be not required")]
        public string WorkTime { get; set; }
        public string Description { get; set; }
        public string EquipmentList { get; set; }
        public Station ToModel()
        {
            return new Station()
            {
                City = City,
                Address = Address,
                WorkTime = WorkTime,
                Description = Description,
                EquipmentList = EquipmentList
            };
        }
    }
}
