namespace FoodLoverGuide.Core.ViewModels.Restaurant
{
    public class AddCategoryToRestaurantVM
    {
        public Guid RestaurantId { get; set; }

        public  List<Guid> SelectedCategoriesIds { get; set; } = new List<Guid>();

        public List<FoodLoverGuide.Models.Category> CategoriesList { get; set; } = new List<FoodLoverGuide.Models.Category>();

        public string NextAction { get; set; }
    }
}
