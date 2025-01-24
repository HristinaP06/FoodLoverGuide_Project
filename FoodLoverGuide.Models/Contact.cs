using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public ICollection<string>? SocialMedia { get; set; }

    }
}
