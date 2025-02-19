using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
    public class AddCategoryToRestaurantVM
    {
        public Guid RestaurantId { get; set; }

        public Models.Restaurant Restaurant { get; set; }

        public  List<Guid> SelectedCategoriesIds { get; set; } = new List<Guid>();

        public List<Category> CategoriesList { get; set; } = new List<Category>();
    }
}
