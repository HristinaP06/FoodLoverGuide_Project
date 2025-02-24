using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.IServices
{
	public interface IRestaurantCategoriesService : IService<RestaurantCategories>
    {
		Task AddRestaurantCategories(AddCategoryToRestaurantVM model);
	}
}
