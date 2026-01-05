using GasStationMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GasStationMobile.ViewModels
{
    public class RegistViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }

        public Customer ToModel()
        {
            return new Customer()
            {
                Email = Email,
                Name = Name,
                Surname = Surname,
                Password = Password,
                Birthday = Birthday
            };
        }
    }
}
