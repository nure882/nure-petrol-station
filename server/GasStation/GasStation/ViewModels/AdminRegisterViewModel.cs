using Repositories.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class AdminRegisterViewModel
    {
        [Required(ErrorMessage = "Should be not required")]
        [EmailAddress(ErrorMessage = "It doesn't look like an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Should be not required")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Should be not required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Field should contains from 5 to 30 symbols")]

        public string Name { get; set; }

        public int? StationId { get; set; }
        
        public Admin ToModel()
        {
            return new Admin()
            {
                Email = Email,
                Password = Password,
                Name = Name,
                CreateDate = DateTime.Now,
                StationId = StationId
            };
        }
    }
}
