using System.ComponentModel.DataAnnotations;

namespace FoodLoverGuide.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CategoryName { get; set; }


        public ICollection<RestaurantCategories> RestaurantCategoriesList = new List<RestaurantCategories>();
    }
}
