using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Models
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }


        
        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public int? Adults { get; set; }

        public int? Children { get; set; }

        public DateTime Date { get; set; }

    }
}
