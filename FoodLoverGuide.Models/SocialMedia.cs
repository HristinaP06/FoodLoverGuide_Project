using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Models
{
    public class SocialMedia
    {
        [Key]
        public Guid Id { get; set; }

        public string? Media { get; set; }

        public Guid? ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
