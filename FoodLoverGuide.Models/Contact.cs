using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        public string? Telephone { get; set; }

        public string? Email { get; set; }

        public ICollection<SocialMedia>? SocialMedia { get; set; }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
