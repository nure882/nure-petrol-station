using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation.ViewModels
{
    public class WorkerChangeViewModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public int StationId { get; set; }

        public Worker ChangeValues(Worker worker)
        {
            worker.Name = Name;
            worker.Surname = Surname;
            worker.Birthday = Birthday;
            worker.StationId = StationId;
            return worker;
        }
    }
}
