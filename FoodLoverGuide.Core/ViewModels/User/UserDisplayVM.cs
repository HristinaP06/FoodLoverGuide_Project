using FoodLoverGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Core.ViewModels.User
{
    public class UserDisplayVM
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
