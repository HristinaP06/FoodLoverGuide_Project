using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodLoverGuide.Models
{
    public class Restaurant
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category RestaurantCategories { get; set; }

        public ICollection<WorkTimeSchedule> WorkTime { get; set; }

        public double? PriceRangeFrom { get; set; }
        public double? PriceRangeTo { get; set; }

        [ForeignKey(nameof(MenuItem))]  
        public Guid MenuId { get; set; }
        public ICollection<MenuItem> Menu { get; set; }

        [ForeignKey(nameof(RestaurantPhoto))]
        public Guid RestaurantPhotoId { get; set; }
        public ICollection<RestaurantPhoto>? Photos { get; set; }

        public ICollection<RestaurantFeature>? Features { get; set; }

        [ForeignKey(nameof(Review))]
        public  Guid ReviewsId { get; set; }
        public ICollection<Review>? Reviews { get; set; }

        [ForeignKey(nameof(Rating))]
        public Guid RatingId { get; set; }
        public ICollection<Rating>? RatingList { get; set; }

        public int? IndoorCapacity { get; set; }
        public int? OutdoorCapacity { get; set; }

        [ForeignKey(nameof(Contact))]
        public Guid ContactsId { get; set; }
        public Contact? RestaurantContacts { get; set; }
    }
}
