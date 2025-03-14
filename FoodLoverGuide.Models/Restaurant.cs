using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodLoverGuide.Models
{
    public class Restaurant
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MaxLength(3000)]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public ICollection<Reservation>? Reservation {  get; set; }

        public ICollection<RestaurantCategories>? RestaurantCategoriesList { get; set; }

        public ICollection<WorkTimeSchedule> WorkTime { get; set; }

        public double? PriceRangeFrom { get; set; }

        public double? PriceRangeTo { get; set; }

        public ICollection<MenuItem>? Menu { get; set; }

        public ICollection<RestaurantPhoto>? Photos { get; set; }

        public ICollection<RestaurantFeature>? Features { get; set; }

        public ICollection<Review>? Reviews { get; set; }

        public ICollection<Rating>? RatingList { get; set; }

        public int? IndoorCapacity { get; set; }

        public int? OutdoorCapacity { get; set; }

        public string? Telephone { get; set; }

        public string? Email { get; set; }

        public string? Instagram { get; set; }

        public string? Facebook { get; set; }

        public string? WebSite { get; set; }
    }
}
