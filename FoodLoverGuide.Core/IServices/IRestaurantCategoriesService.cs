using FoodLoverGuide.Core.ViewModels.Restaurant;
using FoodLoverGuide.Models;

namespace FoodLoverGuide.Core.IServices
{
	public interface IRestaurantCategoriesService : IService<RestaurantCategories>
    {
		Task<Guid> AddRestaurantCategories(AddCategoryToRestaurantVM model);

		Task<List<Guid>> GetCategoryIdsForRestaurantAsync(Guid id);
    }
}
