using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodLoverGuide.Models
{
    public class Restaurant
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [ForeignKey(nameof(Categories))]
        public Guid CategoryId { get; set; }
        public Categories Category { get; set; }

        [ForeignKey(nameof(WorkTimeSchedule))]
        public Guid WorkTimeId { get; set; }
        public WorkTimeSchedule WorkTime { get; set; }

        [ForeignKey(nameof(PriceRanges))]
        public Guid PriceRangeId { get; set; }

        [Required]
        public PriceRanges PriceRange { get; set; }

        [Required]  
        public string Menu { get; set; }

        [ForeignKey(nameof(RestaurantFeatures))]
        public RestaurantFeatures Features { get; set; }
        



    }
}
