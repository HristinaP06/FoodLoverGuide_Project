using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FoodLoverGuide.Models
{
    public class RestaurantPhoto
    {
        [Key]
        public Guid Id { get; set; }

        public string? Photo { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
