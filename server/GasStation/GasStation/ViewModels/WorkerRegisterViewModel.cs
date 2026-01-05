using Repositories.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class WorkerRegisterViewModel
    {
        [Required(ErrorMessage = "Should be not required")]
        [EmailAddress(ErrorMessage = "It doesn't look like an email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Should be not required")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Should be not required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Field should contains from 5 to 30 symbols")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Should be not required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Field should contains from 5 to 30 symbols")]

        public string Surname { get; set; }
        [Required(ErrorMessage = "Should be not required")]
        public DateTime Birthday { get; set; }
        public int StationId { get; set; }

        public Worker ToModel()
        {
            return new Worker()
            {
                Email = Email,
                Password = Password,
                Name = Name,
                Surname = Surname,
                Birthday = Birthday,
                CreateDate = DateTime.Now,
                StationId = StationId
            };
        }
    }
}
