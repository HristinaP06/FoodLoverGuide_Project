using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FoodLoverGuide.Models
{
    public class MenuItem
    {
        [Key]
        public Guid Id { get; set; }

        public string? Photo { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public int Order { get; set; }
    }
}
