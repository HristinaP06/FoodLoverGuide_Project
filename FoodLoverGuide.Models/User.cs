using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FoodLoverGuide.Models
{
    public class User : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }

        public ICollection<Rating>? Ratings { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}
