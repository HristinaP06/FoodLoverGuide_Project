using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Models
{
    public class SocialMedia
    {
        public Guid Id { get; set; }

        public string Media { get; set; }

        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
